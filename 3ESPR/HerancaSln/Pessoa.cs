namespace Lab07_Heranca;

/// <summary>
/// CLASSE BASE: Pessoa
/// Contém propriedades e métodos comuns a todas as pessoas
/// </summary>
public class Pessoa
{
    // PROPRIEDADES PROTEGIDAS - Acessíveis nas classes filhas
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
    protected DateTime DataCadastro { get; set; }

    // CONSTRUTOR DA CLASSE BASE
    public Pessoa(string nome, int idade, string email)
    {
        Nome = nome;
        Idade = idade;
        Email = email;
        DataCadastro = DateTime.Now;
            
        Console.WriteLine($"📝 Pessoa '{nome}' criada no sistema!");
    }

    // MÉTODO VIRTUAL - Pode ser sobrescrito nas classes filhas
    public virtual void Apresentar()
    {
        Console.WriteLine($"\n👋 Olá! Meu nome é {Nome}");
        Console.WriteLine($"📧 Email: {Email}");
        Console.WriteLine($"🎂 Idade: {Idade} anos");
    }

    // MÉTODO VIRTUAL - Para ser personalizado por cada tipo
    public virtual void ExibirInfo()
    {
        Console.WriteLine($"\n📋 === INFORMAÇÕES BÁSICAS ===");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Idade: {Idade}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Cadastro: {DataCadastro:dd/MM/yyyy}");
    }

    // MÉTODO VIRTUAL - Comportamento padrão para atividades
    public virtual void ExecutarAtividade()
    {
        Console.WriteLine($"🤔 {Nome} está realizando uma atividade genérica...");
    }
}