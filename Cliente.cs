namespace P004;
public class Cliente : Pessoa
{
    protected bool _EstadoCivil;

    protected string? _Profissao;


    public Cliente(string? nome, string? cpf, DateTime dataNascimento, bool estadoCivil, string? profissao)
        : base(nome, cpf, dataNascimento)
    {
        EstadoCivil = estadoCivil;
        Profissao = profissao;
    }
    public bool EstadoCivil
    {
        get { return _EstadoCivil; }
        set { _EstadoCivil = value; }
    }

    public string? Profissao
    {
        get { return _Profissao; }
        set { _Profissao = value; }
    }
}
