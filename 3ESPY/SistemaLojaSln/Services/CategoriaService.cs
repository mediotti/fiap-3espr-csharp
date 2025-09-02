using LojaSystem.Data;
using LojaSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaSystem.Services
{
    public class CategoriaService
    {
        private readonly LojaContext _context;

        public CategoriaService(LojaContext context)
        {
            _context = context;
        }

        // Listar todas as categorias COM produtos (Eager Loading)
        public async Task<List<Categoria>> ListarCategoriasComProdutos()
        {
            return await _context.Categorias
                .Include(c => c.Produtos)
                .ToListAsync();
        }

        // Buscar categoria específica com produtos
        public async Task<Categoria?> BuscarCategoriaComProdutos(int id)
        {
            return await _context.Categorias
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Adicionar nova categoria
        public async Task<Categoria> AdicionarCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}