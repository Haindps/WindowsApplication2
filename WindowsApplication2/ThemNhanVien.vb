Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class ThemNhanVien
    Dim tb As New DataTable
    Dim connectstr As String = "workstation id=haindps02363.mssql.somee.com;packet size=4096;user id=nguyenduyhai994_SQLLogin_1;pwd=nbb4l5a2sl;data source=haindps02363.mssql.somee.com;persist security info=False;initial catalog=haindps02363"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim KetNoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("Insert into NhanVien values('" & TextBox1.Text & "','" & TextBox2.Text & "')", KetNoi)

        Try
            KetNoi.Open()
            sqlAdapter.Fill(tb)


        Catch ex As Exception
            MessageBox.Show("Nhập dữ liệu không thành công")
        End Try
        KetNoi.Close()
    End Sub
End Class