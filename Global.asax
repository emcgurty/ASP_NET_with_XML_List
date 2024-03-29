<%@ Application Language="C#" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Web.SessionState" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        ////get reference to the source of the exception chain
        Exception ex = Server.GetLastError().GetBaseException();

        GlobalClass.ErrorMessage = "An unhandled exception has occured: " +
                                "MESSAGE: " + ex.Message +
                                 "\nSOURCE: " + ex.Source +
                                 "\nFORM: " + Request.Form.ToString() +
                                "\nQUERYSTRING: " + Request.QueryString.ToString() +
                                "\nTARGETSITE: " + ex.TargetSite;
       // Response.Redirect("ErrorMessage.aspx");
                                 
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
