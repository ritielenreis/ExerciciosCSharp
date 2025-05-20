using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace KRONOS.Controllers
{
    public class BackupDBController : Controller
    {
        // GET: BackupDB
        //BACKUP DA BASE DE DADOS SQLSERVER #########################################################################
        public ActionResult Index(String nomebackup)
        {
            if (!string.IsNullOrEmpty(nomebackup))
            {
                string SC = "server=LEOPARDO,62444;database=K200;uid=sa;password=123.abc;";
                SqlConnection con = new SqlConnection(SC);
                SqlCommand sqlcmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                con.Open();

                string s = constroiDBnome(nomebackup);                

                sqlcmd = new SqlCommand(@"backup database K200 to disk= 'd:\KRONOSbk\" + s + ".bak'", con);
                sqlcmd.ExecuteNonQuery();
                con.Close();
                ViewBag.pasta = "D:\\KronosBK";
                ViewBag.nome = s;
            }
            return View();
        }

                            public string constroiDBnome(string v)

                            {
                                string s;
                                string d = System.DateTime.Now.ToString();

                                s = d.Replace(':', '-'); //os nomes de ficheiros não podem ter ":"
                                s = s + "("+ v +")"; //junta o que vem da View
                                
                                s = s + "(PJMC)";
            
                                return s;
                            }
    }

    
}