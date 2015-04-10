Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class QLSanPham
    Dim tb As New DataTable
    Dim connectstr As String = "workstation id=haindps02363.mssql.somee.com;packet size=4096;user id=nguyenduyhai994_SQLLogin_1;pwd=nbb4l5a2sl;data source=haindps02363.mssql.somee.com;persist security info=False;initial catalog=haindps02363"



    Public Sub LoadData()
        Dim KetNoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("select * from SanPham", KetNoi)

        Try

            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        KetNoi.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        TextBox1.Text = DataGridView1.Item(0, index).Value
        TextBox2.Text = DataGridView1.Item(1, index).Value
        TextBox3.Text = DataGridView1.Item(2, index).Value
        TextBox4.Text = DataGridView1.Item(3, index).Value
        TextBox5.Text = DataGridView1.Item(4, index).Value
        TextBox6.Text = DataGridView1.Item(5, index).Value
        TextBox7.Text = DataGridView1.Item(6, index).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim KetNoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("select * from SanPham", KetNoi)

        Try

            sqlAdapter.Fill(tb)

        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        KetNoi.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim KetNoi As New SqlConnection(connectstr)
        Dim sqlAdapter As New SqlDataAdapter("Insert into SanPham values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')", KetNoi)

        Try
            KetNoi.Open()
            sqlAdapter.Fill(tb)


        Catch ex As Exception
            MessageBox.Show("Nhập dữ liệu không thành công")
        End Try
        DataGridView1.DataSource = tb
        KetNoi.Close()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim KetNoi As New SqlConnection(connectstr)
        KetNoi.Open()
        Dim stradd As String = "update SanPham set TenSanPham = @TenSanPham, SoLuong = @SoLuong, DonGia = @DonGia, KichThuoc = @KichThuoc, ThongTin = @ThongTin, NhaSanXuat = @NhaSanXuat where MaSanPham = @MaSanPham"
        Dim com As New SqlCommand(stradd, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaSanPham", TextBox1.Text)
            com.Parameters.AddWithValue("@TenSanPham", TextBox2.Text)
            com.Parameters.AddWithValue("@SoLuong", TextBox3.Text)
            com.Parameters.AddWithValue("@DonGia", TextBox4.Text)
            com.Parameters.AddWithValue("@KichThuoc", TextBox5.Text)
            com.Parameters.AddWithValue("@ThongTin", TextBox6.Text)
            com.Parameters.AddWithValue("@NhaSanXuat", TextBox7.Text)
            com.ExecuteNonQuery()
            KetNoi.Close()

        Catch ex As Exception
            MessageBox.Show("Sủa dữ liệu thất bại")
        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim KetNoi As New SqlConnection(connectstr)
        KetNoi.Open()
        Dim stradd As String = "Delete from SanPham where MaSanPham = @MaSanPham"
        Dim com As New SqlCommand(stradd, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaSanPham", TextBox1.Text)
            com.ExecuteNonQuery()
            KetNoi.Close()

        Catch ex As Exception
            MessageBox.Show("Xóa thất bại")
        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()

    End Sub

    Private Sub QLSanPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
End Class