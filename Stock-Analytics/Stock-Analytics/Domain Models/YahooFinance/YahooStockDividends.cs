using System;

namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStockDividends
    {
        public String DividendYield { get; set; }
        public String DividendPerShare { get; set; }
        public String DividendPayDate { get; set; }
        public String ExDividendDate { get; set; }
    }
}
