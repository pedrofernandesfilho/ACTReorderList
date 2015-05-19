using ACTReorderList.Core.Domain.Model;
using System;

namespace ACTReorderList.Core.Domain.Repository
{
    public interface ITaskRepository
    {
        Task Get(int id);

        Task[] GetAll<OrderBy>(Func<Task, OrderBy> orderBy);

        void Add(Task t);

        int Update(Task t);
    }
}