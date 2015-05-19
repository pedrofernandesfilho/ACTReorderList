using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Repository;

namespace ACTReorderList.Core.Domain.Service
{
    public class ServiceTask
    {
        private readonly ITaskRepository _taskRepository;

        public ServiceTask(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task[] GetAllOrderByPriority()
        {
            return _taskRepository.GetAll(t => t.Priority);
        }

        public int UpdatePriority(int id, int priority)
        {
            Task t = _taskRepository.Get(id);
            t.Priority = priority;
            return _taskRepository.Update(t);
        }

        public void Add(string description, int priority)
        {
            _taskRepository.Add(new Task { Description = description, Priority = priority });
        }
    }
}