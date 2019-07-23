using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using BussinessLayer;
using BussinessLayer.Models;
using BussinessLayer.Interfaces;
using BussinessLayer.Repositories;
using System.Data;

namespace StudentManagementSystemWithLayers
{
    public partial class Teachers : System.Web.UI.Page
    {
        ITeacherRepository teacherRepository = new TeacherRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
            else
            {

            }

        }

        protected void bindGrid()
        {
            ListToTable lsttodt = new ListToTable();
            var lst = teacherRepository.GetTeacherList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridViewTeacher.DataSource = dt;
                GridViewTeacher.DataBind();
            }
            else
            {
                GridViewTeacher.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TeacherModels mdl = new TeacherModels();
            mdl.TeacherName = txtTeacherName.Text.Trim();
            mdl.Qualification = txtQualification.Text.Trim();
            if (txtId.Text != "")
                mdl.Id = Convert.ToInt32(txtId.Text);
            bool result = teacherRepository.InsertUpdateTeacher(mdl);
            if (result)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
            }
            bindGrid();
        }

        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Teachers.aspx");
        }
        void Clear()
        {
            txtTeacherName.Text = txtQualification.Text = "";
        }
        void DataGvProperties()
        {

        }

        protected void GridViewTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridViewTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.GridViewTeacher.DataKeys[rowIndex]["Id"].ToString();

            if (e.CommandName == "updates")
            {
                ListToTable lsttodt = new ListToTable();
                var lst = teacherRepository.GetTeacherListByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtId.Text = dt.Rows[0]["Id"].ToString();
                    txtTeacherName.Text = dt.Rows[0]["TeacherName"].ToString();
                    txtQualification.Text = dt.Rows[0]["Qualification"].ToString();

                    btnSave.Text = "Update";
                }
                else
                {
                    //do nothing
                    btnSave.Text = "Save";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                bool result = teacherRepository.DeletesTeacher(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
    }
}
