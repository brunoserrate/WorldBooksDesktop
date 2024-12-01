namespace WorldBooksDesktop
{
    partial class ViewSalesPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSalesPanel));
            this.vendasDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.closeBtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.visualizarItensBtn = new System.Windows.Forms.Button();
            this.vlrTotalTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtVendaTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usuarioTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clienteTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pesquisarBtn = new System.Windows.Forms.Button();
            this.dtFimPicker = new System.Windows.Forms.DateTimePicker();
            this.dtInicioPicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vendasDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // vendasDataGridView
            // 
            this.vendasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vendasDataGridView.Location = new System.Drawing.Point(12, 239);
            this.vendasDataGridView.Name = "vendasDataGridView";
            this.vendasDataGridView.Size = new System.Drawing.Size(776, 240);
            this.vendasDataGridView.TabIndex = 0;
            this.vendasDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vendasDataGridView_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            this.groupBox1.Controls.Add(this.visualizarItensBtn);
            this.groupBox1.Controls.Add(this.vlrTotalTxtBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtVendaTxtBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.usuarioTxtBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.clienteTxtBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.idTxtBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 142);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venda";
            // 
            // visualizarItensBtn
            // 
            this.visualizarItensBtn.Location = new System.Drawing.Point(371, 104);
            this.visualizarItensBtn.Name = "visualizarItensBtn";
            this.visualizarItensBtn.Size = new System.Drawing.Size(153, 23);
            this.visualizarItensBtn.TabIndex = 5;
            this.visualizarItensBtn.Text = "Visualizar produtos";
            this.visualizarItensBtn.UseVisualStyleBackColor = true;
            this.visualizarItensBtn.Click += new System.EventHandler(this.visualizarItensBtn_Click);
            // 
            // vlrTotalTxtBox
            // 
            this.vlrTotalTxtBox.Location = new System.Drawing.Point(249, 75);
            this.vlrTotalTxtBox.Name = "vlrTotalTxtBox";
            this.vlrTotalTxtBox.ReadOnly = true;
            this.vlrTotalTxtBox.Size = new System.Drawing.Size(116, 20);
            this.vlrTotalTxtBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vlr. Total";
            // 
            // dtVendaTxtBox
            // 
            this.dtVendaTxtBox.Location = new System.Drawing.Point(69, 75);
            this.dtVendaTxtBox.Name = "dtVendaTxtBox";
            this.dtVendaTxtBox.ReadOnly = true;
            this.dtVendaTxtBox.Size = new System.Drawing.Size(119, 20);
            this.dtVendaTxtBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dt. Venda";
            // 
            // usuarioTxtBox
            // 
            this.usuarioTxtBox.Location = new System.Drawing.Point(69, 106);
            this.usuarioTxtBox.Name = "usuarioTxtBox";
            this.usuarioTxtBox.ReadOnly = true;
            this.usuarioTxtBox.Size = new System.Drawing.Size(296, 20);
            this.usuarioTxtBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuário";
            // 
            // clienteTxtBox
            // 
            this.clienteTxtBox.Location = new System.Drawing.Point(69, 46);
            this.clienteTxtBox.Name = "clienteTxtBox";
            this.clienteTxtBox.ReadOnly = true;
            this.clienteTxtBox.Size = new System.Drawing.Size(296, 20);
            this.clienteTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente";
            // 
            // idTxtBox
            // 
            this.idTxtBox.Location = new System.Drawing.Point(69, 20);
            this.idTxtBox.Name = "idTxtBox";
            this.idTxtBox.ReadOnly = true;
            this.idTxtBox.Size = new System.Drawing.Size(77, 20);
            this.idTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pesquisarBtn);
            this.groupBox2.Controls.Add(this.dtFimPicker);
            this.groupBox2.Controls.Add(this.dtInicioPicker);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // pesquisarBtn
            // 
            this.pesquisarBtn.Location = new System.Drawing.Point(696, 18);
            this.pesquisarBtn.Name = "pesquisarBtn";
            this.pesquisarBtn.Size = new System.Drawing.Size(75, 23);
            this.pesquisarBtn.TabIndex = 4;
            this.pesquisarBtn.Text = "Pesquisar";
            this.pesquisarBtn.UseVisualStyleBackColor = true;
            this.pesquisarBtn.Click += new System.EventHandler(this.pesquisarBtn_Click);
            // 
            // dtFimPicker
            // 
            this.dtFimPicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtFimPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFimPicker.Location = new System.Drawing.Point(433, 19);
            this.dtFimPicker.Name = "dtFimPicker";
            this.dtFimPicker.Size = new System.Drawing.Size(200, 20);
            this.dtFimPicker.TabIndex = 3;
            // 
            // dtInicioPicker
            // 
            this.dtInicioPicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtInicioPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicioPicker.Location = new System.Drawing.Point(106, 19);
            this.dtInicioPicker.Name = "dtInicioPicker";
            this.dtInicioPicker.Size = new System.Drawing.Size(200, 20);
            this.dtInicioPicker.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(342, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Dt. Final Criação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Dt. Inicial Criação";
            // 
            // ViewSalesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(802, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.vendasDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewSalesPanel";
            this.Text = "World Books - Consultar Venda";
            this.Load += new System.EventHandler(this.ViewSalesPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendasDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView vendasDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton closeBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox idTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dtVendaTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usuarioTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clienteTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vlrTotalTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtFimPicker;
        private System.Windows.Forms.DateTimePicker dtInicioPicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button pesquisarBtn;
        private System.Windows.Forms.Button visualizarItensBtn;
    }
}