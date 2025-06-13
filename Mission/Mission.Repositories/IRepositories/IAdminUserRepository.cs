using Mission.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.Interface
{
    public interface IAdminUserRepository
    {
        List<UserDetails> UserDetailsList();
        string DeleteUser(int id);
        string UpdateUser(UserDetails userDetails);
    }
}