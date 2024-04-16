using Data;
using Cs_Plantlover.Repository.IRepository;
using Cs_Plantlover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cs_Plantlover.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly DoAnWebDbContext _context;
        public UserRepository(DoAnWebDbContext context)
        {
            _context = context;
        }

        public void Update(User user)
        {
            _context.Update(user);
            
        }
    }
}
