using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Laboratorio_LINQ_XML_Lizarraga.Models
{
    [Serializable]
    [XmlRoot("cursos"), XmlType("cursos")]
    public class ClsCursos
    {
        public String codigo { get; set; }
        public String nombre { get; set; }
        public int horas { get; set; }
        public int creditos { get; set; }
        public String prerequisito { get; set; }



        public List<ClsCursos> ListarCursos()
        {
            //Definir el origen de datos
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/cursos.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);

            //Definir la sentencia LINQ
            var objCursos = new List<ClsCursos>();
            objCursos = (from col in ds.Tables[0].AsEnumerable()
                         select new ClsCursos
                         {
                             codigo = col[0].ToString(),
                             nombre = col[1].ToString(),
                             horas = int.Parse(col[2].ToString()),
                             creditos = Convert.ToInt32(col[3].ToString()),
                             prerequisito = col[4].ToString(),
                         }).ToList();

            //Devuelva los registros
            return objCursos;
        }


        public List<ClsCursos> ListarCursos2()
        {
            //Definir el origen de datos
            XDocument xmlData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/cursos.xml"));
          
            //Definir la sentencia LINQ
            var objCursos = new List<ClsCursos>();
            objCursos = (from col in xmlData.Descendants("curso")
                         orderby col.Element("nombre").ToString()
                         select new ClsCursos()
                         {
                             codigo = col.Element("codigo").Value,
                             nombre = col.Element("nombre").Value,
                             horas = int.Parse(col.Element("horas").Value),
                             creditos = Convert.ToInt32(col.Element("creditos").Value),
                             prerequisito = col.Element("prerequisito").Value,
                         }).ToList();

            //Devuelva los registros
            return objCursos;
        }


        public List<ClsCursos> ObtenerporCodigo(string codigo)
        {
            //Definir el origen de datos
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/cursos.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(xmlData);

            //Definir la sentencia LINQ
            var objCursos = new List<ClsCursos>();
            objCursos = (from col in ds.Tables[0].AsEnumerable()
                         where col[0].ToString() == (codigo)
                         select new ClsCursos()
                         {
                             codigo = col[0].ToString(),
                             nombre = col[1].ToString(),
                             horas = int.Parse(col[2].ToString()),
                             creditos = Convert.ToInt32(col[3].ToString()),
                             prerequisito = col[4].ToString(),
                         }).ToList();

            //Devuelva los registros
            return objCursos;
        }


        public List<ClsCursos> ObtenerporCodigo2(string codigo)
        {
            //Definir el origen de datos
            XDocument xmlData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/cursos.xml"));

            //Definir la sentencia LINQ
            var objCursos = new List<ClsCursos>();
            objCursos = (from col in xmlData.Descendants("curso")
                         where col.Element("codigo").Value.ToString() == (codigo)
                         select new ClsCursos()
                         {
                             codigo = col.Element("codigo").Value,
                             nombre = col.Element("nombre").Value,
                             horas = int.Parse(col.Element("horas").Value),
                             creditos = Convert.ToInt32(col.Element("creditos").Value),
                             prerequisito = col.Element("prerequisito").Value,
                         }).ToList();

            //Devuelva los registros
            return objCursos;
        }
    }    
}