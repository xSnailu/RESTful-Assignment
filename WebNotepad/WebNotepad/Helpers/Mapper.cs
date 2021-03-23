using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebNotepad.Models;

namespace webApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        
        public AutoMapperProfile()
        {
            CreateMap<ArchiveNote, ArchiveNoteDBO>() // example of mapping
               .ReverseMap();
            CreateMap<ArchiveNoteDBO, ArchiveNote>() // example of mapping
               .ReverseMap();

            CreateMap<CurrentNote, CurrentNoteDBO>() // example of mapping
                .ReverseMap();
            CreateMap<CurrentNoteDBO, CurrentNote>() // example of mapping
               .ReverseMap();

            CreateMap<CurrentNote, ArchiveNote>()
                    .ForMember(dest => dest.NoteId, a => a.MapFrom(src => src.Id)).ReverseMap();

            /*
               CreateMap<SourceData, DestData>()
   .ForMember(dest => dest.DestName, a => a.MapFrom(src => src.SourceName))
   .ForMember(dest => dest.Code, a => a.MapFrom(src => src.SourceCode))
            );
            */
            /*

            */
        }

    }
}