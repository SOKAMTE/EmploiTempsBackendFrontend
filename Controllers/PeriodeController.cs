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
    public class PeriodeController: ControllerBase
    {
        private readonly IPeriodeRepository periodeRepository;

        public PeriodeController(IPeriodeRepository periodeRepository)
        {
            this.periodeRepository = periodeRepository;
        }

        // GET: api/Periode, Periode
        /// <summary>
        /// Retourne la liste des Periode
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>  
        /// <response code="200">Periode selectionné</response>
        /// <response code="404">Periode introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet]
        [ProducesResponseType(typeof(Periode), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetPeriode()
        {
            try
            {
                return Ok(await periodeRepository.GetPeriodes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Periode/Details/5, api/Periode/5
        /// <summary>
        /// Retourne une Periode specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Periode a retourné</param>   
        /// <response code="200">Periode selectionné</response>
        /// <response code="404">Periode introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Periode), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Periode>> GetPeriode(int id)
        {
            try
            {
                var result = await periodeRepository.GetPeriode(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Periode, Periode
        /// <summary>
        /// Créer une Periode à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="periode">objet Semestre de la classe User du Unite à créer</param>  
        /// <response code="200">Periode selectionné</response>
        /// <response code="404">Periode introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost]
        [ProducesResponseType(typeof(Periode), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Periode>> CreatePeriode(Periode periode)
        {
            try
            {
                if (periode == null) {
                    return BadRequest();
                }

                // Add custom model validation error
                /*var adm = periodeRepository.GetPeriodeByMail(Periode.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Periode email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdPeriode = await periodeRepository.AddPeriode(periode);

                return CreatedAtAction(nameof(GetPeriode),
                    new { id = createdPeriode.idPeriode }, createdPeriode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new periode record");
            }
        }

        // PUT: api/Periode/5
        /// <summary>
        /// modifie un Periode specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Periode à modifier</param>   
        /// <param name="periode">classe d'entité du Periode à modifier</param>
        /// <response code="200">Periode selectionné</response>
        /// <response code="404">Periode introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Periode), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Periode>> UpdatPeriode(int id, Periode periode)
        {
            try
            {
                if (id != periode.idPeriode)
                    return BadRequest("Periode ID mismatch");

                var periodeToUpdate = await periodeRepository.GetPeriode(id);

                if (periodeToUpdate == null)
                    return NotFound($"Periode with Id = {id} not found");

                return await periodeRepository.UpdatePeriode(periode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Periode/5
        /// <summary>
        /// supprime une Periode specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Periode à supprimer</param>   
        /// <response code="200">Periode selectionné</response>
        /// <response code="404">Periode introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Periode), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Periode>> DeletePeriode(int id)
        {
            try
            {
                var periodeToDelete = await periodeRepository.GetPeriode(id);

                if (periodeToDelete == null)
                {
                    return NotFound($"Periode with Id = {id} not found");
                }

                return await periodeRepository.DeletePeriode(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Periode/value/5
        /// <summary>
        /// recherche une Periode specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'Periode à rechercher</param>   
        /// <response code="200">Periode recherché</response>
        /// <response code="404">Periode introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Periode), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Periode>>> Search(string name)
        {
            try
            {
                var result = await periodeRepository.SearchPeriode(name);

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