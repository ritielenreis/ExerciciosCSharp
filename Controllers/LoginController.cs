using Microsoft.AspNetCore.Mvc;
using PKX.Data;
using PKX.Models;

namespace PKX.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbp;

        public LoginController(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        // POST: /Login

        [HttpPost]
        public IActionResult Index(string nome, string senha)
        {

            Utilizador u = new Utilizador();
            if (nome != null || senha != null)
            {
                u = dbp.Utilizadores.FirstOrDefault(i => i.NomeUtilizador == nome && i.Senha == senha);

                if (u != null && u.NomeUtilizador != null)
                {
                    HttpContext.Session.SetString("UTILIZADOR", u.NomeUtilizador);
                    if (u.Administrador == true)
                    {
                        HttpContext.Session.SetString("Privilegios", "true");
                    }
                    return Redirect("Home");
                }
            }
            else
            {
                HttpContext.Session.SetString("UTILIZADOR", "");
            }
            return View();
        }

        public IActionResult Logout()
        {
            // Remove todas as variáveis da sessão
            HttpContext.Session.SetString("UTILIZADOR", "##");

            // Redireciona para a tela de login
            return RedirectToAction("Index", "Login");
        }


        public IActionResult Sucesso()
        {
            return View();
        }
    }
}
