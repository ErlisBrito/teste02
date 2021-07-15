using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using teste02.Util;

namespace teste02.Models
{
    public class RelatorioModel
    {
        public int DonoId { get; set; }
        [Display(Name = "Nome do Dono")]
        public string Nome { get; set; }
        public int CaoId { get; set; }
        [Display(Name = "Nome do Cão")]
        public string CaoNome { get; set; }
        [Display(Name = "Raça")]
        public string Raca { get; set; }



        public List<RelatorioModel> ListarRelatorio()
        {
            List<RelatorioModel> lista = new List<RelatorioModel>();
            string sql = @$"SELECT 
                            dono.Id AS DonoId,
                            dono.Nome AS Nome,
                            cao.Id AS CaoId,
                            cao.Raca AS Raca,
                            cao.Nome AS CaoNome
                             FROM Dono dono
                            Inner JOIN Cao_Dono caoDono on caoDono.Donos_Id = dono.Id
                            Inner JOIN Cao cao on caoDono.Caes_Id = cao.Id ;";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var relatorio = new RelatorioModel
                    {
                        DonoId = int.Parse(dt.Rows[i]["DonoId"].ToString()),
                        Nome = dt.Rows[i]["Nome"].ToString(),
                        CaoId = int.Parse(dt.Rows[i]["CaoId"].ToString()),
                        CaoNome = dt.Rows[i]["CaoNome"].ToString(),
                        Raca = dt.Rows[i]["Raca"].ToString(),
                        

                    };
                    lista.Add(relatorio);
                }
            }

            return lista;

        }

        public List<CaoModel> ListarCao()
        {
            var lstCao = new List<CaoModel>();
            string sql = $"SELECT Id, Raca, Nome FROM Cao;";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var caoModel = new CaoModel
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Nome = dt.Rows[i]["Nome"].ToString(),
                        Raca = dt.Rows[i]["Raca"].ToString()

                    };
                    lstCao.Add(caoModel);
                }
            }

            return lstCao;
        }


    }
}
