using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SPORTSHOP
{
    public partial class FormNhapHang : Form
    {
        private Guna.UI2.WinForms.Guna2ComboBox GNcmbNhaCungCap;
        private Label lblSPORTSHOP;
        private Label lblPhieuNhap;
        private Label lblNCC;
        private Label lblKho;
        private Label lblNgayNhap;
        private Guna.UI2.WinForms.Guna2ComboBox GNcmbKho;
        private Guna.UI2.WinForms.Guna2DateTimePicker GNdtpNgayNhap;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Panel panel1;
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormNhapHang()
        {
            InitializeComponent();

            btnLuu.Click += guna2Button1_Click;
            btnHuy.Click += guna2Button2_Click;
            btnThemDong.Click += GNb_ThemDong_Click;

            guna2ComboBox6.SelectedIndexChanged += guna2ComboBox6_SelectedIndexChanged;
            guna2ComboBox10.SelectedIndexChanged += guna2ComboBox10_SelectedIndexChanged;

            txtDonGia1.TextChanged += txtDonGia1_TextChanged;
            txtDonGia2.TextChanged += txtDonGia2_TextChanged;
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
                LoadSanPham();

                dtp_NgayNhap.Value = DateTime.Now;

                GNc_ChoDuyet.Text = "Chờ duyệt";

                LoadSoLuong(guna2ComboBox6);
                LoadSoLuong(guna2ComboBox10);


                // Làm chữ ComboBox dễ nhìn hơn
                cmb_NhaCungCap.ForeColor = Color.Black;
                cmb_Kho.ForeColor = Color.Black;
                cmb_NhanVien.ForeColor = Color.Black;

                guna2ComboBox4.ForeColor = Color.Black;
                guna2ComboBox5.ForeColor = Color.Black;
                guna2ComboBox6.ForeColor = Color.Black;
                txtDonGia1.ForeColor = Color.Black;

                guna2ComboBox8.ForeColor = Color.Black;
                guna2ComboBox9.ForeColor = Color.Black;
                guna2ComboBox10.ForeColor = Color.Black;
                txtDonGia2.ForeColor = Color.Black;
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

        private decimal GetDonGia(Guna.UI2.WinForms.Guna2TextBox txt)
        {
            if (!decimal.TryParse(txt.Text.Trim(), out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show(
                    "Đơn giá phải là số lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt.Focus();
                return 0;
            }

            return donGia;
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

            cmb_NhaCungCap.DataSource = null;
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

            cmb_Kho.DataSource = null;
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

            cmb_NhanVien.DataSource = null;
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
            combo.DataSource = null;
            combo.DataSource = dt.Copy();
            combo.DisplayMember = "TenSize";
            combo.ValueMember = "MaSize";
            combo.SelectedIndex = -1;
            combo.ForeColor = Color.Black;
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
            combo.DataSource = null;
            combo.DataSource = dt.Copy();
            combo.DisplayMember = "TenMau";
            combo.ValueMember = "MaMau";
            combo.SelectedIndex = -1;
            combo.ForeColor = Color.Black;
        }

        // =========================================================
        // SẢN PHẨM - AUTOCOMPLETE
        // =========================================================
        private void LoadSanPham()
        {
            string sql = @"
        SELECT MaSP, TenSP
        FROM SanPham
        WHERE TrangThai = 1
        ORDER BY TenSP";

            DataTable dt = kt.GetData(sql);

            LoadSanPhamCombo(cmb_SanPham1, dt);
            LoadSanPhamCombo(cmb_SanPham2, dt);
        }

        private void LoadSanPhamCombo(
            Guna.UI2.WinForms.Guna2ComboBox combo,
            DataTable dt)
        {
            combo.DataSource = null;
            combo.DataSource = dt.Copy();
            combo.DisplayMember = "TenSP";
            combo.ValueMember = "MaSP";
            combo.SelectedIndex = -1;
            combo.ForeColor = Color.Black;
        }

        private void ClearForm()
        {
            cmb_NhaCungCap.SelectedIndex = -1;
            cmb_Kho.SelectedIndex = -1;
            cmb_NhanVien.SelectedIndex = -1;

            dtp_NgayNhap.Value = DateTime.Now;

            cmb_SanPham1.SelectedIndex = -1;
            cmb_SanPham2.SelectedIndex = -1;

            guna2ComboBox4.SelectedIndex = -1;
            guna2ComboBox5.SelectedIndex = -1;
            guna2ComboBox6.SelectedIndex = -1;
            txtDonGia1.Text = "";

            guna2ComboBox8.SelectedIndex = -1;
            guna2ComboBox9.SelectedIndex = -1;
            guna2ComboBox10.SelectedIndex = -1;
            txtDonGia2.Text = "";

            GNc_ChoDuyet.Text = "Chờ duyệt";
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

            if (cmb_SanPham1.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm dòng 1.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmb_SanPham1.Focus();
                return false;
            }

            string tenSP = cmb_SanPham1.Text.Trim();

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
                txtDonGia1.Text.Trim(),
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

            // Dòng 2 để trống thì bỏ qua
            if (cmb_SanPham2.SelectedIndex == -1)
                return true;

            string tenSP = cmb_SanPham2.Text.Trim();

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
                txtDonGia2.Text.Trim(),
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
        private void TinhThanhTien1()
        {
            if (guna2ComboBox6.SelectedIndex == -1 ||
                !decimal.TryParse(txtDonGia1.Text.Trim(), out decimal donGia))
            {
                lblThanhTien1.Text = "Thành tiền: 0 VNĐ";
                return;
            }

            int soLuong = Convert.ToInt32(guna2ComboBox6.SelectedItem);
            decimal thanhTien = soLuong * donGia;

            lblThanhTien1.Text =
                "Thành tiền: " + thanhTien.ToString("N0") + " VNĐ";
        }

        private void TinhThanhTien2()
        {
            if (guna2ComboBox10.SelectedIndex == -1 ||
                !decimal.TryParse(txtDonGia2.Text.Trim(), out decimal donGia))
            {
                lblThanhTien2.Text = "Thành tiền: 0 VNĐ";
                return;
            }

            int soLuong = Convert.ToInt32(guna2ComboBox10.SelectedItem);
            decimal thanhTien = soLuong * donGia;

            lblThanhTien2.Text =
                "Thành tiền: " + thanhTien.ToString("N0") + " VNĐ";
        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhThanhTien1();
            CapNhatTongTien();
        }

        private void txtDonGia1_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien1();
            CapNhatTongTien();
        }

        private void guna2ComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhThanhTien2();
            CapNhatTongTien();
        }

        private void txtDonGia2_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien2();
            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;

            // Dòng 1
            if (guna2ComboBox6.SelectedIndex != -1 &&
                decimal.TryParse(txtDonGia1.Text.Trim(), out decimal donGia1))
            {
                int soLuong1 = Convert.ToInt32(guna2ComboBox6.SelectedItem);
                tongTien += soLuong1 * donGia1;
            }

            // Dòng 2
            if (guna2ComboBox10.SelectedIndex != -1 &&
                decimal.TryParse(txtDonGia2.Text.Trim(), out decimal donGia2))
            {
                int soLuong2 = Convert.ToInt32(guna2ComboBox10.SelectedItem);
                tongTien += soLuong2 * donGia2;
            }

            lblThanhTien2.Text =
                "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
        }

        private void InitializeComponent()
        {
            this.GNcmbNhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSPORTSHOP = new System.Windows.Forms.Label();
            this.lblPhieuNhap = new System.Windows.Forms.Label();
            this.lblNCC = new System.Windows.Forms.Label();
            this.lblKho = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.GNcmbKho = new Guna.UI2.WinForms.Guna2ComboBox();
            this.GNdtpNgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GNcmbNhaCungCap
            // 
            this.GNcmbNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.GNcmbNhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GNcmbNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GNcmbNhaCungCap.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmbNhaCungCap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmbNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GNcmbNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.GNcmbNhaCungCap.ItemHeight = 30;
            this.GNcmbNhaCungCap.Location = new System.Drawing.Point(12, 119);
            this.GNcmbNhaCungCap.Name = "GNcmbNhaCungCap";
            this.GNcmbNhaCungCap.Size = new System.Drawing.Size(214, 36);
            this.GNcmbNhaCungCap.TabIndex = 5;
            // 
            // lblSPORTSHOP
            // 
            this.lblSPORTSHOP.AutoSize = true;
            this.lblSPORTSHOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.lblSPORTSHOP.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPORTSHOP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(59)))));
            this.lblSPORTSHOP.Location = new System.Drawing.Point(5, 5);
            this.lblSPORTSHOP.Name = "lblSPORTSHOP";
            this.lblSPORTSHOP.Size = new System.Drawing.Size(171, 38);
            this.lblSPORTSHOP.TabIndex = 0;
            this.lblSPORTSHOP.Text = "SPORTSHOP";
            // 
            // lblPhieuNhap
            // 
            this.lblPhieuNhap.AutoSize = true;
            this.lblPhieuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.lblPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhieuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(169)))), ((int)(((byte)(59)))));
            this.lblPhieuNhap.Location = new System.Drawing.Point(7, 43);
            this.lblPhieuNhap.Name = "lblPhieuNhap";
            this.lblPhieuNhap.Size = new System.Drawing.Size(145, 25);
            this.lblPhieuNhap.TabIndex = 1;
            this.lblPhieuNhap.Text = "Phiếu nhập hàng";
            // 
            // lblNCC
            // 
            this.lblNCC.AutoSize = true;
            this.lblNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.lblNCC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNCC.ForeColor = System.Drawing.Color.LightGray;
            this.lblNCC.Location = new System.Drawing.Point(7, 86);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(129, 25);
            this.lblNCC.TabIndex = 2;
            this.lblNCC.Text = "Nhà cung cấp";
            // 
            // lblKho
            // 
            this.lblKho.AutoSize = true;
            this.lblKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.lblKho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKho.ForeColor = System.Drawing.Color.LightGray;
            this.lblKho.Location = new System.Drawing.Point(246, 86);
            this.lblKho.Name = "lblKho";
            this.lblKho.Size = new System.Drawing.Size(141, 25);
            this.lblKho.TabIndex = 2;
            this.lblKho.Text = "Kho nhận hàng";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.lblNgayNhap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhap.ForeColor = System.Drawing.Color.LightGray;
            this.lblNgayNhap.Location = new System.Drawing.Point(522, 86);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(104, 25);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày nhập";
            // 
            // GNcmbKho
            // 
            this.GNcmbKho.BackColor = System.Drawing.Color.Transparent;
            this.GNcmbKho.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GNcmbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GNcmbKho.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmbKho.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNcmbKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GNcmbKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.GNcmbKho.ItemHeight = 30;
            this.GNcmbKho.Location = new System.Drawing.Point(247, 119);
            this.GNcmbKho.Name = "GNcmbKho";
            this.GNcmbKho.Size = new System.Drawing.Size(257, 36);
            this.GNcmbKho.TabIndex = 5;
            // 
            // GNdtpNgayNhap
            // 
            this.GNdtpNgayNhap.Checked = true;
            this.GNdtpNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNdtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.GNdtpNgayNhap.Location = new System.Drawing.Point(527, 118);
            this.GNdtpNgayNhap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.GNdtpNgayNhap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.GNdtpNgayNhap.Name = "GNdtpNgayNhap";
            this.GNdtpNgayNhap.Size = new System.Drawing.Size(226, 36);
            this.GNdtpNgayNhap.TabIndex = 6;
            this.GNdtpNgayNhap.Value = new System.DateTime(2026, 9, 10, 11, 22, 36, 985);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.panel1);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Location = new System.Drawing.Point(13, 179);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(740, 100);
            this.guna2Panel1.TabIndex = 7;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderRadius = 12;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.guna2Panel2.Location = new System.Drawing.Point(3, 14);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(200, 73);
            this.guna2Panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(6, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 73);
            this.panel1.TabIndex = 0;
            // 
            // FormNhapHang
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(774, 537);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.GNdtpNgayNhap);
            this.Controls.Add(this.GNcmbNhaCungCap);
            this.Controls.Add(this.GNcmbKho);
            this.Controls.Add(this.lblSPORTSHOP);
            this.Controls.Add(this.lblPhieuNhap);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.lblKho);
            this.Controls.Add(this.lblNCC);
            this.Name = "FormNhapHang";
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}