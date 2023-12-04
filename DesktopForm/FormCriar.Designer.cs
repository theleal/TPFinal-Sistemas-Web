namespace DesktopForm
{
    partial class FormCriar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            nomeTextBox = new TextBox();
            senhaTextBox = new TextBox();
            statusCheckBox = new CheckBox();
            criarUsuarioBtn = new Button();
            nomeLabel = new Label();
            senhaLabel = new Label();
            SuspendLayout();
            // 
            // nomeTextBox
            // 
            nomeTextBox.Location = new System.Drawing.Point(97, 63);
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new System.Drawing.Size(220, 22);
            nomeTextBox.TabIndex = 5;
            // 
            // senhaTextBox
            // 
            senhaTextBox.Location = new System.Drawing.Point(97, 114);
            senhaTextBox.Name = "senhaTextBox";
            senhaTextBox.Size = new System.Drawing.Size(220, 22);
            senhaTextBox.TabIndex = 4;
            // 
            // statusCheckBox
            // 
            statusCheckBox.Location = new System.Drawing.Point(97, 162);
            statusCheckBox.Name = "statusCheckBox";
            statusCheckBox.Size = new System.Drawing.Size(70, 21);
            statusCheckBox.TabIndex = 3;
            statusCheckBox.Text = "Status";
            // 
            // criarUsuarioBtn
            // 
            criarUsuarioBtn.Location = new System.Drawing.Point(101, 206);
            criarUsuarioBtn.Name = "criarUsuarioBtn";
            criarUsuarioBtn.Size = new System.Drawing.Size(150, 28);
            criarUsuarioBtn.TabIndex = 2;
            criarUsuarioBtn.Text = "Criar Usuário";
            criarUsuarioBtn.Click += new System.EventHandler(this.criarUsuarioBtn_Click);
            // 
            // nomeLabel
            // 
            nomeLabel.Location = new System.Drawing.Point(16, 66);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(75, 17);
            nomeLabel.TabIndex = 1;
            nomeLabel.Text = "Nome";
            // 
            // senhaLabel
            // 
            senhaLabel.Location = new System.Drawing.Point(16, 117);
            senhaLabel.Name = "senhaLabel";
            senhaLabel.Size = new System.Drawing.Size(75, 17);
            senhaLabel.TabIndex = 0;
            senhaLabel.Text = "Senha";
            // 
            // FormCriar
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(350, 300);
            Controls.Add(nomeLabel);
            Controls.Add(senhaLabel);
            Controls.Add(criarUsuarioBtn);
            Controls.Add(statusCheckBox);
            Controls.Add(senhaTextBox);
            Controls.Add(nomeTextBox);
            Name = "FormCriar";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Criar Usuário";
            Load += new System.EventHandler(this.FormCriar_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nomeTextBox;
        private TextBox senhaTextBox;
        private CheckBox statusCheckBox;
        private Button criarUsuarioBtn;
        private Label nomeLabel;
        private Label senhaLabel;
    }
}