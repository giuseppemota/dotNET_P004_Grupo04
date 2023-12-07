namespace P004;
public class PlanoDeConsultoria
{
    string? titulo;
    double mensalidade;
    public List<string> Beneficios { get; set; }

    public string? Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public double Mensalidade
    {
        get { return mensalidade; }
        set { mensalidade = value; }
    }
    public PlanoDeConsultoria(string titulo, double _mensalidade, List<string> beneficios)
    {
        Titulo = titulo;
        mensalidade = _mensalidade;
        Beneficios = beneficios;
    }
    
}