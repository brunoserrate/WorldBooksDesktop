namespace WorldBooksDesktop
{
    partial class ProdutosPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdutosPanel));
            this.produtosDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.incluirBtn = new System.Windows.Forms.ToolStripButton();
            this.editarBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.closeBtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.qtdEstoqueNumeric = new System.Windows.Forms.NumericUpDown();
            this.precoNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.descricaoTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nomeTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.operacoesGroup = new System.Windows.Forms.GroupBox();
            this.operacaoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.produtosDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdEstoqueNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precoNumeric)).BeginInit();
            this.operacoesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // produtosDataGridView
            // 
            this.produtosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtosDataGridView.Location = new System.Drawing.Point(12, 392);
            this.produtosDataGridView.Name = "produtosDataGridView";
            this.produtosDataGridView.Size = new System.Drawing.Size(776, 178);
            this.produtosDataGridView.TabIndex = 0;
            this.produtosDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.produtosDataGridView_CellEnter);
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
            this.groupBox1.Controls.Add(this.qtdEstoqueNumeric);
            this.groupBox1.Controls.Add(this.precoNumeric);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.descricaoTxtBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nomeTxtBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.idTxtBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 283);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Livro";
            // 
            // qtdEstoqueNumeric
            // 
            this.qtdEstoqueNumeric.Location = new System.Drawing.Point(82, 234);
            this.qtdEstoqueNumeric.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.qtdEstoqueNumeric.Name = "qtdEstoqueNumeric";
            this.qtdEstoqueNumeric.Size = new System.Drawing.Size(146, 20);
            this.qtdEstoqueNumeric.TabIndex = 13;
            // 
            // precoNumeric
            // 
            this.precoNumeric.DecimalPlaces = 2;
            this.precoNumeric.Location = new System.Drawing.Point(82, 206);
            this.precoNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            131072});
            this.precoNumeric.Name = "precoNumeric";
            this.precoNumeric.Size = new System.Drawing.Size(146, 20);
            this.precoNumeric.TabIndex = 12;
            this.precoNumeric.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Descrição";
            // 
            // descricaoTxtBox
            // 
            this.descricaoTxtBox.Location = new System.Drawing.Point(82, 82);
            this.descricaoTxtBox.Multiline = true;
            this.descricaoTxtBox.Name = "descricaoTxtBox";
            this.descricaoTxtBox.Size = new System.Drawing.Size(684, 100);
            this.descricaoTxtBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Qtd. Estoque";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Preço";
            // 
            // nomeTxtBox
            // 
            this.nomeTxtBox.Location = new System.Drawing.Point(82, 46);
            this.nomeTxtBox.Name = "nomeTxtBox";
            this.nomeTxtBox.Size = new System.Drawing.Size(684, 20);
            this.nomeTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // idTxtBox
            // 
            this.idTxtBox.Enabled = false;
            this.idTxtBox.Location = new System.Drawing.Point(82, 20);
            this.idTxtBox.Name = "idTxtBox";
            this.idTxtBox.ReadOnly = true;
            this.idTxtBox.Size = new System.Drawing.Size(100, 20);
            this.idTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
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
            this.operacoesGroup.Location = new System.Drawing.Point(604, 345);
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
            // ProdutosPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(802, 587);
            this.Controls.Add(this.operacaoLabel);
            this.Controls.Add(this.operacoesGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.produtosDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProdutosPanel";
            this.Text = "World Books - Livros";
            this.Load += new System.EventHandler(this.ProdutosPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.produtosDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtdEstoqueNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precoNumeric)).EndInit();
            this.operacoesGroup.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox nomeTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox operacoesGroup;
        private System.Windows.Forms.Label operacaoLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox descricaoTxtBox;
        private System.Windows.Forms.NumericUpDown qtdEstoqueNumeric;
        private System.Windows.Forms.NumericUpDown precoNumeric;
    }
}