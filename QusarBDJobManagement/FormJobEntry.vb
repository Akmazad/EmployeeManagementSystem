Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FormJobEntry
    Dim connectionString As SqlConnection

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim taskAssignedTo = String.Empty

        'build the checked coders
        For Each con As Control In Me.Controls
            If TypeOf con Is CheckBox Then
                Dim ch As CheckBox = CType(con, CheckBox)
                If ch.Checked Then
                    taskAssignedTo &= (ch.Text & ",")
                End If
            End If

        Next

        connectionString = New SqlConnection("Data Source=localhost;Initial Catalog=QuasarBD_Job;Integrated Security=True")

        Dim cmd As SqlCommand
        cmd = New SqlCommand

        With cmd
            .Connection = connectionString
            .CommandType = CommandType.Text
            .CommandText = "insert into ProjectInfo (BuyerName, BuyerContact, BuyerCountry, BuyerReview, ProjectName, ProjectSite, ProjectLink, ProjectBidDate, ProjectRefference, ProjectMoneyAmount, ProjectBuyerAssignedDate, ProjectOurAssignedDate, ProjectBidStatus, ProjectTaskAssignedTo) values ('" & Me.txtBuyerName.Text & "', '" & Me.txtBuyerContact.Text & "', '" & Me.txtBuyerCountry.Text & "', '" & Me.txtBuyerReview.Text & "', '" & Me.txtProjectName.Text & "', '" & Me.txtProjectSite.Text & "', '" & Me.txtProjectLink.Text & "', '" & Me.txtbiddingDate.Text & "', '" & Me.cmbRefferedBy.SelectedItem.ToString & "', '" & Me.txtProjectAmount.Text & "', '" & Me.txtfinishBuyer.Text & "', '" & Me.txtFinishOur.Text & "', '" & Me.cmbProjectStatus.SelectedItem.ToString & "', '" & taskAssignedTo & "')"

        End With
        connectionString.Open()
        cmd.ExecuteNonQuery()
        connectionString.Close()



        'clear all
        Me.txtbiddingDate.Text = ""
        Me.txtBuyerContact.Text = ""
        Me.txtBuyerName.Text = ""
        Me.txtBuyerCountry.Text = ""
        Me.txtBuyerReview.Text = ""
        Me.txtfinishBuyer.Text = ""
        Me.txtFinishOur.Text = ""
        Me.txtProjectAmount.Text = ""
        Me.txtProjectLink.Text = ""
        Me.txtProjectName.Text = ""
        Me.txtProjectSite.Text = ""

        Me.CheckBox1.Checked = False
        Me.CheckBox2.Checked = False
        Me.CheckBox3.Checked = False
        Me.CheckBox4.Checked = False
        Me.CheckBox5.Checked = False
        Me.CheckBox6.Checked = False
        Me.CheckBox7.Checked = False
        Me.CheckBox8.Checked = False

        Me.cmbProjectStatus.SelectedItem = Nothing
        Me.cmbRefferedBy.SelectedItem = Nothing

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class