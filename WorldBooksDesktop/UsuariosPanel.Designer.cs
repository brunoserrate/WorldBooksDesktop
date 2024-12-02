namespace WorldBooksDesktop
{
    partial class UsuariosPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuariosPanel));
            this.usuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.incluirBtn = new System.Windows.Forms.ToolStripButton();
            this.editarBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.closeBtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.senhaTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.usuarioTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nomeTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.operacoesGroup = new System.Windows.Forms.GroupBox();
            this.operacaoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.operacoesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // usuariosDataGridView
            // 
            this.usuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuariosDataGridView.Location = new System.Drawing.Point(12, 229);
            this.usuariosDataGridView.Name = "usuariosDataGridView";
            this.usuariosDataGridView.Size = new System.Drawing.Size(776, 178);
            this.usuariosDataGridView.TabIndex = 0;
            this.usuariosDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.usuariosDataGridView_CellEnter);
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
            this.groupBox1.Controls.Add(this.senhaTxtBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.emailTxtBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.usuarioTxtBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nomeTxtBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.idTxtBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuário";
            // 
            // senhaTxtBox
            // 
            this.senhaTxtBox.Location = new System.Drawing.Point(444, 72);
            this.senhaTxtBox.Name = "senhaTxtBox";
            this.senhaTxtBox.PasswordChar = '*';
            this.senhaTxtBox.Size = new System.Drawing.Size(280, 20);
            this.senhaTxtBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Senha";
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(444, 46);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(280, 20);
            this.emailTxtBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email";
            // 
            // usuarioTxtBox
            // 
            this.usuarioTxtBox.Location = new System.Drawing.Point(63, 72);
            this.usuarioTxtBox.Name = "usuarioTxtBox";
            this.usuarioTxtBox.Size = new System.Drawing.Size(280, 20);
            this.usuarioTxtBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuário";
            // 
            // nomeTxtBox
            // 
            this.nomeTxtBox.Location = new System.Drawing.Point(63, 46);
            this.nomeTxtBox.Name = "nomeTxtBox";
            this.nomeTxtBox.Size = new System.Drawing.Size(280, 20);
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
            this.idTxtBox.Location = new System.Drawing.Point(63, 20);
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
            this.operacoesGroup.Location = new System.Drawing.Point(604, 182);
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
            // UsuariosPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(802, 421);
            this.Controls.Add(this.operacaoLabel);
            this.Controls.Add(this.operacoesGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.usuariosDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UsuariosPanel";
            this.Text = "World Books - Usuários";
            this.Load += new System.EventHandler(this.UsuariosPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.operacoesGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usuariosDataGridView;
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
        private System.Windows.Forms.TextBox senhaTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox usuarioTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox operacoesGroup;
        private System.Windows.Forms.Label operacaoLabel;
    }
}