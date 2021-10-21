using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Dados.Models
{
    public class Dados
    {
        public Dados() { }

        public int CursoId { get; set; }

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

    }
}
