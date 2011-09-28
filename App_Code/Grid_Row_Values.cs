using System;

public class Grid_Row_Values
{
    private int col_ID = 0;
    private string col_identifier = string.Empty;
    private string col_Item = string.Empty;
    private string col_Description = string.Empty;
    private double col_Price = 0.00;
    private string col_Status = string.Empty;


    public Grid_Row_Values(int intID, string strIdentifier,string strItem, string strDescription, double dbPrice, string strStatus)
    {
        this.colrowID = intID;
        this.colIdentifier = strIdentifier;
        this.colItem = strItem;
        this.colDescription = strDescription;
        this.colPrice = dbPrice;
        this.colStatus = strStatus;
        
    }


    public int colrowID
    {
        get
        {
            return col_ID;
        }
        set
        {
            col_ID = value;
        }
    }

    public string colIdentifier
    {
        get
        {
            return col_identifier;
        }
        set
        {
            col_identifier = value;
        }
    }
    
     
    
    public string colItem
    {
        get
        {
            return col_Item;
        }
        set
        {
            col_Item = value;
        }
    }


    public string colDescription
    {
        get
        {
            return col_Description;
        }
        set
        {
            col_Description = value;
        }
    }

    public double colPrice
    {
        get
        {
            return col_Price;
        }
        set
        {
            col_Price = value;
        }
    }

    public string colStatus   //new, changed, deletd or null
    {
        get
        {
            return col_Status;
        }
        set
        {
            col_Status = value;
        }
    }

}





