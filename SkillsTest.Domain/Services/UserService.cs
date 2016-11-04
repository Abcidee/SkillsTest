using SkillsTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkillsTest.Domain.Services
{
    public class UserService : BaseService<DefaultDbContext, User>, IUserService
    {
        public void Add(User entity)
        {
            this._Add(entity);
            this._SaveChanges();
        }

        public User Verify(string email, string password)
        {
            var user = this.Context.Users.FirstOrDefault(a => a.EmailAddress == email.ToLower());

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                return user;

            return null;
        }

        public User Verify(Guid userId, string password)
        {
            var user = this.Context.Users.FirstOrDefault(a => a.Id == userId);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                return user;

            return null;
        }

        public void UpdatePassword(Guid userId, string newPassword)
        {
            var user = this.Context.Users.FirstOrDefault(a => a.Id == userId);

            if (user != null)
            {
                user.ClearTextPassword = newPassword;
                this._Update(user);
                this._SaveChanges();
            }
        }

        public bool EmailExist(string emailAddress)
        {
            return this.All().Where(a => a.EmailAddress == emailAddress).Count() > 0 ? true : false;
        }
    }

    public interface IUserService : IBaseService<User>
    {
        void Add(User entity);
        User Verify(string email, string password);
        User Verify(Guid userId, string password);
        void UpdatePassword(Guid userId, string newPassword);
        bool EmailExist(string emailAddress);
    }
}
