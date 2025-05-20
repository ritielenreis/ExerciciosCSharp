using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KRONOS.DAL;
using APPLisTel.Models;
using Ngeral.Controllers;
using System.Configuration;

namespace KRONOS.Controllers
{ 
    //EXECUTAR CÓPIA FÍSICA DE FICHEIRO
    public class BackupController : Controller
    {
        public clContext db = new clContext();
        // GET: Backup
        public ActionResult Index(String nomebackup)
        {

        //PARTE UM: CÓPIA FÍSICA DE FICHEIRO #################################################################################
        //funciona; copia o dicheiro especificado de ... para ...
        Copyfile Obj = new Copyfile();
        Obj.funccopia(@"D:\Contentor 2016&2017+\Canhoto", "Canhoto 2016.09-2017.12.xlsx");
            return View();
        }
    }
}




//SqlConnection con = new SqlConnection();
//SqlCommand sqlcmd = new SqlCommand();
//SqlDataAdapter da = new SqlDataAdapter();
//DataTable dt = new DataTable();

//con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConString"].ConnectionString;
//            string backupDIR = "~/BackupDB";
//string path = Server.MapPath(backupDIR);

//            try
//            {
//                var databaseName = "MyFirstDatabase";
//con.Open();
//                string saveFileName = "HiteshBackup";
//sqlcmd = new SqlCommand("backup database" +databaseName.BKSDatabaseName + "to disk='" + path + "\\" + saveFileName + ".Bak'", con);
//sqlcmd.ExecuteNonQuery();
//                con.Close();                 


//                ViewBag.Success = "Backup database successfully";
//                return View("Create");
//            }
//            catch (Exception ex)
//            {
//                ViewBag.Error = "Error Occured During DB backup process !<br>" + ex.ToString();
//                return View("Create");
//            }

