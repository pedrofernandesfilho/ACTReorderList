using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Service;
using ACTReorderList.Infra.Data.ADONet;
using ACTReorderList.Infra.Data.ADONet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACTReorderList.UI.WebForms
{
    public partial class UsingObjectDataSource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // TODO: Use Dependency Injector

        /*
            If select method return IEnumerable, ReorderList can't generate New Item Sort Value.
        */
        public IList<Task> ObjectDataSource_SelectMethod()
        {
            return (new TaskService(new TaskRepository(new Conn()))).GetAllOrderByPriority().ToList();
        }
        
        public void ObjectDataSource_UpdateMethod(int id, int priority, string description)
        {
            (new TaskService(new TaskRepository(new Conn()))).Update(id, priority, description);
        }
        
        public void ObjectDataSource_InsertMethod(int priority, string description)
        {
            (new TaskService(new TaskRepository(new Conn()))).Add(priority, description);
        }
    }
}