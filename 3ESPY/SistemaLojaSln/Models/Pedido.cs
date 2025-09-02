using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;




namespace LojaSystem.Models
{
    
    [Index(["Id", "ClienteId"], IsUnique = true)]
    public class Pedido
    {
        
        // Navigation Property - Many-to-One
        public Cliente Cliente { get; set; }
        
        #region properties

        
        public int Id { get; set; }
        
        public DateTime DataPedido { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorTotal { get; set; }
        
        public string Status { get; set; } = "Pendente";
        
        // Foreign Key
        public int ClienteId { get; set; }
        
        
        
        // Navigation Property - One-to-Many
        public ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
        

        #endregion
    }
}