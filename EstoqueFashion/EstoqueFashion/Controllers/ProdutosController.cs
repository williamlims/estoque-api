using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstoqueFashion.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace EstoqueFashion.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProdutosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from produto";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ProdutoAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select * from produto where id=@ProdutoId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ProdutoAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ProdutoId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Produtos pro)
        {
            string query = @"insert into produto (status, descricao, categoria, quantidade, custo, imagem) values 
                                                 (@status, @descricao, @categoria, @quantidade, @custo, @imagem)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ProdutoAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@status", pro.Status);
                    myCommand.Parameters.AddWithValue("@descricao", pro.Descricao);
                    myCommand.Parameters.AddWithValue("@categoria", pro.Categoria);
                    myCommand.Parameters.AddWithValue("@quantidade", pro.Quantidade);
                    myCommand.Parameters.AddWithValue("@custo", pro.Custo);
                    myCommand.Parameters.AddWithValue("@imagem", pro.Imagem);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Produto adicionado com sucesso!");
        }

        [HttpPut("{id}")]
        public JsonResult Put(Produtos pro, int id)
        {
            string query = @"update produto set status = @status, descricao = @descricao, categoria = @categoria,
                                                quantidade = @quantidade, custo = @custo, imagem = @imagem 
                                                where id=@ProdutoId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ProdutoAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ProdutoId", id);
                    myCommand.Parameters.AddWithValue("@status", pro.Status);
                    myCommand.Parameters.AddWithValue("@descricao", pro.Descricao);
                    myCommand.Parameters.AddWithValue("@categoria", pro.Categoria);
                    myCommand.Parameters.AddWithValue("@quantidade", pro.Quantidade);
                    myCommand.Parameters.AddWithValue("@custo", pro.Custo);
                    myCommand.Parameters.AddWithValue("@imagem", pro.Imagem);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Produto atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from produto where id=@ProdutoId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ProdutoAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ProdutoId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Item deletado com sucesso!");
        }

    }
}
