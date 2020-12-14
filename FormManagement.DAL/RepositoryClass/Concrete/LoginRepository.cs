using FormManagement.DAL.RepositoryClass.Interface;
using FormManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormManagement.DAL.RepositoryClass.Concrete
{
    public class LoginRepository : Repository<User>, ILoginRepository
    {
        public LoginRepository(FormManagementEntities context):base(context)
        {

        }
        public User GetUser(string username)
        {
            return logincontext.Users.FirstOrDefault(x => x.username == username);
        }

        public User GetUserWithPassword(string username, string password)
        {
            return logincontext.Users.FirstOrDefault(x => x.username == username && x.password == password);
        }

        public FormManagementEntities logincontext { get { return _context as FormManagementEntities; } }

    }
}
