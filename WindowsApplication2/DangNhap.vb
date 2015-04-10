
Imports System.Data.SqlClient
Public Class DangNhap

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim chuoiketnoi As String = "workstation id=haindps02363.mssql.somee.com;packet size=4096;user id=nguyenduyhai994_SQLLogin_1;pwd=nbb4l5a2sl;data source=haindps02363.mssql.somee.com;persist security info=False;initial catalog=haindps02363"

        Dim KetNoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim sqlAdapter As New SqlDataAdapter("select * from NhanVien where MaNhanVien='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "' ", KetNoi)
        Dim tb As New DataTable

        Try
            KetNoi.Open()
            sqlAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                MessageBox.Show("Kết nối thành công")

                Me.Hide()
                Main.Show()
            Else
                MessageBox.Show("Sai tài khoản hoặc mật khẩu")
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        'phan thay doi


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()

    End Sub
End Class
