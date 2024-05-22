using AutoMapper;
using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.DAL.Repositories;
using MeowTasksBackend.DAL.Repositories.Contract;
using MeowTasksBackend.DTO;
using MeowTasksBackend.Entity;
using MeowTasksBackend.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.BLL.Services
{
  public class MeowUserService : IMeowUserService
  {
    private readonly IGenericRepository<MeowUser> _meowUserRepository;
    private readonly IMapper _mapper;
    private readonly ResponseConsts _rspConsts = new();

    public MeowUserService(IGenericRepository<MeowUser> meowUserRepository, IMapper mapper)
    {
      _meowUserRepository = meowUserRepository;
      _mapper = mapper;
    }

    public MeowUserDTO MeMeowUser(int meowUserId)
    {
      MeowUser? FindUser = _meowUserRepository.Get(u => u.MeowUserId == meowUserId);

      if (FindUser == null)
        throw new TaskCanceledException(_rspConsts.MEOWUSER_ME_FAILED);

      return _mapper.Map<MeowUserDTO>(FindUser);
    }
  }
}
