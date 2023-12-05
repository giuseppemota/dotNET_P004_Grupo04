namespace ProvaIndividual;
public class EscritorioAdvocacia
{
    protected List<Advogado> advogados = new List<Advogado>();
    protected List<Cliente> clientes = new List<Cliente>();
    protected List<CasoJuridico> casosJuridicos = new List<CasoJuridico>();
    public List<Advogado> Advogados
    {
        get
        {
            return advogados;
        }
    }

    public List<Cliente> Clientes
    {
        get
        {
            return clientes;
        }
    }

    public void AdicionarAdvogado(Advogado advogado)
    {
        if (advogados.Exists(x => x.Cpf == advogado.Cpf || x.CNA == advogado.CNA))
        {
            throw new Exception("Advogado ja existe");
        }
        else
        {
            advogados.Add(advogado);
        }
    }

    public void AdicionarCliente(Cliente cliente)
    {
        if (clientes.Exists(x => x.Cpf == cliente.Cpf))
        {
            throw new Exception("Cliente ja existe");
        }
        else
        {
            clientes.Add(cliente);
        }
    }

    public void RemoverAdvogado(Advogado advogado)
    {
        if (advogados.Exists(x => x.Cpf == advogado.Cpf || x.CNA == advogado.CNA))
        {
            advogados.Remove(advogado);
        }
        else
        {
            throw new Exception("Advogado nao existe");
        }

    }

    public void RemoverCliente(Cliente cliente)
    {
        if (clientes.Exists(x => x.Cpf == cliente.Cpf))
        {
            clientes.Remove(cliente);
        }
        else
        {
            throw new Exception("Cliente nao existe");
        }
    }
    public static string ObterStatus()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Informe o status do caso (aberto ou encerrado): ");
                string status = Console.ReadLine()!.ToLower();

                if (status == "aberto" || status == "encerrado")
                {
                    return status;
                }
                else
                {
                    throw new ArgumentException("Status inválido. Digite 'aberto' ou 'encerrado'.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
    }
    public static Cliente EscolherCliente(List<Cliente> clientes)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Escolha um cliente:");
                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {clientes[i].Nome}");
                }

                int escolha = int.Parse(Console.ReadLine()!) - 1;

                if (escolha >= 0 && escolha < clientes.Count)
                {
                    return clientes[escolha];
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

    public static Advogado EscolherAdvogado(List<Advogado> advogados)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Escolha um advogado:");
                for (int i = 0; i < advogados.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {advogados[i].Nome}");
                }

                int escolha = int.Parse(Console.ReadLine()!) - 1;

                if (escolha >= 0 && escolha < advogados.Count)
                {
                    return advogados[escolha];
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
}
