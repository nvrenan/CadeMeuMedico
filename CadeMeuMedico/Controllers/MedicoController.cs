using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class MedicoController : Controller
    {
        //
        // GET: /Medicos/
        private readonly EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            List<Medico> medicos = db.Medicos.Include(m => m.Cidade).Include(m => m.Especialidade).ToList();
            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
                "IDEspecialidade",
                "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade",
                "Nome",
                medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
                "IDEspecialidade",
                "Nome",
                medico.IDEspecialidade);
            return View(medico);
        }

        public ActionResult Editar(long id)
        {
            Medico medico = db.Medicos.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade",
                "Nome",
                medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
                "IDEspecialidade",
                "Nome",
                medico.IDEspecialidade);
            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade",
                "Nome",
                medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,
                "IDEspecialidade",
                "Nome",
                medico.IDEspecialidade);
            return View(medico);
        }
    }
}