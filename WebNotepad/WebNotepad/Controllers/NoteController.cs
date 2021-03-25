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
    [Route("note")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
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
        public ActionResult<CurrentNoteDTO> GetNote([FromQuery] int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var note = _noteService.GetNote(id.Value);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        /// <summary>
        /// Creates New Note
        /// </summary>
        /// <returns> Create New Note</returns>
        /// <response code="200">Note successfully added</response>
        /// <response code="400">Bad Request</response> 
        [HttpPost]
        public ActionResult CreateNote([FromBody] CurrentNoteDTO newNote)
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
        [HttpGet("all")]
        public ActionResult<IEnumerable<CurrentNoteDTO>> GetAllNotes()
        {
            return Ok(_noteService.GetAllNotes());
        }

        /// <summary>
        /// Update Note
        /// </summary>
        /// <param name="id"> Update Id </param>
        /// <returns> Update Note </returns>
        /// <response code="200">Note udpated</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="404">Resource Not Found</response> 
        [HttpPatch]
        public ActionResult UpdateNote([FromBody] CurrentNoteDTO patchNote)
        {
            if(patchNote == null)
            {
                return BadRequest();
            }
            if(_noteService.UpdateNote(patchNote))
            {
                return Ok();
            }else
            {
                return NotFound();
            }
        }
    }
}
