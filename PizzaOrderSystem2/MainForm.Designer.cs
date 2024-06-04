namespace PizzaOrderSystem2
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.DetailsListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrderListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalAmountLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DetailsLabel = new System.Windows.Forms.Label();
            this.OrderListLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.Changebutton = new System.Windows.Forms.Button();
            this.OrderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DetailsListView
            // 
            this.DetailsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.DetailsListView.HideSelection = false;
            this.DetailsListView.Location = new System.Drawing.Point(359, 110);
            this.DetailsListView.Name = "DetailsListView";
            this.DetailsListView.Size = new System.Drawing.Size(302, 230);
            this.DetailsListView.TabIndex = 17;
            this.DetailsListView.UseCompatibleStateImageBehavior = false;
            this.DetailsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "名称";
            this.columnHeader3.Width = 187;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "値段";
            this.columnHeader4.Width = 90;
            // 
            // OrderListView
            // 
            this.OrderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.OrderListView.HideSelection = false;
            this.OrderListView.Location = new System.Drawing.Point(13, 110);
            this.OrderListView.Name = "OrderListView";
            this.OrderListView.Size = new System.Drawing.Size(340, 230);
            this.OrderListView.TabIndex = 16;
            this.OrderListView.UseCompatibleStateImageBehavior = false;
            this.OrderListView.View = System.Windows.Forms.View.Details;
            this.OrderListView.SelectedIndexChanged += new System.EventHandler(this.OrderListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 214;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "小計";
            this.columnHeader2.Width = 90;
            // 
            // TotalAmountLabel
            // 
            this.TotalAmountLabel.AutoSize = true;
            this.TotalAmountLabel.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.TotalAmountLabel.Location = new System.Drawing.Point(558, 374);
            this.TotalAmountLabel.Name = "TotalAmountLabel";
            this.TotalAmountLabel.Size = new System.Drawing.Size(42, 14);
            this.TotalAmountLabel.TabIndex = 15;
            this.TotalAmountLabel.Text = "合計：";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(561, 391);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 30);
            this.CloseButton.TabIndex = 14;
            this.CloseButton.Text = "閉じる";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DetailsLabel
            // 
            this.DetailsLabel.AutoSize = true;
            this.DetailsLabel.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.DetailsLabel.Location = new System.Drawing.Point(356, 93);
            this.DetailsLabel.Name = "DetailsLabel";
            this.DetailsLabel.Size = new System.Drawing.Size(35, 14);
            this.DetailsLabel.TabIndex = 13;
            this.DetailsLabel.Text = "詳細";
            // 
            // OrderListLabel
            // 
            this.OrderListLabel.AutoSize = true;
            this.OrderListLabel.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.OrderListLabel.Location = new System.Drawing.Point(13, 93);
            this.OrderListLabel.Name = "OrderListLabel";
            this.OrderListLabel.Size = new System.Drawing.Size(64, 14);
            this.OrderListLabel.TabIndex = 12;
            this.OrderListLabel.Text = "注文リスト";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(225, 26);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 40);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "取消";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Changebutton
            // 
            this.Changebutton.Enabled = false;
            this.Changebutton.Location = new System.Drawing.Point(119, 26);
            this.Changebutton.Name = "Changebutton";
            this.Changebutton.Size = new System.Drawing.Size(100, 40);
            this.Changebutton.TabIndex = 10;
            this.Changebutton.Text = "変更";
            this.Changebutton.UseVisualStyleBackColor = true;
            // 
            // OrderButton
            // 
            this.OrderButton.Location = new System.Drawing.Point(13, 26);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(100, 40);
            this.OrderButton.TabIndex = 9;
            this.OrderButton.Text = "注文";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 450);
            this.Controls.Add(this.DetailsListView);
            this.Controls.Add(this.OrderListView);
            this.Controls.Add(this.TotalAmountLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DetailsLabel);
            this.Controls.Add(this.OrderListLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.Changebutton);
            this.Controls.Add(this.OrderButton);
            this.Name = "MainForm";
            this.Text = "ピザ注文リスト";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DetailsListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView OrderListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label TotalAmountLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label DetailsLabel;
        private System.Windows.Forms.Label OrderListLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button Changebutton;
        private System.Windows.Forms.Button OrderButton;
    }
}

