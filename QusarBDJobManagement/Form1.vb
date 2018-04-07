Public Class Form1

    Private Sub btnJobEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJobEntry.Click
        Dim entryform As New FormJobEntry
        'entryform.MdiParent = Me
        entryform.Show()
    End Sub

    Private Sub btnBrowseJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseJob.Click
        Dim browseform As New BrowseProject
        browseform.Show()
    End Sub
End Class
