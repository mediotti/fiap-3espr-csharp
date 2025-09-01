namespace LinqAdvancedLab;

public static class LinqExtensions
{
    // TODO: Implementar extension method para filtrar produtos ativos
    public static IEnumerable<Produto> SomenteAtivos(this IEnumerable<Produto> produtos)
    {
        // Implementar aqui
        throw new NotImplementedException();
    }

    // TODO: Extension method para produtos com estoque baixo
    public static IEnumerable<Produto> ComEstoqueBaixo(this IEnumerable<Produto> produtos, int limite = 10)
    {
        // Implementar aqui
        throw new NotImplementedException();
    }

    // TODO: Extension method para calcular valor total do estoque
    public static decimal ValorTotalEstoque(this IEnumerable<Produto> produtos)
    {
        // Implementar aqui
        throw new NotImplementedException();
    }

    // TODO: Extension method para agrupar por faixa de preço
    public static IEnumerable<IGrouping<string, Produto>> AgruparPorFaixaPreco(this IEnumerable<Produto> produtos)
    {
        // Faixas: "Barato" (0-50), "Médio" (51-200), "Caro" (201+)
        // Implementar aqui
        throw new NotImplementedException();
    }
}