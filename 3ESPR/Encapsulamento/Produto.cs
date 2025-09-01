namespace Lab06_Encapsulamento;

/// <summary>
/// TODO: EXERCÍCIO 1 - Converter esta classe para usar encapsulamento
/// Refatorar a classe abaixo aplicando os conceitos de encapsulamento
/// </summary>
public class Produto
{
    // TODO: Converter campos públicos para campos privados
    // Dica: Use convenção _nomeDoCard para campos privados
        
    // TODO: EXERCÍCIO 1 - Criar campos privados
    // private string _nome;
    // private decimal _preco;
    // private int _estoque;
    // private string _categoria;
        
    // Campos que não precisam de validação especial
    public DateTime DataCriacao { get; private set; }
    public bool Ativo { get; set; } = true;
        
    // TODO: EXERCÍCIO 2 - Implementar Properties com validações
        
    /// <summary>
    /// Nome do produto - obrigatório, mínimo 2 caracteres
    /// </summary>
    public string Nome 
    { 
        get 
        { 
            // TODO: Retornar o campo privado _nome
            throw new NotImplementedException("Implementar getter do Nome"); 
        }
        set 
        { 
            // TODO: Implementar validação
            // - Não pode ser null, vazio ou apenas espaços
            // - Deve ter pelo menos 2 caracteres
            // - Se inválido, lance ArgumentException com mensagem clara
            throw new NotImplementedException("Implementar setter do Nome"); 
        }
    }
        
    /// <summary>
    /// Preço do produto - sempre positivo
    /// </summary>
    public decimal Preco 
    { 
        get 
        { 
            // TODO: Retornar o campo privado _preco
            throw new NotImplementedException("Implementar getter do Preco"); 
        }
        set 
        { 
            // TODO: Implementar validação
            // - Deve ser maior que 0
            // - Se inválido, lance ArgumentException
            throw new NotImplementedException("Implementar setter do Preco"); 
        }
    }
        
    /// <summary>
    /// Estoque do produto - não pode ser negativo
    /// </summary>
    public int Estoque 
    { 
        get 
        { 
            // TODO: Retornar o campo privado _estoque
            throw new NotImplementedException("Implementar getter do Estoque"); 
        }
        set 
        { 
            // TODO: Implementar validação
            // - Não pode ser negativo
            // - Se inválido, lance ArgumentException
            throw new NotImplementedException("Implementar setter do Estoque"); 
        }
    }
        
    /// <summary>
    /// Categoria do produto - obrigatória
    /// </summary>
    public string Categoria 
    { 
        get 
        { 
            // TODO: Retornar o campo privado _categoria
            throw new NotImplementedException("Implementar getter da Categoria"); 
        }
        set 
        { 
            // TODO: Implementar validação
            // - Não pode ser null, vazio ou apenas espaços
            throw new NotImplementedException("Implementar setter da Categoria"); 
        }
    }
        
    // TODO: EXERCÍCIO 3 - Implementar Construtores
        
    /// <summary>
    /// Construtor principal - garante que o objeto seja criado em estado válido
    /// </summary>
    /// <param name="nome">Nome do produto</param>
    /// <param name="preco">Preço do produto</param>
    /// <param name="categoria">Categoria do produto</param>
    /// <param name="estoque">Estoque inicial (padrão 0)</param>
    public Produto(string nome, decimal preco, string categoria, int estoque = 0)
    {
        // TODO: Implementar construtor
        // - Use as properties (não os campos) para aproveitar as validações
        // - Defina DataCriacao como DateTime.Now
        // - Defina Ativo como true
        throw new NotImplementedException("Implementar construtor principal");
    }
        
    /// <summary>
    /// Construtor secundário - sem estoque inicial
    /// </summary>
    public Produto(string nome, decimal preco, string categoria) 
        : this(nome, preco, categoria, 0)
    {
        // Construtor chaining - chama o construtor principal com estoque 0
    }
        
    // TODO: EXERCÍCIO 4 - Implementar Métodos de Negócio
        
    /// <summary>
    /// Adiciona quantidade ao estoque
    /// </summary>
    /// <param name="quantidade">Quantidade a adicionar</param>
    /// <returns>Novo valor do estoque</returns>
    public int AdicionarEstoque(int quantidade)
    {
        // TODO: Implementar
        // - Validar se quantidade é positiva
        // - Adicionar ao estoque atual
        // - Retornar novo valor do estoque
        throw new NotImplementedException("Implementar AdicionarEstoque");
    }
        
    /// <summary>
    /// Remove quantidade do estoque
    /// </summary>
    /// <param name="quantidade">Quantidade a remover</param>
    /// <returns>True se conseguiu remover, False se não tem estoque suficiente</returns>
    public bool RemoverEstoque(int quantidade)
    {
        // TODO: Implementar
        // - Validar se quantidade é positiva
        // - Verificar se tem estoque suficiente
        // - Se sim, remover e retornar true
        // - Se não, retornar false (sem alterar estoque)
        throw new NotImplementedException("Implementar RemoverEstoque");
    }
        
    /// <summary>
    /// Aplica desconto percentual ao preço
    /// </summary>
    /// <param name="percentualDesconto">Percentual de desconto (0-100)</param>
    public void AplicarDesconto(decimal percentualDesconto)
    {
        // TODO: Implementar
        // - Validar se percentual está entre 0 e 100
        // - Calcular novo preço com desconto
        // - Atualizar preço usando a property (para validação)
        throw new NotImplementedException("Implementar AplicarDesconto");
    }
        
    /// <summary>
    /// Property calculada - valor total em estoque
    /// </summary>
    public decimal ValorTotalEstoque => Preco * Estoque;
        
    /// <summary>
    /// Verifica se o produto está com estoque baixo
    /// </summary>
    public bool EstoqueBaixo => Estoque < 5;
        
    /// <summary>
    /// Representação string do produto
    /// </summary>
    public override string ToString()
    {
        return $"{Nome} - {Categoria} | R$ {Preco:F2} | Estoque: {Estoque} | " +
               $"Ativo: {(Ativo ? "Sim" : "Não")} | Criado: {DataCriacao:dd/MM/yyyy}";
    }
}