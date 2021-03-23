using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebNotepad.Models;

namespace webApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        /*
        public AutoMapperProfile()
        {
            CreateMap<NoteDBO, Note>() // example of mapping
               .ReverseMap();
            CreateMap<Note, NoteDBO>() // example of mapping
               .ReverseMap();

            CreateMap<NoteKeyDBO, NoteKey>() // example of mapping
                .ReverseMap();

            CreateMap<List<Note>, List<NoteDBO>>() // example of mapping
                .ReverseMap();
            CreateMap<List<NoteDBO>, List<Note>>() // example of mapping
                .ReverseMap();
        }
        */
    }
}