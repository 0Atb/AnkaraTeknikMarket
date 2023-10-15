using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace TeknikMarket.CoreMVCUI.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string json = JsonConvert.SerializeObject(value, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            if (!string.IsNullOrEmpty(json))
            {
                session.SetString(key, json);
            }
        }

        public static T GetObject<T>(this ISession session, string key)
            where T : class
        {
            string json = session.GetString(key);
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return null;
            }
        }



    }
}
