﻿using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interfacies.DTO;

namespace DAL.Interfacies.Repository
{
    public interface IUserRepository : IRepository<DalUser>//Add user repository methods!
    {
        //string GetRoleNameByUserId(int key);
    }
}