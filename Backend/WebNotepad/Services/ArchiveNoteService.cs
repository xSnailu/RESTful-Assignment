using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebNotepad.Models;

namespace webApi.Services
{
    public class ArchiveNoteService : IArchiveNoteService
    {
        private WebNotepadDBContext _context;
        private readonly IMapper _mapper;
        private readonly INoteService _noteService;

        public ArchiveNoteService(WebNotepadDBContext context, IMapper mapper, INoteService noteService)
        {
            _context = context;
            _mapper = mapper;
            _noteService = noteService;
        }

        public IEnumerable<CurrentNoteDTO> GetHistoryOfNoteById(int id)
        {
            var queryResult = _context.ArchiveNotes.Where(x => x.NoteId == id).Select(x => x).OrderBy(x => x.Version).ToList();

            var retList = new List<CurrentNoteDTO>();
            foreach(var archNote in queryResult)
            {
                retList.Add(_mapper.Map<CurrentNoteDTO>(archNote));
            }
            var currentNote = _context.CurrentNotes.FirstOrDefault(x => x.Id == id);
            if (currentNote != null)
            {
                retList.Add(_mapper.Map<CurrentNoteDTO>(currentNote));
            }

            return retList;
        }
    }
}