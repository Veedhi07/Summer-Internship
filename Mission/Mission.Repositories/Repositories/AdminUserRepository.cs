using Mission.Entities.Context;
using Mission.Entities.Models;
using Mission.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories
{
    public class AdminUserRepository(MissionDbContext _missionDb) : IAdminUserRepository
    {
        public List<UserDetails> UserDetailsList()
        {
            var res = _missionDb.User.Where(x => !x.IsDeleted && x.UserType == "user").Select(x => new UserDetails(x));
            return res.ToList();
        }
        public string DeleteUser(int id)
        {
            var user = _missionDb.User.Where(x => x.Id == id).FirstOrDefault();

            if (user == null) throw new Exception("Account does't exist!");

            user.IsDeleted = true;

            //user.EmailAddress = model.EmailAddress

            user.ModifiedDate = DateTime.Now;
            _missionDb.User.Update(user);
            _missionDb.SaveChanges();
            return "Account deleted!";
        }

        public string UpdateUser(UserDetails userDetails)  //new 
        {
            var user = _missionDb.User.FirstOrDefault(x => x.Id == userDetails.Id);

            if (user == null)
            {
                throw new Exception("User not found!");
            }

            // Update the fields you want to allow to be updated
            user.FirstName = userDetails.FirstName;
            user.LastName = userDetails.LastName;
            user.EmailAddress = userDetails.EmailAddress;
            user.PhoneNumber = userDetails.PhoneNumber;
            user.ModifiedDate = DateTime.Now;

            _missionDb.User.Update(user);
            _missionDb.SaveChanges();

            return "User updated successfully!";
        }

    }
}
