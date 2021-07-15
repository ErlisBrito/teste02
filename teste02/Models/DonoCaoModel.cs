using System.Collections.Generic;
using teste02.Util;

namespace teste02.Models
{
    public class DonoCaoModel
    {
        public int CaoId { get; set; }
        public int DonoId { get; set; }

        public List<CaoModel> CaoModels { get; set; }

        public List<CaoModel> ListarCao()
        {
            var cao = new CaoModel();
            var lstCao = cao.ListarCao();
            return lstCao;
        }

        
        public void InserirDonoCao()
        {
                      
            string sql = $"INSERT INTO Cao_Dono(Donos_Id, Caes_Id) VALUES({DonoId}, {CaoId});";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    
    public void DeletarDonoCao()
        {
            string sql = $"DELETE FROM Cao_Dono WHERE Donos_Id = {DonoId};";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }

        public void DeletarCaoDono()
        {
            string sql = $"DELETE FROM Cao_Dono WHERE Caes_Id = {CaoId};";
            var objDAL = new DAL();
            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
