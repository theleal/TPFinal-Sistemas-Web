using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoService produtosService;

        public ProdutoController(ProdutoService produtosService)
        {
            this.produtosService = produtosService;
        }
        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var produtos = await produtosService.GetAll();

            return View(produtos);
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var produto = await produtosService.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return View(produto);
        }

        // GET: Produto/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Usuarios"] = await produtosService.GetUsuariosSelectList();

            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,ID_UsuarioCriacao")] Produto produto)
        {
            var usuario = await produtosService.GetUsuarioById(produto.ID_UsuarioCriacao);
            produto.UsuarioCriacao = usuario;
            produto.UsuarioAlteracao = usuario;
            produto.ID_UsuarioAlteracao = produto.ID_UsuarioCriacao;


            ModelState.Remove("UsuarioCriacao");
            ModelState.Remove("UsuarioAlteracao");

            if (!ModelState.IsValid)
            {
                foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro de validação: {modelError.ErrorMessage}");
                }
                return BadRequest("Erro durante criação");
            }

            await produtosService.Create(produto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Usuarios"] = await produtosService.GetUsuariosSelectList();

            var produto = await produtosService.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
                return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Status,ID_UsuarioAlteracao")] Produto produto)
        {

            var produtoAntigo = await produtosService.GetById(produto.Id);
            produto.ID_UsuarioCriacao = produtoAntigo.ID_UsuarioCriacao;


            var usuarioCriacao = await produtosService.GetUsuarioById(produto.ID_UsuarioCriacao);
            var usuarioAlteracao = await produtosService.GetUsuarioById(produto.ID_UsuarioCriacao);

            produto.UsuarioCriacao = usuarioCriacao;
            produto.UsuarioAlteracao =  usuarioAlteracao;

            ModelState.Remove("UsuarioCriacao");
            ModelState.Remove("UsuarioAlteracao");

            if (ModelState.IsValid)
            {
                await produtosService.Update(produto.Id, produto);

                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Usuarios"] = await produtosService.GetUsuariosSelectList();

            var produto = await produtosService.GetById(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await produtosService.GetById(id);
            if (produto != null)
            {
                await produtosService.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();

        }

        private bool ProdutoExists(int id)
        {
            //return (produtosService.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
            return true;
        }

        public IActionResult Creditos()
        {
            return View();
        }
    }
}
