using FormManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormManagement.DAL.RepositoryClass.Interface
{
    public interface IFormRepository:IRepository<Form>
    {
        IEnumerable<Form> GetFormsOrderBy();

    }
}
