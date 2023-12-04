using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos.Include(p => p.UsuarioAlteracao).Include(p => p.UsuarioCriacao).ToListAsync();
            return Ok(produtos);
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _context.Produtos
            .Include(p => p.UsuarioCriacao)
            .Include(p => p.UsuarioAlteracao)
            .FirstOrDefaultAsync(p => p.Id == id);

            //var usuarioCriacao = await _context.Usuarios.FindAsync(produto.ID_UsuarioCriacao);
            //produto.UsuarioCriacao = usuarioCriacao;

            //var usuarioAlteracao = await _context.Usuarios.FindAsync(produto.ID_UsuarioAlteracao);
            //produto.UsuarioAlteracao = usuarioAlteracao;

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID_Usuario, Produto produto)
        {
            var usuarioAlteracao = await _context.Usuarios.FindAsync(produto.ID_UsuarioAlteracao);
            var produtoAntigo = await _context.Produtos.FindAsync(produto.Id);

            if(produtoAntigo != null )
            {
                produtoAntigo.Preco = produto.Preco;
                produtoAntigo.Status = produto.Status;
                produtoAntigo.ID_UsuarioAlteracao = produto.ID_UsuarioAlteracao;
                produtoAntigo.Nome = produto.Nome;
                produtoAntigo.UsuarioAlteracao = usuarioAlteracao;

                await _context.SaveChangesAsync();
                return Ok(produtoAntigo);

            }

            return NotFound();

        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            // Aqui você deve verificar se o usuário tem permissão para criar um novo produto


            var usuario = await _context.Usuarios.FindAsync(produto.ID_UsuarioCriacao);

            produto.ID_UsuarioAlteracao = produto.ID_UsuarioCriacao;

            if (usuario != null)
            {

                produto.UsuarioCriacao = usuario;
                produto.UsuarioAlteracao = usuario;

                if (ModelState.IsValid)
                {
                    _context.Add(produto);
                        await _context.SaveChangesAsync();
                    return Ok(produto);
                }
            }

            return NotFound();
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
                var produto = await _context.Produtos.FindAsync(id);

                if(produto == null)
                {
                    return NotFound("Produto não encontrado");
                }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}