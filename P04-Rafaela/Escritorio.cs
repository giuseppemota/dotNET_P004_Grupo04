namespace P004;
public class Escritorio
{
    public List<Advogado> Advogados { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<CasoJuridico> CasosJuridicos { get; set; }

    public Escritorio()
    {
        Advogados = new List<Advogado>();
        Clientes = new List<Cliente>();
        CasosJuridicos = new List<CasoJuridico>();
    }

    public void InserirAdvogado(Advogado advogado)
    {
        Advogados.Add(advogado);
    }

    public void RemoverAdvogado(Advogado advogado)
    {
        Advogados.Remove(advogado);
    }

    public void InserirCliente(Cliente cliente)
    {
        Clientes.Add(cliente);
    }

    public void RemoverCliente(Cliente cliente)
    {
        Clientes.Remove(cliente);
    }

    public void InserirCaso(CasoJuridico caso)
    {
        CasosJuridicos.Add(caso);
    }

    public void RemoverCaso(CasoJuridico caso)
    {
        CasosJuridicos.Remove(caso);
    }

    public List<Advogado> AdvogadosEntreIdades(int idadeMin, int idadeMax)
    {
        DateTime dataLimiteSuperior = DateTime.Now.AddYears(-idadeMin);
        DateTime dataLimiteInferior = DateTime.Now.AddYears(-idadeMax);

        return Advogados.Where(advogado => advogado.DataNascimento <= dataLimiteInferior && advogado.DataNascimento >= dataLimiteSuperior).ToList();
    }
    public List<Cliente> ClientesEntreIdades(int idadeMin, int idadeMax)
    {
        DateTime dataLimiteSuperior = DateTime.Now.AddYears(-idadeMin);
        DateTime dataLimiteInferior = DateTime.Now.AddYears(-idadeMax);

        return Clientes
            .Where(cliente => cliente.DataNascimento <= dataLimiteInferior && cliente.DataNascimento >= dataLimiteSuperior)
            .ToList();
    }
    public List<Cliente> ClientesComEstadoCivil(string estadoCivil)
    {
        return Clientes
            .Where(cliente => cliente.EstadoCivil.Equals(estadoCivil, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    public List<Cliente> ClientesOrdemAlfabetica()
    {
        return Clientes
            .OrderBy(cliente => cliente.Nome)
            .ToList();
    }
    public List<Cliente> ClientesPorProfissao(string textoProfissao)
    {
        return Clientes
            .Where(cliente => cliente.Profissao.Contains(textoProfissao, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    public List<Pessoa> AniversariantesDoMes(int mes)
{
    IEnumerable<Pessoa> aniversariantesAdvogados = Advogados
        .Where(advogado => advogado.DataNascimento.Month == mes)
        .Select(advogado => (Pessoa)advogado);

    IEnumerable<Pessoa> aniversariantesClientes = Clientes
        .Where(cliente => cliente.DataNascimento.Month == mes)
        .Select(cliente => (Pessoa)cliente);

    return aniversariantesAdvogados
        .Union(aniversariantesClientes)
        .OrderBy(pessoa => pessoa.DataNascimento.Day)
        .ThenBy(pessoa => pessoa.Nome)
        .ToList();
}
    public List<CasoJuridico> CasosEmAbertoOrdenadosPorData()
    {
        return CasosJuridicos
            .Where(caso => caso.Status == "Em aberto")
            .OrderBy(caso => caso.Abertura)
            .ToList();
    }
    public List<Advogado> AdvogadosPorQuantidadeCasosConcluidos()
    {
        return Advogados
            .OrderByDescending(advogado => CasosJuridicos.Count(caso => caso.Advogados.Contains(advogado) && caso.Status == "Concluído"))
            .ToList();
    }

    public List<CasoJuridico> CasosComCustoDescricao(string palavraDescricao)
    {
        return CasosJuridicos
            .Where(caso => caso.Custos.Any(custo => custo.Item2.Contains(palavraDescricao, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

public List<string?> Top10TiposDocumentosMaisInseridos()
{
    return CasosJuridicos
        .SelectMany(caso => caso.Documentos.Select(documento => documento?.Tipo))
        .Where(tipo => tipo != null)
        .GroupBy(tipo => tipo)
        .OrderByDescending(group => group.Count())
        .Take(10)
        .Select(group => group.Key)
        .ToList();
}

}