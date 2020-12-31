using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class Common
    {
        public static string Print(this int[] input)
        {
            var result = new StringBuilder();
            foreach(var i in input)
            {
                result.Append(i + ",");
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
