namespace LinqAdvancedLab;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int CategoriaId { get; set; }
    public DateTime DataCriacao { get; set; }
    public int Estoque { get; set; }
    public bool Ativo { get; set; }
    public List<string> Tags { get; set; } = new List<string>();
}