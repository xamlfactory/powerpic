using System.Collections.Generic;
using System.Linq;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public class SessionService<T>
    {
        private static Dictionary<T, object> paramList =
        new Dictionary<T, object>();

        public static void Save(T hash, object value)
        {
            if (!paramList.ContainsKey(hash))
                paramList.Add(hash, value);
            else
                paramList[hash] = value;
        }

        public static object Request(T hash)
        {
            return ((KeyValuePair<T, object>)paramList.
                        Where(x => x.Key.Equals(hash)).FirstOrDefault()).Value;
        }

        public static object TryRequest(T hash)
        {
            object value = null;
            paramList.TryGetValue(hash, out value);
            return value;
        }

        public static bool Remove(T hash)
        {
            if (paramList.ContainsKey(hash))
            {
                paramList.Remove(hash);
                return true;
            }

            return false;
        }
    }
}
