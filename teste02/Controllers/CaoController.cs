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

        public IActionResult Create()
        {
            return View();
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
            caoModel.ObterCao();
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
            caoModel.ObterCao();
            return View(caoModel);
        }

        public IActionResult Delete(int id)
        {
            var caoModel = new CaoModel { Id = id };
            caoModel.DeletarCao();
            return RedirectToAction("Index", "Cao");
        }
    }
}
