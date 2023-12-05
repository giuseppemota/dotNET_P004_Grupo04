// ProvaIndividual/Program.cs
using ProvaIndividual;
using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");



Advogado giuseppe = new Advogado();
giuseppe.DataNascimento = new DateTime(1997, 10, 13);
giuseppe.Cpf = "12345678934";
giuseppe.CNA = "123456789";
giuseppe.Nome = "Giuseppe";

Cliente henrique = new Cliente();
henrique.DataNascimento = new DateTime(1998, 11, 24);
henrique.Cpf = "12345678903";
henrique.Nome = "Henrique";
henrique.Profissao = "Debugger";
henrique.EstadoCivil = true;

Cliente pedro = new Cliente();
pedro.DataNascimento = new DateTime(1993, 04, 12);
pedro.Cpf = "12345653420";
pedro.Nome = "Pedro";
pedro.Profissao = "Developer";
pedro.EstadoCivil = true;



EscritorioAdvocacia escritorio = new EscritorioAdvocacia();
escritorio.AdicionarAdvogado(giuseppe);
escritorio.AdicionarCliente(henrique);
escritorio.AdicionarCliente(pedro);
//escritorio.RemoverAdvogado(giuseppe);
//escritorio.RemoverCliente(henrique);

System.Console.WriteLine("Relatorio: ");
System.Console.WriteLine("Advogados com idade entre 18 e 30 anos: ");
Relatorio.AdvogadoIdadeEntre(escritorio.Advogados, 18, 30);
System.Console.WriteLine("Clientes com idade entre 18 e 30 anos: ");
Relatorio.ClienteIdadeEntre(escritorio.Clientes, 18, 30);
System.Console.WriteLine("Clientes com profissão: ");
Relatorio.ClienteComProfissao(escritorio.Clientes, "Developer");
System.Console.WriteLine("Clientes com estado civil: ");
Relatorio.ClienteEstadoCivil(escritorio.Clientes);
System.Console.WriteLine("Clientes em ordem alfabetica: ");
Relatorio.ClienteOrdemAlfabetica(escritorio.Clientes);
System.Console.WriteLine("Pessoas aniversariantes do mes: ");
Relatorio.PessoasAniversariantes(escritorio.Advogados, escritorio.Clientes, 10);


