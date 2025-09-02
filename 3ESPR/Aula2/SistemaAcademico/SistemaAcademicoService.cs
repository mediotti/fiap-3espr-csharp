namespace SistemaAcademico;

public class SistemaAcademicoService
{
    // Listas para armazenar dados (simulando banco de dados)
    private List<Aluno> _alunos;
    private List<Curso> _cursos;
    private List<Nota> _notas;
    private int _proximoIdAluno;
    private int _proximoIdCurso;
    private int _proximoIdNota;

    public SistemaAcademicoService()
    {
        _alunos = new List<Aluno>();
        _cursos = new List<Curso>();
        _notas = new List<Nota>();
        _proximoIdAluno = 1;
        _proximoIdCurso = 1;
        _proximoIdNota = 1;
            
        // Dados iniciais para demonstração
        InicializarDadosDemo();
    }

    private void InicializarDadosDemo()
    {
        // Criando cursos de exemplo
        AdicionarCurso("Programação C#", "Curso básico de programação em C#");
        AdicionarCurso("Banco de Dados", "Fundamentos de banco de dados");
        AdicionarCurso("Desenvolvimento Web", "HTML, CSS e JavaScript");

        // Criando alunos de exemplo
        AdicionarAluno("João Silva", "joao@email.com", new DateTime(2000, 5, 15));
        AdicionarAluno("Maria Santos", "maria@email.com", new DateTime(1999, 8, 22));
        AdicionarAluno("Pedro Oliveira", "pedro@email.com", new DateTime(2001, 3, 10));

        // Adicionando algumas notas
        AdicionarNota(1, 1, 8.5m);
        AdicionarNota(1, 2, 7.2m);
        AdicionarNota(2, 1, 9.0m);
        AdicionarNota(3, 1, 6.5m);
    }

    // === MÉTODOS PARA ALUNOS ===
        
    public void AdicionarAluno(string nome, string email, DateTime dataNascimento)
    {
        var aluno = new Aluno
        {
            Id = _proximoIdAluno++,
            Nome = nome,
            Email = email,
            DataNascimento = dataNascimento
        };
            
        _alunos.Add(aluno);
        Console.WriteLine($"✅ Aluno {nome} adicionado com sucesso!");
    }

    public List<Aluno> ListarAlunos()
    {
        return _alunos.ToList(); // Retorna uma cópia para proteger a lista interna
    }

    public Aluno BuscarAlunoPorId(int id)
    {
        return _alunos.FirstOrDefault(a => a.Id == id);
    }

    // === MÉTODOS PARA CURSOS ===
        
    public void AdicionarCurso(string nome, string descricao)
    {
        var curso = new Curso
        {
            Id = _proximoIdCurso++,
            Nome = nome,
            Descricao = descricao
        };
            
        _cursos.Add(curso);
        Console.WriteLine($"✅ Curso {nome} adicionado com sucesso!");
    }

    public List<Curso> ListarCursos()
    {
        return _cursos.ToList();
    }

    public Curso BuscarCursoPorId(int id)
    {
        return _cursos.FirstOrDefault(c => c.Id == id);
    }

    // === MÉTODOS PARA NOTAS ===
        
    public void AdicionarNota(int alunoId, int cursoId, decimal valorNota)
    {
        // Validações
        if (BuscarAlunoPorId(alunoId) == null)
        {
            Console.WriteLine("❌ Aluno não encontrado!");
            return;
        }
            
        if (BuscarCursoPorId(cursoId) == null)
        {
            Console.WriteLine("❌ Curso não encontrado!");
            return;
        }
            
        if (valorNota < 0 || valorNota > 10)
        {
            Console.WriteLine("❌ Nota deve estar entre 0 e 10!");
            return;
        }

        var nota = new Nota
        {
            Id = _proximoIdNota++,
            AlunoId = alunoId,
            CursoId = cursoId,
            ValorNota = valorNota,
            DataAvaliacao = DateTime.Now
        };
            
        _notas.Add(nota);
        Console.WriteLine($"✅ Nota {valorNota:F1} adicionada com sucesso!");
    }

    public List<Nota> ListarNotasPorAluno(int alunoId)
    {
        return _notas.Where(n => n.AlunoId == alunoId).ToList();
    }

    // === MÉTODOS DE RELATÓRIO ===
        
    public void GerarRelatorioAluno(int alunoId)
    {
        var aluno = BuscarAlunoPorId(alunoId);
        if (aluno == null)
        {
            Console.WriteLine("❌ Aluno não encontrado!");
            return;
        }

        var notasAluno = ListarNotasPorAluno(alunoId);
            
        Console.WriteLine("\n" + "=".PadLeft(50, '='));
        Console.WriteLine($"📊 RELATÓRIO DO ALUNO: {aluno.Nome}");
        Console.WriteLine("=".PadLeft(50, '='));
        Console.WriteLine($"ID: {aluno.Id}");
        Console.WriteLine($"Email: {aluno.Email}");
        Console.WriteLine($"Idade: {aluno.Idade} anos");
        Console.WriteLine();

        if (notasAluno.Any())
        {
            Console.WriteLine("📚 NOTAS:");
            foreach (var nota in notasAluno)
            {
                var curso = BuscarCursoPorId(nota.CursoId);
                Console.WriteLine($"  • {curso.Nome}: {nota}");
            }
                
            var media = notasAluno.Average(n => (double)n.ValorNota);
            Console.WriteLine($"\n📈 MÉDIA GERAL: {media:F2}");
        }
        else
        {
            Console.WriteLine("📚 Nenhuma nota registrada.");
        }
            
        Console.WriteLine("=".PadLeft(50, '=') + "\n");
    }

    public void GerarRelatorioGeral()
    {
        Console.WriteLine("\n" + "=".PadLeft(60, '='));
        Console.WriteLine("📊 RELATÓRIO GERAL DO SISTEMA");
        Console.WriteLine("=".PadLeft(60, '='));
            
        Console.WriteLine($"👥 Total de Alunos: {_alunos.Count}");
        Console.WriteLine($"📚 Total de Cursos: {_cursos.Count}");
        Console.WriteLine($"📝 Total de Notas: {_notas.Count}");
            
        if (_notas.Any())
        {
            var mediaGeral = _notas.Average(n => (double)n.ValorNota);
            Console.WriteLine($"📈 Média Geral do Sistema: {mediaGeral:F2}");
        }
            
        Console.WriteLine("=".PadLeft(60, '=') + "\n");
    }
}