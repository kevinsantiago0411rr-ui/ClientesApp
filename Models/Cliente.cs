using System;
using System.ComponentModel.DataAnnotations;

namespace ClientesApp.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50)]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50)]
        public required string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(150)]
        public string? Direccion { get; set; }

        [StringLength(50)]
        public string? Ciudad { get; set; }

        [StringLength(50)]
        public string? Pais { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        // Nuevos campos:
        [StringLength(50)]
        public string? NombreMascota { get; set; }

        [StringLength(20)]
        public string? Genero { get; set; }
    }
}