using System.Collections.Generic;
using System.Data;

using teste02.Util;

namespace teste02.Models
{
    public class CaoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Raca { get; set; }
        
   

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

        public void RegistrarCao()
        {
            string sql = $"INSERT INTO Cao(Raca, Nome) VALUES ('{Raca}','{Nome}');";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void AtualizarCao()
        {
            string sql = $"UPDATE Cao SET Raca='{Raca}', Nome='{Nome}' WHERE Id = {Id}";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);

        }

        public void DeletarCao()
        {
            string sql = $"DELETE FROM Cao WHERE Id = {Id}";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);

        }

        public void FiltrarCao()
        {
            string sql = $"SELECT Raca, Nome FROM Cao WHERE Id = {Id}";
            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count == 1)
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString());
                Nome = dt.Rows[0]["Nome"].ToString();
                Raca = dt.Rows[0]["Raca"].ToString();
            }
        }
    }
}
