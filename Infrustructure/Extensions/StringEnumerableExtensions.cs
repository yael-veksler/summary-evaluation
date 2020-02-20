using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummaryEvaluationAPI.Infrustructure.Extensions
{
    public static class StringEnumerableExtensions
    {
        /// <summary>
        /// Generates new sub enumerable from an existing enumerable
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start">Start index</param>
        /// <param name="end">End Index</param>
        /// <returns></returns>
        public static IEnumerable<string> SubEnumerable(this IEnumerable<string> arr, int start, int end)
        {
            var lst = new List<string>();
            var temp = arr.ToList();
            for (int i = start; i <= end; i++)
            {
                lst.Add(temp[i]);
            }
            return lst;
        }
    }

}