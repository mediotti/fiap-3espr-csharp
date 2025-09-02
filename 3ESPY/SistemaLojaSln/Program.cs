// ========================================
// COMANDOS PARA EXECUTAR O PROJETO:
// ========================================

// 1. Criar novo projeto console (somente se for criar o projeto do zero) : 
// dotnet new console -n LojaSystem  

// 2. Adicionar pacotes necessários:
// dotnet add package Microsoft.EntityFrameworkCore.Sqlite
// dotnet add package Microsoft.EntityFrameworkCore.Proxies (para Lazy Loading)
// dotnet add package Microsoft.EntityFrameworkCore.Design
// 3. Executar o projeto:
// dotnet run

// 4. Para usar Migrations (opcional):
// dotnet ef migrations add InitialCreate
// dotnet ef database update

// ========================================
// ESTRUTURA DE PASTAS DO PROJETO:
// ========================================
/*
LojaSystem/
├── Models/
├── Data/
│   └── LojaContext.cs
├── Services/
├── Program.cs
└── LojaSystem.csproj
*/
using Microsoft.EntityFrameworkCore;
using LojaSystem.Data;
using LojaSystem.Services;

namespace LojaSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE LOJA COM RELACIONAMENTOS ===\n");

            // Configurar o contexto
            using var context = new LojaContext();
            
            // Garantir que o banco existe
            await context.Database.EnsureCreatedAsync();

            // Instanciar os serviços
            var categoriaService = new CategoriaService(context);
            var produtoService = new ProdutoService(context);
            var pedidoService = new PedidoService(context);

            // DEMONSTRAÇÃO 1: EAGER LOADING - Categorias com Produtos
            Console.WriteLine("=== 1. EAGER LOADING: Categorias com Produtos ===");
            var categoriasComProdutos = await categoriaService.ListarCategoriasComProdutos();
            
            foreach (var categoria in categoriasComProdutos)
            {
                Console.WriteLine($"Categoria: {categoria.Nome}");
                foreach (var produto in categoria.Produtos)
                {
                    Console.WriteLine($"  - {produto.Nome} | R$ {produto.Preco:C}");
                }
                Console.WriteLine();
            }

            // DEMONSTRAÇÃO 2: INCLUDE com ThenInclude
            Console.WriteLine("=== 2. INCLUDE COM THENINCLUDE: Produtos com Categoria ===");
            var produtosComCategoria = await produtoService.ListarProdutosComCategoria();
            
            foreach (var produto in produtosComCategoria)
            {
                var categoriasNomes = string.Join(", ", produto.Categorias.Select(c => c.Nome));
                Console.WriteLine($"{produto.Nome} | Categorias: {categoriasNomes} | R$ {produto.Preco:C}");
            }
            Console.WriteLine();

            // DEMONSTRAÇÃO 3: Criar Pedido com Relacionamentos
            Console.WriteLine("=== 3. CRIANDO PEDIDO COM RELACIONAMENTOS ===");
            var itensPedido = new List<(int produtoId, int quantidade)>
            {
                (1, 2), // 2x Smartphone Samsung Galaxy
                (4, 1)  // 1x Mouse Gamer Logitech
            };

            var novoPedido = await pedidoService.CriarPedido(1, itensPedido); // Cliente ID 1 = João Silva
            Console.WriteLine($"Pedido {novoPedido.Id} criado com sucesso! Valor Total: R$ {novoPedido.ValorTotal:C}");
            Console.WriteLine();

            // DEMONSTRAÇÃO 4: Consulta Complexa - Pedidos Completos
            Console.WriteLine("=== 4. CONSULTA COMPLEXA: Pedidos Completos ===");
            var pedidosCompletos = await pedidoService.ListarPedidosCompletos();
            
            foreach (var pedido in pedidosCompletos)
            {
                Console.WriteLine($"Pedido #{pedido.Id} - Cliente: {pedido.Cliente.Nome}");
                Console.WriteLine($"Data: {pedido.DataPedido:dd/MM/yyyy} | Total: R$ {pedido.ValorTotal:C}");
                Console.WriteLine("Itens:");
                
                foreach (var item in pedido.ItensPedido)
                {
                    Console.WriteLine($"  - {item.Quantidade}x {item.Produto.Nome} | R$ {item.Subtotal:C}");
                }
                Console.WriteLine($"Status: {pedido.Status}\n");
            }

            // DEMONSTRAÇÃO 5: Filtros com Relacionamentos
            Console.WriteLine("=== 5. FILTROS COM RELACIONAMENTOS ===");
            var produtosInformatica = await produtoService.BuscarProdutosPorCategoria(2);
            Console.WriteLine("Produtos da categoria Informática:");
            
            foreach (var produto in produtosInformatica)
            {
                Console.WriteLine($"  - {produto.Nome} | R$ {produto.Preco:C} | Estoque: {produto.EstoqueAtual}");
            }
            Console.WriteLine();

            // DEMONSTRAÇÃO 6: Agregações
            Console.WriteLine("=== 6. AGREGAÇÕES E ESTATÍSTICAS ===");
            
            // Total de produtos por categoria
            var estatisticas = await context.Categorias
                .Select(c => new 
                { 
                    Categoria = c.Nome, 
                    TotalProdutos = c.Produtos.Count(),
                    ValorMedioEstoque = c.Produtos.Average(p => p.Preco)
                })
                .ToListAsync();

            foreach (var stat in estatisticas)
            {
                Console.WriteLine($"{stat.Categoria}: {stat.TotalProdutos} produtos | Preço médio: R$ {stat.ValorMedioEstoque:C}");
            }
            Console.WriteLine();

            // EXERCÍCIOS PARA OS ALUNOS
            Console.WriteLine("=== EXERCÍCIOS PARA PRATICAR ===");
            Console.WriteLine("1. Implemente Lazy Loading e compare com Eager Loading");
            Console.WriteLine("2. Crie uma consulta que mostre o cliente que mais gastou");
            Console.WriteLine("3. Liste produtos que nunca foram vendidos");
            Console.WriteLine("4. Calcule o valor total de vendas por categoria");
            Console.WriteLine("5. Implemente um relatório de produtos com baixo estoque");

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}

