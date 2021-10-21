using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dados.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;



namespace Curso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;


        public string CursoId { get; set; }

        public string CursoTitulo { get; set; }

        public string CursoImagem { get; set; }

        public string CursoProfessor { get; set; }

        public string CursoDescricao { get; set; }

        public string AulaUmTitulo { get; set; }

        public string AulaUmLink { get; set; }

        public string DescricaoAulaUm { get; set; }

        public string AulaDoisTitulo { get; set; }

        public string AulaDoisLink { get; set; }

        public string DescricaoAulaDois { get; set; }

        public CursoController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select * from
                            dbo.curso
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CursosAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(CursoController cur)
        {
            string query = @"
                            insert into dbo.curso
                            (CursoTitulo, CursoImagem, CursoProfessor, CursoDescricao, AulaUmTitulo, AulaUmLink, DescricaoAulaUm, AulaDoisTitulo, AulaDoisLink, DescricaoAulaDois)
                     values (@CursoTitulo, @CursoImagem, @CursoProfessor, @CursoDescricao, @AulaUmTitulo, @AulaUmLink, @DescricaoAulaUm, @AulaDoisTitulo, @AulaDoisLink, @DescricaoAulaDois)

                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CursosAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CursoTitulo", cur.CursoTitulo);
                    myCommand.Parameters.AddWithValue("@CursoImagem", cur.CursoImagem);
                    myCommand.Parameters.AddWithValue("@CursoProfessor", cur.CursoProfessor);
                    myCommand.Parameters.AddWithValue("@CursoDescricao", cur.CursoDescricao);
                    myCommand.Parameters.AddWithValue("@AulaUmTitulo", cur.AulaUmTitulo);
                    myCommand.Parameters.AddWithValue("@AulaUmLink", cur.AulaUmLink);
                    myCommand.Parameters.AddWithValue("@DescricaoAulaUm", cur.DescricaoAulaUm);
                    myCommand.Parameters.AddWithValue("@AulaDoisTitulo", cur.AulaDoisTitulo);
                    myCommand.Parameters.AddWithValue("@AulaDoisLink", cur.AulaDoisLink);
                    myCommand.Parameters.AddWithValue("@DescricaoAulaDois", cur.DescricaoAulaDois);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Curso incluido com sucesso!!");
        }

        [HttpPut]
        public JsonResult Put(CursoController cur)
        {

            string query = @"
                            update dbo.curso
                         set CursoTitulo = @CursoTitulo,
                             CursoImagem = @CursoImagem,
                             CursoProfessor = @CursoProfessor,
                             CursoDescricao = @CursoDescricao,
                             AulaUmTitulo = @AulaUmTitulo,
                             AulaUmLink = @AulaUmLink,
                             DescricaoAulaUm = @DescricaoAulaUm,
                             AulaDoisTitulo = @AulaDoisTitulo,
                             AulaDoisLink = @AulaDoisLink
                             DescricaoAulaDois = @DescricaoAulaDois
                            where CursoId = @CursoId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CursosAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CursoTitulo", cur.CursoTitulo);
                    myCommand.Parameters.AddWithValue("@CursoImagem", cur.CursoImagem);
                    myCommand.Parameters.AddWithValue("@CursoProfessor", cur.CursoProfessor);
                    myCommand.Parameters.AddWithValue("@CursoDescricao", cur.CursoDescricao);
                    myCommand.Parameters.AddWithValue("@AulaUmTitulo", cur.AulaUmTitulo);
                    myCommand.Parameters.AddWithValue("@AulaUmLink", cur.AulaUmLink);
                    myCommand.Parameters.AddWithValue("@DescricaoAulaUm", cur.DescricaoAulaUm);
                    myCommand.Parameters.AddWithValue("@AulaDoisTitulo", cur.AulaDoisTitulo);
                    myCommand.Parameters.AddWithValue("@AulaDoisLink", cur.AulaDoisLink);
                    myCommand.Parameters.AddWithValue("@DescricaoAulaDois", cur.DescricaoAulaDois);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Curso alterado com sucesso!!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                            delete from dbo.curso
                            where CursoId = @CursoId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CursosAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CursoId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Curso deletado com sucesso!!");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Fotos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

    }
}