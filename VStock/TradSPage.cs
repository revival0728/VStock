using ScottPlot;
using ScottPlot.TickGenerators;
using Skender.Stock.Indicators;

namespace VStock
{
    public partial class TradSPage : Form
    {
        public TradSPage()
        {
            InitializeComponent();
        }

        public void InitHistoricalPage(string stockId, List<Stock> stocks)
        {
            DateTime from = stocks.Min(s => s.Date), to = stocks.Max(s => s.Date);
            decimal durMin = stocks.Min(s => s.Low), durMax = stocks.Max(s => s.High);
            Title.Text = $"{stockId} 趨勢圖";
            Info.Text = $"{from.ToShortDateString()} - {to.ToShortDateString()}, 資料筆數: {stocks.Count}, 區間最大價格: {durMax.Round(2)}, 區間最低價格: {durMin.Round(2)}";
            var plt = stockPlot.Plot;
            plt.Add.Candlestick(stocks.Select(s => s.ToOHLC()).ToList());
            plt.Axes.DateTimeTicksBottom();
            plt.Axes.SetLimitsX(from.AddDays(-1).ToOADate(), to.AddDays(-1).ToOADate());
            plt.Axes.SetLimitsY((double)durMin - 10, (double)durMax + 10);
            plt.ScaleFactor = 2;
            plt.Font.Automatic();
            stockPlot.Refresh();
        }

        public void InitRealTimePage(List<string> stockIds, List<Stock> stocks)
        {
            Title.Text = $"即時股價 趨勢圖";
            Info.Text = $"{stocks.First().Date}, 資料筆數: {stocks.Count}, 查詢股票: {string.Join(", ", stockIds)}";
            var plt = stockPlot.Plot;
            if (stockIds.Count != stocks.Count)
            {
                throw new Exception("股票數量與資料數量不符");
            }
            for (int i = 0; i < stockIds.Count; ++i)
            {
                var stockId = stockIds[i];
                var stock = stocks[i];
                bool OpenHigher = stock.Open > stock.Close;
                Box box = new()
                {
                    Position = i,
                    BoxMin = OpenHigher ? (double)stock.Close : (double)stock.Open,
                    BoxMax = OpenHigher ? (double)stock.Open : (double)stock.Close,
                    WhiskerMax = (double)stock.High,
                    WhiskerMin = (double)stock.Low,
                };
                plt.Add.Box(box);
                box.FillColor = OpenHigher ? Colors.Red : Colors.Green;
            }
            ScottPlot.TickGenerators.NumericFixedInterval tg = new(1)
            {
                LabelFormatter = (index) =>
                {
                    int idx = (int)Math.Round(index);
                    if (idx < 0 || idx >= stockIds.Count)
                    {
                        return "";
                    }
                    return stockIds[idx];
                }
            };
            plt.Axes.Bottom.TickGenerator = tg;
            plt.Axes.AutoScale();
            plt.ScaleFactor = 2;
            plt.Font.Automatic();
        }
    }
}
