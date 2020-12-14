using FormManagement.DAL.RepositoryClass.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormManagement.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IFormRepository FormRepository { get; }
        ILoginRepository LoginRepository { get; }
        int CompleteSave();
    }
}
