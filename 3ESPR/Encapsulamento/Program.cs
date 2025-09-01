using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab06_Encapsulamento
{
    /// <summary>
    /// Classe principal para testes
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== LAB 6 - ENCAPSULAMENTO E MODIFICADORES DE ACESSO ===\n");
            
            // TODO: EXERCÍCIO 5 - Implementar testes
            
            try
            {
                Console.WriteLine("1. Testando criação de produto válido...");
                // TODO: Criar produto válido
                // var produto1 = new Produto("Notebook Dell", 2500m, "Informática", 10);
                // Console.WriteLine(produto1);
                
                Console.WriteLine("\n2. Testando validações...");
                // TODO: Testar casos inválidos (use try-catch para capturar exceções)
                // - Nome vazio
                // - Preço negativo  
                // - Estoque negativo
                // - Categoria vazia
                
                Console.WriteLine("\n3. Testando métodos de negócio...");
                // TODO: Testar AdicionarEstoque, RemoverEstoque, AplicarDesconto
                
                Console.WriteLine("\n4. Testando properties calculadas...");
                // TODO: Testar ValorTotalEstoque e EstoqueBaixo
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            
            Console.WriteLine("\n=== COMPARAÇÃO COM CÓDIGO ANTERIOR ===");
            DemonstrarProblemasSemEncapsulamento();
            
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Demonstra os problemas do código sem encapsulamento
        /// </summary>
        static void DemonstrarProblemasSemEncapsulamento()
        {
            Console.WriteLine("\nProblemas sem encapsulamento:");
            
            var produtoRuim = new ProdutoAntigo();
            
            // Todos esses são possíveis e problemáticos!
            produtoRuim.nome = "";           // Nome vazio!
            produtoRuim.preco = -100;        // Preço negativo!
            produtoRuim.estoque = -50;       // Estoque negativo!
            produtoRuim.categoria = null;    // Categoria null!
            
            Console.WriteLine("❌ Produto em estado inválido criado com sucesso!");
            Console.WriteLine($"Nome: '{produtoRuim.nome}', Preço: {produtoRuim.preco}, " +
                            $"Estoque: {produtoRuim.estoque}, Categoria: '{produtoRuim.categoria}'");
        }
    }
}