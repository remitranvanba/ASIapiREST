using ASIapiREST.Models.DataManager;
using ASIapiREST.Models.EntityFramework;

namespace ASIapiREST.Models.DTO
{
    public class UtilisateurDetailDTO
    {
        public int UtilisateurId { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Mobile { get; set; }
        public string? Mail { get; set; }
        public string? Pwd { get; set; }
        public string? CodePostal { get; set; }
        public string? Ville { get; set; }
        public string? Pays { get; set; }
    }
}
