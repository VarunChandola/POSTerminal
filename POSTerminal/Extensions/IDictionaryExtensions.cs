using System.Collections.Generic;

namespace POSTerminal.Extensions
{
    public static class IDictionaryExtensions
    {
        public static TV GetValueOrDefault<TK, TV>(this IDictionary<TK, TV> dictionary, TK key)
        {
            if (!dictionary.TryGetValue(key, out TV value))
            {
                return default;
            }

            return value;
        }
    }
}