using LojaSystem.Data;
using LojaSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaSystem.Services
{
    public class PedidoService
    {
        private readonly LojaContext _context;

        public PedidoService(LojaContext context)
        {
            _context = context;
        }

        // Criar novo pedido com itens
        public async Task<Pedido> CriarPedido(int clienteId, List<(int produtoId, int quantidade)> itens)
        {
            var pedido = new Pedido
            {
                ClienteId = clienteId,
                DataPedido = DateTime.Now
            };

            decimal valorTotal = 0;

            foreach (var (produtoId, quantidade) in itens)
            {
                var produto = await _context.Produtos.FindAsync(produtoId);
                if (produto != null)
                {
                    var itemPedido = new ItemPedido
                    {
                        ProdutoId = produtoId,
                        Quantidade = quantidade,
                        PrecoUnitario = produto.Preco,
                        Subtotal = produto.Preco * quantidade
                    };

                    pedido.ItensPedido.Add(itemPedido);
                    valorTotal += itemPedido.Subtotal;
                }
            }

            pedido.ValorTotal = valorTotal;
            
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            
            return pedido;
        }

        // Buscar pedidos completos (com cliente e itens)
        public async Task<List<Pedido>> ListarPedidosCompletos()
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.ItensPedido)
                .ThenInclude(i => i.Produto)
                .ThenInclude(prod => prod.Categorias)
                .OrderByDescending(p => p.DataPedido)
                .ToListAsync();
        }

        // Buscar pedidos de um cliente específico
        public async Task<List<Pedido>> BuscarPedidosDoCliente(int clienteId)
        {
            return await _context.Pedidos
                .Include(p => p.ItensPedido)
                .ThenInclude(i => i.Produto)
                .Where(p => p.ClienteId == clienteId)
                .OrderByDescending(p => p.DataPedido)
                .ToListAsync();
        }
    }
}