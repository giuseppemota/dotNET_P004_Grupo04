namespace P004;

public class Cliente : Pessoa
    {
        
    public string? Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? CPF { get; set; }

    public int Idade
    {
        get
        {
            return (int)((DateTime.Now - DataNascimento).TotalDays / 365.25);
        }
    }
        PlanoDeConsultoria? planoDeConsultoria;

        public List<IPagamento> pagamentos = new List<IPagamento>();

        public PlanoDeConsultoria planoDeConsultoria
        {
            get { return planoDeConsultoria; }
            set { this.planoDeConsultoria = value; }
        }

        public List<IPagamento> Pagamentos
        {
            get { return pagamentos; }
            set
            {
                foreach (IPagamento pagamento in value)
                {
                    this.pagamentos.Add(pagamento);
                }
            }
        }

        public void efetuarPagamento(IPagamento pagamento)
        {
            pagamento.RealizarPagamento(this.planoDeSaude!.Mensalidade);
            this.pagamentos.Add(pagamento);
        }

        public Paciente(string _nome, DateTime _dataDeNascimento, string _cpf, string _sexo, List<string> _sintomas, PlanoDeSaude? _plano) : base(_nome, _dataDeNascimento, _cpf)
        {
            sexo = _sexo;
            sintomas = _sintomas;
            PlanoDeSaude = _plano!;
        }
    }
}