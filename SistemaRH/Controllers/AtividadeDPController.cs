using Microsoft.AspNetCore.Mvc;
using SistemaRH.Database.Entity;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AtividadeDPController : Controller
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EncerrarAtividadeDP(int id)
        {
            AtividadeDPModel ativDpModel = new AtividadeDPModel();

            AtividadeDP atividade = ativDpModel.GetAtividadeDPById(id);

            atividade.Encerrada = true;

            ativDpModel.UpdateAtividadeDP(atividade);

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarAtividadeDP(int id)
        {
            AtividadeDPModel ativDpModel = new AtividadeDPModel();

            AtividadeDP atividade = ativDpModel.GetAtividadeDPById(id);

            atividade.Encerrada = true;

            ativDpModel.DeletarAtividadeDP(atividade);

            return RedirectToAction(actionName: "Index", controllerName: "Home");
            //return View("~/Views/Home/Index.cshtml", atividadesDpList);
        }

    }
}
