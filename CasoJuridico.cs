namespace P004;

public class CasoJuridico
{
    public DateTime Abertura { get; set; }
    public DateTime Encerramento { get; set; }
    public float ProbabilidadeDeSucesso { get; set; }
    public Cliente? ClienteDoCaso { get; set; }
    public string? Status { get; set; }
    public List<Advogado>? Advogados { get; set; }
    public List<Documento>? Documentos { get; set; }
    public List<CustoItem>? Custos { get; set; }


    public void criarCaso(List<CasoJuridico> casos, List<Cliente> clientes, List<Advogado> advogados)
    {

        DateTime abertura = DateTime.Now;

        Console.WriteLine("Informe a probabilidade de sucesso do caso (0-100): ");
        float probabilidade = float.Parse(Console.ReadLine()!);

        // Supondo que ClienteDoCaso seja um objeto Cliente
        Console.WriteLine("Escolha o cliente do caso: ");
        Cliente clienteDoCaso = EscritorioAdvocacia.EscolherCliente(clientes);



        string status = EscritorioAdvocacia.ObterStatus();

        CasoJuridico novoCaso = new CasoJuridico
        {
            Abertura = abertura,
            ProbabilidadeDeSucesso = probabilidade,
            ClienteDoCaso = clienteDoCaso,
            Status = status,
            Advogados = new List<Advogado>(),
            Documentos = new List<Documento>(),
            Custos = new List<CustoItem>()
        };
        System.Console.WriteLine("Escolha o advogado do caso: ");
        Advogado advogadoDoCaso = EscritorioAdvocacia.EscolherAdvogado(advogados);
        this.Advogados?.Add(advogadoDoCaso);



        casos.Add(novoCaso);
        Console.WriteLine("Novo caso criado com sucesso!");
    }

    public void AdicionarDocumento(List<CasoJuridico> casos)
    {
        Console.WriteLine("Escolha o caso que deseja adicionar o documento: ");
        CasoJuridico caso = EscolherCaso(casos);

        do
        {
            try
            {
                Console.WriteLine("Escolha o tipo de documento: ");
                string tipo = Console.ReadLine()!;

                Console.WriteLine("Digite a descrição do documento: ");
                string descricao = Console.ReadLine()!;

                Documento novoDocumento = new Documento(tipo, descricao);

                caso.Documentos?.Add(novoDocumento);
                Console.WriteLine("Documento adicionado com sucesso!");

                Console.WriteLine("Deseja adicionar outro documento? (s/n): ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar documento: {ex.Message}");
            }
        } while (Console.ReadLine()?.ToLower() == "s");
    }
    public void AdicionarCusto(List<CasoJuridico> casos)
    {
        Console.WriteLine("Escolha o caso que deseja adicionar o custo: ");
        CasoJuridico caso = EscolherCaso(casos);

        do
        {
            try
            {
                Console.WriteLine("Escolha o tipo de custo: ");
                string tipo = Console.ReadLine()!;

                Console.WriteLine("Digite o valor do custo: ");
                float valor = float.Parse(Console.ReadLine()!);

                CustoItem novoCusto = new CustoItem(tipo, valor);

                caso.Custos?.Add(novoCusto);
                Console.WriteLine("Custo adicionado com sucesso!");

                Console.WriteLine("Deseja adicionar outro custo? (s/n): ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar custo: {ex.Message}");
            }
        } while (Console.ReadLine()?.ToLower() == "s");
    }


    public static CasoJuridico EscolherCaso(List<CasoJuridico> casos)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Escolha um caso jurídico:");
                for (int i = 0; i < casos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Caso iniciado em {casos[i].Abertura}");
                }

                int escolha = int.Parse(Console.ReadLine()!) - 1;

                if (escolha >= 0 && escolha < casos.Count)
                {
                    return casos[escolha];
                }
                else
                {
                    throw new IndexOutOfRangeException("Índice fora dos limites.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Digite um número válido.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
    }

    public void EncerrarCaso()
    {
        this.Status = "encerrado";
        this.Encerramento = DateTime.Now;
        Console.WriteLine("Caso encerrado com sucesso!");
    }

    public static void MostrarCasosAbertos(List<CasoJuridico> casos)
    {
        foreach (var caso in casos)
        {
            if (caso.Status?.ToLower() == "aberto")
            {
                Console.WriteLine($"Caso iniciado em {caso.Abertura} para o cliente {caso.ClienteDoCaso?.Nome}");
            }
        }
    }
    public static void MostrarAdvogadosMaisConcluidos(List<Advogado> advogados)
    {
        var advogadosOrdenados = advogados.OrderByDescending(advogado => advogado.CasosConcluidos.Count);

        foreach (var advogado in advogadosOrdenados)
        {
            Console.WriteLine($"{advogado.Nome}: {advogado.CasosConcluidos.Count} casos concluídos");
        }
    }
}





