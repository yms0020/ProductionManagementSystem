namespace ProductionClient
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboSearchType = new ComboBox();
            txtSearchKeyword = new TextBox();
            btnSearch = new Button();
            btnCancel = new Button();
            lblSearchType = new Label();
            lblSearchKeyword = new Label();
            SuspendLayout();
            // 
            // cboSearchType
            // 
            cboSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchType.FormattingEnabled = true;
            cboSearchType.Items.AddRange(new object[] { "실적 ID", "제품 코드", "제품 이름", "생산 수량", "상태" });
            cboSearchType.Location = new Point(38, 103);
            cboSearchType.Name = "cboSearchType";
            cboSearchType.Size = new Size(214, 40);
            cboSearchType.TabIndex = 0;
            // 
            // txtSearchKeyword
            // 
            txtSearchKeyword.Location = new Point(268, 104);
            txtSearchKeyword.Name = "txtSearchKeyword";
            txtSearchKeyword.Size = new Size(509, 39);
            txtSearchKeyword.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(462, 222);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(627, 222);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSearchType
            // 
            lblSearchType.AutoSize = true;
            lblSearchType.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            lblSearchType.Location = new Point(38, 55);
            lblSearchType.Name = "lblSearchType";
            lblSearchType.Size = new Size(134, 37);
            lblSearchType.TabIndex = 4;
            lblSearchType.Text = "검색 조건";
            // 
            // lblSearchKeyword
            // 
            lblSearchKeyword.AutoSize = true;
            lblSearchKeyword.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            lblSearchKeyword.Location = new Point(268, 55);
            lblSearchKeyword.Name = "lblSearchKeyword";
            lblSearchKeyword.Size = new Size(98, 37);
            lblSearchKeyword.TabIndex = 5;
            lblSearchKeyword.Text = "검색어";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 308);
            Controls.Add(lblSearchKeyword);
            Controls.Add(lblSearchType);
            Controls.Add(btnCancel);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchKeyword);
            Controls.Add(cboSearchType);
            Name = "SearchForm";
            Text = "검색";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboSearchType;
        private TextBox txtSearchKeyword;
        private Button btnSearch;
        private Button btnCancel;
        private Label lblSearchType;
        private Label lblSearchKeyword;
    }
}