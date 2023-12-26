using AutoMapper;
using AutoMapper.Execution;
using MambaAPIclasstask.DTOs.MemberDtos;
using MambaAPIclasstask.DTOs.ProfessionDto;
using MambaAPIclasstask.Entities;
using Member = MambaAPIclasstask.Entities.Member;

namespace MambaAPIclasstask.MappingProfiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<MemberGetDto, Member>().ReverseMap();
            CreateMap<MemberUpdateDto, Member>().ReverseMap();
            CreateMap<MemberCreateDto, Member>().ReverseMap();
            CreateMap<ProfessionGetDto, Profession>().ReverseMap();
            CreateMap<ProfessionCreateDto, Profession>().ReverseMap();
           
        }
    }
}
