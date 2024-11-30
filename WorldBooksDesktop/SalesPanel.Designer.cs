namespace WorldBooksDesktop
{
    partial class SalesPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesPanel));
            this.produtosDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.incluirBtn = new System.Windows.Forms.ToolStripButton();
            this.editarBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.closeBtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.indiceLbl = new System.Windows.Forms.Label();
            this.indiceTxtBox = new System.Windows.Forms.TextBox();
            this.qtdNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.clientesCombox = new System.Windows.Forms.ComboBox();
            this.produtosCombox = new System.Windows.Forms.ComboBox();
            this.descontoNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.operacoesGroup = new System.Windows.Forms.GroupBox();
            this.operacaoLabel = new System.Windows.Forms.Label();
            this.salvarVendaGroupBox = new System.Windows.Forms.GroupBox();
            this.salvarVendaBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.produtosDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descontoNumeric)).BeginInit();
            this.operacoesGroup.SuspendLayout();
            this.salvarVendaGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // produtosDataGridView
            // 
            this.produtosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtosDataGridView.Location = new System.Drawing.Point(12, 281);
            this.produtosDataGridView.Name = "produtosDataGridView";
            this.produtosDataGridView.Size = new System.Drawing.Size(776, 198);
            this.produtosDataGridView.TabIndex = 0;
            this.produtosDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.salesItemDataGridView_CellEnter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incluirBtn,
            this.editarBtn,
            this.deleteBtn,
            this.closeBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // incluirBtn
            // 
            this.incluirBtn.Image = ((System.Drawing.Image)(resources.GetObject("incluirBtn.Image")));
            this.incluirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.incluirBtn.Name = "incluirBtn";
            this.incluirBtn.Size = new System.Drawing.Size(60, 22);
            this.incluirBtn.Text = "Incluir";
            this.incluirBtn.Click += new System.EventHandler(this.incluirBtn_Click);
            // 
            // editarBtn
            // 
            this.editarBtn.Image = ((System.Drawing.Image)(resources.GetObject("editarBtn.Image")));
            this.editarBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editarBtn.Name = "editarBtn";
            this.editarBtn.Size = new System.Drawing.Size(57, 22);
            this.editarBtn.Text = "Editar";
            this.editarBtn.Click += new System.EventHandler(this.editarBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(64, 22);
            this.deleteBtn.Text = "Deletar";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(62, 22);
            this.closeBtn.Text = "Fechar";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.indiceLbl);
            this.groupBox1.Controls.Add(this.indiceTxtBox);
            this.groupBox1.Controls.Add(this.qtdNumeric);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clientesCombox);
            this.groupBox1.Controls.Add(this.produtosCombox);
            this.groupBox1.Controls.Add(this.descontoNumeric);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 131);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venda";
            // 
            // indiceLbl
            // 
            this.indiceLbl.AutoSize = true;
            this.indiceLbl.Location = new System.Drawing.Point(10, 22);
            this.indiceLbl.Name = "indiceLbl";
            this.indiceLbl.Size = new System.Drawing.Size(36, 13);
            this.indiceLbl.TabIndex = 13;
            this.indiceLbl.Text = "Indice";
            // 
            // indiceTxtBox
            // 
            this.indiceTxtBox.Location = new System.Drawing.Point(69, 20);
            this.indiceTxtBox.Name = "indiceTxtBox";
            this.indiceTxtBox.ReadOnly = true;
            this.indiceTxtBox.Size = new System.Drawing.Size(37, 20);
            this.indiceTxtBox.TabIndex = 12;
            // 
            // qtdNumeric
            // 
            this.qtdNumeric.Location = new System.Drawing.Point(69, 73);
            this.qtdNumeric.Name = "qtdNumeric";
            this.qtdNumeric.Size = new System.Drawing.Size(120, 20);
            this.qtdNumeric.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Qtd.";
            // 
            // clientesCombox
            // 
            this.clientesCombox.FormattingEnabled = true;
            this.clientesCombox.Location = new System.Drawing.Point(190, 19);
            this.clientesCombox.Name = "clientesCombox";
            this.clientesCombox.Size = new System.Drawing.Size(375, 21);
            this.clientesCombox.TabIndex = 9;
            this.clientesCombox.SelectedIndexChanged += new System.EventHandler(this.clientesCombox_SelectedIndexChanged);
            // 
            // produtosCombox
            // 
            this.produtosCombox.FormattingEnabled = true;
            this.produtosCombox.Location = new System.Drawing.Point(69, 45);
            this.produtosCombox.Name = "produtosCombox";
            this.produtosCombox.Size = new System.Drawing.Size(496, 21);
            this.produtosCombox.TabIndex = 8;
            // 
            // descontoNumeric
            // 
            this.descontoNumeric.DecimalPlaces = 2;
            this.descontoNumeric.Location = new System.Drawing.Point(69, 99);
            this.descontoNumeric.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.descontoNumeric.Name = "descontoNumeric";
            this.descontoNumeric.Size = new System.Drawing.Size(120, 20);
            this.descontoNumeric.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Desconto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Produto";
            // 
            // confirmBtn
            // 
            this.confirmBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.confirmBtn.Location = new System.Drawing.Point(100, 12);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 3;
            this.confirmBtn.Text = "Confirmar";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.cancelarBtn.Location = new System.Drawing.Point(19, 12);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarBtn.TabIndex = 4;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // operacoesGroup
            // 
            this.operacoesGroup.Controls.Add(this.cancelarBtn);
            this.operacoesGroup.Controls.Add(this.confirmBtn);
            this.operacoesGroup.Location = new System.Drawing.Point(606, 193);
            this.operacoesGroup.Name = "operacoesGroup";
            this.operacoesGroup.Size = new System.Drawing.Size(184, 41);
            this.operacoesGroup.TabIndex = 5;
            this.operacoesGroup.TabStop = false;
            this.operacoesGroup.Visible = false;
            // 
            // operacaoLabel
            // 
            this.operacaoLabel.BackColor = System.Drawing.Color.LightGreen;
            this.operacaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operacaoLabel.Location = new System.Drawing.Point(658, 25);
            this.operacaoLabel.Name = "operacaoLabel";
            this.operacaoLabel.Size = new System.Drawing.Size(132, 28);
            this.operacaoLabel.TabIndex = 6;
            this.operacaoLabel.Text = "Consulta";
            this.operacaoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salvarVendaGroupBox
            // 
            this.salvarVendaGroupBox.Controls.Add(this.salvarVendaBtn);
            this.salvarVendaGroupBox.Location = new System.Drawing.Point(606, 234);
            this.salvarVendaGroupBox.Name = "salvarVendaGroupBox";
            this.salvarVendaGroupBox.Size = new System.Drawing.Size(184, 41);
            this.salvarVendaGroupBox.TabIndex = 6;
            this.salvarVendaGroupBox.TabStop = false;
            this.salvarVendaGroupBox.Visible = false;
            // 
            // salvarVendaBtn
            // 
            this.salvarVendaBtn.ForeColor = System.Drawing.Color.ForestGreen;
            this.salvarVendaBtn.Location = new System.Drawing.Point(19, 12);
            this.salvarVendaBtn.Name = "salvarVendaBtn";
            this.salvarVendaBtn.Size = new System.Drawing.Size(156, 23);
            this.salvarVendaBtn.TabIndex = 3;
            this.salvarVendaBtn.Text = "Salvar Venda";
            this.salvarVendaBtn.UseVisualStyleBackColor = true;
            this.salvarVendaBtn.Click += new System.EventHandler(this.salvarVendaBtn_Click);
            // 
            // SalesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(802, 491);
            this.Controls.Add(this.salvarVendaGroupBox);
            this.Controls.Add(this.operacaoLabel);
            this.Controls.Add(this.operacoesGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.produtosDataGridView);
            this.Name = "SalesPanel";
            this.Text = "World Books - Registrar Venda";
            this.Load += new System.EventHandler(this.SalesPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.produtosDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descontoNumeric)).EndInit();
            this.operacoesGroup.ResumeLayout(false);
            this.salvarVendaGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView produtosDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton incluirBtn;
        private System.Windows.Forms.ToolStripButton editarBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripButton closeBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox operacoesGroup;
        private System.Windows.Forms.Label operacaoLabel;
        private System.Windows.Forms.ComboBox clientesCombox;
        private System.Windows.Forms.ComboBox produtosCombox;
        private System.Windows.Forms.NumericUpDown descontoNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown qtdNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox salvarVendaGroupBox;
        private System.Windows.Forms.Button salvarVendaBtn;
        private System.Windows.Forms.TextBox indiceTxtBox;
        private System.Windows.Forms.Label indiceLbl;
    }
}