namespace P004;

public class CasoJuridico
{
    private static int id = 0;
    public int ID { get; }
    public DateTime Abertura { get; set; }
    public DateTime? Encerramento { get; set; }
    public float ProbabilidadeDeSucesso { get; set; }
    public Cliente? ClienteDoCaso { get; set; }
    public string? Status { get; set; }
    public List<Advogado>? Advogados { get; set; }
    public List<Documento>? Documentos { get; set; }
    public List<CustoItem>? Custos { get; set; }

    public CasoJuridico()
    {
        ID = id + 1;
        id++;
        Abertura = DateTime.Now;
    }
}
