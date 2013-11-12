using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstadoCidadeAjax.Models;

namespace EstadoCidadeAjax.Controllers
{
    public class EstadoController : Controller
    {
        private TesteContext db = new TesteContext();

        // GET: /Estado/
        public ActionResult Index()
        {
            return View(db.Estado.ToList());
        }

        // GET: /Estado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // GET: /Estado/Create
        public ActionResult Create()
        {
            Estado estado = new Estado();
            estado.UsuarioCadId = 1;
            estado.DataHoraCad = DateTime.Now;
            return View(estado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoId,CodigoIBGE,Sigla,Descricao,UsuarioCadId,DataHoraCad,Ativo")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Estado.Add(estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado);
        }

        // GET: /Estado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Estado estado = db.Estado.Find(id);


            if (estado == null)
            {
                return HttpNotFound();
            }

            EstadoModel estadoModel = new EstadoModel();
            estadoModel.Estado = estado;
            estadoModel.Cidade = new CidadeModel()
            {
                EstadoId = estado.EstadoId,
                Cidades = db.Cidade.ToList()
            };

            return View(estadoModel);
        }

        [HttpPost]
        public ActionResult SalvarCidade(Cidade cidade)
        {
            db.Cidade.Add(cidade);
            db.SaveChanges();


            CidadeModel cidadeModel = new CidadeModel()
            {
                EstadoId = cidade.EstadoId,
                Cidades = db.Cidade.ToList()
            };

            return PartialView("_Cidades", cidadeModel);
        }

        [HttpPost]
        public ActionResult ExcluirCidade(Cidade cidade)
        {            
            if (ModelState.IsValid)
            {
                db.Cidade.Remove(db.Cidade.FirstOrDefault(a => a.CidadeId == cidade.CidadeId));
                db.SaveChanges();
            }

            CidadeModel cidadeModel = new CidadeModel()
            {
                EstadoId = cidade.EstadoId,
                Cidades = db.Cidade.ToList()
            };

            return PartialView("_Cidades", cidadeModel);



        }

        // POST: /Estado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoId,CodigoIBGE,Sigla,Descricao,UsuarioCadId,DataHoraCad,Ativo")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado);
        }

        // GET: /Estado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: /Estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado estado = db.Estado.Find(id);
            db.Estado.Remove(estado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



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
