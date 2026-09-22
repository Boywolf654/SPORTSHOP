using SPORTSHOP._06_BanHang;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormDonOnline : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private int maDonOnlineDangChon;
        private string trangThaiDangChon;

        public FormDonOnline()
        {
            InitializeComponent();
            CauHinhGiaoDien();
        }

        private void CauHinhGiaoDien()
        {
            btnRaDon.Text = "✓  RA ĐƠN";
            btnRaDon.BackColor = Color.FromArgb(27, 142, 62);
            CapNhatTrangThaiNut(false);
        }

        private void FormDonOnline_Load(object sender, EventArgs e)
        {
            // Đơn online là nghiệp vụ bán hàng của nhân viên:
            // bắt buộc phải có ca đang hoạt động.
            if (Session.MaNV <= 0 || !QuanLyCa1.KiemTraCaDangLam())
            {
                MessageBox.Show(
                    QuanLyCa1.ThongBaoChuaCoCa() +
                    "\n\nHãy vào ca trước khi xử lý đơn online.",
                    "CHƯA VÀO CA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            TaoCotDanhSach();
            TaoCotChiTiet();
            LoadDonOnline();
        }

        private void TaoCotDanhSach()
        {
            dgvDonOnline.Columns.Clear();
            dgvDonOnline.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMaDon", HeaderText = "MÃ ĐƠN", Width = 90 });
            dgvDonOnline.Columns.Add(new DataGridViewTextBoxColumn { Name = "colKhachHang", HeaderText = "KHÁCH HÀNG", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDonOnline.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTongTien", HeaderText = "THÀNH TIỀN", Width = 125 });
            dgvDonOnline.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhuongThuc", HeaderText = "THANH TOÁN", Width = 125 });
            dgvDonOnline.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTrangThai", HeaderText = "TRẠNG THÁI", Width = 125 });
            dgvDonOnline.AllowUserToAddRows = false;
            dgvDonOnline.ReadOnly = true;
            dgvDonOnline.RowHeadersVisible = false;
            dgvDonOnline.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonOnline.MultiSelect = false;
        }

        private void TaoCotChiTiet()
        {
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTenSP", HeaderText = "SẢN PHẨM", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSize", HeaderText = "SIZE", Width = 65 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMau", HeaderText = "MÀU", Width = 80 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSoLuong", HeaderText = "SL", Width = 55 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDonGia", HeaderText = "ĐƠN GIÁ", Width = 115 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTien", HeaderText = "THÀNH TIỀN", Width = 125 });
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersVisible = false;
        }

        private void LoadDonOnline()
        {
            try
            {
                string sql = @"
SELECT
    d.MaDonOnline,
    kh.HoTen AS KhachHang,
    d.TongTienHang,
    d.TienGiam,
    d.PhiVanChuyen,
    d.PhuongThucThanhToan,
    d.TrangThai
FROM DonOnline d
INNER JOIN KhachHang kh ON kh.MaKH=d.MaKH
WHERE d.TrangThai IN (N'Chờ thanh toán',N'Đã thanh toán',N'NV tiếp nhận')
ORDER BY d.MaDonOnline DESC";
                DataTable dt = kt.GetData(sql);
                dgvDonOnline.Rows.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    decimal tong = Convert.ToDecimal(r["TongTienHang"]) - Convert.ToDecimal(r["TienGiam"]) + Convert.ToDecimal(r["PhiVanChuyen"]);
                    int i = dgvDonOnline.Rows.Add(
                        "DO" + Convert.ToInt32(r["MaDonOnline"]).ToString("D4"),
                        r["KhachHang"],
                        tong.ToString("N0") + " đ",
                        r["PhuongThucThanhToan"],
                        r["TrangThai"]);
                    dgvDonOnline.Rows[i].Tag = Convert.ToInt32(r["MaDonOnline"]);
                }
                lblSoDon.Text = dgvDonOnline.Rows.Count + " đơn online chờ xử lý";
                XoaChiTiet();
                CapNhatTrangThaiNut(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải đơn online.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvDonOnline.Rows)
            {
                string ma = Convert.ToString(row.Cells["colMaDon"].Value).ToLower();
                string ten = Convert.ToString(row.Cells["colKhachHang"].Value).ToLower();
                row.Visible = string.IsNullOrWhiteSpace(key) || ma.Contains(key) || ten.Contains(key);
            }
        }

        private void dgvDonOnline_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvDonOnline.Rows[e.RowIndex];
            if (row.Tag == null) return;
            maDonOnlineDangChon = Convert.ToInt32(row.Tag);
            trangThaiDangChon = Convert.ToString(row.Cells["colTrangThai"].Value);
            LoadChiTietDon();
            CapNhatTrangThaiNut(true);
        }

        private void LoadChiTietDon()
        {
            string sql = @"
SELECT TOP 1
    d.MaDonOnline,d.TrangThai,d.PhuongThucThanhToan,d.NgayTao,
    d.TongTienHang,d.TienGiam,d.PhiVanChuyen,
    kh.HoTen,kh.SDT,
    dc.NguoiNhan,dc.SDT AS SDTNhan,dc.DiaChiCuThe,dc.TinhThanh
FROM DonOnline d
INNER JOIN KhachHang kh ON kh.MaKH=d.MaKH
LEFT JOIN DiaChiKhachHang dc ON dc.MaDiaChi=d.MaDiaChi
WHERE d.MaDonOnline=@MaDonOnline";
            DataTable h = kt.GetData(sql, new[] { new SqlParameter("@MaDonOnline", maDonOnlineDangChon) });
            if (h.Rows.Count == 0) { XoaChiTiet(); return; }
            DataRow r = h.Rows[0];
            lblMaDon.Text = "DO" + maDonOnlineDangChon.ToString("D4");
            lblKhachHang.Text = Convert.ToString(r["HoTen"]);
            lblSDT.Text = Convert.ToString(r["SDT"]);
            lblDiaChi.Text = Convert.ToString(r["NguoiNhan"]) + " - " + Convert.ToString(r["SDTNhan"]) + "\n" + Convert.ToString(r["DiaChiCuThe"]) + (r["TinhThanh"] == DBNull.Value ? "" : ", " + Convert.ToString(r["TinhThanh"]));
            lblThanhToan.Text = Convert.ToString(r["PhuongThucThanhToan"]);
            lblNgay.Text = Convert.ToDateTime(r["NgayTao"]).ToString("dd/MM/yyyy HH:mm");
            lblTrangThai.Text = Convert.ToString(r["TrangThai"]).ToUpper();
            lblTienHang.Text = Convert.ToDecimal(r["TongTienHang"]).ToString("N0") + " đ";
            lblGiam.Text = Convert.ToDecimal(r["TienGiam"]).ToString("N0") + " đ";
            lblShip.Text = Convert.ToDecimal(r["PhiVanChuyen"]).ToString("N0") + " đ";
            lblThanhTien.Text = (Convert.ToDecimal(r["TongTienHang"]) - Convert.ToDecimal(r["TienGiam"]) + Convert.ToDecimal(r["PhiVanChuyen"])).ToString("N0") + " đ";

            string detail = @"
SELECT sp.TenSP,s.TenSize AS Size,ISNULL(m.TenMau,'') AS Mau,ct.SoLuong,ct.DonGia,ct.SoLuong*ct.DonGia AS ThanhTien
FROM ChiTietDonOnline ct
INNER JOIN BienTheSanPham bt ON bt.MaBienThe=ct.MaBienThe
INNER JOIN SanPham sp ON sp.MaSP=bt.MaSP
INNER JOIN Size s ON s.MaSize=bt.MaSize
LEFT JOIN MauSac m ON m.MaMau=bt.MaMau
WHERE ct.MaDonOnline=@MaDonOnline
ORDER BY sp.TenSP,s.TenSize";
            DataTable dt = kt.GetData(detail, new[] { new SqlParameter("@MaDonOnline", maDonOnlineDangChon) });
            dgvChiTiet.Rows.Clear();
            foreach (DataRow x in dt.Rows)
                dgvChiTiet.Rows.Add(x["TenSP"], x["Size"], x["Mau"], x["SoLuong"], Convert.ToDecimal(x["DonGia"]).ToString("N0"), Convert.ToDecimal(x["ThanhTien"]).ToString("N0"));
        }

        private void CapNhatTrangThaiNut(bool coDon)
        {
            bool coTheXuLy = coDon &&
                (trangThaiDangChon == "Chờ thanh toán" ||
                 trangThaiDangChon == "Đã thanh toán" ||
                 trangThaiDangChon == "NV tiếp nhận");

            // Xóa vẫn cho phép với đơn chưa ra đơn.
            btnXoaDon.Enabled = coTheXuLy;
            btnInDon.Enabled = coDon;

            // Chỉ đơn ĐÃ THANH TOÁN mới được phép RA ĐƠN.
            // Không mở FormThanhToan ở đây vì tiền đã được xử lý
            // ở bước checkout của khách hàng.
            bool coCaDangLam = QuanLyCa1.KiemTraCaDangLam();

            btnRaDon.Enabled =
                coDon &&
                trangThaiDangChon == "Đã thanh toán" &&
                coCaDangLam;

            btnRaDon.Text = coCaDangLam
                ? "✓  RA ĐƠN"
                : "🔒  VÀO CA ĐỂ RA ĐƠN";
        }

        private void btnRaDon_Click(object sender, EventArgs e)
        {
            if (maDonOnlineDangChon <= 0)
                return;

            if (Session.MaNV <= 0)
            {
                MessageBox.Show(
                    "Không xác định được nhân viên đang đăng nhập.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!QuanLyCa1.KiemTraCaDangLam())
            {
                MessageBox.Show(
                    QuanLyCa1.ThongBaoChuaCoCa() +
                    "\n\nHãy vào ca trước khi ra đơn.",
                    "Không thể ra đơn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(trangThaiDangChon, "Đã thanh toán", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Đơn này chưa ở trạng thái Đã thanh toán nên chưa thể ra đơn.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraKhachHangDangGiaoDich())
                return;

            DialogResult confirm = MessageBox.Show(
                "Xác nhận RA ĐƠN cho DO" + maDonOnlineDangChon.ToString("D4") + "?\n\n" +
                "Nhân viên: NV" + Session.MaNV.ToString("D4") + "\n" +
                "Ca làm việc: CA" + Session.MaCa.ToString("D4") + "\n\n" +
                "Hệ thống sẽ:\n" +
                "• Tạo hóa đơn và chi tiết hóa đơn\n" +
                "• Trừ tồn kho theo từng biến thể\n" +
                "• Ghi lịch sử xuất kho\n" +
                "• Chuyển đơn online thành Đã ra đơn",
                "Xác nhận ra đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                int maHD = TaoHoaDonTuDonOnline();

                MessageBox.Show(
                    "Ra đơn thành công!\n\n" +
                    "Mã hóa đơn: HD" + maHD.ToString("D5") + "\n" +
                    "Mã ca: CA" + Session.MaCa.ToString("D4"),
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                using (FormHoaDon frm = new FormHoaDon(maHD))
                {
                    frm.ShowDialog(this);
                }

                LoadDonOnline();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ra đơn thất bại.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tạo HoaDon + ChiTietHoaDon từ DonOnline đã thanh toán.
        /// Không trừ Ví ở đây vì khách đã thanh toán online trước đó.
        /// </summary>
        private bool KiemTraKhachHangDangGiaoDich()
        {
            if (maDonOnlineDangChon <= 0)
                return false;

            try
            {
                object result = kt.ExecuteScalar(
                    @"SELECT TOP 1 kh.TrangThai
                      FROM DonOnline d
                      INNER JOIN KhachHang kh ON kh.MaKH=d.MaKH
                      WHERE d.MaDonOnline=@MaDonOnline",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaDonOnline", maDonOnlineDangChon)
                    });

                bool dangGiaoDich =
                    result == null ||
                    result == DBNull.Value ||
                    Convert.ToBoolean(result);

                if (!dangGiaoDich)
                {
                    MessageBox.Show(
                        "Khách hàng của đơn này đã ngừng giao dịch.\n\n" +
                        "Không thể RA ĐƠN cho đến khi khách hàng được mở lại giao dịch.",
                        "Không thể ra đơn",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kiểm tra trạng thái khách hàng.\n\n" + ex.Message,
                    "Không thể ra đơn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        private int TaoHoaDonTuDonOnline()
        {
            using (SqlConnection conn = kt.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (!QuanLyCa1.KiemTraCaDangLam(conn, tran))
                        {
                            throw new Exception(
                                "Ca làm việc đã kết thúc hoặc không còn hoạt động. " +
                                "Không thể ra đơn.");
                        }


                        int maKH;
                        decimal tongTien;
                        string phuongThuc;
                        string trangThai;

                        // 1. Khóa đơn để tránh 2 nhân viên cùng ra đơn.
                        DataTable don = new DataTable();
                        using (SqlCommand cmd = new SqlCommand(@"
SELECT TOP 1 *
FROM DonOnline WITH (UPDLOCK, ROWLOCK)
WHERE MaDonOnline=@MaDonOnline", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnlineDangChon);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                da.Fill(don);
                        }

                        if (don.Rows.Count == 0)
                            throw new Exception("Không tìm thấy đơn online.");

                        DataRow d = don.Rows[0];
                        maKH = Convert.ToInt32(d["MaKH"]);

                        // Kiểm tra lại trạng thái khách hàng ngay trong transaction.
                        // Nếu khách vừa bị ngừng giao dịch sau khi form được mở,
                        // hóa đơn vẫn không được tạo.
                        using (SqlCommand cmd = new SqlCommand(
                            @"SELECT TrangThai
                              FROM KhachHang WITH (UPDLOCK, ROWLOCK)
                              WHERE MaKH=@MaKH", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", maKH);
                            object trangThaiObj = cmd.ExecuteScalar();

                            if (trangThaiObj == null || trangThaiObj == DBNull.Value)
                                throw new Exception("Không tìm thấy khách hàng của đơn online.");

                            if (!Convert.ToBoolean(trangThaiObj))
                                throw new Exception(
                                    "Khách hàng đã ngừng giao dịch. Không thể ra đơn.");
                        }

                        tongTien = Convert.ToDecimal(d["TongTienHang"])
                                   - Convert.ToDecimal(d["TienGiam"])
                                   + Convert.ToDecimal(d["PhiVanChuyen"]);
                        if (tongTien < 0) tongTien = 0;

                        phuongThuc = d["PhuongThucThanhToan"] == DBNull.Value
                            ? ""
                            : Convert.ToString(d["PhuongThucThanhToan"]);
                        trangThai = Convert.ToString(d["TrangThai"]);

                        if (!string.Equals(trangThai, "Đã thanh toán", StringComparison.OrdinalIgnoreCase))
                            throw new Exception("Đơn không còn ở trạng thái Đã thanh toán.");

                        // 2. Chặn tạo hóa đơn trùng cho cùng đơn online.
                        using (SqlCommand cmd = new SqlCommand(
                            "SELECT TOP 1 MaHD FROM HoaDon WHERE MaDonOnline=@MaDonOnline",
                            conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnlineDangChon);
                            object existed = cmd.ExecuteScalar();
                            if (existed != null && existed != DBNull.Value)
                                throw new Exception("Đơn này đã có hóa đơn HD" + Convert.ToInt32(existed).ToString("D5") + ".");
                        }

                        // 3. Lấy chi tiết đơn.
                        DataTable chiTiet = new DataTable();
                        using (SqlCommand cmd = new SqlCommand(@"
SELECT MaBienThe, SoLuong, DonGia
FROM ChiTietDonOnline
WHERE MaDonOnline=@MaDonOnline
ORDER BY MaBienThe", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnlineDangChon);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                da.Fill(chiTiet);
                        }

                        if (chiTiet.Rows.Count == 0)
                            throw new Exception("Đơn online không có sản phẩm.");

                        // 4. Kiểm tra tồn kho trước khi tạo hóa đơn.
                        foreach (DataRow row in chiTiet.Rows)
                        {
                            int maBienThe = Convert.ToInt32(row["MaBienThe"]);
                            int soLuong = Convert.ToInt32(row["SoLuong"]);

                            using (SqlCommand cmd = new SqlCommand(@"
SELECT SoLuong
FROM BienTheSanPham WITH (UPDLOCK, ROWLOCK)
WHERE MaBienThe=@MaBienThe", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                                object stock = cmd.ExecuteScalar();

                                if (stock == null || stock == DBNull.Value)
                                    throw new Exception("Không tìm thấy tồn kho BT" + maBienThe.ToString("D4") + ".");

                                int ton = Convert.ToInt32(stock);
                                if (ton < soLuong)
                                {
                                    throw new Exception(
                                        "BT" + maBienThe.ToString("D4") +
                                        " không đủ tồn kho.\nTồn hiện tại: " + ton +
                                        "\nCần bán: " + soLuong);
                                }
                            }
                        }

                        // 5. Tạo hóa đơn, gắn NV + CA.
                        int maHD;
                        string sqlHoaDon = @"
INSERT INTO HoaDon
(
    MaNV,
    MaKH,
    MaDonOnline,
    MaCa,
    NgayLap,
    TongTien,
    TrangThaiDonHang
)
OUTPUT INSERTED.MaHD
VALUES
(
    @MaNV,
    @MaKH,
    @MaDonOnline,
    @MaCa,
    GETDATE(),
    @TongTien,
    N'Hoàn thành'
)";

                        using (SqlCommand cmd = new SqlCommand(sqlHoaDon, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", Session.MaNV);
                            cmd.Parameters.AddWithValue("@MaKH", maKH);
                            cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnlineDangChon);
                            cmd.Parameters.AddWithValue("@MaCa", Session.MaCa);
                            AddDecimal(cmd, "@TongTien", tongTien);
                            maHD = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 6. Tạo chi tiết hóa đơn.
                        foreach (DataRow row in chiTiet.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO ChiTietHoaDon
(
    MaHD, MaBienThe, SoLuong, DonGia
)
VALUES
(
    @MaHD, @MaBienThe, @SoLuong, @DonGia
)", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaHD", maHD);
                                cmd.Parameters.AddWithValue("@MaBienThe", Convert.ToInt32(row["MaBienThe"]));
                                cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row["SoLuong"]));
                                AddDecimal(cmd, "@DonGia", Convert.ToDecimal(row["DonGia"]));
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 7. Ghi phương thức thanh toán của hóa đơn.
                        using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO ThanhToan
(
    MaHD,
    PhuongThuc,
    TrangThai,
    NgayThanhToan
)
VALUES
(
    @MaHD,
    @PhuongThuc,
    N'Đã thanh toán',
    GETDATE()
)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maHD);
                            cmd.Parameters.Add("@PhuongThuc", SqlDbType.NVarChar, 50).Value =
                                string.IsNullOrWhiteSpace(phuongThuc) ? "Online" : phuongThuc;
                            cmd.ExecuteNonQuery();
                        }

                        // 8. Trừ tồn kho + cập nhật TonKho + lịch sử.
                        foreach (DataRow row in chiTiet.Rows)
                        {
                            int maBienThe = Convert.ToInt32(row["MaBienThe"]);
                            int soLuong = Convert.ToInt32(row["SoLuong"]);

                            using (SqlCommand cmd = new SqlCommand(@"
UPDATE BienTheSanPham
SET SoLuong = SoLuong - @SoLuong
WHERE MaBienThe=@MaBienThe
  AND SoLuong >= @SoLuong", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception("Không thể trừ tồn kho BT" + maBienThe.ToString("D4") + ".");
                            }

                            using (SqlCommand cmd = new SqlCommand(@"
UPDATE TonKho
SET
    SLTon = SLTon - @SoLuong,
    TongSLXuat = TongSLXuat + @SoLuong
WHERE MaTonKho =
(
    SELECT TOP 1 MaTonKho
    FROM TonKho
    WHERE MaBienThe=@MaBienThe
      AND SLTon >= @SoLuong
    ORDER BY MaKho
)", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand(@"
INSERT INTO LichSuTonKho
(
    MaBienThe,
    ThayDoi,
    Loai,
    MaTK,
    ThoiGian
)
VALUES
(
    @MaBienThe,
    -@SoLuong,
    N'Bán hàng',
    @MaTK,
    GETDATE()
)", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaBienThe", maBienThe);
                                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                                cmd.Parameters.AddWithValue("@MaTK", Session.MaTK);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 9. Chuyển đơn online thành Đã ra đơn.
                        using (SqlCommand cmd = new SqlCommand(@"
UPDATE DonOnline
SET
    TrangThai=N'Đã ra đơn',
    NgayCapNhat=GETDATE(),
    MaNV=@MaNV
WHERE MaDonOnline=@MaDonOnline
  AND TrangThai=N'Đã thanh toán'", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", Session.MaNV);
                            cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnlineDangChon);

                            if (cmd.ExecuteNonQuery() != 1)
                                throw new Exception("Không thể chuyển trạng thái đơn online sang Đã ra đơn.");
                        }

                        tran.Commit();
                        return maHD;
                    }
                    catch
                    {
                        try { tran.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        private void btnXoaDon_Click(object sender, EventArgs e)
        {
            if (maDonOnlineDangChon <= 0) return;
            DialogResult ok = MessageBox.Show(
                "Hủy đơn DO" + maDonOnlineDangChon.ToString("D4") + "?\n\n" +
                "Nếu đơn đã thanh toán bằng Ví điện tử, số tiền sẽ được hoàn lại vào ví trong cùng transaction.\n" +
                "Nếu thanh toán bằng thẻ/chuyển khoản, hệ thống chỉ ghi nhận hủy/hoàn tiền; không thể tự chuyển tiền qua ngân hàng trong bản demo.",
                "Xác nhận hủy đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (ok != DialogResult.Yes) return;

            try
            {
                HuyDonVaHoanTien();
                MessageBox.Show("Đã hủy đơn thành công.", "Đơn Online", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDonOnline();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hủy đơn.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HuyDonVaHoanTien()
        {
            using (SqlConnection conn = kt.GetConnection())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        DataTable t = new DataTable();
                        using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 * FROM DonOnline WITH (UPDLOCK,ROWLOCK) WHERE MaDonOnline=@MaDonOnline", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnlineDangChon);
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) da.Fill(t);
                        }
                        if (t.Rows.Count == 0) throw new Exception("Không tìm thấy đơn.");
                        DataRow r = t.Rows[0];
                        string status = Convert.ToString(r["TrangThai"]);
                        if (status == "Đã hủy") throw new Exception("Đơn đã hủy.");
                        if (status == "Đã ra đơn") throw new Exception("Đơn đã ra đơn, không thể hủy tại đây.");

                        string method = r["PhuongThucThanhToan"] == DBNull.Value ? "" : Convert.ToString(r["PhuongThucThanhToan"]);
                        int maKH = Convert.ToInt32(r["MaKH"]);
                        decimal soTien = Convert.ToDecimal(r["TongTienHang"]) - Convert.ToDecimal(r["TienGiam"]) + Convert.ToDecimal(r["PhiVanChuyen"]);
                        if (soTien < 0) soTien = 0;

                        if (status == "Đã thanh toán" && method == "Ví điện tử")
                            HoanTienVi(conn, tran, maKH, soTien);

                        if (r.Table.Columns.Contains("MaVoucher") && r["MaVoucher"] != DBNull.Value)
                        {
                            using (SqlCommand v = new SqlCommand("UPDATE Voucher SET DaSuDung=CASE WHEN DaSuDung>0 THEN DaSuDung-1 ELSE 0 END WHERE MaVoucher=@MaVoucher", conn, tran))
                            { v.Parameters.AddWithValue("@MaVoucher", r["MaVoucher"]); v.ExecuteNonQuery(); }
                        }

                        using (SqlCommand cmd = new SqlCommand(@"UPDATE DonOnline SET TrangThai=N'Đã hủy', NgayCapNhat=GETDATE() WHERE MaDonOnline=@MaDonOnline AND TrangThai<>N'Đã ra đơn'", conn, tran))
                        { cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnlineDangChon); if (cmd.ExecuteNonQuery() != 1) throw new Exception("Đơn vừa thay đổi trạng thái."); }

                        tran.Commit();
                    }
                    catch { try { tran.Rollback(); } catch { } throw; }
                }
            }
        }

        private void HoanTienVi(SqlConnection conn, SqlTransaction tran, int maKH, decimal soTien)
        {
            int maVi; decimal truoc;
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaVi,SoDu FROM ViDienTu WITH (UPDLOCK,ROWLOCK) WHERE MaKH=@MaKH", conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                using (SqlDataReader rd = cmd.ExecuteReader()) { if (!rd.Read()) throw new Exception("Khách hàng không có ví để hoàn tiền."); maVi = Convert.ToInt32(rd["MaVi"]); truoc = Convert.ToDecimal(rd["SoDu"]); }
            }
            decimal sau = truoc + soTien;
            using (SqlCommand cmd = new SqlCommand("UPDATE ViDienTu SET SoDu=@Sau,NgayCapNhat=GETDATE() WHERE MaVi=@MaVi", conn, tran))
            { cmd.Parameters.AddWithValue("@MaVi", maVi); AddDecimal(cmd, "@Sau", sau); cmd.ExecuteNonQuery(); }

            bool coMaDon = CoCot(conn, tran, "GiaoDichVi", "MaDonOnline");
            string sql = coMaDon
                ? @"INSERT INTO GiaoDichVi(MaVi,LoaiGD,SoTien,SoDuTruoc,SoDuSau,NoiDung,MaDonOnline,ThoiGian) VALUES(@MaVi,N'Hoàn tiền',@Tien,@Truoc,@Sau,N'Hoàn tiền hủy đơn online',@MaDon,GETDATE())"
                : @"INSERT INTO GiaoDichVi(MaVi,LoaiGD,SoTien,SoDuTruoc,SoDuSau,NoiDung) VALUES(@MaVi,N'Hoàn tiền',@Tien,@Truoc,@Sau,N'Hoàn tiền hủy đơn online')";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            { cmd.Parameters.AddWithValue("@MaVi", maVi); AddDecimal(cmd, "@Tien", soTien); AddDecimal(cmd, "@Truoc", truoc); AddDecimal(cmd, "@Sau", sau); if (coMaDon) cmd.Parameters.AddWithValue("@MaDon", maDonOnlineDangChon); cmd.ExecuteNonQuery(); }
        }

        private bool CoCot(SqlConnection conn, SqlTransaction tran, string table, string column)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT CASE WHEN COL_LENGTH('dbo.'+@Table,@Column) IS NULL THEN 0 ELSE 1 END", conn, tran))
            { cmd.Parameters.AddWithValue("@Table", table); cmd.Parameters.AddWithValue("@Column", column); return Convert.ToInt32(cmd.ExecuteScalar()) == 1; }
        }
        private void AddDecimal(SqlCommand cmd, string name, decimal value) { SqlParameter p = cmd.Parameters.Add(name, SqlDbType.Decimal); p.Precision = 18; p.Scale = 2; p.Value = value; }

        private void btnInDon_Click(object sender, EventArgs e)
        {
            if (maDonOnlineDangChon <= 0) return;

            try
            {
                DataTable dt = kt.GetData(
                    "SELECT TOP 1 MaHD FROM HoaDon WHERE MaDonOnline=@MaDonOnline ORDER BY MaHD DESC",
                    new[] { new SqlParameter("@MaDonOnline", maDonOnlineDangChon) });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Đơn này chưa được ra đơn nên chưa có hóa đơn để in.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                int maHD = Convert.ToInt32(dt.Rows[0]["MaHD"]);
                using (FormHoaDon frm = new FormHoaDon(maHD))
                    frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở hóa đơn.\n\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LoadDonOnline();

        private void XoaChiTiet()
        {
            dgvChiTiet.Rows.Clear();
            lblMaDon.Text = "—"; lblKhachHang.Text = "—"; lblSDT.Text = "—"; lblDiaChi.Text = "—"; lblThanhToan.Text = "—"; lblNgay.Text = "—"; lblTrangThai.Text = "—";
            lblTienHang.Text = "0 đ"; lblGiam.Text = "0 đ"; lblShip.Text = "0 đ"; lblThanhTien.Text = "0 đ";
            maDonOnlineDangChon = 0; trangThaiDangChon = "";
        }
    }
}
