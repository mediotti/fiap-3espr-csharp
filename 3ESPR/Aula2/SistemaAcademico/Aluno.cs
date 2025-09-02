namespace SistemaAcademico;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
        
    // Propriedade calculada - demonstra encapsulamento
    public int Idade => DateTime.Now.Year - DataNascimento.Year;

    public override string ToString()
    {
        return $"[{Id}] {Nome} - {Email} ({Idade} anos)";
    }
}