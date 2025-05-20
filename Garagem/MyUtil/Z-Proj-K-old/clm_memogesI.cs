using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//ex: display name
using System.ComponentModel.DataAnnotations.Schema;
namespace KRONOS.Models
{


    public class clm_memogesI    


    {
        public int ID { get; set; }
        [Display(Name = "Item")]        public string item { get; set; }
        [Display(Name = "Texto 1")]        public string texto1 { get; set; }

        [Display(Name = "Texto 2")]        public string texto2 { get; set; }
        
    }
}