using Microsoft.AspNetCore.Mvc;

namespace GestaoEquipamentos.Compartilhado.Apresentacao
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
