using DesktopForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopForm
{
    public partial class FormCriar : Form
    {
        public FormCriar()
        {
            InitializeComponent();
        }

        private void criarUsuarioBtn_Click(object sender, EventArgs e)
        {
            AdicionarUsuario();
        }

        private async void AdicionarUsuario()
        {
            string uri = "https://localhost:7076/api/Usuarios";
            Usuario usuario = new Usuario
            {
                Nome = nomeTextBox.Text,
                Senha = senhaTextBox.Text,
                Status = statusCheckBox.Checked
            };

            using (var client = new HttpClient())
            {
                var serializedUsuario = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await client.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuário Criado");
                    Close();
                }
                else
                {
                    MessageBox.Show("Falha ao criar o usuário: " + responseMessage.StatusCode);
                }
            }
        }

        private void FormCriar_Load(object sender, EventArgs e)
        {

        }

    }
}
