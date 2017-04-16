using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockRatios
    {
        public String EarningsPerShare { get; set; }
        public String EPSEstimateCurrentYear { get; set; }
        public String EPSEstimateNextYear { get; set; }
        public String EPSEstimateNextQuarter { get; set; }
        public String BookValue { get; set; }
        public String EBITDA { get; set; }
        public String PriceSales { get; set; }
        public String PriceBook { get; set; }
        public String PERatio { get; set; }
        public String PERatioRealTime { get; set; }
        public String PEGRatio { get; set; }
        public String PriceEPSEstimateCurrentYear { get; set; }
        public String PriceEPSEstimateNextYear { get; set; }
        public String ShortRatio { get; set; }
    }
}
