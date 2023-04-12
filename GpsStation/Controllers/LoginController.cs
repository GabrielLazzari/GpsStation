using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class LoginController : Controller
    {
        LoginModel login = new ();

        public IActionResult Index()
        {
                return View();
        }

        //tipo de retorno do form da view do login
        [HttpPost]
        //método que recebe info do form login
        public void Confirmarlogin()
        {
            if (login.username == Request.Form["username"] && login.password == Request.Form["password"])
            {
                //se correto redireciona para controller Mapa action index
                Response.Redirect("/Mapa/Index");
            }
            else 
                //se errado redireciona para controller Login action index
                Response.Redirect("/Login/Index");

        }
    }
}
