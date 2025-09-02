using LojaSystem.Data;
using LojaSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaSystem.Services
{
    public class ProdutoService
    {
        private readonly LojaContext _context;

        public ProdutoService(LojaContext context)
        {
            _context = context;
        }

        // Listar todos os produtos COM categorias (Eager Loading)
        public async Task<List<Produto>> ListarProdutosComCategoria()
        {
            return await _context.Produtos
                .Include(p => p.Categorias)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        // Buscar produtos por categoria
        public async Task<List<Produto>> BuscarProdutosPorCategoria(int categoriaId)
        {
            return await _context.Produtos
                .Include(p => p.Categorias)
                .Where(p => p.Categorias.Any(c => c.Id == categoriaId))
                .ToListAsync();
        }

        // Adicionar novo produto
        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        // Buscar produtos em estoque baixo (menos de 10 unidades)
        public async Task<List<Produto>> ProdutosEstoqueBaixo()
        {
            return await _context.Produtos
                .Include(p => p.Categorias)
                .Where(p => p.EstoqueAtual < 10)
                .ToListAsync();
        }
    }
}