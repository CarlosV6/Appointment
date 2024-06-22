using System.Data;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HelperSerialize
{
    public static class ObjectSerialize
    {
        /// <summary>
        /// Serialize an Object into Byte
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[]? Serialize(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }

                var json = JsonConvert.SerializeObject(obj);
                return Encoding.UTF8.GetBytes(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while serializing an object to byte: " + ex.Message);
                return new byte[0];
            }

        }
        /// <summary>
        /// Serialize an Object to String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string? SerializeText(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }

                var json = JsonConvert.SerializeObject(obj);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while serializing an object to String: " + ex.Message);
                return String.Empty;
            }

        }
        /// <summary>
        /// Deserializes a bit array to a data type
        /// </summary>
        /// <param name="arrBytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object? Deserialize(this byte[] arrBytes, Type type)
        {
            try
            {
                var json = Encoding.Default.GetString(arrBytes);
                return JsonConvert.DeserializeObject(json, type);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deserializing an object to Byte to an input type: " + ex.Message);
                return new object();
            }
        }
        /// <summary>
        /// Deserializes string to a data type
        /// </summary>
        /// <param name="arrBytes"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object? Deserialize(this string json, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, type);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deserializing an object to String to an input type: " + ex.Message);
                return new object();
            }
        }
        /// <summary>
        /// Deserialize a Json string to a datatable
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable? DeserializeToTable(this string json)
        {
            try
            {
                return (JsonConvert.DeserializeObject(json, typeof(DataTable)) as DataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deserializing an object to String to DataTable: " + ex.Message);
                return new DataTable();
            }
        }
        /// <summary>
        /// Normalize a Json string to a string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string? DeserializeToString(this string json)
        {
            try
            {
                return (JsonConvert.DeserializeObject(json, typeof(string)) as string);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while Normalize a Json string to a string: " + ex.Message);
                return String.Empty;
            }
        }
        /// <summary>
        /// Deserializes an array of bytes to a string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string? DeserializeText(this byte[] arrBytes)
        {
            try
            {
                return Encoding.Default.GetString(arrBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while Deserializes an array of bytes to a string: " + ex.Message);
                return String.Empty;
            }
        }
        /// <summary>
        /// Create the dynamic model of an object (DataTable)
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static dynamic? DynamicParseObject(this string json)
        {
            try
            {
                var res = json.ToString();
                dynamic messageDynamic = JObject.Parse(res);
                return messageDynamic;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while Create the dynamic model of an object (DataTable): " + ex.Message);
                return null;
            }
        }
    }
}
