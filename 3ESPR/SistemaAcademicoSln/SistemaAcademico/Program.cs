namespace SistemaAcademico;

class Program
{
    static double[] LerNotas(int quantidade)
    {
        double[] notas = new double[quantidade];

        Console.WriteLine($"\nDigite {quantidade} notas:");
        for (int i = 0; i < quantidade; i++)
        {
            notas[i] = LerNotaValida(i + 1);
        }

        return notas;
    }

    static double CalcularMedia(double[] notas)
    {
        if (notas == null || notas.Length == 0)
            return 0;

        double soma = 0;
        foreach (double nota in notas)
        {
            soma += nota;
        }

        return soma / notas.Length;
    }

    static bool VerificarAprovacao(double media)
    {
        return media >= 7.0;
    }

    static string ObterSituacao(bool aprovado)
    {
        return aprovado ? "APROVADO" : "REPROVADO";
    }

    static void ExibirCabecalho()
    {
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║       SISTEMA ACADÊMICO FIAP       ║");
        Console.WriteLine("╚════════════════════════════════════╝\n");
    }

    static void ExibirResultadoAluno(string nome, double[] notas, double media, bool aprovado)
    {
        Console.WriteLine($"\n--- RESULTADO DE {nome.ToUpper()} ---");
        Console.Write("Notas: ");
    
        for (int i = 0; i < notas.Length; i++)
        {
            Console.Write(notas[i].ToString("F1"));
            if (i < notas.Length - 1)
                Console.Write(" | ");
        }
    
        Console.WriteLine($"\nMédia: {media:F2}");
        Console.WriteLine($"Situação: {ObterSituacao(aprovado)}");
        Console.WriteLine(new string('-', 30));
    }

    static void ExibirMenu()
    {
        Console.WriteLine("\n=== MENU ===");
        Console.WriteLine("1. Processar um aluno");
        Console.WriteLine("2. Processar múltiplos alunos");
        Console.WriteLine("3. Sair");
        Console.Write("Escolha uma opção: ");
    }

    

    static bool ValidarNota(double nota)
    {
        return nota >= 0 && nota <= 10;
    }

    static string LerNomeValido()
    {
        while (true)
        {
            Console.Write("Nome do aluno: ");
            string nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nome))
                return nome;

            Console.WriteLine("Nome não pode ser vazio!");
        }
    }

    static double LerNotaValida(int numeroNota)
    {
        while (true)
        {
            Console.Write($"Nota {numeroNota} (0-10): ");

            if (double.TryParse(Console.ReadLine(), out double nota))
            {
                if (ValidarNota(nota))
                    return nota;
                else
                    Console.WriteLine("Nota deve estar entre 0 e 10!");
            }
            else
            {
                Console.WriteLine("Digite um número válido!");
            }
        }
    }

    static void Main(string[] args)
    {
        ExibirCabecalho();

        while (true)
        {
            ExibirMenu();
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ProcessarUmAluno();
                    break;
                case "2":
                    ProcessarMultiplosAlunos();
                    break;
                case "3":
                    Console.WriteLine("Encerrando sistema...");
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private static void ProcessarMultiplosAlunos()
    {
        throw new NotImplementedException();
    }

    private static void ProcessarUmAluno()
    {
        throw new NotImplementedException();
    }
}