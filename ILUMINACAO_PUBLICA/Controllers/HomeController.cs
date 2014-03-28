using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ILUMINACAO_PUBLICA.Models;
using WebMatrix.WebData;

namespace ILUMINACAO_PUBLICA.Controllers
{
    public class HomeController : Controller
    {
        private ILUMINACAO_PUBLICAContext db = new ILUMINACAO_PUBLICAContext();

        [Authorize(Roles = "Admin, Master, Acompanhamento,Convidado")]
        public ActionResult Index(int? selecionado)
        {
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            var usuario = db.UserProfiles.Where(u => u.UserId == userID).First();
            var prefeituraID = usuario.PrefeituraID;
            #region redirecionamento
            if (usuario.PosMenu1 != null)
            {
                switch (usuario.PosMenu1)
                {
                    case 1: // Desenvolvimento
                    return PartialView("~/Views/Tabela1/_Corpo.cshtml");
                }
            }

            #endregion

            return View();
        }

        #region Navegação
        
        public ActionResult SelecionaMenuH1(int? selecionado)
        {
            // Identifica o usuario logado
            int userID = WebSecurity.GetUserId(User.Identity.Name);
            var usuario = db.UserProfiles.Where(u => u.UserId == userID).First();
            usuario.PosMenu1 = selecionado;

            //if (User.IsInRole("Convidado"))
            //{
            //    usuario.PosMenu1 = 4;
            //    usuario.PosMenu2 = null;
            //    usuario.PosMenu3 = null;
            //}


            //switch (selecionado)
            //{
            //    case 2: // Cadastros iniciais
            //        usuario.PosMenu2 = 1;
            //        usuario.PosMenu3 = null;
            //        break;
            //    case 3: // propostas
            //        usuario.PosMenu2 = null;
            //        usuario.PosMenu3 = null;
            //        break;
            //    case 4: // Cadastros iniciais
            //        usuario.PosMenu2 = 4;
            //        usuario.PosMenu3 = null;
            //        break;
            //    default:
            //        usuario.PosMenu2 = null;
            //        usuario.PosMenu3 = null;
            //        break;

            //}
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
