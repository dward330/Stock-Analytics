using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockMisc
    {
        public String DayValueChange { get; set; }
        public String DayValueChangeRealTime { get; set; }
        public String PricePaid { get; set; }
        public String DayRange { get; set; }
        public String DayRangeRealTime { get; set; }
        public String HoldingsGainPercent { get; set; }
        public String AnnualizedGain { get; set; }
        public String HoldingsGain { get; set; }
        public String HoldingsGainPercentRealTime { get; set; }
        public String HoldingsGainRealTime { get; set; }
        public String TickerTrend { get; set; }
        public String TradeLinks { get; set; }
        public String OrderBookRealTime { get; set; }
        public String HighLimit { get; set; }
        public String LowLimit { get; set; }
        public String HoldingsValue { get; set; }
        public String HoldingsValueRealTime { get; set; }
        public String Revenue { get; set; }
    }
}
