using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Service;
using ACTReorderList.Infra.Data.ADONet;
using ACTReorderList.Infra.Data.ADONet.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace ACTReorderList.UI.WebForms
{
    public partial class UsingObjectDataSource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        // TODO: Use Dependency Resolution
        
        protected void ObjectDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = new TaskService(new TaskRepository(new Conn()));
        }
        
        /*
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Task> ObjectDataSource_SelectMethod()
        {
            return (new TaskService(new TaskRepository(new Conn()))).GetAllOrderByPriority();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int ObjectDataSource_UpdateMethod(int id, int priority, string description)
        {
            return (new TaskService(new TaskRepository(new Conn()))).UpdatePriority(id, priority, description);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void ObjectDataSource_InsertMethod(int priority, string description)
        {
            (new TaskService(new TaskRepository(new Conn()))).Add(priority, description);
        }*/
    }
}