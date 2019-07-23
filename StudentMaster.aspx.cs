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
    public partial class StudentMaster : System.Web.UI.Page
    {
        IStudentRepository studentRepository = new StudentRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                bindGrid();
                bindTeacherList();
                bindCourseList();

            }
            else
            {

            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StudentModels mdl = new StudentModels();
            mdl.StdName = txtStdName.Text.Trim();
            mdl.FatherName = txtFather.Text.Trim();
            mdl.Mobile = txtMobile.Text.Trim();
            mdl.Address = txtAddress.Text.Trim();
            mdl.Email = txtEmail.Text.Trim();
            mdl.Gender = DropDownList1.SelectedValue;
            mdl.CourseId = Convert.ToInt32(ddCourse.SelectedValue);
            mdl.TeacherId = Convert.ToInt32(ddTeacher.SelectedValue);
            if (txtId.Text != "")
                mdl.Id = Convert.ToInt32(txtId.Text);
            bool result = studentRepository.InsertUpdateStudent(mdl);
            if (result)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
            }
            bindGrid();
        }

        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentMaster.aspx");
        }
       
        void Clear()
        {
            txtStdName.Text = txtAddress.Text = txtFather.Text = txtEmail.Text = txtMobile.Text = " ";
            BtnDelete.Enabled = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void bindGrid()
        {
            ListToTable lsttodt = new ListToTable();
            var lst = studentRepository.GetStudentList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.GridView1.DataKeys[rowIndex]["Id"].ToString();

            if (e.CommandName == "updates")
            {
                ListToTable lsttodt = new ListToTable();
                var lst = studentRepository.GetStudentListByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtId.Text = dt.Rows[0]["Id"].ToString();
                    txtStdName.Text = dt.Rows[0]["StdName"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtFather.Text = dt.Rows[0]["FatherName"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                    ddCourse.SelectedValue = dt.Rows[0]["CourseId"].ToString();
                    ddTeacher.SelectedValue = dt.Rows[0]["TeacherId"].ToString();
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
                bool result = studentRepository.DeletesStudent(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindCourseList()
        {
            ListToTable lsttodt = new ListToTable();
            ICourseRepository courseRepository = new CourseRepository();
            var lst = courseRepository.GetCourseList().Select(x => new { x.CourseName, x.Id }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddCourse.DataSource = dt;
                ddCourse.DataTextField = "CourseName";
                ddCourse.DataValueField = "Id";
                ddCourse.DataBind();

            }
            else
            {
                ddCourse.DataBind();
            }
        }
        protected void bindTeacherList()
        {
            ListToTable lsttodt = new ListToTable();
            ITeacherRepository courseRepository = new TeacherRepository();
            var lst = courseRepository.GetTeacherList().Select(x => new { x.TeacherName, x.Id }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                ddTeacher.DataSource = dt;
                ddTeacher.DataTextField = "TeacherName";
                ddTeacher.DataValueField = "Id";
                ddTeacher.DataBind();

            }
            else
            {
                ddTeacher.DataBind();
            }
        }
    }
}