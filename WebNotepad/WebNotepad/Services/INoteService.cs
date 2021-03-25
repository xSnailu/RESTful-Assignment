using System.Collections.Generic;
using WebNotepad.Models;

namespace webApi.Services
{
    public interface INoteService
    {
        public CurrentNote GetNote(int id);
        int CreateNote(CurrentNoteDTO note);
        bool DeleteNote(int id);
        int UpdateNote(int id);
        public IEnumerable<CurrentNoteDTO> GetAllNotes();
    }
}