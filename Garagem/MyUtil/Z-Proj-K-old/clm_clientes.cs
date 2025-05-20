using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KRONOS.Models
{
    public class clm_clientes
    {

        public int ID { get; set; }

        [Display(Name = "#Cli")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string codcli { get; set; }


        [Display(Name = "Nome cliente")]
        public string cliente { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "Telemóvel")]
        public string telemovel { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Fax")]
        public string fax { get; set; }
        [Display(Name = "Morada")]
        public string morada { get; set; }
        [Display(Name = "#Postal")]
        public string CP { get; set; }
        [StringLength(9, ErrorMessage = "Máx. carateres")]
        public string NIF { get; set; }

        [Display(Name = "Cód. cert. permanente")]
        public string codcerper { get; set; }

        [Display(Name = "Login AT")]
        public string PortalAT_login { get; set; }
        [Display(Name = "Senha AT")]
        public string PortalAT_senha { get; set; }

        [Display(Name = "Login SS")]
        public string PortalSS_login { get; set; }
        [Display(Name = "Senha SS")]
        public string PortalSS_senha { get; set; }

        [Display(Name = "Login IAPMEI")]
        public string PortalIAPMEI_login { get; set; }
        [Display(Name = "Senha IAPMEI")]
        public string PortalIAPMEI_senha { get; set; }

        [Display(Name = "Login VCTT")]
        public string PortalVCTT_login { get; set; }
        [Display(Name = "Senha VCTT")]
        public string PortalVCTT_senha { get; set; }

        [Display(Name = "Login IEFP")]
        public string PortalIEFP_login { get; set; }
        [Display(Name = "Senha IEFP")]
        public string PortalIEFP_senha { get; set; }

        [Display(Name = "Login INE")]
        public string PortalINE_login { get; set; }
        [Display(Name = "Senha INE")]
        public string PortalINE_senha { get; set; }

        [Display(Name = "Log. Fundo compens.")]
        public string Fundo_comp_login { get; set; }
        [Display(Name = "Senh. Fundo compens.")]
        public string Fundo_comp_senha { get; set; }

        [Display(Name = "Login B. de Portugal")]
        public string Banco_de_Portugal_login { get; set; }
        [Display(Name = "Senha B. de Portugal")]
        public string Banco_de_Portugal_senha { get; set; }

        [Display(Name = "Login Siifse")]
        public string Siifse_login { get; set; }
        [Display(Name = "Senha Siifse")]
        public string Siifse { get; set; }

        [Display(Name = "SAGE CNT utilizador")]
        public string SAGE_CNT_utilizador { get; set; }
        [Display(Name = "SAGE CNT senha")]
        public string SAGE_CNT_senha { get; set; }

        [Display(Name = "SAGE FAC utilizador")]
        public string SAGE_FAC_utilizador { get; set; }
        [Display(Name = "SAGE FAC senha")]
        public string SAGE_FAC_senha { get; set; }

        [Display(Name = "Acesso remoto login")]
        public string acesso_remoto_login { get; set; }
        [Display(Name = "Acesso remoto senha")]
        public string acesso_remoto_senha { get; set; }
        [Display(Name = "Acesso remoto descrição")]
        public string acesso_remoto_descricao { get; set; }

        [Display(Name = "Relatório único utilizador")]
        public string rel_unico_utilizador { get; set; }
        [Display(Name = "Relatório único senha")]
        public string rel_unico_senha { get; set; }

        [Display(Name = "Portugal 2020 utilizador")]
        public string portugal_2020_utilizador { get; set; }
        [Display(Name = "Portugal 2020 senha")]
        public string portugal_2020_senha { get; set; }

        // 40:
        [Display(Name = "Diversos 1")]
        public string diversos1 { get; set; }
        [Display(Name = "Diversos 2")]
        public string diversos2 { get; set; }
        [Display(Name = "Diversos 3")]
        public string Diversos3 { get; set; }

        //43:
        [Display(Name = "N.º de contrato")]
        // [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string NumContrato { get; set; }
        //44:
        [Column("DATA1R")]
        [Display(Name = "Data 1º registo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dataY { get; set; }

        public virtual ICollection <clm_clireu> texto {get;set;}
}
}