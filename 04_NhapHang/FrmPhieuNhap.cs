using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace SPORTSHOP
{
    public partial class FrmPhieuNhap : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        // Phiếu đang chọn
        private int? maPNDangChon = null;

        // Tài khoản người đang thực hiện duyệt
        private int? maTKNguoiDuyet = null;

        public FrmPhieuNhap()
        {
            InitializeComponent();


            // Lấy tài khoản đang đăng nhập
            maTKNguoiDuyet = Session.MaTK;

            // Gắn event ở đây vì Designer hiện tại chưa gắn
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;

            dgvDanhSachPhieu.CellClick += dgvDanhSachPhieu_CellClick;

            btnDuyet.Click += btnDuyet_Click;
            btnTuChoi.Click += btnTuChoi_Click;
            btnDong.Click += btnDong_Click;

            this.Load += FrmPhieuNhap_Load;
        }

     

        // =========================================================
        // LOAD FORM
        // =========================================================
        private void FrmPhieuNhap_Load(object sender, EventArgs e)
        {

            cboTrangThai.Items.Clear();

            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Chờ duyệt");
            cboTrangThai.Items.Add("Chờ xuất kho");
            cboTrangThai.Items.Add("Đã xuất kho");
            cboTrangThai.Items.Add("Đã hủy");

            cboTrangThai.SelectedIndex = 0;

            dtpNgayLap.Value = DateTime.Now;

            ClearChiTiet();
            LoadDanhSachPhieu();
            btnDuyet.Enabled = false;
            btnTuChoi.Enabled = false;

            if (!PhanQuyen.CoQuyenDuyetPhieuNhap())
            {
                btnDuyet.Visible = false;
                btnTuChoi.Visible = false;
            }
        }

        // =========================================================
        // LOAD DANH SÁCH PHIẾU
        // =========================================================
        private void LoadDanhSachPhieu()
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                string trangThai = cboTrangThai.Text;

                string sql = @"
                    SELECT
                        pn.MaPN,
                        pn.NgayNhap,
                        nv.HoTen AS TenNhanVien,
                        ncc.TenNCC,
                        k.TenKho,
                        pn.TrangThai
                    FROM PhieuNhap pn
                    INNER JOIN NhanVien nv
                        ON nv.MaNV = pn.MaNV
                    INNER JOIN NhaCungCap ncc
                        ON ncc.MaNCC = pn.MaNCC
                    LEFT JOIN Kho k
                        ON k.MaKho = pn.MaKho
                    WHERE
                    (
                        CAST(pn.MaPN AS NVARCHAR(20)) LIKE '%' + @TuKhoa + '%'
                        OR nv.HoTen LIKE '%' + @TuKhoa + '%'
                        OR ncc.TenNCC LIKE '%' + @TuKhoa + '%'
                    )
                    AND
                    (
                        @TrangThai = N'Tất cả'
                        OR pn.TrangThai = @TrangThai
                    )
                    ORDER BY pn.MaPN DESC";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@TuKhoa", tuKhoa),
                    new SqlParameter("@TrangThai",
                        string.IsNullOrWhiteSpace(trangThai)
                            ? "Tất cả"
                            : trangThai)
                };

                DataTable dt = kt.GetData(sql, parameters);

                dgvDanhSachPhieu.DataSource = dt;

                DinhDangDanhSachPhieu();
                lblSoPhieu.Text =
                    "Danh sách phiếu (" + dt.Rows.Count + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách phiếu nhập.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DinhDangDanhSachPhieu()
        {
            if (dgvDanhSachPhieu.Columns["MaPN"] != null)
                dgvDanhSachPhieu.Columns["MaPN"].HeaderText = "Mã phiếu";

            if (dgvDanhSachPhieu.Columns["NgayNhap"] != null)
            {
                dgvDanhSachPhieu.Columns["NgayNhap"].HeaderText =
                    "Ngày nhập";

                dgvDanhSachPhieu.Columns["NgayNhap"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvDanhSachPhieu.Columns["TenNhanVien"] != null)
                dgvDanhSachPhieu.Columns["TenNhanVien"].HeaderText =
                    "Nhân viên";

            if (dgvDanhSachPhieu.Columns["TenNCC"] != null)
                dgvDanhSachPhieu.Columns["TenNCC"].HeaderText =
                    "Nhà cung cấp";

            if (dgvDanhSachPhieu.Columns["TenKho"] != null)
                dgvDanhSachPhieu.Columns["TenKho"].HeaderText =
                    "Kho";

            if (dgvDanhSachPhieu.Columns["TrangThai"] != null)
                dgvDanhSachPhieu.Columns["TrangThai"].HeaderText =
                    "Trạng thái";
        }

        // =========================================================
        // TÌM KIẾM
        // =========================================================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieu();
        }

        // =========================================================
        // LỌC TRẠNG THÁI
        // =========================================================
        private void cboTrangThai_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadDanhSachPhieu();
        }

        // =========================================================
        // CHỌN PHIẾU
        // =========================================================
        private void dgvDanhSachPhieu_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvDanhSachPhieu.Rows[e.RowIndex];

                maPNDangChon =
                    Convert.ToInt32(row.Cells["MaPN"].Value);

                txtMaPhieu.Text =
                    "PN" + maPNDangChon.Value.ToString("D4");

                txtNhanVien.Text =
                    row.Cells["TenNhanVien"].Value?.ToString() ?? "";

                txtNhaCungCap.Text =
                    row.Cells["TenNCC"].Value?.ToString() ?? "";
                
                txtKho.Text =
                    row.Cells["TenKho"].Value?.ToString() ?? "";

                if (row.Cells["NgayNhap"].Value != DBNull.Value)
                {
                    dtpNgayLap.Value =
                        Convert.ToDateTime(
                            row.Cells["NgayNhap"].Value);
                }

                string trangThai =
                    row.Cells["TrangThai"].Value?.ToString() ?? "";

                HienThiTrangThai(trangThai);

                LoadChiTietPhieu(maPNDangChon.Value);

                // Chỉ cho duyệt / từ chối khi đang Chờ duyệt
                bool choDuyet = trangThai == "Chờ duyệt";

                btnDuyet.Enabled = choDuyet;
                btnTuChoi.Enabled = choDuyet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải phiếu.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD CHI TIẾT PHIẾU
        // =========================================================
        private void LoadChiTietPhieu(int maPN)
        {
                    string sql = @"
                SELECT
                ct.MaBienThe,
                bt.SKU,
                sp.TenSP,
                sz.TenSize,
                ms.TenMau,
                ct.SoLuong,
                ct.DonGia,
                ct.SoLuong * ct.DonGia AS ThanhTien
                FROM ChiTietPhieuNhap ct
                INNER JOIN BienTheSanPham bt
                    ON bt.MaBienThe = ct.MaBienThe
                INNER JOIN SanPham sp
                    ON sp.MaSP = bt.MaSP
                INNER JOIN Size sz
                    ON sz.MaSize = bt.MaSize
                INNER JOIN MauSac ms
                    ON ms.MaMau = bt.MaMau
                WHERE ct.MaPN = @MaPN
                ORDER BY sp.TenSP";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaPN", maPN)
            };

            DataTable dt = kt.GetData(sql, parameters);

            dgvDanhSachSP.DataSource = dt;

            DinhDangChiTiet();
            TinhTongCong(dt);
        }

        private void DinhDangChiTiet()
        {
            if (dgvDanhSachSP.Columns["SKU"] != null)
            {
                dgvDanhSachSP.Columns["SKU"].HeaderText =
                    "Mã biến thể (SKU)";
            }
            if (dgvDanhSachSP.Columns["MaBienThe"] != null)
                dgvDanhSachSP.Columns["MaBienThe"]
                    .Visible = false;

            if (dgvDanhSachSP.Columns["TenSP"] != null)
                dgvDanhSachSP.Columns["TenSP"].HeaderText =
                    "Sản phẩm";

            if (dgvDanhSachSP.Columns["TenSize"] != null)
                dgvDanhSachSP.Columns["TenSize"].HeaderText =
                    "Size";

            if (dgvDanhSachSP.Columns["TenMau"] != null)
                dgvDanhSachSP.Columns["TenMau"].HeaderText =
                    "Màu";

            if (dgvDanhSachSP.Columns["SoLuong"] != null)
                dgvDanhSachSP.Columns["SoLuong"].HeaderText =
                    "Số lượng";

            if (dgvDanhSachSP.Columns["DonGia"] != null)
            {
                dgvDanhSachSP.Columns["DonGia"].HeaderText =
                    "Đơn giá";

                dgvDanhSachSP.Columns["DonGia"]
                    .DefaultCellStyle.Format = "N0";
            }

            if (dgvDanhSachSP.Columns["ThanhTien"] != null)
            {
                dgvDanhSachSP.Columns["ThanhTien"].HeaderText =
                    "Thành tiền";

                dgvDanhSachSP.Columns["ThanhTien"]
                    .DefaultCellStyle.Format = "N0";
            }
        }

        private void TinhTongCong(DataTable dt)
        {
            decimal tongTien = 0;
            int tongSoLuong = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["SoLuong"] != DBNull.Value)
                {
                    tongSoLuong += Convert.ToInt32(row["SoLuong"]);
                }

                if (row["ThanhTien"] != DBNull.Value)
                {
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }
            }

            lblTongSoLuong.Text =
                "Tổng số lượng: " + tongSoLuong.ToString("N0");

            lblTongCong.Text =
                "Tổng cộng: " + tongTien.ToString("N0") + " VNĐ";
        }

        // =========================================================
        // DUYỆT PHIẾU
        // =========================================================
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (!PhanQuyen.CoQuyenDuyetPhieuNhap())
            {
                MessageBox.Show(
                    "Tài khoản của bạn không có quyền duyệt phiếu nhập!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (maPNDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phiếu cần duyệt.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn duyệt phiếu " +
                txtMaPhieu.Text + " không?",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
            UPDATE PhieuNhap
            SET TrangThai = N'Chờ xuất kho'
            WHERE MaPN = @MaPN
              AND TrangThai = N'Chờ duyệt'";

                SqlParameter[] parameters =
                {
            new SqlParameter("@MaPN", maPNDangChon.Value)
        };

                int affected = kt.Execute(sql, parameters);

                if (affected == 0)
                {
                    MessageBox.Show(
                        "Phiếu không còn ở trạng thái Chờ duyệt.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(
                    "Duyệt phiếu thành công!\n\n" +
                    "Phiếu đã chuyển sang trạng thái 'Chờ xuất kho'.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                maPNDangChon = null;

                ClearChiTiet();
                LoadDanhSachPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Duyệt phiếu thất bại.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // TỪ CHỐI PHIẾU
        // =========================================================
        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (!PhanQuyen.CoQuyenDuyetPhieuNhap())
            {
                MessageBox.Show(
                    "Tài khoản của bạn không có quyền từ chối phiếu nhập!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            if (maPNDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phiếu cần từ chối.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn từ chối phiếu " +
                txtMaPhieu.Text + " không?",
                "Xác nhận từ chối",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
                    UPDATE PhieuNhap
                    SET TrangThai = N'Đã hủy'
                    WHERE MaPN = @MaPN
                      AND TrangThai = N'Chờ duyệt'";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@MaPN",
                        maPNDangChon.Value)
                };

                int affected =
                    kt.Execute(sql, parameters);

                if (affected == 0)
                {
                    MessageBox.Show(
                        "Phiếu không còn ở trạng thái Chờ duyệt.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    "Đã từ chối phiếu nhập.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                maPNDangChon = null;

                ClearChiTiet();
                LoadDanhSachPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể từ chối phiếu.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ĐÓNG
        // =========================================================
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================================================
        // XÓA CHI TIẾT
        // =========================================================
        private void ClearChiTiet()
        {
            maPNDangChon = null;

            txtMaPhieu.Text = "";
            txtNhanVien.Text = "";
            txtNhaCungCap.Text = "";

            dtpNgayLap.Value = DateTime.Now;

            dgvDanhSachSP.DataSource = null;

            lblTongCong.Text = "Tổng cộng: 0 VNĐ";
            

            btnDuyet.Enabled = false;
            btnTuChoi.Enabled = false;
        }

        // =========================================================
        // CÁC EVENT RỖNG DO DESIGNER ĐÃ TẠO
        // =========================================================
        private void flowLayoutPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void guna2GroupBox1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void grpChiTietHangHoa_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtNguoiLap_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void txtSoPhieu_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void HienThiTrangThai(string trangThai)
        {
            lblTrangThai.Text = trangThai;

            switch (trangThai)
            {
                case "Chờ duyệt":
                    lblTrangThai.BackColor =
                        Color.FromArgb(255, 243, 205);

                    lblTrangThai.ForeColor =
                        Color.FromArgb(180, 120, 0);
                    break;

                case "Hoàn tất":
                    lblTrangThai.BackColor =
                        Color.FromArgb(220, 245, 228);

                    lblTrangThai.ForeColor =
                        Color.FromArgb(35, 130, 70);
                    break;

                case "Đã hủy":
                    lblTrangThai.BackColor =
                        Color.FromArgb(252, 225, 225);

                    lblTrangThai.ForeColor =
                        Color.FromArgb(190, 50, 50);
                    break;

                default:
                    lblTrangThai.BackColor =
                        Color.LightGray;

                    lblTrangThai.ForeColor =
                        Color.Black;
                    break;
            }

            lblTrangThai.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);
        }
    }
}