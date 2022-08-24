using ClosedXML.Excel;
using Database.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaRH.Database.Entity;
using SistemaRH.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WebApp.Models;

namespace SistemaRH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //string fileName = "exemplo.xlsx";
            //try
            //{
            //    using (var workbook = new XLWorkbook())
            //    {
            //        IXLWorksheet worksheet =
            //        workbook.Worksheets.Add("Authors");
            //        worksheet.Cell(1, 1).Value = "Id";
            //        worksheet.Cell(1, 2).Value = "FirstName";
            //        worksheet.Cell(1, 3).Value = "LastName";
            //        worksheet.Columns().AdjustToContents(startRow: 1, endRow: 1, minWidth: 8.43, maxWidth: 100);
            //        for (int index = 1; index <= 3; index++)
            //        {
            //            worksheet.Cell(index + 1, 1).Value = 1;
            //            worksheet.Cell(index + 1, 2).Value = "Exemplo";
            //            worksheet.Cell(index + 1, 3).Value = "Exemplo";
            //        }
            //        using (var stream = new MemoryStream())
            //        {
            //            workbook.SaveAs(stream);
            //            var content = stream.ToArray();
            //            return File(content, contentType, fileName);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Error();
            //}
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction(actionName: "LoginUsuario", controllerName: "ContaUsuario");
            }
            else
            {
                AtividadeDPModel ativModel = new AtividadeDPModel();
                
                List<AtividadeDP> atividadesDpList = new List<AtividadeDP>();
                if (User.IsInRole("Administrador"))
                {
                    atividadesDpList = ativModel.GetAllAtividadeDPList(incluirEncerradas: false);
                }
                else
                {
                    ContaUsuarioModel contaUsuarioModel = new ContaUsuarioModel();
                    Usuario usuario = contaUsuarioModel.GetUsuarioByNomeDeUsuario(User.Identity.Name);
                    atividadesDpList = ativModel.GetAtividadeDPListByEmailUsuario(usuario.Email, false);
                }

                atividadesDpList.ForEach(a => a.Status = a.SetStatus());
                ViewData["QntNoPrazo"] = atividadesDpList.Where(a => a.Status == "No prazo").Count();
                ViewData["QntVencendo"] = atividadesDpList.Where(a => a.Status == "Vencendo").Count();
                ViewData["QntAtrasadas"] = atividadesDpList.Where(a => a.Status == "Atrasada").Count();
                ViewData["QntTotal"] = atividadesDpList.Count();

                return View(atividadesDpList);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarAtividadeDP(string inputEmail, string inputPassword)
        {
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
