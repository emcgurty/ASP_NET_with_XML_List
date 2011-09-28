<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ErrorMessage.aspx.cs" Inherits="ErrorMessage" Title="Error Message" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table >
        <tr>
            <td style="width: 2%">
            </td>
            <td style="width: 80%">
            </td>
            <td style="width: 18%">
            </td>
        </tr>
        <tr>
            <td style="width: 2%">
            </td>
            <td style="width: 80%; color: black; font-family: Calibri, Arial; text-align: left">
                The following error has occurred within this Application:</td>
            <td style="width: 18%">
            </td>
        </tr>
        <tr>
            <td style="width: 2%">
            </td>
            <td style="width: 80%">
            </td>
            <td style="width: 18%">
            </td>
        </tr>
        <tr>
            <td style="width: 2%">
            </td>
            <td style="width: 80%">
                <asp:TextBox ID="lblErrorMessage" TextMode="MultiLine" runat="server" ReadOnly="true" 
                style="font-size: 1em; vertical-align: middle; color: blue; font-family: Calibri, Arial; text-align: left">
                </asp:TextBox></td>
            <td style="width: 18%">
            </td>
        </tr>
        <tr>
            <td style="width: 2%">
            </td>
            <td style="width: 80%">
            </td>
            <td style="width: 18%">
            </td>
        </tr>
        <tr>
            <td style="width: 2%">
            </td>
            <td style="width: 80%; text-align: left">
                Sorry for the inconvenience.</td>
            <td style="width: 18%">
            </td>
        </tr>
        
    </table>

</asp:Content>

