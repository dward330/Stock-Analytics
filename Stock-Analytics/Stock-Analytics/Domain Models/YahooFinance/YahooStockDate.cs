using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockDate
    {
        public String Change { get; set; }
        public String ChangePercentChange { get; set; }
        public String ChangeRealTime { get; set; }
        public String ChangePercentRealtime { get; set; }
        public String ChangeInPercent { get; set; }
        public String LastTradeDate { get; set; }
        public String TradeDate { get; set; }
        public String LastTradeTime { get; set; }
    }
}
