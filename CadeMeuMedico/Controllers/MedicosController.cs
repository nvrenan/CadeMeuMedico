using System.Web.Mvc;
using System.Linq;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        //
        // GET: /Medicos/
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades").ToList();
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
        public ActionResult Adicionar(Medicos medico)
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

        public ActionResult Edit(long id)
        {
            Medicos medico = db.Medicos.Find(id);

        }

    }
}
