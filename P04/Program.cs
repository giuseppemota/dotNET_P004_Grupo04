
public class Pessoa{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    // metodo construtor
    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
    }
}
public class Cliente : Pessoa{
    public string EstadoCivil { get; set; }
    public string Profissao { get; set; }

    public Cliente(string nome, DateTime dataNascimento, string cpf, string estadoCivil, string profissao)
        : base(nome, dataNascimento, cpf)
    {
        EstadoCivil = estadoCivil;
        Profissao = profissao;
    }
}
public class Advogado : Pessoa{
    public string CNA { get; set; }

    public Advogado(string nome, DateTime dataNascimento, string cpf, string cna)
        : base(nome, dataNascimento, cpf)
    {
        CNA = cna;
    }
}
public class Documento{
    public DateTime DataDeModificacao { get; set; }
    public int Codigo { get; set;}
    public string? Tipo { get; set; }
    public string? Descricao {get; set;}

    public Documento(DateTime dataDeModificacao, int codigo, string? tipo, string? descricao)
    {
        DataDeModificacao = dataDeModificacao;
        Codigo = codigo;
        Tipo = tipo;
        Descricao = descricao;
    }
}