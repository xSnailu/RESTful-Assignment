using System;
using System.Collections.Generic;

#nullable disable

namespace WebNotepad.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsActive { get; set; }
        public int Version { get; set; }

        public virtual NoteKey NoteNavigation { get; set; }
    }
}
