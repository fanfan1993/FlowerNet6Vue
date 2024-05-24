using Microsoft.Extensions.Caching.Memory;
using SqlSugar;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace yanfanFlower.Common
{
    public class MemoryHelper
    {
        private static IMemoryCache _memoryCache = null;

        static MemoryHelper()
        { 
          if (_memoryCache == null)
            {
                _memoryCache = new MemoryCache(new MemoryCacheOptions());
            }
        }

        /// <summary>
        ///  有效期 验证码
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireMins"></param>
        public static void SetMemory(string key, object value, int expireMins)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(expireMins));
        }

        public static object GetMemory(string key)
        {
            return _memoryCache.Get(key);
        }

    }
}
