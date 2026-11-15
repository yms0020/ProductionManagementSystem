namespace winforms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            grpProduction = new GroupBox();
            txtQuantity = new TextBox();
            txtProductName = new TextBox();
            txtProductCode = new TextBox();
            txtResultId = new TextBox();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            lblQuantity = new Label();
            lblProductName = new Label();
            lblProductCode = new Label();
            lblResultId = new Label();
            btnInsert = new Button();
            btnSelect = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvProduction = new DataGridView();
            grpProduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduction).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(387, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(392, 72);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "생산 실적 관리";
            lblTitle.Click += label1_Click;
            // 
            // grpProduction
            // 
            grpProduction.Controls.Add(txtQuantity);
            grpProduction.Controls.Add(txtProductName);
            grpProduction.Controls.Add(txtProductCode);
            grpProduction.Controls.Add(txtResultId);
            grpProduction.Controls.Add(cmbStatus);
            grpProduction.Controls.Add(lblStatus);
            grpProduction.Controls.Add(lblQuantity);
            grpProduction.Controls.Add(lblProductName);
            grpProduction.Controls.Add(lblProductCode);
            grpProduction.Controls.Add(lblResultId);
            grpProduction.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            grpProduction.Location = new Point(31, 119);
            grpProduction.Name = "grpProduction";
            grpProduction.Size = new Size(1156, 316);
            grpProduction.TabIndex = 1;
            grpProduction.TabStop = false;
            grpProduction.Text = "생산 실적 정보";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtQuantity.Location = new Point(687, 67);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(242, 47);
            txtQuantity.TabIndex = 18;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtProductName.Location = new Point(190, 211);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(242, 47);
            txtProductName.TabIndex = 17;
            // 
            // txtProductCode
            // 
            txtProductCode.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtProductCode.Location = new Point(190, 143);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(242, 47);
            txtProductCode.TabIndex = 16;
            // 
            // txtResultId
            // 
            txtResultId.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtResultId.Location = new Point(190, 72);
            txtResultId.Name = "txtResultId";
            txtResultId.ReadOnly = true;
            txtResultId.Size = new Size(242, 47);
            txtResultId.TabIndex = 15;
            txtResultId.TextChanged += txtResultId_TextChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "완료", "진행중", "불량" });
            cmbStatus.Location = new Point(687, 141);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(242, 48);
            cmbStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(538, 138);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 41);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "상태";
            lblStatus.Click += label5_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            lblQuantity.ForeColor = Color.Black;
            lblQuantity.Location = new Point(538, 72);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(149, 41);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "생산 수량";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            lblProductName.ForeColor = Color.Black;
            lblProductName.Location = new Point(27, 216);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(108, 41);
            lblProductName.TabIndex = 5;
            lblProductName.Text = "제품명";
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            lblProductCode.ForeColor = Color.Black;
            lblProductCode.Location = new Point(27, 141);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(149, 41);
            lblProductCode.TabIndex = 4;
            lblProductCode.Text = "제품 코드";
            // 
            // lblResultId
            // 
            lblResultId.AutoSize = true;
            lblResultId.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            lblResultId.ForeColor = Color.Black;
            lblResultId.Location = new Point(27, 72);
            lblResultId.Name = "lblResultId";
            lblResultId.Size = new Size(120, 41);
            lblResultId.TabIndex = 2;
            lblResultId.Text = "실적 ID";
            lblResultId.Click += label1_Click_1;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.SeaGreen;
            btnInsert.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(60, 482);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(179, 67);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "등록";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.RoyalBlue;
            btnSelect.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnSelect.ForeColor = Color.White;
            btnSelect.Location = new Point(350, 482);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(179, 67);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "조회";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Goldenrod;
            btnUpdate.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.MintCream;
            btnUpdate.Location = new Point(640, 482);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(179, 67);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "수정";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(930, 482);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(179, 67);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvProduction
            // 
            dgvProduction.AllowUserToAddRows = false;
            dgvProduction.AllowUserToDeleteRows = false;
            dgvProduction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduction.BackgroundColor = Color.White;
            dgvProduction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduction.Location = new Point(31, 584);
            dgvProduction.MultiSelect = false;
            dgvProduction.Name = "dgvProduction";
            dgvProduction.ReadOnly = true;
            dgvProduction.RowHeadersVisible = false;
            dgvProduction.RowHeadersWidth = 82;
            dgvProduction.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduction.Size = new Size(1156, 431);
            dgvProduction.TabIndex = 6;
            dgvProduction.CellClick += dgvProduction_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1218, 1076);
            Controls.Add(dgvProduction);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSelect);
            Controls.Add(btnInsert);
            Controls.Add(grpProduction);
            Controls.Add(lblTitle);
            Font = new Font("맑은 고딕", 10.875F, FontStyle.Bold, GraphicsUnit.Point, 129);
            ForeColor = Color.Navy;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "생산 실적 관리 시스템";
            Load += Form1_Load;
            grpProduction.ResumeLayout(false);
            grpProduction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduction).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpProduction;
        private Label lblProductCode;
        private Label lblResultId;
        private Label lblStatus;
        private Label lblQuantity;
        private Label lblProductName;
        private Button btnInsert;
        private Button btnSelect;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvProduction;
        private TextBox txtQuantity;
        private TextBox txtProductName;
        private TextBox txtProductCode;
        private TextBox txtResultId;
        private ComboBox cmbStatus;
    }
}
