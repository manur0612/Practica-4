using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeruFail.Models
{
    public class Comentario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor tu comentario")]
        [Display(Name="Comentario")]
        public string Titulo { get; set; }

    }
}