using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsTracker
{
    public static class Extensions
    {
        public static int? ToSafeNullableInt(this string s)
        {
            var result = 0;
            var success = Int32.TryParse(s, out result);
            return success ? result : (int?)null;
        }
    }
}
