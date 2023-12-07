namespace P004;
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

    public List<CasoJuridico> CasosJuridicos
    {
        get
        {
            return casosJuridicos;
        }
    }

    public void AdicionarAdvogado()
    {
        try
        {
            Console.WriteLine("Informe o CPF do advogado: ");
            string cpf = Console.ReadLine()!;

            Console.WriteLine("Informe o nome do advogado: ");
            string nome = Console.ReadLine()!;

            Console.WriteLine("Informe a data de nascimento do advogado (Formato: dd/MM/yyyy): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine()!);

            Console.WriteLine("Informe o CNA do advogado: ");
            string cna = Console.ReadLine()!;

            Advogado novoAdvogado = new Advogado(nome, cpf, dataNascimento, cna);

            if (advogados.Exists(x => x.Cpf == novoAdvogado.Cpf))
            {
                throw new Exception("Advogado já existe");
            }
            else
            {
                advogados.Add(novoAdvogado);
                Console.WriteLine("Advogado adicionado com sucesso!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao adicionar advogado: {ex.Message}");
        }
    }


    public void AdicionarCliente()
    {
        try
        {
            Console.WriteLine("Informe o CPF do cliente: ");
            string? cpf = Console.ReadLine();

            Console.WriteLine("Informe o nome do cliente: ");
            string? nome = Console.ReadLine();

            Console.WriteLine("Informe a data de nascimento do cliente (Formato: dd/MM/yyyy): ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine()!);

            Console.WriteLine("Informe o estado civil do cliente (true para casado, false para solteiro): ");
            bool estadoCivil = bool.Parse(Console.ReadLine()!);

            Console.WriteLine("Informe a profissão do cliente: ");
            string profissao = Console.ReadLine()!;

            Cliente novoCliente = new Cliente(nome, cpf, dataNascimento, estadoCivil, profissao);

            if (clientes.Exists(x => x.Cpf == novoCliente.Cpf))
            {
                throw new Exception("Cliente já existe");
            }
            else
            {
                clientes.Add(novoCliente);
                Console.WriteLine("Cliente adicionado com sucesso!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao adicionar cliente: {ex.Message}");
        }
    }


    public void RemoverAdvogado()
    {
        try
        {
            Console.WriteLine("Informe o CPF do advogado que deseja remover: ");
            string cpf = Console.ReadLine()!;

            Advogado advogadoParaRemover = advogados.Find(x => x.Cpf == cpf)!;

            if (advogadoParaRemover != null)
            {
                Console.WriteLine($"Tem certeza que deseja remover o advogado {advogadoParaRemover.Nome}? (s/n): ");
                if (Console.ReadLine()?.ToLower() == "s")
                {
                    advogados.Remove(advogadoParaRemover);
                    Console.WriteLine("Advogado removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Remoção cancelada pelo usuário.");
                }
            }
            else
            {
                Console.WriteLine("Advogado não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao remover advogado: {ex.Message}");
        }
    }


    public void RemoverCliente()
    {
        try
        {
            Console.WriteLine("Informe o CPF do cliente que deseja remover: ");
            string cpf = Console.ReadLine()!;

            Cliente? clienteParaRemover = clientes.Find(x => x.Cpf == cpf);

            if (clienteParaRemover != null)
            {
                Console.WriteLine($"Tem certeza que deseja remover o cliente {clienteParaRemover.Nome}? (s/n): ");
                if (Console.ReadLine()?.ToLower() == "s")
                {
                    clientes.Remove(clienteParaRemover);
                    Console.WriteLine("Cliente removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Remoção cancelada pelo usuário.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao remover cliente: {ex.Message}");
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
