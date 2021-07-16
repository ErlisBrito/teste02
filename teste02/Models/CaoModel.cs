using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

using teste02.Util;
using Xunit;
using Xunit.Sdk;

namespace teste02.Models
{
    public class CaoModel
    {
        public int Id { get; set; }

        public int DonoId { get; set; }

        [Required(ErrorMessage = "Informe o nome do seu cão!")]
        public string Nome { get; set; }

        [Display(Name = "Raça"), Required(ErrorMessage = "Informe a raça do seu cão!")]
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
            var cao = ObterCao();
            var donoCaoModel = new DonoCaoModel();
            donoCaoModel.CaoId = cao.Id;
            donoCaoModel.DonoId = DonoId;
            donoCaoModel.InserirDonoCao();


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
            string sql = $"SELECT * FROM Cao where Raca ='{Raca}'";
            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count == 1)
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString());
                Nome = dt.Rows[0]["Nome"].ToString();
                Raca = dt.Rows[0]["Raca"].ToString();
            }
        }

        public CaoModel ObterCao()
        {
            string sql = $"SELECT Id, Nome, Raca FROM Cao WHERE Nome = '{Nome}' " +
                $"AND Raca = '{Raca}'";
            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            var caoModel = new CaoModel();
           

            if (dt != null && dt.Rows.Count == 1)
            {
                caoModel.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                caoModel.Nome = dt.Rows[0]["Nome"].ToString();
                caoModel.Raca = dt.Rows[0]["Raca"].ToString();
            }
            return caoModel;
        }

        public void ObterCaoo()
        {
            string sql = $"SELECT Id, Raca, Nome FROM Cao WHERE Id = {Id}";
            var objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if (dt != null && dt.Rows.Count == 1)
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString());
                Raca = dt.Rows[0]["Raca"].ToString();
                Nome = dt.Rows[0]["Nome"].ToString();
            }
        }
   
    }
}
