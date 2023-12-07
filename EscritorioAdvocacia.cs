
namespace P004;

public class EscritorioAdvocacia
{
    public List<Cliente> Clientes { get; set; } = new();
    public List<Advogado> Advogados { get; set; } = new();
    public List<Documento> Documentos { get; set; } = new();
    public List<CasoJuridico> CasosJuridicos { get; set; } = new();

    public List<PlanoDeConsultoria> PlanosDeConsultoria { get; set; } = new();

    public EscritorioAdvocacia()
    {
        var cliente1 = new Cliente
        {
            Nome = "João",
            CPF = "123.456.789-00",
            DataNascimento = new DateTime(1980, 1, 1),
            EstadoCivil = "Casado",
            Profissao = "Programador"
        };

        var cliente2 = new Cliente
        {
            Nome = "Maria",
            CPF = "987.654.321-00",
            DataNascimento = new DateTime(1985, 2, 1),
            EstadoCivil = "Solteiro",
            Profissao = "Programadora"
        };

        Clientes.Add(cliente1);
        Clientes.Add(cliente2);

        var advogado1 = new Advogado
        {
            Nome = "José",
            CPF = "123.456.789-00",
            DataNascimento = new DateTime(1980, 1, 1),
            CNA = "123456"
        };

        var advogado2 = new Advogado
        {
            Nome = "Maria",
            CPF = "987.654.321-00",
            DataNascimento = new DateTime(1985, 2, 1),
            CNA = "654321"
        };

        Advogados.Add(advogado1);
        Advogados.Add(advogado2);

        var documento1 = new Documento
        {
            DataModificacao = DateTime.Now,
            Descricao = "Documento 1",
            Tipo = "Tipo 1",
            Codigo = "123456"
        };

        var documento2 = new Documento
        {
            DataModificacao = DateTime.Now,
            Descricao = "Documento 2",
            Tipo = "Tipo 2",
            Codigo = "654321"
        };

        Documentos.Add(documento1);
        Documentos.Add(documento2);

        var casoJuridico1 = new CasoJuridico
        {
            Status = "Aberto",
            ProbabilidadeDeSucesso = 0.5f,
            ClienteDoCaso = cliente1,
            Advogados = new List<Advogado> { advogado1, advogado2 },
            Documentos = new List<Documento> { documento1, documento2 }
        };

        var casoJuridico2 = new CasoJuridico
        {
            Status = "Aberto",
            ProbabilidadeDeSucesso = 0.5f,
            ClienteDoCaso = cliente2,
            Advogados = new List<Advogado> { advogado2, advogado1 },
            Documentos = new List<Documento> { documento2 }
        };

        CasosJuridicos.Add(casoJuridico1);
        CasosJuridicos.Add(casoJuridico2);

        var custo1 = new CustoItem
        {
            Custo = 1000,
            Descricao = "Custo 1"
        };

        var custo2 = new CustoItem
        {
            Custo = 2000,
            Descricao = "Custo 2"
        };

        casoJuridico1.Custos = new List<CustoItem> { custo1 };
        casoJuridico2.Custos = new List<CustoItem> { custo2 };

        var casoJuridico3 = new CasoJuridico
        {
            Status = "Concluído",
            ProbabilidadeDeSucesso = 0.5f,
            ClienteDoCaso = cliente2,
            Advogados = new List<Advogado> { advogado2 },
            Documentos = new List<Documento> { documento2 },
            Encerramento = DateTime.Now
        };

        CasosJuridicos.Add(casoJuridico3);
    }

    internal void AdicionarCliente(string nome, string cpf, DateTime dataNascimento, string estadoCivil, string profissao)
    {
        if (Clientes.Any(c => c.CPF == cpf))
        {
            throw new Exception("CPF já cadastrado");
        }
        var cliente = new Cliente
        {
            Nome = nome,
            CPF = cpf,
            DataNascimento = dataNascimento,
            EstadoCivil = estadoCivil,
            Profissao = profissao
        };

        Clientes.Add(cliente);
    }

    internal void AdicionarCliente (Cliente cliente)
    {
        if (Clientes.Any(c => c.CPF == cliente.CPF))
        {
            throw new Exception("CPF já cadastrado");
        }
        Clientes.Add(cliente);
    }

    public void AdicionarAdvogado(string nome, string cpf, DateTime dataNascimento, string cna)
    {
        if (Advogados.Any(a => a.CNA == cna))
        {
            throw new Exception("CNA já cadastrado");
        }
        var advogado = new Advogado
        {
            Nome = nome,
            CPF = cpf,
            DataNascimento = dataNascimento,
            CNA = cna
        };

        Advogados.Add(advogado);
    }

    public void AdicionarAdvogado(Advogado advogado)
    {
        if (Advogados.Any(a => a.CNA == advogado.CNA))
        {
            throw new Exception("CNA já cadastrado");
        }
        Advogados.Add(advogado);
    }

    internal void ListarClientes()
    {
        foreach (var cliente in Clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"CPF: {cliente.CPF}");
            Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"Estado Civil: {cliente.EstadoCivil}");
            Console.WriteLine($"Profissão: {cliente.Profissao}");
            Console.WriteLine($"Idade: {cliente.Idade}");
            Console.WriteLine();
        }
    }

    internal void ListarAdvogados()
    {
        foreach (var advogado in Advogados)
        {
            Console.WriteLine($"Nome: {advogado.Nome}");
            Console.WriteLine($"CPF: {advogado.CPF}");
            Console.WriteLine($"Data de Nascimento: {advogado.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"CNA: {advogado.CNA}");
            Console.WriteLine($"Idade: {advogado.Idade}");
            Console.WriteLine();
        }
    }

    internal void AdicionarDocumento(string descricao, string tipo, string codigo)
    {
        if (Documentos.Any(d => d.Codigo == codigo))
        {
            throw new Exception("Código já cadastrado");
        }
        var documento = new Documento
        {
            DataModificacao = DateTime.Now,
            Descricao = descricao,
            Tipo = tipo,
            Codigo = codigo
        };

        Documentos.Add(documento);
    }

    internal void ListarDocumentos()
    {
        foreach (var documento in Documentos)
        {
            Console.WriteLine($"Data de Modificação: {documento.DataModificacao}");
            Console.WriteLine($"Descrição: {documento.Descricao}");
            Console.WriteLine($"Tipo: {documento.Tipo}");
            Console.WriteLine($"Código: {documento.Codigo}");
            Console.WriteLine();
        }
    }

    internal Cliente? ProcurarCliente(string cpf){
        return Clientes.FirstOrDefault(c => c.CPF == cpf);
    }

    internal Advogado? ProcurarAdvogado(string cna){
        return Advogados.FirstOrDefault(a => a.CNA == cna);
    }

    internal Documento? ProcurarDocumento(string codigo){
        return Documentos.FirstOrDefault(d => d.Codigo == codigo);
    }

    internal void AdicionarCasoJuridico(float probabilidadeDeSucesso, Cliente clienteDoCaso, List<Advogado> advogados, List<Documento>? documentos)
    {
        var casoJuridico = new CasoJuridico
        {
            Status = "Aberto",
            ProbabilidadeDeSucesso = probabilidadeDeSucesso,
            ClienteDoCaso = clienteDoCaso,
            Advogados = advogados,
            Documentos = documentos
        };

        CasosJuridicos.Add(casoJuridico);
    }

    internal void ListarCasosJuridicos()
    {
        foreach (var casoJuridico in CasosJuridicos)
        {
            Console.WriteLine($"---------------------------------------------------------");
            Console.WriteLine($"ID: {casoJuridico.ID}");
            Console.WriteLine($"Abertura: {casoJuridico.Abertura.ToShortDateString()}");
            Console.WriteLine($"Encerramento: {casoJuridico.Encerramento?.ToShortDateString()}");
            Console.WriteLine($"Cliente do Caso: {casoJuridico.ClienteDoCaso?.CPF}");
            Console.WriteLine($"Probabilidade de Sucesso: {casoJuridico.ProbabilidadeDeSucesso}");
            Console.WriteLine($"Status: {casoJuridico.Status}");
            Console.WriteLine($"Custo Total:{casoJuridico.Custos?.Sum(c => c.Custo)}");
            Console.WriteLine();
            if (casoJuridico.Advogados != null){
                Console.WriteLine();
                Console.WriteLine("Advogados: ");
                foreach (var advogado in casoJuridico.Advogados)
                {
                    Console.WriteLine($"CNA: {advogado.CNA}");
                    Console.WriteLine($"Nome: {advogado.Nome}");
                }
                Console.WriteLine();
            }
            if (casoJuridico.Documentos != null){
                Console.WriteLine();
                Console.WriteLine("Documentos: ");
                foreach (var documento in casoJuridico.Documentos)
                {
                    Console.WriteLine($"Código: {documento.Codigo}");
                    Console.WriteLine($"Descrição: {documento.Descricao}");
                }
                Console.WriteLine();
            }

            if (casoJuridico.Custos != null){
                Console.WriteLine();
                Console.WriteLine("Custos: ");
                foreach (var custo in casoJuridico.Custos)
                {
                    Console.WriteLine($"Custo: {custo.Custo}");
                    Console.WriteLine($"Descrição: {custo.Descricao}");
                }
                Console.WriteLine();
            }

        }
    }

    internal void AtualizarDocumento(string codigo, string? descricao, string? tipo)
    {
        var documento = this.ProcurarDocumento(codigo);
        if (documento != null)
        {
            documento.DataModificacao = DateTime.Now;
            documento.Descricao = descricao;
            documento.Tipo = tipo;
        }
    }

    internal CasoJuridico? ProcurarCasoJuridico(int id)
    {
        return CasosJuridicos.FirstOrDefault(c => c.ID == id);
    }

    internal void AdicionarCusto(int id, float custo, string? descricao)
    {
        var casoJuridico = this.ProcurarCasoJuridico(id);
        if (casoJuridico != null)
        {
            var custoItem = new CustoItem
            {
                Custo = custo,
                Descricao = descricao
            };

            if (casoJuridico.Custos == null)
            {
                casoJuridico.Custos = new List<CustoItem>();
            }

            casoJuridico.Custos.Add(custoItem);
        }
    }

    internal void ListarCustos(int id)
    {
        var casoJuridico = this.ProcurarCasoJuridico(id);
        if (casoJuridico != null)
        {
            if (casoJuridico.Custos != null)
            {
                foreach (var custo in casoJuridico.Custos)
                {
                    Console.WriteLine($"Custo: {custo.Custo}");
                    Console.WriteLine($"Descrição: {custo.Descricao}");
                    Console.WriteLine();
                }
            }
        }
    }

    internal void AtualizarCasoJuridico(int id, string? status, float? probabilidadeDeSucesso)
    {
        var casoJuridico = this.ProcurarCasoJuridico(id);
        if (casoJuridico != null)
        {
            casoJuridico.Status = status;
            casoJuridico.ProbabilidadeDeSucesso = probabilidadeDeSucesso ?? casoJuridico.ProbabilidadeDeSucesso;
        }
    }

    internal void EncerrarCasoJuridico(int id)
    {
        var casoJuridico = this.ProcurarCasoJuridico(id);
        if (casoJuridico != null)
        {
            casoJuridico.Encerramento = DateTime.Now;
        }
    }

    internal void AdicionarAdvogadoAoCasoJuridico(int id, Advogado advogado)
    {
        var casoJuridico = this.ProcurarCasoJuridico(id);
        if (casoJuridico != null)
        {
            if (casoJuridico.Advogados == null)
            {
                casoJuridico.Advogados = new List<Advogado>();
            }

            casoJuridico.Advogados.Add(advogado);
        }
    }

    internal void AdicionarDocumentoAoCasoJuridico(int id, Documento documento)
    {
        var casoJuridico = this.ProcurarCasoJuridico(id);
        if (casoJuridico != null)
        {
            if (casoJuridico.Documentos == null)
            {
                casoJuridico.Documentos = new List<Documento>();
            }

            casoJuridico.Documentos.Add(documento);
        }
    }

    internal List<Advogado> AdvogadoEntreIdades(int idadeMinima, int idadeMaxima)
    {
        return Advogados.Where(a => a.Idade >= idadeMinima && a.Idade <= idadeMaxima).ToList();
    }

    internal List<Cliente> ClienteEntreIdades(int idadeMinima, int idadeMaxima)
    {
        return Clientes.Where(c => c.Idade >= idadeMinima && c.Idade <= idadeMaxima).ToList();;
    }

    internal List<Cliente> ClientePorEstadoCivil(string estadoCivil)
    {
        estadoCivil = estadoCivil.ToLower();
        return Clientes.Where(c => c.EstadoCivil.ToLower() == estadoCivil).ToList();;
    }

    internal List<Cliente> ClienteOrdemAlfabetica()
    {
        return Clientes.OrderBy(c => c.Nome).ToList();;
    }

    internal List<Cliente> ClienteComProfissao(string profissao)
    {
        return Clientes.Where(c => c.Profissao.ToLower().Contains(profissao.ToLower())).ToList();;
    }

    internal List<Advogado> AdvogadoClienteNiver(int mes)
    {
        return Advogados.Where(a => a.DataNascimento.Month == mes).ToList();;
    }

    internal List<CasoJuridico> CasosAbertos()
    {
        return CasosJuridicos.Where(c => c.Status == "Aberto").OrderBy(c => c.Abertura).ToList();;
    }

    internal List<(Advogado, int)> AdvogadosMaisCasosConcluidos()
    {
        var casosConcluidos = CasosJuridicos.Where(c => c.Status == "Concluído");

        var advogadosComCasosConcluidos = casosConcluidos
            .SelectMany(caso => caso.Advogados)
            .GroupBy(advogado => advogado.CNA)
            .Select(group => (group.First(), group.Count()))
            .OrderByDescending(a => a.Item2)
            .ToList();

        return advogadosComCasosConcluidos;

    }

    internal List<CasoJuridico> PesquisaDescricaoCustoCaso(string descricao)
    {
        return CasosJuridicos.Where(c => c.Custos != null && c.Custos.Any(c => c.Descricao?.ToLower().Contains(descricao.ToLower()) ?? false)).ToList();
    }

    internal List<Documento> Top10Documentos()
    {
        var documentos = CasosJuridicos.SelectMany(c => c.Documentos);

        var documentosMaisInseridos = documentos
            .GroupBy(d => d.Codigo)
            .Select(group => (group.First(), group.Count()))
            .OrderByDescending(d => d.Item2)
            .Take(10)
            .Select(d => d.Item1)
            .ToList();

        return documentosMaisInseridos;
    }

    internal void AdicionarPlanoConsultoria(string titulo, double mensalidade, List<string> beneficios)
    {
        var plano = new PlanoDeConsultoria(titulo, mensalidade, beneficios);

        PlanosDeConsultoria.Add(plano);
    }

    internal PlanoDeConsultoria ProcurarPlanoPorTitulo(string tituloPlano)
    {
    return PlanosDeConsultoria.FirstOrDefault(plano => plano.Titulo.Equals(tituloPlano, StringComparison.OrdinalIgnoreCase));
    }

}