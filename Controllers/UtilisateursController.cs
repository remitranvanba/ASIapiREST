using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASIapiREST.Models.EntityFramework;
using System.Net;
using Microsoft.AspNetCore.JsonPatch;
using ASIapiREST.Models.DataManager;
using ASIapiREST.Models.Repository;
using AutoMapper;
using ASIapiREST.Models.DTO;

namespace ASIapiREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IDataRepository<UtilisateurDTO> userRepository;
        private readonly IDataRepository<UtilisateurDetailDTO> userDetailRepository;

        //private readonly SerieDBContext _context;

        public UtilisateursController(IDataRepository<UtilisateurDTO> userRepo, IDataRepository<UtilisateurDetailDTO> userDetailRepo)
        {
            userRepository = userRepo;
            userDetailRepository = userDetailRepo;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        [ProducesResponseType<UtilisateurDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType<UtilisateurDTO>(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<UtilisateurDTO>>> GetUtilisateurs()
        {
            var listUtilisateurs = await userRepository.GetAllAsync();

            if (listUtilisateurs.Value == null)
            {
                return NoContent();
            }

            return listUtilisateurs;

        }

        // GET: api/GetUtilisateurById/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType<UtilisateurDetailDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UtilisateurDetailDTO>> GetUtilisateurById(int id)
        {
            var utilisateurDto = await userDetailRepository.GetByIdAsync(id);
            //var utilisateur = _context.Utilisateurs.FindAsync(id);

            if (utilisateurDto == null)
            {
                return NotFound();
            }

            return utilisateurDto;
        }

        // GET: api/GetUtilisateurByEmail/5
        [HttpGet]
        [Route("[action]/{email}")]
        [ProducesResponseType<UtilisateurDetailDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UtilisateurDetailDTO>> GetUtilisateurByEmail(string email)
        {
            var utilisateurDto = await userDetailRepository.GetByStringAsync(email);
            //var utilisateur = _context.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToLower() == email.ToLower());

            if (utilisateurDto == null)
            {
                return NotFound();
            }

            return utilisateurDto;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUtilisateur(int id, UtilisateurDetailDTO utilisateurDetailDTO)
        {
            if (id != utilisateurDetailDTO.UtilisateurId)
            {
                return BadRequest();
            }

            var userToUpdate = await userDetailRepository.GetByIdAsync(id);
            if (userToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                await userDetailRepository.UpdateAsync(userToUpdate.Value, utilisateurDetailDTO);
                return NoContent();
            }
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType<UtilisateurDTO>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UtilisateurDetailDTO>> PostUtilisateur(UtilisateurDetailDTO utilisateurDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await userDetailRepository.AddAsync(utilisateurDetailDTO);

            return CreatedAtAction("GetUtilisateurById", new { id = utilisateurDetailDTO.UtilisateurId }, utilisateurDetailDTO);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await userDetailRepository.GetByIdAsync(id);
            if (utilisateur.Value == null)
            {
                return NotFound();
            }

            await userDetailRepository.DeleteAsync(utilisateur.Value);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType<UtilisateurDetailDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PatchUtilisateur(int id, [FromBody] JsonPatchDocument<UtilisateurDetailDTO> patchEntity)
        {
            var entity = await userDetailRepository.GetByIdAsync(id);

            if (entity.Value == null)
            {
                return NotFound();
            }

            patchEntity.ApplyTo(entity.Value, ModelState); // Must have Microsoft.AspNetCore.Mvc.NewtonsoftJson installed

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            //dataRepository.Update(entity);
            return Ok(entity);
        }

        //private bool UtilisateurExists(int id)
        //{
        //    return _context.Utilisateurs.Any(e => e.UtilisateurId == id);
        //}
    }
}

