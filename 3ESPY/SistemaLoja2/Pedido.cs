namespace LinqAdvancedLab;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public decimal Total { get; set; }
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}