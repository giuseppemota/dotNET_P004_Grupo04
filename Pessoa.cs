namespace ProvaIndividual;
public abstract class Pessoa
{

    protected string? _Cpf;
    protected DateTime _DataNascimento;
    protected string? _Nome;
    public string? Nome { get; set; }

    public int Idade => DateTime.Now.Year - DataNascimento.Year;
    public string? Cpf
    {
        get {return _Cpf;}
        set
        {
            if (value?.Length != 11 || !value.All(char.IsDigit))
            { throw new Exception("Cpf inválido"); }
            else _Cpf = value;
        }
    }
    public DateTime DataNascimento
    {
        get
        {return _DataNascimento;}
        set
        {
            if (value > DateTime.Now)
            {
                throw new Exception("Data de nascimento inválida");
            }
            else
            {
                _DataNascimento = value;
            }
        }
    }
}
