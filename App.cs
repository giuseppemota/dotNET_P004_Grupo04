namespace P004;

public class App
{
    public static EscritorioAdvocacia escritorio = new EscritorioAdvocacia();

    public static void Menu()
    {
        int opcaoMenu = -1;
        do {
            try {
                opcaoMenu = App.ExibeMenu();
            switch (opcaoMenu) {
                case 1:
                    App.MenuCadastro();
                    break;
                case 2:
                    App.MenuConsulta();
                    break;
                case 3:
                    App.MenuAtualizacao();
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
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            if (opcaoMenu != 0) {
                Pausar();
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

    private static void MenuAtualizacao(){
        int opcaoAtt = -1;
        do {
            try {
                opcaoAtt = App.ExibeMenuAtualizacao();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            switch (opcaoAtt) {
                case 1:
                    App.AtualizarDocumento();
                    break;
                case 2:
                    App.AtualizarCasoJuridico();
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            if (opcaoAtt != 0) {
                Pausar();
            }
        } while (opcaoAtt != 0);
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
                    App.ListarClientes();
                    break;
                case 2:
                    App.ListarAdvogados();
                    break;
                case 3:
                    App.ListarDocumentos();
                    break;
                case 4:
                    App.ListarCasosJuridicos();
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            if (opcaoRel != 0) {
                Pausar();
            }
        } while (opcaoRel != 0);
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
                    App.CadastroCliente();
                    break;
                case 2:
                    App.CadastroAdvogado();
                    break;
                case 3:
                    App.CadastroDocumento();
                    break;
                case 4:
                    App.CadastroCasoJuridico();
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            if (opcaoCad != 0) {
                Pausar();
            }
        } while (opcaoCad != 0);
    }

    public static void MenuAttCaso(CasoJuridico casoJuridico) {
        int opcaoAttCaso = -1;
        Advogado? advogado;
        do {
            try {
                opcaoAttCaso = App.ExibeMenuAttCaso(casoJuridico);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            switch (opcaoAttCaso) {
                case 1:
                    casoJuridico.Encerramento = DateTime.Now;
                    casoJuridico.Status = "Encerrado";
                    Console.WriteLine("Caso Encerrado");
                    break;
                case 2:
                    casoJuridico.Encerramento = DateTime.Now;
                    casoJuridico.Status = "Arquivado";
                    Console.WriteLine("Caso Arquivado");
                    break;
                case 3:
                    Console.WriteLine("Adicionar Advogado");
                    Console.Write("CNA: ");
                    string cna = Console.ReadLine() ?? throw new InvalidOperationException();
                    advogado = escritorio.ProcurarAdvogado(cna);
                    if (advogado == null){
                        throw new Exception("Advogado não encontrado");
                    }
                    casoJuridico.Advogados.Add(advogado);
                    break;
                case 4:
                    Console.WriteLine("Adicionar Documento");
                    Console.Write("Código: ");
                    string codigo = Console.ReadLine() ?? throw new InvalidOperationException();
                    Documento? documento = escritorio.ProcurarDocumento(codigo);
                    if (documento == null){
                        throw new Exception("Documento não encontrado");
                    }
                    casoJuridico.Documentos.Add(documento);
                    break;
                case 5:
                    Console.WriteLine("Adicionar Custo");
                    Console.Write("Descrição: ");
                    string descricao = Console.ReadLine() ?? throw new InvalidOperationException();
                    Console.Write("Valor: ");
                    float valor = float.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    CustoItem custoItem = new CustoItem();
                    custoItem.Descricao = descricao;
                    custoItem.Custo = valor;
                    casoJuridico.Custos.Add(custoItem);
                    break;
                case 6:
                    Console.WriteLine("Mudar Probabilidade de Sucesso");
                    Console.Write("Probabilidade de Sucesso: ");
                    float probabilidadeDeSucesso = float.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    if (probabilidadeDeSucesso < 0 || probabilidadeDeSucesso > 1){
                        throw new Exception("Provabilidade de sucesso deve estar entre 0 e 1");
                    }
                    casoJuridico.ProbabilidadeDeSucesso = probabilidadeDeSucesso;
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            if (opcaoAttCaso != 0) {
                Pausar();
            }
        } while (opcaoAttCaso != 0);
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
        Console.WriteLine("2 - Consulta");
        Console.WriteLine("3 - Atualização");
        Console.WriteLine("3 - Relatórios");
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

    public static int ExibeMenuAttCaso(CasoJuridico casoJuridico ){
        Console.Clear();
        Console.WriteLine("Atualização de Caso Jurídico de ID " + casoJuridico.ID);
        Console.WriteLine("1 - Encerrar");
        Console.WriteLine("2 - Arquivar");
        Console.WriteLine("3 - Adicionar Advogado");
        Console.WriteLine("4 - Adicionar Documento");
        Console.WriteLine("5 - Adicionar Custo");
        Console.WriteLine("6 - Mudar Probabilidade de Sucesso");
        Console.WriteLine("0 - Voltar");
        Console.Write("Opção: ");
        return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    }

    public static int ExibeMenuAtualizacao(){
        Console.Clear();
        Console.WriteLine("Atualização");
        Console.WriteLine("1 - Documento");
        Console.WriteLine("2 - Caso Jurídico");
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

       public static void CadastroCliente()
    {
        string? nome;
        string? cpf;
        string? estadoCivil;
        string? profissao;
        Console.Clear();
        Console.WriteLine("Cadastro de Cliente");
        Console.Write("Nome: ");
        if (string.IsNullOrEmpty(nome = Console.ReadLine()))
        {
            throw new Exception("Nome inválido!");
        }
        Console.Write("CPF: ");

        if (string.IsNullOrEmpty(cpf = Console.ReadLine())){
            throw new Exception("CPF inválido!");
        }

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            throw new Exception("CPF inválido!");
        }

        if (escritorio.Clientes.Any(cliente => cliente.CPF == cpf))
        {
            throw new Exception("CPF já cadastrado!");
        }

        Console.Write("Data de Nascimento: ");
        DateTime dataNascimento = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        
        Console.Write("Estado Civil: ");
        if (string.IsNullOrEmpty(estadoCivil = Console.ReadLine())){
            throw new Exception("Estado civil vazio!");
        }

        Console.Write("Profissão: ");
        if (string.IsNullOrEmpty(profissao = Console.ReadLine())){
            throw new Exception("Profissão vazia!");
        }
        escritorio.AdicionarCliente(nome, cpf, dataNascimento, estadoCivil, profissao);
        Console.WriteLine("Cliente cadastrado com sucesso!");
    }

    public static void CadastroAdvogado (){
        string? nome;
        string? cpf;
        string? cna;
        DateTime dataNascimento;
        Console.Clear();
        Console.WriteLine("Cadastro de Advogado");
        Console.Write("Nome: ");
        if (string.IsNullOrEmpty(nome = Console.ReadLine()))
        {
            throw new Exception("Nome inválido!");
        }
        Console.Write("CPF: ");

        if (string.IsNullOrEmpty(cpf = Console.ReadLine())){
            throw new Exception("CPF inválido!");
        }

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            throw new Exception("CPF inválido!");
        }

        if (escritorio.Advogados.Any(advogado => advogado.CPF == cpf))
        {
            throw new Exception("CPF já cadastrado!");
        }

        Console.Write("Data de Nascimento: ");
        dataNascimento = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        Console.Write("CNA: ");
        if (string.IsNullOrEmpty(cna = Console.ReadLine())){
            throw new Exception("CNA vazio!");
        }

        if (escritorio.Advogados.Any(advogado => advogado.CNA == cna))
        {
            throw new Exception("CNA já cadastrado!");
        }

        escritorio.AdicionarAdvogado(nome, cpf, dataNascimento, cna);
        Console.WriteLine("Advogado cadastrado com sucesso!");    }

    public static void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("Lista de Clientes");
        escritorio.ListarClientes();
    }

    public static void ListarAdvogados()
    {
        Console.Clear();
        Console.WriteLine("Lista de Advogados");
        escritorio.ListarAdvogados();
    }

    public static void CadastroDocumento(){
        string? descricao;
        string? tipo;
        string? codigo;
        Console.Clear();
        Console.WriteLine("Cadastro de Documento");
        Console.Write("Descrição: ");
        if (string.IsNullOrEmpty(descricao = Console.ReadLine()))
        {
            throw new Exception("Descrição inválida!");
        }
        Console.Write("Tipo: ");
        if (string.IsNullOrEmpty(tipo = Console.ReadLine()))
        {
            throw new Exception("Tipo inválido!");
        }
        Console.Write("Código: ");
        if (string.IsNullOrEmpty(codigo = Console.ReadLine()))
        {
            throw new Exception("Código inválido!");
        }
        escritorio.AdicionarDocumento(descricao, tipo, codigo);
        Console.WriteLine("Documento cadastrado com sucesso!");
    }

    public static void ListarDocumentos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Documentos");
        escritorio.ListarDocumentos();
    }

    public static void CadastroCasoJuridico(){
        float probabilidadeDeSucesso;
        Cliente? clienteDoCaso;
        List<Advogado>? advogados;
        List<Documento>? documentos;
        Console.Clear();
        Console.WriteLine("Iniciar um Caso Jurídico");
        Console.Write("Probabilidade de Sucesso: ");
        probabilidadeDeSucesso = float.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        if (probabilidadeDeSucesso < 0 || probabilidadeDeSucesso > 1){
            throw new Exception("Provabilidade de sucesso deve estar entre 0 e 1");
        }
        Console.Write("Cliente do Caso (Cpf): ");
        string cpf = Console.ReadLine() ?? throw new InvalidOperationException();
        clienteDoCaso = escritorio.ProcurarCliente(cpf);
        if (clienteDoCaso == null){
            throw new Exception("Cliente não encontrado");
        }
        Console.Write("Advogados do Caso (cna): ");
        Console.WriteLine("Digite o cna de cada advogado separado por espaço");
        string cna = Console.ReadLine() ?? throw new InvalidOperationException();
        string[] cnas = cna.Split(' ');
        advogados = new List<Advogado>();
        foreach (string cnaAdvogado in cnas){
            Advogado? advogado = escritorio.ProcurarAdvogado(cnaAdvogado);
            if (advogado == null){
                throw new Exception("Advogado de Cna " + cnaAdvogado + " não encontrado");
            }
            advogados.Add(advogado);
        }
        Console.WriteLine("Deseja adicionar documentos ao caso? (s/n)");
        string resposta = Console.ReadLine() ?? throw new InvalidOperationException();
        if (resposta == "s")
        {
            Console.Write("Documentos do Caso (codigo): ");
            Console.WriteLine("Digite o codigo de cada documento separado por espaço");
            string codigo = Console.ReadLine() ?? throw new InvalidOperationException();
            string[] codigos = codigo.Split(' ');
            documentos = new List<Documento>();
            foreach (string codigoDocumento in codigos)
            {
                Documento? documento = escritorio.ProcurarDocumento(codigoDocumento);
                if (documento == null)
                {
                    throw new Exception("Documento de Codigo " + codigoDocumento + " não encontrado");
                }
                documentos.Add(documento);
            }
            escritorio.AdicionarCasoJuridico(probabilidadeDeSucesso, clienteDoCaso, advogados, documentos);
        }
        else
        {
            escritorio.AdicionarCasoJuridico(probabilidadeDeSucesso, clienteDoCaso, advogados, null);
        }
    }

    public static void ListarCasosJuridicos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Casos Jurídicos");
        escritorio.ListarCasosJuridicos();
    }

    public static void AtualizarDocumento(){
        Console.Clear();
        Console.WriteLine("Atualizar Documento");
        Console.Write("Código: ");
        string codigo = Console.ReadLine() ?? throw new InvalidOperationException();
        Documento? documento = escritorio.ProcurarDocumento(codigo);
        if (documento == null){
            throw new Exception("Documento não encontrado");
        }
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.Write("Tipo: ");
        string tipo = Console.ReadLine() ?? throw new InvalidOperationException();
        documento.Descricao = descricao;
        documento.Tipo = tipo;
        documento.DataModificacao = DateTime.Now;     
    }

    public static void AtualizarCasoJuridico(){
        Console.Clear();
        Console.WriteLine("Atualizar Caso Jurídico");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        CasoJuridico? casoJuridico = escritorio.ProcurarCasoJuridico(id);
        if (casoJuridico == null){
            throw new Exception("Caso Jurídico não encontrado");
        }
        App.MenuAttCaso(casoJuridico);
    }
}
