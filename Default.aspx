<%@ Page Language="C#" 
     MasterPageFile="~/MasterPage.master" 
     viewStateEncryptionMode =Never
     AutoEventWireup="true" CodeFile="Default.aspx.cs" 
     Inherits="_Default" Title="Demo of List to XML" 
     EnableEventValidation=false

     %>
  
<%@ MasterType VirtualPath="~/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="localForm" name="frmDemoMean" method="post"  action=""
    enctype="multipart/form-data">

     <div id="divManual" runat="server" style="display:inline">
        
    <table >
        <tr>
            <td width=2%></td>
            <td width=15%></td>
            <td style="width: 42%"></td>
            <td style="width: 12%"></td>
            <td width=25%></td>
            <td width=5%></td>
        </tr>
<tr bgcolor="#ffcc33">
            <td width=2%></td>
            <td width=15%>Manual entry:</td>
            <td style="width: 42%">Enter the number of sample rows (max 20):
           <asp:textbox runat="server" 
                        id="txtNumberOfEntries" 
                        Text="0" AutoPostBack="true" 
                        OnTextChanged="txtNumberOfEntries_TextChanged" 
                        style="vertical-align: middle; text-align: center; color: blue; 
               font-family: Calibri, Arial;" Width="24px" 
                     />
          
           
           </td>
           <td style="width: 12%"><asp:LinkButton ID="linkBuildRows" runat="server" 
               CausesValidation="False" Height="16px"
               PostBackUrl="~/Default.aspx?function=BuildRows" 
               style="vertical-align: bottom; text-align: left">Build Rows
               </asp:LinkButton></td>
           <td width=25%><asp:LinkButton ID="lnkClearAll" 
                           runat="server" 
                           CausesValidation="False" Height="16px"
                           PostBackUrl="~/Default.aspx?function=ClearAll" >Clear All Rows</asp:LinkButton></td>
<td width=5%></td>
       </tr>
       </table>
     
</div>

    <table >
        <tr>
            <td width="2%">&nbsp;</td>
            <td style="width: 16%">&nbsp;</td>
            <td style="width: 27%">&nbsp;</td>
            <td width="25%">&nbsp;</td>
            <td width="30%">&nbsp;</td>
        </tr>
      <tr bgcolor="#ffcc33">
      <td width="2%">&nbsp;</td>
      <td style="width: 16%">Search: </td>
      <td style="width: 27%"><asp:DropDownList ID="cmbSearch" runat="server" 
              style="margin-left: 0px" > 
                <asp:ListItem Selected="True">Item</asp:ListItem>
                <asp:ListItem>Description</asp:ListItem>
                <asp:ListItem >Price</asp:ListItem>
                </asp:DropDownList></td>
      <td width="25%">Value:&nbsp;<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
      <td width="25%"><asp:Button OnClick="btnSearch_click" Text="Search" runat="server"/></td> 
      <td width=5%></td>
      </tr>
        <tr>
            <td width="2%">&nbsp;</td>
            <td style="width: 16%">&nbsp;</td>
            <td style="width: 27%">&nbsp;</td>
            <td width="25%">&nbsp;</td>
            <td width="25%">&nbsp;</td>
            <td width=5%></td>
        </tr>
      <tr bgcolor="#ffcc33">         
            <td width="2%">&nbsp;</td>
            <td style="width: 16%">Port all to XML:</td>
            <td style="width: 27%"><asp:Button ID="btnPort" OnClick="btnPort_click" Text="Port" runat="server"/></td> 
            <td width="25%">Reload XML Rows:</td>
            <td width="25%"><asp:Button ID="btnReload" OnClick="btnReload_click" Text="Reload" 
                    runat="server"/></td>
            <td width="25%">&nbsp;</td>
            <td width=5%></td>
        </tr>
        <tr >
            <td width="2%">&nbsp;</td>
            <td style="width: 16%">&nbsp;</td>
            <td style="width: 27%">&nbsp;</td>
            <td width="25%">&nbsp;</td>
            <td width="25%">&nbsp;</td>
            <td width=5%></td>
        </tr>
      </table>

      
     
        <table >
        <tr >
            <td width="2%">&nbsp;</td>
            <td colspan="3"><asp:Label ID="lblRowError" runat="server" Text="Application Loaded" ></asp:Label></td>
            <td width="25%">&nbsp;</td>
            <td width=5%></td>
        </tr>
        </table>


  <asp:GridView ID="DemoView" 
         runat="server" 
         DataSourceID="DemoViewDataSource"
         DataKeyNames="colrowID"
         AutoGeneratecolumns="False" 
         Height="61px" Font-Names="Calibri,Arial" 
         Font-Size="Small" 
         GridLines="None"
         AlternatingRowStyle-BackColor="Bisque" 
         BorderColor="AliceBlue"
         BorderStyle="Solid" 
         BorderWidth="1px" 
         
         >
         
        <columns>
                    
           
           <asp:TemplateField HeaderText="Row Number" >
              <ItemTemplate>
                    <asp:Label ID="lblRowID" runat="server" Text='<%# Bind("colrowID") %>' Backcolor="LightYellow">
                    </asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" Backcolor="LightYellow"/>
                <ControlStyle Width="65px"  Backcolor="LightYellow" />
                <FooterStyle Width="65px"/>
           </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Identifier">
              <ItemTemplate>
                    <asp:TextBox ID="lblIdentifier" runat="server" Text='<%# Bind("colIdentifier") %>'
                    BackColor="Transparent" BorderColor="AliceBlue">
                    </asp:TextBox>
                </ItemTemplate>
             <EditItemTemplate>
                    <asp:TextBox ID="txtlIdentifier" runat="server" Text='<%# Bind("colIdentifier") %>'
                    BackColor="Transparent" BorderColor="AliceBlue" >
                    </asp:TextBox>
                </EditItemTemplate>
               
                     


             
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                <ControlStyle Width="100px" />
           </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="Item" SortExpression="colItem">
               
                <ItemTemplate>
                    <asp:TextBox ID="lblItem" runat="server" Text='<%# Bind("colItem") %>' 
                    BackColor="Transparent" BorderColor="AliceBlue">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" />
                
                             
                <ControlStyle Width="65px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Description" SortExpression="colDescription">
                <ItemTemplate>
                    <asp:TextBox ID="lblDescription" runat="server" Text='<%# Bind("colDescription") %>'
                    BackColor="Transparent" BorderColor="AliceBlue">
                    </asp:TextBox>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" />
                
      
                <ControlStyle Width="65px" />
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="Price" SortExpression="colPrice">
                <ItemTemplate>
                    <asp:TextBox ID="lblPrice" runat="server" Text='<%# Bind("colPrice") %>'
                    BackColor="Transparent" BorderColor="AliceBlue">
                    </asp:TextBox>
                </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" />
                
                <ControlStyle Width="65px" />
            </asp:TemplateField>

               <asp:TemplateField HeaderText="Status" SortExpression="colStatus">
                <ItemTemplate>
                    <asp:TextBox ID="lblStatus" runat="server" Text='<%# Bind("colStatus") %>'
                    BackColor="Transparent" BorderColor="AliceBlue">
                    </asp:TextBox>
                </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" />
                
                <ControlStyle Width="65px" />
            </asp:TemplateField>
           
           
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkKeep" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKeep" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                <asp:Button ID="btnKeepChanges" 
                            runat="server" 
                            Text="Keep Record" 
                            style="font-size: 1em; vertical-align: middle; color: blue; font-family: Calibri, Arial; text-align: center" 
                            Width="99px" 
                            PostBackUrl="~/Default.aspx?function=AcceptRows"
                            />
                </HeaderTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            
            </asp:TemplateField>
              <asp:TemplateField>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkDelete" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkDelete" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                <asp:Button ID="btnDeleteChanges" 
                            runat="server" 
                            Text="Delete Record" 
                            style="font-size: 1em; vertical-align: middle; color: blue; font-family: Calibri, Arial; text-align: center" 
                            Width="99px" 
                            PostBackUrl="~/Default.aspx?function=DeleteRows"
                            />
                </HeaderTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>      
            
        </columns>
      <AlternatingRowStyle BackColor="Bisque" />
    </asp:GridView>
    
    <asp:ObjectDataSource ID="DemoViewDataSource" 
        runat="server" 
        UpdateMethod="UpdateCurrentRow"
        SelectMethod="GetRowValues"
       
        TypeName="Table_Values" >
        <UpdateParameters>
             <asp:Parameter Name="colrowID" Type="Int32" />
             <asp:Parameter Name="colIdentifier" Type="String" />
             <asp:Parameter Name="colItem" Type="String" />
             <asp:Parameter Name="colDescription" Type="String" />
             <asp:Parameter Name="colPrice" Type="Double" />
              <asp:Parameter Name="colStatus" Type="String" />
        </UpdateParameters>
        </asp:ObjectDataSource>

     <br />
     <br />
 
</form>
</asp:Content>


