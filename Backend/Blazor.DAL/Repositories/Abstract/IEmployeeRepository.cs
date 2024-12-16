﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Models;

namespace Blazor.DAL.Repositories.Abstract
{
    public interface IEmployeeRepository:IRepository<Employee>
    {

        Task ConfirmEmployee(int id);
    }
}