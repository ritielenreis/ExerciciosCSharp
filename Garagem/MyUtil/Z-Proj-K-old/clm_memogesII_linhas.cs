using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KRONOS.Models
{
    public class clm_memogesII_linhas
    {

        public int ID { get; set; }

        [Display(Name = "Texto")]
        public string texto { get; set; }

        [Column("DATA")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dataY { get; set; }

        public int parteID { get; set; }
        public virtual clm_memogesII parte { get; set; }


    }
}