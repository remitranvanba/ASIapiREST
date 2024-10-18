﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASIapiREST.Models.EntityFramework;
using System.Net;

namespace ASIapiREST.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        private readonly SerieDBContext _context;

        public UtilisateursController(SerieDBContext context)
        {
            _context = context;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        [ActionName("GetUtilisateurs")]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        [ActionName("GetUtilisateurById")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurById(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{email}")]
        [ActionName("GetUtilisateurByEmail")]
        public async Task<ActionResult<Utilisateur>> GetUtilisateurByEmail(string email)
        {
            var utilisateur = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // PUT: api/Utilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ActionName("PutUtilisateur")]
        public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.UtilisateurId)
            {
                return BadRequest();
            }

            _context.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Utilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ActionName("PostUtilisateur")]
        public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
        {
            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.UtilisateurId }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUtilisateur(int id)
        //{
        //    var utilisateur = await _context.Utilisateurs.FindAsync(id);
        //    if (utilisateur == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Utilisateurs.Remove(utilisateur);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateurs.Any(e => e.UtilisateurId == id);
        }
    }

    [Route("api/[controller]/[action]")]
    public class ServicesController : ControllerBase
    {
        private readonly SerieDBContext _context;

        public ServicesController(SerieDBContext context)
        {
            _context = context;
        }

        


    }
}

