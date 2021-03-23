using System;
using System.Collections.Generic;

#nullable disable

namespace WebNotepad.Models
{
    public partial class CurrentNote
    {
        public CurrentNote()
        {
            ArchiveNotes = new HashSet<ArchiveNote>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ArchiveNote> ArchiveNotes { get; set; }
    }
}
