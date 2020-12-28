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
    public class SemestreController: ControllerBase
    {
        private readonly ISemestreRepository semestreRepository;

        public SemestreController(ISemestreRepository semestreRepository)
        {
            this.semestreRepository = semestreRepository;
        }

        // GET: api/Semestre, Semestre
        /// <summary>
        /// Retourne la liste des Semestre
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>  
        /// <response code="200">Semestre selectionné</response>
        /// <response code="404">Semestre introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet]
        [ProducesResponseType(typeof(Semestre), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetSemestre()
        {
            try
            {
                return Ok(await semestreRepository.GetSemestres());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Semestre/Details/5, api/Semestre/5
        /// <summary>
        /// Retourne une Semestre specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Semestre a retourné</param>   
        /// <response code="200">Semestre selectionné</response>
        /// <response code="404">Semestre introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Semestre), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Semestre>> GetSemestre(int id)
        {
            try
            {
                var result = await semestreRepository.GetSemestre(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Semestre, Semestre
        /// <summary>
        /// Créer une Semestre à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="semestre">objet Semestre de la classe User du Unite à créer</param>  
        /// <response code="200">Semestre selectionné</response>
        /// <response code="404">Semestre introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost]
        [ProducesResponseType(typeof(Semestre), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Semestre>> CreateSemestre(Semestre semestre)
        {
            try
            {
                if (semestre == null) {
                    return BadRequest();
                }

                // Add custom model validation error
                /*var adm = semestreRepository.GetSemestreByMail(Semestre.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Semestre email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdSemestre = await semestreRepository.AddSemestre(semestre);

                return CreatedAtAction(nameof(GetSemestre),
                    new { id = createdSemestre.idSemestre }, createdSemestre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new semestre record");
            }
        }

        // PUT: api/Semestre/5
        /// <summary>
        /// modifie un Semestre specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Semestre à modifier</param>   
        /// <param name="semestre">classe d'entité du Semestre à modifier</param>
        /// <response code="200">Semestre selectionné</response>
        /// <response code="404">Semestre introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Semestre), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Semestre>> UpdatSemestre(int id, Semestre semestre)
        {
            try
            {
                if (id != semestre.idSemestre)
                    return BadRequest("Semestre ID mismatch");

                var semestreToUpdate = await semestreRepository.GetSemestre(id);

                if (semestreToUpdate == null)
                    return NotFound($"Semestre with Id = {id} not found");

                return await semestreRepository.UpdateSemestre(semestre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Semestre/5
        /// <summary>
        /// supprime une Semestre specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Semestre à supprimer</param>   
        /// <response code="200">Semestre selectionné</response>
        /// <response code="404">Semestre introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Semestre), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Semestre>> DeleteSemestre(int id)
        {
            try
            {
                var semestreToDelete = await semestreRepository.GetSemestre(id);

                if (semestreToDelete == null)
                {
                    return NotFound($"Semestre with Id = {id} not found");
                }

                return await semestreRepository.DeleteSemestre(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Semestre/value/5
        /// <summary>
        /// recherche une Semestre specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'Semestre à rechercher</param>   
        /// <response code="200">Semestre recherché</response>
        /// <response code="404">Semestre introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Semestre), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Semestre>>> Search(string name)
        {
            try
            {
                var result = await semestreRepository.SearchSemestre(name);

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