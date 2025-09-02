using System.ComponentModel.DataAnnotations;

namespace LojaSystem.Models
{
    public class Perfil
    {
        // Navigation Property - One-to-One
        public Cliente Cliente { get; set; }
       #region properties

        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public DateTime? DataUltimaVisita { get; set; }
        
        // Foreign Key para relacionamento 1:1 com Cliente
        public int ClienteId { get; set; }

        #endregion
    }
}