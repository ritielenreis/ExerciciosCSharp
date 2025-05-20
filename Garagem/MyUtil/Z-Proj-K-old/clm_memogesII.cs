using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRONOS.Models
{
    public class clm_memogesII
    {
        public int ID { get; set; }

        [Display(Name = "Item")]
        public string item { get; set; }
                            
        public virtual ICollection<clm_memogesII_linhas> linha { get; set; }

    }



}