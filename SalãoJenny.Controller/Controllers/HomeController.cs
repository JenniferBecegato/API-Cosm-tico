using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SalãoJenny.SalãoJenny.Controller.Banco;
using SalãoJenny.SalãoJenny.Model.Request;
using SalãoJenny.SalãoJenny.Model.Request.Put.request;
using SalãoJenny.SalãoJenny.Model.Response;
using System.Text.RegularExpressions;

namespace SalãoJenny.SalãoJenny.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost("CadastroProduto")]
        public async Task<IActionResult> Dadosgerais([FromBody] DadosgeraisRequest request)
        {
            var nome = request.Nome;
            var id = request.Id;
            var valor = request.Valor;
            var marca = request.Marca;
            var validade = request.Validade;
            var descricao = request.Descricao;

            if (id != 0 && valor != 0)
            {
                var banco = DBprodutos.Abrir();

                var select = $"Insert into tbproduto (Nome, Id, Valor, Marca, Validade, Descricao) values ('{nome}', {id}, {valor}, '{marca}', '{validade.ToString("yyyy-MM-dd HH:mm:ss")}', '{descricao}')";

                var comando = new MySqlCommand(select, banco);
                
                comando.ExecuteNonQuery();
                
                banco.Close();

                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("DeletarProduto/{id}")]

        public async Task<IActionResult> DeletarId(int id)
        {
            if (id != 0)
            {
                var banco = DBprodutos.Abrir();

                var select = $"delete from tbproduto where Id = {id}";

                var comando = new MySqlCommand(select, banco);

                comando.ExecuteNonQuery();

                banco.Close();

                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("AlterarDados /{id}")]

        public async Task<IActionResult> Alterardados(int id, [FromBody] Alterardados request)
        {

            var nome = request.Nome;
            var valor = request.Valor;
            var marca = request.Marca;
            var validade = request.Validade;
            var descricao = request.Descricao;

            var banco = DBprodutos.Abrir();

            var select = $"update tbproduto set Nome = '{nome}', Valor = '{valor}', Marca = '{marca}', Validade = '{validade.ToString("yyyy-MM-dd HH:mm:ss")}', Descricao = '{descricao}' where Id = {id}";

            var comando = new MySqlCommand(select, banco);

            var alteracao = comando.ExecuteNonQuery();

            banco.Close();

            if (alteracao > 0)
            {
                return Ok("Personagem atualizado com sucesso");
            
            }
            else
            {
                return NotFound("Personagem não encontrado");
            }
        }

        [HttpGet("BuscarProdutos")]

        public async Task<IActionResult> Listagerais()
        {

            var banco = DBprodutos.Abrir();

            var select = $"Select * from tbproduto";


            MySqlCommand comando = new MySqlCommand(select, banco);

            MySqlDataReader leitor = comando.ExecuteReader();

            var response = new List<DadosgeraisResponse>();


            while (leitor.Read())
            {
                var dados = new DadosgeraisResponse();

                dados.Nome = leitor.GetString("Nome");
                dados.Id = leitor.GetInt32("Id");
                dados.Valor = leitor.GetDecimal("Valor");
                dados.Marca = leitor.GetString("Marca");
                dados.Validade = leitor.GetDateTime("Validade");
                dados.Descricao = leitor.GetString("Descricao");

                response.Add(dados);
            }
            banco.Close();

            return Ok(response);
            
        }


        [HttpGet("BuscarProdutosNome/{Nome}")]

        public async Task<IActionResult> ListaNome(string Nome)
        {

            var banco = DBprodutos.Abrir();

            var select = $"Select * from tbproduto where Nome = '{Nome}'";

            MySqlCommand comando = new MySqlCommand(select, banco);

            MySqlDataReader leitor = comando.ExecuteReader();

            var response = new List<DadosgeraisResponse>();

            while (leitor.Read())
            {
                var dados = new DadosgeraisResponse();

                dados.Nome = leitor.GetString("Nome");
                dados.Id = leitor.GetInt32("Id");
                dados.Valor = leitor.GetDecimal("Valor");
                dados.Marca = leitor.GetString("Marca");
                dados.Validade = leitor.GetDateTime("Validade");
                dados.Descricao = leitor.GetString("Descricao");

                response.Add(dados);
            }
            banco.Close();

            return Ok(response);
        }


        [HttpGet("BuscarProdutosMarca/{Marca}")]

        public async Task<IActionResult> ListaMarca(string Marca)
        {
            var banco = DBprodutos.Abrir();

            var select = $"Select * from tbproduto where Marca = '{Marca}'";

            MySqlCommand comando = new MySqlCommand(select, banco);

            MySqlDataReader leitor = comando.ExecuteReader();

            var response = new List<DadosgeraisResponse>();

            while (leitor.Read())
            {
                var dados = new DadosgeraisResponse();

                dados.Nome = leitor.GetString("Nome");
                dados.Id = leitor.GetInt32("Id");
                dados.Valor = leitor.GetDecimal("Valor");
                dados.Marca = leitor.GetString("Marca");
                dados.Validade = leitor.GetDateTime("Validade");
                dados.Descricao = leitor.GetString("Descricao");

                response.Add(dados);
            }
            banco.Close();

            return Ok(response);
        }



    }
}
