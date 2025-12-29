using ScottPlot;
using Skender.Stock.Indicators;

namespace VStock
{
    public class Stock : IQuote
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }

        public OHLC ToOHLC()
        {
            return new OHLC
            {
                Open = (double)this.Open,
                High = (double)this.High,
                Low = (double)this.Low,
                Close = (double)this.Close,
                DateTime = this.Date,
                TimeSpan = TimeSpan.FromDays(1)
            };
        }
    }
}
