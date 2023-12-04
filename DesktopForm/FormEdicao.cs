using DesktopForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopForm
{
    public partial class FormEdicao : Form
    {


        private string EndpointAPI = "https://localhost:7076/api/Usuarios";
        private Usuario usuarioParaEdicao = null;

        public FormEdicao(Usuario usuario)
        {
            InitializeComponent();
            usuarioParaEdicao = usuario;
            txtNome.Text = usuario.Nome;
            txtSenha.Text = usuario.Senha;
            chkStatus.Checked = usuario.Status;
        }

        private async void EditarUsuarioPorId()
        {
            EndpointAPI = EndpointAPI + "/" + usuarioParaEdicao.Id.ToString();
            Usuario usuarioEditado = new Usuario();
            usuarioEditado.Id = usuarioParaEdicao.Id;
            usuarioEditado.Nome = txtNome.Text;
            usuarioEditado.Senha = txtSenha.Text;
            usuarioEditado.Status = chkStatus.Checked;

            using (var client = new HttpClient())
            {


                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(EndpointAPI, usuarioEditado);

                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuário atualizado com sucesso");
                    this.Close();
                    var formUsuarios = new FormUsuarios();
                    formUsuarios.Show();
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o usuário: " + responseMessage.StatusCode);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarUsuarioPorId();
        }
    }
}
