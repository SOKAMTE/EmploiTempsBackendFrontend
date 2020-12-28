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
    public class NiveauController: ControllerBase
    {
        private readonly INiveauRepository niveauRepository;

        public NiveauController(INiveauRepository niveauRepository)
        {
            this.niveauRepository = niveauRepository;
        }

        // GET: api/Niveau, Niveau
        /// <summary>
        /// Retourne la liste des Niveau
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>  
        /// <response code="200">Niveau selectionné</response>
        /// <response code="404">Niveau introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet]
        [ProducesResponseType(typeof(Niveau), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetNiveau()
        {
            try
            {
                return Ok(await niveauRepository.GetNiveaus()); 
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Niveau/Details/5, api/Niveau/5
        /// <summary>
        /// Retourne une Niveau specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Niveau a retourné</param>   
        /// <response code="200">Niveau selectionné</response>
        /// <response code="404">Niveau introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Niveau), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Niveau>> GetNiveau(int id)
        {
            try
            {
                var result = await niveauRepository.GetNiveau(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Niveau, Niveau
        /// <summary>
        /// Créer une Niveau à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="niveau">objet Semestre de la classe User du Unite à créer</param>  
        /// <response code="200">Niveau selectionné</response>
        /// <response code="404">Niveau introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost]
        [ProducesResponseType(typeof(Niveau), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Niveau>> CreateNiveau(Niveau niveau)
        {
            try
            {
                if (niveau == null) {
                    return BadRequest();
                }

                // Add custom model validation error
                /*var adm = niveauRepository.GetNiveauByMail(niveau.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Niveau email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdNiveau = await niveauRepository.AddNiveau(niveau);

                return CreatedAtAction(nameof(GetNiveau),
                    new { id = createdNiveau.idNiveau }, createdNiveau);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Niveau record");
            }
        }

        // PUT: api/Niveau/5
        /// <summary>
        /// modifie un Niveau specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Niveau à modifier</param>   
        /// <param name="niveau">classe d'entité du Niveau à modifier</param>
        /// <response code="200">Niveau selectionné</response>
        /// <response code="404">Niveau introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Niveau), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Niveau>> UpdatNiveau(int id, Niveau niveau)
        {
            try
            {
                if (id != niveau.idNiveau)
                    return BadRequest("Niveau ID mismatch");

                var niveauToUpdate = await niveauRepository.GetNiveau(id);

                if (niveauToUpdate == null)
                    return NotFound($"Niveau with Id = {id} not found");

                return await niveauRepository.UpdateNiveau(niveau);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Niveau/5
        /// <summary>
        /// supprime une Niveau specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Niveau à supprimer</param>   
        /// <response code="200">Niveau selectionné</response>
        /// <response code="404">Niveau introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Niveau), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Niveau>> DeleteNiveau(int id)
        {
            try
            {
                var niveauToDelete = await niveauRepository.GetNiveau(id);

                if (niveauToDelete == null)
                {
                    return NotFound($"Niveau with Id = {id} not found");
                }

                return await niveauRepository.DeleteNiveau(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Niveau/value/5
        /// <summary>
        /// recherche une Niveau specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'Niveau à rechercher</param>   
        /// <response code="200">Niveau recherché</response>
        /// <response code="404">Niveau introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Niveau), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Niveau>>> Search(string name)
        {
            try
            {
                var result = await niveauRepository.SearchNiveau(name);

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