using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAdvancedLab
{
   

    // === EXERCÍCIOS PRINCIPAIS ===
    class Program
    {
        static void Main(string[] args)
        {
            // Gerar dados de teste
            var categorias = DataGenerator.GerarCategorias();
            var produtos = DataGenerator.GerarProdutos(10000);
            var pedidos = DataGenerator.GerarPedidos(produtos, 1000);

            Console.WriteLine("=== SISTEMA DE CONSULTAS LINQ - LAB ===\n");

            // === PARTE 1: CONSULTAS BÁSICAS ===
            Console.WriteLine("=== PARTE 1: CONSULTAS BÁSICAS ===");
            
            // TODO 1.1: Listar top 10 produtos mais caros
            Console.WriteLine("1.1 - Top 10 produtos mais caros:");
            // Implementar aqui
            
            // TODO 1.2: Contar produtos por categoria
            Console.WriteLine("\n1.2 - Produtos por categoria:");
            // Implementar aqui
            
            // TODO 1.3: Produtos com estoque zero
            Console.WriteLine("\n1.3 - Produtos sem estoque:");
            // Implementar aqui

            // === PARTE 2: CONSULTAS AVANÇADAS ===
            Console.WriteLine("\n\n=== PARTE 2: CONSULTAS AVANÇADAS ===");
            
            // TODO 2.1: Produto mais vendido (maior quantidade nos pedidos)
            Console.WriteLine("2.1 - Produto mais vendido:");
            // Implementar aqui usando SelectMany e GroupBy
            
            // TODO 2.2: Receita por mês
            Console.WriteLine("\n2.2 - Receita por mês:");
            // Implementar aqui agrupando pedidos por mês
            
            // TODO 2.3: Categorias com maior valor em estoque
            Console.WriteLine("\n2.3 - Valor em estoque por categoria:");
            // Implementar Join entre produtos e categorias

            // === PARTE 3: EXTENSION METHODS ===
            Console.WriteLine("\n\n=== PARTE 3: EXTENSION METHODS CUSTOMIZADOS ===");
            
            try
            {
                var produtosAtivos = produtos.SomenteAtivos();
                Console.WriteLine($"3.1 - Produtos ativos: {produtosAtivos.Count()}");
                
                var estoqueBaixo = produtos.ComEstoqueBaixo(5);
                Console.WriteLine($"3.2 - Produtos com estoque < 5: {estoqueBaixo.Count()}");
                
                var valorTotal = produtos.ValorTotalEstoque();
                Console.WriteLine($"3.3 - Valor total do estoque: R$ {valorTotal:N2}");
                
                var porFaixaPreco = produtos.AgruparPorFaixaPreco();
                Console.WriteLine("3.4 - Produtos por faixa de preço:");
                foreach (var grupo in porFaixaPreco)
                {
                    Console.WriteLine($"  {grupo.Key}: {grupo.Count()} produtos");
                }
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Extension methods ainda não implementados!");
            }

            // === PARTE 4: PERFORMANCE E OTIMIZAÇÃO ===
            Console.WriteLine("\n\n=== PARTE 4: ANÁLISE DE PERFORMANCE ===");
            
            // TODO 4.1: Comparar performance de diferentes abordagens
            var produtosGrandes = DataGenerator.GerarProdutos(100000);
            
            Console.WriteLine("4.1 - Benchmark: Buscar produtos caros");
            
            // Versão com múltipla enumeração (LENTA)
            BenchmarkHelper.MedirTempo("Múltipla enumeração", () =>
            {
                var query = produtosGrandes.Where(p => p.Preco > 1000);
                var count = query.Count();
                var avg = query.Average(p => p.Preco);
            }, 100);
            
            // Versão otimizada (RÁPIDA)
            BenchmarkHelper.MedirTempo("Materialização única", () =>
            {
                var materialized = produtosGrandes.Where(p => p.Preco > 1000).ToList();
                var count = materialized.Count;
                var avg = materialized.Average(p => p.Preco);
            }, 100);

            // TODO 4.2: Comparar Any() vs Count() > 0
            Console.WriteLine("\n4.2 - Benchmark: Verificar existência");
            
            BenchmarkHelper.MedirTempo("Count() > 0", () =>
            {
                var existe = produtosGrandes.Where(p => p.Id > 50000).Count() > 0;
            }, 1000);
            
            BenchmarkHelper.MedirTempo("Any()", () =>
            {
                var existe = produtosGrandes.Any(p => p.Id > 50000);
            }, 1000);

            // === DESAFIO EXTRA ===
            Console.WriteLine("\n\n=== DESAFIO EXTRA ===");
            Console.WriteLine("Implementar uma consulta que encontre:");
            Console.WriteLine("- Produtos que aparecem em mais de 3 pedidos diferentes");
            Console.WriteLine("- E têm média de quantidade por pedido > 2");
            Console.WriteLine("- Ordenados por receita total gerada");
            
            // TODO: Implementar o desafio

            Console.WriteLine("\n\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}

