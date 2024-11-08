namespace SeriesApp.Models;

public partial class Notation
{
    public int UtilisateurId { get; set; }

    public int SerieId { get; set; }

    public int Note { get; set; }

    public virtual Utilisateur UtilisateurNotant { get; set; } = null!;

    public virtual Serie SerieNotee { get; set; } = null!;
}
