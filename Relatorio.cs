namespace ProvaIndividual;
public abstract class Relatorio
{
    public static void AdvogadoIdadeEntre(List<Advogado> advogados, int idadeMin, int idadeMax)
    {
        var advogadosFiltrados = advogados.Where(item => item.Idade >= idadeMin && item.Idade <= idadeMax);

        foreach (var advogado in advogadosFiltrados)
        {
            Console.WriteLine(advogado.Nome);
        }
    }



    public static void ClienteIdadeEntre(List<Cliente> clientes, int idadeMin, int idadeMax)
    {
        foreach (var item in clientes)
        {
            if (item.Idade >= idadeMin && item.Idade <= idadeMax)
            {
                Console.WriteLine(item.Nome);
            }
        }
    }

    public static void ClienteEstadoCivil(List<Cliente> clientes)
    {
        foreach (var item in clientes)
        {
            if (item.EstadoCivil)
            {
                Console.WriteLine(item.Nome + " " + "Solteiro");
            }
            else
            {
                Console.WriteLine(item.Nome + " " + "Casado");
            }
        }
    }

    public static void ClienteOrdemAlfabetica(List<Cliente> lista)
    {
        var clientesOrdenados = lista.OrderBy(cliente => cliente.Nome);

        foreach (var item in clientesOrdenados)
        {
            Console.WriteLine(item.Nome);
        }
    }


    public static void ClienteComProfissao(List<Cliente> lista, string profissao)
    {
        var clientesComProfissao = lista.Where(item => item.Profissao == profissao);

        foreach (var cliente in clientesComProfissao)
        {
            Console.WriteLine(cliente.Nome);
        }
    }


    public static void PessoasAniversariantes(List<Advogado> lista, List<Cliente> lista2, int mes)
    {
        foreach (var item in lista)
        {
            if (item.DataNascimento.Month == mes)
            {
                Console.WriteLine(item.Nome);
            }
        }
        foreach (var item in lista2)
        {
            if (item.DataNascimento.Month == mes)
            {
                Console.WriteLine(item.Nome);
            }
        }
    }



}
