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
    public class SalleController: ControllerBase
    {
        private readonly ISalleRepository salleRepository;

        public SalleController(ISalleRepository salleRepository)
        {
            this.salleRepository = salleRepository;
        }

        // GET: api/Salle, Salle
        /// <summary>
        /// Retourne la liste des Salle
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>  
        /// <response code="200">Salle selectionné</response>
        /// <response code="404">Salle introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet]
        [ProducesResponseType(typeof(Salle), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetSalle()
        {
            try
            {
                return Ok(await salleRepository.GetSalles());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Salle/Details/5, api/Salle/5
        /// <summary>
        /// Retourne une Salle specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Salle a retourné</param>   
        /// <response code="200">Salle selectionné</response>
        /// <response code="404">Salle introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Salle), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Salle>> GetSalle(int id)
        {
            try
            {
                var result = await salleRepository.GetSalle(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Salle, Salle
        /// <summary>
        /// Créer une Salle à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="salle">objet Semestre de la classe User du Unite à créer</param>  
        /// <response code="200">Salle selectionné</response>
        /// <response code="404">Salle introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost]
        [ProducesResponseType(typeof(Salle), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Salle>> CreateSalle(Salle salle)
        {
            try
            {
                if (salle == null) {
                    return BadRequest();
                }

                // Add custom model validation error
                /*var adm = SalleRepository.GetSalleByMail(salle.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Salle email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdSalle = await salleRepository.AddSalle(salle);

                return CreatedAtAction(nameof(GetSalle),
                    new { id = createdSalle.idSalle }, createdSalle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Salle record");
            }
        }

        // PUT: api/Salle/5
        /// <summary>
        /// modifie un Salle specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Salle à modifier</param>   
        /// <param name="salle">classe d'entité du Salle à modifier</param>
        /// <response code="200">Salle selectionné</response>
        /// <response code="404">Salle introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Salle), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Salle>> UpdatSalle(int id, Salle salle)
        {
            try
            {
                if (id != salle.idSalle)
                    return BadRequest("Salle ID mismatch");

                var salleToUpdate = await salleRepository.GetSalle(id);

                if (salleToUpdate == null)
                    return NotFound($"Salle with Id = {id} not found");

                return await salleRepository.UpdateSalle(salle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Salle/5
        /// <summary>
        /// supprime une Salle specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Salle à supprimer</param>   
        /// <response code="200">Salle selectionné</response>
        /// <response code="404">Salle introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Salle), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Salle>> DeleteSalle(int id)
        {
            try
            {
                var salleToDelete = await salleRepository.GetSalle(id);

                if (salleToDelete == null)
                {
                    return NotFound($"Salle with Id = {id} not found");
                }

                return await salleRepository.DeleteSalle(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Salle/value/5
        /// <summary>
        /// recherche une Salle specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'Salle à rechercher</param>   
        /// <response code="200">Salle recherché</response>
        /// <response code="404">Salle introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Salle), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Salle>>> Search(string name)
        {
            try
            {
                var result = await salleRepository.SearchSalle(name);

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