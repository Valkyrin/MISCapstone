<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Checkout.aspx.vb" Inherits="Restricted_Checkout" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <form id="form1">
        <div>
            <asp:Label ID="lblCart" runat="server" Font-Bold="True" Text="Items in Your Cart"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="lblProfile" runat="server" Font-Bold="True" Text="Billing Profile"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">First Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFName"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Last Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLName"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Street</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtStreet"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">City</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                    <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCity"></asp:RequiredFieldValidator> &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">State</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtState"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Zip</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtZip"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Phone</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2"><strong>Payment</strong></td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Credit Card Type</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="ddlCType" runat="server">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Visa</asp:ListItem>
                            <asp:ListItem Value="2">MC</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddlCType" ErrorMessage="Required Field" MaximumValue="2" MinimumValue="1"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Card Number</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtCNumber" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCNumber"></asp:RequiredFieldValidator>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit Order" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</asp:Content>

