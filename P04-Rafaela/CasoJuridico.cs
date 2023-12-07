namespace P004;

public class CasoJuridico
{
    public DateTime Abertura { get; set; }
    public DateTime Encerramento { get; set; }
    public float ProbabilidadeDeSucesso { get; set; }
    public Cliente? ClienteDoCaso { get; set; }
    public string? Status { get; set; }
    public List<Advogado>? Advogados { get; set; }
    public List<Documento>? Documentos { get; set; }    
    public List<Tuple<float, string>>? Custos { get; set; }
    public DateTime DataHoraModificacao { get; set; }

     public void IniciarCaso()
    {
        if (Status == "Em aberto")
        {
            throw new InvalidOperationException("O caso já está aberto.");
        }

        Status = "Em aberto";
        Abertura = DateTime.Now;
    }

    public void AtualizarCaso()
    {
        if (Status == "Concluído" && Encerramento <= Abertura)
        {
            throw new InvalidOperationException("A data de conclusão deve ser posterior à data de abertura.");
        }

        DataHoraModificacao = DateTime.Now;
    }
}

