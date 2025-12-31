namespace VStock
{
    public partial class HomePage : Form
    {
        bool isSearching = false;
        Dictionary<string, Form> sPages = new();

        readonly string searchingString = "查詢中...";
        readonly string tradSString = "傳統查詢分析";
        readonly string vStockSString = "VStock 查詢分析";

        public HomePage()
        {
            InitializeComponent();
            StockIdInput.CharacterCasing = CharacterCasing.Upper;
        }

        private void SHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (SHistory.Checked)
            {
                DateFrom.Enabled = true;
                DateTo.Enabled = true;
            }
            else
            {
                DateFrom.Enabled = false;
                DateTo.Enabled = false;
            }
        }

        private void SListAdd_Click(object sender, EventArgs e)
        {
            if (SHistory.Checked)
            {
                MessageBox.Show("無法查詢分析多筆歷史資料");
                return;
            }
            string stockId = StockIdInput.Text.ToUpper();
            if (SearchList.Items.ContainsKey(stockId))
            {
                MessageBox.Show("清單中已存在此股票代碼");
                return;
            }
            SearchList.Items.Add(new ListViewItem(stockId) { Name = stockId });
        }

        private void SListDel_Click(object sender, EventArgs e)
        {
            if (SearchList.SelectedIndices.Count > 0)
            {
                SearchList.Items.RemoveAt(SearchList.SelectedIndices[0]);
            }
        }

        private async void SearchTrad_Click(object sender, EventArgs e)
        {
            if (isSearching)
            {
                MessageBox.Show("查詢中...");
                return;
            }
            isSearching = true;
            SearchTrad.Text = searchingString;
            var nowTime = DateTime.Now;
            string nowTimeStr = nowTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (SRealTime.Checked)
            {
                List<string> stockIds = new List<string>();
                for (int i = 0; i < SearchList.Items.Count; i++)
                {
                    var item = SearchList.Items[i];
                    string stockId = item.Text.ToUpper();
                    stockIds.Add(stockId);
                }
                if (stockIds.Count == 0)
                {

                    if (StockIdInput.Text == "")
                    {
                        MessageBox.Show("請輸入股票代碼");
                        return;
                    }
                    stockIds.Add(StockIdInput.Text.ToUpper());
                }
                try
                {
                    List<Stock> stocks = await Crawler.GetRealTime(stockIds);
                    TradSPage tradSPage = new();
                    tradSPage.InitRealTimePage(stockIds, stocks);
                    tradSPage.Show();
                    foreach (var stockId in stockIds)
                    {
                        HistoryView.Items.Add(new ListViewItem(new string[]
                        {
                            nowTimeStr,
                            stockId,
                            "TDR",
                        }));
                    }
                    sPages.Add(nowTimeStr, tradSPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"取得即時股價失敗: {ex.Message}");
                    SearchTrad.Text = tradSString;
                    isSearching = false;
                    return;
                }
            }
            else
            {
                if (StockIdInput.Text == "")
                {
                    MessageBox.Show("請輸入股票代碼");
                    return;
                }
                if (DateFrom.Value >= DateTo.Value)
                {
                    MessageBox.Show("結束日期必須大於開始日期");
                    return;
                }
                try
                {
                    string stockId = StockIdInput.Text.ToUpper();
                    List<Stock> stocks = await Crawler.GetHistorical(
                        stockId,
                        DateFrom.Value,
                        DateTo.Value);
                    if (stocks.Count == 0)
                    {
                        MessageBox.Show("時間區間內查無此股票資料");
                        return;
                    }
                    TradSPage tradSPage = new();
                    tradSPage.InitHistoricalPage(stockId, stocks);
                    tradSPage.Show();
                    HistoryView.Items.Add(new ListViewItem(new string[]
                    {
                        nowTimeStr,
                        stockId,
                        "TDH",
                    }));
                    sPages.Add(nowTimeStr, tradSPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"取得歷史股價失敗: {ex.Message}");
                    SearchTrad.Text = tradSString;
                    isSearching = false;
                    return;
                }
            }
            SearchTrad.Text = tradSString;
            isSearching = false;
        }

        private async void SearchVStock_Click(object sender, EventArgs e)
        {
            if (isSearching)
            {
                MessageBox.Show("查詢中...");
                return;
            }
            isSearching = true;
            SearchVStock.Text = searchingString;
            var nowTime = DateTime.Now;
            string nowTimeStr = nowTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (SRealTime.Checked)
            {
                List<string> stockIds = new List<string>();
                for (int i = 0; i < SearchList.Items.Count; i++)
                {
                    var item = SearchList.Items[i];
                    string stockId = item.Text.ToUpper();
                    stockIds.Add(stockId);
                }
                if (stockIds.Count == 0)
                {

                    if (StockIdInput.Text == "")
                    {
                        MessageBox.Show("請輸入股票代碼");
                        return;
                    }
                    stockIds.Add(StockIdInput.Text.ToUpper());
                }
                try
                {
                    List<Stock> stocks = await Crawler.GetRealTime(stockIds);
                    VStockSPage vStockSPage = new();
                    vStockSPage.InitRealTimePage(stockIds, stocks);
                    vStockSPage.Show();
                    foreach (var stockId in stockIds)
                    {
                        HistoryView.Items.Add(new ListViewItem(new string[]
                        {
                            nowTimeStr,
                            stockId,
                            "VSR",
                        }));
                    }
                    sPages.Add(nowTimeStr, vStockSPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"取得即時股價失敗: {ex.Message}");
                    SearchVStock.Text = vStockSString;
                    isSearching = false;
                    return;
                }
            }
            else
            {
                if (StockIdInput.Text == "")
                {
                    MessageBox.Show("請輸入股票代碼");
                    return;
                }
                if (DateFrom.Value >= DateTo.Value)
                {
                    MessageBox.Show("結束日期必須大於開始日期");
                    return;
                }
                try
                {
                    string stockId = StockIdInput.Text.ToUpper();
                    List<Stock> stocks = await Crawler.GetHistorical(
                        stockId,
                        DateFrom.Value,
                        DateTo.Value);
                    if (stocks.Count == 0)
                    {
                        MessageBox.Show("時間區間內查無此股票資料");
                        return;
                    }
                    VStockSPage vStockSPage = new();
                    vStockSPage.InitHistoricalPage(stockId, stocks);
                    vStockSPage.Show();
                    HistoryView.Items.Add(new ListViewItem(new string[]
                    {
                        nowTimeStr,
                        stockId,
                        "VSH",
                    }));
                    sPages.Add(nowTimeStr, vStockSPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"取得歷史股價失敗: {ex.Message}");
                    SearchVStock.Text = vStockSString;
                    isSearching = false;
                    return;
                }
            }
            SearchVStock.Text = vStockSString;
            isSearching = false;
        }

        private void HistoryView_DoubleClick(object sender, EventArgs e)
        {
            int index = HistoryView.SelectedIndices[0];
            string time = HistoryView.Items[index].SubItems[0].Text;
            sPages[time].Show();
        }

        private void StockIdInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(char.IsWhiteSpace(((char)e.KeyCode)))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
