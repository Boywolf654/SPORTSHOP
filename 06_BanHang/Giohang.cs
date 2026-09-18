using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class Giohang : Form
    {
        private decimal giamGia = 0;
        private decimal phiVanChuyen = 0;

        private int maVoucherDangApDung = 0;
        private int maDiaChiDangApDung = 0;

        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        public Giohang()
        {
            InitializeComponent();

            btn_xoa.Click += btn_xoa_Click;
            btn_giamgia.Click += btn_giamgia_Click;
            btn_vanchuyen.Click += btn_vanchuyen_Click;
            btn_thanhtoan.Click += btn_thanhtoan_Click;

            dgv_giohang.CellContentClick += dgv_giohang_CellContentClick;
            dgv_giohang.CellMouseDown += dgv_giohang_CellMouseDown;

            rdoThe.CheckedChanged += PhuongThucThanhToan_CheckedChanged;
            rdoChuyenKhoan.CheckedChanged += PhuongThucThanhToan_CheckedChanged;

            GanHoverButton(btn_thanhtoan, Color.FromArgb(37, 166, 76), Color.FromArgb(27, 142, 62));
            GanHoverButton(btn_xoa, Color.FromArgb(225, 66, 66), Color.FromArgb(198, 52, 52));
            GanHoverButton(btn_giamgia, Color.FromArgb(215, 225, 239), Color.FromArgb(232, 238, 247));
            GanHoverButton(btn_vanchuyen, Color.FromArgb(215, 225, 239), Color.FromArgb(232, 238, 247));
        }

        private void Giohang_Load(object sender, EventArgs e)
        {
            CauHinhGioHang();
            LoadGioHang();
            LoadDiaChiMacDinh();
            CapNhatTrangThaiNut();
        }

        private void CauHinhGioHang()
        {
            dgv_giohang.AllowUserToAddRows = false;
            dgv_giohang.ReadOnly = true;
            dgv_giohang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_giohang.MultiSelect = false;
            dgv_giohang.RowTemplate.Height = 55;

            dgv_giohang.Columns["Column3"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgv_giohang.Columns["Column4"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgv_giohang.Columns["Column5"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgv_giohang.Columns["Column2"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgv_giohang.Columns["Column6"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

        private void GanHoverButton(Button button, Color hoverColor, Color normalColor)
        {
            button.MouseEnter += (s, e) =>
            {
                if (button.Enabled)
                    button.BackColor = hoverColor;
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = button.Enabled
                    ? normalColor
                    : Color.FromArgb(205, 205, 205);
            };
        }

        private void LoadGioHang()
        {
            dgv_giohang.Rows.Clear();

            foreach (GioHangItem item in GioHangManager.DanhSach)
            {
                string thongTinSP = item.SanPham.TenSP;

                if (!string.IsNullOrWhiteSpace(item.Size))
                    thongTinSP += Environment.NewLine + "Size: " + item.Size;

                if (!string.IsNullOrWhiteSpace(item.MauSac))
                    thongTinSP += " | Màu: " + item.MauSac;

                dgv_giohang.Rows.Add(
                    thongTinSP,
                    item.SanPham.Gia.ToString("N0") + " Đ",
                    "+",
                    item.SoLuong,
                    "-",
                    item.ThanhTien.ToString("N0") + " Đ"
                );
            }

            CapNhatTongTien();
            CapNhatTrangThaiNut();
        }

        private void CapNhatTrangThaiNut()
        {
            bool coHang = GioHangManager.DanhSach.Count > 0;
            btn_thanhtoan.Enabled = coHang;

            if (!coHang)
            {
                btn_thanhtoan.BackColor = Color.FromArgb(205, 205, 205);
                btn_thanhtoan.ForeColor = Color.White;
            }
            else
            {
                btn_thanhtoan.BackColor = Color.FromArgb(27, 142, 62);
                btn_thanhtoan.ForeColor = Color.White;
            }
        }

        private void CapNhatTongTien()
        {
            decimal giaGoc = GioHangManager.TongTien();

            if (GioHangManager.DanhSach.Count == 0)
            {
                giamGia = 0;
                phiVanChuyen = 0;
                maVoucherDangApDung = 0;
            }

            if (giamGia > giaGoc)
                giamGia = giaGoc;

            decimal tong = giaGoc - giamGia + phiVanChuyen;

            if (tong < 0)
                tong = 0;

            label4.Text = "Giá gốc: " + giaGoc.ToString("N0") + " Đ";
            label5.Text = "Giảm giá: -" + giamGia.ToString("N0") + " Đ";
            label6.Text = "Vận chuyển: " + phiVanChuyen.ToString("N0") + " Đ";
            label7.Text = "TỔNG: " + tong.ToString("N0") + " Đ";
        }

        private void dgv_giohang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= GioHangManager.DanhSach.Count)
                return;

            GioHangItem item = GioHangManager.DanhSach[e.RowIndex];

            if (e.ColumnIndex == 2)
            {
                if (item.SoLuong < 99)
                    item.SoLuong++;
                else
                {
                    MessageBox.Show(
                        "Số lượng tối đa là 99.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                if (item.SoLuong > 1)
                    item.SoLuong--;
                else
                {
                    DialogResult result = MessageBox.Show(
                        "Số lượng đang là 1.\nBạn có muốn xóa sản phẩm này khỏi giỏ?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                        GioHangManager.Xoa(item);
                }
            }
            else
                return;

            // Thay đổi số lượng có thể làm voucher cũ không còn hợp lệ.
            maVoucherDangApDung = 0;
            giamGia = 0;

            LoadGioHang();
        }

        private void dgv_giohang_CellMouseDown(
            object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= GioHangManager.DanhSach.Count ||
                e.Button != MouseButtons.Right)
                return;

            dgv_giohang.ClearSelection();
            dgv_giohang.Rows[e.RowIndex].Selected = true;

            GioHangItem item = GioHangManager.DanhSach[e.RowIndex];

            DialogResult result = MessageBox.Show(
                "Xóa sản phẩm này khỏi giỏ hàng?\n\n" + item.SanPham.TenSP,
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            GioHangManager.Xoa(item);
            maVoucherDangApDung = 0;
            giamGia = 0;
            LoadGioHang();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ giỏ hàng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            GioHangManager.XoaTatCa();
            giamGia = 0;
            phiVanChuyen = 0;
            maVoucherDangApDung = 0;

            LoadGioHang();
        }

        private void btn_giamgia_Click(object sender, EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string ma = cmb_giamgia.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã giảm giá.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmb_giamgia.Focus();
                return;
            }

            try
            {
                string sql = @"
                    SELECT TOP 1
                        MaVoucher,
                        GiaTri,
                        LoaiGiam,
                        GiaTriDonToiThieu,
                        SoLuongToiDa,
                        DaSuDung
                    FROM Voucher
                    WHERE UPPER(MaCode) = @MaCode
                      AND TrangThai = 1
                      AND NgayBatDau <= CAST(GETDATE() AS DATE)
                      AND (NgayHetHan IS NULL OR NgayHetHan >= CAST(GETDATE() AS DATE))
                      AND DaSuDung < SoLuongToiDa";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaCode", ma)
                };

                DataTable dt = kt.GetData(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    maVoucherDangApDung = 0;
                    giamGia = 0;
                    CapNhatTongTien();

                    MessageBox.Show(
                        "Mã giảm giá không tồn tại, đã hết hạn hoặc đã hết lượt sử dụng.",
                        "Voucher",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DataRow row = dt.Rows[0];
                decimal giaGoc = GioHangManager.TongTien();
                decimal toiThieu = Convert.ToDecimal(row["GiaTriDonToiThieu"]);

                if (giaGoc < toiThieu)
                {
                    MessageBox.Show(
                        "Đơn hàng chưa đạt giá trị tối thiểu " +
                        toiThieu.ToString("N0") + " Đ.",
                        "Voucher",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                decimal giaTri = Convert.ToDecimal(row["GiaTri"]);
                string loai = row["LoaiGiam"].ToString();

                if (loai.Equals("PhanTram", StringComparison.OrdinalIgnoreCase))
                    giamGia = giaGoc * giaTri / 100m;
                else
                    giamGia = giaTri;

                if (giamGia > giaGoc)
                    giamGia = giaGoc;

                maVoucherDangApDung = Convert.ToInt32(row["MaVoucher"]);

                CapNhatTongTien();

                MessageBox.Show(
                    "Áp dụng voucher thành công!\n" +
                    "Mã: " + ma +
                    "\nGiảm: " + giamGia.ToString("N0") + " Đ",
                    "Voucher",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể áp dụng voucher.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_vanchuyen_Click(object sender, EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string phuongThuc = cmb_vanchuyen.Text.Trim();

            if (string.IsNullOrWhiteSpace(phuongThuc))
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức giao hàng.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (phuongThuc.IndexOf(
                "Nhanh",
                StringComparison.OrdinalIgnoreCase) >= 0)
                phiVanChuyen = 40000;
            else
                phiVanChuyen = 30000;

            CapNhatTongTien();
        }

        private void PhuongThucThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoThe.Checked)
                lblPhuongThuc.Text = "PHƯƠNG THỨC THANH TOÁN  •  THẺ";
            else if (rdoChuyenKhoan.Checked)
                lblPhuongThuc.Text = "PHƯƠNG THỨC THANH TOÁN  •  CHUYỂN KHOẢN";
        }

        private void LoadDiaChiMacDinh()
        {
            maDiaChiDangApDung = 0;

            if (Session.MaTK <= 0)
            {
                lblDiaChiValue.Text = "Chưa đăng nhập tài khoản khách hàng.";
                return;
            }

            try
            {
                string sql = @"
                    SELECT TOP 1
                        dc.MaDiaChi,
                        dc.NguoiNhan,
                        dc.SDT,
                        dc.DiaChiCuThe,
                        dc.TinhThanh
                    FROM KhachHang kh
                    INNER JOIN DiaChiKhachHang dc
                        ON dc.MaKH = kh.MaKH
                    WHERE kh.MaTK = @MaTK
                    ORDER BY dc.MacDinh DESC, dc.MaDiaChi DESC";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaTK", Session.MaTK)
                };

                DataTable dt = kt.GetData(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    lblDiaChiValue.Text =
                        "Chưa có địa chỉ nhận hàng. Vui lòng thêm địa chỉ trước khi đặt đơn.";
                    return;
                }

                DataRow row = dt.Rows[0];
                maDiaChiDangApDung = Convert.ToInt32(row["MaDiaChi"]);

                string diaChi = row["NguoiNhan"] + " - " +
                                row["SDT"] + "\n" +
                                row["DiaChiCuThe"];

                if (row["TinhThanh"] != DBNull.Value &&
                    !string.IsNullOrWhiteSpace(row["TinhThanh"].ToString()))
                    diaChi += ", " + row["TinhThanh"];

                lblDiaChiValue.Text = diaChi;
            }
            catch (Exception ex)
            {
                lblDiaChiValue.Text = "Không tải được địa chỉ nhận hàng.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private int LayMaKH()
        {
            if (Session.MaTK <= 0)
                return 0;

            string sql = @"
                SELECT TOP 1 MaKH
                FROM KhachHang
                WHERE MaTK = @MaTK";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaTK", Session.MaTK)
            };

            object result = kt.ExecuteScalar(sql, parameters);

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }

        private decimal LayTongThanhToan()
        {
            decimal tong = GioHangManager.TongTien()
                          - giamGia
                          + phiVanChuyen;

            return tong < 0 ? 0 : tong;
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if (GioHangManager.DanhSach.Count == 0)
            {
                MessageBox.Show(
                    "Giỏ hàng đang trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int maKH = LayMaKH();

            if (maKH <= 0)
            {
                MessageBox.Show(
                    "Không xác định được khách hàng đang đăng nhập.\n\n" +
                    "Vui lòng đăng nhập lại bằng tài khoản khách hàng.",
                    "Không thể thanh toán",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (maDiaChiDangApDung <= 0)
            {
                MessageBox.Show(
                    "Bạn chưa có địa chỉ nhận hàng.\n\n" +
                    "Vui lòng thêm địa chỉ trước khi thanh toán.",
                    "Thiếu địa chỉ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!rdoThe.Checked && !rdoChuyenKhoan.Checked)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức thanh toán.",
                    "Thanh toán",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal giaGoc = GioHangManager.TongTien();
            decimal tong = LayTongThanhToan();

            string phuongThuc =
                rdoThe.Checked ? "Thẻ" : "Chuyển khoản";

            DialogResult confirm = MessageBox.Show(
                "XÁC NHẬN THANH TOÁN\n\n" +
                "Phương thức: " + phuongThuc + "\n" +
                "Số loại sản phẩm: " + GioHangManager.DanhSach.Count + "\n" +
                "Số lượng: " + GioHangManager.TongSoLuong() + "\n\n" +
                "Giá gốc: " + giaGoc.ToString("N0") + " Đ\n" +
                "Giảm giá: -" + giamGia.ToString("N0") + " Đ\n" +
                "Vận chuyển: " + phiVanChuyen.ToString("N0") + " Đ\n" +
                "------------------------------\n" +
                "THANH TOÁN: " + tong.ToString("N0") + " Đ\n\n" +
                "Trong bản demo này, thao tác xác nhận được xem là thanh toán thành công.",
                "SPORTSHOP",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            btn_thanhtoan.Enabled = false;

            try
            {
                TaoDonOnlineSauThanhToan(maKH, phuongThuc, giaGoc, tong);

                MessageBox.Show(
                    "THANH TOÁN THÀNH CÔNG!\n\n" +
                    "Đơn online đã được tạo và chuyển cho nhân viên xử lý.\n" +
                    "Trạng thái: Đã thanh toán",
                    "Đặt đơn thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                GioHangManager.XoaTatCa();

                giamGia = 0;
                phiVanChuyen = 0;
                maVoucherDangApDung = 0;

                LoadGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thanh toán chưa được ghi nhận.\n\n" +
                    "Không có đơn online nào được tạo.\n\n" +
                    ex.Message,
                    "Thanh toán thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btn_thanhtoan.Enabled =
                    GioHangManager.DanhSach.Count > 0;
            }
        }

        private void TaoDonOnlineSauThanhToan(
            int maKH,
            string phuongThuc,
            decimal giaGoc,
            decimal tongThanhToan)
        {
            using (SqlConnection conn = kt.GetConnection())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // -----------------------------------------------------
                        // 1. Kiểm tra lại khách hàng + địa chỉ trong transaction
                        // -----------------------------------------------------
                        string sqlCheckKH = @"
                            SELECT COUNT(*)
                            FROM KhachHang
                            WHERE MaKH = @MaKH
                              AND MaTK = @MaTK";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlCheckKH, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", maKH);
                            cmd.Parameters.AddWithValue("@MaTK", Session.MaTK);

                            if (Convert.ToInt32(cmd.ExecuteScalar()) != 1)
                                throw new Exception(
                                    "Tài khoản khách hàng không hợp lệ.");
                        }

                        string sqlCheckDC = @"
                            SELECT COUNT(*)
                            FROM DiaChiKhachHang
                            WHERE MaDiaChi = @MaDiaChi
                              AND MaKH = @MaKH";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlCheckDC, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaDiaChi", maDiaChiDangApDung);
                            cmd.Parameters.AddWithValue("@MaKH", maKH);

                            if (Convert.ToInt32(cmd.ExecuteScalar()) != 1)
                                throw new Exception(
                                    "Địa chỉ nhận hàng không hợp lệ.");
                        }

                        // -----------------------------------------------------
                        // 2. Kiểm tra tất cả biến thể trong giỏ
                        // -----------------------------------------------------
                        DataTable bienTheDaXacNhan = new DataTable();
                        bienTheDaXacNhan.Columns.Add("MaBienThe", typeof(int));
                        bienTheDaXacNhan.Columns.Add("SoLuong", typeof(int));
                        bienTheDaXacNhan.Columns.Add("DonGia", typeof(decimal));

                        foreach (GioHangItem item in GioHangManager.DanhSach)
                        {
                            string sqlBienThe = @"
                                SELECT TOP 1
                                    bt.MaBienThe,
                                    bt.GiaBan,
                                    bt.SoLuong
                                FROM BienTheSanPham bt
                                INNER JOIN Size s
                                    ON s.MaSize = bt.MaSize
                                INNER JOIN MauSac m
                                    ON m.MaMau = bt.MaMau
                                WHERE bt.MaSP = @MaSP
                                  AND s.TenSize = @Size
                                  AND m.TenMau = @Mau
                                  AND bt.TrangThai = 1";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlBienThe, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaSP", item.SanPham.MaSP);
                                cmd.Parameters.AddWithValue(
                                    "@Size", item.Size ?? "");
                                cmd.Parameters.AddWithValue(
                                    "@Mau", item.MauSac ?? "");

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        throw new Exception(
                                            "Không tìm thấy biến thể: " +
                                            item.SanPham.TenSP +
                                            " / Size " + item.Size +
                                            " / Màu " + item.MauSac);
                                    }

                                    int maBienThe =
                                        Convert.ToInt32(reader["MaBienThe"]);

                                    decimal giaBan =
                                        reader["GiaBan"] == DBNull.Value
                                        ? item.SanPham.Gia
                                        : Convert.ToDecimal(reader["GiaBan"]);

                                    int tonKho =
                                        reader["SoLuong"] == DBNull.Value
                                        ? 0
                                        : Convert.ToInt32(reader["SoLuong"]);

                                    if (tonKho < item.SoLuong)
                                    {
                                        throw new Exception(
                                            "Sản phẩm \"" +
                                            item.SanPham.TenSP +
                                            "\" / Size " + item.Size +
                                            " / Màu " + item.MauSac +
                                            " chỉ còn " + tonKho +
                                            ", không đủ số lượng " +
                                            item.SoLuong + ".");
                                    }

                                    DataRow newRow =
                                        bienTheDaXacNhan.NewRow();

                                    newRow["MaBienThe"] = maBienThe;
                                    newRow["SoLuong"] = item.SoLuong;
                                    newRow["DonGia"] = giaBan;

                                    bienTheDaXacNhan.Rows.Add(newRow);
                                }
                            }
                        }

                        // -----------------------------------------------------
                        // 3. Tạo DonOnline
                        // -----------------------------------------------------
                        string sqlDon = @"
                            INSERT INTO DonOnline
                            (
                                MaKH,
                                MaVoucher,
                                MaDiaChi,
                                TongTienHang,
                                TienGiam,
                                PhiVanChuyen,
                                PhuongThucThanhToan,
                                TrangThai,
                                NgayTao,
                                NgayCapNhat,
                                MaNV
                            )
                            OUTPUT INSERTED.MaDonOnline
                            VALUES
                            (
                                @MaKH,
                                @MaVoucher,
                                @MaDiaChi,
                                @TongTienHang,
                                @TienGiam,
                                @PhiVanChuyen,
                                @PhuongThucThanhToan,
                                N'Đã thanh toán',
                                GETDATE(),
                                GETDATE(),
                                NULL
                            )";

                        int maDonOnline;

                        using (SqlCommand cmd = new SqlCommand(
                            sqlDon, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", maKH);

                            cmd.Parameters.AddWithValue(
                                "@MaVoucher",
                                maVoucherDangApDung > 0
                                    ? (object)maVoucherDangApDung
                                    : DBNull.Value);

                            cmd.Parameters.AddWithValue(
                                "@MaDiaChi",
                                maDiaChiDangApDung);

                            AddDecimalParameter(
                                cmd, "@TongTienHang", giaGoc);

                            AddDecimalParameter(
                                cmd, "@TienGiam", giamGia);

                            AddDecimalParameter(
                                cmd, "@PhiVanChuyen", phiVanChuyen);

                            cmd.Parameters.Add(
                                "@PhuongThucThanhToan",
                                SqlDbType.NVarChar, 30).Value =
                                phuongThuc;

                            maDonOnline =
                                Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // -----------------------------------------------------
                        // 4. Tạo ChiTietDonOnline
                        // -----------------------------------------------------
                        string sqlChiTiet = @"
                            INSERT INTO ChiTietDonOnline
                            (
                                MaDonOnline,
                                MaBienThe,
                                SoLuong,
                                DonGia
                            )
                            VALUES
                            (
                                @MaDonOnline,
                                @MaBienThe,
                                @SoLuong,
                                @DonGia
                            )";

                        foreach (DataRow row in bienTheDaXacNhan.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                sqlChiTiet, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaDonOnline", maDonOnline);

                                cmd.Parameters.AddWithValue(
                                    "@MaBienThe",
                                    Convert.ToInt32(row["MaBienThe"]));

                                cmd.Parameters.AddWithValue(
                                    "@SoLuong",
                                    Convert.ToInt32(row["SoLuong"]));

                                AddDecimalParameter(
                                    cmd,
                                    "@DonGia",
                                    Convert.ToDecimal(row["DonGia"]));

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // -----------------------------------------------------
                        // 5. Ghi nhận voucher đã sử dụng
                        // -----------------------------------------------------
                        if (maVoucherDangApDung > 0)
                        {
                            string sqlVoucher = @"
                                UPDATE Voucher
                                SET DaSuDung = DaSuDung + 1
                                WHERE MaVoucher = @MaVoucher
                                  AND TrangThai = 1
                                  AND DaSuDung < SoLuongToiDa";

                            using (SqlCommand cmd = new SqlCommand(
                                sqlVoucher, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaVoucher",
                                    maVoucherDangApDung);

                                int affected = cmd.ExecuteNonQuery();

                                if (affected != 1)
                                    throw new Exception(
                                        "Voucher vừa hết lượt sử dụng.");
                            }
                        }

                        // -----------------------------------------------------
                        // 6. COMMIT
                        // -----------------------------------------------------
                        tran.Commit();
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

        private void AddDecimalParameter(
            SqlCommand cmd,
            string name,
            decimal value)
        {
            SqlParameter p = cmd.Parameters.Add(
                name,
                SqlDbType.Decimal);

            p.Precision = 18;
            p.Scale = 2;
            p.Value = value;
        }
    }
}
