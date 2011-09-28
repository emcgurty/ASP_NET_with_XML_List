using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using System.Threading;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {

        if (!(Page.IsPostBack))   // Not postBack
        {

            //  Not super happy with this call. On load and reload of this page in
            //  debugging, I see duplicate rows.  Not certain regarding caching of List<T>
            //  Probably a web.config setting of which I am not aware
            Table_Values.DeleteRowValues();

            if (!(Table_Values.BuildList()))
            {
                if (GlobalClass.ErrorMessage.Length == 0)
                {
                    this.lblRowError.Text = "No rows in XML file.  Please add rows above.";
                }
                else
                {
                    GlobalClass.ErrorMessage = "Error in initializing values ";
                    Response.Redirect("ErrorMessage.aspx");
                }
            }
            else
            {
                DemoView.DataBind();
            }
        }
    }

    

    protected void Page_Load(object sender, EventArgs e)
    {

        int test_Master_NumberOfRows = 0;
        
        if (!(String.IsNullOrEmpty(Request.QueryString["function"])))
        {
            string strReq = Request.QueryString["function"];

            if (!(String.IsNullOrEmpty(strReq)))
            {
                if (strReq == "port")
                {
                    
                    this.lblRowError.Text = "Completed porting to XML.";
                    
                }
                else if (strReq == "AcceptRows")
                {
                    AcceptRowChanges();
                    this.lblRowError.Text = "Completed modifying to keep (checked) rows.  Click 'Port' to write to XML file."; 
                    
                }
                else if (strReq == "DeleteRows")
                {
                    DeleteSelectedRows();
                    this.lblRowError.Text = "Completed modifying to delete (checked) rows.";
                }

                else if (strReq == "ClearAll")
                {
                    if (!(Table_Values.DeleteRowValues()))
                    {
                        Response.Redirect("ErrorMessage.aspx");
                    }
                    else
                    {
                        this.lblRowError.Text = "FINISHED clearing rows.";
                    }
                }
                else if (strReq == "BuildRows")
                {

                    try
                    {
                        test_Master_NumberOfRows = Convert.ToInt16(this.txtNumberOfEntries.Text);
                        this.txtNumberOfEntries.Text = null;
                    }
                    catch
                    {
                        this.lblRowError.Text = "Please enter an integer row count greater than 0.";
                        return;
                    }

                    

                    if (test_Master_NumberOfRows < 1)
                    {
                        this.lblRowError.Text = "Please enter an integer row count greater than 0.";
                        return;

                    }
                    else if (test_Master_NumberOfRows > 21)
                    {
                        this.lblRowError.Text = "Please build rows in increments of 20, just for this demo purpose.";
                        return;

                    }
                   
                    else
                    {

                        if (!(Table_Values.InsertRows(test_Master_NumberOfRows)))
                        {

                            Response.Redirect("ErrorMessage.aspx");
                        }
                        else
                        {
                            this.lblRowError.Text = "Finished building " + test_Master_NumberOfRows + " rows.";
                        }
                    }
                }
                else { }

                DemoView.DataBind();  // emm 0225


            }
        }
    } // closes function  


    protected void AcceptRowChanges() // emm 0225 (object sender, EventArgs e)
    {


        CheckBox chk;
        int intRowNumber = 0;
        String strIdentifier = string.Empty;
        string strItem = string.Empty;
        string strDesc = string.Empty;
        double dblPrice = 0.00;
        string strStatus = string.Empty;


        foreach (GridViewRow gvr in DemoView.Rows)
        {
            chk = new CheckBox();
            chk = (CheckBox)gvr.FindControl("chkKeep");


            if (chk.Checked)
            {

                TextBox tCell = (TextBox)gvr.FindControl("lblIdentifier");
                strIdentifier = tCell.Text;

                Label tlCell = (Label)gvr.FindControl("lblRowID");
                intRowNumber = Convert.ToInt16(tlCell.Text);

                tCell = (TextBox)gvr.FindControl("lblItem");
                strItem = tCell.Text;

                tCell = (TextBox)gvr.FindControl("lblDescription");
                strDesc = tCell.Text;

                tCell = (TextBox)gvr.FindControl("lblPrice");
                dblPrice = Convert.ToDouble(tCell.Text);

                tCell = (TextBox)gvr.FindControl("lblStatus");
                strStatus = tCell.Text;


                if (Table_Values.CheckForDuplicates(strIdentifier, strItem, strDesc, dblPrice, chk.Checked))
                {
                    if (strStatus == "new")
                    {
                        if (!(Table_Values.UpdateRowValues(intRowNumber, strIdentifier, strItem, strDesc, dblPrice, "new", true)))
                            this.lblRowError.Text = "Please provide non-null values.";
                    }
                    else
                    {

                        if (!(Table_Values.UpdateRowValues(intRowNumber, strIdentifier, strItem, strDesc, dblPrice, "changed", false)))
                            this.lblRowError.Text = "Please provide non-null values.";

                    }
                }
            }
        }


    }


    protected bool DeleteSelectedRows()
    {

        bool results = false;
        CheckBox chk;
        String strIdentifier = string.Empty;


        foreach (GridViewRow gvr in DemoView.Rows)
        {
            chk = new CheckBox();
            chk = (CheckBox)gvr.FindControl("chkDelete");


            if (chk.Checked)
            {

                try
                {
                   // gvr.RowIndex should be parallel with GlobalClass.RowNumber
                    
                    results = Table_Values.DeleteSelectedRow(gvr.RowIndex);
                }
                catch (Exception ex)
                {
                    GlobalClass.ErrorMessage = "Error in Default.aspx.cs (DeleteSelectedRows(): Error Message:" + ex.Message;
                    results = false;

                }


            }
        }

 
        
        return results;
    }

    protected void txtNumberOfEntries_TextChanged(object sender, EventArgs e)
    {

        int CheckValue;
                
        try 
        {
            CheckValue = Convert.ToInt16(this.txtNumberOfEntries.Text.ToString());
        }
        catch
        {
            this.lblRowError.Text = "Please enter a positive integer value.";
            return;
        }

        if (CheckValue < 1)
        {
            this.lblRowError.Text = "Please enter a value greater than zero.";
            return;

        }
        
    }

    protected void btnSearch_click(object sender, EventArgs e)
    {
        //  This is just for demo purposes, obviously the search on price for example
        //  should contain a range, or values < or >
        //  Also I suppose I could implement something like a sql LIKE statements
        
        string strTxtSearch = this.txtSearch.Text;
        int intCmbSearch = this.cmbSearch.SelectedIndex;
        string myCol = string.Empty;


        if (intCmbSearch == 0)
            myCol = "col1";
        else if (intCmbSearch == 1)
            myCol = "col2";
        else if (intCmbSearch == 2)
            myCol = "col3";
        else {}

        //  Should ask if user wants to save changes: new, changes and deletes.

        GlobalClass.okRedirect = false;
        btnPort_click(null, null);

        //  Going to Tavle_Values becuase some other form may want to do a search
        if (Table_Values.SearchRows(myCol, strTxtSearch))
        {
            DemoView.DataBind();
            this.lblRowError.Text = "Search complete.";
        }
        else
        {
            Response.Redirect("ErrorMessage.aspx");
        }
     }


    protected void btnPort_click(object sender, EventArgs e)
    {
        
        // Wished I could ReaderWriterLockSlim here
        
        this.txtNumberOfEntries.Text = null;

        if (Table_Values.DemoList.Count < 1)
        {
            this.lblRowError.Text = "No data rows.";
            return;
        }
            
        foreach (Grid_Row_Values grv in Table_Values.DemoList)
        {
            if (grv.colItem == null || grv.colDescription == null || grv.colIdentifier == null  )
            {
                this.lblRowError.Text = "Can't submit incomplete data to the Item XML file.";
                return;
            }
        }
                 
        bool xmlDocChanged = false;
        int my_increment = 0;
        string myStatus = string.Empty;
        string App_Path = @ConfigurationManager.AppSettings["Data_Path"].ToString();
        App_Path = App_Path + "Items.xml";
        XmlNodeList cldnode;
        string[] arrayDelete;
        
     
            XmlDocument xmldoc = new XmlDocument();
            try
            {

                 GetXMLdoc apt = new GetXMLdoc();
                 xmldoc = apt.OpenAppXMLFile();
            }
            catch (Exception ex)
            {
                GlobalClass.ErrorMessage = "Error in btnPort_click: " + ex.Message;
                Response.Redirect("ErrorMessage.aspx");
            }

            
            XmlNode ele = xmldoc.DocumentElement;
            cldnode = ele.ChildNodes;
            arrayDelete = new string[cldnode.Count];
           
        
            for (my_increment = 0; my_increment < cldnode.Count; my_increment++)
            {
                arrayDelete[my_increment] = null;
            }

            my_increment = 0;
            foreach(Grid_Row_Values grv in Table_Values.DemoList)
            {
                       
               myStatus = grv.colStatus;

               if (myStatus == "changed")
               {
                  

                       xmlDocChanged = true;
                       // Have to create a new node first
                       XmlElement top = xmldoc.CreateElement("items");
                       XmlElement child0 = xmldoc.CreateElement("col0");
                       XmlElement chi1d1 = xmldoc.CreateElement("col1");
                       XmlElement child2 = xmldoc.CreateElement("col2");
                       XmlElement child3 = xmldoc.CreateElement("col3");
                       child0.InnerText = Convert.ToString(grv.colIdentifier);
                       chi1d1.InnerText = grv.colItem;
                       child2.InnerText = grv.colDescription;
                       child3.InnerText = Convert.ToString(grv.colPrice);
                       top.AppendChild(child0);
                       top.AppendChild(chi1d1);
                       top.AppendChild(child2);
                       top.AppendChild(child3);
                       ele.AppendChild(top);
                       ele.ReplaceChild(top, cldnode[my_increment]);
                       my_increment++;
                  

               }
            }   // end change foreach

               if (xmlDocChanged)
               {                  
                   xmldoc.Save(@App_Path);    // the childnode count hasn't changed
                   xmlDocChanged = false;
               }

             
                       
             
           my_increment = 0;
          // Delete from XML
          foreach(Grid_Row_Values grv in Table_Values.DemoList)
          {
              // Insert code to check for duplicates
              myStatus = grv.colStatus;

             if (myStatus == "deleted")
              {
                // Build "innerText" from grv
                arrayDelete[my_increment++] = grv.colIdentifier+grv.colItem+grv.colDescription+grv.colPrice;
             }
              
          } 
            my_increment = 0;
            
            // Check the array first becuase it is likely to have fewer elemtns 
            // then Childnodes
            for (int ii = 0; ii < arrayDelete.Length; ii++)
            {
                if (arrayDelete[ii] != null)
                {
                    foreach (XmlNode xn in xmldoc.DocumentElement.ChildNodes)
                    {

                        if (xn.InnerText == arrayDelete[ii])
                        {
                            xmldoc.DocumentElement.RemoveChild(xn);
                            xmlDocChanged = true;
                        }
                    }
                }

            }

             
           // Save to XML
          if (xmlDocChanged)
          {
              xmldoc.Save(@App_Path);    // the childnode count HAS changed
              xmlDocChanged = false;
          }


          foreach (Grid_Row_Values grv in Table_Values.DemoList)
          {
              // Insert code to check for duplicates
              myStatus = grv.colStatus;

              if (myStatus == "new")
              {
      
                  xmlDocChanged = true;
                  XmlElement top = xmldoc.CreateElement("items");
                  XmlElement child0 = xmldoc.CreateElement("col0");
                  XmlElement chi1d1 = xmldoc.CreateElement("col1");
                  XmlElement child2 = xmldoc.CreateElement("col2");
                  XmlElement child3 = xmldoc.CreateElement("col3");
                  child0.InnerText = grv.colIdentifier;
                  chi1d1.InnerText = grv.colItem;
                  child2.InnerText = grv.colDescription;
                  child3.InnerText = Convert.ToString(grv.colPrice);
                  top.AppendChild(child0);
                  top.AppendChild(chi1d1);
                  top.AppendChild(child2);
                  top.AppendChild(child3);
                  ele.AppendChild(top);
              }
          }   // end new foreach
          if (xmlDocChanged)
          {
              xmldoc.Save(@App_Path);
          }
          
          
          this.lblRowError.Text = "Finished porting";
          if (GlobalClass.okRedirect)
          {
              
              Table_Values.DeleteRowValues();  // To clear the existing values and reflect updates
              Response.Redirect("Default.aspx?function=port");  // To refresh the GridView, not super happy with this
              GlobalClass.okRedirect = true;
          }


       // }  //if file exists
        return;
    }

    protected void btnReload_click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  // Not super happy with this..
        
    }
    

}  // Close class _default    


          
        
    

   
