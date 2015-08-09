using ACTReorderList.Core.Domain.Model;
using System;
using System.Collections.Generic;

namespace ACTReorderList.Core.Domain.Repository
{
    public interface ITaskRepository
    {
        Task Get(int id);

        IEnumerable<Task> GetAll<OrderBy>(Func<Task, OrderBy> orderBy);

        int Add(Task t);

        int Update(Task t);
    }
}