using ASIapiREST.Models.DTO;
using ASIapiREST.Models.EntityFramework;
using ASIapiREST.Models.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASIapiREST.Models.DataManager
{
    public class UtilisateurDetailManager : IDataRepository<UtilisateurDetailDTO>
    {
        readonly IMapper _mapper;

        readonly SerieDBContext? serieDBContext;
        public UtilisateurDetailManager() { }
        public UtilisateurDetailManager(SerieDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            serieDBContext = context;
        }

        Task<ActionResult<IEnumerable<UtilisateurDetailDTO>>> IDataRepository<UtilisateurDetailDTO>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        async Task<ActionResult<UtilisateurDetailDTO>> IDataRepository<UtilisateurDetailDTO>.GetByIdAsync(int id)
        {
            var listUtilisateurs = serieDBContext.Utilisateurs.Where(u => u.UtilisateurId == id).Select(
                u => _mapper.Map<UtilisateurDetailDTO>(u));
            return await listUtilisateurs.FirstOrDefaultAsync();
        }

        async Task<ActionResult<UtilisateurDetailDTO>> IDataRepository<UtilisateurDetailDTO>.GetByStringAsync(string str)
        {
            var listUtilisateurs = serieDBContext.Utilisateurs.Where(u => u.Mail == str).Select(
                u => _mapper.Map<UtilisateurDetailDTO>(u));
            return await listUtilisateurs.FirstOrDefaultAsync();
        }

        async Task IDataRepository<UtilisateurDetailDTO>.AddAsync(UtilisateurDetailDTO entityDto)
        {
            var entity = _mapper.Map<Utilisateur>(entityDto);
            await serieDBContext.Utilisateurs.AddAsync(entity);
            await serieDBContext.SaveChangesAsync();
            entityDto.UtilisateurId = entity.UtilisateurId;
        }

        async Task IDataRepository<UtilisateurDetailDTO>.UpdateAsync(UtilisateurDetailDTO entityToUpdateDto, UtilisateurDetailDTO entityDto)
        {
            var utilisateur = _mapper.Map<Utilisateur>(entityToUpdateDto);
            var entity = _mapper.Map<Utilisateur>(entityDto);
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

        async Task IDataRepository<UtilisateurDetailDTO>.DeleteAsync(UtilisateurDetailDTO entityDto)
        {
            var utilisateur = _mapper.Map<Utilisateur>(entityDto);
            serieDBContext.Utilisateurs.Remove(utilisateur);
            await serieDBContext.SaveChangesAsync();
        }
    }
}
