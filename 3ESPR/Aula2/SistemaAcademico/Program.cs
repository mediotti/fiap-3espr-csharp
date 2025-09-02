using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAcademico
{
    // === CLASSES DE MODELO ===

    // === CLASSE DE SERVIÇO ===

    // === CLASSE PRINCIPAL ===
    
    class Program
    {
        private static SistemaAcademicoService _sistema;

        static void Main(string[] args)
        {
            _sistema = new SistemaAcademicoService();
            Console.WriteLine("🎓 SISTEMA DE CONTROLE ACADÊMICO");
            Console.WriteLine("Bem-vindo! Sistema iniciado com dados de demonstração.\n");

            while (true)
            {
                ExibirMenu();
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarAluno();
                        break;
                    case "2":
                        ListarAlunos();
                        break;
                    case "3":
                        CadastrarCurso();
                        break;
                    case "4":
                        ListarCursos();
                        break;
                    case "5":
                        CadastrarNota();
                        break;
                    case "6":
                        ConsultarNotasAluno();
                        break;
                    case "7":
                        GerarRelatorioAluno();
                        break;
                    case "8":
                        _sistema.GerarRelatorioGeral();
                        break;
                    case "0":
                        Console.WriteLine("👋 Saindo do sistema...");
                        return;
                    default:
                        Console.WriteLine("❌ Opção inválida! Tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ExibirMenu()
        {
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║           MENU PRINCIPAL             ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1 - Cadastrar Aluno                  ║");
            Console.WriteLine("║ 2 - Listar Alunos                    ║");
            Console.WriteLine("║ 3 - Cadastrar Curso                  ║");
            Console.WriteLine("║ 4 - Listar Cursos                    ║");
            Console.WriteLine("║ 5 - Cadastrar Nota                   ║");
            Console.WriteLine("║ 6 - Consultar Notas do Aluno         ║");
            Console.WriteLine("║ 7 - Relatório Individual do Aluno    ║");
            Console.WriteLine("║ 8 - Relatório Geral                  ║");
            Console.WriteLine("║ 0 - Sair                             ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("Escolha uma opção: ");
        }

        static void CadastrarAluno()
        {
            Console.WriteLine("\n📝 CADASTRO DE ALUNO");
            Console.WriteLine("=" + "=".PadLeft(30, '='));

            Console.Write("Nome: ");
            var nome = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/mm/aaaa): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, 
                System.Globalization.DateTimeStyles.None, out DateTime dataNascimento))
            {
                _sistema.AdicionarAluno(nome, email, dataNascimento);
            }
            else
            {
                Console.WriteLine("❌ Data inválida! Use o formato dd/mm/aaaa");
            }
        }

        static void ListarAlunos()
        {
            Console.WriteLine("\n👥 LISTA DE ALUNOS");
            Console.WriteLine("=" + "=".PadLeft(30, '='));

            var alunos = _sistema.ListarAlunos();
            if (alunos.Any())
            {
                foreach (var aluno in alunos)
                    
                {
                    Console.WriteLine(aluno);
                }
            }
            else
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
            }
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("\n📚 CADASTRO DE CURSO");
            Console.WriteLine("=" + "=".PadLeft(30, '='));

            Console.Write("Nome do Curso: ");
            var nome = Console.ReadLine();

            Console.Write("Descrição: ");
            var descricao = Console.ReadLine();

            _sistema.AdicionarCurso(nome, descricao);
        }

        static void ListarCursos()
        {
            Console.WriteLine("\n📚 LISTA DE CURSOS");
            Console.WriteLine("=" + "=".PadLeft(30, '='));

            var cursos = _sistema.ListarCursos();
            if (cursos.Any())
            {
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso);
                }
            }
            else
            {
                Console.WriteLine("Nenhum curso cadastrado.");
            }
        }

        static void CadastrarNota()
        {
            Console.WriteLine("\n📝 CADASTRO DE NOTA");
            Console.WriteLine("=" + "=".PadLeft(30, '='));

            // Listar alunos disponíveis
            Console.WriteLine("Alunos disponíveis:");
            var alunos = _sistema.ListarAlunos();
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.Write("\nID do Aluno: ");
            if (int.TryParse(Console.ReadLine(), out int alunoId))
            {
                // Listar cursos disponíveis
                Console.WriteLine("\nCursos disponíveis:");
                var cursos = _sistema.ListarCursos();
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso);
                }

                Console.Write("\nID do Curso: ");
                if (int.TryParse(Console.ReadLine(), out int cursoId))
                {
                    Console.Write("Nota (0-10): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                    {
                        _sistema.AdicionarNota(alunoId, cursoId, nota);
                    }
                    else
                    {
                        Console.WriteLine("❌ Nota inválida!");
                    }
                }
                else
                {
                    Console.WriteLine("❌ ID do curso inválido!");
                }
            }
            else
            {
                Console.WriteLine("❌ ID do aluno inválido!");
            }
        }

        static void ConsultarNotasAluno()
        {
            Console.WriteLine("\n📊 CONSULTAR NOTAS DO ALUNO");
            Console.WriteLine("=" + "=".PadLeft(40, '='));

            ListarAlunos();
            Console.Write("\nID do Aluno: ");
            
            if (int.TryParse(Console.ReadLine(), out int alunoId))
            {
                var aluno = _sistema.BuscarAlunoPorId(alunoId);
                if (aluno != null)
                {
                    var notas = _sistema.ListarNotasPorAluno(alunoId);
                    
                    Console.WriteLine($"\n📚 Notas de {aluno.Nome}:");
                    if (notas.Any())
                    {
                        foreach (var nota in notas)
                        {
                            var curso = _sistema.BuscarCursoPorId(nota.CursoId);
                            Console.WriteLine($"  • {curso.Nome}: {nota}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  Nenhuma nota registrada.");
                    }
                }
                else
                {
                    Console.WriteLine("❌ Aluno não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("❌ ID inválido!");
            }
        }

        static void GerarRelatorioAluno()
        {
            Console.WriteLine("\n📊 RELATÓRIO INDIVIDUAL DO ALUNO");
            Console.WriteLine("=" + "=".PadLeft(40, '='));

            ListarAlunos();
            Console.Write("\nID do Aluno: ");
            
            if (int.TryParse(Console.ReadLine(), out int alunoId))
            {
                _sistema.GerarRelatorioAluno(alunoId);
            }
            else
            {
                Console.WriteLine("❌ ID inválido!");
            }
        }
    }
}