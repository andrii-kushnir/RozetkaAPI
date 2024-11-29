using System;
using System.Collections.Generic;
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
    }
}
