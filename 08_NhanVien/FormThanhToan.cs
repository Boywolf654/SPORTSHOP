using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class FormThanhToan : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maDonOnline;
        private decimal tongTien;
        private decimal soDuVi;

        public int MaHoaDonDaTao { get; private set; }
        public bool DaXuLyThanhCong { get; private set; }

        public FormThanhToan(int maDonOnline)
        {
            this.maDonOnline = maDonOnline;
            InitializeComponent();
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            LoadDonHang();
            LoadVi();

            // Không cho nhân viên đã ra ca tiếp tục dùng form đang mở.
            if (!QuanLyCa1.KiemTraCaDangLam())
            {
                btnXacNhan.Enabled = false;

                MessageBox.Show(
                    QuanLyCa1.ThongBaoChuaCoCa() +
                    "\n\nForm thanh toán đã bị khóa.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void LoadDonHang()
        {
            try
            {
                string sql = @"
SELECT TOP 1
    d.MaDonOnline,
    d.NgayDat,
    d.TongTien,
    d.MaKH,
    kh.HoTen,
    kh.SDT,
    kh.Email,
    d.TrangThai
FROM DonOnline d
LEFT JOIN KhachHang kh ON kh.MaKH = d.MaKH
WHERE d.MaDonOnline=@MaDonOnline;";

                DataTable dt = kt.GetData(sql, new SqlParameter[] { new SqlParameter("@MaDonOnline", maDonOnline) });

                if (dt.Rows.Count == 0)
                    throw new Exception("Không tìm thấy đơn hàng.");

                DataRow r = dt.Rows[0];
                tongTien = Convert.ToDecimal(r["TongTien"]);

                lblMaDonValue.Text = "DO" + maDonOnline.ToString("D5");
                lblKhachValue.Text = r["HoTen"] == DBNull.Value ? "Khách hàng" : r["HoTen"].ToString();
                lblSDTValue.Text = r["SDT"] == DBNull.Value ? "—" : r["SDT"].ToString();
                lblNgayValue.Text = Convert.ToDateTime(r["NgayDat"]).ToString("dd/MM/yyyy HH:mm");
                lblTrangThaiValue.Text = r["TrangThai"] == DBNull.Value ? "Chờ thanh toán" : r["TrangThai"].ToString();

                lblTongTienValue.Text = tongTien.ToString("N0") + " đ";
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải đơn hàng.\n\n" + ex.Message,
                    "SPORTSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPham()
        {
            string sql = @"
SELECT
    c.MaBienThe,
    sp.TenSP,
    sz.TenSize,
    ms.TenMau,
    c.SoLuong,
    c.DonGia,
    c.SoLuong*c.DonGia AS ThanhTien
FROM ChiTietDonOnline c
INNER JOIN BienTheSanPham bt ON bt.MaBienThe=c.MaBienThe
INNER JOIN SanPham sp ON sp.MaSP=bt.MaSP
LEFT JOIN Size sz ON sz.MaSize=bt.MaSize
LEFT JOIN MauSac ms ON ms.MaMau=bt.MaMau
WHERE c.MaDonOnline=@MaDonOnline
ORDER BY c.MaBienThe;";

            DataTable dt = kt.GetData(sql, new SqlParameter[] { new SqlParameter("@MaDonOnline", maDonOnline) });

            dgvSanPham.Rows.Clear();

            int tongSL = 0;
            foreach (DataRow r in dt.Rows)
            {
                int i = dgvSanPham.Rows.Add();
                int sl = Convert.ToInt32(r["SoLuong"]);
                decimal gia = Convert.ToDecimal(r["DonGia"]);
                decimal tien = Convert.ToDecimal(r["ThanhTien"]);

                dgvSanPham.Rows[i].Cells["colSTT"].Value = i + 1;
                dgvSanPham.Rows[i].Cells["colSanPham"].Value = r["TenSP"].ToString();
                dgvSanPham.Rows[i].Cells["colBienThe"].Value = "BT" + Convert.ToInt32(r["MaBienThe"]).ToString("D4");
                dgvSanPham.Rows[i].Cells["colPhanLoai"].Value =
                    (r["TenSize"] == DBNull.Value ? "" : r["TenSize"].ToString())
                    + " / " +
                    (r["TenMau"] == DBNull.Value ? "" : r["TenMau"].ToString());
                dgvSanPham.Rows[i].Cells["colSL"].Value = sl;
                dgvSanPham.Rows[i].Cells["colDonGia"].Value = gia.ToString("N0");
                dgvSanPham.Rows[i].Cells["colThanhTien"].Value = tien.ToString("N0");
                tongSL += sl;
            }

            lblTongSPValue.Text = tongSL + " sản phẩm";
        }

        private void LoadVi()
        {
            try
            {
                string sql = "SELECT SoDu FROM ViDienTu WHERE MaKH=(SELECT MaKH FROM DonOnline WHERE MaDonOnline=@MaDonOnline)";
                DataTable dt = kt.GetData(sql, new SqlParameter[] { new SqlParameter("@MaDonOnline", maDonOnline) });

                soDuVi = dt.Rows.Count == 0 ? 0 : Convert.ToDecimal(dt.Rows[0]["SoDu"]);
                lblSoDuValue.Text = soDuVi.ToString("N0") + " đ";
            }
            catch
            {
                soDuVi = 0;
                lblSoDuValue.Text = "—";
            }
        }

        private void PhuongThuc_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoVi.Checked)
            {
                pnlVi.Visible = false;
                lblHint.Text = "Chọn phương thức phù hợp để tiếp tục thanh toán.";
                return;
            }

            pnlVi.Visible = true;
            if (soDuVi < tongTien)
                lblHint.Text = "Số dư ví không đủ để thanh toán đơn này.";
            else
                lblHint.Text = "Số dư ví đủ. Tiền sẽ được trừ khi xác nhận.";
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!chkCheckIn.Checked)
            {
                MessageBox.Show(
                    "Vui lòng xác nhận đã check-in khách hàng trước khi thanh toán.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

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
                    "\n\nVui lòng vào ca trước khi thanh toán.",
                    "Không thể thanh toán",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (rdoVi.Checked && soDuVi < tongTien)
            {
                MessageBox.Show(
                    "Số dư ví không đủ để thanh toán.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string phuongThuc =
                rdoTienMat.Checked ? "Tiền mặt" :
                rdoThe.Checked ? "Thẻ" :
                rdoChuyenKhoan.Checked ? "Chuyển khoản" :
                "Ví điện tử";

            DialogResult xacNhan = MessageBox.Show(
                "Xác nhận thanh toán đơn hàng?\n\n" +
                "Mã đơn: DO" + maDonOnline.ToString("D5") + "\n" +
                "Tổng tiền: " + tongTien.ToString("N0") + " đ\n" +
                "Phương thức: " + phuongThuc + "\n" +
                "Nhân viên: " + Session.MaNV + "\n" +
                "Ca: " + Session.MaCa,
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                XuLyThanhToan(phuongThuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thanh toán thất bại.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void XuLyThanhToan(string phuongThuc)
        {
            using (SqlConnection conn = kt.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // Khóa kiểm tra ca ngay trong transaction.
                        // Nếu ca vừa bị kết thúc sau khi mở form,
                        // toàn bộ thanh toán sẽ bị chặn và rollback.
                        if (!QuanLyCa1.KiemTraCaDangLam(conn, tran))
                        {
                            throw new Exception(
                                "Ca làm việc đã kết thúc hoặc không còn hoạt động. " +
                                "Không thể thanh toán đơn này.");
                        }

                        // =====================================================
                        // 1. Lấy lại đơn online trong transaction
                        // =====================================================
                        int maKH;
                        decimal tongTienDon;
                        string trangThaiDon;

                        string sqlDon = @"
SELECT TOP 1
    MaKH,
    TongTien,
    TrangThai
FROM DonOnline WITH (UPDLOCK, ROWLOCK)
WHERE MaDonOnline = @MaDonOnline";

                        using (SqlCommand cmd = new SqlCommand(sqlDon, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaDonOnline", maDonOnline);

                            using (SqlDataReader rd = cmd.ExecuteReader())
                            {
                                if (!rd.Read())
                                    throw new Exception("Không tìm thấy đơn hàng.");

                                maKH = Convert.ToInt32(rd["MaKH"]);
                                tongTienDon = Convert.ToDecimal(rd["TongTien"]);
                                trangThaiDon = rd["TrangThai"] == DBNull.Value
                                    ? ""
                                    : rd["TrangThai"].ToString();
                            }
                        }

                        if (tongTienDon <= 0)
                            throw new Exception("Tổng tiền đơn hàng không hợp lệ.");

                        if (trangThaiDon.Equals(
                            "Đã thanh toán",
                            StringComparison.OrdinalIgnoreCase))
                        {
                            throw new Exception(
                                "Đơn hàng này đã được thanh toán trước đó.");
                        }

                        // =====================================================
                        // 2. Kiểm tra chi tiết đơn
                        // =====================================================
                        DataTable dtChiTiet = new DataTable();

                        string sqlChiTietDon = @"
SELECT
    MaBienThe,
    SoLuong,
    DonGia
FROM ChiTietDonOnline
WHERE MaDonOnline = @MaDonOnline";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlChiTietDon, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaDonOnline", maDonOnline);

                            using (SqlDataAdapter da =
                                new SqlDataAdapter(cmd))
                            {
                                da.Fill(dtChiTiet);
                            }
                        }

                        if (dtChiTiet.Rows.Count == 0)
                            throw new Exception(
                                "Đơn hàng không có sản phẩm.");

                        // =====================================================
                        // 3. Kiểm tra tồn kho trước khi tạo hóa đơn
                        // =====================================================
                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            int maBienThe = Convert.ToInt32(row["MaBienThe"]);
                            int soLuong = Convert.ToInt32(row["SoLuong"]);

                            string sqlCheckStock = @"
SELECT SoLuong
FROM BienTheSanPham WITH (UPDLOCK, ROWLOCK)
WHERE MaBienThe = @MaBienThe";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlCheckStock, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaBienThe", maBienThe);

                                object stock = cmd.ExecuteScalar();

                                if (stock == null)
                                    throw new Exception(
                                        "Không tìm thấy biến thể BT" +
                                        maBienThe.ToString("D4") + ".");

                                int ton = Convert.ToInt32(stock);

                                if (ton < soLuong)
                                {
                                    throw new Exception(
                                        "Sản phẩm BT" +
                                        maBienThe.ToString("D4") +
                                        " không đủ tồn kho.\n" +
                                        "Tồn hiện tại: " + ton +
                                        "\nCần bán: " + soLuong);
                                }
                            }
                        }

                        // =====================================================
                        // 4. Tạo HoaDon - GẮN MaNV + MaCa
                        // =====================================================
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

                        using (SqlCommand cmd = new SqlCommand(
                            sqlHoaDon, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaNV", Session.MaNV);

                            cmd.Parameters.AddWithValue(
                                "@MaKH", maKH);

                            cmd.Parameters.AddWithValue(
                                "@MaDonOnline", maDonOnline);

                            cmd.Parameters.AddWithValue(
                                "@MaCa", Session.MaCa);

                            cmd.Parameters.AddWithValue(
                                "@TongTien", tongTienDon);

                            maHD = Convert.ToInt32(
                                cmd.ExecuteScalar());
                        }

                        // =====================================================
                        // 5. Tạo ChiTietHoaDon
                        // =====================================================
                        string sqlInsertCT = @"
INSERT INTO ChiTietHoaDon
(
    MaHD,
    MaBienThe,
    SoLuong,
    DonGia
)
VALUES
(
    @MaHD,
    @MaBienThe,
    @SoLuong,
    @DonGia
)";

                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                sqlInsertCT, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaHD", maHD);

                                cmd.Parameters.AddWithValue(
                                    "@MaBienThe",
                                    Convert.ToInt32(row["MaBienThe"]));

                                cmd.Parameters.AddWithValue(
                                    "@SoLuong",
                                    Convert.ToInt32(row["SoLuong"]));

                                cmd.Parameters.Add(
                                    "@DonGia",
                                    SqlDbType.Decimal).Value =
                                    Convert.ToDecimal(row["DonGia"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // =====================================================
                        // 6. Trừ ví nếu chọn Ví điện tử
                        // =====================================================
                        if (phuongThuc == "Ví điện tử")
                        {
                            decimal soDuTruoc;
                            decimal soDuSau;

                            string sqlVi = @"
SELECT SoDu
FROM ViDienTu WITH (UPDLOCK, ROWLOCK)
WHERE MaKH = @MaKH";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlVi, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaKH", maKH);

                                object result = cmd.ExecuteScalar();

                                if (result == null)
                                    throw new Exception(
                                        "Khách hàng chưa có ví điện tử.");

                                soDuTruoc = Convert.ToDecimal(result);
                            }

                            if (soDuTruoc < tongTienDon)
                                throw new Exception(
                                    "Số dư ví không đủ.");

                            soDuSau = soDuTruoc - tongTienDon;

                            string sqlTruVi = @"
UPDATE ViDienTu
SET SoDu = @SoDuSau
WHERE MaKH = @MaKH";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlTruVi, conn, tran))
                            {
                                cmd.Parameters.Add(
                                    "@SoDuSau",
                                    SqlDbType.Decimal).Value = soDuSau;

                                cmd.Parameters.AddWithValue(
                                    "@MaKH", maKH);

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception(
                                        "Không thể trừ số dư ví.");
                            }

                            string sqlGiaoDich = @"
INSERT INTO GiaoDichVi
(
    MaVi,
    LoaiGD,
    SoTien,
    SoDuTruoc,
    SoDuSau,
    NoiDung
)
SELECT
    MaVi,
    N'Thanh toán',
    @SoTien,
    @SoDuTruoc,
    @SoDuSau,
    @NoiDung
FROM ViDienTu
WHERE MaKH = @MaKH";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlGiaoDich, conn, tran))
                            {
                                cmd.Parameters.Add(
                                    "@SoTien",
                                    SqlDbType.Decimal).Value =
                                    tongTienDon;

                                cmd.Parameters.Add(
                                    "@SoDuTruoc",
                                    SqlDbType.Decimal).Value =
                                    soDuTruoc;

                                cmd.Parameters.Add(
                                    "@SoDuSau",
                                    SqlDbType.Decimal).Value =
                                    soDuSau;

                                cmd.Parameters.Add(
                                    "@NoiDung",
                                    SqlDbType.NVarChar, 500).Value =
                                    "Thanh toán đơn online DO" +
                                    maDonOnline.ToString("D5");

                                cmd.Parameters.AddWithValue(
                                    "@MaKH", maKH);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // =====================================================
                        // 7. Ghi ThanhToan
                        // Schema hiện tại: MaHD, PhuongThuc, TrangThai,
                        // NgayThanhToan
                        // =====================================================
                        string sqlThanhToan = @"
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
)";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlThanhToan, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaHD", maHD);

                            cmd.Parameters.Add(
                                "@PhuongThuc",
                                SqlDbType.NVarChar, 50).Value =
                                phuongThuc;

                            cmd.ExecuteNonQuery();
                        }

                        // =====================================================
                        // 8. Trừ tồn kho biến thể + ghi lịch sử
                        // =====================================================
                        foreach (DataRow row in dtChiTiet.Rows)
                        {
                            int maBienThe =
                                Convert.ToInt32(row["MaBienThe"]);

                            int soLuong =
                                Convert.ToInt32(row["SoLuong"]);

                            string sqlTruBTP = @"
UPDATE BienTheSanPham
SET SoLuong = SoLuong - @SoLuong
WHERE MaBienThe = @MaBienThe
  AND SoLuong >= @SoLuong";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlTruBTP, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@SoLuong", soLuong);

                                cmd.Parameters.AddWithValue(
                                    "@MaBienThe", maBienThe);

                                if (cmd.ExecuteNonQuery() != 1)
                                {
                                    throw new Exception(
                                        "Không thể trừ tồn kho BT" +
                                        maBienThe.ToString("D4") + ".");
                                }
                            }

                            string sqlTruTonKho = @"
UPDATE TonKho
SET
    SLTon = SLTon - @SoLuong,
    TongSLXuat = TongSLXuat + @SoLuong
WHERE MaTonKho =
(
    SELECT TOP 1 MaTonKho
    FROM TonKho
    WHERE MaBienThe = @MaBienThe
      AND SLTon >= @SoLuong
    ORDER BY MaKho
)";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlTruTonKho, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@SoLuong", soLuong);

                                cmd.Parameters.AddWithValue(
                                    "@MaBienThe", maBienThe);

                                // Nếu không có dòng TonKho thì vẫn để
                                // BienTheSanPham là nguồn tồn kho chính.
                                cmd.ExecuteNonQuery();
                            }

                            string sqlLichSu = @"
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
)";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlLichSu, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaBienThe", maBienThe);

                                cmd.Parameters.AddWithValue(
                                    "@SoLuong", soLuong);

                                cmd.Parameters.AddWithValue(
                                    "@MaTK", Session.MaTK);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // =====================================================
                        // 9. Cập nhật DonOnline
                        // =====================================================
                        string sqlUpdateDon = @"
UPDATE DonOnline
SET
    TrangThai = N'Đã thanh toán',
    NgayCapNhat = GETDATE(),
    MaNV = @MaNV
WHERE MaDonOnline = @MaDonOnline";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlUpdateDon, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaNV", Session.MaNV);

                            cmd.Parameters.AddWithValue(
                                "@MaDonOnline", maDonOnline);

                            if (cmd.ExecuteNonQuery() != 1)
                                throw new Exception(
                                    "Không thể cập nhật trạng thái đơn online.");
                        }

                        tran.Commit();

                        MaHoaDonDaTao = maHD;
                        DaXuLyThanhCong = true;

                        MessageBox.Show(
                            "Thanh toán thành công!\n\n" +
                            "Mã hóa đơn: HD" + maHD.ToString("D5") +
                            "\nMã ca: " + Session.MaCa +
                            "\nTổng tiền: " +
                            tongTienDon.ToString("N0") + " đ",
                            "SPORTSHOP",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        using (FormHoaDon frm =
                            new FormHoaDon(maHD))
                        {
                            frm.ShowDialog(this);
                        }

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch
                    {
                        try
                        {
                            tran.Rollback();
                        }
                        catch
                        {
                        }

                        throw;
                    }
                }
            }
        }
    }
}

