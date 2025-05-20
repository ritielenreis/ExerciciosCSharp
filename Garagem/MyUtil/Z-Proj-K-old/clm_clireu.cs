using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace KRONOS.Models
{
    public class clm_clireu
    {

        public int ID { get; set; }

        [Display(Name = "Texto")]
        public string textodescricao { get; set; }

        [Column("DATA")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dataY { get; set; }


        [Display(Name = "Presentes")]
        public string textopresentes { get; set; }

        [Display(Name = "I?")]
        public bool Importante { get; set; }

        [Display(Name = "R?")]
        public bool Reservado { get; set; }

        //apenas as linhas importantes mas não reservadas se podem mostrar a um cliente:
        //[Display(Name = "Impress.?")]
        //public string mostravel
        //        {
        //            get
        //                    {
        //                        string s = ".";
        //                        if (Importante && !Reservado) { s = "S"; }
        //                        return s;          
        //                    }
        //            set {
        //                ;
        //                 }
        //        }

        [Display(Name = "H?")]
        public bool historico { get; set;}

        [Display(Name = "Autor?")]
        public string Autor  { get; set; }

        [Display(Name = "Cliente")]
        public int cliID { get; set; }
        public virtual clm_clientes cli { get; set; }
      
    }
}