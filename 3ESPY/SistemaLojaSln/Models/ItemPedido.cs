using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSystem.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        
        public int Quantidade { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoUnitario { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public decimal Subtotal { get; set; }
        
        // Foreign Keys
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        
        // Navigation Properties
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}