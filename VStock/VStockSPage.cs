using Skender.Stock.Indicators;

namespace VStock
{
    public partial class VStockSPage : Form
    {
        readonly int cSLength;
        bool hasNoiseImg = false;
        bool hasStairImg = false;
        Bitmap noiseImg, stairImg;

        static readonly int MC = 1 << 8;
        Matrix R = new(0, 0);
        Matrix G = new(0, 0);
        Matrix B = new(0, 0);
        Matrix A = new(0, 0);

        public VStockSPage()
        {
            InitializeComponent();
            cSLength = Math.Min(canvas.Height, canvas.Width);
            noiseImg = new Bitmap(cSLength, cSLength);
            stairImg = new Bitmap(cSLength, cSLength);
        }

        void DrawColorsToImg(Bitmap img, Matrix gR, Matrix gG, Matrix gB, Matrix gA)
        {
            if (gR.Col != cSLength || gR.Row != cSLength ||
                gG.Col != cSLength || gG.Row != cSLength ||
                gB.Col != cSLength || gB.Row != cSLength ||
                gA.Col != cSLength || gA.Row != cSLength)
            {
                throw new ArgumentException("Matrix dimensions do not match canvas size.");
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

        void MakeNoiseImg(Matrix R, Matrix G, Matrix B, Matrix A)
        {
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
            DrawColorsToImg(noiseImg, gR, gG, gB, gA);
            hasNoiseImg = true;
        }

        void MakeStairImg(Matrix R, Matrix G, Matrix B, Matrix A)
        {
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

            Matrix rowVec = Matrix.Ones(1, cSLength);
            Matrix colVec = Matrix.Ones(cSLength, 1);
            Matrix ones = Matrix.Ones(cSLength, cSLength);
            Matrix rv = rowVec.Mul(gR, MC).Mul(colVec, MC);
            Matrix gv = rowVec.Mul(gG, MC).Mul(colVec, MC);
            Matrix bv = rowVec.Mul(gB, MC).Mul(colVec, MC);
            gR.Fill(0, 0, cSLength, cSLength, rv[0, 0]);
            gG.Fill(0, 0, cSLength, cSLength, gv[0, 0]);
            gB.Fill(0, 0, cSLength, cSLength, bv[0, 0]);
            gA.Apply(e =>
                (int)Math.Clamp(
                    Math.Sin(e / 255.0 * Math.PI) * Math.Cos(e / 255.0 * Math.PI) * 128 + 128,
                    0,
                    255)
                );

            DrawColorsToImg(stairImg, gR, gG, gB, gA);
            hasStairImg = true;
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

            R = closeMat.Mul(openMat, MC);
            G = highMat.Mul(lowMat, MC);
            B = volumeMat.Mul(dateMat, MC);
            A = closeMat.Mul(dateMat, MC).Mul(openMat, MC);

            // Default Img
            MakeStairImg(R, G, B, A);
        }
        public void InitHistoricalPage(string stockId, List<Stock> stocks)
        {
            this.Text = $"{stockId} 分析圖";
            Title.Text = $"{stockId} 分析圖";
            Info.Text = $"股票代碼: {stockId}, 資料筆數: {stocks.Count}, 僅供參考請勿迷信";
            InitCanvas(stocks);
        }
        public void InitRealTimePage(List<string> stockIds, List<Stock> stocks)
        {
            this.Text = $"即時多股分析圖";
            Title.Text = $"即時多股分析圖";
            Info.Text = $"股票代碼: {string.Join(" + ", stockIds)}{(stockIds.Count >= 4 ? "\n" : ", ")}資料筆數: {stocks.Count}, 僅供參考請勿迷信";
            InitCanvas(stocks);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (StairMode.Checked)
            {
                if (!hasStairImg)
                {
                    MakeStairImg(R, G, B, A);
                }
                canvas.Image = stairImg;
            }
            else
            {
                if (!hasNoiseImg)
                {
                    MakeNoiseImg(R, G, B, A);
                }
                canvas.Image = noiseImg;
            }
        }

        private void SaveImg_Click(object sender, EventArgs e)
        {
            if(StairMode.Checked)
            {
                if(!hasStairImg)
                {
                    MakeStairImg(R, G, B, A);
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                sfd.Title = "儲存生成結果";
                sfd.FileName = "VStock_Analysis_Stair_Image";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    stairImg.Save(sfd.FileName);
                }
            }
            else
            {
                if (!hasNoiseImg)
                {
                    MakeNoiseImg(R, G, B, A);
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                sfd.Title = "儲存生成結果";
                sfd.FileName = "VStock_Analysis_Noise_Image";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    noiseImg.Save(sfd.FileName);
                }
            }
        }
    }
}
