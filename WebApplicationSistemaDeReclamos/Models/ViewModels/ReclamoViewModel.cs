using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationSistemaDeReclamos.Models.ViewModels
{
    public class ReclamoViewModel
    {
        private long id;
        private string titulo;
        private string descripcion;
        private string estado;
        private DateTime fechaAlta;

        [DisplayName("id auto generado")]
        public long Id { get => id; set => id = value; }

        [DisplayName("Titulo del producto")]
        [Required]
        public string Titulo { get => titulo; set => titulo = value; }

        [DisplayName("Descripción")]
        [Required]
        [StringLength(100)]
        public string Descripcion { get => descripcion; set => descripcion = value; }

        [DisplayName("Estado")]
        public string Estado { get => estado; set => estado = value; }

        [DisplayName("Fecha Alta")]
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta=value; }
    }
}
