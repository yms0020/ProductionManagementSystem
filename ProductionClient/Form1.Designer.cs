namespace ProductionClient
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
            grpProductionList = new GroupBox();
            dgvProduction = new DataGridView();
            grpProductionDetail = new GroupBox();
            cmbStatus = new ComboBox();
            txtQuantity = new TextBox();
            txtProductName = new TextBox();
            txtProductCode = new TextBox();
            txtResultId = new TextBox();
            lblStatus = new Label();
            lblQuantity = new Label();
            lblProductName = new Label();
            lblProductCode = new Label();
            lblResultId = new Label();
            btnSelect = new Button();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            grpProductionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduction).BeginInit();
            grpProductionDetail.SuspendLayout();
            SuspendLayout();
            // 
            // grpProductionList
            // 
            grpProductionList.Controls.Add(dgvProduction);
            grpProductionList.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            grpProductionList.Location = new Point(52, 54);
            grpProductionList.Name = "grpProductionList";
            grpProductionList.Size = new Size(796, 632);
            grpProductionList.TabIndex = 0;
            grpProductionList.TabStop = false;
            grpProductionList.Text = "생산 실적 목록";
            grpProductionList.Enter += groupBox1_Enter;
            // 
            // dgvProduction
            // 
            dgvProduction.BackgroundColor = SystemColors.ControlLight;
            dgvProduction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduction.Location = new Point(10, 53);
            dgvProduction.Name = "dgvProduction";
            dgvProduction.RowHeadersWidth = 82;
            dgvProduction.Size = new Size(776, 543);
            dgvProduction.TabIndex = 0;
            dgvProduction.CellClick += dgvProduction_CellClick;
            // 
            // grpProductionDetail
            // 
            grpProductionDetail.Controls.Add(cmbStatus);
            grpProductionDetail.Controls.Add(txtQuantity);
            grpProductionDetail.Controls.Add(txtProductName);
            grpProductionDetail.Controls.Add(txtProductCode);
            grpProductionDetail.Controls.Add(txtResultId);
            grpProductionDetail.Controls.Add(lblStatus);
            grpProductionDetail.Controls.Add(lblQuantity);
            grpProductionDetail.Controls.Add(lblProductName);
            grpProductionDetail.Controls.Add(lblProductCode);
            grpProductionDetail.Controls.Add(lblResultId);
            grpProductionDetail.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            grpProductionDetail.Location = new Point(854, 54);
            grpProductionDetail.Name = "grpProductionDetail";
            grpProductionDetail.Size = new Size(459, 632);
            grpProductionDetail.TabIndex = 1;
            grpProductionDetail.TabStop = false;
            grpProductionDetail.Text = "실적 상세 정보";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "완료", "진행중", "불량" });
            cmbStatus.Location = new Point(180, 465);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(242, 55);
            cmbStatus.TabIndex = 10;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(180, 362);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(242, 54);
            txtQuantity.TabIndex = 9;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(180, 259);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(242, 54);
            txtProductName.TabIndex = 8;
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(180, 156);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(242, 54);
            txtProductCode.TabIndex = 7;
            // 
            // txtResultId
            // 
            txtResultId.BackColor = SystemColors.Window;
            txtResultId.Location = new Point(180, 53);
            txtResultId.Name = "txtResultId";
            txtResultId.ReadOnly = true;
            txtResultId.Size = new Size(242, 54);
            txtResultId.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            lblStatus.Location = new Point(25, 465);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(71, 37);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "상태";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            lblQuantity.Location = new Point(25, 362);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(134, 37);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "생산 수량";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            lblProductName.Location = new Point(25, 259);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(98, 37);
            lblProductName.TabIndex = 4;
            lblProductName.Text = "제품명";
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            lblProductCode.Location = new Point(25, 156);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(134, 37);
            lblProductCode.TabIndex = 3;
            lblProductCode.Text = "제품 코드";
            // 
            // lblResultId
            // 
            lblResultId.AutoSize = true;
            lblResultId.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblResultId.Location = new Point(25, 53);
            lblResultId.Name = "lblResultId";
            lblResultId.Size = new Size(108, 37);
            lblResultId.TabIndex = 2;
            lblResultId.Text = "실적 ID";
            // 
            // btnSelect
            // 
            btnSelect.BackColor = SystemColors.Highlight;
            btnSelect.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSelect.ForeColor = SystemColors.Window;
            btnSelect.Location = new Point(222, 728);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(170, 65);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "조회";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.Green;
            btnInsert.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            btnInsert.ForeColor = SystemColors.Window;
            btnInsert.Location = new Point(409, 728);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(170, 65);
            btnInsert.TabIndex = 3;
            btnInsert.Text = "등록";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 128, 0);
            btnUpdate.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            btnUpdate.ForeColor = SystemColors.Window;
            btnUpdate.Location = new Point(596, 728);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(170, 65);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "수정";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            btnDelete.ForeColor = SystemColors.Window;
            btnDelete.Location = new Point(783, 728);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(170, 65);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.AppWorkspace;
            btnClear.Font = new Font("맑은 고딕", 10.125F, FontStyle.Bold);
            btnClear.ForeColor = SystemColors.Window;
            btnClear.Location = new Point(970, 728);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(170, 65);
            btnClear.TabIndex = 6;
            btnClear.Text = "초기화";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1363, 859);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(btnSelect);
            Controls.Add(grpProductionDetail);
            Controls.Add(grpProductionList);
            Name = "Form1";
            Text = "생산 실적 관리 시스템";
            Load += Form1_Load;
            grpProductionList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProduction).EndInit();
            grpProductionDetail.ResumeLayout(false);
            grpProductionDetail.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpProductionList;
        private GroupBox grpProductionDetail;
        private Label lblStatus;
        private Label lblQuantity;
        private Label lblProductName;
        private Label lblProductCode;
        private Label lblResultId;
        private ComboBox cmbStatus;
        private TextBox txtQuantity;
        private TextBox txtProductName;
        private TextBox txtProductCode;
        private TextBox txtResultId;
        private DataGridView dgvProduction;
        private Button btnSelect;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}
