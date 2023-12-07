
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
    public DateTime DataAbertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> Documentos { get; private set; } = new List<Documento>();
    public List<(float Custo, string Descricao)>? Custos { get; set; }
    public DateTime DataEncerramento { get; set; }
    public List<Advogado>? Advogados { get; set; }
    public Cliente? Cliente { get; set; }
    public string? Status { get; set; }

    public CasoJuridico(DateTime dataAbertura, float probabilidadeSucesso, List<InfoDocumento> infoDocumentos,
                        List<(float Custo, string Descricao)>? custos, DateTime dataEncerramento,
                        List<Advogado>? advogados, Cliente? cliente, string? status)
    {
        DataAbertura = dataAbertura;
        ProbabilidadeSucesso = probabilidadeSucesso;
        Documentos = infoDocumentos.Select(infoDoc => new Documento(infoDoc)).ToList();
        Custos = custos;
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
        Console.WriteLine($"Tipo: {documento.Tipo ?? "N/A"}");
        Console.WriteLine($"Descrição: {documento.Descricao ?? "N/A"}");
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


