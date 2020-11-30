using FormManagement.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace FormManagement.BL.RepositoryClass
{
    public class FormRepository : IFormRepository
    {
        private readonly FormManagementEntities _context;
        
        public FormRepository(FormManagementEntities context)
        {
            _context = context;
        }
        public int Add(Form entity)
        {
            int result = -1;
            if (entity != null)
            {
                _context.Forms.Add(entity);
                _context.SaveChanges();
                result = entity.Id;
            }
            return result;
        }
        public Form form()
        {
            return new Form();
        }
        public User GetUser(string username)
        {
            return _context.Users.FirstOrDefault(x => x.username == username);
        }
        public IEnumerable<Form> GetAllForms()
        {
            return _context.Forms.Include(x => x.User).OrderByDescending(x => x.formName).ToList();
        }

        public Form GetFormById(int id)
        {
            return _context.Forms.Find(id);
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
    }
}
