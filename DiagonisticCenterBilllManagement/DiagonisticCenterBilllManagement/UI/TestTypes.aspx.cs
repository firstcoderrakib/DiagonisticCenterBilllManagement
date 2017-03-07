using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagonisticCenterBilllManagement.BLL;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.UI
{
    public partial class TestTypes : System.Web.UI.Page
    {
        TestTypeManager typeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAllType();
            }



        }

        protected void btnTypeSave_Click(object sender, EventArgs e)
        {
            string name = txtTypeName.Text;

            Types type = new Types(name);
            try
            {
                Label1.Visible = false;
                int rowAffected = typeManager.AddType(type);

                if (rowAffected > 0)
                {
                  
                    ShowAllType();
                }


            }
            catch (Exception exception)
            {
                Label1.Visible = true;
                Label1.Text = exception.Message;

            }
            Clear();
        }

        private void Clear()
        {
            txtTypeName.Text = string.Empty;
        }
        private void ShowAllType()
        {
            List<Types> typeList = typeManager.GetAllTestType();
            testTypeGridView.DataSource = typeList;
            testTypeGridView.DataBind();
        }
    }
}