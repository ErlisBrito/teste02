using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using teste02.Util;

namespace teste02.Models
{
    public class DonoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe seu Nome!")]
        public string Nome { get; set; }

        public List<CaoModel> ListaCaoModel { get; set; }


        public List<DonoModel> ListarDono()
        {
            var lstDono = new List<DonoModel>();
            string sql = $"SELECT Id, Nome FROM Dono;";
            DAL objDAL = new();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var donoModel = new DonoModel
                    {
                        Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                        Nome = dt.Rows[i]["Nome"].ToString()
                    };

                    donoModel.ListaCaoModel = ObterCaoDono(donoModel.Id);
                    lstDono.Add(donoModel);

                }
            }

            return lstDono;
        }


        public void RegistrarDono()
        {

            string sql = $"INSERT INTO Dono(Nome) VALUES('{Nome}');";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }


        public void AtualizarDono()
        {
            string sql = $"UPDATE Dono SET Id = '{Id}', Nome = '{Nome}' WHERE Id = { Id }; ";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);

        }

        public void DeletarDono()
        {
            string sql = $"DELETE FROM Dono WHERE Id = {Id};";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void ObterDono()
        {
            string sql = $"SELECT Id, Nome FROM Dono WHERE Id = {Id}";
            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count == 1)
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString());
                Nome = dt.Rows[0]["Nome"].ToString();
            }
        }

        private List<CaoModel> ObterCaoDono(int donoId)
        {
            ListaCaoModel = new List<CaoModel>();
            string sql = @$"SELECT 
                            cao.Id AS CaoId,
                            cao.Nome AS CaoNome
                             FROM Dono dono
                            Inner JOIN Cao_Dono caoDono on caoDono.Donos_Id = dono.Id
                            Inner JOIN Cao cao on caoDono.Caes_Id = cao.Id 
                            WHERE dono.Id = {donoId}";

            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);


            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var caoModel = new CaoModel
                    {
                        Id = int.Parse(dt.Rows[i]["CaoId"].ToString()),
                        Nome = dt.Rows[i]["CaoNome"].ToString()

                    };
                    ListaCaoModel.Add(caoModel);
                }

            }
            return ListaCaoModel;
        }

    }
}

