using System;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;



public class Table_Values
{
  
     
 public Table_Values()
    { }
       
   
    private static List<Grid_Row_Values> Demo_row = new List<Grid_Row_Values>();
    
    public static List<Grid_Row_Values> DemoList
    {

        get { return Demo_row; }

        set { Demo_row = value; }

    }



    public static bool  DeleteRowValues()       /// Should be called add new row
    {
      
        try
        {
            Demo_row.Clear();
            return true;
        }
        catch(Exception e)
        {
            GlobalClass.ErrorMessage = "Error in Table_Values.cs (DeleteRowValues(): Error Message:" + e.Message; 
            return false;
        }

       
    }

      
    public static bool DeleteSelectedRow(int colrowID)
    {  
       
        try
        {
            //Demo_row.RemoveAt(colrowID);
            Demo_row[colrowID].colStatus = "deleted";
            //    Convert.ToDouble(String.Format("{0:#.#####}", colPrice));
             return true;

        }
        catch (FormatException fe)
        {
            GlobalClass.ErrorMessage = fe.Message + fe.Source;
            return false;
        }

    }

    public List<Grid_Row_Values> GetRowValues()       /// Should be called add new row
    {
        return Demo_row;
    }

    public static bool InsertRows(int NumberOfRows)       
    {
  
        int intRowCounter = NumberOfRows;
        while (intRowCounter >  0)
        {
            try
            {

                Demo_row.Insert(0, new Grid_Row_Values(GlobalClass.Master_NumberOfRows++, null, null, null, Convert.ToDouble("0.00"), "new"));
                
            }
            catch (Exception e)
            {
                GlobalClass.ErrorMessage = "Error in Table_Values.cs (InsertRows(int): Error Message:" + e.Message; 
                return false;
            }
            intRowCounter--;
        }
        return true;
    }

    public static bool InsertXMLRowsIntoList(int myInt, string mystr1, string mystr2, string mystr3, double mydbl)
    {
       
        {
            try
            {
               Demo_row.Add(new Grid_Row_Values(myInt, mystr1, mystr2, mystr3, mydbl, null));
            }
            catch (Exception e)
            {
                GlobalClass.ErrorMessage = "Error in Table_Values.cs (InsertRows(int): Error Message:" + e.Message;
                return false;
            }
        }
      
        return true;
    }

    public static bool SearchRows(string strCol, string strCriteria)
    {
        /// Table_Values.SearchRows(myCol, strTxtSearch);
        // 0 = Item col1
        // 1 = Description col2
        // 2 = price  col3
        Demo_row.Clear();
        GlobalClass.Master_NumberOfRows = 0;
             

            XmlDocument xmldoc = new XmlDocument();
            try 
            {
                GetXMLdoc apt = new GetXMLdoc();
                xmldoc = apt.OpenAppXMLFile();
            }
            catch (Exception ex)
            {
                GlobalClass.ErrorMessage = "Error in SearchRows in calling GetXMLdoc: " + ex.Message;
            }


           
            XmlNode ele = xmldoc.DocumentElement;
            XmlNodeList cldnode = ele.ChildNodes;

            foreach (XmlNode xn in cldnode)
            {
              // For demo purposes we're just doing any exact match.  
              // In the future we could use Reg Expressions
                
                if (xn[strCol].InnerText == strCriteria)
                {

                    try
                    {
                        Demo_row.Add(new Grid_Row_Values
                            (GlobalClass.Master_NumberOfRows++, xn["col0"].InnerText, xn["col1"].InnerText, xn["col2"].InnerText, Convert.ToDouble(xn["col3"].InnerText), null));
                    }
                    catch (Exception e)
                    {
                        GlobalClass.ErrorMessage = "Error in Table_Values.cs (SearchRows(str,str): Error Message:" + e.Message;
                        return false;
                    }
                }

            }
        
    return true;
    }

    public static int GetRowCount()
    {
        return Demo_row.Count;
        
    }
        

    public static bool BuildList()
    {
        GlobalClass.Master_NumberOfRows = 0;    // Probably not necessary
        int i = 0;
        int j = 0;
        string cellName = "";
                
        XmlDocument xmldoc = new XmlDocument();

        try
        {

            GetXMLdoc apt = new GetXMLdoc();
            xmldoc = apt.OpenAppXMLFile();
        }
        catch (Exception ex)
        {
            GlobalClass.ErrorMessage = "Error in BuildList in calling GetXMLdoc: " + ex.Message;
        }

        if (xmldoc.DocumentElement != null)
        {
            XmlElement element = xmldoc.DocumentElement;
            XmlNodeList lstcols = element.ChildNodes;
            cellName = string.Empty;

            if (lstcols.Count == 0)
            {
                GlobalClass.ErrorMessage = string.Empty;
                return false;
            }


            for (i = 0; i < lstcols.Count; i++)
            {

                cellName = "col" + (j + 1);

                try
                {
                    InsertXMLRowsIntoList(GlobalClass.Master_NumberOfRows++,
                        Convert.ToString(lstcols[i]["col0"].InnerText),
                        Convert.ToString(lstcols[i]["col1"].InnerText),
                        Convert.ToString(lstcols[i]["col2"].InnerText),
                        Convert.ToDouble(lstcols[i]["col3"].InnerText));
                }

                catch (Exception ex)
                {

                    GlobalClass.ErrorMessage = ex.Message + ex.Source;
                    return false;

                }

            }
        }  
        
        //GlobalClass.GetXMLDoc = null;       
         
        return true;
    }

    public static bool UpdateRowValues( int colrowID, string strIdentifier, string colItem, string colDescription, double colPrice, string strStatus, bool IsNew) 
    {
       
            
           if ((strIdentifier == null) || (colItem == null) || (colDescription == null) || (colPrice == 0))
                return false;
           try
            {
                Demo_row[colrowID].colIdentifier = strIdentifier;
                Demo_row[colrowID].colItem = colItem;
                Demo_row[colrowID].colDescription = colDescription;
                Demo_row[colrowID].colPrice = Convert.ToDouble(String.Format("{0:#.#####}", colPrice));
                Demo_row[colrowID].colStatus = strStatus;
                return true;
            }
            catch (FormatException fe)
            {
                GlobalClass.ErrorMessage = fe.Message + fe.Source;
                return false;
            }


        }
       
      
    public static bool CheckForDuplicates(string strIdentifier, string colItem, string colDescription, double colPrice, bool IsNew)
    {

        if (IsNew)
        {
            ////  Check the xml file.  Great opportunity for threading
       
        }
        else
        {
            //// check LIST<>
        }

            return true;
    }

      
}








    
    
    
    
    