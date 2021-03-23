using System;
using System.Collections.Generic;

#nullable disable

namespace WebNotepad.Models
{
    public partial class NoteKey
    {
        public NoteKey()
        {
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
