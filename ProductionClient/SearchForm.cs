using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProductionClient
{
    public partial class SearchForm : Form
    {
        public string SearchType { get; set; } = "";
        public string Keyword { get; set; } = "";

        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboSearchType.SelectedItem == null)
            {
                MessageBox.Show("검색 조건을 선택해 주세요.");
                return;
            }

            string searchType = cboSearchType.SelectedItem.ToString();

            string keyword = txtSearchKeyword.Text;

            if (string.IsNullOrWhiteSpace(keyword)) 
            {
                MessageBox.Show("검색어를 입력해 주세요.");
                return;
            }

            if (searchType == "실적 ID")
            {
                searchType = "RESULT_ID";
            } 
            else if (searchType == "제품 코드") 
            {
                searchType = "PRODUCT_CODE";
            }
            else if (searchType == "제품 이름")
            {
                searchType = "PRODUCT_NAME";
            }
            else if (searchType == "생산 수량")
            {
                searchType = "QUANTITY";
            }
            else if (searchType == "상태")
            {
                searchType = "STATUS";
            }

            SearchType = searchType;
            Keyword = keyword;

            this.DialogResult = DialogResult.OK;
        }
    }
}
