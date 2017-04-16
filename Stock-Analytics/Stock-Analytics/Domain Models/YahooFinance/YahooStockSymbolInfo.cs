using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockSymbolInfo
    {
        public String MoreInfo { get; set; }
        public String MarketCapitalization { get; set; }
        public String MarketCapRealTime { get; set; }
        public String FloatShares { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }
        public String Symbol { get; set; }
        public String SharesOwned { get; set; }
        public String StockExchange { get; set; }
        public String SharesOutstanding { get; set; }
    }
}
