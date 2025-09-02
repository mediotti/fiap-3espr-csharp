namespace Lab07_Heranca;

/// <summary>
/// CLASSE DERIVADA: Funcionario
/// Herda de Pessoa e adiciona funcionalidades específicas
/// </summary>
public class Funcionario : Pessoa
{
    // PROPRIEDADES ESPECÍFICAS DO FUNCIONÁRIO
    public string CodigoFuncionario { get; private set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public string Departamento { get; set; }
    public DateTime DataAdmissao { get; set; }

    // CONSTRUTOR - Usa base() para chamar construtor da classe pai
    public Funcionario(string nome, int idade, string email, string cargo, decimal salario, string departamento)
        : base(nome, idade, email)  // ← CHAMA construtor da classe Pessoa
    {
        CodigoFuncionario = $"FUNC-{DateTime.Now.Ticks.ToString().Substring(0, 6)}";
        Cargo = cargo;
        Salario = salario;
        Departamento = departamento;
        DataAdmissao = DateTime.Now;
            
        Console.WriteLine($"👨‍💼 Funcionário cadastrado - Código: {CodigoFuncionario}");
    }

    // SOBRESCRITA DO MÉTODO APRESENTAR
    public override void Apresentar()
    {
        // Executa apresentação básica da classe pai
        base.Apresentar();  // ← CHAMA método da classe Pessoa
            
        // Adiciona informações profissionais
        Console.WriteLine($"👨‍💼 Trabalho como {Cargo} no departamento de {Departamento}");
        Console.WriteLine($"💼 Código funcionário: {CodigoFuncionario}");
    }

    // SOBRESCRITA DO MÉTODO EXIBIR INFO
    public override void ExibirInfo()
    {
        Console.WriteLine($"\n👨‍💼 === INFORMAÇÕES DO FUNCIONÁRIO ===");
            
        // Informações básicas da classe pai
        base.ExibirInfo();
            
        // Informações profissionais
        Console.WriteLine($"Código Funcionário: {CodigoFuncionario}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Departamento: {Departamento}");
        Console.WriteLine($"Salário: R$ {Salario:F2}");
        Console.WriteLine($"Data Admissão: {DataAdmissao:dd/MM/yyyy}");
    }

    // SOBRESCRITA DA ATIVIDADE
    public override void ExecutarAtividade()
    {
        Console.WriteLine($"💼 {Nome} está executando suas atividades como {Cargo}...");
    }

    // MÉTODOS ESPECÍFICOS DO FUNCIONÁRIO
    public void BaterPonto()
    {
        Console.WriteLine($"🕐 {Nome} bateu o ponto às {DateTime.Now:HH:mm}");
    }

    public void ReceberAumento(decimal percentual)
    {
        decimal salarioAnterior = Salario;
        Salario += Salario * (percentual / 100);
            
        Console.WriteLine($"📈 {Nome} recebeu aumento de {percentual}%!");
        Console.WriteLine($"💰 Salário: R$ {salarioAnterior:F2} → R$ {Salario:F2}");
    }

    public void TrocarDepartamento(string novoDepartamento)
    {
        string departamentoAnterior = Departamento;
        Departamento = novoDepartamento;
            
        Console.WriteLine($"🔄 {Nome} foi transferido(a):");
        Console.WriteLine($"📂 {departamentoAnterior} → {novoDepartamento}");
    }
}