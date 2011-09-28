using System;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!(IsPostBack))
        {
           
          
        }

    }

    public Label Title_Label
    {
        get
        {
            return lblTitle;
        }

        set
        { lblTitle = value; }

    }





  
   
}

