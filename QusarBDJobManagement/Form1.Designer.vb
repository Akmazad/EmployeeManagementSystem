<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnJobEntry = New System.Windows.Forms.Button
        Me.btnBrowseJob = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnJobEntry
        '
        Me.btnJobEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnJobEntry.FlatAppearance.BorderColor = System.Drawing.Color.Navy
        Me.btnJobEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJobEntry.Location = New System.Drawing.Point(66, 311)
        Me.btnJobEntry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnJobEntry.Name = "btnJobEntry"
        Me.btnJobEntry.Size = New System.Drawing.Size(100, 25)
        Me.btnJobEntry.TabIndex = 0
        Me.btnJobEntry.Text = "Enter A Job"
        Me.btnJobEntry.UseVisualStyleBackColor = False
        '
        'btnBrowseJob
        '
        Me.btnBrowseJob.FlatAppearance.BorderColor = System.Drawing.Color.Navy
        Me.btnBrowseJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnBrowseJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBrowseJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseJob.Location = New System.Drawing.Point(762, 437)
        Me.btnBrowseJob.Name = "btnBrowseJob"
        Me.btnBrowseJob.Size = New System.Drawing.Size(97, 23)
        Me.btnBrowseJob.TabIndex = 1
        Me.btnBrowseJob.Text = "Browse Job"
        Me.btnBrowseJob.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.QusarBDJobManagement.My.Resources.Resources.Quasar_BD
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(949, 590)
        Me.Controls.Add(Me.btnBrowseJob)
        Me.Controls.Add(Me.btnJobEntry)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QuasarBD Job Management System"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnJobEntry As System.Windows.Forms.Button
    Friend WithEvents btnBrowseJob As System.Windows.Forms.Button

End Class
