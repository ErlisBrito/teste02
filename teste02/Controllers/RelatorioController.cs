using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using teste02.Models;

namespace teste02.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            var relatorioModel = new RelatorioModel();
            var lstRelatorio = relatorioModel.ListarRelatorio();
            return View(lstRelatorio);
        }

        public IActionResult ExportExcel()
        {
            var relatorioModel = new RelatorioModel();
            var lstRelatorio = relatorioModel.ListarRelatorio();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tr>DonoId</tr>");
            sb.Append("<tr>Nome</tr>");
            sb.Append("<tr>CaoId</tr>");
            sb.Append("<tr>Raça</tr>");
            sb.Append("<tr>Nome do Cão</tr>");
            foreach (var item in lstRelatorio)
            {
                sb.Append($"<td>{item.DonoId}</td>");
                sb.Append($"<td>{item.Nome}</td>");
                sb.Append($"<td>{item.CaoId}</td>");
                sb.Append($"<td>{item.Raca}</td>");
                sb.Append($"<td>{item.CaoNome}</td>");
            }

            sb.Append("</table>");

            // Return FileResult
            byte[] byteArray = Encoding.UTF8.GetBytes(sb.ToString());
            return File(new MemoryStream(byteArray, 0, byteArray.Length), "application/octet-stream", $"relatorio.xlsx");


        }
    }
}
