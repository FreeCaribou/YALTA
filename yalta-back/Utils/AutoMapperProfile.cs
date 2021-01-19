using AutoMapper;
using Yalta.Models;
using Yalta.Models.DTO;
using System;

namespace Utils
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserSimpleDTO>();
      CreateMap<User, UserWithoutInfoDTO>();
      CreateMap<UserSignUpDTO, User>();

      CreateMap<Profil, ProfilDTO>()
      .ForMember(dest => dest.Age, opt => opt.MapFrom<BirthdayToAgeResolver>());
      CreateMap<ProfilSignUpForUserDTO, Profil>();
      CreateMap<ProfilUpdateDTO, Profil>();

      CreateMap<HatedPersonalities, PersonalitiesTopDTO>();
      CreateMap<LovedPersonalities, PersonalitiesTopDTO>();
      CreateMap<PersonalitiesTopPostDTO, HatedPersonalities>();
      CreateMap<PersonalitiesTopPostDTO, LovedPersonalities>();

      CreateMap<PreferredPeriod, PreferredPeriodDTO>();
      CreateMap<PreferredPeriodDTO, PreferredPeriod>();
      CreateMap<PreferredPeriodPutDTO, PreferredPeriod>();

      CreateMap<Area, AreaDTO>();
      CreateMap<AreaPutDTO, Area>();
    }
  }

  public class BirthdayToAgeResolver : IValueResolver<Profil, ProfilDTO, int>
  {
    public int Resolve(Profil source, ProfilDTO destination, int member, ResolutionContext context)
    {
      int age = DateTime.Now.Year - source.BirthdayDate.Year;
      if (source.BirthdayDate.Date > DateTime.Now.AddYears(-age))
      {
        age--;
      }
      return age;
    }
  }

}
