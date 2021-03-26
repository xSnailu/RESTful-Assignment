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
            CreateMap<CurrentNote, CurrentNoteDTO>() 
                .ReverseMap();

            CreateMap<CurrentNote, ArchiveNote>()
                    .ForMember(dest => dest.NoteId, a => a.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<CurrentNoteDTO, ArchiveNote>()
                    .ForMember(dest => dest.NoteId, a => a.MapFrom(src => src.Id)).ReverseMap();

                    /*
                       CreateMap<SourceData, DestData>()
           .ForMember(dest => dest.DestName, a => a.MapFrom(src => src.SourceName))
           .ForMember(dest => dest.Code, a => a.MapFrom(src => src.SourceCode))
                    );
                    */
            
        }

    }
}