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
            var medicos = db.Medicos.Include(m => m.Cidades).Include(m => m.Especialidades).ToList();
            return View(medicos);
        }

    }
}
