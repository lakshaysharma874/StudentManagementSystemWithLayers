using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using BussinessLayer;
using BussinessLayer.Repositories;
using BussinessLayer.Interfaces;
using System.Data;
using BussinessLayer.Models;

namespace StudentManagementSystemWithLayers
{
    public partial class Course : System.Web.UI.Page
    {
        ICourseRepository courseRepository = new CourseRepository();//Creating the instace of repository class
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
        protected void bindGrid()//method for binding gridview
        {
            ListToTable lsttodt = new ListToTable();
            var lst = courseRepository.GetCourseList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridViewCourse.DataSource = dt;
                GridViewCourse.DataBind();
            }
            else
            {
                GridViewCourse.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //This method for saving and updating data
            CourseModels mdl = new CourseModels();
            mdl.CourseName = txtCourseName.Text.Trim();
            mdl.CourseFees = Convert.ToDecimal(txtFees.Text.Trim());
            mdl.CourseDuration = txtTime.Text.Trim();
            if (txtCourseId.Text != "")
                mdl.Id =Convert.ToInt32(txtCourseId.Text);
            bool result = courseRepository.InsertUpdateCourse(mdl);
            if (result)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
            }
            bindGrid();
        }

       
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Course.aspx");
        }
        void Clear()
        {
            txtCourseName.Text = txtFees.Text = txtTime.Text = "";
            BtnReset.Enabled = false;
        }
        
        protected void GridViewCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridViewCourse_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string courseid = this.GridViewCourse.DataKeys[rowIndex]["Id"].ToString();

            if (e.CommandName == "updates")
            {
                ListToTable lsttodt = new ListToTable();
                var lst = courseRepository.GetCourseListByID(Convert.ToInt32(courseid));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtCourseId.Text = dt.Rows[0]["Id"].ToString();
                    txtCourseName.Text = dt.Rows[0]["CourseName"].ToString();
                    txtFees.Text = dt.Rows[0]["CourseFees"].ToString();
                    txtTime.Text = dt.Rows[0]["CourseDuration"].ToString();
                    
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
                bool result = courseRepository.DeletesCourse(Convert.ToInt32(courseid));
                if (result)
                {
                    bindGrid();

                }
            }
        }
    }
}