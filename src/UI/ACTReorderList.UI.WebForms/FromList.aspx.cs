using ACTReorderList.Core.Domain.Model;
using ACTReorderList.Core.Domain.Service;
using System;
using System.Collections.Generic;

namespace ACTReorderList.UI.WebForms
{
    public partial class FromList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillReorderList((new ServiceTask()).Get());
        }

        #region Private Methods
        private void FillReorderList(IList<Task> source)
        {
            ReorderList.DataSource = source;
            ReorderList.DataBind();
        }
        #endregion
    }
}