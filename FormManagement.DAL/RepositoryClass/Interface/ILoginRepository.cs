using FormManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormManagement.DAL.RepositoryClass.Interface
{
    public interface ILoginRepository:IRepository<User>
    {
        User GetUser(string username);
        User GetUserWithPassword(string username, string password);
    }
}
