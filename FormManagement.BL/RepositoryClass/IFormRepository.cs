using FormManagement.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FormManagement.BL.RepositoryClass
{
    public interface IFormRepository :IDisposable 
    {
        IEnumerable<Form> GetAllForms();
        Form GetFormById(int id);
        int Add(Form entity);
        User GetUser(string username);
        Form form();
    }
}
