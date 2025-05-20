using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using KRONOS.Models;
using APPLisTel.Models; //namespace da aplicação de onde veio o login


namespace KRONOS.DAL
{
    public class clContext : DbContext

    {
        public DbSet<clm_contactos> Tcontactos { get; set; }
        public DbSet<clm_clientes> Tclientes { get; set; }

        public DbSet<clLogin> Tlogin { get; set; } //adicionada para controlo da autenticação

        public DbSet<clm_memogesI> TMemoGesI { get; set; }//migrada da class memoges, para ter apenas 1 DB; 170403
        //Kronos.Models != KRONOS.Models !.....



        public DbSet<clm_memogesII> Tmemoges { get; set; }
        public DbSet<clm_memogesII_linhas> Tmemogeslinhas { get; set; }


        public DbSet<clm_clireu> Tclireu { get; set; }

    }
}