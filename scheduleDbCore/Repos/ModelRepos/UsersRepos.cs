using scheduleDbCore.Models.DbModels;
using System.Linq;

namespace scheduleDbCore.Repos.ModelRepos
{
    public class UsersRepos : BaseRepo<User>
    {
        public User GetOne(string username) => Context.Users.Where(u => u.Username.Equals(username)).FirstOrDefault();
    }
}
