using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockVolume
    {
        public String Volume { get; set; }
        public String AskSize { get; set; }
        public String BidSize { get; set; }
        public String LastTradeSize { get; set; }
        public String AverageDailyVolume { get; set; }
    }
}
