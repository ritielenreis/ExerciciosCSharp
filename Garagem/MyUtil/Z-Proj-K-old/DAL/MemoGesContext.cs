using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MemoGes.Models;

namespace MemoGes.DAL
{
    public class MemoGesContext : DbContext

    {
        public DbSet<CLMemoges> TMemoGes { get; set; }
    }
}