using ASIapiREST.Models.EntityFramework;
using ASIapiREST.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASIapiREST.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        readonly SerieDBContext? serieDBContext;
        public UtilisateurManager() { }
        public UtilisateurManager(SerieDBContext context)
        {
            serieDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllAsync()
        {
            return await serieDBContext.Utilisateurs.ToListAsync();
        }

        public async Task<ActionResult<Utilisateur>> GetByIdAsync(int id)
        {
            return await serieDBContext.Utilisateurs.FirstOrDefaultAsync(u => u.UtilisateurId == id);
        }
        public async Task<ActionResult<Utilisateur>> GetByStringAsync(string mail)
        {
            return await serieDBContext.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToUpper() == mail.ToUpper());
        }
        public async Task AddAsync(Utilisateur entity)
        {
            await serieDBContext.Utilisateurs.AddAsync(entity);
            await serieDBContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Utilisateur utilisateur, Utilisateur entity)
        {
            serieDBContext.Entry(utilisateur).State = EntityState.Modified;
            utilisateur.UtilisateurId = entity.UtilisateurId;
            utilisateur.Nom = entity.Nom;
            utilisateur.Prenom = entity.Prenom;
            utilisateur.Mail = entity.Mail;
            utilisateur.Rue = entity.Rue;
            utilisateur.CodePostal = entity.CodePostal;
            utilisateur.Ville = entity.Ville;
            utilisateur.Pays = entity.Pays;
            utilisateur.Latitude = entity.Latitude;
            utilisateur.Longitude = entity.Longitude;
            utilisateur.Pwd = entity.Pwd;
            utilisateur.Mobile = entity.Mobile;
            utilisateur.NotesUtilisateur = entity.NotesUtilisateur;
            await serieDBContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Utilisateur utilisateur)
        {
            serieDBContext.Utilisateurs.Remove(utilisateur);
            await serieDBContext.SaveChangesAsync();
        }
    }
}
