namespace Stock_Analytics.Domain_Models.YahooFinance
{
    public class YahooStock
    {
        public YahooStockPricing Pricing { get; set; }
        public YahooStockDividends Dividends { get; set; }
        public YahooStockDate Dates { get; set; }
        public YahooStockAverages Averages { get; set; }
        public YahooStockMisc MiscInfo { get; set; }
        public YahooStock52WeekPricing WeekPricing52 { get; set; }
        public YahooStockSymbolInfo SymbolInfo { get; set; }
        public YahooStockVolume Volume { get; set; }
        public YahooStockRatios Ratios { get; set; }
    }
}
