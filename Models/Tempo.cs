using System.ComponentModel.DataAnnotations;

namespace PKX.Models
{
    public class Tempo
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Data de registo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public string? Descritivo {  get; set; }
        
        [Required]
        [Display(Name = "Minutos")]
        [Range(0, double.MaxValue, ErrorMessage = "O tempo nao pode ser negativo")]
        public int Minutos { get; set; }
        [Required]
        public int AtividadeId {  get; set; }

        [Required]
        public int FuncionarioId { get; set; }
        
        [Required]
        public int ClienteId { get; set; }
        
    }
}
