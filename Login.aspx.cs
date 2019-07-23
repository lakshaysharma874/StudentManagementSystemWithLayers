using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer.Interfaces;
using BussinessLayer.Models;
using BussinessLayer.Repositories;
using DataLayer;

namespace StudentManagementSystemWithLayers
{
    public partial class Login : System.Web.UI.Page
    {
        IUserRepository userRepository = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserModels mdl = new UserModels();
            Response.Cookies["UserName"].Value = txtName.Text.Trim();
            Response.Cookies["Password"].Value = txtPassword.Text.Trim();
            mdl.UserName = txtName.Text.Trim();
            mdl.Password = txtPassword.Text.Trim();
            bool msg = userRepository.LoginUser(mdl);
            if (msg)
            {

                Response.Redirect("Course.aspx");
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Username and Password is invalid.";
            }
        }
    }
}