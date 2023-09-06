using System.ComponentModel.DataAnnotations.Schema;

namespace EverydayAPI.Models{
    public class UpdateUserRequest{
        public string userEmail { get; set; }
        public string password { get; set; }
        [ForeignKey("jornalId")]
        public Guid jornalFavorito { get; set; }
    }
}
