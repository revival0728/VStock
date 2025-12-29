namespace VStock
{
    public partial class HomePage : Form
    {
        TradSPage tradSPage = new TradSPage();

        readonly string searchingString = "查詢中...";
        readonly string tradSString = "傳統查詢分析";
        readonly string vStockSString = "VStock 查詢分析";

        public HomePage()
        {
            InitializeComponent();
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
            SearchTrad.Text = searchingString;
            var nowTime = DateTime.Now;
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
                
                    if(StockIdInput.Text == "")
                    {
                        MessageBox.Show("請輸入股票代碼");
                        return;
                    }
                    stockIds.Add(StockIdInput.Text.ToUpper());
                }
                try
                {
                    List<Stock> stocks = await Crawler.GetRealTime(stockIds);
                    tradSPage = new TradSPage();
                    tradSPage.InitRealTimePage(stockIds, stocks);
                    tradSPage.Show();
                    foreach (var stockId in stockIds)
                    {
                        HistoryView.Items.Add(new ListViewItem(new string[]
                        {
                            nowTime.ToString("yyyy-MM-dd HH:mm:ss"),
                            stockId,
                            "TDR",
                        }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"取得即時股價失敗: {ex.Message}");
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
                    tradSPage = new TradSPage();
                    tradSPage.InitHistoricalPage(stockId, stocks);
                    tradSPage.Show();
                    HistoryView.Items.Add(new ListViewItem(new string[]
                    {
                        nowTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        stockId,
                        "TDH",
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"取得歷史股價失敗: {ex.Message}");
                    return;
                }
            }
            SearchTrad.Text = tradSString;
        }

        private void SearchVStock_Click(object sender, EventArgs e)
        {
            SearchVStock.Text = searchingString;
            var nowTime = DateTime.Now;
            // TODO: Implement search functionality
            if (SRealTime.Checked)
            {
                for (int i = 0; i < SearchList.Items.Count; i++)
                {
                    var item = SearchList.Items[i];
                    HistoryView.Items.Add(new ListViewItem(new string[]
                    {
                        nowTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        item.Text,
                        "VSR",
                    }));
                }
            }
            else
            {
                HistoryView.Items.Add(new ListViewItem(new string[]
                {
                    nowTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    StockIdInput.Text.ToUpper(),
                    "VSH",
                }));
            }
            SearchVStock.Text = vStockSString;
        }
    }
}
