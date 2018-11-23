using System;
using System.Drawing;
using System.Web.Security;

namespace PapaBobs.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logon_Click(object sender, EventArgs e)
        {
            // Validate the user against the Membership framework user store
            if (Membership.ValidateUser(UserEmail.Text, UserPass.Text))
            {
                // Log the user into the site
                FormsAuthentication.RedirectFromLoginPage(UserEmail.Text, true);
            }
            // If we reach here, the user's credentials were invalid
            Msg.Text = "Invalid Credentials";
        }
    }
}