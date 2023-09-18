using Newtonsoft.Json;
using PozetkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI
{
	public class ApiManager
	{
		public const string apiPath = "https://api-seller.rozetka.com.ua/";

		private string _username = "shop@ars.ua";
		private string _password64 = "Nkp2bXg1QlI3bjZW";
		private string _password = "6Jvmx5BR7n6V";

		private string _token;

		public static ApiManager Current { get; private set; }

		private readonly HttpClient _httpClient;

		public ApiManager()
		{
			if (Current == null)
				Current = this;

			_httpClient = new HttpClient();

			//var login = Login(_username, _password);
			//if (login != null && login.success)
			//    _token = login.content.access_token;
		}

		public LoginResponse Login()
		{
			return Login(_username, _password64);
		}

		public LoginResponse Login(string username, string password)
		{
			LoginResponse result = null;
			HttpResponseMessage response;
			var token = new LoginRequest()
			{
				username = username,
				password = password
			};
			var requestJson = JsonConvert.SerializeObject(token, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
			try
			{
				response = _httpClient.PostAsync(apiPath + "sites", new StringContent(requestJson, Encoding.UTF8, "application/json")).Result;
			}
			catch { return null; }
			result = ParseResponse<LoginResponse>(response, out var error);
			if (result != null && result.success)
				_token = result.content.access_token;
			return result;
		}

		public LogoutResponse Logout()
		{
			LogoutResponse result = null;
			HttpResponseMessage response;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			try
			{
				response = _httpClient.PostAsync(apiPath + "sites/logout", new StringContent("", Encoding.UTF8, "application/json")).Result;
			}
			catch { return null; }
			result = ParseResponse<LogoutResponse>(response, out var error);
			return result;
		}

		public ProductResponse GetTovar(int id)
		{
			ProductResponse result = null;
			HttpResponseMessage response;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			try
			{
				response = _httpClient.GetAsync($"{apiPath}items/search?product_id={id}").Result;
			}
			catch { return null; }
			result = ParseResponse<ProductResponse>(response, out var error);
			return result;
		}

		public OrderStatusesResponse GetOrderStatus()
		{
			OrderStatusesResponse result = null;
			HttpResponseMessage response;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			try
			{
				response = _httpClient.GetAsync($"{apiPath}order-statuses/search").Result;
			}
			catch { return null; }
			result = ParseResponse<OrderStatusesResponse>(response, out var error);
			return result;
		}

		public OrdersSearchResponse GetOrdersSearch()
		{
			OrdersSearchResponse result = null;
			HttpResponseMessage response;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			try
			{
				response = _httpClient.GetAsync($"{apiPath}orders/search?&types=1").Result;
			}
			catch { return null; }
			result = ParseResponse<OrdersSearchResponse>(response, out var error);
			return result;
		}

		public OrderResponse GetOrder(int id)
		{
			OrderResponse result = null;
			HttpResponseMessage response;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			try
			{
				response = _httpClient.GetAsync($"{apiPath}orders/{id}").Result;
			}
			catch { return null; }
			result = ParseResponse<OrderResponse>(response, out var error);
			return result;
		}

		public OrderExtraResponse GetOrderWithExtra(int id)
		{
			OrderExtraResponse result = null;
			HttpResponseMessage response;
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			try
			{
				response = _httpClient.GetAsync($"{apiPath}orders/{id}?expand=chatUser,chatMessages,delivery,user,status_available,status_data,purchases,payment_status,status_payment,can_edit,feedback,feedback_count,order_status_history,credit_status,credit_broker,delivery_service,payment_invoice_id,can_edit,is_free_delivery,delivery_prices,reminder_to_check_payment_for_duplicates,invoice_exist,can_create_invoice").Result;
			}
			catch { return null; }
			result = ParseResponse<OrderExtraResponse>(response, out var error);
			return result;
		}

		private T ParseResponse<T>(HttpResponseMessage response, out string error) where T : class
		{
			error = "";
			string responseBody = null;
			try
			{
				responseBody = response.Content.ReadAsStringAsync().Result;
			}
			catch (Exception ex)
			{
				error += ex.Message + "\r\n";
			}

			if (response.StatusCode != HttpStatusCode.OK)
			{
				error += response.StatusCode.ToString() + "\r\n";
			}

			T result = null;
			try
			{
				result = JsonConvert.DeserializeObject<T>(responseBody);
			}
			catch (Exception ex)
			{
				error += ex.Message + "\r\n";
			}
			return result;
		}
	}
}
