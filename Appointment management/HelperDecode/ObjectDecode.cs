using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperDecode
{
    public static class ObjectDecode
    {
        /// <summary>
        /// Encode a string to base64
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string? EncodeBase64String(this string inputStr)
        {
            try
            {
                if (inputStr == null)
                {
                    return null;
                }

                var byteString = Encoding.UTF8.GetBytes(inputStr);
                return Convert.ToBase64String(byteString);
            }
            catch { throw; }

        }
        /// <summary>
        /// Decode a base64 string to string
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string? DecodeBase64String(this string inputStr)
        {
            try
            {
                if (inputStr == null)
                {
                    return null;
                }

                byte[] textAsBytes = Convert.FromBase64String(inputStr);
                return Encoding.UTF8.GetString(textAsBytes);
            }
            catch { throw; }

        }
        /// <summary>
        /// Encodes an array of bits to base64
        /// </summary>
        /// <param name="inputarray"></param>
        /// <returns></returns>
        public static string? EncodeBase64Byte(this byte[] inputarray)
        {
            try
            {
                if (inputarray == null)
                {
                    return null;
                }
                return Convert.ToBase64String(inputarray);
            }
            catch { throw; }

        }
        /// <summary>
        /// Decode a base 64 string to a bit array
        /// </summary>
        /// <param name="inputarray"></param>
        /// <returns></returns>
        public static byte[]? DecodeBase64Byte(this string inputarray)
        {
            try
            {
                if (inputarray == null)
                {
                    return null;
                }
                return Convert.FromBase64String(inputarray);
            }
            catch { throw; }

        }
        /// <summary>
        /// Encode a DataTable to base 64
        /// </summary>
        /// <param name="inputdata"></param>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public static string? EncodeBase64Table(this DataSet inputdata, string NombreTabla)
        {
            try
            {
                if (inputdata == null)
                {
                    return null;
                }
                StringWriter writer = new();
                inputdata.WriteXml(writer);
                var byteString = Encoding.UTF8.GetBytes(writer.ToString());
                return Convert.ToBase64String(byteString);
            }
            catch { throw; }
        }
        /// <summary>
        /// Encode a Base64 string to a DataTable
        /// </summary>
        /// <param name="inputdata"></param>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public static DataSet? DecodeBase64Table(this string inputdata)
        {
            try
            {
                if (inputdata == null)
                {
                    return null;
                }
                DataSet dt = new();
                byte[] textAsBytes = Convert.FromBase64String(inputdata);
                string strXmlString = Encoding.UTF8.GetString(textAsBytes);
                StringReader stringReader = new(strXmlString);
                dt.ReadXml(stringReader);
                return dt;
            }
            catch { throw; }

        }
    }
}
