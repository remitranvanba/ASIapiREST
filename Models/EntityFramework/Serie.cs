using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ASIapiREST.Models.EntityFramework
{
    [Table("t_e_serie_ser")]
    public partial class Serie
    {
        [Key]
        [Column("ser_id")]
        public int SerieId { get; set; }

        [Column("ser_titre")]
        [StringLength(50)]
        public string Titre { get; set; } = null!;

        [Column("ser_resume")]
        public string? Resume { get; set; }

        [Column("ser_nbsaisons")]
        public int? NbSaisons { get; set; }

        [Column("ser_nbepisodes")]
        public int? NbEpisodes { get; set; }

        [Column("ser_anneecreation")]
        public int? AnneeCreation { get; set; }

        [Column("ser_network")]
        [StringLength(50)]
        public string? Network { get; set; }

        [InverseProperty("SerieNotee")]
        public virtual ICollection<Notation> NotesSerie { get; set; } = new List<Notation>();
    }
}
