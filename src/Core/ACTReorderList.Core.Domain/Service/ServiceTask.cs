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

        public IEnumerable<Task> GetAllOrderByPriority()
        {
            return _taskRepository.GetAll(t => t.Priority);
        }

        public int UpdatePriority(int id, int priority, string description)
        {
            Task t = _taskRepository.Get(id);
            t.Priority = priority;
            return _taskRepository.Update(t);
        }

        public void Add(string description, int Priority)
        {
            _taskRepository.Add(new Task { Description = description, Priority = Priority });
        }
    }
}