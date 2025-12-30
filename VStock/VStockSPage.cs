using Skender.Stock.Indicators;

namespace VStock
{
    public partial class VStockSPage : Form
    {

        Graphics graphics;

        public VStockSPage()
        {
            InitializeComponent();
            graphics = canvas.CreateGraphics();
        }

        void InitCanvas(List<Stock> stocks)
        {
            graphics.Clear(Color.White);
            List<int> opens = stocks.Select(s => (int)s.Open.Round(0)).ToList();
            List<int> closes = stocks.Select(s => (int)s.Close.Round(0)).ToList();
            List<int> highs = stocks.Select(s => (int)s.High.Round(0)).ToList();
            List<int> lows = stocks.Select(s => (int)s.Low.Round(0)).ToList();
            List<int> volumes = stocks.Select(s => (int)s.Volume.Round(0)).ToList();
            List<int> dates = stocks.Select(s => (int)s.Date.ToOADate().Round(0)).ToList();
            Matrix openMat = Matrix.FromList(opens);
            Matrix closeMat = Matrix.FromList(closes);
            Matrix highMat = Matrix.FromList(highs);
            Matrix lowMat = Matrix.FromList(lows);
            Matrix volumeMat = Matrix.FromList(volumes);
            Matrix dateMat = Matrix.FromList(dates);

            int MC = 1 << 8;
            Matrix R = closeMat.mul(openMat, MC);
            Matrix G = highMat.mul(lowMat, MC);
            Matrix B = volumeMat.mul(dateMat, MC);
            Matrix A = openMat.mul(closeMat.mul(dateMat, MC), MC);

            int cHeight = canvas.Height;
            int cWidth = canvas.Width;
            Info.Text = $"畫布大小: {cWidth}x{cHeight}, 矩陣大小: {R.Col}x{R.Row}, 每像素矩陣元素數量: 1";
            if (cHeight >= R.Row && cWidth >= R.Col)
            {
                for (int i = 0; i < R.Row; i++)
                {
                    for (int j = 0; j < R.Col; j++)
                    {
                        int r = R[i, j];
                        int g = G[i, j];
                        int b = B[i, j];
                        int a = A[i, j];
                        Color color = Color.FromArgb(a, r, g, b);
                        Brush brush = new SolidBrush(color);
                        int rectWidth = cWidth / R.Col;
                        int rectHeight = cHeight / R.Row;
                        graphics.FillRectangle(brush, j * rectWidth, i * rectHeight, rectWidth, rectHeight);
                    }
                }
            } else
            {
                for (int i = 0; i < cHeight; i++)
                {
                    for (int j = 0; j < cWidth; j++)
                    {
                        int ratio = R.Row / cHeight;
                        int r = 0, g = 0, b = 0, a = 0;
                        for (int k = 0; k < cHeight; ++k)
                        {
                            for (int l = 0; l < cWidth; ++l)
                            {
                                r += R[i * ratio + k, j * ratio + l];
                                g += G[i * ratio + k, j * ratio + l];
                                b += B[i * ratio + k, j * ratio + l];
                                a += A[i * ratio + k, j * ratio + l];
                            }
                        }
                        int ratioSq = ratio * ratio;
                        r /= ratioSq;
                        g /= ratioSq;
                        b /= ratioSq;
                        a /= ratioSq;
                        Color color = Color.FromArgb(a, r, g, b);
                        Brush brush = new SolidBrush(color);
                        graphics.FillRectangle(brush, j, i, 1, 1);
                    }
                }
            }
            canvas.Refresh();
            canvas.Invalidate();
        }
        public void InitHistoricalPage(string stockId, List<Stock> stocks)
        {
            this.Text = $"{stockId} 分析圖";
            Title.Text = $"{stockId} 分析圖";
            InitCanvas(stocks);
        }
        public void InitRealTimePage(List<string> stockIds, List<Stock> stocks)
        {
            this.Text = $"即時多股分析圖";
            Title.Text = $"即時多股分析圖";
            InitCanvas(stocks);
        }
    }
}
