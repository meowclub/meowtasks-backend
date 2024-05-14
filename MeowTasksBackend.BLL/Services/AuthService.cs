using AutoMapper;
using MeowTasksBackend.BLL.Services.Contract;
using MeowTasksBackend.DAL.Repositories.Contract;
using MeowTasksBackend.DTO;
using MeowTasksBackend.DTO.Requests;
using MeowTasksBackend.Entity;
using MeowTasksBackend.Utilities;
using MeowTasksBackend.Utilities.Consts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.BLL.Services
{
  public class AuthService : IAuthService
  {
    private readonly IGenericRepository<MeowUser> _meowUserRepository;
    private readonly IGenericRepository<MeowUserRole> _meowUserRoleRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly ResponseConsts _rspConsts = new();

    public AuthService(IGenericRepository<MeowUser> meowUserRepository, IGenericRepository<MeowUserRole> meowUserRoleRepository, IMapper mapper, IConfiguration config)
    {
      _meowUserRepository = meowUserRepository;
      _meowUserRoleRepository = meowUserRoleRepository;
      _mapper = mapper;
      _config = config;
    }

    public string LoginMeowUser(MeowUserLoginRequestDTO model)
    {
      ManageToken mngToken = new();

      try
      {
        var FindUser = _meowUserRepository.Get(u => u.Nickname == model.Nickname && u.Password == model.Password);

        if (FindUser == null)
        {
          throw new TaskCanceledException(_rspConsts.MEOWUSER_LOGIN_INCORRECT_CREDENTIALS);
        }

        var token = mngToken.CreateToken(_config, FindUser);

        return token;
      }
      catch (Exception)
      {

        throw;
      }
    }

    public async Task<string> RegisterMeowUser(MeowUserRegisterRequestDTO model)
    {
      ManageToken mngToken = new();

      try
      {
        var FindUser = _meowUserRepository.Get(u => u.Nickname == model.Nickname);

        if (FindUser != null)
        {
          throw new TaskCanceledException(_rspConsts.MEOWUSER_REGISTER_NICKNAME_TAKED);
        }

        var NewUser = await _meowUserRepository.Create(_mapper.Map<MeowUser>(model));
        
        MeowUserRole DefaultUserRole = new()
        {
          Name = "meowUser",
          UserId = NewUser.MeowUserId
        };

        await _meowUserRoleRepository.Create(DefaultUserRole);

        var token = mngToken.CreateToken(_config, NewUser);

        return token;
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
