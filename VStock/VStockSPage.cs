using Skender.Stock.Indicators;

namespace VStock
{
    public partial class VStockSPage : Form
    {
        int cSLength;
        Bitmap img;

        public VStockSPage()
        {
            InitializeComponent();
            cSLength = Math.Min(canvas.Height, canvas.Width);
            img = new Bitmap(cSLength, cSLength);
        }

        void InitCanvas(List<Stock> stocks)
        {
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
            Matrix R = closeMat.Mul(openMat, MC);
            Matrix G = highMat.Mul(lowMat, MC);
            Matrix B = volumeMat.Mul(dateMat, MC);
            Matrix A = openMat.Mul(closeMat.Mul(dateMat, MC), MC);
            Matrix gR = new Matrix(cSLength, cSLength);
            Matrix gG = new Matrix(cSLength, cSLength);
            Matrix gB = new Matrix(cSLength, cSLength);
            Matrix gA = new Matrix(cSLength, cSLength);

            if (cSLength >= R.Row && cSLength >= R.Col)
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
                        int rectWidth = cSLength / R.Col;
                        int rectHeight = cSLength / R.Row;
                        gR.Fill(j * rectWidth, i * rectHeight, rectWidth, rectHeight, r);
                        gG.Fill(j * rectWidth, i * rectHeight, rectWidth, rectHeight, g);
                        gB.Fill(j * rectWidth, i * rectHeight, rectWidth, rectHeight, b);
                        gA.Fill(j * rectWidth, i * rectHeight, rectWidth, rectHeight, a);
                    }
                }
            }
            else
            {
                for (int i = 0; i < cSLength; i++)
                {
                    for (int j = 0; j < cSLength; j++)
                    {
                        int ratio = R.Row / cSLength;
                        int r = 0, g = 0, b = 0, a = 0;
                        for (int k = 0; k < cSLength; ++k)
                        {
                            for (int l = 0; l < cSLength; ++l)
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
                        gR[i, j] = r;
                        gG[i, j] = g;
                        gB[i, j] = b;
                        gA[i, j] = a;
                    }
                }
            }
            for (int i = 0; i < cSLength; i++)
            {
                for (int j = 0; j < cSLength; j++)
                {
                    int r = gR[i, j];
                    int g = gG[i, j];
                    int b = gB[i, j];
                    int a = gA[i, j];
                    Color color = Color.FromArgb(a, r, g, b);
                    img.SetPixel(j, i, color);
                }
            }
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

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            canvas.Image = img;
        }
    }
}
