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
            /*
               var mapConfig = new MapperConfiguration(
               cfg => cfg.CreateMap<Employee, EmployeeDto>()
                  .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
            );
            */
            /*
                var mapper = mapConfig.CreateMapper();
            */
        }
        
    }
}