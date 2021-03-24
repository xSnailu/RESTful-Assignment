using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Services;
using WebNotepad.Models;

namespace webApi.Controllers
{
    [ApiController]
    [Route("archivednote")]
    public class ArchivedNoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public ArchivedNoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        /// <summary>
        /// Returns Note Details
        /// </summary>
        /// <param name="id"> Note Id </param>
        /// <returns> Returns Note Details </returns>
        /// <response code="200">Return Note details</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="404">Resource Not Found</response> 
        [HttpGet]
        public ActionResult<CurrentNoteDBO> GetNote([FromQuery] int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var note = _noteService.GetNote(id.Value);
            if (note == null)
            {
                return NotFound("Resource not Found");
            }
            return Ok(note);
        }

        /// <summary>
        /// Creates New Note
        /// </summary>
        /// <returns> Create New Note</returns>
        /// <response code="200">Note successfully added</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">UnAuthorised</response>
        [HttpPost]
        public ActionResult CreateNote([FromBody] CurrentNoteDBO newNote)
        {
            if (newNote == null)
            {
                return BadRequest("Bad Request");
            }
            _noteService.CreateNote(newNote);

            return Ok();
        }

        /// <summary>
        /// Deletes Note
        /// </summary>
        /// <param name="id"> Note Id </param>
        /// <returns> Delete Note </returns>
        /// <response code="200">Note deleted</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">UnAuthorised</response>
        /// <response code="404">Resource Not Found</response> 
        [HttpDelete]
        public ActionResult DeleteNote([FromQuery] int id)
        {
            _noteService.DeleteNote(id);
            return Ok();
        }

        /// <summary>
        /// Returns All DiscountCodes
        /// </summary>
        /// <returns> Returns All DiscountCodes </returns>
        /// <response code="200">Returns all DiscountCodes </response>
        /// <response code="400">Bad Request</response> 
        /// <response code="401">UnAuthorised</response> 
        [HttpGet("all")]
        public ActionResult<IEnumerable<CurrentNoteDBO>> GetAllNotes()
        {
            return Ok(_noteService.GetAllNotes());
        }
        
    }
}
