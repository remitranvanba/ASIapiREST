using ASIapiREST.Models.DTO;
using ASIapiREST.Models.EntityFramework;
using ASIapiREST.Models.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASIapiREST.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<UtilisateurDTO>
    {
        readonly IMapper _mapper;

        readonly SerieDBContext? serieDBContext;
        public UtilisateurManager() { }
        public UtilisateurManager(SerieDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            serieDBContext = context;
        }
        public async Task<ActionResult<IEnumerable<UtilisateurDTO>>> GetAllAsync()
        {
            var listUtilisateurs = serieDBContext.Utilisateurs.Select(
                u => new UtilisateurDTO()
                {
                    Id = u.UtilisateurId,
                    Nom = u.Nom,
                    Prenom = u.Prenom,
                    NoteMoyenne = u.NotesUtilisateur.Count == 0 ? 0 : u.NotesUtilisateur.Average(n => n.Note)
                });

            return await listUtilisateurs.ToListAsync();
        }

        public async Task<ActionResult<UtilisateurDTO>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<ActionResult<UtilisateurDTO>> GetByStringAsync(string mail)
        {
            throw new NotImplementedException();
        }
        public async Task AddAsync(UtilisateurDTO entityDto)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateAsync(UtilisateurDTO utilisateurDto, UtilisateurDTO entityDto)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(UtilisateurDTO utilisateurDto)
        {
            var utilisateur = _mapper.Map<Utilisateur>(utilisateurDto);
            serieDBContext.Utilisateurs.Remove(utilisateur);
            await serieDBContext.SaveChangesAsync();
        }
    }
}
