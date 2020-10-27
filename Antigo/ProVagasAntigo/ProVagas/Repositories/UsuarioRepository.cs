using LumenWorks.Framework.IO.Csv;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public bool aluno(string email)
        {
            var csvTable = new DataTable();

            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"Csv\alunos.csv")), true))
            {
                csvTable.Load(csvReader);
            }

            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                if (csvTable.Rows[i][4].ToString().ToLower() == email.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
