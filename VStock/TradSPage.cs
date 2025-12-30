using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.DataSources;
using Skender.Stock.Indicators;
using System.Linq.Expressions;

namespace VStock
{
    public partial class TradSPage : Form
    {
        // Plot Function
        // 1. SMA
        // 2. Bollinger Bands (BollingerB)
        // 3. RSI
        // 4. MACD
        bool hasSma = false;
        bool hasBollingerB = false;
        bool hasRsi = false;
        bool hasMacd = false;
        List<Scatter> smaScatters = new();
        List<Scatter> bbScatters = new();
        List<Scatter> rsiScatters = new();
        List<LinePlot> rsiLines = new();
        List<Scatter> macdScatters = new();
        List<BarPlot> macdBarPlots = new();
        List<LinePlot> macdLines = new();

        int rightAxisMin = -15;
        int rightAxisMax = 100;

        public TradSPage()
        {
            InitializeComponent();
            stockPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
            stockPlot.Plot.Legend.Alignment = Alignment.UpperLeft;
        }

        void InitSma(double[] dates, double[] sma, int windowSize, double colorAlpha)
        {
            ScatterSourceDoubleArray ssda = new(dates, sma);
            ScottPlot.Plottables.Scatter sp = new(ssda);
            smaScatters.Add(sp);
            sp.LegendText = $"SMA {windowSize}";
            sp.MarkerSize = 0;
            sp.LineWidth = 3;
            sp.Color = Colors.Navy.WithAlpha(colorAlpha);
            hasSma = true;
        }
        
        void InitBollingerBands(double[] dates, double[] upperBand, double[] lowerBand, double[] sma)
        {
            ScatterSourceDoubleArray upperBandSSDA = new(dates, upperBand);
            ScatterSourceDoubleArray lowerBandSSDA = new(dates, lowerBand);
            ScatterSourceDoubleArray smaSSDA = new(dates, sma);
            Scatter upperBandSp = new(upperBandSSDA);
            Scatter lowerBandSp = new(lowerBandSSDA);
            Scatter smaSp = new(smaSSDA);
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
            hasBollingerB = true;
        }

        void InitRsi(double[] dates, double[] rsi)
        {
            ScatterSourceDoubleArray rsiSSDA = new(dates, rsi);
            Scatter rsiSp = new(rsiSSDA);
            rsiScatters.Add(rsiSp);
            rsiSp.Color = Colors.Orange;
            rsiSp.MarkerSize = 0;
            rsiSp.LineWidth = 2;
            LinePlot upperLine = new()
            {
                Start = new(dates.First(), 70),
                End = new(dates.Last(), 70),
                Color = Colors.Red,
                LinePattern = LinePattern.Dotted,
            };
            LinePlot lowerLine = new()
            {
                Start = new(dates.First(), 30),
                End = new(dates.Last(), 30),
                Color = Colors.Green,
                LinePattern = LinePattern.Dotted,
            };
            rsiLines.Add(upperLine);
            rsiLines.Add(lowerLine);
            hasRsi = true;
        }

        void InitMacd(double[] dates, double[] macd, double[] signal, double[] histogram)
        {
            ScatterSourceDoubleArray macdSSDA = new(dates, macd);
            ScatterSourceDoubleArray signalSSDA = new(dates, signal);
            Scatter macdSp = new(macdSSDA);
            Scatter signalSp = new(signalSSDA);
            macdScatters.Add(macdSp);
            macdScatters.Add(signalSp);
            macdSp.MarkerSize = 0;
            macdSp.Color = Colors.Red;
            macdSp.LineWidth = 2;
            macdSp.LegendText = "MACD";
            signalSp.MarkerSize = 0;
            signalSp.Color = Colors.Blue;
            signalSp.LineWidth = 2;
            signalSp.LegendText = "Signal";
            List<Bar> histogramBars = new();
            foreach (var (date, histogramE) in dates.Zip(histogram))
            {
                histogramBars.Add(new Bar()
                {
                    Position = date,
                    Value = histogramE,
                    FillColor = Colors.SlateGray.WithAlpha(0.8),
                    LineStyle = LineStyle.None,
                });
            }
            BarPlot histogramBarPlot = new(histogramBars);
            macdBarPlots.Add(histogramBarPlot);
            LinePlot zeroLine = new()
            {
                Start = new(dates.First(), 0),
                End = new(dates.Last(), 0),
                Color = Colors.Black,
                LinePattern = LinePattern.Dashed,
            };
            macdLines.Add(zeroLine);
            hasMacd = true;
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
                    if (dates.Length == 0 || sma.Length == 0)
                    {
                        continue;
                    }
                    InitSma(dates, sma, windowSize, smaColorAlpha[i]);
                }
            }

            // Bollinger Bands
            {
                IEnumerable<BollingerBandsResult> bbResults = stocks.GetBollingerBands();
                double[] dates = bbResults.Where(r => r.UpperBand != null).Select(r => r.Date.ToOADate()).ToArray();
                double[] upperBand = bbResults.Where(r => r.UpperBand != null).Select(r => (double)r.UpperBand!).ToArray();
                double[] lowerBand = bbResults.Where(r => r.LowerBand != null).Select(r => (double)r.LowerBand!).ToArray();
                double[] sma = bbResults.Where(r => r.Sma != null).Select(r => (double)r.Sma!).ToArray();
                if(dates.Length > 0 && upperBand.Length > 0 && lowerBand.Length > 0 && sma.Length > 0)
                {
                    InitBollingerBands(dates, upperBand, lowerBand, sma);
                }
            }

            // RSI
            {
                IEnumerable<RsiResult> rsiResults = stocks.GetRsi();
                double[] dates = rsiResults.Where(r => r.Rsi != null).Select(r => r.Date.ToOADate()).ToArray();
                double[] rsi = rsiResults.Where(r => r.Rsi != null).Select(r => (double)r.Rsi!).ToArray();
                if(dates.Length > 0 && rsi.Length > 0)
                {
                    InitRsi(dates, rsi);
                }
            }

            // MACD
            {
                IEnumerable<MacdResult> macdResults = stocks.GetMacd();
                double[] dates = macdResults.Where(r => r.Macd != null).Select(r => r.Date.ToOADate()).ToArray();
                double[] macd = macdResults.Where(r => r.Macd != null).Select(r => (double)r.Macd!).ToArray();
                double[] signal = macdResults.Where(r => r.Signal != null).Select(r => (double)r.Signal!).ToArray();
                double[] histogram = macdResults.Where(r => r.Histogram != null).Select(r => (double)r.Histogram!).ToArray();
                if(dates.Length > 0 && macd.Length > 0 && signal.Length > 0 && histogram.Length > 0)
                {
                    InitMacd(dates, macd, signal, histogram);
                }
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

        private void UpdatePlottables(IEnumerable<IPlottable> plottable, bool addOrRemove)
        {
            if (addOrRemove)
            {
                foreach (var p in plottable)
                {
                    stockPlot.Plot.Add.Plottable(p);
                }
            }
            else
            {
                foreach (var p in plottable)
                {
                    stockPlot.Plot.Remove(p);
                }
            }
        }

        private void plotFn_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var plt = stockPlot.Plot;
            switch (e.Index)
            {
                case 0:
                    if (!hasSma)
                    {
                        MessageBox.Show("此股票選取的時間區間無法計算 SMA 指標");
                        e.NewValue = e.CurrentValue;
                        break;
                    }
                    UpdatePlottables(smaScatters, e.NewValue == CheckState.Checked);
                    break;
                case 1:
                    if(!hasBollingerB)
                    {
                        MessageBox.Show("此股票選取的時間區間無法計算 Bollinger Bands 指標");
                        e.NewValue = e.CurrentValue;
                        break;
                    }
                    UpdatePlottables(bbScatters, e.NewValue == CheckState.Checked);
                    break;
                case 2:
                    if(!hasRsi)
                    {
                        MessageBox.Show("此股票選取的時間區間無法計算 RSI 指標");
                        e.NewValue = e.CurrentValue;
                        break;
                    }
                    UpdatePlottables(rsiScatters, e.NewValue == CheckState.Checked);
                    UpdatePlottables(rsiLines, e.NewValue == CheckState.Checked);
                    rsiScatters.First().Axes.YAxis = plt.Axes.Right;
                    rsiLines.ForEach(line => line.Axes.YAxis = plt.Axes.Right);
                    plt.Axes.SetLimitsY(bottom: rightAxisMin, top: rightAxisMax, yAxis: plt.Axes.Right);
                    break;
                case 3:
                    if(!hasMacd)
                    {
                        MessageBox.Show("此股票選取的時間區間無法計算 MACD 指標");
                        e.NewValue = e.CurrentValue;
                        break;
                    }
                    UpdatePlottables(macdBarPlots, e.NewValue == CheckState.Checked);
                    UpdatePlottables(macdScatters, e.NewValue == CheckState.Checked);
                    UpdatePlottables(macdLines, e.NewValue == CheckState.Checked);
                    macdScatters.ForEach(scatter => scatter.Axes.YAxis = plt.Axes.Right);
                    macdBarPlots.First().Axes.YAxis = plt.Axes.Right;
                    macdLines.ForEach(line => line.Axes.YAxis = plt.Axes.Right);
                    plt.Axes.SetLimitsY(bottom: rightAxisMin, top: rightAxisMax, yAxis: plt.Axes.Right);
                    break;
            }
            stockPlot.Refresh();
        }
    }
}
