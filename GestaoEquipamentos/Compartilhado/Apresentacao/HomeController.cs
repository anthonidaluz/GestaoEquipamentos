using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Compartilhado.Apresentacao;

public class HomeController : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

}
