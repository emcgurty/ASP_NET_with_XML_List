using System.Configuration;
using System.Xml;
using System.IO;



public class GlobalClass
{
    private static int m_NumOfRows = 0;
    private static string m_ErrorMessage = string.Empty;
    private static bool m_boolredirect = false;

      
    public static int Master_NumberOfRows
    {
        get { return m_NumOfRows; }
        set { m_NumOfRows = value; }
    }

   
    public static string ErrorMessage
    {
        get { return m_ErrorMessage; }
        set { m_ErrorMessage = value; }
    }

    public static bool okRedirect
    {
        get { return m_boolredirect; }
        set { m_boolredirect = value; }
    }

  
  
}


