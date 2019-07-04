using System.Collections.Generic;
using System.Linq;
using Lab_APSNETCORE.Context;
using Lab_APSNETCORE.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_APSNETCORE.Services
{
    public class UsersService
    {
        public UsersService(ProjectContext projectContext) => _projectContext = projectContext;
        private readonly ProjectContext _projectContext;
        public User Add(User user)
        {
            var result = _projectContext.Users.Add(user);
            _projectContext.SaveChanges();
            return result.Entity;
        }
        public User Update(User user)
        {
            _projectContext.Attach(user);
            _projectContext.Entry(user).State = EntityState.Modified;
            var result = _projectContext.Update(user);
            _projectContext.SaveChanges();
            return result.Entity;
        }
        public User Delete(int id)
        {
            var user = Read(id);
            if (user == null)
                return null;
            _projectContext.Entry(user).State = EntityState.Deleted;
            _projectContext.SaveChanges();
            return user;
        }
        public User Read(int id) => _projectContext.Users.FirstOrDefault(x => x.Id == id);
        public List<User> Read() => _projectContext.Users.ToList();
    }
}