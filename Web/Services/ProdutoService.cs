using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;
using Web.Models;


//Luiz Gustavo e Rodrigo Rebelo
namespace Web.Services
{
    public class ProdutoService
    {
        private string baseUrl;
        private HttpClient client;
        public ProdutoService(string baseUrl, HttpClient client)
        {
            this.client = client;
            this.baseUrl = baseUrl;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/Api/Usuarios/{id}");

            var response = await client.SendAsync(request);

            var usuarioEncontrado = JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());

            return usuarioEncontrado;
        }

        public async Task<List<SelectListItem>> GetUsuariosSelectList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/Api/Usuarios");

            var response = await client.SendAsync(request);

            var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(await response.Content.ReadAsStringAsync());

            var selectList = usuarios.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Nome
            }).ToList();

            return selectList;
        }

        public async Task<List<Produto>> GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/Api/Produtos");

            var response = await client.SendAsync(request);

            var atividades = JsonConvert.DeserializeObject<List<Produto>>(await response.Content.ReadAsStringAsync());

            return atividades;

        }

        public async Task<Produto> GetById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/Api/Produtos/{id}");

            var response = await client.SendAsync(request);

            var atividade = JsonConvert.DeserializeObject<Produto>(await response.Content.ReadAsStringAsync());

            return atividade;
        }

        public async Task<bool> Create(Produto atividade)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/Api/Produtos");

            var content = JsonConvert.SerializeObject(atividade);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Update(int id, Produto atividade)
        {

            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/Api/Produtos/{id}");

            var content = JsonConvert.SerializeObject(atividade);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/Api/Produtos/{id}");

            var response = await client.SendAsync(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

    }
}
