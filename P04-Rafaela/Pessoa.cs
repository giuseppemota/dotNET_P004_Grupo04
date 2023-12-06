namespace P004;

public class Pessoa
{
    public string? Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? CPF { get; set; }

    public int Idade
    {
        get
        {
            return (int)((DateTime.Now - DataNascimento).TotalDays / 365.25);
        }
    }
}
