using ScottPlot;
using ScottPlot.DataSources;
using Skender.Stock.Indicators;
using System.Security;

namespace VStock
{
    public partial class TradSPage : Form
    {
        // Plot Function
        // 1. SMA
        // 2. Bollinger Bands (BollingerB)
        List<ScottPlot.Plottables.Scatter> smaScatters = new();
        List<ScottPlot.Plottables.Scatter> bbScatters = new();

        public TradSPage()
        {
            InitializeComponent();
        }

        public void InitHistoricalPage(string stockId, List<Stock> stocks)
        {
            DateTime from = stocks.Min(s => s.Date), to = stocks.Max(s => s.Date);
            decimal durMin = stocks.Min(s => s.Low), durMax = stocks.Max(s => s.High);
            Title.Text = $"{stockId} 趨勢圖";
            this.Text = Title.Text;
            Info.Text = $"{from.ToShortDateString()} - {to.ToShortDateString()}, 資料筆數: {stocks.Count}, 區間最大價格: {durMax.Round(2)}, 區間最低價格: {durMin.Round(2)}";
            var plt = stockPlot.Plot;

            List<OHLC> ohlcStocks = stocks.Select(s => s.ToOHLC()).ToList();
            plt.Add.Candlestick(ohlcStocks);

            // SMA
            {
                int[] windowSizes = { 3, 20, 60 };
                double[] smaColorAlpha = { 1, 0.6, 0.4 };
                for (int i = 0; i < windowSizes.Length; ++i)
                {
                    int windowSize = windowSizes[i];
                    IEnumerable<SmaResult> smaResults = stocks.GetSma(windowSize);
                    double[] dates = smaResults.Where(r => r.Sma != null).Select(r => r.Date.ToOADate()).ToArray();
                    double[] sma = smaResults.Where(r => r.Sma != null).Select(r => (double)r.Sma!).ToArray();
                    ScatterSourceDoubleArray ssda = new(dates, sma);
                    ScottPlot.Plottables.Scatter sp = new(ssda);
                    smaScatters.Add(sp);
                    sp.LegendText = $"SMA {windowSize}";
                    sp.MarkerSize = 0;
                    sp.LineWidth = 3;
                    sp.Color = Colors.Navy.WithAlpha(smaColorAlpha[i]);
                }
            }

            // Bollinger Bands
            {
                IEnumerable<BollingerBandsResult> bbResults = stocks.GetBollingerBands();
                double[] dates = bbResults.Where(r => r.UpperBand != null).Select(r => r.Date.ToOADate()).ToArray();
                double[] upperBand = bbResults.Where(r => r.UpperBand != null).Select(r => (double)r.UpperBand!).ToArray();
                double[] lowerBand = bbResults.Where(r => r.LowerBand != null).Select(r => (double)r.LowerBand!).ToArray();
                double[] sma = bbResults.Where(r => r.Sma != null).Select(r => (double)r.Sma!).ToArray();
                ScatterSourceDoubleArray upperBandSSDA = new(dates, upperBand);
                ScatterSourceDoubleArray lowerBandSSDA = new(dates, lowerBand);
                ScatterSourceDoubleArray smaSSDA = new(dates, sma);
                ScottPlot.Plottables.Scatter upperBandSp = new(upperBandSSDA);
                ScottPlot.Plottables.Scatter lowerBandSp = new(lowerBandSSDA);
                ScottPlot.Plottables.Scatter smaSp = new(smaSSDA);
                bbScatters.Add(upperBandSp);
                bbScatters.Add(lowerBandSp);
                bbScatters.Add(smaSp);
                upperBandSp.Color = Colors.Gray;
                upperBandSp.MarkerSize = 0;
                lowerBandSp.Color = Colors.Gray;
                lowerBandSp.MarkerSize = 0;
                smaSp.Color = Colors.Gray;
                smaSp.LinePattern = LinePattern.Dotted;
                smaSp.MarkerSize = 0;
            }

            plt.Axes.DateTimeTicksBottom();
            plt.Axes.SetLimitsX(from.AddDays(-1).ToOADate(), to.AddDays(-1).ToOADate());
            plt.Axes.SetLimitsY((double)durMin - 10, (double)durMax + 10);
            plt.ScaleFactor = 2;
            plt.Font.Automatic();
            stockPlot.Refresh();
            plotFn.Enabled = true;
        }

        public void InitRealTimePage(List<string> stockIds, List<Stock> stocks)
        {
            Title.Text = $"即時股價 趨勢圖";
            this.Text = Title.Text;
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

        private void plotFn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var plt = stockPlot.Plot;
            switch (e.Index)
            {
                case 0:
                    foreach (var smaScatter in smaScatters)
                    {
                        if (e.NewValue == CheckState.Checked)
                        {
                            plt.Add.Plottable(smaScatter);
                        }
                        else
                        {
                            plt.Remove(smaScatter);
                        }
                    }
                    break;
                case 1:
                    foreach (var bbScatter in bbScatters)
                    {
                        if (e.NewValue == CheckState.Checked)
                        {
                            plt.Add.Plottable(bbScatter);
                        }
                        else
                        {
                            plt.Remove(bbScatter);
                        }
                    }
                    break;
            }
            stockPlot.Refresh();
        }
    }
}
