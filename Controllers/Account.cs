using Microsoft.AspNetCore.Mvc;

namespace TP09_LoginMVCyJavaScript.Controllers;

public class Account : Controller
{

    public IActionResult Login(){
        ViewBag.ListaUsuarios = BD.LoginUsuario;
        return View();
    }

    public IActionResult Registro(){
        ViewBag.
        return View();
    }

    public IActionResult Olvide(){

        return View();
    }

    public IActionResult PaginaBienvenida(){

        return View();
    }



}
