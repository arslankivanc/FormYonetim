using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormManagement.DAL.RepositoryClass.Concrete;
using FormManagement.DAL.RepositoryClass.Interface;
using FormManagement.Domain;

namespace FormManagement.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private FormManagementEntities _context;
        public UnitOfWork(FormManagementEntities context)
        {
            _context = context;
            FormRepository = new FormRepository(_context);
            LoginRepository = new LoginRepository(_context);
        }
        public IFormRepository FormRepository { get; private set; }
        public ILoginRepository LoginRepository { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int CompleteSave()
        {
            return _context.SaveChanges();
        }
    }

}
