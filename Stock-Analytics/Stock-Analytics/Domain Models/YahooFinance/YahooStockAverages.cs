using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockAverages
    {
        public String AfterHoursChangeRealtime { get; set; }
        public String Commission { get; set; }
        public String DayLow { get; set; }
        public String DayHigh { get; set; }
        public String LastTradeRealTimeWithTime { get; set; }
        public String LastTradeWithTime { get; set; }
        public String LastTradePriceOnly { get; set; }
        public String TargetPrice1Yr { get; set; }
        public String ChangeFrom200DayMovingAverage { get; set; }
        public String PercentChangeFrom200DayMovingAverage { get; set; }
        public String ChangeFrom50DayMovingAverage { get; set; }
        public String PercentChangeFrom50DayMovingAverage { get; set; }
        public String MovingAverage50Day { get; set; }
        public String MovingAverage200Day { get; set; }
    }
    }
}
