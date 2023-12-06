using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Escritorio escritorio = new Escritorio();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Inserir Advogado");
            Console.WriteLine("2. Remover Advogado");
            Console.WriteLine("3. Inserir Cliente");
            Console.WriteLine("4. Remover Cliente");
            Console.WriteLine("5. Inserir Caso Jurídico");
            Console.WriteLine("6. Remover Caso Jurídico");
            Console.WriteLine("7. Iniciar Caso Jurídico");
            Console.WriteLine("8. Atualizar Caso Jurídico");
            Console.WriteLine("9. Listar Advogados");
            Console.WriteLine("10. Listar Clientes");
            Console.WriteLine("11. Listar Casos Jurídicos");
            Console.WriteLine("12. Relatório: Advogados com idade entre dois valores");
            Console.WriteLine("13. Relatório: Clientes com idade entre dois valores");
            Console.WriteLine("14. Relatório: Clientes com estado civil informado pelo usuário");
            Console.WriteLine("15. Relatório: Clientes em ordem alfabética");
            Console.WriteLine("16. Relatório: Clientes cuja profissão contenha texto informado pelo usuário");
            Console.WriteLine("17. Relatório: Advogados e Clientes aniversariantes do mês informado");
            Console.WriteLine("18. Relatório: Casos com o status “Em aberto”, em ordem crescente pela data de início");
            Console.WriteLine("19. Relatório: Advogados em ordem decrescente pela quantidade de casos com status “Concluído”");
            Console.WriteLine("20. Relatório: Casos que possuam custo com uma determinada palavra na descrição");
            Console.WriteLine("21. Relatório: Top 10 tipos de documentos mais inseridos nos casos");
            Console.WriteLine("22. Sair");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    InserirAdvogado();
                    break;
                case 2:
                    RemoverAdvogado();
                    break;
                case 3:
                    InserirCliente();
                    break;
                case 4:
                    RemoverCliente();
                    break;
                case 5:
                    InserirCasoJuridico();
                    break;
                case 6:
                    RemoverCasoJuridico();
                    break;
                case 7:
                    IniciarCasoJuridico();
                    break;
                case 8:
                    AtualizarCasoJuridico();
                    break;
                case 9:
                    ListarAdvogados();
                    break;
                case 10:
                    ListarClientes();
                    break;
                case 11:
                    ListarCasosJuridicos();
                    break;
                case 12:
                    RelatorioAdvogadosComIdade();
                    break;
                case 13:
                    RelatorioClientesComIdade();
                    break;
                case 14:
                    RelatorioClientesComEstadoCivil();
                    break;
                case 15:
                    RelatorioClientesEmOrdemAlfabetica();
                    break;
                case 16:
                    RelatorioClientesComProfissao();
                    break;
                case 17:
                    RelatorioAniversariantesDoMes();
                    break;
                case 18:
                    RelatorioCasosEmAbertoOrdenadosPorDataDeInicio();
                    break;
                case 19:
                    RelatorioAdvogadosPorQuantidadeDeCasosConcluidos();
                    break;
                case 20:
                    RelatorioCasosComCustoDescricaoContendoTexto();
                    break;
                case 21:
                    RelatorioTop10TiposDocumentosMaisInseridos();
                    break;
                // ... (Código anterior)
            }
        }
    }
    static void InserirAdvogado()
    {
        Console.WriteLine("Inserir Advogado:");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Data de Nascimento (dd/mm/yyyy): ");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("CPF (11 dígitos): ");
        string cpf = Console.ReadLine();
        Console.Write("CNA: ");
        string cna = Console.ReadLine();

        Advogado novoAdvogado = new Advogado { Nome = nome, DataNascimento = dataNascimento, CPF = cpf, CNA = cna };
        escritorio.AdicionarAdvogado(novoAdvogado);

        Console.WriteLine("Advogado inserido com sucesso!");
    }

    static void RemoverAdvogado()
    {
        Console.WriteLine("Remover Advogado:");
        Console.Write("CPF do Advogado a ser removido: ");
        string cpf = Console.ReadLine();

        if (escritorio.RemoverAdvogado(cpf))
        {
            Console.WriteLine("Advogado removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Advogado não encontrado.");
        }
    }

    static void InserirCliente()
    {
        Console.WriteLine("Inserir Cliente:");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Data de Nascimento (dd/mm/yyyy): ");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("CPF (11 dígitos): ");
        string cpf = Console.ReadLine();
        Console.Write("Estado Civil: ");
        string estadoCivil = Console.ReadLine();
        Console.Write("Profissão: ");
        string profissao = Console.ReadLine();

        Cliente novoCliente = new Cliente { Nome = nome, DataNascimento = dataNascimento, CPF = cpf, EstadoCivil = estadoCivil, Profissao = profissao };
        escritorio.AdicionarCliente(novoCliente);

        Console.WriteLine("Cliente inserido com sucesso!");
    }

    static void RemoverCliente()
    {
        Console.WriteLine("Remover Cliente:");
        Console.Write("CPF do Cliente a ser removido: ");
        string cpf = Console.ReadLine();

        if (escritorio.RemoverCliente(cpf))
        {
            Console.WriteLine("Cliente removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }

    static void InserirCasoJuridico()
    {
        Console.WriteLine("Inserir Caso Jurídico:");
        Console.Write("Data de Abertura (dd/mm/yyyy): ");
        DateTime abertura = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Probabilidade de Sucesso: ");
        float probabilidadeSucesso = float.Parse(Console.ReadLine());

        CasoJuridico novoCaso = new CasoJuridico
        {
            Abertura = abertura,
            ProbabilidadeSucesso = probabilidadeSucesso,
            Documentos = new List<Documento>(),
            Custos = new List<Custo>(),
            Advogados = new List<Advogado>(),
            Cliente = null,
            Status = "Em aberto"
        };

        escritorio.AdicionarCasoJuridico(novoCaso);

        Console.WriteLine("Caso Jurídico inserido com sucesso!");
    }

    static void RemoverCasoJuridico()
    {
        Console.WriteLine("Remover Caso Jurídico:");
        Console.Write("ID do Caso Jurídico a ser removido: ");
        int idCaso = int.Parse(Console.ReadLine());

        if (escritorio.RemoverCasoJuridico(idCaso))
        {
            Console.WriteLine("Caso Jurídico removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Caso Jurídico não encontrado.");
        }
    }

    static void IniciarCasoJuridico()
    {
        Console.WriteLine("Iniciar Caso Jurídico:");
        Console.Write("ID do Caso Jurídico a ser iniciado: ");
        int idCaso = int.Parse(Console.ReadLine());

        if (escritorio.IniciarCasoJuridico(idCaso))
        {
            Console.WriteLine("Caso Jurídico iniciado com sucesso!");
        }
        else
        {
            Console.WriteLine("Caso Jurídico não encontrado ou já iniciado.");
        }
    }

    static void AtualizarCasoJuridico()
    {
        Console.WriteLine("Atualizar Caso Jurídico:");
        Console.Write("ID do Caso Jurídico a ser atualizado: ");
        int idCaso = int.Parse(Console.ReadLine());

        if (escritorio.AtualizarCasoJuridico(idCaso))
        {
            Console.WriteLine("Caso Jurídico atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Caso Jurídico não encontrado ou não pode ser atualizado.");
        }
    }

    static void ListarAdvogados()
    {
        Console.WriteLine("Lista de Advogados:");
        foreach (Advogado advogado in escritorio.ListarAdvogados())
        {
            Console.WriteLine($"Nome: {advogado.Nome}, CPF: {advogado.CPF}, CNA: {advogado.CNA}");
        }
    }

    static void ListarClientes()
    {
        Console.WriteLine("Lista de Clientes:");
        foreach (Cliente cliente in escritorio.ListarClientes())
        {
            Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.CPF}, Profissão: {cliente.Profissao}");
        }
    }

    static void ListarCasosJuridicos()
    {
        Console.WriteLine("Lista de Casos Jurídicos:");
        foreach (CasoJuridico caso in escritorio.ListarCasosJuridicos())
        {
            Console.WriteLine($"ID: {caso.Id}, Cliente: {caso.Cliente?.Nome}, Status: {caso.Status}");
        }
    }

        static void RelatorioAdvogadosComIdade()
    {
        Console.WriteLine("Relatório: Advogados com idade entre dois valores");
        Console.Write("Idade Mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine());
        Console.Write("Idade Máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine());

        List<Advogado> advogadosRelatorio = escritorio.AdvogadosComIdadeEntre(idadeMinima, idadeMaxima);

        Console.WriteLine("\nAdvogados encontrados:");
        foreach (Advogado advogado in advogadosRelatorio)
        {
            Console.WriteLine($"Nome: {advogado.Nome}, Idade: {(DateTime.Now - advogado.DataNascimento).Days / 365} anos");
        }
        Console.WriteLine();
    }

    static void RelatorioClientesComIdade()
    {
        Console.WriteLine("Relatório: Clientes com idade entre dois valores");
        Console.Write("Idade Mínima: ");
        int idadeMinima = int.Parse(Console.ReadLine());
        Console.Write("Idade Máxima: ");
        int idadeMaxima = int.Parse(Console.ReadLine());

        List<Cliente> clientesRelatorio = escritorio.ClientesComIdadeEntre(idadeMinima, idadeMaxima);

        Console.WriteLine("\nClientes encontrados:");
        foreach (Cliente cliente in clientesRelatorio)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Idade: {(DateTime.Now - cliente.DataNascimento).Days / 365} anos");
        }
        Console.WriteLine();
    }

    static void RelatorioClientesComEstadoCivil()
    {
        Console.WriteLine("Relatório: Clientes com estado civil informado pelo usuário");
        Console.Write("Informe o estado civil: ");
        string estadoCivil = Console.ReadLine();

        List<Cliente> clientesRelatorio = escritorio.ClientesComEstadoCivil(estadoCivil);

        Console.WriteLine("\nClientes encontrados:");
        foreach (Cliente cliente in clientesRelatorio)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Estado Civil: {cliente.EstadoCivil}");
        }
        Console.WriteLine();
    }

    static void RelatorioClientesEmOrdemAlfabetica()
    {
        Console.WriteLine("Relatório: Clientes em ordem alfabética");

        List<Cliente> clientesRelatorio = escritorio.ClientesEmOrdemAlfabetica();

        Console.WriteLine("\nClientes em ordem alfabética:");
        foreach (Cliente cliente in clientesRelatorio)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
        }
        Console.WriteLine();
    }

    static void RelatorioClientesComProfissao()
    {
        Console.WriteLine("Relatório: Clientes cuja profissão contenha texto informado pelo usuário");
        Console.Write("Informe o texto da profissão: ");
        string textoProfissao = Console.ReadLine();

        List<Cliente> clientesRelatorio = escritorio.ClientesComProfissaoContendoTexto(textoProfissao);

        Console.WriteLine("\nClientes encontrados:");
        foreach (Cliente cliente in clientesRelatorio)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Profissão: {cliente.Profissao}");
        }
        Console.WriteLine();
    }

    static void RelatorioAniversariantesDoMes()
    {
        Console.WriteLine("Relatório: Advogados e Clientes aniversariantes do mês informado");
        Console.Write("Informe o mês (número): ");
        int mes = int.Parse(Console.ReadLine());

        List<Pessoa> aniversariantesRelatorio = escritorio.AniversariantesDoMes(mes);

        Console.WriteLine("\nAniversariantes do mês:");
        foreach (Pessoa pessoa in aniversariantesRelatorio)
        {
            Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataNascimento.ToString("dd/MM")}");
        }
        Console.WriteLine();
    }

    static void RelatorioCasosEmAbertoOrdenadosPorDataDeInicio()
    {
        Console.WriteLine("Relatório: Casos com o status 'Em aberto', em ordem crescente pela data de início");

        List<CasoJuridico> casosRelatorio = escritorio.CasosEmAbertoOrdenadosPorDataDeInicio();

        Console.WriteLine("\nCasos em aberto ordenados por data de início:");
        foreach (CasoJuridico caso in casosRelatorio)
        {
            Console.WriteLine($"ID: {caso.Id}, Cliente: {caso.Cliente?.Nome}, Data de Abertura: {caso.Abertura.ToString("dd/MM/yyyy")}");
        }
        Console.WriteLine();
    }

    static void RelatorioAdvogadosPorQuantidadeDeCasosConcluidos()
    {
        Console.WriteLine("Relatório: Advogados em ordem decrescente pela quantidade de casos com status 'Concluído'");

        List<Advogado> advogadosRelatorio = escritorio.AdvogadosPorQuantidadeDeCasosConcluidos();

        Console.WriteLine("\nAdvogados em ordem decrescente pela quantidade de casos concluídos:");
        foreach (Advogado advogado in advogadosRelatorio)
        {
            int quantidadeCasosConcluidos = escritorio.ListarCasosJuridicos()
                .Count(c => c.Advogados.Contains(advogado) && c.Status == "Concluído");

            Console.WriteLine($"Nome: {advogado.Nome}, Casos Concluídos: {quantidadeCasosConcluidos}");
        }
        Console.WriteLine();
    }

    static void RelatorioCasosComCustoDescricaoContendoTexto()
    {
        Console.WriteLine("Relatório: Casos que possuam custo com uma determinada palavra na descrição");
        Console.Write("Informe o texto da descrição do custo: ");
        string textoDescricaoCusto = Console.ReadLine();

        List<CasoJuridico> casosRelatorio = escritorio.CasosComCustoDescricaoContendoTexto(textoDescricaoCusto);

        Console.WriteLine("\nCasos que possuem custo com a descrição informada:");
        foreach (CasoJuridico caso in casosRelatorio)
        {
            Console.WriteLine($"ID: {caso.Id}, Cliente: {caso.Cliente?.Nome}, Descrição do Custo: {textoDescricaoCusto}");
        }
        Console.WriteLine();
    }

    static void RelatorioTop10TiposDocumentosMaisInseridos()
    {
        Console.WriteLine("Relatório: Top 10 tipos de documentos mais inseridos nos casos");

        List<string> tiposDocumentosRelatorio = escritorio.Top10TiposDocumentosMaisInseridos();

        Console.WriteLine("\nTop 10 tipos de documentos mais inseridos:");
        for (int i = 0; i < tiposDocumentosRelatorio.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tiposDocumentosRelatorio[i]}");
        }
        Console.WriteLine();
    }
}

class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}

class Advogado : Pessoa
{
    public string CNA { get; set; }
}

class Cliente : Pessoa
{
    public string EstadoCivil { get; set; }
    public string Profissao { get; set; }
}

class Documento
{
    public DateTime DataHoraModificacao { get; set; }
    public int Codigo { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }
}

class Custo
{
    public float Valor { get; set; }
    public string Descricao { get; set; }
}

class CasoJuridico
{
    private static int proximoId = 1;

    public int Id { get; }
    public DateTime Abertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> Documentos { get; set; }
    public List<Custo> Custos { get; set; }
    public DateTime Encerramento { get; set; }
    public List<Advogado> Advogados { get; set; }
    public Cliente Cliente { get; set; }
    public string Status { get; set; }

    public CasoJuridico()
    {
        Id = proximoId++;
    }
}

class Escritorio
{
    private List<Advogado> advogados = new List<Advogado>();
    private List<Cliente> clientes = new List<Cliente>();
    private List<CasoJuridico> casosJuridicos = new List<CasoJuridico>();

    public void AdicionarAdvogado(Advogado advogado)
    {
        advogados.Add(advogado);
    }

    public bool RemoverAdvogado(string cpf)
    {
        Advogado advogadoParaRemover = advogados.Find(a => a.CPF == cpf);
        if (advogadoParaRemover != null)
        {
            advogados.Remove(advogadoParaRemover);
            return true;
        }
        return false;
    }

    public void AdicionarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public bool RemoverCliente(string cpf)
    {
        Cliente clienteParaRemover = clientes.Find(c => c.CPF == cpf);
        if (clienteParaRemover != null)
        {
            clientes.Remove(clienteParaRemover);
            return true;
        }
        return false;
    }

    public void AdicionarCasoJuridico(CasoJuridico casoJuridico)
    {
        casosJuridicos.Add(casoJuridico);
    }

    public bool RemoverCasoJuridico(int id)
    {
        CasoJuridico casoParaRemover = casosJuridicos.Find(c => c.Id == id);
        if (casoParaRemover != null)
        {
            casosJuridicos.Remove(casoParaRemover);
            return true;
        }
        return false;
    }

    public List<Advogado> ListarAdvogados()
    {
        return advogados;
    }

    public List<Cliente> ListarClientes()
    {
        return clientes;
    }

    public List<CasoJuridico> ListarCasosJuridicos()
    {
        return casosJuridicos;
    }

    public bool IniciarCasoJuridico(int id)
    {
        CasoJuridico caso = casosJuridicos.Find(c => c.Id == id && c.Status == "Em aberto");
        if (caso != null)
        {
            caso.Status = "Iniciado";
            return true;
        }
        return false;
    }

    public bool AtualizarCasoJuridico(int id)
    {
        CasoJuridico caso = casosJuridicos.Find(c => c.Id == id && c.Status == "Iniciado");
        if (caso != null)
        {
            Console.Write("Data de Encerramento (dd/mm/yyyy): ");
            DateTime encerramento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            if (encerramento > caso.Abertura)
            {
                caso.Encerramento = encerramento;
                caso.Status = "Concluído";
                return true;
            }
            else
            {
                Console.WriteLine("A data de encerramento deve ser posterior à data de abertura.");
            }
        }
        return false;
    }

public List<Advogado> AdvogadosComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        return advogados
            .Where(a => CalcularIdade(a.DataNascimento) >= idadeMinima && CalcularIdade(a.DataNascimento) <= idadeMaxima)
            .ToList();
    }

    public List<Cliente> ClientesComIdadeEntre(int idadeMinima, int idadeMaxima)
    {
        return clientes
            .Where(c => CalcularIdade(c.DataNascimento) >= idadeMinima && CalcularIdade(c.DataNascimento) <= idadeMaxima)
            .ToList();
    }

    public List<Cliente> ClientesComEstadoCivil(string estadoCivil)
    {
        return clientes
            .Where(c => c.EstadoCivil.Equals(estadoCivil, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Cliente> ClientesEmOrdemAlfabetica()
    {
        return clientes.OrderBy(c => c.Nome).ToList();
    }

    public List<Cliente> ClientesComProfissaoContendoTexto(string textoProfissao)
    {
        return clientes
            .Where(c => c.Profissao.Contains(textoProfissao, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

  public List<Pessoa> AniversariantesDoMes(int mes)
{
    var aniversariantes = advogados
        .Where(a => a.DataNascimento.Month == mes)
        .Cast<Pessoa>()
        .Concat(clientes.Where(c => c.DataNascimento.Month == mes))
        .ToList();

    return aniversariantes;
}
    public List<CasoJuridico> CasosEmAbertoOrdenadosPorDataDeInicio()
    {
        return casosJuridicos
            .Where(c => c.Status == "Em aberto")
            .OrderBy(c => c.Abertura)
            .ToList();
    }

    public List<Advogado> AdvogadosPorQuantidadeDeCasosConcluidos()
    {
        return advogados
            .OrderByDescending(a => casosJuridicos.Count(c => c.Advogados.Contains(a) && c.Status == "Concluído"))
            .ToList();
    }

    public List<CasoJuridico> CasosComCustoDescricaoContendoTexto(string textoDescricaoCusto)
    {
        return casosJuridicos
            .Where(c => c.Custos.Any(custo => custo.Descricao.Contains(textoDescricaoCusto, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

    public List<string> Top10TiposDocumentosMaisInseridos()
    {
        var documentos = casosJuridicos.SelectMany(c => c.Documentos).ToList();
        var tiposDocumentos = documentos.GroupBy(d => d.Tipo).OrderByDescending(g => g.Count()).Take(10);

        return tiposDocumentos.Select(g => g.Key).ToList();
    }

    private int CalcularIdade(DateTime dataNascimento)
    {
        return (int)((DateTime.Now - dataNascimento).Days / 365.25);
    }
}

