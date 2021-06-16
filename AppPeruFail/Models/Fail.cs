using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPeruFail.Models
{
    public class Fail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }
        public String UserID { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese el título")]
        [Display(Name="Titulo de la publicación")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor ingresa la foto")]
        [Display(Name="Foto de la publicación")]
        public string Foto { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
    }
}