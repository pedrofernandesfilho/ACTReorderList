using ACTReorderList.Core.Domain.Service;
using ACTReorderList.Infra.Data.ADONet;
using ACTReorderList.Infra.Data.ADONet.Repository;
using System;
using System.Web.UI.WebControls;

namespace ACTReorderList.UI.WebForms
{
    public partial class UsingObjectDataSource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void ObjectDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            // TODO: Use Dependency Resolution
            e.ObjectInstance = new ServiceTask(new TaskRepository(new Conn()));
        }
    }
}