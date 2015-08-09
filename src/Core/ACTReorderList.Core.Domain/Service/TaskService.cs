using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Repository;
using System.Collections.Generic;

namespace ACTReorderList.Core.Domain.Service
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<Task> GetAllOrderByPriority()
        {
            return _taskRepository.GetAll(t => t.Priority);
        }

        public int UpdatePriority(int id, int priority, string description)
        {
            return UpdatePriority(id, priority);
        }

        public int UpdatePriority(int id, int priority)
        {
            Task t = _taskRepository.Get(id);
            t.Priority = priority;
            return _taskRepository.Update(t);
        }

        public int Add(int priority, string description)
        {
            return _taskRepository.Add(new Task { Priority = priority, Description = description });
        }
    }
}