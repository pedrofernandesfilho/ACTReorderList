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
            Task t = _taskRepository.Get(id);
            t.Priority = priority;
            return _taskRepository.Update(t);
        }

        public void Add(int Priority, string description)
        {
            _taskRepository.Add(new Task { Priority = Priority, Description = description });
        }
    }
}