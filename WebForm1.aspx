<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SampleMVC.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustId" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="CustId" HeaderText="CustId" ReadOnly="True" SortExpression="CustId" InsertVisible="False" />
                    <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="Abbrev" HeaderText="Abbrev" SortExpression="Abbrev" />
                    <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Benchworks_POCConnectionString %>" SelectCommand="SELECT top 100 * FROM [Customers]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
