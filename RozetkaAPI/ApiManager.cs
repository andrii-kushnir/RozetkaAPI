using Newtonsoft.Json;
using RozetkaAPI.Models;
using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace RozetkaAPI
{
	public class ApiManager
	{
		public const string apiPath = "https://api-seller.rozetka.com.ua/";

		private static string _username = "shop@ars.ua";
		private static string _password64 = "Nkp2bXg1QlI3bjZW";

		private static readonly string _sql_database = "[InetClient].[dbo].";

		private string _token;

		public static ApiManager Current { get; private set; }


		public ApiManager()
		{
			if (Current == null)
				Current = this;
		}

		public LoginResponse Login()
		{
			return Login(_username, _password64);
		}

		public static LoginResponse Login(string username, string password, bool issql = false)
		{
			LoginResponse result = null;

			var keysBody = new Dictionary<string, string>
			{
				{ "username", username },
				{ "password", password }
			};

			string response = null;
			string error;
			try
			{
				response = RequestData.FormDataRequest(apiPath + "sites", null, keysBody, null, null, null, out error);
			}
			catch (Exception ex)
			{
				error = ex.Message + "  ";
			}
			result = response.ConvertJson<LoginResponse>(ref error);
            if (issql)
                SaveErrorToSQL(error);
            if (result != null && result.success && !issql)
                Current._token = result.content.access_token;
			return result;
		}

        public LogoutResponse Logout()
        {
            LogoutResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.FormDataRequest(apiPath + "sites/logout", _token, null, null, null, null, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
            }
            result = response.ConvertJson<LogoutResponse>(ref error);
            return result;
        }

        public static void SaveErrorToSQL(string error)
        {
            if (!String.IsNullOrWhiteSpace(error))
            {
                var methodName = new StackTrace(1).GetFrame(0).GetMethod().Name;
                using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
                {
                    connection.Open();
                    var sql = $@"INSERT INTO {_sql_database}[RozetkaErrorLog] (error, date) VALUES ('{methodName} error: {error}', '{DateTime.Now.DateToSQL()}')";
                    using (var query = new SqlCommand(sql, connection))
                        query.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        //public ProductResponse GetTovar(int id)
        //{
        //    ProductResponse result = null;
        //    if (_token == null) return result;
        //    HttpResponseMessage response;
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        //    try
        //    {
        //        response = _httpClient.GetAsync($"{apiPath}items/search?product_id={id}").Result;
        //    }
        //    catch { return null; }
        //    result = ParseResponse<ProductResponse>(response, out var error);
        //    return result;
        //}

        public OrderStatusesResponse GetOrderStatus(int status = 0)
        {
            OrderStatusesResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;

            try
            {
                if (status == 0)
                    response = RequestData.SendGet($"{apiPath}order-statuses/search?&expand=status_available", _token, out error);
                 else
                    response = RequestData.SendGet($"{apiPath}order-statuses/search?id={status}&expand=status_available", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<OrderStatusesResponse>(ref error);
            return result;
        }

        //public OrdersSearchResponse GetOrdersSearch(int type)
        //{
        //	OrdersSearchResponse result = null;
        //	if (_token == null) return result;
        //	HttpResponseMessage response;
        //	_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        //	try
        //	{
        //		response = _httpClient.GetAsync($"{apiPath}orders/search?&type={type}").Result;
        //		//response = _httpClient.GetAsync($"{apiPath}orders/search?&types=3").Result;
        //	}
        //	catch { return null; }
        //	result = ParseResponse<OrdersSearchResponse>(response, out var error);
        //	if (result != null)
        //		if (result.content._meta.pageCount >= 2)
        //              {
        //			for(int i = 2; i <= result.content._meta.pageCount; i++)
        //                  {
        //				var responseNew = _httpClient.GetAsync($"{apiPath}orders/search?&type={type}&page={i}").Result;
        //				var resultNew = ParseResponse<OrdersSearchResponse>(responseNew, out error);
        //				result.content.orders.AddRange(resultNew.content.orders);
        //			}
        //              }
        //	return result;
        //}

        public OrdersSearchExpandResponse GetOrdersExpandSearchForFiskal() 
        {
            //НОВА!!!
            OrdersSearchExpandResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&types=6", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&types=6", _token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            return result;
        }

        public OrdersSearchExpandResponse GetOrdersExpandSearch(int types)
        {
            OrdersSearchExpandResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&types={types}", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&types={types}", _token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            return result;
        }

        public OrdersSearchExpandResponse GetOrdersByStatuserSearch(int status)
        {
            OrdersSearchExpandResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&status={status}", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&status={status}", _token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            return result;
        }

        public static void GetOrdersToSQL()
        {
            var token = Login(_username, _password64, true);

            OrdersSearchExpandResponse result = null;
            if (token?.content.access_token == null) 
            {
                SaveErrorToSQL("Не згенерувався токен");
                return; 
            }

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&types=4", token.content.access_token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&types=4", token.content.access_token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            SaveErrorToSQL(error);

            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                foreach (var order in result.content.orders)
                {
                    var city = order.delivery.city?.title == null ? "" : Regex.Replace(order.delivery.city.title, @"Селище міського типу", @"смт");
                    var adress = $"{city}, {order.delivery.place_street} {(order.delivery.place_house ?? "")},{(order.delivery.place_flat ?? "")}{(order.delivery.place_number != null ? ", Відділення № " + order.delivery.place_number : "")}";
                    adress = Regex.Replace(adress, @"'", @"''");
                    var contact_fio = Regex.Replace(order.user.contact_fio, @"'", @"''");
                    var full_name = Regex.Replace(order.user_title.full_name, @"'", @"''");
                    var first_name = order.user_title.first_name ==  null ? "" : Regex.Replace(order.user_title.first_name, @"'", @"''");
                    var last_name = order.user_title.last_name == null ? "" : Regex.Replace(order.user_title.last_name, @"'", @"''");
                    var second_name = order.user_title.second_name == null ? "" : Regex.Replace(order.user_title.second_name, @"'", @"''");
                    var email = order.user.has_email && order.user.email != "true" ? order.user.email : "";
                    var phone = order.user_phone.Length > 10 ? order.user_phone.Substring(order.user_phone.Length - 10, 10) : order.user_phone;
                    string rating = "";
                    switch (order.user_rating)
                    {
                        case null: rating = "Мало замавлень у покупця"; break;
                        case 1: rating = "Високий відсоток викупу замовлень"; break;
                        case 2: rating = "Середній відсоток викупу замовлень"; break;
                        case 3: rating = "Низький відсоток викупу замовлень"; break;
                    }
                    var otherinfo = $"{order.delivery.delivery_service_name}, {order.payment_type_name}, {rating}";
                    var comment = Regex.Replace(order.comment, @"'", @"''");
                    var recipient = order.recipient_title.full_name == order.user.contact_fio ? order.user.contact_fio : $"{order.recipient_title.full_name}({order.recipient_phone})";
                    recipient = Regex.Replace(recipient, @"'", @"''");

                    var sql = $@"INSERT INTO {_sql_database}[RozetkaOrder] (id, created, fullname, firstname, lastname, secondname, userphone, adress, email, otherinfo, deliveryid, recipient, amount, cost, comment) VALUES ({order.id}, '{DateTime.Parse(order.created).DateToSQL()}', '{full_name}', '{first_name}', '{last_name}', '{second_name}','{phone}', '{(adress.Length > 100 ? adress.Substring(0, 100) : adress)}', '{email}', '{(otherinfo.Length > 200 ? otherinfo.Substring(0, 200) : otherinfo)}', {order.delivery.delivery_service_id}, '{(recipient.Length > 50 ? recipient.Substring(0, 50) : recipient)}', '{order.amount_with_discount}', '{order.cost_with_discount}', '{(comment.Length > 100 ? comment.Substring(0, 100) : comment)}')";
                    using (var query = new SqlCommand(sql, connection))
                        query.ExecuteNonQuery();
                    foreach (var purchase in order.purchases)
                    {
                        var item_name = Regex.Replace(purchase.item_name, @"'", @"''");

                        sql = $@"INSERT INTO {_sql_database}[RozetkaPurchase] (id, orderid, codetv, itemname, quantity, cena) VALUES ({purchase.item.id}, {order.id}, {Convert.ToInt32(purchase.item.article)}, '{(item_name.Length > 100 ? item_name.Substring(0, 100) : item_name)}', {purchase.quantity}, '{purchase.price}')";
                        using (var query = new SqlCommand(sql, connection))
                            query.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

        public OrderWithExpand GetOneOrder(int idOrder)
        {
            OrderExtraResponse result = null;
            if (_token == null) return null;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/{idOrder}?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return null;
            }
            result = response.ConvertJson<OrderExtraResponse>(ref error);
            return result?.content;
        }

        public static void GetOneOrderToSQL(int idOrder)
        {
            var token = Login(_username, _password64, true);

            OrderExtraResponse result = null;
            if (token?.content.access_token == null)
            {
                SaveErrorToSQL("Не згенерувався токен");
                return;
            }

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/{idOrder}?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order", token.content.access_token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return;
            }
            result = response.ConvertJson<OrderExtraResponse>(ref error);
            SaveErrorToSQL(error);

            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                var order = result.content;

                var city = Regex.Replace(order.delivery.city.title, @"Селище міського типу", @"смт");
                var adress = $"{city}, {order.delivery.place_street} {(order.delivery.place_house ?? "")},{(order.delivery.place_flat ?? "")}{(order.delivery.place_number != null ? ", Відділення № " + order.delivery.place_number : "")}";
                adress = Regex.Replace(adress, @"'", @"''");
                var contact_fio = Regex.Replace(order.user.contact_fio, @"'", @"''");
                var full_name = Regex.Replace(order.user_title.full_name, @"'", @"''");
                var first_name = order.user_title.first_name == null ? "" : Regex.Replace(order.user_title.first_name, @"'", @"''");
                var last_name = order.user_title.last_name == null ? "" : Regex.Replace(order.user_title.last_name, @"'", @"''");
                var second_name = order.user_title.second_name == null ? "" : Regex.Replace(order.user_title.second_name, @"'", @"''");
                var email = order.user.has_email && order.user.email != "true" ? order.user.email : "";
                var phone = order.user_phone.Length > 10 ? order.user_phone.Substring(order.user_phone.Length - 10, 10) : order.user_phone;
                string rating = "";
                switch (order.user_rating)
                {
                    case null: rating = "Мало замавлень у покупця"; break;
                    case 1: rating = "Високий відсоток викупу замовлень"; break;
                    case 2: rating = "Середній відсоток викупу замовлень"; break;
                    case 3: rating = "Низький відсоток викупу замовлень"; break;
                }
                var otherinfo = $"{order.delivery.delivery_service_name}, {order.payment_type_name}, {rating}";
                var comment = Regex.Replace(order.comment, @"'", @"''");
                var recipient = order.recipient_title.full_name == order.user.contact_fio ? order.user.contact_fio : $"{order.recipient_title.full_name}({order.recipient_phone})";
                recipient = Regex.Replace(recipient, @"'", @"''");

                var sql = $@"INSERT INTO {_sql_database}[RozetkaOrder] (id, created, fullname, firstname, lastname, secondname, userphone, adress, email, otherinfo, deliveryid, recipient, amount, cost, comment) VALUES ({order.id}, '{DateTime.Parse(order.created).DateToSQL()}', '{full_name}', '{first_name}', '{last_name}', '{second_name}','{phone}', '{(adress.Length > 100 ? adress.Substring(0, 100) : adress)}', '{email}', '{(otherinfo.Length > 200 ? otherinfo.Substring(0, 200) : otherinfo)}', {order.delivery.delivery_service_id}, '{(recipient.Length > 50 ? recipient.Substring(0, 50) : recipient)}', '{order.amount_with_discount}', '{order.cost_with_discount}', '{(comment.Length > 100 ? comment.Substring(0, 100) : comment)}')";
                using (var query = new SqlCommand(sql, connection))
                    query.ExecuteNonQuery();
                foreach (var purchase in order.purchases)
                {
                    var item_name = Regex.Replace(purchase.item_name, @"'", @"''");

                    sql = $@"INSERT INTO {_sql_database}[RozetkaPurchase] (id, orderid, codetv, itemname, quantity, cena) VALUES ({purchase.item.id}, {order.id}, {Convert.ToInt32(purchase.item.article)}, '{(item_name.Length > 100 ? item_name.Substring(0, 100) : item_name)}', {purchase.quantity}, '{purchase.price}')";
                    using (var query = new SqlCommand(sql, connection))
                        query.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public Item GetItem(int idItem)
        {
            if (_token == null) return null;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}items/{idItem}", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + " ";
                return null;
            }
            var result = response.ConvertJson<ItemResponse>(ref error);
            return result?.content;
        }

        public bool ChangeStatus(int idOrder, int status, string ttn = null)
        {
            bool result = false;
            if (_token == null) return result;

            string response = null;
            string error;
            string json;
            if (String.IsNullOrEmpty(ttn))
                json = "{\"status\":" + status.ToString() + "}";
            else
                json = "{\"status\":3, \"ttn\":\"" + ttn.Trim() +  "\"}";
            try
            {
                response = RequestData.SendPut($"{apiPath}orders/{idOrder}", _token, json, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<OrderChangeResponse>(ref error).success;
            return result;
        }

        public static void ChangeStatusFromSQL(int idOrder, int status)
        {
            var token = Login(_username, _password64, true);

            if (token?.content.access_token == null)
            {
                SaveErrorToSQL("Не згенерувався токен");
                return;
            }

            string response = null;
            string error;

            var json = "{\"status\":" + status.ToString() + "}";
            try
            {
                response = RequestData.SendPut($"{apiPath}orders/{idOrder}", token.content.access_token, json, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return;
            }
            var result = response.ConvertJson<OrderChangeResponse>(ref error);
            SaveErrorToSQL(error);
        }

        public static void SendTTNFromSQL(int idOrder, string ttn)
        {
            var token = Login(_username, _password64, true);

            if (token?.content.access_token == null)
            {
                SaveErrorToSQL("Не згенерувався токен");
                return;
            }

            string response = null;
            string error;

            var json = "{\"status\":3, \"ttn\":\"" + ttn + "\"}";
            try
            {
                response = RequestData.SendPut($"{apiPath}orders/{idOrder}", token.content.access_token, json, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return;
            }
            var result = response.ConvertJson<OrderChangeResponse>(ref error);
            SaveErrorToSQL(error);
        }

        public static void GetUnsuccesOrdersToSQL()
        {
            var token = Login(_username, _password64, true);

            OrderSearchUnsuccesResponse result = null;
            if (token?.content.access_token == null)
            {
                SaveErrorToSQL("Не згенерувався токен");
                return;
            }

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=order_status_history&types=6&status=45&status_updated_from={DateTime.Now.AddDays(-1)}", token.content.access_token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return;
            }
            result = response.ConvertJson<OrderSearchUnsuccesResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=order_status_history&status_updated_from={DateTime.Now.AddDays(-1)}&page={i}&types=6&status=45", token.content.access_token, out error);
                        var resultNew = responseNew.ConvertJson<OrderSearchUnsuccesResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            SaveErrorToSQL(error);

            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                foreach (var order in result.content.orders)
                {
                    if (order.status_group == 3)
                    {
                        var sql = $@"INSERT INTO {_sql_database}[RozetkaUnsuccesOrder] (id, changed, reason) VALUES ({order.id}, '{DateTime.Parse(order.order_status_history[0].created).DateToSQL()}', '{order.order_status_history[0].status.name_uk}')";
                        using (var query = new SqlCommand(sql, connection))
                            query.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

        public MessagesCountResponse GetMessagesCount()
        {
            MessagesCountResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}messages/counts", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<MessagesCountResponse>(ref error);
            return result;
        }

        public MessagesOrderResponse GetMessagesOrder(string type, bool read = false)
        {
            MessagesOrderResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}messages/search?msgType={type}&searchType=0&read={(read ? "1" : "0")}&expand=messages", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<MessagesOrderResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}messages/search?msgType={type}&searchType=0&read={(read ? "1" : "0")}&expand=messages&page={i}", _token, out error);
                        var resultNew = responseNew.ConvertJson<MessagesOrderResponse>(ref error);
                        result.content.chats.AddRange(resultNew.content.chats);
                    }
                }
            return result;
        }

        public MessagesItemResponse GetMessagesItem()
        {
            MessagesItemResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}item-comments/search?type=question", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<MessagesItemResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}item-comments/search?type=question&page={i}", _token, out error);
                        var resultNew = responseNew.ConvertJson<MessagesItemResponse>(ref error);
                        result.content.itemComments.AddRange(resultNew.content.itemComments);
                    }
                }
            return result;
        }

        public ChatResponse OpenChat(int id)
        {
            ChatResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}messages/{id}?expand=messages", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<ChatResponse>(ref error);
            return result;
        }

        public ChatMessage SetMessagesAnswer(int chat, string text, int receiver)
        {
            ChatMessage result = null;
            if (_token == null) return result;

            var keysBody = new Dictionary<string, string>
            {
                { "body", text },
                { "chat_id", chat.ToString() },
                { "receiver_id", receiver.ToString() }
            };

            string response = null;
            string error;
            try
            {
                response = RequestData.FormDataRequest(apiPath + "messages/create", _token, keysBody, null, null, null, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<ChatMessage>(ref error);
            return result;
        }

        public OrdersSearchExpandResponse GetOrdersByPay(string typePay)
        {
            //4524-карта(RozetkaPay)
            //5307-GooglePay
            //5405-ApplePay

            OrdersSearchExpandResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&type=2&status_updated_from={DateTime.Now.AddDays(-3)}&payment_methods={typePay}", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&type=2&status_updated_from={DateTime.Now.AddDays(-3)}&page={i}&payment_methods={typePay}", _token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            return result;
        }

        public OrdersSearchExpandResponse GetOrdersRozDeliveryAndCash()
        {
            OrdersSearchExpandResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&type=2&status_updated_from={DateTime.Now.AddDays(-3)}&delivery_id=1&payment_methods=1", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&type=2&status_updated_from={DateTime.Now.AddDays(-3)}&delivery_id=1&payment_methods=1", _token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            return result;
        }

        public static void GetOrdersForFiskalXml(out string result)
        {
            result = "";
            var token = Login(_username, _password64, true);
            if (token?.content.access_token == null)
            {
                SaveErrorToSQL("Не згенерувався токен");
                return;
            }

            _ = new ApiManager();
            Current._token = token.content.access_token;

            var orders = new List<OrderWithExpand>();
            var ordersP = Current.GetOrdersByPay("4524,5307,5405")?.content.orders;
            if (ordersP != null && ordersP.Count != 0)
                orders.AddRange(ordersP);

            var ordersD = Current.GetOrdersRozDeliveryAndCash()?.content.orders;
            if (ordersD != null && ordersD.Count != 0)
                orders.AddRange(ordersD);

            result = orders.Where(o => o.status_payment != null && o.status_payment.status_payment_id == 2).OrderByDescending(o => o.created).Select(n => new OplZam() { nomZam = n.id, sumaOpl = n.amount_with_discount }).ToList().ToXml<List<OplZam>>();
        }

        public struct OplZam
        {
            public int nomZam;
            public string sumaOpl;
        }
    }
}
