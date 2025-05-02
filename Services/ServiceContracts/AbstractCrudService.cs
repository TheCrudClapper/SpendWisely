using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceContracts
{
    public abstract class AbstractCrudService<RequestType, ResponseType>
    {
        public abstract Task<IEnumerable<ResponseType>> GetAll();
        public abstract Task<ResponseType> GetItem(int id);

        public abstract Task Delete(int id);


    }
}
