using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Laboratorio_LINQ_XML_Lizarraga.Models;

namespace Laboratorio_LINQ_XML_Lizarraga.Controllers
{
    public class CursosController : Controller
    {
        // GET: Cursos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            //Trabajando con el metodo ListarCursos()
            ClsCursos objCursos = new ClsCursos();
            var data = objCursos.ListarCursos();
            return View(data.ToList());
        }

        public ActionResult ListarCursos2(ClsCursos objCurso)
        {
            //Trabajando con el metodo ListarCursos2()
            return View(objCurso.ListarCursos2());
        }

        public ActionResult ObtenerCodigo(ClsCursos objCurso, String codigo)
        {
            if (codigo == "" || codigo == null)
            {
                return View(objCurso.ListarCursos());
            } 
            
            else
            {
                return View(objCurso.ObtenerporCodigo(codigo));
            }            
        }

        public ActionResult ObtenerCodigo2(ClsCursos objCurso, String codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return View(objCurso.ListarCursos2());
            }
            return View(objCurso.ObtenerporCodigo2(codigo));
        }
    }
}