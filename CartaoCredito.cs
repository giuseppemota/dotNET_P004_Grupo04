namespace P004;
public class CartaoCredito : IPagamento
{
  public string? Descricao { get; set; }
  public double ValorBruto { get; set; }

  public double Desconto { get; set; }

  public DateTime DataHora { get; set; }

  
  public void RealizarPagamento(double valor)
  {
    this.Descricao = "Pagamento com cartão de crédito";
    this.ValorBruto = valor;
    this.DataHora = DateTime.Now;
    this.Desconto = 0;

    Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito");
  }
}
