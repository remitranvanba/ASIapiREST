using ASIapiREST.Models.DTO;
using ASIapiREST.Models.EntityFramework;
using AutoMapper;

namespace ASIapiREST.Models.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<UtilisateurDTO, Utilisateur>().ReverseMap();
            CreateMap<UtilisateurDetailDTO, Utilisateur>().ReverseMap();
        }
        
    }
}
