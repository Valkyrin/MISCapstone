'Global import function statement referenced every time page loads (Namespace)
Imports System.Data
'Lower level namespace that references sql objects from the client.
Imports System.Data.SqlClient

Partial Class Restricted_Cart
    'Where all objects, labels, buttons, etc. exist (Memory)
    Inherits System.Web.UI.Page

    'Just declaring objDT and objDR as table and row data namespaces
    Dim ObjDT As System.Data.DataTable
    Dim ObjDR As System.Data.DataRow
    'Declared memory location called ds and made reference to a new instantiation of dataset object
    Dim ds As New DataSet


    'Loads the cart for postback
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If never been posted back before then run the function makeCart() which will create the data table. If it has then do nothing.
        If Not IsPostBack Then
            makeCart()
        End If
    End Sub


    'Function to make a data table called cart that will be editable.
    Function makeCart()
        'variable dedicated to holding the memory of datatable cart
        ObjDT = New System.Data.DataTable("Cart")
        'Adds columns with datatypes to the table
        ObjDT.Columns.Add("Pub_ID", GetType(Int64))

        ObjDT.Columns.Add("Pub_Date", GetType(String))
        ObjDT.Columns.Add("Pub_Price", GetType(Decimal))
        ObjDT.Columns.Add("Pub_Title", GetType(String))
        ObjDT.Columns.Add("Pub_Qty", GetType(Integer))
        'session stores the new columns to the table. Saves the structure of the cart.
        Session("Cart") = ObjDT

    End Function


    'After selecting item, movie or book, subprocedure handles dropdownlist object to pull up data from data tier layer.
    Public Sub DropDownList1_ItemSelected(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Dim intCategory As Integer
        Dim strSQL As String

        'Create sql string connection to the local database directory (products.mdf) and assign it to variable
        Dim strConnection As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Products.mdf;Integrated Security=True"
        'Creates new sql connection that points to data source above
        Dim objConnection As New SqlConnection(strConnection)

        'Grabs value that is passed from dropdownlist
        intCategory = DropDownList1.SelectedValue


        'Depending on the value that was chosen from the dropdownlist, the conditions below will run. If condition is equal to 0,1, or 2.
        Select Case intCategory
            Case 0

                GridView1.DataSource = Nothing
                GridView1.DataBind()
                Exit Sub
            'If 1 or 2 SQL statement runs that pulls all data * from the respective table
            Case 1
                strSQL = "SELECT * FROM [Books]"
                lblProd.Visible = True
            Case 2
                strSQL = "SELECT * FROM [Movies]"
                lblProd.Visible = True
        End Select

        'Connection must be open in order to use as parameter in the objAdapter
        objConnection.Open()

        'Because the page is runnning connectionless, a data adapter is necessary to fill a dataset or datatable. In this case either the Books or Movies
        Dim objAdapter As New SqlDataAdapter(strSQL, objConnection)

        Using objConnection
            Select Case intCategory
                'ds filled with movies or books
                Case 1
                    objAdapter.Fill(ds, "Books")
                Case 2
                    objAdapter.Fill(ds, "Movies")
            End Select
        End Using

        'Instantiated dataset stored by the system 
        Session("ds") = ds
        'Display the dataset.
        GridView1.DataSource = ds
        GridView1.DataBind()


        objConnection.Close()

    End Sub

    'This function is run when an existing item is added from catalog to table or a completly new unique item is added
    Function AddItemToCart()
        'Declarations necessary for function
        Dim intProductKey, intCurrentKey As Integer
        Dim i As Integer = 0
        Dim blnFound As Boolean = False
        Dim intCategory As Integer

        ds = Session("ds")

        intProductKey = GridView1.SelectedValue
        ObjDT = Session("Cart")
        'Will loop through all the existing rows until the primary ID chosen is found
        For Each ObjDR In ObjDT.Rows
            If ObjDR("Pub_ID") = intProductKey Then
                'Add until true then will exit the for loop.
                ObjDR("Pub_Qty") += 1
                blnFound = True
                Exit For
            End If
        Next
        'If above conditon is not true then a new row is created for the item.
        If Not blnFound Then
            ObjDR = ObjDT.NewRow
            ObjDR("Pub_ID") = intProductKey
            ObjDR("Pub_Qty") = 1

            intCategory = DropDownList1.SelectedValue
            Select Case intCategory
                'Do while loop will loop through dataset until the one record is found that is = to the intProductKey after determining the condition of books or movies.
                Case 1
                    Do While i <= (ds.Tables("Books").Rows.Count - 1)
                        intCurrentKey = ds.Tables("Books").Rows(i).Item("Pub_ID")
                        If intCurrentKey = intProductKey Then
                            'Assign data to row if intCurrentKey=intProductKey
                            ObjDR("Pub_Title") = ds.Tables("Books").Rows(i).Item("Pub_Title")
                            ObjDR("Pub_Price") = ds.Tables("Books").Rows(i).Item("Pub_Price")
                            ObjDR("Pub_Date") = ds.Tables("Books").Rows(i).Item("Pub_Date")
                        End If
                        i += 1
                    Loop

                Case 2
                    Do While i <= (ds.Tables("Movies").Rows.Count - 1)
                        intCurrentKey = ds.Tables("Movies").Rows(i).Item("Pub_ID")
                        If intCurrentKey = intProductKey Then
                            ObjDR("Pub_Title") = ds.Tables("Movies").Rows(i).Item("Pub_Title")
                            ObjDR("Pub_Price") = ds.Tables("Movies").Rows(i).Item("Pub_Price")
                            ObjDR("Pub_Date") = ds.Tables("Movies").Rows(i).Item("Pub_Date")
                        End If
                        i += 1
                    Loop

            End Select
            'Based off values will be added to cart table
            ObjDT.Rows.Add(ObjDR)

        End If

        Session("Cart") = ObjDT

    End Function
    'Take data table stored in session table and will show whats in the cart after running the DataBind
    Function ShowItemsInCart()

        ObjDT = Session("Cart")
        GridView2.DataSource = ObjDT
        GridView2.DataBind()

    End Function
    'Will make lblTotal lblAmount and btncheckout visible and will run another function called GetItemTotals to the display the to display totals at end
    Function ShowCartTotal()
        lblTotal.Visible = True
        lblAmount.Visible = True
        btnCheckOut.Visible = True
        lblAmount.Text = "$" & GetItemTotals()
        lblTotal.Text = "Total:"
    End Function
    'Function will hide the cart totals by making lblTotal lblAmount and btncheckout set to false.
    Function CloseCartTotal()
        lblTotal.Visible = False
        lblAmount.Visible = False
        btnCheckOut.Visible = False
        lblTotal.Text = ""
    End Function
    'Function will perform the math to get the running total using a for loop. Published price * published quanity for every row.
    Function GetItemTotals()

        Dim intCounter As Integer
        Dim decRunningTotal As Decimal
        ObjDT = Session("Cart")

        For intCounter = 0 To ObjDT.Rows.Count - 1
            ObjDR = ObjDT.Rows(intCounter)
            decRunningTotal += (ObjDR("Pub_Price") * ObjDR("Pub_Qty"))
        Next

        Return decRunningTotal

    End Function

    'Publication ID is passed into this function and sends it back to the server. Gridview1 will build the catalog.
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Once item is selected in catalog the 3 functions AddItemToCart() ShowItemsInCart() ShowCartTotal() will show up.
        AddItemToCart()
        ShowItemsInCart()
        ShowCartTotal()
    End Sub

    'Grab an item in the cart to then remove it from your shopping cart.
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        ObjDT = Session("Cart")
        Dim i As Integer = 0

        'The .delete method will delete the row, and assign it back to the session data table.
        For Each ObjDR In ObjDT.Rows
            If i = e.RowIndex Then
                'Find the record within the cart, and when it is found the delete function will run on the row index
                If ObjDR("Pub_Qty") = 1 Then
                    ObjDT.Rows.Item(e.RowIndex).Delete()
                    Exit For
                Else
                    ObjDR("Pub_Qty") -= 1
                    Exit For
                End If
            End If
            i += 1
        Next

        'Stored cookie
        Session("Cart") = ObjDT
        'Row count will decide whether or not to show items in cart and the cart total or to close the cart if below 1
        If ObjDT.Rows.Count >= 1 Then
            ShowItemsInCart()
            ShowCartTotal()
        Else
            ShowItemsInCart()
            CloseCartTotal()
        End If


    End Sub
    'Takes you to a new page called checkout.aspx when item is checked out with server.transfer on the click of the button
    Protected Sub btnCheckOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckOut.Click
        Server.Transfer("~/Restricted/CheckOut.aspx")
    End Sub
End Class