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
        private bool khachHangDangGiaoDich = true;
        private string hangThanhVienHienTai = "Đồng";

        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        public Giohang()
        {
            InitializeComponent();

            btn_xoa.Click += btn_xoa_Click;
            btn_giamgia.Click += btn_giamgia_Click;
            btn_vanchuyen.Click += btn_vanchuyen_Click;
            btn_thanhtoan.Click += btn_thanhtoan_Click;
            btn_thongTinKH.Click += btn_thongTinKH_Click;
            btn_doiDiaChi.Click += btn_doiDiaChi_Click;
            btn_moVi.Click += btn_moVi_Click;
            btn_dong.Click += btn_dong_Click;

            dgv_giohang.CellContentClick += dgv_giohang_CellContentClick;
            dgv_giohang.CellMouseDown += dgv_giohang_CellMouseDown;

            rdoThe.CheckedChanged += PhuongThucThanhToan_CheckedChanged;
            rdoChuyenKhoan.CheckedChanged += PhuongThucThanhToan_CheckedChanged;
            rdoViDienTu.CheckedChanged += PhuongThucThanhToan_CheckedChanged;

            GanHoverButton(btn_thanhtoan, Color.FromArgb(37, 166, 76), Color.FromArgb(27, 142, 62));
            GanHoverButton(btn_xoa, Color.FromArgb(225, 66, 66), Color.FromArgb(198, 52, 52));
            GanHoverButton(btn_giamgia, Color.FromArgb(215, 225, 239), Color.FromArgb(232, 238, 247));
            GanHoverButton(btn_vanchuyen, Color.FromArgb(215, 225, 239), Color.FromArgb(232, 238, 247));
        }

        private void Giohang_Load(object sender, EventArgs e)
        {
            CauHinhGioHang();
            LoadThongTinKhachHang();
            LoadDanhSachVoucher();
            LoadGioHang();
            LoadDiaChiMacDinh();
            CapNhatThongTinVi();
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
            bool coDiaChi = maDiaChiDangApDung > 0;
            bool choPhepThanhToan = coHang && coDiaChi && khachHangDangGiaoDich;

            btn_thanhtoan.Enabled = choPhepThanhToan;

            if (!khachHangDangGiaoDich)
            {
                btn_thanhtoan.Text = "KHÁCH ĐANG NGỪNG GIAO DỊCH";
                btn_thanhtoan.BackColor = Color.FromArgb(85, 85, 90);
            }
            else if (!coDiaChi)
            {
                btn_thanhtoan.Text = "THÊM ĐỊA CHỈ ĐỂ THANH TOÁN";
                btn_thanhtoan.BackColor = Color.FromArgb(85, 85, 90);
            }
            else
            {
                btn_thanhtoan.Text = "THANH TOÁN & ĐẶT ĐƠN";
                btn_thanhtoan.BackColor = choPhepThanhToan
                    ? Color.FromArgb(220, 30, 45)
                    : Color.FromArgb(85, 85, 90);
            }

            btn_thanhtoan.ForeColor = Color.White;
        }

        private void LoadThongTinKhachHang()
        {
            khachHangDangGiaoDich = true;
            hangThanhVienHienTai = "Đồng";

            if (Session.MaTK <= 0)
            {
                lblKHValue.Text = "Chưa đăng nhập tài khoản khách hàng.";
                lblHangDiem.Text = "Hạng: Chưa xác định";
                return;
            }

            try
            {
                string sql = @"
                    SELECT TOP 1
                        MaKH,
                        HoTen,
                        SDT,
                        DiemTichLuy,
                        HangThanhVien,
                        TrangThai
                    FROM KhachHang
                    WHERE MaTK = @MaTK";

                DataTable dt = kt.GetData(
                    sql,
                    new SqlParameter[] { new SqlParameter("@MaTK", Session.MaTK) });

                if (dt.Rows.Count == 0)
                {
                    lblKHValue.Text = "Tài khoản chưa có hồ sơ khách hàng.";
                    lblHangDiem.Text = "Hạng: Chưa xác định";
                    return;
                }

                DataRow r = dt.Rows[0];

                string hoTen = r["HoTen"] == DBNull.Value
                    ? "Khách hàng"
                    : Convert.ToString(r["HoTen"]);

                string sdt = r["SDT"] == DBNull.Value
                    ? ""
                    : Convert.ToString(r["SDT"]);

                int diem = r["DiemTichLuy"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(r["DiemTichLuy"]);

                hangThanhVienHienTai = r["HangThanhVien"] == DBNull.Value
                    ? "Đồng"
                    : Convert.ToString(r["HangThanhVien"]);

                khachHangDangGiaoDich =
                    r["TrangThai"] == DBNull.Value ||
                    Convert.ToBoolean(r["TrangThai"]);

                lblKHValue.Text = string.IsNullOrWhiteSpace(sdt)
                    ? hoTen
                    : hoTen + "  •  " + sdt;

                lblHangDiem.Text =
                    "Hạng " + hangThanhVienHienTai +
                    "  •  " + diem.ToString("N0") + " điểm";

                lblHangDiem.ForeColor = khachHangDangGiaoDich
                    ? Color.FromArgb(190, 190, 198)
                    : Color.FromArgb(255, 95, 95);

                if (khachHangDangGiaoDich)
                {
                    lblVoucherInfo.Text = "Voucher: Chưa áp dụng";
                }
                else
                {
                    lblVoucherInfo.Text =
                        "● KHÁCH HÀNG ĐÃ NGỪNG GIAO DỊCH";
                    lblVoucherInfo.ForeColor = Color.FromArgb(255, 85, 85);
                }
            }
            catch (Exception ex)
            {
                lblKHValue.Text = "Không tải được thông tin khách hàng.";
                lblHangDiem.Text = "Không tải được hạng thành viên.";
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void LoadDanhSachVoucher()
        {
            try
            {
                cmb_giamgia.Items.Clear();

                string sql = @"
                    SELECT MaCode
                    FROM Voucher
                    WHERE TrangThai = 1
                      AND DaSuDung < SoLuongToiDa
                      AND NgayBatDau <= CAST(GETDATE() AS DATE)
                      AND (NgayHetHan IS NULL OR NgayHetHan >= CAST(GETDATE() AS DATE))
                    ORDER BY MaVoucher DESC";

                DataTable dt = kt.GetData(sql, null);

                foreach (DataRow row in dt.Rows)
                {
                    string ma = Convert.ToString(row["MaCode"]);
                    if (!string.IsNullOrWhiteSpace(ma))
                        cmb_giamgia.Items.Add(ma);
                }

                cmb_giamgia.Text = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void btn_thongTinKH_Click(object sender, EventArgs e)
        {
            try
            {
                using (SPORTSHOP._07_KhachHang.FormThongTinKhachHang frm =
                    new SPORTSHOP._07_KhachHang.FormThongTinKhachHang())
                {
                    frm.ShowDialog(this);
                }

                LoadThongTinKhachHang();
                LoadDiaChiMacDinh();
                CapNhatThongTinVi();
                CapNhatTrangThaiNut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở thông tin khách hàng.\n\n" + ex.Message,
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_doiDiaChi_Click(object sender, EventArgs e)
        {
            int maKH = LayMaKH();

            if (maKH <= 0)
            {
                MessageBox.Show(
                    "Không xác định được khách hàng.",
                    "Địa chỉ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SPORTSHOP._07_KhachHang.FormQuanLyDiaChi frm =
                    new SPORTSHOP._07_KhachHang.FormQuanLyDiaChi(maKH))
                {
                    frm.ShowDialog(this);
                }

                LoadDiaChiMacDinh();
                CapNhatTrangThaiNut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở quản lý địa chỉ.\n\n" + ex.Message,
                    "Địa chỉ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_moVi_Click(object sender, EventArgs e)
        {
            try
            {
                using (SPORTSHOP._07_KhachHang.FormViDienTu frm =
                    new SPORTSHOP._07_KhachHang.FormViDienTu())
                {
                    frm.ShowDialog(this);
                }

                CapNhatThongTinVi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở Ví điện tử.\n\n" + ex.Message,
                    "Ví điện tử",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            Close();
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
            lblPhiVanChuyen.Text = "Vận chuyển: " + phiVanChuyen.ToString("N0") + " Đ";
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
            lblVoucherInfo.Text = "Voucher: Chưa áp dụng";
            lblVoucherInfo.ForeColor = Color.FromArgb(190, 190, 198);

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
                lblVoucherInfo.Text =
                    "Voucher: " + ma +
                    "  •  Giảm " + giamGia.ToString("N0") + " Đ";
                lblVoucherInfo.ForeColor = Color.FromArgb(255, 90, 100);

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
            else if (rdoViDienTu.Checked)
                lblPhuongThuc.Text = "PHƯƠNG THỨC THANH TOÁN  •  VÍ ĐIỆN TỬ";
        }

        private void CapNhatThongTinVi()
        {
            if (Session.MaTK <= 0)
            {
                lblViInfo.Text = "Ví điện tử: Chưa đăng nhập";
                return;
            }

            try
            {
                int maKH = LayMaKH();

                if (maKH <= 0)
                {
                    lblViInfo.Text = "Ví điện tử: Chưa xác định KH";
                    return;
                }

                object result = kt.ExecuteScalar(
                    @"SELECT TOP 1 SoDu
                      FROM ViDienTu
                      WHERE MaKH=@MaKH",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaKH", maKH)
                    });

                if (result == null || result == DBNull.Value)
                    lblViInfo.Text = "Ví điện tử: Chưa tạo ví";
                else
                    lblViInfo.Text =
                        "Ví điện tử: " + Convert.ToDecimal(result).ToString("N0") + " Đ";
            }
            catch
            {
                lblViInfo.Text = "Ví điện tử: Không tải được số dư";
            }
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

        /// <summary>
        /// Kiểm tra giá hiện tại của toàn bộ biến thể trong giỏ trước khi thanh toán.
        /// Nếu giá đã thay đổi so với giá đang hiển thị trong giỏ, cập nhật lại giá
        /// trên GioHangItem, làm mới giao diện và yêu cầu khách xác nhận lại.
        /// </summary>
        private bool KiemTraVaCapNhatGiaHienTai()
        {
            if (GioHangManager.DanhSach.Count == 0)
                return true;

            bool coThayDoi = false;
            string thongBao = "";

            try
            {
                foreach (GioHangItem item in GioHangManager.DanhSach)
                {
                    if (item == null || item.SanPham == null)
                        continue;

                    string sqlGia;
                    if (item.MaBienThe > 0)
                    {
                        sqlGia = @"
                            SELECT TOP 1 GiaBan
                            FROM BienTheSanPham
                            WHERE MaBienThe=@MaBienThe
                              AND MaSP=@MaSP
                              AND TrangThai=1";
                    }
                    else
                    {
                        sqlGia = @"
                            SELECT TOP 1 bt.GiaBan
                            FROM BienTheSanPham bt
                            INNER JOIN Size s ON s.MaSize=bt.MaSize
                            LEFT JOIN MauSac m ON m.MaMau=bt.MaMau
                            WHERE bt.MaSP=@MaSP
                              AND s.TenSize=@Size
                              AND bt.TrangThai=1
                              AND (
                                    (@Mau<>'' AND ISNULL(m.TenMau,'')=@Mau)
                                    OR
                                    (@Mau='' AND (m.MaMau IS NULL OR ISNULL(m.TenMau,'')=''))
                                  )
                            ORDER BY bt.MaBienThe";
                    }

                    SqlParameter[] parameters;
                    if (item.MaBienThe > 0)
                    {
                        parameters = new[]
                        {
                            new SqlParameter("@MaBienThe", item.MaBienThe),
                            new SqlParameter("@MaSP", item.SanPham.MaSP)
                        };
                    }
                    else
                    {
                        parameters = new[]
                        {
                            new SqlParameter("@MaSP", item.SanPham.MaSP),
                            new SqlParameter("@Size", item.Size ?? ""),
                            new SqlParameter("@Mau", (item.MauSac ?? "").Trim())
                        };
                    }

                    object result = kt.ExecuteScalar(sqlGia, parameters);

                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception(
                            "Không tìm thấy biến thể đang có trong giỏ: " +
                            item.SanPham.TenSP +
                            " / Size " + item.Size +
                            " / Màu " + item.MauSac);
                    }

                    decimal giaMoi = Convert.ToDecimal(result);
                    decimal giaCu = item.SanPham.Gia;

                    if (giaMoi != giaCu)
                    {
                        coThayDoi = true;

                        thongBao +=
                            "• " + item.SanPham.TenSP +
                            (string.IsNullOrWhiteSpace(item.Size) ? "" : " / Size " + item.Size) +
                            (string.IsNullOrWhiteSpace(item.MauSac) ? "" : " / Màu " + item.MauSac) +
                            "\n  Giá cũ: " + giaCu.ToString("N0") + " Đ" +
                            " → Giá mới: " + giaMoi.ToString("N0") + " Đ\n";

                        // Cập nhật trực tiếp giá của item trong giỏ.
                        item.SanPham.Gia = giaMoi;
                    }
                }

                if (!coThayDoi)
                    return true;

                // Giá đơn đã thay đổi nên voucher cũ phải được kiểm tra lại.
                // Không giữ nguyên mức giảm được tính theo giá cũ.
                giamGia = 0;
                maVoucherDangApDung = 0;

                // Refresh toàn bộ DataGridView + tổng tiền theo giá mới.
                LoadGioHang();

                MessageBox.Show(
                    "GIÁ SẢN PHẨM ĐÃ THAY ĐỔI\n\n" +
                    thongBao +
                    "\nGiỏ hàng đã được tự động cập nhật theo giá mới.\n" +
                    "Voucher/giảm giá cũ đã được bỏ để tính lại theo giá mới.\n\n" +
                    "Vui lòng kiểm tra lại đơn hàng và bấm Thanh toán một lần nữa.",
                    "Giá sản phẩm thay đổi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kiểm tra giá sản phẩm hiện tại.\n\n" + ex.Message,
                    "Không thể thanh toán",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
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

            LoadThongTinKhachHang();

            if (!khachHangDangGiaoDich)
            {
                CapNhatTrangThaiNut();
                MessageBox.Show(
                    "Khách hàng đã ngừng giao dịch.\n\n" +
                    "Không thể tạo hoặc thanh toán đơn hàng.",
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

            if (!rdoThe.Checked && !rdoChuyenKhoan.Checked && !rdoViDienTu.Checked)
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức thanh toán.",
                    "Thanh toán",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá DB ngay trước khi hiện hộp xác nhận.
            // Nếu giá thay đổi, hàm sẽ tự refresh giỏ và dừng lần thanh toán này.
            // Khách phải kiểm tra giá mới và bấm Thanh toán lại.
            if (!KiemTraVaCapNhatGiaHienTai())
                return;

            decimal giaGoc = GioHangManager.TongTien();
            decimal tong = LayTongThanhToan();

            string phuongThuc =
                rdoThe.Checked
                    ? "Thẻ"
                    : (rdoChuyenKhoan.Checked ? "Chuyển khoản" : "Ví điện tử");

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
                LoadThongTinKhachHang();
                CapNhatThongTinVi();
                LoadDiaChiMacDinh();
                CapNhatTrangThaiNut();
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
                              AND MaTK = @MaTK
                              AND TrangThai = 1";

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
                            string sqlBienThe;

                            if (item.MaBienThe > 0)
                            {
                                // Item mới: dùng thẳng MaBienThe đã lưu trong giỏ.
                                sqlBienThe = @"
                                    SELECT TOP 1
                                        bt.MaBienThe,
                                        bt.GiaBan,
                                        bt.SoLuong
                                    FROM BienTheSanPham bt
                                    WHERE bt.MaBienThe = @MaBienThe
                                      AND bt.MaSP = @MaSP
                                      AND bt.TrangThai = 1";
                            }
                            else
                            {
                                // Fallback cho item cũ được thêm trước bản sửa.
                                sqlBienThe = @"
                                    SELECT TOP 1
                                        bt.MaBienThe,
                                        bt.GiaBan,
                                        bt.SoLuong
                                    FROM BienTheSanPham bt
                                    INNER JOIN Size s
                                        ON s.MaSize = bt.MaSize
                                    LEFT JOIN MauSac m
                                        ON m.MaMau = bt.MaMau
                                    WHERE bt.MaSP = @MaSP
                                      AND s.TenSize = @Size
                                      AND bt.TrangThai = 1
                                      AND (
                                            (@Mau <> '' AND ISNULL(m.TenMau,'') = @Mau)
                                            OR
                                            (@Mau = '' AND (m.MaMau IS NULL OR ISNULL(m.TenMau,'') = ''))
                                          )
                                    ORDER BY
                                        CASE
                                            WHEN @Mau <> '' AND ISNULL(m.TenMau,'') = @Mau THEN 0
                                            WHEN @Mau = '' AND m.MaMau IS NULL THEN 0
                                            ELSE 1
                                        END,
                                        bt.MaBienThe";
                            }

                            using (SqlCommand cmd = new SqlCommand(
                                sqlBienThe, conn, tran))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@MaSP", item.SanPham.MaSP);

                                if (item.MaBienThe > 0)
                                {
                                    cmd.Parameters.AddWithValue(
                                        "@MaBienThe", item.MaBienThe);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(
                                        "@Size", item.Size ?? "");
                                    cmd.Parameters.AddWithValue(
                                        "@Mau", (item.MauSac ?? "").Trim());
                                }

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
                        // 3. Thanh toán bằng ví điện tử (nếu được chọn)
                        //    Cùng transaction với việc tạo đơn:
                        //    lock số dư -> kiểm tra -> trừ tiền -> ghi lịch sử.
                        //    Nếu bước tạo đơn phía sau lỗi thì toàn bộ sẽ rollback.
                        // -----------------------------------------------------
                        if (phuongThuc == "Ví điện tử")
                        {
                            int maVi = 0;
                            decimal soDuTruoc;

                            using (SqlCommand cmd = new SqlCommand(
                                @"SELECT TOP 1 MaVi, SoDu
                                  FROM ViDienTu WITH (UPDLOCK, ROWLOCK)
                                  WHERE MaKH=@MaKH",
                                conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaKH", maKH);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        throw new Exception(
                                            "Khách hàng chưa có ví điện tử. " +
                                            "Vui lòng mở ví trước khi thanh toán bằng ví.");
                                    }

                                    maVi = Convert.ToInt32(reader["MaVi"]);
                                    soDuTruoc = Convert.ToDecimal(reader["SoDu"]);
                                }
                            }

                            if (soDuTruoc < tongThanhToan)
                            {
                                decimal thieu = tongThanhToan - soDuTruoc;

                                throw new Exception(
                                    "Số dư ví không đủ để thanh toán.\n\n" +
                                    "Số dư hiện tại: " + soDuTruoc.ToString("N0") + " Đ\n" +
                                    "Cần thanh toán: " + tongThanhToan.ToString("N0") + " Đ\n" +
                                    "Còn thiếu: " + thieu.ToString("N0") + " Đ");
                            }

                            decimal soDuSau = soDuTruoc - tongThanhToan;

                            using (SqlCommand cmd = new SqlCommand(
                                @"UPDATE ViDienTu
                                  SET SoDu=@SoDuSau,
                                      NgayCapNhat=GETDATE()
                                  WHERE MaVi=@MaVi
                                    AND SoDu >= @SoTien",
                                conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaVi", maVi);
                                AddDecimalParameter(cmd, "@SoTien", tongThanhToan);
                                AddDecimalParameter(cmd, "@SoDuSau", soDuSau);

                                if (cmd.ExecuteNonQuery() != 1)
                                    throw new Exception(
                                        "Không thể trừ số dư ví. Vui lòng thử lại.");
                            }

                            using (SqlCommand cmd = new SqlCommand(
                                @"INSERT INTO GiaoDichVi
                                  (
                                      MaVi,
                                      LoaiGD,
                                      SoTien,
                                      SoDuTruoc,
                                      SoDuSau,
                                      NoiDung
                                  )
                                  VALUES
                                  (
                                      @MaVi,
                                      N'Thanh toán',
                                      @SoTien,
                                      @SoDuTruoc,
                                      @SoDuSau,
                                      @NoiDung
                                  )",
                                conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaVi", maVi);
                                AddDecimalParameter(cmd, "@SoTien", tongThanhToan);
                                AddDecimalParameter(cmd, "@SoDuTruoc", soDuTruoc);
                                AddDecimalParameter(cmd, "@SoDuSau", soDuSau);
                                cmd.Parameters.Add(
                                    "@NoiDung",
                                    SqlDbType.NVarChar,
                                    500).Value =
                                    "Thanh toán đơn online";

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // -----------------------------------------------------
                        // 4. Tạo DonOnline
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
                        // 5. Tạo ChiTietDonOnline
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
                        // 6. Ghi nhận voucher đã sử dụng
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
                        // 7. COMMIT
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
