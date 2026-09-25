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
using static RozetkaAPI.ExtensionSQL;

namespace RozetkaAPI
{
	public class ApiManager
	{
		public const string apiPath = "https://api-seller.rozetka.com.ua/";

		private static string _username = "shop@ars.ua";
		private static string _password64 = "Nkp2bXg1QlI3bjZW";

        public const string connectionSql100 = "Context Connection = true;";
        public static readonly string _sql_database = "[InetClient].[dbo].";

		private string _token;
        private const int _timeoutSendTTN = 2000;

        public static ApiManager Current { get; private set; }


		public ApiManager()
		{
			if (Current == null)
				Current = this;
		}

		public void Login()
		{
            var token = GetCachedToken();
            if (token == null)
                token = LoginSQL(_username, _password64);
            if (token != null)
                Current._token = token;
        }

        public bool Login(string connectionString)
        {
            var token = GetCachedToken(connectionString);
            if (token == null)
                return false;
            Current._token = token;
            return true;
        }

        public static string LoginSQL(string username, string password)
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
            SaveErrorToSQL(error);
            string token = null;
            if (result != null && result.success)
            {
                token = result.content.access_token;
                SaveTokenToDB(token);
            }
            return token;
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
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
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
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
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
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
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
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
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
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);

            OrdersSearchExpandResponse result = null;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&types=4", token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                SaveErrorToSQL(error);
                return;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&types=4", token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            SaveErrorToSQL(error);

            using (SqlConnection connection = new SqlConnection(connectionSql100))
            {
                connection.Open();
                foreach (var order in result.content.orders)
                {
                    var city = order.delivery.city?.title == null ? "" : Regex.Replace(order.delivery.city.title, @"Селище міського типу", @"смт");
                    var adress = $"{city}, {order.delivery.place_street} {(order.delivery.place_house ?? "")},{(order.delivery.place_flat ?? "")}{(order.delivery.place_number != null ? ", Відділення № " + order.delivery.place_number : "")}";
                    adress = Regex.Replace(adress, @"'", @"`");
                    var contact_fio = Regex.Replace(order.user.contact_fio, @"'", @"`");
                    var full_name = Regex.Replace(order.user_title.full_name, @"'", @"`");
                    var first_name = order.user_title.first_name ==  null ? "" : Regex.Replace(order.user_title.first_name, @"'", @"`");
                    var last_name = order.user_title.last_name == null ? "" : Regex.Replace(order.user_title.last_name, @"'", @"`");
                    var second_name = order.user_title.second_name == null ? "" : Regex.Replace(order.user_title.second_name, @"'", @"`");
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
                    var otherinfo = $"{Regex.Replace(order.delivery.delivery_service_name, @"'", @"`")}, {order.payment_type_name}, {rating}";
                    var comment = Regex.Replace(order.comment, @"'", @"`");
                    var recipient = (order.recipient_title.full_name == order.user.contact_fio && order.user_phone == order.recipient_phone) ? order.user.contact_fio : $"{order.recipient_title.full_name}({order.recipient_phone})";
                    recipient = Regex.Replace(recipient, @"'", @"`");
                    var paymentType = Regex.Replace(order.payment_type_name, @"'", @"`");

                    var sql = $@"INSERT INTO {_sql_database}[RozetkaOrder] (id, created, fullname, firstname, lastname, secondname, userphone, adress, email, otherinfo, deliveryid, recipient, amount, cost, comment, payment) VALUES ({order.id}, '{DateTime.Parse(order.created).DateToSQL()}', '{full_name}', '{first_name}', '{last_name}', '{second_name}','{phone}', '{(adress.Length > 100 ? adress.Substring(0, 100) : adress)}', '{email}', '{(otherinfo.Length > 200 ? otherinfo.Substring(0, 200) : otherinfo)}', {order.delivery.delivery_service_id}, '{(recipient.Length > 50 ? recipient.Substring(0, 50) : recipient)}', '{order.amount_with_discount}', '{order.cost_with_discount}', '{(comment.Length > 100 ? comment.Substring(0, 100) : comment)}', '{paymentType}')";
                    using (var query = new SqlCommand(sql, connection))
                        query.ExecuteNonQuery();
                    foreach (var purchase in order.purchases)
                    {
                        var item_name = Regex.Replace(purchase.item_name, @"'", @"`");

                        sql = $@"INSERT INTO {_sql_database}[RozetkaPurchase] (id, orderid, codetv, itemname, quantity, cena) VALUES ({purchase.item.id}, {order.id}, {Convert.ToInt32(purchase.item.article)}, '{(item_name.Length > 100 ? item_name.Substring(0, 100) : item_name)}', {purchase.quantity}, '{purchase.price}')";
                        using (var query = new SqlCommand(sql, connection))
                            query.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

        public static void GetOrderStatusToSQL(int idOrder)
        {
            GetOrderStatusRepeat(idOrder, false);
        }

        public static void GetOrderStatusRepeat(int idOrder, bool retried)
        {
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/{idOrder}?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order", token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                SaveErrorToSQL(error);
                return;
            }
            if (TokenError(response))
            {
                SaveErrorToSQL(response);
                if (retried)
                    return;
                LoginSQL(_username, _password64);
                GetOrderStatusRepeat(idOrder, true);
                return;
            }
            var order = response.ConvertJson<OrderExtraResponse>(ref error).content;
            SaveErrorToSQL(error);

            var paymentName = order.payment_type_name;
            var paymentStatus = order.payment_status ?? order.payment_type_name;

            //var deliveryId = order.delivery.delivery_service_id;
            var deliveryName = $"{Regex.Replace(order.delivery.delivery_service_name, @"'", @"`")}";

            var sql = $@"IF EXISTS(SELECT * FROM {_sql_database}[RozetkaStatuses] WHERE id = {order.id}) UPDATE {_sql_database}[RozetkaStatuses] SET payName = '{paymentName}', payStatus = '{paymentStatus}', delName = '{deliveryName}', datenlog = '{DateTime.Now.DateToSQL()}' WHERE id = {order.id} ELSE INSERT INTO {_sql_database}[RozetkaStatuses] (id, payName, payStatus, delName, datenlog) VALUES ({order.id}, '{paymentName}', '{paymentStatus}', '{deliveryName}', '{DateTime.Now.DateToSQL()}')";

            using (SqlConnection connection = new SqlConnection(connectionSql100))
            {
                connection.Open();
                using (var query = new SqlCommand(sql, connection))
                    query.ExecuteNonQuery();
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
                SaveErrorToSQL(error);
                return null;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return null;
            }
            result = response.ConvertJson<OrderExtraResponse>(ref error);
            return result?.content;
        }

        public static void GetOneOrderToSQL(int idOrder)
        {
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);

            OrderExtraResponse result = null;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/{idOrder}?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order", token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                SaveErrorToSQL(error);
                return;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return;
            }
            result = response.ConvertJson<OrderExtraResponse>(ref error);
            SaveErrorToSQL(error);

            using (SqlConnection connection = new SqlConnection(connectionSql100))
            {
                connection.Open();
                var order = result.content;

                var city = Regex.Replace(order.delivery.city.title, @"Селище міського типу", @"смт");
                var adress = $"{city}, {order.delivery.place_street} {(order.delivery.place_house ?? "")},{(order.delivery.place_flat ?? "")}{(order.delivery.place_number != null ? ", Відділення № " + order.delivery.place_number : "")}";
                adress = Regex.Replace(adress, @"'", @"`");
                var contact_fio = Regex.Replace(order.user.contact_fio, @"'", @"`");
                var full_name = Regex.Replace(order.user_title.full_name, @"'", @"`");
                var first_name = order.user_title.first_name == null ? "" : Regex.Replace(order.user_title.first_name, @"'", @"`");
                var last_name = order.user_title.last_name == null ? "" : Regex.Replace(order.user_title.last_name, @"'", @"`");
                var second_name = order.user_title.second_name == null ? "" : Regex.Replace(order.user_title.second_name, @"'", @"`");
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
                var otherinfo = $"{Regex.Replace(order.delivery.delivery_service_name, @"'", @"`")}, {order.payment_type_name}, {rating}";
                var comment = Regex.Replace(order.comment, @"'", @"`");
                var recipient = (order.recipient_title.full_name == order.user.contact_fio && order.user_phone == order.recipient_phone) ? order.user.contact_fio : $"{order.recipient_title.full_name}({order.recipient_phone})";
                recipient = Regex.Replace(recipient, @"'", @"`");
                var paymentType = Regex.Replace(order.payment_type_name, @"'", @"`");

                var sql = $@"INSERT INTO {_sql_database}[RozetkaOrder] (id, created, fullname, firstname, lastname, secondname, userphone, adress, email, otherinfo, deliveryid, recipient, amount, cost, comment, payment) VALUES ({order.id}, '{DateTime.Parse(order.created).DateToSQL()}', '{full_name}', '{first_name}', '{last_name}', '{second_name}','{phone}', '{(adress.Length > 100 ? adress.Substring(0, 100) : adress)}', '{email}', '{(otherinfo.Length > 200 ? otherinfo.Substring(0, 200) : otherinfo)}', {order.delivery.delivery_service_id}, '{(recipient.Length > 50 ? recipient.Substring(0, 50) : recipient)}', '{order.amount_with_discount}', '{order.cost_with_discount}', '{(comment.Length > 100 ? comment.Substring(0, 100) : comment)}', '{paymentType}')";
                using (var query = new SqlCommand(sql, connection))
                    query.ExecuteNonQuery();
                foreach (var purchase in order.purchases)
                {
                    var item_name = Regex.Replace(purchase.item_name, @"'", @"`");

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
                SaveErrorToSQL(error);
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
                SaveErrorToSQL(error);
                return result;
            }
            result = response.ConvertJson<OrderChangeResponse>(ref error).success;
            return result;
        }

        public static void ChangeStatusFromSQL(int idOrder, int status)
        {
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);
            var json = "{\"status\":" + status.ToString() + "}";
            try
            {
                RequestData.SendPutNoWait($"{apiPath}orders/{idOrder}", token, json);
            }
            catch (Exception ex)
            {
                SaveErrorToSQL(ex.Message + "  ");
            }
        }

        public static void SendTTNFromSQL(int idOrder, string ttn)
        {
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);

            string response = null;
            string error;

            var json = "{\"status\":3, \"ttn\":\"" + ttn + "\"}";
            try
            {
                response = RequestData.SendPut($"{apiPath}orders/{idOrder}", token, json, out error, _timeoutSendTTN);
            }
            catch (Exception ex)
            {
                SaveErrorToSQL(ex.Message);
                return;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return;
            }
            var result = response.ConvertJson<OrderChangeResponse>(ref error);
            SaveErrorToSQL(error);
        }

        public static void GetUnsuccesOrdersToSQL()
        {
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);

            OrderSearchUnsuccesResponse result = null;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=order_status_history&types=6&status=45&status_updated_from={DateTime.Now.AddDays(-1)}", token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                SaveErrorToSQL(error);
                return;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return;
            }
            result = response.ConvertJson<OrderSearchUnsuccesResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=order_status_history&status_updated_from={DateTime.Now.AddDays(-1)}&page={i}&types=6&status=45", token, out error);
                        var resultNew = responseNew.ConvertJson<OrderSearchUnsuccesResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            SaveErrorToSQL(error);

            using (SqlConnection connection = new SqlConnection(connectionSql100))
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
                SaveErrorToSQL(error);
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
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
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
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
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
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
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
                SaveErrorToSQL(error);
                return result;
            }
            result = response.ConvertJson<ChatMessage>(ref error);
            return result;
        }

        public OrdersSearchExpandResponse GetOrdersByPay(string typePay)
        {
            //НЕ ФІСКАЛІЗУЮ:
            //1 - Оплата під час отримання товару
            //2 - Безготівковий для фізичних осіб
            //4682 - Оплата на рахунок продавця
            //6211 - Передплата на картку продавця

            //ФІСКАЛІЗУЮ:
            //4524,6815 - Оплата карткою Visa/MasterCard (RozetkaPay)
            //5307,6809 - Google Pay
            //5405,6812 - Apple Pay
            //7244 - Оплатити частинами від Rozetka 6
            //7339 - Оплатити частинами від Rozetka 2
            //8031 - Оплатити Карткою Rozetka зараз

            OrdersSearchExpandResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&types=1&status_updated_from={DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")}&payment_methods={typePay}", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&types=1&status_updated_from={DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")}&page={i}&payment_methods={typePay}", _token, out error);
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
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&type=2&status_updated_from={DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")}&delivery_id=1&payment_methods=1", _token, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&type=2&status_updated_from={DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")}&delivery_id=1&payment_methods=1", _token, out error);
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            return result;
        }

        public static void GetOrdersForFiskalXml(out string result)
        {
            result = "";
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);

            _ = new ApiManager();
            Current._token = token;

            var orders = new List<OrderWithExpand>();
            var ordersP = Current.GetOrdersByPay("4524,5307,5405,6809,6812,6815,7244,7339,8031")?.content.orders.Where(o => o.status_payment != null && (o.status_payment.status_payment_id == 2 || o.status_payment.status_payment_id == 5 || o.status_payment.status_payment_id == 9)).ToList();
            if (ordersP != null && ordersP.Count != 0)
                orders.AddRange(ordersP);

            var ordersD = Current.GetOrdersRozDeliveryAndCash()?.content.orders;
            if (ordersD != null && ordersD.Count != 0)
                orders.AddRange(ordersD);

            result = orders.OrderByDescending(o => o.created).Select(n => new OplZam() { nomZam = n.id, sumaOpl = n.amount_with_discount }).ToList().ToXml<List<OplZam>>();
        }

        public struct OplZam
        {
            public int nomZam;
            public string sumaOpl;
        }

        public OrdersSearchExpandResponse GetOrdersDostAndWait()
        {
            OrdersSearchExpandResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;
            try
            {
                response = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&delivery_id=1&status=5", _token, out error);
            }
            //&status_updated_to ={ DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")}  - Більше 3 днів
            catch (Exception ex)
            {
                error = ex.Message + "  ";
                SaveErrorToSQL(error);
                return result;
            }
            if (TokenError(response))
            {
                LoginSQL(_username, _password64);
                return result;
            }
            result = response.ConvertJson<OrdersSearchExpandResponse>(ref error);
            if (result != null)
                if (result.content._meta.pageCount >= 2)
                {
                    for (int i = 2; i <= result.content._meta.pageCount; i++)
                    {
                        var responseNew = RequestData.SendGet($"{apiPath}orders/search?expand=chatUser,chatMessages,user,delivery,purchases,payment_status,status_payment,can_edit,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice,payment_type,payment_type_name,is_access_change_order&page={i}&delivery_id=1&status=5", _token, out error);
                    //&status_updated_to ={ DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")}  - Більше 3 днів
                        var resultNew = responseNew.ConvertJson<OrdersSearchExpandResponse>(ref error);
                        result.content.orders.AddRange(resultNew.content.orders);
                    }
                }
            return result;
        }

        public static void GetOrdersDostAndWaitXml(out string result)
        {
            result = "";
            var token = GetCachedToken();
            if (token == null) token = LoginSQL(_username, _password64);

            _ = new ApiManager();
            Current._token = token;
            var orders = Current.GetOrdersDostAndWait();
            if (orders != null)
                result = orders.content.orders.Select(n => new WaitZam() { nomZam = n.id, changeStatus = DateTime.Parse(n.order_status_history[0].created).DateToSQL() }).ToList().ToXml<List<WaitZam>>();
        }

        public struct WaitZam
        {
            public int nomZam;
            public string changeStatus;
        }

        public static bool TokenError(string response)
        {
            if (string.IsNullOrEmpty(response))
                return false;
            return response.IndexOf("incorrect_access_token", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
