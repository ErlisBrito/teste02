using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste02.Models;

namespace teste02.Controllers
{
    public class DonoController : Controller
    {
        public IActionResult Index()
        {
            var donoModel = new DonoModel();
            var lstDono = donoModel.ListarDono();
            return View(lstDono);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DonoModel donoModel)
        {
            donoModel.RegistrarDono();
            return RedirectToAction("Index", "Dono");
        }

        public IActionResult Edit(int id)
        {
            var donoModel = new DonoModel { Id = id };
            donoModel.ObterDono();
            return View(donoModel);
        }

        [HttpPost]
        public IActionResult Edit(DonoModel donoModel)
        {
            donoModel.AtualizarDono();
            return RedirectToAction("Index", "Dono");
        }

        public IActionResult Details(int id)
        {
            var donoModel = new DonoModel { Id = id };
            donoModel.ObterDono();
            return View(donoModel);
        }

        public IActionResult Delete(int id)
        {
            var donoCaoModel = new DonoCaoModel { DonoId = id };
            var donoModel = new DonoModel { Id = id };
            donoCaoModel.DeletarDonoCao();
            donoModel.DeletarDono();
            return RedirectToAction("Index", "Dono");
        }

        public IActionResult CadastrarCao(int donoId)
        {
            var donoCao = new DonoCaoModel
            {
                DonoId = donoId
            };
            var cao = new CaoModel();
            var lstCao = cao.ListarCao();
            ViewBag.Cao = lstCao;
            return View(donoCao);
        }

        [HttpPost]
        public IActionResult CadastrarCao(DonoCaoModel donoCaoModel)
        {
            donoCaoModel.InserirDonoCao();
            return RedirectToAction("Index", "Dono");
        }
    }
}
