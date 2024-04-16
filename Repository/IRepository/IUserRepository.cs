using Nest;
using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cs_Plantlover.Repository.IRepository
{
    public interface IUserRepository 
    {
        void Update(User user);
    }
}