namespace DesktopForm
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void criarUsuario_Click(object sender, EventArgs e)
        {
            var formCriarUsuario = new FormCriar();
            formCriarUsuario.Show();
        }

        private void gerenciarUsuarios_Click(object sender, EventArgs e)
        {
            var formUsuarios = new FormUsuarios();
            formUsuarios.Show();
        }
    }
}