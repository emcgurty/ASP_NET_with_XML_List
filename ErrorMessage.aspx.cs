using System;

public partial class ErrorMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblErrorMessage.Text = GlobalClass.ErrorMessage;
    }
}
