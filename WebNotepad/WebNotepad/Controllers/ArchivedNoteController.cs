using Microsoft.AspNetCore.Cors;
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
        private readonly IArchiveNoteService _archivedNoteService;

        public ArchivedNoteController(IArchiveNoteService archivedNoteService)
        {
            _archivedNoteService = archivedNoteService;
        }

        /// <summary>
        /// Returns Note History 
        /// </summary>
        /// <param name="id"> Note Id </param>
        /// <returns> Returns Note History </returns>
        /// <response code="200">Return Note History</response>
        /// <response code="400">Bad Request</response> 
        /// <response code="404">Resource Not Found</response> 
        [EnableCors]
        [HttpGet]
        public ActionResult<IEnumerable<CurrentNoteDTO>> GetHistoryOfNote([FromQuery] int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var history = _archivedNoteService.GetHistoryOfNoteById(id.Value);
            if (!history.Any())
            {
                return NotFound();
            }
            return Ok(history);
        }
        
    }
}
