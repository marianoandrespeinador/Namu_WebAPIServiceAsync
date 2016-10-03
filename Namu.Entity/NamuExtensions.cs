using System;
using System.Collections.Generic;

namespace Namu.Entity
{
    public static class NamuExtensions
    {
        /// <summary>
        /// Reemplaza la sintaxis del foreach para hacerlo con lambda
        /// </summary>
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}
