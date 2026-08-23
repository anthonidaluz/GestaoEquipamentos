using Microsoft.AspNetCore.Mvc;

namespace GestaoEquipamentos.Modulos.Fabricantes.Apresentacao
{
    public class FabricanteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
