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
    public partial class FormUsuarios : Form
    {
        private string EndpointAPI = "https://localhost:7076/api/Usuarios";

        public FormUsuarios()
        {
            InitializeComponent();
            CarregarUsuarios();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int usuarioId = ExtrairIdUsuarioSelecionado();
                DeletarUsuario(usuarioId);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int usuarioId = ExtrairIdUsuarioSelecionado();
                EditarUsuarioPorId(usuarioId);
            }
        }

        private async void CarregarUsuarios()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(EndpointAPI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosJsonString = await response.Content.ReadAsStringAsync();
                        listBox1.DisplayMember = "Nome";
                        listBox1.DataSource = JsonConvert.DeserializeObject<Usuario[]>(usuariosJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter os usuários: " + response.StatusCode);
                    }
                }
            }
        }

        private int ExtrairIdUsuarioSelecionado()
        {

            try
            {
                string itemSelecionado = listBox1.GetItemText(listBox1.SelectedItem);

                if (listBox1.SelectedItem is Usuario selectedUsuario)
                {
                    return selectedUsuario.Id;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e) ;
            }

            return -1;
        }

        private async void EditarUsuarioPorId(int usuarioId)
        {
            string uriUsuario = $"{EndpointAPI}/{usuarioId}";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uriUsuario);

                if (response.IsSuccessStatusCode)
                {
                    var usuarioJsonString = await response.Content.ReadAsStringAsync();
                    Usuario usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJsonString);

                    var formEdicao = new FormEdicao(usuario);
                    formEdicao.Show();
                }
                else
                {
                    MessageBox.Show("Falha ao obter o usuário: " + response.StatusCode);
                }
            }
        }

        private async void DeletarUsuario(int usuarioId)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync($"{EndpointAPI}/{usuarioId}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuário excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o usuário: " + responseMessage.StatusCode);
                }
            }

            CarregarUsuarios();
        }
    }
}
