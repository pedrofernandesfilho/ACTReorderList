using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Repository;
using System.Data;

namespace ACTReorderList.Core.Domain.Service
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //public IEnumerable<Task> GetAllOrderByPriority()
        public DataView GetAllOrderByPriority()
        {
            // Test to resolve new Priority automatically
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Priority", typeof(int));
            table.Columns.Add("Description", typeof(string));

            DataRow row;
            foreach (Task item in _taskRepository.GetAll(t => t.Priority))
            {
                row = table.NewRow();
                row["Id"] = item.Id;
                row["Priority"] = item.Priority;
                row["Description"] = item.Description;
                table.Rows.Add(row);
            }

            //return _taskRepository.GetAll(t => t.Priority);
            table.DefaultView.Sort = "Priority";
            return table.DefaultView;
        }

        public int Update(int id, int priority, string description)
        {
            Task t = _taskRepository.Get(id);
            t.Priority = priority;
            t.Description = description;
            return _taskRepository.Update(t);
        }
        // Test
        public int Add(string description)
        {
            return Add(description, 888);
        }
        // Test
        public int Add(string description, int priority = 99)
        {
            return Add(0, priority, description);
        }
        // Test
        public int Add(int id, int priority, string description)
        {
            return _taskRepository.Add(new Task { Priority = priority, Description = description });
        }
    }
}