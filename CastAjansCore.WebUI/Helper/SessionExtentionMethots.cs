using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI
{
    public static class SessionExtentionMethots
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string val = session.GetString(key);
            if (string.IsNullOrEmpty(val))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(val);
            }
        }
    }
}
