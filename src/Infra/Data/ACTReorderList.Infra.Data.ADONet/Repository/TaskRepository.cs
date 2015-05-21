using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ACTReorderList.Infra.Data.ADONet.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Conn _c;

        public TaskRepository(Conn c)
        {
            _c = c;
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAll<OrderBy>(Func<Task, OrderBy> orderBy)
        {
            IList<Task> ret = new List<Task>();
            
            string query = "SELECT Id, Priority, Description FROM Task";

            foreach (DataRow item in _c.ExecuteQueryDataSet(query).Tables[0].Rows)
                ret.Add(new Task { Id = (int)item["Id"], Priority = (int)item["Priority"], Description = item["Description"].ToString() });

            return ret.OrderBy(orderBy);
        }

        public void Add(Task t)
        {
            throw new NotImplementedException();
        }

        public int Update(Task t)
        {
            string query = "UPDATE Task SET Priority = @P1, Description = @P2 WHERE Id = @P3";

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter { ParameterName = "@P1", Value = t.Priority },
                new SqlParameter { ParameterName = "@P2", Value = t.Description },
                new SqlParameter { ParameterName = "@P3", Value = t.Id }
            };

            return _c.ExecuteQueryNonQuery(query, parameters);
        }
    }
}