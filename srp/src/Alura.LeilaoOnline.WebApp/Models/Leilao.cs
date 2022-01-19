using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class Leilao
    {        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "T�tulo � obrigat�rio")] 
        [Display(Name = "T�tulo", Prompt = "Digite o t�tulo do leil�o")]
        public string Titulo { get; set; }

        [Display(Name = "Descri��o")]
        public string Descricao { get; set; }

        [Display(Name = "In�cio do Preg�o")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inv�lida")]
        public DateTime? Inicio { get; set; }

        [Display(Name = "T�rmino do Preg�o")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inv�lida")]
        public DateTime? Termino { get; set; }

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public SituacaoLeilao Situacao { get; set; }
        public string PosterUrl => $"/images/poster-{Id}.jpg";
    }
}