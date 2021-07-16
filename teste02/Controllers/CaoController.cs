using Microsoft.AspNetCore.Mvc;
using teste02.Models;

namespace teste02.Controllers
{
    public class CaoController : Controller
    {
        public IActionResult Index()
        {
            var caoModel = new CaoModel();
            var lstCao = caoModel.ListarCao();
            return View(lstCao);
        }

        public IActionResult Create(int donoId)
        {
            var caoModel = new CaoModel() { DonoId = donoId };
            return View(caoModel);
        }

        [HttpPost]
        public IActionResult Create(CaoModel caoModel)
        {

            caoModel.RegistrarCao();

            return RedirectToAction("Index", "Cao");
        }

        public IActionResult Edit(int id)
        {
            var caoModel = new CaoModel { Id = id };
            caoModel.ObterCaoo();
            return View(caoModel);
        }

        [HttpPost]
        public IActionResult Edit(CaoModel caoModel)
        {
            
           
            caoModel.AtualizarCao();
            return RedirectToAction("Index", "Cao");
        }

        public IActionResult Details(int id)
        {
            var caoModel = new CaoModel { Id = id };
            caoModel.ListarCao();
            return View(caoModel);
        }

        

        public IActionResult Delete(int id)
        {
            var donoCaoModel = new DonoCaoModel { CaoId = id };
            var caoModel = new CaoModel { Id = id };
            donoCaoModel.DeletarCaoDono();
            caoModel.DeletarCao();
            return RedirectToAction("Index", "Cao");
        }

        public IActionResult FiltrarCao(CaoModel caoModel)
        {
          
            caoModel.FiltrarCao();
            return RedirectToAction("Index", "Cao");
        }
}
}
