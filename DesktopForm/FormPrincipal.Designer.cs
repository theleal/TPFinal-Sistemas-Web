namespace DesktopForm
{
    partial class FormPrincipal
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
            this.criarUsuario = new System.Windows.Forms.Button();
            this.gerenciarUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // criarUsuario
            // 
            this.criarUsuario.Location = new System.Drawing.Point(46, 32);
            this.criarUsuario.Name = "criarUsuario";
            this.criarUsuario.Size = new System.Drawing.Size(75, 23);
            this.criarUsuario.TabIndex = 0;
            this.criarUsuario.Text = "Criar Usuário";
            this.criarUsuario.UseVisualStyleBackColor = true;
            this.criarUsuario.Click += new System.EventHandler(this.criarUsuario_Click);
            // 
            // gerenciarUsuarios
            // 
            this.gerenciarUsuarios.Location = new System.Drawing.Point(162, 32);
            this.gerenciarUsuarios.Name = "gerenciarUsuarios";
            this.gerenciarUsuarios.Size = new System.Drawing.Size(130, 23);
            this.gerenciarUsuarios.TabIndex = 1;
            this.gerenciarUsuarios.Text = "Gerenciar Usuários";
            this.gerenciarUsuarios.UseVisualStyleBackColor = true;
            this.gerenciarUsuarios.Click += new System.EventHandler(this.gerenciarUsuarios_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 94);
            this.Controls.Add(this.gerenciarUsuarios);
            this.Controls.Add(this.criarUsuario);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar/Gerenciar Usuários";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button criarUsuario;
        private System.Windows.Forms.Button gerenciarUsuarios;
    }
}