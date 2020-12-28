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
    public class OptionController: ControllerBase
    {
        private readonly IOptionRepository optionRepository;

        public OptionController(IOptionRepository optionRepository)
        {
            this.optionRepository = optionRepository;
        }

        // GET: api/Option, Option
        /// <summary>
        /// Retourne la liste des Option
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>  
        /// <response code="200">Option selectionné</response>
        /// <response code="404">Option introuvable</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet]
        [ProducesResponseType(typeof(Option), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetOption()
        {
            try
            {
                return Ok(await optionRepository.GetOptions());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
					"Error retrieving data from the database");
            }
        }

        // GET: Option/Details/5, api/Option/5
        /// <summary>
        /// Retourne une Option specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Option a retourné</param>   
        /// <response code="200">Option selectionné</response>
        /// <response code="404">Option introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Option), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Option>> GetOption(int id)
        {
            try
            {
                var result = await optionRepository.GetOption(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // POST: api/Option, Option
        /// <summary>
        /// Créer une Option à partir de ses attributs
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="option">objet Semestre de la classe User du Unite à créer</param>  
        /// <response code="200">Option selectionné</response>
        /// <response code="404">Option introuvable pour l'attribut specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPost]
        [ProducesResponseType(typeof(Option), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Option>> CreateOption(Option option)
        {
            try
            {
                if (option == null) {
                    return BadRequest();
                }

                // Add custom model validation error
                /*var adm = optionRepository.GetOptionByMail(option.mail);

                if(adm != null)
                {
                    ModelState.AddModelError("email", "Option email already in use");
                    return BadRequest(ModelState);
                }*/

                var createdOption = await optionRepository.AddOption(option);

                return CreatedAtAction(nameof(GetOption),
                    new { id = createdOption.idOption }, createdOption);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Option record");
            }
        }

        // PUT: api/Option/5
        /// <summary>
        /// modifie un Option specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Option à modifier</param>   
        /// <param name="option">classe d'entité du Option à modifier</param>
        /// <response code="200">Option selectionné</response>
        /// <response code="404">Option introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Option), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Option>> UpdatOption(int id, Option option)
        {
            try
            {
                if (id != option.idOption)
                    return BadRequest("Option ID mismatch");

                var optionToUpdate = await optionRepository.GetOption(id);

                if (optionToUpdate == null)
                    return NotFound($"Option with Id = {id} not found");

                return await optionRepository.UpdateOption(option);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE: api/Option/5
        /// <summary>
        /// supprime une Option specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du Option à supprimer</param>   
        /// <response code="200">Option selectionné</response>
        /// <response code="404">Option introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Option), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<Option>> DeleteOption(int id)
        {
            try
            {
                var optionToDelete = await optionRepository.GetOption(id);

                if (optionToDelete == null)
                {
                    return NotFound($"Option with Id = {id} not found");
                }

                return await optionRepository.DeleteOption(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // GET: api/Option/value/5
        /// <summary>
        /// recherche une Option specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="name">valeur de l'Option à rechercher</param>   
        /// <response code="200">Option recherché</response>
        /// <response code="404">Option introuvable pour la valeur specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet("value/{search}")]
        [ProducesResponseType(typeof(Option), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult<IEnumerable<Option>>> Search(string name)
        {
            try
            {
                var result = await optionRepository.SearchOption(name);

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