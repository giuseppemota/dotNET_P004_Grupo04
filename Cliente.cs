namespace P004;

public class Cliente : Pessoa
{
    public string? EstadoCivil { get; set; }
    public string? Profissao { get; set; }
    public PlanoDeConsultoria? Plano {get; set}
     public List<IPagamento> pagamentos = new List<IPagamento>();


// Método para associar um plano ao cliente
        public void AssociarPlano(PlanoDeConsultoria plano)
        {
            if (Plano == null)
            {
                Plano = plano;
                Console.WriteLine($"Plano '{plano.Titulo}' associado ao cliente '{Nome}'.");
            }
            else
            {
                Console.WriteLine($"O cliente '{Nome}' já possui um plano associado.");
            }
        }
}