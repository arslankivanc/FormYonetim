using FormManagement.DAL.RepositoryClass.Interface;
using FormManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormManagement.DAL.RepositoryClass.Concrete
{
    public class FormRepository:Repository<Form>,IFormRepository
    {
        public FormRepository(FormManagementEntities context):base(context)
        {

        }

        public IEnumerable<Form> GetFormsOrderBy()
        {
            return formcontext.Forms.OrderBy(x => x.formName).ToList();
        }
        public FormManagementEntities formcontext { get { return _context as FormManagementEntities; } }

    }
}
