using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStock52WeekPricing
    {
        public String WeekHigh52 { get; set; }
        public String WeekLow52 { get; set; }
        public String ChangeFrom52WeekLow { get; set; }
        public String ChangeFrom52WeekHigh { get; set; }
        public String PercentChangeFromWeekLow52 { get; set; }
        public String PercentChangeFromWeekHigh52 { get; set; }
        public String WeekRange52 { get; set; }
    }
}
