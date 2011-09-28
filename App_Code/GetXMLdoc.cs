using System;
using System.Threading;
using System.Xml;
using System.Configuration;
using System.IO;


public class GetXMLdoc
{

    private static XmlDocument xmldoc;

    public GetXMLdoc()
    {
       
    }

    public  XmlDocument OpenAppXMLFile()
    {
        string App_Path = @ConfigurationManager.AppSettings["Data_Path"].ToString();
        App_Path = App_Path + "Items.xml";

        if (File.Exists(@App_Path))
        {
            try
            {
                xmldoc = new XmlDocument();
                xmldoc.Load(@App_Path);
            }
            catch (Exception ex)
            {
                ///  Do not currently understand how to terminate the ThreadStart in the event of a failure
                GlobalClass.ErrorMessage = "Error in AppThreads(OpenAppFile): " + ex.Message;

            }

        }
        else
        {
            xmldoc = new XmlDocument();
            XmlNode iheader = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmldoc.AppendChild(iheader);
            XmlElement root = xmldoc.CreateElement("dataroot");
            xmldoc.InsertAfter(root, iheader);
            xmldoc.Save(@App_Path);

        }
        
         return  xmldoc;
    }

    
}