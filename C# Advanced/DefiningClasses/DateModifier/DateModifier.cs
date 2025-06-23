using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier() { }

        public int GetDaysDifference(string firstDataStr, string secondDateStr)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime firstDate = DateTime.ParseExact(firstDataStr, "yyyy MM dd", provider);
            DateTime secondDate = DateTime.ParseExact(secondDateStr, "yyyy MM dd", provider);

            return Math.Abs((firstDate - secondDate).Days);
        }
    }
}
