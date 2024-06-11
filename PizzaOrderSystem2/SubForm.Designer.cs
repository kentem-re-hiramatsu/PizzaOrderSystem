namespace sub
{
    partial class SubForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ToppingListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainMenuListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ToppingLabel = new System.Windows.Forms.Label();
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Enabled = false;
            this.OkButton.Location = new System.Drawing.Point(263, 427);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 40);
            this.OkButton.TabIndex = 11;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(157, 427);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 40);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "キャンセル";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ToppingListView
            // 
            this.ToppingListView.CheckBoxes = true;
            this.ToppingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.ToppingListView.HideSelection = false;
            this.ToppingListView.Location = new System.Drawing.Point(12, 201);
            this.ToppingListView.Name = "ToppingListView";
            this.ToppingListView.Size = new System.Drawing.Size(351, 220);
            this.ToppingListView.TabIndex = 9;
            this.ToppingListView.UseCompatibleStateImageBehavior = false;
            this.ToppingListView.View = System.Windows.Forms.View.Details;
            this.ToppingListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ToppingListView_ItemCheck);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "名称";
            this.columnHeader3.Width = 210;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "価格";
            this.columnHeader4.Width = 120;
            // 
            // MainMenuListView
            // 
            this.MainMenuListView.CheckBoxes = true;
            this.MainMenuListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MainMenuListView.HideSelection = false;
            this.MainMenuListView.Location = new System.Drawing.Point(12, 35);
            this.MainMenuListView.MultiSelect = false;
            this.MainMenuListView.Name = "MainMenuListView";
            this.MainMenuListView.Size = new System.Drawing.Size(351, 140);
            this.MainMenuListView.TabIndex = 8;
            this.MainMenuListView.UseCompatibleStateImageBehavior = false;
            this.MainMenuListView.View = System.Windows.Forms.View.Details;
            this.MainMenuListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.MainMenuListView_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 210;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "価格";
            this.columnHeader2.Width = 120;
            // 
            // ToppingLabel
            // 
            this.ToppingLabel.AutoSize = true;
            this.ToppingLabel.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.ToppingLabel.Location = new System.Drawing.Point(9, 184);
            this.ToppingLabel.Name = "ToppingLabel";
            this.ToppingLabel.Size = new System.Drawing.Size(56, 14);
            this.ToppingLabel.TabIndex = 7;
            this.ToppingLabel.Text = "トッピング";
            // 
            // MainMenuLabel
            // 
            this.MainMenuLabel.AutoSize = true;
            this.MainMenuLabel.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.MainMenuLabel.Location = new System.Drawing.Point(9, 8);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(77, 14);
            this.MainMenuLabel.TabIndex = 6;
            this.MainMenuLabel.Text = "メインメニュー";
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 497);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ToppingListView);
            this.Controls.Add(this.MainMenuListView);
            this.Controls.Add(this.ToppingLabel);
            this.Controls.Add(this.MainMenuLabel);
            this.Name = "SubForm";
            this.Text = "注文画面";
            this.Load += new System.EventHandler(this.SubForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ListView ToppingListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView MainMenuListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label ToppingLabel;
        private System.Windows.Forms.Label MainMenuLabel;
    }
}

