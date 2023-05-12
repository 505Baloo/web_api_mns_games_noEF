﻿using System.Data;
using System.Data.Common;
using WebAPI_MNS_Games.Domain;
using WebAPI_MNS_Games.Domain.DTO;
using WebAPI_MNS_Games.Models;

namespace WebAPI_MNS_Games.Abstractions
{
    public interface IAppUserService
    {
        public IEnumerable<AppUserDTO> GetAllUsersDTO();

        public AppUserDTO GetAllUsersNicknameDTO(int id);

        public string CreateAppUser(CreateAppUserCmd appUserCmd);

        public void DeleteAppUser(int id);

        public void UpdateAppUser(EditAppUserCmd editAppUserCmd, int id);
    }
}
