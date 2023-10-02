﻿using Newtonsoft.Json;
using RozetkaAPI.Models;
using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RozetkaAPI
{
	public class ApiManager
	{
		public const string apiPath = "https://api-seller.rozetka.com.ua/";

		private static string _username = "shop@ars.ua";
		private static string _password64 = "Nkp2bXg1QlI3bjZW";
		private static string _password = "6Jvmx5BR7n6V";

		private static readonly string _sql_database = "";

		private string _token;

		public static ApiManager Current { get; private set; }


		public ApiManager()
		{
			if (Current == null)
				Current = this;

			//var login = Login(_username, _password);
			//if (login != null && login.success)
			//    _token = login.content.access_token;
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

        //public ProductResponse GetTovar(int id)
        //{
        //	ProductResponse result = null;
        //	if (_token == null) return result;
        //	HttpResponseMessage response;
        //	_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        //	try
        //	{
        //		response = _httpClient.GetAsync($"{apiPath}items/search?product_id={id}").Result;
        //	}
        //	catch { return null; }
        //	result = ParseResponse<ProductResponse>(response, out var error);
        //	return result;
        //}

        public OrderStatusesResponse GetOrderStatus()
        {
            OrderStatusesResponse result = null;
            if (_token == null) return result;

            string response = null;
            string error;

            try
            {
                response = RequestData.SendGet($"{apiPath}order-statuses/search?id=26&expand=status_available", _token, out error);
                //response = RequestData.SendGet($"{apiPath}order-statuses/search?&expand=status_available", _token, out error);
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

        public static void GetOrdersToSQL(out string error)
        {
            error = "";
            var token = Login(_username, _password64, true);

            OrdersSearchExpandResponse result = null;
            if (token?.content.access_token == null) { error = "Не згенерувався токен"; return; }

            string response = null;
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

            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                foreach (var order in result.content.orders)
                {
                    var city = Regex.Replace(order.delivery.city.title, @"Селище міського типу", @"смт");
                    var adress = $"{city}, {order.delivery.place_street} {(order.delivery.place_house ?? "")},{(order.delivery.place_flat ?? "")}{(order.delivery.place_number != null ? ", Відділення № " + order.delivery.place_number : "")}";
                    adress = Regex.Replace(adress, @"'", @"''");
                    var contact_fio = Regex.Replace(order.user.contact_fio, @"'", @"''");
                    var full_name = Regex.Replace(order.user_title.full_name, @"'", @"''");
                    var first_name = Regex.Replace(order.user_title.first_name, @"'", @"''");
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

        public static void GetOneOrderToSQL(int idOrder, out string error)
        {
            error = "";
            var token = Login(_username, _password64, true);

            OrderExtraResponse result = null;
            if (token?.content.access_token == null) { error = "Не згенерувався токен"; return; }

            string response = null;
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

            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                var order = result.content;

                var city = Regex.Replace(order.delivery.city.title, @"Селище міського типу", @"смт");
                var adress = $"{city}, {order.delivery.place_street} {(order.delivery.place_house ?? "")},{(order.delivery.place_flat ?? "")}{(order.delivery.place_number != null ? ", Відділення № " + order.delivery.place_number : "")}";
                adress = Regex.Replace(adress, @"'", @"''");
                var contact_fio = Regex.Replace(order.user.contact_fio, @"'", @"''");
                var full_name = Regex.Replace(order.user_title.full_name, @"'", @"''");
                var first_name = Regex.Replace(order.user_title.first_name, @"'", @"''");
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

        public bool ChangeStatus(int idOrder, int status)
        {
            bool result = false;
            if (_token == null) return result;

            string response = null;
            string error;
            var json = "{\"status\":" + status.ToString() + "}";
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

        public static void ChangeStatusFromSQL(int idOrder, int status, out string error)
        {
            error = "";
            var token = Login(_username, _password64, true);

            if (token?.content.access_token == null) { error = "Не згенерувався токен";  return; }

            string response = null;
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
        }

    }
}
