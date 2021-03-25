using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNotepad.Models;

namespace webApi.Services
{
    public class NoteService : INoteService
    {
        
        private WebNotepadDBContext _context;
        private readonly IMapper _mapper;
        public NoteService(WebNotepadDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CurrentNote GetNote(int id)
        {
            return _context.CurrentNotes.FirstOrDefault(note => note.Id == id);
        }

        public int CreateNote(CurrentNoteDTO note)
        {

            if(note.Created == null)
            {
                note.Created = DateTime.Now;
            }

            if(note.Modified == null)
            {
                note.Modified = DateTime.Now;
            }

            var newNote = _mapper.Map<CurrentNote>(note);
            _context.CurrentNotes.Add(newNote);
            _context.SaveChanges();
            return newNote.Id = newNote.Id;
        }

        public bool DeleteNote(int id)
        {
            var noteToDelete = _context.CurrentNotes.FirstOrDefault(note => note.Id == id);
            if(noteToDelete == null)
            {
                return false;
            }else
            {
                var NoteToArchive = _mapper.Map<ArchiveNote>(noteToDelete);
                // <TODO> delete time as "modified" property
                NoteToArchive.IsActive = false;
                NoteToArchive.Modified = DateTime.Now;
                _context.ArchiveNotes.Add(NoteToArchive);
                _context.SaveChanges();
                _context.CurrentNotes.Remove(noteToDelete);
                _context.SaveChanges();

                return true;
            }
        }

        public bool UpdateNote(CurrentNoteDTO note)
        {
            var notefromDB = _context.CurrentNotes.FirstOrDefault(x => x.Id == note.Id);
            if (notefromDB == null)
            {
                return false;
            }
            note.IsActive = true;
            note.Created = notefromDB.Created;
            note.Modified = DateTime.Now;
            _context.Entry(notefromDB).CurrentValues.SetValues(_mapper.Map<CurrentNote>(note));
            _context.SaveChanges();
            return true;
            
        }

        public IEnumerable<CurrentNoteDTO> GetAllNotes()
        {
            var queryResult = (from Notes in _context.CurrentNotes select Notes).ToList();
            queryResult.Sort((n1, n2) => n1.Id.CompareTo(n2.Id));

            // mapping whole list does not work
            // <TODO> change it 
            // mapper 
            List<CurrentNoteDTO> retList = new List<CurrentNoteDTO>();
            foreach (var note in queryResult)
            {
                retList.Add(_mapper.Map<CurrentNoteDTO>(note));
            }
            return retList;
        }
    }

}
