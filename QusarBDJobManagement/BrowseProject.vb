Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class BrowseProject
    Dim constr As SqlConnection
    Public updateID As Integer

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKeyword.KeyPress

        constr = New SqlConnection("Data Source=localhost;Initial Catalog=QuasarBD_Job;Integrated Security=True")
        Dim cmd As SqlCommand
        cmd = New SqlCommand
        cmd.Connection = constr
        cmd.CommandType = CommandType.Text

        Dim whereClause As String = ""

        If e.KeyChar = CType(ChrW(13), Char) Then

            'check option
            If cmbSearchOption.SelectedItem.ToString() = "Project Name" Then
                cmd.CommandText = "Select * from ProjectInfo where ProjectName like '%" & Me.txtKeyword.Text & "%';"

            ElseIf cmbSearchOption.SelectedItem.ToString() = "Reffered By" Then
                cmd.CommandText = "Select * from ProjectInfo where ProjectRefference like '%" & Me.txtKeyword.Text & "%';"
            Else
                cmd.CommandText = "Select * from ProjectInfo where ProjectTaskAssignedTo like '%" & Me.txtKeyword.Text & "%';"
            End If
            

            
            constr.Open()
            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = cmd
            Dim _DataTable As New DataTable
            adapter.Fill(_DataTable)

            If _DataTable.Rows.Count <> 0 Then
                Me.ListBox1.DataSource = _DataTable

                If cmbSearchOption.SelectedItem.ToString() = "Project Name" Then
                    Me.ListBox1.DisplayMember = "ProjectName"
                    Me.ListBox1.ValueMember = "id"

                ElseIf cmbSearchOption.SelectedItem.ToString() = "Reffered By" Then
                    Me.ListBox1.DisplayMember = "ProjectRefference"
                    Me.ListBox1.ValueMember = "id"
                Else
                    Me.ListBox1.DisplayMember = "ProjectTaskAssignedTo"
                    Me.ListBox1.ValueMember = "id"
                End If
            Else
                Me.ListBox1.Items.Add("             There's no Result to display")
            End If
            
            
        End If
        constr.Close()
    End Sub

    Private Sub ListBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        If Me.ListBox1.SelectedItem.ToString() = "             There's no Result to display" Then
            Return
        End If
        'readonly all
        Me.txtbiddingDate.ReadOnly = True
        Me.txtBuyerContact.ReadOnly = True
        Me.txtBuyerCountry.ReadOnly = True
        Me.txtBuyerName.ReadOnly = True
        Me.txtBuyerReview.ReadOnly = True
        Me.txtfinishBuyer.ReadOnly = True
        Me.txtFinishOur.ReadOnly = True
        Me.txtProjectAmount.ReadOnly = True
        Me.txtProjectLink.ReadOnly = True
        Me.txtProjectName.ReadOnly = True
        Me.txtProjectSite.ReadOnly = True
        Me.cmbAssignedTo.Enabled = False
        Me.cmbProjectStatus.Enabled = False
        Me.cmbRefferedBy.Enabled = False

        Me.btnEdit.Enabled = True
        Me.btnUpdate.Enabled = False
        Dim cmd As SqlCommand
        cmd = New SqlCommand
        cmd.Connection = constr
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * from ProjectInfo where id = " & Me.ListBox1.SelectedValue.ToString()

        constr.Open()

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read
            Me.txtBuyerName.Text = reader.Item("BuyerName").ToString()
            Me.txtbiddingDate.Text = reader.Item("ProjectBidDate").ToString()
            Me.txtBuyerContact.Text = reader.Item("BuyerContact").ToString()
            Me.txtBuyerCountry.Text = reader.Item("BuyerCountry").ToString()
            Me.txtBuyerReview.Text = reader.Item("BuyerReview").ToString()
            Me.txtfinishBuyer.Text = reader.Item("ProjectBuyerAssignedDate").ToString()
            Me.txtFinishOur.Text = reader.Item("ProjectOurAssignedDate").ToString()
            Me.txtProjectAmount.Text = reader.Item("ProjectMoneyAmount").ToString()
            Me.txtProjectLink.Text = reader.Item("ProjectLink").ToString()
            Me.txtProjectName.Text = reader.Item("ProjectName").ToString()
            Me.txtProjectSite.Text = reader.Item("ProjectSite").ToString()
            Me.cmbRefferedBy.SelectedItem = reader.Item("ProjectRefference").ToString()
            Me.cmbAssignedTo.SelectedItem = reader.Item("ProjectTaskAssignedTo").ToString()
            Me.cmbProjectStatus.SelectedItem = reader.Item("ProjectBidStatus").ToString()

            updateID = CType(Me.ListBox1.SelectedValue.ToString(), Integer)

        End While
        constr.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Me.txtbiddingDate.ReadOnly = False
        Me.txtBuyerContact.ReadOnly = False
        Me.txtBuyerCountry.ReadOnly = False
        Me.txtBuyerName.ReadOnly = False
        Me.txtBuyerReview.ReadOnly = False
        Me.txtfinishBuyer.ReadOnly = False
        Me.txtFinishOur.ReadOnly = False
        Me.txtProjectAmount.ReadOnly = False
        Me.txtProjectLink.ReadOnly = False
        Me.txtProjectName.ReadOnly = False
        Me.txtProjectSite.ReadOnly = False
        Me.cmbAssignedTo.Enabled = True
        Me.cmbProjectStatus.Enabled = True
        Me.cmbRefferedBy.Enabled = True


        Me.btnUpdate.Enabled = True
        Me.btnEdit.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub btnUpdate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        

        Dim cmd As SqlCommand
        cmd = New SqlCommand
        cmd.Connection = constr
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Update ProjectInfo set BuyerName = '" & Me.txtBuyerName.Text & "', BuyerContact = '" & Me.txtBuyerContact.Text & "', BuyerCountry = '" & Me.txtBuyerCountry.Text & "', BuyerReview ='" & Me.txtBuyerReview.Text & "', ProjectName ='" & Me.txtProjectName.Text & "', ProjectSite ='" & Me.txtProjectSite.Text & "', ProjectLink ='" & Me.txtProjectLink.Text & "', ProjectBidDate ='" & Me.txtbiddingDate.Text & "', ProjectRefference ='" & Me.cmbRefferedBy.SelectedItem.ToString() & "', ProjectMoneyAmount ='" & Me.txtProjectAmount.Text & "', ProjectBuyerAssignedDate ='" & Me.txtfinishBuyer.Text & "', ProjectOurAssignedDate ='" & Me.txtFinishOur.Text & "', ProjectBidStatus ='" & Me.cmbProjectStatus.SelectedItem.ToString() & "', ProjectTaskAssignedTo ='" & Me.cmbAssignedTo.SelectedItem.ToString() & "' where id = " & updateID & ";"

        constr.Open()
        cmd.ExecuteNonQuery()
        constr.Close()


        'readonly all
        Me.txtbiddingDate.ReadOnly = True
        Me.txtBuyerContact.ReadOnly = True
        Me.txtBuyerCountry.ReadOnly = True
        Me.txtBuyerName.ReadOnly = True
        Me.txtBuyerReview.ReadOnly = True
        Me.txtfinishBuyer.ReadOnly = True
        Me.txtFinishOur.ReadOnly = True
        Me.txtProjectAmount.ReadOnly = True
        Me.txtProjectLink.ReadOnly = True
        Me.txtProjectName.ReadOnly = True
        Me.txtProjectSite.ReadOnly = True
        Me.cmbAssignedTo.Enabled = False
        Me.cmbProjectStatus.Enabled = False
        Me.cmbRefferedBy.Enabled = False


        Me.btnEdit.Enabled = True
        Me.btnUpdate.Enabled = False
    End Sub
End Class