using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Interface
{
    public interface ISessionType
    {
        public void add(ISessionType Entity);
        public Task delete(Guid id);
        public Task<List<ISessionType>> List();
       
    }
}
