using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KRONOS.pt.mcdonalds;
using System.Data.SqlClient;
using System.Data;

namespace KRONOS.Controllers
{
    public class serviceController : Controller
    {
        // GET: service
        public ActionResult Index(string stringfiltro)
        {
            stringfiltro = string.IsNullOrEmpty(stringfiltro) ? "" : stringfiltro;
            pt.mcdonalds.portugal.mcdonalds_svc Obj = new pt.mcdonalds.portugal.mcdonalds_svc();

            DataSet T = new DataSet();
            T = Obj.GetAllRestaurants();

            SelectListItem linha     = new SelectListItem() { };
            List<SelectListItem> lista = new List<SelectListItem>();

            int contador = 0;
            foreach (DataRow row in T.Tables[0].Rows)
            {
                string x = row[0].ToString();
                string y = row[1].ToString();
                if (y.ToUpper().Contains(stringfiltro.ToUpper()))
                {
                linha = new SelectListItem() { Value = x.ToString(), Text = y.ToString() };
                lista.Add(linha);
                    contador++;
                }
                
            }
           
            ViewBag.lista = lista.ToList();
            ViewBag.contador = contador;

            return View();
        }
    }
}

//o código seguinte permitiu ver a constituição de T, que era desconhecida
//porque não se sabia o que é que o web service devolvia:
//foreach (DataTable table in T.Tables)
//{
//    foreach (DataRow row in table.Rows)
//    {
//        foreach (DataColumn column in table.Columns)
//        {
//            object item = row[column];
//            Response.Write(item.ToString());Response.Write(" | ");
//        }
//    }
//}