using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Common.Extensions
{
    public static class StringExtensions
    {
        public static string With(this string format, params object[] args)
        {
            return String.Format(format, args);
        }
    }
}
