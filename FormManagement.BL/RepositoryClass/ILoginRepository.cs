using FormManagement.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormManagement.BL.RepositoryClass
{
    public interface ILoginRepository:IDisposable
    {
        int Add(User entity);
        User GetFormById(int id);
        User GetUsername(string username);
        User LoginWithPassword(string username, string password);
        User form();
    }
}
