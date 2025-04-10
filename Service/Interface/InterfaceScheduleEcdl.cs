using Identity2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Service.Interface
{
    public interface InterfaceScheduleEcdl
    {
        public void add(SchedulerEcdl Entity);
        public Task delete(Guid id);

    }
}
