namespace P004;

public class App
{
    public static void Menu()
    {
        int opcaoMenu = -1;
        do {
            try {
                opcaoMenu = App.ExibeMenu();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            switch (opcaoMenu) {
                case 1:
                    App.MenuCadastro();
                    break;
                case 2:
                    App.MenuAtualizacao();
                    break;
                case 3:
                    App.MenuConsulta();
                    break;
                case 4:
                    App.MenuRelatorio();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while (opcaoMenu != 0);
    }

    private static void MenuRelatorio()
    {
        int opcaoRel = -1;
        do {
            try {
                opcaoRel = App.ExibeMenuRelatorio();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            switch (opcaoRel) {
                case 1:
                    Console.WriteLine("Advogados entre idades");
                    Pausar();
                    break;
                case 2:
                    Console.WriteLine("Clientes entre idades");
                    Pausar();
                    break;
                case 3:
                    Console.WriteLine("Clientes por estado civil");
                    Pausar();
                    break;
                case 4:
                    Console.WriteLine("Clientes em ordem alfabetica");
                    Pausar();
                    break;
                case 5:
                    Console.WriteLine("Clientes com profissao");
                    Pausar();
                    break;
                case 6:
                    Console.WriteLine("Advogados e Clientes aniversariantes do mes");
                    Pausar();
                    break;
                case 7:
                    Console.WriteLine("Casos abertos");
                    Pausar();
                    break;
                case 8:
                    Console.WriteLine("Advogados com mais casos concluidos");
                    Pausar();
                    break;
                case 9:
                    Console.WriteLine("Pesquisa da descrição de custo de caso");
                    Pausar();
                    break;
                case 10:
                    Console.WriteLine("Top 10 documentos");
                    Pausar();
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while (opcaoRel != 0);
    }

    private static void MenuConsulta()
    {
        int opcaoRel = -1;
        do {
            try {
                opcaoRel = App.ExibeMenuConsulta();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            switch (opcaoRel) {
                case 1:
                    Console.WriteLine("Consulta de Cliente");
                    Pausar();
                    break;
                case 2:
                    Console.WriteLine("Consulta de Advogado");
                    Pausar();
                    break;
                case 3:
                    Console.WriteLine("Consulta de Documento");
                    Pausar();
                    break;
                case 4:
                    Console.WriteLine("Consulta de Caso Jurídico");
                    Pausar();
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while (opcaoRel != 0);
    }

    private static void MenuAtualizacao()
    {
        int opcaoAtt = -1;
        do {
            try {
                opcaoAtt = App.ExibeMenuAtualizacao();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            switch (opcaoAtt) {
                case 1:
                    Console.WriteLine("Atualização de Cliente");
                    Pausar();
                    break;
                case 2:
                    Console.WriteLine("Atualização de Advogado");
                    Pausar();
                    break;
                case 3:
                    Console.WriteLine("Atualização de Documento");
                    Pausar();
                    break;
                case 4:
                    Console.WriteLine("Atualização de Caso Jurídico");
                    Pausar();
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while (opcaoAtt != 0);
    }

    private static void MenuCadastro()
    {
        int opcaoCad = -1;
        do {
            try {
                opcaoCad = App.ExibeMenuCadastro();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            switch (opcaoCad) {
                case 1:
                    Console.WriteLine("Cadastro de Cliente");
                    Pausar();
                    break;
                case 2:
                    Console.WriteLine("Cadastro de Advogado");
                    Pausar();
                    break;
                case 3:
                    Console.WriteLine("Cadastro de Documento");
                    Pausar();
                    break;
                case 4:
                    Console.WriteLine("Cadastro de Caso Jurídico");
                    Pausar();
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        } while (opcaoCad != 0);
    }

    public static void Pausar(){
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public static int ExibeMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Principal");
        Console.WriteLine("1 - Cadastro");
        Console.WriteLine("2 - Atualização");
        Console.WriteLine("3 - Consulta");
        Console.WriteLine("4 - Relatórios");
        Console.WriteLine("0 - Sair");
        Console.Write("Opção: ");
        return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    }

    public static int ExibeMenuRelatorio(){
        Console.Clear();
        Console.WriteLine("Relatórios");
        Console.WriteLine("1 - Advogados entre idades");
        Console.WriteLine("2 - Clientes entre idades");
        Console.WriteLine("3 - Clientes por estado civil");
        Console.WriteLine("4 - Clientes em ordem alfabetica");
        Console.WriteLine("5 - Clientes com profissao");
        Console.WriteLine("6 - Advogados e Clientes aniversariantes do mês");
        Console.WriteLine("7 - Casos abertos");
        Console.WriteLine("8 - Advogados com mais casos concluidos");
        Console.WriteLine("9 - Pesquisa da descrição de custo de caso");
        Console.WriteLine("10 - Top 10 documentos");
        Console.WriteLine("0 - Voltar");
        Console.Write("Opção: ");
        return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }

    public static int ExibeMenuCadastro(){
        Console.Clear();
        Console.WriteLine("Cadastro");
        Console.WriteLine("1 - Cliente");
        Console.WriteLine("2 - Advogado");
        Console.WriteLine("3 - Documento");
        Console.WriteLine("4 - Caso Jurídico");
        Console.WriteLine("0 - Voltar");
        Console.Write("Opção: ");
        return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }

    public static int ExibeMenuAtualizacao(){
        Console.Clear();
        Console.WriteLine("Atualização");
        Console.WriteLine("1 - Cliente");
        Console.WriteLine("2 - Advogado");
        Console.WriteLine("3 - Documento");
        Console.WriteLine("4 - Caso Jurídico");
        Console.WriteLine("0 - Voltar");
        Console.Write("Opção: ");
        return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }

    public static int ExibeMenuConsulta(){
        Console.Clear();
        Console.WriteLine("Consulta");
        Console.WriteLine("1 - Cliente");
        Console.WriteLine("2 - Advogado");
        Console.WriteLine("3 - Documento");
        Console.WriteLine("4 - Caso Jurídico");
        Console.WriteLine("0 - Voltar");
        Console.Write("Opção: ");
        return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }


    // Class que vai implementar as telas, lógica e regras de negócio, menu etc.
}
