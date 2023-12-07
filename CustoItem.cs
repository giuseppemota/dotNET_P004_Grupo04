namespace P004;

public class CustoItem
{
    public float Custo { get; set; }
    public string? Descricao { get; set; }

    public CustoItem(string? descricao, float custo)
    {
        this.Descricao = descricao;
        this.Custo = custo;
    }
}

