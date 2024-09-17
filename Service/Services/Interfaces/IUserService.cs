﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task Check(string userName, string password);
    }
}
