namespace Lab07_Heranca;

/// <summary>
/// CLASSE DERIVADA: Cliente
/// Herda de Pessoa e adiciona funcionalidades específicas
/// </summary>
public class Cliente : Pessoa
{
    // PROPRIEDADES ESPECÍFICAS DO CLIENTE
    public string CodigoCliente { get; private set; }
    public decimal LimiteCredito { get; set; }
    public List<string> Compras { get; private set; }

    // CONSTRUTOR - Chama o construtor da classe base com 'base()'
    public Cliente(string nome, int idade, string email, decimal limiteCredito) 
        : base(nome, idade, email)  // ← CHAMA construtor da classe Pessoa
    {
        CodigoCliente = $"CLI-{DateTime.Now.Ticks.ToString().Substring(0, 6)}";
        LimiteCredito = limiteCredito;
        Compras = new List<string>();
            
        Console.WriteLine($"🛍️  Cliente cadastrado com código: {CodigoCliente}");
    }

    // SOBRESCRITA DO MÉTODO APRESENTAR
    public override void Apresentar()
    {
        // Chama o método da classe pai PRIMEIRO
        base.Apresentar();  // ← CHAMA método da classe Pessoa
            
        // Adiciona informações específicas do cliente
        Console.WriteLine($"🛍️  Sou cliente com código: {CodigoCliente}");
        Console.WriteLine($"💰 Limite de crédito: R$ {LimiteCredito:F2}");
    }

    // SOBRESCRITA DO MÉTODO EXIBIR INFO
    public override void ExibirInfo()
    {
        Console.WriteLine($"\n🛍️  === INFORMAÇÕES DO CLIENTE ===");
            
        // Reutiliza informações básicas da classe pai
        base.ExibirInfo();
            
        // Adiciona informações específicas
        Console.WriteLine($"Código Cliente: {CodigoCliente}");
        Console.WriteLine($"Limite Crédito: R$ {LimiteCredito:F2}");
        Console.WriteLine($"Total de Compras: {Compras.Count}");
    }

    // SOBRESCRITA DA ATIVIDADE
    public override void ExecutarAtividade()
    {
        Console.WriteLine($"🛒 {Nome} está navegando pelo catálogo de produtos...");
    }

    // MÉTODO ESPECÍFICO DO CLIENTE
    public void RealizarCompra(string produto, decimal valor)
    {
        if (valor <= LimiteCredito)
        {
            Compras.Add($"{produto} - R$ {valor:F2}");
            LimiteCredito -= valor;
            Console.WriteLine($"✅ Compra realizada: {produto} por R$ {valor:F2}");
            Console.WriteLine($"💳 Limite restante: R$ {LimiteCredito:F2}");
        }
        else
        {
            Console.WriteLine($"❌ Compra negada! Limite insuficiente.");
            Console.WriteLine($"💳 Limite atual: R$ {LimiteCredito:F2} | Valor: R$ {valor:F2}");
        }
    }

    public void ExibirHistoricoCompras()
    {
        Console.WriteLine($"\n🛍️  === HISTÓRICO DE COMPRAS - {Nome} ===");
        if (Compras.Count == 0)
        {
            Console.WriteLine("Nenhuma compra realizada ainda.");
        }
        else
        {
            for (int i = 0; i < Compras.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Compras[i]}");
            }
        }
    }
}