using ACTReorderList.Core.Domain.Model;
using System.Collections.Generic;

namespace ACTReorderList.Infra.Data.EF.Repository
{
    public class TaskRepository
    {
        private readonly Context _con;

        public TaskRepository()
        {
            _con = new Context();
        }

        public IEnumerable<Task> GetAll()
        {
            return _con.Set<Task>();
        }
    }
}