using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace OnlineFoodOrderingSystem.Helper
{
    public static class SessionExtensions
    {
        // Set a complex object as JSON in session
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }

        // Get a complex object from session (returns default value if not found)
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return json == null ? default : JsonConvert.DeserializeObject<T>(json);
        }
    }
}