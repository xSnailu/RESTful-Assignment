using System.Collections.Generic;
using WebNotepad.Models;

namespace webApi.Services
{
    public interface IArchiveNoteService
    {
        public IEnumerable<CurrentNoteDTO> GetHistoryOfNoteById(int id);
    }
}