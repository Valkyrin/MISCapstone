'Global import function statement referenced every time page loads (Namespace)
Imports System.Data
'Lower level namespace that references sql objects from the client.
Imports System.Data.SqlClient

'Tied to the CheckOut.aspx file which inherits this partial class CheckOut. Class makes up all the behind the scene functionalities of the CheckOut process.
Partial Class Restricted_Checkout
    'Where all objects, labels, buttons, etc. exist (Memory)
    Inherits System.Web.UI.Page

    'Just declaring objDT and objDR as table and row data namespaces
    Dim ObjDT As System.Data.DataTable
    Dim ObjDR As System.Data.DataRow
    'Declared memory location called ds and made reference to a new instantiation of dataset object
    Dim ds As New DataSet

    'Page loads cart for postback
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Assign data source of gridview to the cart from the previous page.
        GridView1.DataSource = Session("Cart")
        GridView1.DataBind()
        'Whenever a tetfield is left empty, this will validate and make it visible.
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None
    End Sub

    'When a person is ready to checkout. This button will run functions for most of the work for the process of checking out items.
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        makeNewDataTable()
        'Declares two new items Items Ordered and the Total
        Dim strItemsOrdered As String = ""
        Dim strTotal As Decimal = 0

        'Create connection string to point to the database
        Dim strConnection As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Products.mdf;Integrated Security=True"
        Dim objConnection As New SqlConnection(strConnection)
        'Pulling data from the table ToBe_Shipped
        Dim mySqlDataAdapter As New SqlDataAdapter("Select * From ToBe_Shipped", objConnection)


        ObjDT = Session("Cart")
        'Loops through all the rows in the data table and adds them together.
        For Each ObjDR In ObjDT.Rows
            'Concatenates the name of the column for the new to be shipped table
            strItemsOrdered += ObjDR("Pub_ID") & "(" & ObjDR("Pub_Qty") & ")" & ", "
            'Calculates the total cost of the items in the cart
            strTotal += ObjDR("Pub_Qty") * ObjDR("Pub_Price")

        Next


        Dim myDataRow As DataRow
        'SQLCommandBuilder will run the update of the data in memory (dataset) referencing the tobeshipped table and execute that against the data
        Dim myDataRowsCommandBuilder As New SqlCommandBuilder(mySqlDataAdapter)
        'Makes sure that a primary key exists for every row to the tobeshipped table
        mySqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey


        mySqlDataAdapter.Fill(ds, "ToBe_Shipped")
        'adds new row to the tobeshipped table in memory
        myDataRow = ds.Tables("ToBe_Shipped").NewRow()
        'schema down below of the table. Assigns values that came from textboxes from checkout.aspx
        myDataRow("FName") = txtFName.Text
        myDataRow("LName") = txtLName.Text
        myDataRow("Street") = txtStreet.Text
        myDataRow("City") = txtCity.Text
        myDataRow("State") = txtState.Text
        myDataRow("Zip") = txtZip.Text
        myDataRow("Phone") = txtPhone.Text
        myDataRow("CardType") = ddlCType.SelectedValue
        myDataRow("CardNumber") = txtCNumber.Text
        'values declared earlier
        myDataRow("Products") = strItemsOrdered
        myDataRow("Total") = strTotal
        'adds row of all the attributes to the very first newrow that was in memory
        ds.Tables("ToBe_Shipped").Rows.Add(myDataRow)
        'execute against the table ToBe_Shipped
        mySqlDataAdapter.Update(ds, "ToBe_Shipped")

        'After everything sends you to the confirmation.aspx page
        Server.Transfer("~/Restricted/Confirmation.aspx")


    End Sub

    'Function that makes new data table and adds the columns down below.
    Function makeNewDataTable()
        ObjDT = New System.Data.DataTable("Cart")
        'New columns to be added to the new data table
        ObjDT.Columns.Add("Pub_ID", GetType(Int64))

        ObjDT.Columns.Add("Pub_Date", GetType(String))
        ObjDT.Columns.Add("Pub_Price", GetType(Decimal))
        ObjDT.Columns.Add("Pub_Title", GetType(String))
        ObjDT.Columns.Add("Pub_Qty", GetType(Integer))

    End Function

End Class
