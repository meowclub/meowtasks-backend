using AutoMapper;
using MeowTasksBackend.DTO;
using MeowTasksBackend.Entity;

namespace MeowTasksBackend.Utilities
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      #region MeowUser
        CreateMap<MeowUser, MeowUserDTO>().ReverseMap();
      #endregion
    }
  }
}
