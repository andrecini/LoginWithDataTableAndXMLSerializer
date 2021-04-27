namespace frmLogin
{
    partial class frmLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRegister = new System.Windows.Forms.ToolStripButton();
            this.tsbForgot = new System.Windows.Forms.ToolStripButton();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSingIn = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRegister,
            this.tsbForgot});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(374, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRegister
            // 
            this.tsbRegister.Image = ((System.Drawing.Image)(resources.GetObject("tsbRegister.Image")));
            this.tsbRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegister.Name = "tsbRegister";
            this.tsbRegister.Size = new System.Drawing.Size(96, 24);
            this.tsbRegister.Text = "Cadastrar";
            this.tsbRegister.Click += new System.EventHandler(this.tsbRegister_Click);
            // 
            // tsbForgot
            // 
            this.tsbForgot.Image = ((System.Drawing.Image)(resources.GetObject("tsbForgot.Image")));
            this.tsbForgot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForgot.Name = "tsbForgot";
            this.tsbForgot.Size = new System.Drawing.Size(139, 24);
            this.tsbForgot.Text = "Esqueci a Senha";
            // 
            // picLogin
            // 
            this.picLogin.Location = new System.Drawing.Point(12, 40);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(100, 133);
            this.picLogin.TabIndex = 1;
            this.picLogin.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(131, 59);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(231, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(131, 113);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(231, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // btnSingIn
            // 
            this.btnSingIn.Location = new System.Drawing.Point(287, 150);
            this.btnSingIn.Name = "btnSingIn";
            this.btnSingIn.Size = new System.Drawing.Size(75, 23);
            this.btnSingIn.TabIndex = 6;
            this.btnSingIn.Text = "Entrar";
            this.btnSingIn.UseVisualStyleBackColor = true;
            this.btnSingIn.Click += new System.EventHandler(this.btnSingIn_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 187);
            this.Controls.Add(this.btnSingIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picLogin);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmLogin";
            this.Text = "LOGIN";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRegister;
        private System.Windows.Forms.ToolStripButton tsbForgot;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSingIn;
    }
}

