
using System;
using System.Collections.Generic;
using System.Linq;
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

    // construtor
    public Cliente(string nome, DateTime dataNascimento, string cpf, string estadoCivil, string profissao)
        : base(nome, dataNascimento, cpf)
    {
        EstadoCivil = estadoCivil;
        Profissao = profissao;
    }
}
    // construtor
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

public class CasoJuridico{
    public string? Status { get; set; }
    public DateTime DataAbertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Advogado>? Advogados { get; set; }
    public List<Documento> Documentos { get; private set; } = new List<Documento>();
    public List<(float Custo, string Descricao)>? Custos { get; set; }
    public DateTime DataEncerramento { get; set; }
    public Cliente? Cliente { get; set; }
    
    public CasoJuridico(DateTime dataAbertura, float probabilidadeSucesso, List<InfoDocumento> infoDocumentos,
                        List<(float Custo, string Descricao)>? custos, DateTime dataEncerramento,
                        List<Advogado>? advogados, Cliente? cliente, string? status)
    {
        
        ProbabilidadeSucesso = probabilidadeSucesso;
        Documentos = infoDocumentos.Select(infoDoc => new Documento(infoDoc)).ToList();
        Custos = custos;
        DataAbertura = dataAbertura;
        DataEncerramento = dataEncerramento;
        Advogados = advogados;
        Cliente = cliente;
        Status = status;
    }

    public void AtualizarStatus(string novoStatus)
    {
        Status = novoStatus;
        Console.WriteLine("Atualizado com sucesso!");
    }

    public void AdicionarDocumento(Documento documento)
    {
        Documentos.Add(documento);
        Console.WriteLine("Documento adicionado ao caso jurídico");
    }

    public void ListarDocumentos()
    {
        Console.WriteLine("Documentos associados ao caso jurídico:");
        foreach (var documento in Documentos)
        {
            ExibirInformacoesDocumento(documento);
            Console.WriteLine();
        }
    }

    public void DeletarDocumento(int codigo)
    {
        try
        {
            var documento = Documentos.Find(d => d.Codigo == codigo);

            if (documento != null)
            {
                Documentos.Remove(documento);
                Console.WriteLine("Documento deletado\n");
            }
            else
            {
                throw new DocumentoNaoEncontradoException();
            }
        }
        catch (DocumentoNaoEncontradoException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    public void ExibirInformacoesDocumento(Documento documento)
    {
        Console.WriteLine($"Código: {documento.Codigo}");
        Console.WriteLine($"Tipo: {documento.Tipo ?? "Indefinido"}");
        Console.WriteLine($"Descrição: {documento.Descricao ?? "Indefinido"}");
        Console.WriteLine($"Data de Modificação: {documento.DataModificacao:dd/MM/yyyy}");
    }

    public void AdicionarCusto(float custo, string descricao)
    {
        Custos ??= new List<(float Custo, string Descricao)>();
        Custos.Add((custo, descricao));
        Console.WriteLine("Custo adicionado ao caso jurídico!");
    }

    public void ListarCustos()
    {
        Console.WriteLine("Custos associados ao caso jurídico:");
        foreach (var custo in Custos)
        {
            Console.WriteLine($"Valor: {custo.Custo}, Descrição: {custo.Descricao}");
        }
    }

    public void DeletarCusto(string descricao)
    {
        try
        {
            var custo = Custos?.Find(c => c.Descricao == descricao);

            if (custo != null)
            {
                Custos?.Remove(custo.Value);
                Console.WriteLine("Custo deletado\n");
            }
            else
            {
                throw new CustoNaoEncontradoException();
            }
        }
        catch (CustoNaoEncontradoException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}
    public class Escritorio
    {
        private List<Advogado> advogados;
        private List<Cliente> clientes;
        private List<Documento> documentos;
        private List<CasoJuridico> casosJuridicos;

        public IReadOnlyList<Advogado> Advogados => advogados.AsReadOnly();
        public IReadOnlyList<Cliente> Clientes => clientes.AsReadOnly();
        public IReadOnlyList<Documento> Documentos => documentos.AsReadOnly();
        public IReadOnlyList<CasoJuridico> CasosJuridicos => casosJuridicos.AsReadOnly();

        public Escritorio()
        {
            advogados = new List<Advogado>();
            clientes = new List<Cliente>();
            documentos = new List<Documento>();
            casosJuridicos = new List<CasoJuridico>();
        }

        public void AdicionarAdvogado(Advogado advogado)
        {
            try
            {
                ValidarAdvogado(advogado);
                advogados.Add(advogado);
                Console.WriteLine("Advogado adicionado com sucesso!");
            }
            catch (RepeatedRegisterAttorneyException ex)
            {
                TratarErro($"Erro ao adicionar advogado: {ex.Message}");
            }
            catch (Exception ex)
            {
                TratarErro($"Erro inesperado: {ex.Message}");
            }
        }

        public void DeletarCasoJuridico(DateTime abertura)
        {
        var casoJuridico = casosJuridicos.Find(c => c.Abertura == abertura);

        if (casoJuridico != null)
        {
            casosJuridicos.Remove(casoJuridico);
            Console.WriteLine("Caso Jurídico deletado com sucesso!");
        }
        else
        {
            Console.WriteLine("Caso Jurídico não encontrado.");
        }
        }

        public void AdicionarCliente(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);
                clientes.Add(cliente);
                Console.WriteLine("Cliente adicionado com sucesso!");
            }
            catch (RepeatedRegisterClientException ex)
            {
                TratarErro($"Erro ao adicionar cliente: {ex.Message}");
            }
            catch (Exception ex)
            {
                TratarErro($"Erro inesperado: {ex.Message}");
            }
        }

        public void ListarAdvogados()
        {
        Console.WriteLine("Lista de Advogados:");
        foreach (var advogado in advogados)
        {
            Console.WriteLine($"Nome: {advogado.Nome}, Data de Nascimento: {advogado.DataNascimento}, CPF: {advogado.CPF}, CNA: {advogado.CNA}");
        }
        Console.WriteLine();
        }

        public void ListarClientes()
        {
        Console.WriteLine("Lista de Clientes:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Data de Nascimento: {cliente.DataNascimento}, CPF: {cliente.CPF}, Estado Civíl: {cliente.EstadoCivil}, Profissão: {cliente.Profissao}");
        }
        }

        public void ListarCasosJuridicos()
        {
        Console.WriteLine("Lista de Casos Jurídicos:");
        foreach (var casoJuridico in casosJuridicos)
        {
            ExibirInformacoesCasoJuridico(casoJuridico);
            Console.WriteLine();
        }
        }
        private void ValidarAdvogado(Advogado advogado)
        {
            if (advogados.Any(a => a.CPF == advogado.CPF) || advogados.Any(a => a.CNA == advogado.CNA))
            {
                throw new RepeatedRegisterAttorneyException();
            }
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (clientes.Any(c => c.CPF == cliente.CPF))
            {
                throw new RepeatedRegisterClientException();
            }
        }

        private void TratarErro(string mensagemErro)
        {
            Console.WriteLine(mensagemErro);
        }

        // Outros métodos auxiliares...
    }



