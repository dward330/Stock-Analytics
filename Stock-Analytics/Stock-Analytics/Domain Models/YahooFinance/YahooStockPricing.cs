using System;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockPricing
    {
        public String Ask { get; set; }
        public String AskRealTime { get; set; }
        public String Bid { get; set; }
        public String BidRealTime { get; set; }
        public String PreviousClose { get; set; }
        public String Open { get; set; }
    }
}
