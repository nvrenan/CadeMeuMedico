﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class MensagensController : Controller
    {
        // GET: MensagensController
        public ActionResult BomDia()
        {
            return Content("Bom dia....hoje você acordou cedo");
        }

        public ActionResult Boatarde()
        {
            return Content("Boa tarde....não durma na mesa do trabalho");
        }
    }
}