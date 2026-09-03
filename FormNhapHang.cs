using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormNhapHang : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormNhapHang()
        {
            InitializeComponent();
            guna2Button1.Click += guna2Button1_Click;
            guna2Button2.Click += guna2Button2_Click;
            GNb_ThemDong.Click += GNb_ThemDong_Click;
        }

        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNhaCungCap();
                LoadKho();
                LoadNhanVien();
                LoadSize();
                LoadMauSac();
                LoadSanPhamAutoComplete();

                dtp_NgayNhap.Value = DateTime.Now;

                // Trạng thái mặc định
                GNc_ChoDuyet.Text = "Chờ duyệt";

                // Đơn giá và số lượng
                LoadSoLuong(guna2ComboBox6);
                LoadSoLuong(guna2ComboBox10);

                LoadDonGia(guna2ComboBox7);
                LoadDonGia(guna2ComboBox11);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu cho form nhập hàng.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // NHÀ CUNG CẤP
        // =========================================================
        private void LoadNhaCungCap()
        {
            string sql = @"
                SELECT MaNCC, TenNCC
                FROM NhaCungCap
                WHERE TrangThai = 1
                ORDER BY TenNCC";

            DataTable dt = kt.GetData(sql);

            cmb_NhaCungCap.DataSource = dt;
            cmb_NhaCungCap.DisplayMember = "TenNCC";
            cmb_NhaCungCap.ValueMember = "MaNCC";
            cmb_NhaCungCap.SelectedIndex = -1;
        }

        // =========================================================
        // KHO
        // =========================================================
        private void LoadKho()
        {
            string sql = @"
                SELECT MaKho, TenKho
                FROM Kho
                WHERE TrangThai = 1
                ORDER BY TenKho";

            DataTable dt = kt.GetData(sql);

            cmb_Kho.DataSource = dt;
            cmb_Kho.DisplayMember = "TenKho";
            cmb_Kho.ValueMember = "MaKho";
            cmb_Kho.SelectedIndex = -1;
        }

        // =========================================================
        // NHÂN VIÊN
        // =========================================================
        private void LoadNhanVien()
        {
            string sql = @"
                SELECT MaNV, HoTen
                FROM NhanVien
                WHERE TrangThai = 1
                ORDER BY HoTen";

            DataTable dt = kt.GetData(sql);

            cmb_NhanVien.DataSource = dt;
            cmb_NhanVien.DisplayMember = "HoTen";
            cmb_NhanVien.ValueMember = "MaNV";
            cmb_NhanVien.SelectedIndex = -1;
        }

        // =========================================================
        // SIZE
        // =========================================================
        private void LoadSize()
        {
            string sql = @"
                SELECT MaSize, TenSize
                FROM Size
                ORDER BY TenSize";

            DataTable dt = kt.GetData(sql);

            LoadSizeCombo(guna2ComboBox4, dt);
            LoadSizeCombo(guna2ComboBox8, dt);
        }

        private void LoadSizeCombo(
            Guna.UI2.WinForms.Guna2ComboBox combo,
            DataTable dt)
        {
            combo.DataSource = dt.Copy();
            combo.DisplayMember = "TenSize";
            combo.ValueMember = "MaSize";
            combo.SelectedIndex = -1;
        }

        // =========================================================
        // MÀU
        // =========================================================
        private void LoadMauSac()
        {
            string sql = @"
                SELECT MaMau, TenMau
                FROM MauSac
                ORDER BY TenMau";

            DataTable dt = kt.GetData(sql);

            LoadMauCombo(guna2ComboBox5, dt);
            LoadMauCombo(guna2ComboBox9, dt);
        }

        private void LoadMauCombo(
            Guna.UI2.WinForms.Guna2ComboBox combo,
            DataTable dt)
        {
            combo.DataSource = dt.Copy();
            combo.DisplayMember = "TenMau";
            combo.ValueMember = "MaMau";
            combo.SelectedIndex = -1;
        }

        // =========================================================
        // SẢN PHẨM - AUTOCOMPLETE
        // =========================================================
        private void LoadSanPhamAutoComplete()
        {
            string sql = @"
                SELECT DISTINCT TenSP
                FROM SanPham
                WHERE TrangThai = 1
                ORDER BY TenSP";

            DataTable dt = kt.GetData(sql);

            AutoCompleteStringCollection source =
                new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                source.Add(row["TenSP"].ToString());
            }

            guna2TextBox1.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            guna2TextBox1.AutoCompleteSource =
                AutoCompleteSource.CustomSource;

            guna2TextBox1.AutoCompleteCustomSource = source;


            guna2TextBox2.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            guna2TextBox2.AutoCompleteSource =
                AutoCompleteSource.CustomSource;

            guna2TextBox2.AutoCompleteCustomSource = source;
        }

        // =========================================================
        // SỐ LƯỢNG
        // =========================================================
        private void LoadSoLuong(
            Guna.UI2.WinForms.Guna2ComboBox combo)
        {
            combo.Items.Clear();

            for (int i = 1; i <= 500; i++)
            {
                combo.Items.Add(i);
            }

            combo.SelectedIndex = -1;
        }

        // =========================================================
        // ĐƠN GIÁ
        // Cho nhập giá bằng cách gõ trực tiếp vào ComboBox
        // =========================================================
        private void LoadDonGia(
            Guna.UI2.WinForms.Guna2ComboBox combo)
        {
            combo.DropDownStyle =
                ComboBoxStyle.DropDown;

            combo.Items.Clear();

            combo.Items.Add("100000");
            combo.Items.Add("150000");
            combo.Items.Add("200000");
            combo.Items.Add("250000");
            combo.Items.Add("300000");
            combo.Items.Add("500000");
        }

        // =========================================================
        // LẤY MÃ BIẾN THỂ
        //
        // Dựa vào:
        // Tên sản phẩm + Size + Màu
        // =========================================================
        private int GetMaBienThe(
            string tenSP,
            int maSize,
            int maMau)
        {
            string sql = @"
                SELECT TOP 1 bt.MaBienThe
                FROM BienTheSanPham bt
                INNER JOIN SanPham sp
                    ON sp.MaSP = bt.MaSP
                WHERE sp.TenSP = @TenSP
                  AND bt.MaSize = @MaSize
                  AND bt.MaMau = @MaMau
                  AND sp.TrangThai = 1
                  AND bt.TrangThai = 1";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenSP", tenSP),
                new SqlParameter("@MaSize", maSize),
                new SqlParameter("@MaMau", maMau)
            };

            object result =
                kt.ExecuteScalar(sql, parameters);

            if (result == null ||
                result == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(result);
        }

        // =========================================================
        // VALIDATE
        // =========================================================
        private bool ValidateHeader()
        {
            if (cmb_NhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmb_NhaCungCap.Focus();
                return false;
            }

            if (cmb_Kho.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn kho nhận hàng.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmb_Kho.Focus();
                return false;
            }

            if (cmb_NhanVien.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên lập phiếu.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmb_NhanVien.Focus();
                return false;
            }

            return true;
        }

        // =========================================================
        // LẤY CHI TIẾT DÒNG 1
        // =========================================================
        private bool GetRow1(
            out int maBienThe,
            out int soLuong,
            out decimal donGia)
        {
            maBienThe = 0;
            soLuong = 0;
            donGia = 0;

            string tenSP =
                guna2TextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenSP))
                return false;

            if (guna2ComboBox4.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn size cho dòng 1.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (guna2ComboBox5.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn màu cho dòng 1.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (guna2ComboBox6.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn số lượng cho dòng 1.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!decimal.TryParse(
                guna2ComboBox7.Text.Trim(),
                out donGia) ||
                donGia <= 0)
            {
                MessageBox.Show(
                    "Đơn giá dòng 1 không hợp lệ.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            soLuong =
                Convert.ToInt32(
                    guna2ComboBox6.SelectedItem);

            int maSize =
                Convert.ToInt32(
                    guna2ComboBox4.SelectedValue);

            int maMau =
                Convert.ToInt32(
                    guna2ComboBox5.SelectedValue);

            maBienThe =
                GetMaBienThe(
                    tenSP,
                    maSize,
                    maMau);

            if (maBienThe == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy biến thể:\n\n" +
                    "Sản phẩm: " + tenSP + "\n" +
                    "Size: " + guna2ComboBox4.Text + "\n" +
                    "Màu: " + guna2ComboBox5.Text +
                    "\n\n" +
                    "Hãy kiểm tra biến thể đã được tạo chưa.",
                    "Không tìm thấy biến thể",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // =========================================================
        // LẤY CHI TIẾT DÒNG 2
        // =========================================================
        private bool GetRow2(
            out int maBienThe,
            out int soLuong,
            out decimal donGia)
        {
            maBienThe = 0;
            soLuong = 0;
            donGia = 0;

            string tenSP =
                guna2TextBox2.Text.Trim();

            // Dòng 2 để trống thì bỏ qua
            if (string.IsNullOrWhiteSpace(tenSP))
                return true;

            if (guna2ComboBox8.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn size cho dòng 2.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (guna2ComboBox9.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn màu cho dòng 2.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (guna2ComboBox10.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn số lượng cho dòng 2.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!decimal.TryParse(
                guna2ComboBox11.Text.Trim(),
                out donGia) ||
                donGia <= 0)
            {
                MessageBox.Show(
                    "Đơn giá dòng 2 không hợp lệ.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            soLuong =
                Convert.ToInt32(
                    guna2ComboBox10.SelectedItem);

            int maSize =
                Convert.ToInt32(
                    guna2ComboBox8.SelectedValue);

            int maMau =
                Convert.ToInt32(
                    guna2ComboBox9.SelectedValue);

            maBienThe =
                GetMaBienThe(
                    tenSP,
                    maSize,
                    maMau);

            if (maBienThe == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy biến thể dòng 2.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // =========================================================
        // LƯU PHIẾU NHẬP
        // =========================================================
        private void LuuPhieuNhap()
        {
            if (!ValidateHeader())
                return;

            int maBienThe1;
            int soLuong1;
            decimal donGia1;

            if (!GetRow1(
                out maBienThe1,
                out soLuong1,
                out donGia1))
            {
                return;
            }

            int maBienThe2;
            int soLuong2;
            decimal donGia2;

            if (!GetRow2(
                out maBienThe2,
                out soLuong2,
                out donGia2))
            {
                return;
            }

            // Không cho trùng biến thể trong cùng phiếu
            if (maBienThe2 != 0 &&
                maBienThe1 == maBienThe2)
            {
                MessageBox.Show(
                    "Hai dòng đang chọn cùng một biến thể.\n" +
                    "Vui lòng chọn biến thể khác.",
                    "Trùng sản phẩm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (SqlConnection conn =
                    kt.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction tran =
                        conn.BeginTransaction())
                    {
                        try
                        {
                            // =================================================
                            // 1. TẠO PHIẾU NHẬP
                            // =================================================
                            string sqlPhieu = @"
                                INSERT INTO PhieuNhap
                                (
                                    NgayNhap,
                                    MaNV,
                                    MaNCC,
                                    TrangThai,
                                    MaKho
                                )
                                OUTPUT INSERTED.MaPN
                                VALUES
                                (
                                    @NgayNhap,
                                    @MaNV,
                                    @MaNCC,
                                    @TrangThai,
                                    @MaKho
                                )";

                            using (SqlCommand cmd =
                                new SqlCommand(
                                    sqlPhieu,
                                    conn,
                                    tran))
                            {
                                cmd.Parameters.Add(
                                    "@NgayNhap",
                                    SqlDbType.DateTime)
                                    .Value =
                                    dtp_NgayNhap.Value;

                                cmd.Parameters.Add(
                                    "@MaNV",
                                    SqlDbType.Int)
                                    .Value =
                                    Convert.ToInt32(
                                        cmb_NhanVien.SelectedValue);

                                cmd.Parameters.Add(
                                    "@MaNCC",
                                    SqlDbType.Int)
                                    .Value =
                                    Convert.ToInt32(
                                        cmb_NhaCungCap.SelectedValue);

                                cmd.Parameters.Add(
                                    "@TrangThai",
                                    SqlDbType.NVarChar, 30)
                                    .Value =
                                    "Chờ duyệt";

                                cmd.Parameters.Add(
                                    "@MaKho",
                                    SqlDbType.Int)
                                    .Value =
                                    Convert.ToInt32(
                                        cmb_Kho.SelectedValue);

                                int maPN =
                                    Convert.ToInt32(
                                        cmd.ExecuteScalar());

                                // =============================================
                                // 2. CHI TIẾT DÒNG 1
                                // =============================================
                                string sqlChiTiet = @"
                                    INSERT INTO ChiTietPhieuNhap
                                    (
                                        MaPN,
                                        MaBienThe,
                                        SoLuong,
                                        DonGia
                                    )
                                    VALUES
                                    (
                                        @MaPN,
                                        @MaBienThe,
                                        @SoLuong,
                                        @DonGia
                                    )";

                                using (SqlCommand cmdCT =
                                    new SqlCommand(
                                        sqlChiTiet,
                                        conn,
                                        tran))
                                {
                                    cmdCT.Parameters.Add(
                                        "@MaPN",
                                        SqlDbType.Int)
                                        .Value = maPN;

                                    cmdCT.Parameters.Add(
                                        "@MaBienThe",
                                        SqlDbType.Int)
                                        .Value = maBienThe1;

                                    cmdCT.Parameters.Add(
                                        "@SoLuong",
                                        SqlDbType.Int)
                                        .Value = soLuong1;

                                    cmdCT.Parameters.Add(
                                        "@DonGia",
                                        SqlDbType.Decimal)
                                        .Value = donGia1;

                                    cmdCT.Parameters[
                                        "@DonGia"]
                                        .Precision = 18;

                                    cmdCT.Parameters[
                                        "@DonGia"]
                                        .Scale = 2;

                                    cmdCT.ExecuteNonQuery();
                                }

                                // =============================================
                                // 3. CHI TIẾT DÒNG 2
                                // =============================================
                                if (maBienThe2 != 0)
                                {
                                    using (SqlCommand cmdCT2 =
                                        new SqlCommand(
                                            sqlChiTiet,
                                            conn,
                                            tran))
                                    {
                                        cmdCT2.Parameters.Add(
                                            "@MaPN",
                                            SqlDbType.Int)
                                            .Value = maPN;

                                        cmdCT2.Parameters.Add(
                                            "@MaBienThe",
                                            SqlDbType.Int)
                                            .Value = maBienThe2;

                                        cmdCT2.Parameters.Add(
                                            "@SoLuong",
                                            SqlDbType.Int)
                                            .Value = soLuong2;

                                        cmdCT2.Parameters.Add(
                                            "@DonGia",
                                            SqlDbType.Decimal)
                                            .Value = donGia2;

                                        cmdCT2.Parameters[
                                            "@DonGia"]
                                            .Precision = 18;

                                        cmdCT2.Parameters[
                                            "@DonGia"]
                                            .Scale = 2;

                                        cmdCT2.ExecuteNonQuery();
                                    }
                                }

                                // =================================================
                                // Commit
                                // =================================================
                                tran.Commit();

                                MessageBox.Show(
                                    "Tạo phiếu nhập thành công!\n\n" +
                                    "Mã phiếu: PN" +
                                    maPN.ToString("D4") +
                                    "\nTrạng thái: Chờ duyệt",
                                    "Thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                ClearForm();
                            }
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể lưu phiếu nhập.\n\n" +
                    ex.Message,
                    "Lỗi SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra:\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XÓA FORM
        // =========================================================
        private void ClearForm()
        {
            cmb_NhaCungCap.SelectedIndex = -1;
            cmb_Kho.SelectedIndex = -1;
            cmb_NhanVien.SelectedIndex = -1;

            dtp_NgayNhap.Value = DateTime.Now;

            guna2TextBox1.Clear();
            guna2TextBox2.Clear();

            guna2ComboBox4.SelectedIndex = -1;
            guna2ComboBox5.SelectedIndex = -1;
            guna2ComboBox6.SelectedIndex = -1;
            guna2ComboBox7.Text = "";

            guna2ComboBox8.SelectedIndex = -1;
            guna2ComboBox9.SelectedIndex = -1;
            guna2ComboBox10.SelectedIndex = -1;
            guna2ComboBox11.Text = "";

            GNc_ChoDuyet.Text = "Chờ duyệt";
        }

        // =========================================================
        // NÚT THÊM DÒNG
        // =========================================================
        private void GNb_ThemDong_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Form hiện tại đang thiết kế sẵn 2 dòng sản phẩm.\n\n" +
                "Sau khi phần Sản phẩm + Biến thể hoàn thiện, " +
                "mình sẽ nâng phần này lên DataGridView để thêm " +
                "không giới hạn số dòng.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =========================================================
        // NÚT LƯU
        // =========================================================
        private void guna2Button1_Click(
            object sender,
            EventArgs e)
        {
            LuuPhieuNhap();
        }

        // =========================================================
        // NÚT XÓA / RESET
        // =========================================================
        private void guna2Button2_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Bạn có muốn xóa toàn bộ dữ liệu đang nhập?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private void label9_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}