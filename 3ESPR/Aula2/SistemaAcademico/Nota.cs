namespace SistemaAcademico;

public class Nota
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public int CursoId { get; set; }
    public decimal ValorNota { get; set; }
    public DateTime DataAvaliacao { get; set; }
        
    // Propriedade calculada para status da nota
    public string Status
    {
        get
        {
            if (ValorNota >= 7) return "Aprovado";
            if (ValorNota >= 5) return "Recuperação";
            return "Reprovado";
        }
    }
        
    public override string ToString()
    {
        return $"Nota: {ValorNota:F1} - {Status} - {DataAvaliacao:dd/MM/yyyy}";
    }
}