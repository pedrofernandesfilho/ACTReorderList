using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Repository;
using System.Collections.Generic;

namespace ACTReorderList.Core.Domain.Service
{
    public class ServiceTask
    {
        private readonly ITaskRepository _taskRepository;

        public ServiceTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public ServiceTask() {}

        public IList<Task> Get()
        {
            IList<Task> ret = new List<Task>();

            ret.Add(new Task { Id = 10, Priority = 5, Description = "Release" });
            ret.Add(new Task { Id = 11, Priority = 4, Description = "Test" });            
            ret.Add(new Task { Id = 12, Priority = 3, Description = "Implement code" });
            ret.Add(new Task { Id = 13, Priority = 2, Description = "Create Project" });
            ret.Add(new Task { Id = 14, Priority = 1, Description = "Create repositorty" });

            return ret;
        }
    }
}