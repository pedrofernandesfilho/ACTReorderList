using ACTReorderList.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACTReorderList.Core.Domain.Repository
{
    public interface ITaskRepository
    {
        IList<Task> Get();

        void Add(Task t);

        void Update(Task t);
    }
}
