using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnection _connection;

        public UsersRepository (IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _connection.Query<Users>("Select * From users;");


        }
        public Users GetUsers(int id)
        {
            return _connection.QuerySingle<Users>("SELECT * FROM USERS WHERE MID = @id", new { id = id });
        }

        public void UpdateUsers(Users users)
        {
            _connection.Execute("UPDATE users SET Fname = @fname,  Lname = @lname, mid = @mid, gender = @gender, dob = @dob, mobile = @mobile, email = @email, joindate = @joinDate, gymtime = @gymtime, maddress = @maddress, membershipperiod = @membershipPeriod WHERE MID = @Mid",
             new { fname = users.Fname,  lname = users.Lname, mid = users.MID, gender = users.Gender, dob = users.Dob, mobile = users.Mobile, email = users.Email, joindate = users.JoinDate, gymtime = users.Gymtime, maddress = users.Maddress, membershipperiod = users.MembershipPeriod  });
        }

        public void InsertUsers(Users usersToInsert)
        {
            _connection.Execute("INSERT INTO users ( FNAME, LNAME, MID, GENDER, DOB, MOBILE, EMAIL, JOINDATE, GYMTIME, MADDRESS, MEMBERSHIPPERIOD, ) VALUES (@fname, @lname, @mid, @gender, @dob, @mobile, @email, @joinDate,@gymtime, @maddress, @membershipPeriod);",
                new { fname = usersToInsert.Fname, lname = usersToInsert.Lname, mid = usersToInsert.MID, gender = usersToInsert.Gender, dob = usersToInsert.Dob, mobile = usersToInsert.Mobile, email = usersToInsert.Email, joindate = usersToInsert.JoinDate, gymtime = usersToInsert.Gymtime, maddress = usersToInsert.Maddress, membershipperiod = usersToInsert.MembershipPeriod });
        }

        public IEnumerable<Users> GetCategories() 
        {
            return _connection.Query<Users>("SELECT * FROM users;");
        }

        public Users AssignCategory()
        {
            var categoryList = GetCategories();
            var users = new Users();
            users.MIDs = categoryList;

            return users;
        }





    }
}
