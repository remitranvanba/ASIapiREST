using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ASIapiREST.Models.EntityFramework
{
    [PrimaryKey("UtilisateurId", "SerieId")]
    [Table("t_j_notation_not")]
    public partial class Notation
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [Column("ser_id")]
        public int SerieId { get; set; }

        [Column("not_note")]
        [Range(0, 5)]
        public int Note { get; set; }

        [ForeignKey("UtilisateurId")]
        [InverseProperty("NotesUtilisateur")]
        public virtual Utilisateur UtilisateurNotant { get; set; } = null!;

        [ForeignKey("SerieId")]
        [InverseProperty("NotesSerie")]
        public virtual Serie SerieNotee { get; set; } = null!;
    }
}
