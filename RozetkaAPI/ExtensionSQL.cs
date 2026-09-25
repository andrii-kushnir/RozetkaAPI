using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RozetkaAPI
{
    public static class ExtensionSQL
    {
        public static string DateToSQL(this DateTime date)
        {
            var dateBegin = new DateTime(1970, 1, 1);
            date = date < dateBegin ? dateBegin : date;
            var result = date.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        public static string NullCheck(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "0";
            return value;
        }

        public static string ToXml<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var xmlserializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings();
            //settings.Indent = true;
            //settings.OmitXmlDeclaration = true;
            var stringWriter = new StringWriter();
            try
            {
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void SaveErrorToSQL(string error)
        {
            if (!String.IsNullOrWhiteSpace(error))
            {
                var methodName = new StackTrace(1).GetFrame(0).GetMethod().Name;
                using (SqlConnection connection = new SqlConnection(ApiManager.connectionSql100))
                {
                    connection.Open();
                    var sql = $@"INSERT INTO {ApiManager._sql_database}[RozetkaErrorLog] (error, date) VALUES (@error, @date)";
                    using (var query = new SqlCommand(sql, connection))
                    {
                        query.Parameters.AddWithValue("@error", methodName + " error: " + error);
                        query.Parameters.AddWithValue("@date", DateTime.Now.DateToSQL());
                        query.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }

        public static string GetCachedToken()
        {
            string token = null;
            DateTime lastUpdated = DateTime.MinValue;
            try
            {
                using (var connection = new SqlConnection(ApiManager.connectionSql100))
                {
                    var query = new SqlCommand(@"SELECT TOP 1 Token, LastUpdated FROM RozetkaConfig ORDER BY LastUpdated DESC", connection);
                    connection.Open();
                    var reader = query.ExecuteReader();

                    if (reader.Read())
                    {
                        token = reader.GetString(0);
                        lastUpdated = reader.GetDateTime(1);
                        reader.Close();
                    }
                }

                if (DateTime.Now - lastUpdated > TimeSpan.FromHours(23))
                {
                    SaveErrorToSQL($"Токен {token} просрочений на 23 години");
                    token = null;
                }
                else
                {
                    UpdateLastUsed(token);
                }
            }
            catch { }
            return token;
        }

        public static string GetCachedToken(string connectionString)
        {
            string token = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var query = new SqlCommand(@"SELECT TOP 1 Token FROM RozetkaConfig ORDER BY LastUpdated DESC", connection);
                    connection.Open();
                    var reader = query.ExecuteReader();
                    if (reader.Read())
                    {
                        token = reader.GetString(0);
                        reader.Close();
                    }
                }
            }
            catch { }
            return token;
        }

        public static void SaveTokenToDB(string token)
        {
            try
            {
                using (var connection = new SqlConnection(ApiManager.connectionSql100))
                {
                    var query = new SqlCommand(@"INSERT INTO RozetkaConfig (Token, DateCreated, LastUpdated) VALUES (@token, GETDATE(), GETDATE())", connection);
                    query.Parameters.AddWithValue("@token", token);
                    connection.Open();
                    query.ExecuteNonQuery();
                }
            }
            catch { }
        }

        public static void UpdateLastUsed(string token)
        {
            try
            {
                using (var connection = new SqlConnection(ApiManager.connectionSql100))
                {
                    var query = new SqlCommand("UPDATE RozetkaConfig SET LastUpdated = GETDATE() WHERE Token = @token", connection);
                    query.Parameters.AddWithValue("@token", token);
                    connection.Open();
                    query.ExecuteNonQuery();
                }
            }
            catch { }
        }
    }
}
