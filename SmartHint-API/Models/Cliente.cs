namespace SmartHint_API.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public DateTime dataCadastro { get; set; }
        public string? cpf { get; set; }
        public string? cnpj { get; set; }
        public string? inscricaoEstadual { get; set; }
        public bool? inscricaoEstadualIsento { get; set; }
        public string genero { get; set; }
        public DateTime nascimento { get; set; }
        public bool bloqueado{ get; set; }
        public string senha{  get; set; }

    }
}
