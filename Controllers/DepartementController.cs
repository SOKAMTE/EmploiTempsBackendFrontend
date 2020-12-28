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
    public class DepartementController: ControllerBase
    {
        private readonly IDepartementRepository departementRepository;

        public DepartementController(IDepartementRepository departementRepository)
        {
            this.departementRepository = departementRepository;
        }

        // GET: api/Departement, Departement
        /// <summary>
        /// Retourne la liste des Departement
        /// </summary>
        /// <remarks>Services qui permet d'afficher tous les départements</remarks>  
        /// <response code="200">Departement selectionné</response>
        /// <response code="404">Departement introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(Departement), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> GetDepartement()
        {
            try
            {
                return Ok(await departementRepository.GetDepartements());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Departement/Details/5, api/Departement/5
        /// <summary>
        /// Retourne une Departement specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Departement a retourné</param>   
        /// <response code="200">Departement selectionné</response>
        /// <response code="404">Departement introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Departement), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Departement>> GetDepartement(int id)
        {
            try
            {
                var result = await departementRepository.GetDepartement(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Departement, Departement
        /// <summary>
        /// Créer une Departement à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="departement">objet Departement de la classe Departement du Unite à créer</param>  
        /// <response code="200">Departement selectionné</response>
        /// <response code="404">Departement introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost("post")]
        [ProducesResponseType(typeof(Departement), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Departement>> CreateDepartement(Departement departement)
        {
            try
            {
                if (departement == null) { 
                    return BadRequest();
                }

                // Add custom model validation error
                /*var adm = departementRepository.GetDepartementByMail(Departement.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Departement email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdDepartement = await departementRepository.AddDepartement(departement);

                return CreatedAtAction(nameof(GetDepartement),
                    new { id = createdDepartement.idDepartement }, createdDepartement);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new departement record");
            }
        }

        // PUT: api/Departement/5
        /// <summary>
        /// modifie un Departement specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Departement à modifier</param>   
        /// <param name="departement">classe d'entité du Departement à modifier</param>
        /// <response code="200">Departement selectionné</response>
        /// <response code="404">Departement introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Departement), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Departement>> UpdateDepartement(int id, Departement departement)
        {
            try
            {
                if (id != departement.idDepartement)
                    return BadRequest("Departement ID mismatch");

                var departementToUpdate = await departementRepository.GetDepartement(id);

                if (departementToUpdate == null)
                    return NotFound($"Departement with Id = {id} not found");

                return await departementRepository.UpdateDepartement(departement);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Departement/5
        /// <summary>
        /// supprime une Departement specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Departement à supprimer</param>   
        /// <response code="200">Departement selectionné</response>
        /// <response code="404">Departement introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Departement), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Departement>> DeleteDepartement(int id)
        {
            try
            {
                var departementToDelete = await departementRepository.GetDepartement(id);

                if (departementToDelete == null)
                {
                    return NotFound($"Departement with Id = {id} not found");
                }

                return await departementRepository.DeleteDepartement(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Departement/value/5
        /// <summary>
        /// recherche une Departement specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'Departement à rechercher</param>   
        /// <response code="200">Departement recherché</response>
        /// <response code="404">Departement introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Departement), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Departement>>> Search(string name)
        {
            try
            {
                var result = await departementRepository.SearchDepartement(name);

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