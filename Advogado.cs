namespace P004
{
    public class Advogado : Pessoa
    {
        public string? CNA { get; set; }
        public List<CasoJuridico> CasosConcluidos { get; private set; }

        public Advogado(string? nome, string? cpf, DateTime dataNascimento, string? cna)
            : base(nome, cpf, dataNascimento)
        {
            
            CNA = cna;
            CasosConcluidos = new List<CasoJuridico>();
        }

        // Método para adicionar caso concluído
        public void AdicionarCasoConcluido(CasoJuridico caso)
        {
            CasosConcluidos.Add(caso);
        }
    }

    // Restante da classe
}