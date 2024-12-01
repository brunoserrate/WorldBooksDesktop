namespace WorldBooksDesktop
{
    partial class ViewSaleItemsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSaleItemsPanel));
            this.saleItensDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.saleItensDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // saleItensDataGridView
            // 
            this.saleItensDataGridView.AllowUserToAddRows = false;
            this.saleItensDataGridView.AllowUserToDeleteRows = false;
            this.saleItensDataGridView.AllowUserToOrderColumns = true;
            this.saleItensDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleItensDataGridView.Location = new System.Drawing.Point(12, 12);
            this.saleItensDataGridView.Name = "saleItensDataGridView";
            this.saleItensDataGridView.ReadOnly = true;
            this.saleItensDataGridView.Size = new System.Drawing.Size(776, 304);
            this.saleItensDataGridView.TabIndex = 0;
            // 
            // ViewSaleItemsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 331);
            this.Controls.Add(this.saleItensDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewSaleItemsPanel";
            this.Text = "World Books - Itens da venda";
            ((System.ComponentModel.ISupportInitialize)(this.saleItensDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView saleItensDataGridView;
    }
}