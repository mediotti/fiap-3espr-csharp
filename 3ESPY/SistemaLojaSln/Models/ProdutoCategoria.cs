namespace LojaSystem.Models
{
    public class ProdutoCategoria
    {
        // Composite Key
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }
        
        // Navigation Properties
        public Produto Produto { get; set; } = null!;
        public Categoria Categoria { get; set; } = null!;
    }
}