namespace P004;

public class Documento
{
    public DateTime DataModificacao { get; set; }
    public string? Descricao { get; set; }
    public string? Tipo { get; set; }
    public int Codigo { get; set; }


    public void AtualizarData()
    {
        DataModificacao = DateTime.Now;
    }

    public Documento(string? descricao, string? tipo)
    {
        this.DataModificacao = DateTime.Now;
        this.Descricao = descricao;
        this.Tipo = tipo;
        this.Codigo = ++id;
    }
    public static int id = 0;

}