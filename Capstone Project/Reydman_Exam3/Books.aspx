<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <h3>Books</h3>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="Pub_Title" HeaderText="Pub_Title" SortExpression="Pub_Title" />
        <asp:BoundField DataField="Pub_Date" HeaderText="Pub_Date" SortExpression="Pub_Date" />
        <asp:BoundField DataField="Pub_Price" HeaderText="Pub_Price" SortExpression="Pub_Price" />
        <asp:BoundField DataField="Pub_Qty" HeaderText="Pub_Qty" SortExpression="Pub_Qty" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Pub_Title], [Pub_Date], [Pub_Price], [Pub_Qty] FROM [Books]"></asp:SqlDataSource>
</asp:Content>
