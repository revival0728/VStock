namespace VStock
{
    public partial class HomePage : Form
    {
        Crawler crawler = new Crawler();

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
            SearchList.Items.Add(StockIdInput.Text.ToUpper());
        }

        private void SListDel_Click(object sender, EventArgs e)
        {
            if (SearchList.SelectedIndices.Count > 0)
            {
                SearchList.Items.RemoveAt(SearchList.SelectedIndices[0]);
            }
        }

        private void SearchTrad_Click(object sender, EventArgs e)
        {
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
                        "TDR",
                    }));
                }
            }
            else
            {
                HistoryView.Items.Add(new ListViewItem(new string[]
                {
                    nowTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    StockIdInput.Text.ToUpper(),
                    "TDH",
                }));
            }
        }

        private void SearchVStock_Click(object sender, EventArgs e)
        {
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
        }
    }
}
