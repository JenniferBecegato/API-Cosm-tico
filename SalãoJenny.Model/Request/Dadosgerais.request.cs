namespace SalãoJenny.SalãoJenny.Model.Request
{
    public class DadosgeraisRequest
    {
        public string Nome { get; set; } = "";
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Marca { get; set; } = "";
        public DateTime Validade { get; set; }
        public string Descricao { get; set; } = "";
    }
}
