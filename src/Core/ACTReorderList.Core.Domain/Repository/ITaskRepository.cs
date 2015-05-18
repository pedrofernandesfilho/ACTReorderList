using ACTReorderList.Core.Domain.Model;
using System.Collections.Generic;

namespace ACTReorderList.Core.Domain.Repository
{
    public interface ITaskRepository
    {
        Task Get(int id);
        
        IEnumerable<Task> Get();

        void Add(Task t);

        void Update(Task t);
    }
}