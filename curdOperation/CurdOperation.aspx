<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurdOperation.aspx.cs" Inherits="curdOperation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .display-table{
            margin: 20px 0px;
        }
        .display-table td{
            border-bottom: 1px solid #ddd;
        }
        .display-table tr:hover {background-color: coral;}
    </style>
</head>
<body>
    <h1 style="text-align: center;">CURD Operation</h1>
    <form id="form1" runat="server" style="width: 100vw; display: flex; flex-direction: column; justify-content: center; align-items: center;">
        <div>
            <table style="margin: 20px 0px;">
                <tr>
                    <td>Id: </td>
                    <td>
                        <asp:TextBox ID="IdBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Name: </td>
                    <td>
                        <asp:TextBox ID="NameBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email: </td>
                    <td>
                        <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Phone: </td>
                    <td>
                        <asp:TextBox ID="PhoneBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Age: </td>
                    <td>
                        <asp:TextBox ID="AgeBox" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Gender: </td>
                    <td>
                        <asp:TextBox ID="GenderBox" runat="server"></asp:TextBox></td>
                </tr>
                
            </table>
            <asp:Button ID="Add" runat="server" Text="Add Data" OnClick="Add_Click" BackColor="#0066FF" ForeColor="White" />
            <asp:Button ID="Update" runat="server" Text="Update Data" OnClick="Update_Click" ForeColor="White" BackColor="#009933" />
        </div>
        <div class="display">
             <%-- for display details from database --%>
             <asp:Table ID="Table1" runat="server" Height="123px" Width="567px" CssClass="display-table"></asp:Table>  
        </div>
        <div class="delete-item">
            <table>
                <tr>
                    <td>Enter Id:</td>
                    <td>
                        <asp:TextBox ID="DeleteIdBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Delete" runat="server" Text="Delete Data" OnClick="Delete_Click" BackColor="#CC0000" ForeColor="White" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
