using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebNotepad.Models
{
    public partial class ArchiveNote
    {
        [Required]
        public int NoteId { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [Required]
        [StringLength(512)]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Modified { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int Version { get; set; }
    }
}
