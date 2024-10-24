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

namespace ASIapiREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly IDataRepository<Utilisateur> dataRepository;
        //private readonly SerieDBContext _context;

        public UtilisateursController(IDataRepository<Utilisateur> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        [ProducesResponseType<Utilisateur>(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/GetUtilisateurById/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType<Utilisateur>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurById(int id)
        {
            var utilisateur = await dataRepository.GetByIdAsync(id);
            //var utilisateur = _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // GET: api/GetUtilisateurByEmail/5
        [HttpGet]
        [Route("[action]/{email}")]
        [ProducesResponseType<Utilisateur>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurByEmail(string email)
        {
            var utilisateur = await dataRepository.GetByStringAsync(email);
            //var utilisateur = _context.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToLower() == email.ToLower());

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }

            var userToUpdate = await dataRepository.GetByIdAsync(id);
            if (userToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(userToUpdate.Value, utilisateur);
                return NoContent();
            }
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType<Utilisateur>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(utilisateur);

            return CreatedAtAction("GetUtilisateurById", new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur(int id)
        {
            var utilisateur = await dataRepository.GetByIdAsync(id);
            if (utilisateur.Value == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(utilisateur.Value);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType<Utilisateur>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PatchUtilisateur(int id, [FromBody] JsonPatchDocument<Utilisateur> patchEntity)
        {
            var entity = await dataRepository.GetByIdAsync(id);

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

