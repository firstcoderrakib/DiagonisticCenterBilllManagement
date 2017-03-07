﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagonisticCenterBilllManagement.BLL;
using DiagonisticCenterBilllManagement.Model;

namespace DiagonisticCenterBilllManagement.UI
{
    public partial class Test : System.Web.UI.Page
    {
        TestTypeManager typeManager = new TestTypeManager();
        TestManager testManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowType();
            }
            ShowTest();
        }



        protected void btnTestSave_Click(object sender, EventArgs e)
        {

           
            decimal Number;
            bool IsExistsNumber = decimal.TryParse(txtTestFee.Text, out Number);
           
            if (IsExistsNumber)
            {
                if (Number >= 0)
                {
                   
                    
                    try
                    {
                        Label1.Visible = false;
                        lblNumberMsg.Visible = false;
                        decimal testFee = Number;
                        string name = txtTestName.Text;
                        int typeId = Convert.ToInt32(ddlTestType.SelectedItem.Value);

                        Tests test = new Tests(name, testFee, typeId);
                        int rowAffected = testManager.AddTest(test);

                        if (rowAffected > 0)
                        {
                            ShowTest();

                        }

                    }
                    catch (Exception exception)
                    {
                        Label1.Visible = true;
                        Label1.Text = exception.Message;
                        Label1.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {
                    lblNumberMsg.Text = "Number must be greater than or equal 0";
                    lblNumberMsg.ForeColor = System.Drawing.Color.Red;
                }
            }


            Clear();
        }

        public void ShowTest()
        {
            GridViewTest.DataSource = testManager.GetAllTestWithType().OrderBy(x => x.Test);

            GridViewTest.DataBind();
        }
        public void ShowType()
        {
            List<Types> type = typeManager.GetAllTestType().ToList();

            ddlTestType.DataTextField = "typeName";
            ddlTestType.DataValueField = "ID";
            ddlTestType.DataSource = type;
            ddlTestType.DataBind();

            ddlTestType.Items.Insert(0, "Select One");



        }

        private void Clear()
        {
            txtTestFee.Text = string.Empty;
            txtTestName.Text = string.Empty;
            ddlTestType.SelectedIndex = 0;
        }




    }
}