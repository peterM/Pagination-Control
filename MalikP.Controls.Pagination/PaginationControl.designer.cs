namespace MalikP.Controls.Pagination
{
    sealed partial class PaginationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.setPageCb = new System.Windows.Forms.ComboBox();
            this.lastPageBtn = new System.Windows.Forms.Button();
            this.firstPageBtn = new System.Windows.Forms.Button();
            this.recordsInfoLbl = new System.Windows.Forms.Label();
            this.totalRecordsInfoLbl = new System.Windows.Forms.Label();
            this.pagesInfolbl = new System.Windows.Forms.Label();
            this.currentAndTotalPagesInfoTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // prevBtn
            // 
            this.prevBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.prevBtn.BackColor = System.Drawing.SystemColors.Window;
            this.prevBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevBtn.Location = new System.Drawing.Point(35, 6);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(28, 23);
            this.prevBtn.TabIndex = 129;
            this.prevBtn.Text = "<<";
            this.prevBtn.UseVisualStyleBackColor = false;
            this.prevBtn.Click += new System.EventHandler(this.PrevPage);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nextBtn.BackColor = System.Drawing.SystemColors.Window;
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(139, 6);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(28, 23);
            this.nextBtn.TabIndex = 128;
            this.nextBtn.Text = ">>";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.NextPage);
            // 
            // setPageCb
            // 
            this.setPageCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.setPageCb.FormattingEnabled = true;
            this.setPageCb.Location = new System.Drawing.Point(67, 7);
            this.setPageCb.Name = "setPageCb";
            this.setPageCb.Size = new System.Drawing.Size(68, 21);
            this.setPageCb.TabIndex = 126;
            this.setPageCb.SelectedIndexChanged += new System.EventHandler(this.PageChangedByComboBox);
            // 
            // lastPageBtn
            // 
            this.lastPageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lastPageBtn.BackColor = System.Drawing.SystemColors.Window;
            this.lastPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastPageBtn.Location = new System.Drawing.Point(171, 6);
            this.lastPageBtn.Name = "lastPageBtn";
            this.lastPageBtn.Size = new System.Drawing.Size(28, 23);
            this.lastPageBtn.TabIndex = 130;
            this.lastPageBtn.Text = "> |";
            this.lastPageBtn.UseVisualStyleBackColor = false;
            this.lastPageBtn.Click += new System.EventHandler(this.LastPage);
            // 
            // firstPageBtn
            // 
            this.firstPageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.firstPageBtn.BackColor = System.Drawing.SystemColors.Window;
            this.firstPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstPageBtn.Location = new System.Drawing.Point(3, 6);
            this.firstPageBtn.Name = "firstPageBtn";
            this.firstPageBtn.Size = new System.Drawing.Size(28, 23);
            this.firstPageBtn.TabIndex = 131;
            this.firstPageBtn.Text = "| <";
            this.firstPageBtn.UseVisualStyleBackColor = false;
            this.firstPageBtn.Click += new System.EventHandler(this.FirstPage);
            // 
            // recordsInfoLbl
            // 
            this.recordsInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsInfoLbl.Location = new System.Drawing.Point(217, 11);
            this.recordsInfoLbl.Name = "recordsInfoLbl";
            this.recordsInfoLbl.Size = new System.Drawing.Size(50, 13);
            this.recordsInfoLbl.TabIndex = 135;
            this.recordsInfoLbl.Text = "Records:";
            // 
            // totalRecordsInfoLbl
            // 
            this.totalRecordsInfoLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalRecordsInfoLbl.AutoSize = true;
            this.totalRecordsInfoLbl.Location = new System.Drawing.Point(269, 11);
            this.totalRecordsInfoLbl.Name = "totalRecordsInfoLbl";
            this.totalRecordsInfoLbl.Size = new System.Drawing.Size(14, 13);
            this.totalRecordsInfoLbl.TabIndex = 136;
            this.totalRecordsInfoLbl.Text = "#";
            // 
            // pagesInfolbl
            // 
            this.pagesInfolbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pagesInfolbl.Location = new System.Drawing.Point(312, 10);
            this.pagesInfolbl.Name = "pagesInfolbl";
            this.pagesInfolbl.Size = new System.Drawing.Size(40, 13);
            this.pagesInfolbl.TabIndex = 138;
            this.pagesInfolbl.Text = "Pages:";
            // 
            // currentAndTotalPagesInfoTb
            // 
            this.currentAndTotalPagesInfoTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentAndTotalPagesInfoTb.Enabled = false;
            this.currentAndTotalPagesInfoTb.Location = new System.Drawing.Point(355, 7);
            this.currentAndTotalPagesInfoTb.Name = "currentAndTotalPagesInfoTb";
            this.currentAndTotalPagesInfoTb.ReadOnly = true;
            this.currentAndTotalPagesInfoTb.Size = new System.Drawing.Size(68, 20);
            this.currentAndTotalPagesInfoTb.TabIndex = 137;
            this.currentAndTotalPagesInfoTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PaginationControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pagesInfolbl);
            this.Controls.Add(this.currentAndTotalPagesInfoTb);
            this.Controls.Add(this.totalRecordsInfoLbl);
            this.Controls.Add(this.recordsInfoLbl);
            this.Controls.Add(this.firstPageBtn);
            this.Controls.Add(this.lastPageBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.setPageCb);
            this.MinimumSize = new System.Drawing.Size(425, 35);
            this.Name = "PaginationControl";
            this.Size = new System.Drawing.Size(425, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.ComboBox setPageCb;
        private System.Windows.Forms.Button lastPageBtn;
        private System.Windows.Forms.Button firstPageBtn;
        private System.Windows.Forms.Label recordsInfoLbl;
        private System.Windows.Forms.Label totalRecordsInfoLbl;
        private System.Windows.Forms.Label pagesInfolbl;
        private System.Windows.Forms.TextBox currentAndTotalPagesInfoTb;

    }
}
