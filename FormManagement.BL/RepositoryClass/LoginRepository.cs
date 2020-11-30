using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormManagement.DAL.EntityFramework;

namespace FormManagement.BL.RepositoryClass
{
    public class LoginRepository : ILoginRepository
    {
        private readonly FormManagementEntities _context;

        public LoginRepository(FormManagementEntities context)
        {
            _context = context;
        }
        public int Add(User entity)
        {
            int result = -1;
            if (entity != null)
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                result = entity.Id;
            }
            return result;
        }

        public User user()
        {
            return new User();
        }

        public User GetFormById(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.username == username);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public User LoginWithPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(x => x.username == username && x.password == password);
        }
    }
}
