using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Calbay.Core.Helper
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Gönderilen Object Value'u Decimal'e çevirir.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static decimal ToDecimalCul(this object str, CultureInfo cultureInfo)
        {
            if (str.IsNotNull())
                return Convert.ToDecimal(str, cultureInfo);
            else
                return 0;
        }
        /// <summary>
        /// Gönderilen Object Value'u Decimal'e çevirir.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object str)
        {
            if (str.IsNotNull())
                return Convert.ToDecimal(str);
            else
                return 0;
        }
        /// <summary>
        /// Eğer geri dönen değer null ise ve siz null olması durumunda bir değer döndürmesini istiyorsanız bu metodu kullanabilirsiniz.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <param name="returnValue">Null olduğunda geri döndüreceğiniz değer.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object str, decimal returnValue)
        {
            if (str.IsNull())
                return returnValue;
            else
                return Convert.ToDecimal(str);
        }
        /// <summary>
        /// Gönderilen Object value'yu nullable değer olarak decimal'e convert eder. Bu değer null ise geri decimal? tipinde null döner.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static decimal? ToNDecimal(this object str)
        {
            if (str.IsNull()) return null;
            else return Convert.ToDecimal(str);
        }
        /// <summary>
        /// Nesneyi Double'a Convert eder.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static double ToDouble(this object str)
        {
            return Convert.ToDouble(str);
        }
        /// <summary>
        /// Nesneyi Double'a Convert eder.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <param name="returnValue">Null olduğunda geri döndüreceğiniz değer.</param>
        /// <returns></returns>
        public static double ToDouble(this object str, double returnValue, CultureInfo cultureInfo)
        {
            if (str.IsNull())
                return returnValue;
            else
                return Convert.ToDouble(str, cultureInfo);
        }

        /// <summary>
        /// Nesneyi Double'a Convert eder.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <param name="returnValue">Null olduğunda geri döndüreceğiniz değer.</param>
        /// <returns></returns>
        public static double ToDouble(this object str, double returnValue)
        {
            if (str.IsNull())
                return returnValue;
            else
                return Convert.ToDouble(str);
        }
        /// <summary>
        /// Nesneyi Nullable olacak şekilde Double'a Convert eder. Dönen değer double?'dır.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static double? ToNDouble(this object str)
        {
            if (str.IsNull()) return null;
            else return Convert.ToDouble(str);
        }
        /// <summary>
        /// Nesneyi DateTime'e çevirir.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object str)
        {
            return Convert.ToDateTime(str.ToString());
        }
        /// <summary>
        /// Nesneyi DateTime'e çevirir.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object str, DateTime returnValue)
        {
            if (str.IsNull())
                return returnValue;
            else
                return Convert.ToDateTime(str.ToString());
        }

        public static DateTime ToDateTime(this object dtStr, string format)
        {
            DateTime result = DateTime.MinValue;

            if (dtStr == null || dtStr == DBNull.Value)
                return DateTime.MinValue;
            if (dtStr is DateTime)
                return (DateTime)dtStr;
            else
                if (!DateTime.TryParseExact(dtStr.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                result = DateTime.MinValue;
            return result;
        }

        /// <summary>
        /// Nesneyi TimeSpan'a çevirir.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this object str)
        {
            return TimeSpan.Parse(str.ToString());
        }
        /// <summary>
        /// Nesneyi Int64(long)'e Convert eder.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static long ToInt64(this object str)
        {
            return Convert.ToInt64(str);
        }
        /// <summary>
        /// Nesneyi Long(Int64)'a Convert eder.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToLong(this object str)
        {
            return str.ToInt64();
        }
        /// <summary>
        /// Nesneyi long(Int64)'a Convert eder.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <param name="returnValue">Null olduğunda geri döndüreceğiniz değer.</param>
        /// <returns></returns>
        public static long ToLong(this object str, short returnValue)
        {
            if (str.IsNull())
                return returnValue;
            else
                return Convert.ToInt64(str);
        }
        /// <summary>
        /// Nesneyi Int'e Convert eder.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this object str)
        {
            if (str.IsNotNull())
                return Convert.ToInt32(str);
            else
                return 0;
        }
        /// <summary>
        /// Nesneyi Int'e Convert eder.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <param name="returnValue">Null olduğunda geri döndüreceğiniz değer.</param>
        /// <returns></returns>
        public static int ToInt(this object str, int returnValue)
        {
            if (str.IsNull())
                return returnValue;
            else
                return Convert.ToInt32(str);
        }
        /// <summary>
        /// Nesneyi Nullable olacak şekilde int'e Convert eder. Dönen değer int?'dır.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <returns></returns>
        public static int? ToNInt(this object str)
        {
            if (str.IsNull()) return null;
            else return Convert.ToInt32(str);
        }
        /// <summary>
        /// Nesneyi değeri Short'a Convert eder.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static short ToShort(this object str)
        {
            return Convert.ToInt16(str);
        }
        /// <summary>
        /// Nesneyi short'a Convert eder.
        /// </summary>
        /// <param name="str">Convert edilecek değer.</param>
        /// <param name="returnValue">Null olduğunda geri döndüreceğiniz değer.</param>
        /// <returns></returns>
        public static short ToShort(this object str, short returnValue)
        {
            if (str.IsNull())
                return returnValue;
            else
                return Convert.ToInt16(str);
        }
        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }
        /// <summary>
        /// Nesne null ise true değilse false döner. Gönderilen obje DataSet veya DataTable ise ve Row'ları 0 ise yine true döner. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            if (obj is string && string.IsNullOrEmpty((string)obj))
                return true;
            else if (obj != null && obj is StringBuilder && ((StringBuilder)obj).Length == 0)
                return true;
            else
                return obj == null;
        }
        /// <summary>
        /// Eğer obje null ise parantez içinde gönderdiğiniz değeri size geri döner.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object IfIsNull(this object obj, object value)
        {
            if (obj.IsNull())
                return value;
            else
                return obj;
        }
        /// <summary>
        /// Gönderilen değer objeye eşitse 1 değilse 0, obje null ise -1 döner.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short IfIsValue(this object obj, object value)
        {
            if (obj.IsNull())
                return -1;
            else if (obj.Equals(value))
                return 1;
            else
                return 0;
        }
       
        public static string ToMD5(this String text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2").ToLower());
            }

            return builder.ToString();
        }

        /************************************************************************
         ADI            :  DataForUsage
         Yazan          :  Özer Karagöl
         Tarih          :  25/05/2006
         Guncelleyen    :  
         Tarih          :
         Acıklama       : SQL tipinde bir veriyi string e dondurmede kullanılır.
         ***********************************************************************/
        public static string DataForUsage(this Object data)
        {
            NumberFormatInfo nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberDecimalDigits = 2,
                NumberGroupSeparator = "."
            };

            if (data is System.Decimal)
            {
                Decimal dc = (Decimal)data;
                return String.Format(nfi, "{0:n}", dc);
            }

            if (data is System.Int16)
            {
                Int16 dc = (Int16)data;
                return dc.ToString();
            }

            if (data is System.Int32)
            {
                Int32 dc = (Int32)data;
                return dc.ToString();
            }

            if (data is System.Int64)
            {
                Int64 dc = (Int64)data;
                return dc.ToString();
            }

            if (data is System.Double)
            {
                Double dc = (Double)data;
                return String.Format(nfi, "{0:n}", dc);
            }

            if (data is System.DateTime)
            {
                DateTime dt = (DateTime)data;
                return dt.ToString();
            }

            if (data is System.Boolean)
            {
                bool _data = Boolean.Parse(data.ToString());
                return (_data ? "1" : "0");
            }

            if (data == null || data == DBNull.Value) return ""; else return data.ToString().Trim();
        }

        /************************************************************************
         ADI            :  DataForUsage
         Yazan          :  Özer Karagöl
         Tarih          :  25/05/2006
         Guncelleyen    :  
         Tarih          :
         Acıklama       : Bir tipteki veriyi SQL tipe dondurmede kullanılır.
         ***********************************************************************/
        public static Object DataForSQL(this Object data)
        {
            if (data is DBNull)
            {
                return DBNull.Value;
            }

            if (data is DateTime)
            {
                if (data == null) return DBNull.Value; else return ((DateTime)data);
            }

            if (data is Boolean)
            {
                if (data == null) return DBNull.Value; else return data.Equals(true) ? 1 : 0;
            }
            if (data is double)
            {
                return (data ?? DBNull.Value);
            }

            if (data is Decimal)
            {
                return (data ?? DBNull.Value);
            }

            if (data is Int16)
            {
                return (data ?? DBNull.Value);
            }

            if (data is Int32)
            {
                return (data ?? DBNull.Value);
            }

            if (data is Int64)
            {
                return (data ?? DBNull.Value);
            }

            if (data is Byte[])
            {
                return (data ?? DBNull.Value);
            }

            if (data == null || data.ToString().Trim().Equals("")) return DBNull.Value; else return data.ToString().Trim();

        }

        public static bool IsNumeric(this string s)
        {
            return float.TryParse(s, out float output);
        }

        public static Stream ToStream(this string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static byte[] ToByteArray(this Stream input)
        {
            if (input.GetType() == typeof(MemoryStream))
            {
                return ((MemoryStream)input).ToArray();
            }
            else
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    if (ms.Length == 0)
                    {
                        try
                        {
                            return ((MemoryStream)input).ToArray();
                        }
                        catch
                        {

                        }
                    }
                    return ms.ToArray();
                }
            }


        }

        public static byte[] ToByteArray(this MemoryStream input)
        {
            return input.ToArray();
        }

        //public static byte[] ToByteArray(this Object obj)
        //{
        //    if (obj == null)
        //        return null;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    MemoryStream ms = new MemoryStream();
        //    bf.Serialize(ms, obj);
        //    return ms.ToArray();
        //}

        public static Object ToObject(this byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public static Stream ToStream(this byte[] arrBytes)
        {
            Stream memStream = new MemoryStream();

            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);

            return memStream;
        }


        public static string ToHexadecimal(this byte[] ba)
        {
            return Convert.ToBase64String(ba, 0, ba.Length);
        }

        public static string GetDecimalStringValue(this object obj)
        {
            string sonuc = "";
            if (obj != null)
            {
                NumberFormatInfo nfi = new NumberFormatInfo
                {
                    CurrencyDecimalDigits = 2,
                    CurrencyDecimalSeparator = ".",
                    CurrencyGroupSeparator = ",",
                    NumberDecimalDigits = 2,
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ","
                };
                if (obj is decimal)
                {
                    sonuc = ((decimal)obj).ToString("#,##0.#0", nfi);
                }
                if (obj is double)
                {
                    sonuc = ((double)obj).ToString("#,##0.#0", nfi);

                }
            }
            return sonuc;
        }

        public static string GetIntegerStringValue(this object obj)
        {
            string sonuc = "";
            if (obj != null && !obj.DataForUsage().Equals(""))
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                sonuc = ((int)obj).ToString(nfi);
            }
            return sonuc;
        }

        public static string ToDateStr(this object str, string format = "dd.MM.yyyy")
        {
            return str.IsNull() ? "" : str.ToDateTime().ToString(format);
        }

        public static string OzetText(this string str, int lenght)
        {
            if (str.IsNull())
            {
                return "";
            }
            else
            {
                if (str.DataForUsage().Length > lenght)
                {
                    return str.DataForUsage().Substring(0, lenght) + "...";
                }
                else
                {
                    return str.DataForUsage();
                }
            }
        }

        public static byte[] ToByteArray(this Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public static byte[] ToByteArray(this Image img, ImageFormat imageFormat)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, imageFormat);
            return ms.ToArray();
        }

        public static Image ToImage(this byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static string ToLogStr(this Exception ex)
        {
            string str = "";
            if (ex.InnerException.IsNotNull())
            {
                str = "InnerException.Source:" + ex.InnerException.Source + Environment.NewLine;
                str += "InnerException.Message:" + ex.InnerException.Message + Environment.NewLine;
                str += "InnerException.StackTrace:" + ex.InnerException.StackTrace;
            }
            else
            {
                str = "Source:" + ex.Source + Environment.NewLine;
                str += "Message:" + ex.Message + Environment.NewLine;
                str += "InnerException.StackTrace:" + ex.StackTrace;
            }
            return str;
        }

        public static bool ToBool(this object str)
        {
            switch (str.ToString().ToLower())
            {
                case "1":
                case "true":
                case "y":
                case "yes":
                case "e":
                case "evet":
                    return true;
                case "":
                case "0":
                case "false":
                case "n":
                case "no":
                case "h":
                case "hayır":
                case "hayir":
                    return false;
                default:
                    return Convert.ToBoolean(str);
            }
        }

        public static bool ToBool(this object str, bool returnValue)
        {
            if (str.IsNull())
                return returnValue;
            else
                return ToBool(str);
        }

        

      

         

        private static bool RowEqual(object[] Values, object[] OtherValues)
        {
            if (Values == null)
                return false;

            for (int i = 0; i < Values.Length; i++)
            {
                if (!Values[i].Equals(OtherValues[i]))
                    return false;
            }
            return true;
        }
         
        public static string MaxLength(this string val, int MaxLength)
        {
            return val.Length <= 4000 ? val : val.Substring(0, MaxLength - 1);
        }


        public static string TurkceKarakterdenDonustur(this string val)
        {
            return val.Replace('Ğ', 'G').Replace('İ', 'I').Replace('Ö', 'O').Replace('Ş', 'S').Replace('Ç', 'C').Replace('Ü', 'U').
                           Replace('ğ', 'g').Replace("ı", "i").Replace('ö', 'o').Replace('ş', 's').Replace('ç', 'c').Replace('ü', 'u');
        }

        public static string ToDisplay(this Enum value)
        {

            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }



    }
}
