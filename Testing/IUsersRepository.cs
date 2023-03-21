using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Testing.Models;

namespace Testing
{
    public interface IUsersRepository
    {
        public IEnumerable<Users> GetAllUsers();
        public Users GetUsers(int id);
        public void UpdateUsers(Users users);

        public void InsertUsers(Users usersToInsert);

        public IEnumerable<Users> GetCategories();

        public Users AssignCategory();
    }
}
