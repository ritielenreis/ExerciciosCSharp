using System;
using System.Web.Mvc;
using KRONOS.DAL;
using APPLisTel.Models;

using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Ngeral.Controllers
{
    public class myfuncs : Controller
    {
        public static string bomdia()
        {
            string s;
            if (DateTime.Now.Hour < 12) s = "bd";
            else if (DateTime.Now.Hour < 20) s = "bt";
            else s = "bn";
            return s;
        }

        public static string greeting(string s)
        {
            string r;

            //s=Convert.ToString(Session["user"]);

            if (s == "" || s == null)
                r = bomdia(); //+ ", sem login.";
            else
                r = bomdia() + ", " + s;

            return r;

        }
    }

    public class estado
    {//usada para controlar a inicilização dos radiobuttons na app clireu
        public string historico = "N";
        public string importante = "T"; //Sim, Não, Todas,... em vez de bool -> string...
        public string reservada = "N";


        public string cliid_na_drop;
        public string x;
        // public string clinome_na_drop;

    }



    public class Copyfile
    {
        public void funccopia(string origem, string nomefile)
        {
            string fileName = nomefile;
            string sourcePath = origem;
            string targetPath = @"d:\kronosbk";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            //if (System.IO.Directory.Exists(sourcePath))
            //{
            //    string[] files = System.IO.Directory.GetFiles(sourcePath);

            //    // Copy the files and overwrite destination files if they already exist.
            //    foreach (string s in files)
            //    {
            //        // Use static Path methods to extract only the file name from the path.
            //        fileName = System.IO.Path.GetFileName(s);
            //        destFile = System.IO.Path.Combine(targetPath, fileName);
            //        System.IO.File.Copy(s, destFile, true);
            //    }
            //}
            //else
            //{
            //    //Console.WriteLine("Source path does not exist!");
            //}

        }
    }


   
}
