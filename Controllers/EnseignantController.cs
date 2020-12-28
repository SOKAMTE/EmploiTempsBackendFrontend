using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using emploiTemps.Repository;
using Microsoft.AspNetCore.Http;
using emploiTemps.Models;
using System.Collections.Generic;
using System.Linq;

namespace  emploiTemps.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnseignantController: ControllerBase
    {
        private readonly IEnseignantRepository enseignantRepository;

        public EnseignantController(IEnseignantRepository enseignantRepository)
        {
            this.enseignantRepository = enseignantRepository;
        }

        // GET: api/Enseignant, Enseignant
        /// <summary>
        /// Retourne la liste des Enseignant
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>  
        /// <response code="200">Enseignant selectionné</response>
        /// <response code="404">Enseignant introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet]
        [ProducesResponseType(typeof(Enseignant), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetEnseignant()
        {
            try
            {
                return Ok(await enseignantRepository.GetEnseignants());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Enseignant/Details/5, api/Enseignant/5
        /// <summary>
        /// Retourne une Enseignant specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Enseignant a retourné</param>   
        /// <response code="200">Enseignant selectionné</response>
        /// <response code="404">Enseignant introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Enseignant), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Enseignant>> GetEnseignant(int id)
        {
            try
            {
                var result = await enseignantRepository.GetEnseignant(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Enseignant, Enseignant
        /// <summary>
        /// Créer une Enseignant à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="enseignant">objet Enseignant de la classe User du Unite à créer</param>  
        /// <response code="200">Enseignant selectionné</response>
        /// <response code="404">Enseignant introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost]
        [ProducesResponseType(typeof(Enseignant), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Enseignant>> CreateEnseignant(Enseignant enseignant)
        {
            try
            {
                if (enseignant == null) {
                    return BadRequest();
                }

                // Add custom model validation error
                var adm = enseignantRepository.GetEnseignantByMail(enseignant.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Enseignant email already in use");
                    return BadRequest(ModelState);
                }

                var createdEnseignant = await enseignantRepository.AddEnseignant(enseignant);

                return CreatedAtAction(nameof(GetEnseignant),
                    new { id = createdEnseignant.idEnseignant }, createdEnseignant);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new enseignant record");
            }
        }

        // PUT: api/Enseignant/5
        /// <summary>
        /// modifie un Enseignant specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Enseignant à modifier</param>   
        /// <param name="enseignant">classe d'entité du Enseignant à modifier</param>
        /// <response code="200">Enseignant selectionné</response>
        /// <response code="404">Enseignant introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Enseignant), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Enseignant>> UpdatEnseignant(int id, Enseignant enseignant)
        {
            try
            {
                if (id != enseignant.idEnseignant)
                    return BadRequest("Enseignant ID mismatch");

                var enseignantToUpdate = await enseignantRepository.GetEnseignant(id);

                if (enseignantToUpdate == null)
                    return NotFound($"Enseignant with Id = {id} not found");

                return await enseignantRepository.UpdateEnseignant(enseignant);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Enseignant/5
        /// <summary>
        /// supprime une Enseignant specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Enseignant à supprimer</param>   
        /// <response code="200">Enseignant selectionné</response>
        /// <response code="404">Enseignant introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Enseignant), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Enseignant>> DeleteEnseignant(int id)
        {
            try
            {
                var enseignantToDelete = await enseignantRepository.GetEnseignant(id);

                if (enseignantToDelete == null)
                {
                    return NotFound($"Enseignant with Id = {id} not found");
                }

                return await enseignantRepository.DeleteEnseignant(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Enseignant/value/5
        /// <summary>
        /// recherche une Enseignant specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'Enseignant à rechercher</param>   
        /// <response code="200">Enseignant recherché</response>
        /// <response code="404">Enseignant introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Enseignant), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Enseignant>>> Search(string name)
        {
            try
            {
                var result = await enseignantRepository.SearchEnseignant(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}