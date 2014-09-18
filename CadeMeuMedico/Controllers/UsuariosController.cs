﻿using System.Web.Mvc;
using CadeMeuMedico.Repositorios;

namespace CadeMeuMedico.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/
        [HttpGet]
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (RepositorioUsuarios.AutenticarUsuario(Login, Senha))
            {
                return Json(new
                {
                    OK = true,
                    Mensagem = "Usuário autenticado. Redirecionando..."
                },
                    JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                OK = false,
                Mensagem = "Usuário não encontrando. Tente novamente."
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}