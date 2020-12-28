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
    public class UniteController: ControllerBase
    {
        private readonly IUniteRepository uniteRepository;

        public UniteController(IUniteRepository uniteRepository)
        {
            this.uniteRepository = uniteRepository;
        }

        // GET: api/Unite, Unite
        /// <summary>
        /// Retourne la liste des Unites
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>  
        /// <response code="200">Unite selectionné</response>
        /// <response code="404">Unite introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet]
        [ProducesResponseType(typeof(Unite), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetUnite()
        {
            try
            {
                return Ok(await uniteRepository.GetUnites());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Unite/Details/5, api/Unite/5
        /// <summary>
        /// Retourne une Unite specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Unite a retourné</param>   
        /// <response code="200">Unite selectionné</response>
        /// <response code="404">Unite introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Unite), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Unite>> GetUnite(int id)
        {
            try
            {
                var result = await uniteRepository.GetUnite(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Unite, Unite
        /// <summary>
        /// Créer une unite à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="unite">objet unite de la classe unite du Unite à créer</param>  
        /// <response code="200">unite selectionné</response>
        /// <response code="404">unite introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost]
        [ProducesResponseType(typeof(Unite), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Unite>> CreateUnite(Unite unite)
        {
            try
            {
                if (unite == null) {
                    return BadRequest();
                }

                // Add custom model validation error
                /*var adm = uniteRepository.GetUniteByMail(unite.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Unite email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdUnite = await uniteRepository.AddUnite(unite);

                return CreatedAtAction(nameof(GetUnite),
                    new { id = createdUnite.idUnite }, createdUnite);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new unite record");
            }
        }

        // PUT: api/Unite/5
        /// <summary>
        /// modifie un unite specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du unite à modifier</param>   
        /// <param name="unite">classe d'entité du unite à modifier</param>
        /// <response code="200">unite selectionné</response>
        /// <response code="404">unite introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Unite), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Unite>> UpdateUnite(int id, Unite unite)
        {
            try
            {
                if (id != unite.idUnite)
                    return BadRequest("Unite ID mismatch");

                var uniteToUpdate = await uniteRepository.GetUnite(id);

                if (uniteToUpdate == null)
                    return NotFound($"Unite with Id = {id} not found");

                return await uniteRepository.UpdateUnite(unite);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Unite/5
        /// <summary>
        /// supprime une unite specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du unite à supprimer</param>   
        /// <response code="200">unite selectionné</response>
        /// <response code="404">unite introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Unite), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Unite>> DeleteUnite(int id)
        {
            try
            {
                var uniteToDelete = await uniteRepository.GetUnite(id);

                if (uniteToDelete == null)
                {
                    return NotFound($"Unite with Id = {id} not found");
                }

                return await uniteRepository.DeleteUnite(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Unite/value/5
        /// <summary>
        /// recherche une unite specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'unite à rechercher</param>   
        /// <response code="200">unite recherché</response>
        /// <response code="404">unite introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Unite), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Unite>>> Search(string name)
        {
            try
            {
                var result = await uniteRepository.SearchUnite(name);

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