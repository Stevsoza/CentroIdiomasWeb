using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMVC.Controllers
{

    public class HomeController : Controller
    {

        private readonly contextoAplicacion _context;

        /*private readonly ILogger<HomeController> _logger;*/

        public HomeController(contextoAplicacion context)
        {
            _context = context;
        }

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public static int _id_estudiante;

        public Curso _cursoMatricular;


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Iniciar(Curso curso)
        {
            int id;

            if (Convert.ToInt32(TempData["id"]) != 0)
            {
                id = Convert.ToInt32(TempData["id"]);
                _id_estudiante = id;
            }
            else
            {
                id = _id_estudiante;
            }

            ViewBag.Idiomas = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Ingles", Value = "1"},
                new SelectListItem{ Text = "Aleman", Value = "2"},
                new SelectListItem{ Text = "Frances", Value = "3"},
                new SelectListItem{ Text = "Mandarin", Value = "3"},
            };

            Estudiante actualEst = _context.Estudiante.Find(id);
            IEnumerable<CursoEstudiante> ListaCursos = _context.CursoEstudiante.Where(c => c.Id_estudiante == id);

            ViewData["Cursos"] = ListaCursos;
            if (curso != null)
            {
                ViewData["Curs_mat"] = curso;
            }
            else
            {
                ViewData["Curs_mat"] = null;
            }

            Programa nuevoPrograma = new Programa();

            ViewData["Programa"] = nuevoPrograma;
            TempData["estudiante"] = id;

            return View(actualEst);
        }


        [HttpPost]
        public IActionResult Iniciar(Estudiante estudiante)
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inicio(Login login)
        {
            if (ModelState.IsValid)
            {
                var consulta = (from log in _context.login
                                where log.Usuario == login.Usuario
                                select log).FirstOrDefault();

                if (consulta != null)
                {
                    TempData["id"] = consulta.Id_estudiante;
                    return RedirectToAction("Iniciar");
                }
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Registro(Login login, Estudiante estudiante)
        {

            if (ModelState.IsValid)
            {

                _context.Add(estudiante);
                _context.SaveChanges();

                login.Id_estudiante = estudiante.Id_estudiante;

                _context.Add(login);
                _context.SaveChanges();
                TempData["msg"] = "<script>alert('Se guardo el usuario');</script>";
            }
            return RedirectToAction("Index");
        }


        public IActionResult Curso_matricular(Curso curso)
        {
            return RedirectToAction("Iniciar", curso);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuscarCurso(Programa programa)
        {
            int idPrograma = Convert.ToInt32(programa.Idioma);

            int idEst = (int)TempData["estudiante"];

            if (programa != null)
            {
                IEnumerable<CursoEstudiante> cursosEst = _context.CursoEstudiante.Where
                (c => c.Id_estudiante == idEst).ToList();

                Curso Curso_matricularB;

                var query = (from cursE in _context.CursoEstudiante
                             join cursC in _context.curso
                             on cursE.Id_curso equals cursC.Id_curso
                             join prog in _context.programa
                             on cursC.Id_programa equals prog.Id_programa
                             where prog.Id_programa == idPrograma && cursE.Id_estudiante == idEst
                             select cursE).ToList();

                if (query.Count == 0)
                {
                    var query2 = (from cursC in _context.curso
                                  where cursC.Id_programa == idPrograma
                                  select cursC).FirstOrDefault();
                    Curso_matricularB = query2;                    
                    return RedirectToAction("Curso_matricular", Curso_matricularB);
                }
                else
                {
                    var query3 = (from cursC in _context.curso
                                  join cursE in _context.CursoEstudiante on cursC.Id_curso equals cursE.Id_curso into cursR
                                  from cursE in cursR.DefaultIfEmpty()
                                  where cursC.Id_programa == idPrograma && cursE == null
                                  select cursC).FirstOrDefault();
                    Curso_matricularB = query3;
                    return RedirectToAction("Curso_matricular", Curso_matricularB);
                }

                
            }
            return RedirectToAction("Iniciar");
        }
    }
}
