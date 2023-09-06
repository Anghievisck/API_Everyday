using System.ComponentModel.DataAnnotations.Schema;

namespace EverydayAPI.Models {
    public class Jornal{
        public Guid jornalId { get; set; }
        [ForeignKey("autorId")]
        public Guid autorId { get; set; }
        public string link { get; set; }
        public string descricao { get; set; }
        public string sinopse { get; set; }
        public string titulo { get; set; }
        public string assunto { get; set; }
    }
}
