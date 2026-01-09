using MySql.Data.MySqlClient;

namespace SalãoJenny.SalãoJenny.Controller.Banco
{
        public class DBprodutos
    {

        private static string conexao =
            "Server=localhost;Database=banco;User=root;Password=Jenny210702@;";

        public static MySqlConnection Abrir()
        {
            MySqlConnection conn = new MySqlConnection(conexao);
            conn.Open();

            return conn;
        }
    }
}
