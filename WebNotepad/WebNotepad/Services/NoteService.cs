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

        public int CreateNote(CurrentNoteDBO note)
        {
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
                _context.ArchiveNotes.Add(NoteToArchive);
                _context.SaveChanges();
                _context.CurrentNotes.Remove(noteToDelete);
                _context.SaveChanges();
            }

            throw new NotImplementedException();
        }

        public int UpdateNote(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CurrentNoteDBO> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        /*
        public int CreateNote(NoteDBO noteDBO)
        {
            if(noteDBO.NoteId == null)
            {
                var newNoteKey = _mapper.Map<NoteKey>(new NoteKeyDBO());
                _context.NoteKeys.Add(newNoteKey);
                _context.SaveChanges();
                noteDBO.NoteId = newNoteKey.Id;

                var note = _mapper.Map<Note>(noteDBO);
                _context.Notes.Add(note);
                _context.SaveChanges();
                return note.NoteId;
            }else
            {
                var note = _mapper.Map<Note>(noteDBO);
                _context.Notes.Add(note);
                _context.SaveChanges();
                return note.NoteId;
            }
        }

        public bool DeleteNote(int? id)
        {
            if (_context.NoteKeys.FirstOrDefault(noteKey => noteKey.Id == id) != null)
            {
                var queryResult = (from Notes in _context.Notes.Where(n => n.NoteId == id) select Notes).ToList();
                queryResult.Sort((n1, n2) => n1.Version.CompareTo(n2.Version));

                var noteDBO = _mapper.Map<NoteDBO>(queryResult.Last());
                var note = _mapper.Map<Note>(noteDBO);
                note.IsActive = false;
                _context.Notes.Add(note);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public NoteDBO GetNote(int? id)
        {
            if(_context.NoteKeys.FirstOrDefault(noteKey => noteKey.Id == id) != null)
            {
                var queryResult = (from Notes in _context.Notes.Where(n => n.NoteId == id) select Notes).ToList();
                queryResult.Sort((n1, n2) => n1.Version.CompareTo(n2.Version));

                if (queryResult.Last().IsActive)
                {
                    return _mapper.Map<NoteDBO>(queryResult.Last());
                }
                else
                    return null;
            }
            else
            {
                return null;
            } 
        }

        public IEnumerable<NoteDBO> GetAllNotes()
        {
            var allNotes = (from x in _context.Notes
                           group x by x.NoteId into g
                              select g.OrderByDescending(y => y.Version).FirstOrDefault()).ToList();

            allNotes.RemoveAll(note => !note.IsActive);

            List<NoteDBO> retList = new List<NoteDBO>();

            // mapping whole list does not work
            // <TODO> 
            foreach(var note in allNotes)
            {
                retList.Add(_mapper.Map<NoteDBO>(note));
            }

            return retList;
        }

        public int UpdateNote(int? id)
        {
            throw new NotImplementedException();
        }

        */
    }

}
