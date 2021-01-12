using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio;
using RepositorioEF;

namespace Anuncio2
{
    public class AnunciosController : Controller
    {
        private ProjetoEstudoContex db = new ProjetoEstudoContex();

        [AllowAnonymous]
        // GET: Anuncios
        public ActionResult Index()
        {
            var anuncios = db.Anuncios.Include(a => a.Pessoa);

            return View(anuncios.ToList());
        }

        [Authorize]
        public ActionResult MeusAnuncios() {
            var anuncios = db.Anuncios.Include(a => a.Pessoa);
            List<Anuncio> anun = new List<Anuncio>();

            foreach (var item in anuncios.ToList())
            {
                if (item.Pessoa.Email == User.Identity.Name)
                {
                   anun.Add(item);
                }
            } 


            return View(anun);

            
        }

        [Authorize]
        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        [Authorize]
        // GET: Anuncios/Create
        public ActionResult Create()
        {
            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome");
            return View();
        }

        [Authorize]
        // POST: Anuncios/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Data,PessoaID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Anuncios.Add(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome", anuncio.PessoaID);
            return View(anuncio);
        }

        [Authorize]
        // GET: Anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome", anuncio.PessoaID);
            return View(anuncio);
        }

        [Authorize]
        // POST: Anuncios/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Data,PessoaID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PessoaID = new SelectList(db.Pessoas, "ID", "Nome", anuncio.PessoaID);
            return View(anuncio);
        }

        [Authorize]
        // GET: Anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        [Authorize]
        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            db.Anuncios.Remove(anuncio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
