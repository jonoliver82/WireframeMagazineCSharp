using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class JObjectExtensions
    {
        public static T Get<T>(this JObject json)
        {
            var name = typeof(T).Name;
            var section = name.Substring(0, name.IndexOf("Options", StringComparison.Ordinal));

            if (json.ContainsKey(section))
            {
                return json[section].ToObject<T>();
            }
            else
            {
                // Use default rather than T as it could be a non-nullable value type
                return default(T);
            }
        }
    }
}
