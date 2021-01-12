using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Dominio;
using RepositorioEF;

namespace Anuncio2
{
    public class PessoasController : Controller
    {
        private ProjetoEstudoContex db = new ProjetoEstudoContex();

        [Authorize]
        // GET: Pessoas
        public ActionResult Index()
        {
            
            return View();
        }
                

        [Authorize]
        // GET: Pessoas/Details/5
        public ActionResult Details()
        {
                      
            var indice = db.Pessoas.Where(x => x.Email == User.Identity.Name).FirstOrDefault();

            if (indice == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(indice.ID);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }


        [AllowAnonymous]
        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Email,Senha,ConfirmarSenha")] Pessoa pessoa)
        {
            var p = db.Pessoas.Where(x => x.Email == pessoa.Email).FirstOrDefault();
            if (p != null)
            {
                ModelState.AddModelError("Email", "Email já existe");
            }

            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(pessoa.Email, false);
                return RedirectToAction("Index","Anuncios");
            }

            return View(pessoa);
        }

        [Authorize]
        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Email,Senha,ConfirmarSenha")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        [Authorize]
        // GET: Pessoas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pessoa pessoa = db.Pessoas.Find(id);
        //    if (pessoa == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pessoa);
        //}

        //[Authorize]
        //// POST: Pessoas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Pessoa pessoa = db.Pessoas.Find(id);
        //    db.Pessoas.Remove(pessoa);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Pessoa login, string returnUrl)
        {          
                var pessoa = db.Pessoas.Where(x => x.Email == login.Email).FirstOrDefault();
                if (pessoa != null)
                {
                    if (pessoa.Senha == login.Senha)
                    {
                        FormsAuthentication.SetAuthCookie(login.Email, false);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Anuncios");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Senha", "Senha Invalida.");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Login inválido.");
                }
              

            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Anuncios");
        }

    }
}
