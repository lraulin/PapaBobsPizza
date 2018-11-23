using System;
using System.Web.Security;

namespace PapaBobs.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipCreateStatus createStatus;
                MembershipUser newUser = System.Web.Security.Membership.CreateUser(Email.Text, Password.Text, Email.Text, "whodo", "youdo", true, out createStatus);
                
            }
            catch (Exception ex)
            {
                CreateAccountResults.Text = ex.Message;
            }
        }
    }
}