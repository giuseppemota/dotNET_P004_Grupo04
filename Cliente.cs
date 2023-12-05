namespace ProvaIndividual;
public class Cliente : Pessoa
{
    protected bool _EstadoCivil;

    protected string? _Profissao;

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
