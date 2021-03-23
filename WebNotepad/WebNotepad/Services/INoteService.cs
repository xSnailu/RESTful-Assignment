using System.Collections.Generic;
using WebNotepad.Models;

namespace webApi.Services
{
    public interface INoteService
    {
        public NoteDBO GetNote(int? id);
        int CreateNote(NoteDBO note);
        bool DeleteNote(int? id);
        int UpdateNote(int? id);
        public IEnumerable<NoteDBO> GetAllNotes();
    }
}