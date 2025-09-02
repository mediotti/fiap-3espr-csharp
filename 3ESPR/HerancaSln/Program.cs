using System;
using System.Collections.Generic;

namespace Lab07_Heranca
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🎓 === LAB 7: HERANÇA - HIERARQUIA SIMPLES ===\n");

            // =================================================================
            // PARTE 1: CRIANDO INSTÂNCIAS E TESTANDO HERANÇA
            // =================================================================
            
            Console.WriteLine("📋 1. CRIANDO PESSOAS...\n");
            
            // Criando um Cliente
            var cliente1 = new Cliente("Maria Silva", 28, "maria@email.com", 5000.00m);
            
            // Criando um Funcionário
            var funcionario1 = new Funcionario("João Santos", 35, "joao@empresa.com", 
                                             "Desenvolvedor", 8000.00m, "TI");

            // =================================================================
            // PARTE 2: DEMONSTRANDO POLIMORFISMO
            // =================================================================
            
            Console.WriteLine("\n📋 2. DEMONSTRANDO POLIMORFISMO...\n");
            
            // Lista de pessoas - pode conter qualquer classe derivada!
            List<Pessoa> pessoas = new List<Pessoa>
            {
                cliente1,
                funcionario1,
                new Cliente("Ana Costa", 45, "ana@email.com", 10000.00m),
                new Funcionario("Pedro Lima", 29, "pedro@empresa.com", "Designer", 6500.00m, "Marketing")
            };

            // Chamando método virtual - cada classe executa sua própria versão!
            foreach (Pessoa pessoa in pessoas)
            {
                pessoa.Apresentar();  // ← Polimorfismo em ação!
                Console.WriteLine();
            }

            // =================================================================
            // PARTE 3: USANDO MÉTODOS ESPECÍFICOS
            // =================================================================
            
            Console.WriteLine("📋 3. FUNCIONALIDADES ESPECÍFICAS...\n");
            
            // Funcionalidades específicas do Cliente
            Console.WriteLine("🛍️  === AÇÕES DO CLIENTE ===");
            cliente1.RealizarCompra("Notebook", 2500.00m);
            cliente1.RealizarCompra("Mouse", 150.00m);
            cliente1.RealizarCompra("Teclado", 300.00m);
            cliente1.ExibirHistoricoCompras();
            
            Console.WriteLine();
            
            // Funcionalidades específicas do Funcionário
            Console.WriteLine("👨‍💼 === AÇÕES DO FUNCIONÁRIO ===");
            funcionario1.BaterPonto();
            funcionario1.ReceberAumento(10);
            funcionario1.TrocarDepartamento("Desenvolvimento");

            // =================================================================
            // PARTE 4: INFORMAÇÕES DETALHADAS
            // =================================================================
            
            Console.WriteLine("\n📋 4. INFORMAÇÕES DETALHADAS...\n");
            
            cliente1.ExibirInfo();
            funcionario1.ExibirInfo();

            // =================================================================
            // PARTE 5: ATIVIDADES POLIMÓRFICAS
            // =================================================================
            
            Console.WriteLine("\n📋 5. EXECUTANDO ATIVIDADES...\n");
            
            foreach (Pessoa pessoa in pessoas)
            {
                pessoa.ExecutarAtividade();  // ← Cada um faz sua atividade específica!
            }

            // =================================================================
            // EXERCÍCIOS PARA OS ALUNOS
            // =================================================================
            
            Console.WriteLine("\n🎯 === EXERCÍCIOS PARA PRATICAR ===");
            Console.WriteLine("1. Crie mais clientes e funcionários");
            Console.WriteLine("2. Adicione um método virtual 'CalcularBonificacao()' na classe Pessoa");
            Console.WriteLine("3. Implemente o método de forma diferente em cada classe filha");
            Console.WriteLine("4. Crie uma classe 'Gerente' que herda de 'Funcionario'");
            Console.WriteLine("5. Adicione validações nos construtores");
            
            Console.WriteLine("\n✅ Lab 7 concluído! Pressione qualquer tecla...");
            Console.ReadKey();
        }
    }
}

/* 
=================================================================
CONCEITOS DEMONSTRADOS NESTE LAB:

✅ HERANÇA BÁSICA: Cliente e Funcionario herdam de Pessoa
✅ PALAVRA-CHAVE BASE: Construtor e métodos da classe pai
✅ VIRTUAL/OVERRIDE: Sobrescrita personalizada de métodos  
✅ POLIMORFISMO: Lista de Pessoa com comportamentos específicos
✅ PROPRIEDADES HERDADAS: Nome, Idade, Email acessíveis em filhas
✅ ENCAPSULAMENTO: Propriedades protected e private adequadas

PRÓXIMO PASSO: Polimorfismo avançado e classes abstratas! 🚀
================================================================= 
*/