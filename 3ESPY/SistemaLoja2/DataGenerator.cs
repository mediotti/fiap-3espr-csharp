namespace LinqAdvancedLab;

public static class DataGenerator
{
    private static readonly Random random = new Random(42);
    private static readonly string[] nomesProdutos = {
        "Smartphone", "Laptop", "Mouse", "Teclado", "Monitor", "Tablet", 
        "Fone de Ouvido", "Webcam", "Impressora", "Scanner", "Roteador", "SSD"
    };
    private static readonly string[] nomesCategoria = {
        "Eletrônicos", "Informática", "Periféricos", "Audio & Video"
    };
    private static readonly string[] tags = {
        "novo", "promoção", "importado", "nacional", "premium", "básico", "wireless", "bluetooth"
    };

    public static List<Categoria> GerarCategorias()
    {
        return nomesCategoria.Select((nome, index) => new Categoria
        {
            Id = index + 1,
            Nome = nome,
            MargemLucro = (decimal)(random.NextDouble() * 0.5 + 0.1) // 10-60%
        }).ToList();
    }

    public static List<Produto> GerarProdutos(int quantidade)
    {
        return Enumerable.Range(1, quantidade)
            .Select(i => new Produto
            {
                Id = i,
                Nome = $"{nomesProdutos[random.Next(nomesProdutos.Length)]} {i}",
                Preco = (decimal)(random.NextDouble() * 2000 + 50), // 50-2050
                CategoriaId = random.Next(1, 5),
                DataCriacao = DateTime.Now.AddDays(-random.Next(365)),
                Estoque = random.Next(0, 100),
                Ativo = random.NextDouble() > 0.1, // 90% ativos
                Tags = tags.OrderBy(x => random.Next()).Take(random.Next(1, 4)).ToList()
            }).ToList();
    }

    public static List<Pedido> GerarPedidos(List<Produto> produtos, int quantidade)
    {
        return Enumerable.Range(1, quantidade)
            .Select(i => {
                var itens = produtos
                    .OrderBy(x => random.Next())
                    .Take(random.Next(1, 6))
                    .Select(p => new ItemPedido
                    {
                        ProdutoId = p.Id,
                        Quantidade = random.Next(1, 5),
                        PrecoUnitario = p.Preco * (decimal)(0.9 + random.NextDouble() * 0.2) // ±10% variação
                    }).ToList();
                    
                return new Pedido
                {
                    Id = i,
                    Data = DateTime.Now.AddDays(-random.Next(90)),
                    Itens = itens,
                    Total = itens.Sum(item => item.Quantidade * item.PrecoUnitario)
                };
            }).ToList();
    }
}