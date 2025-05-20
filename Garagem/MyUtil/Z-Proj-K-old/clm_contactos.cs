using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRONOS.Models
{
    public class clm_contactos
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string cliente { get; set; }

        [Display(Name = "Telefone(s)")]
        public string telefone { get; set; }

        [Display(Name = "Email")]
        public string telemovel { get; set; }
        
        [Display(Name = "Morada & CP")]
        public string morada { get; set; }

        [Display(Name = "Anotações 1")]
        public string anotacoes1 { get; set; }

        [Display(Name = "Anotações 2")]
        public string anotacoes2 { get; set; }


    }
}