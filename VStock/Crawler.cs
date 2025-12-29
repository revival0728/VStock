using YahooFinanceApi;

namespace VStock
{
    public class Crawler
    {
        public static async Task<List<Stock>> GetRealTime(List<string> stockIds)
        {
            var securities = await Yahoo.Symbols(stockIds.ToArray()).Fields(
                Field.Symbol, 
                Field.RegularMarketOpen, 
                Field.RegularMarketDayHigh,
                Field.RegularMarketDayLow,
                Field.RegularMarketPrice,
                Field.RegularMarketVolume,
                Field.RegularMarketTime).QueryAsync();
            var res = new List<Stock>();
            foreach (var symbol in securities.Keys)
            {
                var security = securities[symbol];
                res.Add(new Stock
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds((long)(security[Field.RegularMarketTime] ?? 0)).DateTime,
                    Open = (decimal)(security[Field.RegularMarketOpen] ?? 0),
                    High = (decimal)(security[Field.RegularMarketDayHigh] ?? 0),
                    Low = (decimal)(security[Field.RegularMarketDayLow] ?? 0),
                    Close = (decimal)(security[Field.RegularMarketPrice] ?? 0),
                    Volume = (decimal)(security[Field.RegularMarketVolume] ?? 0),
                });
            }
            return res;
        }

        static bool PartialEq(decimal a, decimal b)
        {
            return Math.Abs(a - b) < (decimal)1e-6;
        }

        public static async Task<List<Stock>> GetHistorical(string stockId, DateTime from, DateTime to)
        {
            var history = await Yahoo.GetHistoricalAsync(stockId, from, to, Period.Daily);
            var res = new List<Stock>();
            foreach (var item in history)
            {
                if (PartialEq(item.High, item.Low) || (PartialEq(item.High, 0) && PartialEq(item.Low, 0)))
                {
                    continue;
                }
                res.Add(new Stock
                {
                    Date = item.DateTime,
                    Open = item.Open,
                    High = item.High,
                    Low = item.Low,
                    Close = item.Close,
                    Volume = item.Volume,
                });
            }
            return res;
        }
    }
}
