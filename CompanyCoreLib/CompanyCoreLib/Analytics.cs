using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCoreLib
{
    public class Analytics
    {
        public List<DateTime> PopularMonths(List<DateTime> dates) {
    var DateTimeWithCounterList = new List<Tuple<DateTime, int>>();

    int PreviousYear = DateTime.Now.Year - 1;
    foreach (DateTime IterDate in dates)
    {
        if (IterDate.Year == PreviousYear)
        {
            var DateMonthStart = new DateTime(IterDate.Year, IterDate.Month, 1, 0, 0, 0);

            var index = DateTimeWithCounterList.FindIndex(item => item.Item1 == DateMonthStart);

            if (index == -1)
            {
                DateTimeWithCounterList.
                    Add( new Tuple<DateTime,int>(DateMonthStart, 1) );
            }
            else
            {
                DateTimeWithCounterList[index] = Tuple.Create(DateTimeWithCounterList[index].Item1, DateTimeWithCounterList[index].Item2 + 1);
            }
        }
    }

    return DateTimeWithCounterList
        .OrderByDescending(item => item.Item2)
        .ThenBy(item => item.Item1)
        .Select(item => item.Item1)
        .ToList();
}
    }
}
