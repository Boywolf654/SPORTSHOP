using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._04_NhapHang
{
    public partial class FormNhapHang : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        // Một phiếu nhập chỉ có một nhà cung cấp.
        private bool dangCoSanPhamTrongPhieu = false;

        // Tên các cột của dgv_chitietSP
        private const string COL_MA_BT = "MaBienThe";
        private const string COL_TEN_SP = "TenSP";
        private const string COL_SIZE = "TenSize";
        private const string COL_MAU = "TenMau";
        private const string COL_SO_LUONG = "SoLuong";
        private const string COL_DON_GIA = "DonGia";
        private const string COL_THANH_TIEN = "ThanhTien";

        public FormNhapHang()
        {
            InitializeComponent();

            // ==============================
            // BUTTON
            // ==============================

            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;

            btn_ThemPhieu.Click += btn_ThemPhieu_Click;
            btn_xoadong.Click += btn_xoadong_Click;

            // ==============================
            // TÌM KIẾM
            // ==============================

            btn_timSP.TextChanged += btn_timSP_TextChanged;

            // ==============================
            // DATAGRIDVIEW CHI TIẾT
            // ==============================

            dgv_chitietSP.CellValidating +=
                dgv_chitietSP_CellValidating;

            dgv_chitietSP.CellValueChanged +=
                dgv_chitietSP_CellValueChanged;

            dgv_chitietSP.CellEndEdit +=
                dgv_chitietSP_CellEndEdit;

            dgv_chitietSP.RowsRemoved +=
                dgv_chitietSP_RowsRemoved;

            // Click đúp sản phẩm bên trái cũng thêm
            dgv_SanPham.CellDoubleClick +=
                dgv_SanPham_CellDoubleClick;
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void FormNhapHang_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadNhaCungCap();
                LoadKho();
                LoadNhanVien();

                CauHinhDgvSanPham();
                CauHinhDgvChiTiet();

                LoadSanPhamBienThe();

                dtp_NgayNhap.Value = DateTime.Now;

                GNc_ChoDuyet.Text = "Chờ duyệt";

                lblThanhTien1.Text = "Tổng Tiền";
                lblThanhTien2.Text = "Thành tiền: 0 VNĐ";

                cmb_NhaCungCap.ForeColor = Color.Black;
                cmb_Kho.ForeColor = Color.Black;
                cmb_NhanVien.ForeColor = Color.Black;
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
        // CẤU HÌNH BẢNG SẢN PHẨM
        // =========================================================

        private void CauHinhDgvSanPham()
        {
            dgv_SanPham.DataSource = null;
            dgv_SanPham.AutoGenerateColumns = true;

            dgv_SanPham.AllowUserToAddRows = false;
            dgv_SanPham.AllowUserToDeleteRows = false;

            dgv_SanPham.ReadOnly = true;

            dgv_SanPham.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_SanPham.MultiSelect = false;

            dgv_SanPham.RowHeadersVisible = false;

            dgv_SanPham.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dgv_SanPham.RowTemplate.Height = 30;

            dgv_SanPham.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv_SanPham.Cursor =
                Cursors.Hand;
        }

        // =========================================================
        // LOAD SẢN PHẨM + BIẾN THỂ
        // =========================================================

        private void LoadSanPhamBienThe()
        {
            string tuKhoa =
                btn_timSP.Text.Trim();

            string sql = @"
                SELECT
                    bt.MaBienThe,
                    sp.TenSP,
                    sz.TenSize,
                    ms.TenMau
                FROM BienTheSanPham bt
                INNER JOIN SanPham sp
                    ON sp.MaSP = bt.MaSP
                INNER JOIN Size sz
                    ON sz.MaSize = bt.MaSize
                INNER JOIN MauSac ms
                    ON ms.MaMau = bt.MaMau
                WHERE sp.TrangThai = 1
                  AND bt.TrangThai = 1
                  AND
                  (
                      @TuKhoa = ''
                      OR sp.TenSP LIKE @TuKhoaLike
                      OR sz.TenSize LIKE @TuKhoaLike
                      OR ms.TenMau LIKE @TuKhoaLike
                      OR CONVERT(VARCHAR(20), bt.MaBienThe)
                         LIKE @TuKhoaLike
                  )
                ORDER BY
                    sp.TenSP,
                    sz.TenSize,
                    ms.TenMau";

            SqlParameter[] parameters =
            {
                new SqlParameter(
                    "@TuKhoa",
                    tuKhoa),

                new SqlParameter(
                    "@TuKhoaLike",
                    "%" + tuKhoa + "%")
            };

            DataTable dt =
                kt.GetData(
                    sql,
                    parameters);

            dgv_SanPham.DataSource = dt;

            DoiTenCotSanPham();

            dgv_SanPham.ClearSelection();
        }

        // =========================================================
        // ĐỔI TÊN CỘT BẢNG SẢN PHẨM
        // =========================================================

        private void DoiTenCotSanPham()
        {
            if (dgv_SanPham.Columns.Contains("MaBienThe"))
            {
                dgv_SanPham.Columns["MaBienThe"]
                    .HeaderText = "Mã BT";

                dgv_SanPham.Columns["MaBienThe"]
                    .Width = 60;
            }

            if (dgv_SanPham.Columns.Contains("TenSP"))
            {
                dgv_SanPham.Columns["TenSP"]
                    .HeaderText = "Sản phẩm";
            }

            if (dgv_SanPham.Columns.Contains("TenSize"))
            {
                dgv_SanPham.Columns["TenSize"]
                    .HeaderText = "Size";
            }

            if (dgv_SanPham.Columns.Contains("TenMau"))
            {
                dgv_SanPham.Columns["TenMau"]
                    .HeaderText = "Màu";
            }
        }

        // =========================================================
        // CẤU HÌNH BẢNG CHI TIẾT
        // =========================================================

        private void CauHinhDgvChiTiet()
        {
            dgv_chitietSP.DataSource = null;
            dgv_chitietSP.Columns.Clear();

            dgv_chitietSP.AutoGenerateColumns = false;

            dgv_chitietSP.AllowUserToAddRows = false;
            dgv_chitietSP.AllowUserToDeleteRows = false;

            dgv_chitietSP.ReadOnly = false;

            // Cho phép click trực tiếp vào ô SL / Đơn giá để nhập.
            dgv_chitietSP.EditMode = DataGridViewEditMode.EditOnEnter;

            dgv_chitietSP.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_chitietSP.MultiSelect = false;

            dgv_chitietSP.RowHeadersVisible = false;

            dgv_chitietSP.RowTemplate.Height = 30;

            dgv_chitietSP.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // -------------------------
            // MÃ BIẾN THỂ
            // -------------------------

            DataGridViewTextBoxColumn colMa =
                new DataGridViewTextBoxColumn();

            colMa.Name = COL_MA_BT;
            colMa.HeaderText = "Mã BT";
            colMa.ReadOnly = true;
            colMa.Visible = false;

            dgv_chitietSP.Columns.Add(colMa);

            // -------------------------
            // TÊN SẢN PHẨM
            // -------------------------

            DataGridViewTextBoxColumn colTen =
                new DataGridViewTextBoxColumn();

            colTen.Name = COL_TEN_SP;
            colTen.HeaderText = "Sản phẩm";
            colTen.ReadOnly = true;
            colTen.FillWeight = 180;

            dgv_chitietSP.Columns.Add(colTen);

            // -------------------------
            // SIZE
            // -------------------------

            DataGridViewTextBoxColumn colSize =
                new DataGridViewTextBoxColumn();

            colSize.Name = COL_SIZE;
            colSize.HeaderText = "Size";
            colSize.ReadOnly = true;
            colSize.FillWeight = 60;

            dgv_chitietSP.Columns.Add(colSize);

            // -------------------------
            // MÀU
            // -------------------------

            DataGridViewTextBoxColumn colMau =
                new DataGridViewTextBoxColumn();

            colMau.Name = COL_MAU;
            colMau.HeaderText = "Màu";
            colMau.ReadOnly = true;
            colMau.FillWeight = 80;

            dgv_chitietSP.Columns.Add(colMau);

            // -------------------------
            // SỐ LƯỢNG
            // -------------------------

            DataGridViewTextBoxColumn colSL =
                new DataGridViewTextBoxColumn();

            colSL.Name = COL_SO_LUONG;
            colSL.HeaderText = "SL";
            colSL.ReadOnly = false;
            colSL.FillWeight = 60;

            dgv_chitietSP.Columns.Add(colSL);

            // -------------------------
            // ĐƠN GIÁ
            // -------------------------

            DataGridViewTextBoxColumn colGia =
                new DataGridViewTextBoxColumn();

            colGia.Name = COL_DON_GIA;
            colGia.HeaderText = "Đơn giá";
            colGia.ReadOnly = false;
            colGia.FillWeight = 110;

            dgv_chitietSP.Columns.Add(colGia);

            // -------------------------
            // THÀNH TIỀN
            // -------------------------

            DataGridViewTextBoxColumn colThanhTien =
                new DataGridViewTextBoxColumn();

            colThanhTien.Name = COL_THANH_TIEN;
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.ReadOnly = true;
            colThanhTien.FillWeight = 120;

            dgv_chitietSP.Columns.Add(
                colThanhTien);
        }

        // =========================================================
        // TÌM KIẾM
        // =========================================================

        private void btn_timSP_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadSanPhamBienThe();
            }
            catch
            {
                // Không hiện MessageBox liên tục khi người dùng đang gõ
            }
        }

        // =========================================================
        // DOUBLE CLICK SẢN PHẨM
        // =========================================================

        private void dgv_SanPham_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ThemSanPhamVaoPhieu();
        }

        // =========================================================
        // THÊM VÀO PHIẾU
        // =========================================================

        private void btn_ThemPhieu_Click(
            object sender,
            EventArgs e)
        {
            ThemSanPhamVaoPhieu();
        }

        private void ThemSanPhamVaoPhieu()
        {
            if (cmb_NhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp trước khi thêm sản phẩm.",
                    "Chưa chọn nhà cung cấp",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmb_NhaCungCap.Focus();
                return;
            }

            if (dgv_SanPham.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn một biến thể sản phẩm.",
                    "Chưa chọn sản phẩm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow row =
                dgv_SanPham.CurrentRow;

            int maBienThe =
                Convert.ToInt32(
                    row.Cells["MaBienThe"].Value);

            string tenSP =
                Convert.ToString(
                    row.Cells["TenSP"].Value);

            string tenSize =
                Convert.ToString(
                    row.Cells["TenSize"].Value);

            string tenMau =
                Convert.ToString(
                    row.Cells["TenMau"].Value);

            // Không cho thêm trùng biến thể
            foreach (DataGridViewRow item
                in dgv_chitietSP.Rows)
            {
                if (item.IsNewRow)
                    continue;

                int maCu =
                    Convert.ToInt32(
                        item.Cells[COL_MA_BT].Value);

                if (maCu == maBienThe)
                {
                    MessageBox.Show(
                        "Biến thể này đã có trong phiếu.\n\n" +
                        tenSP +
                        " - Size " +
                        tenSize +
                        " - " +
                        tenMau,
                        "Sản phẩm đã tồn tại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    dgv_chitietSP.CurrentCell =
                        item.Cells[COL_SO_LUONG];

                    return;
                }
            }

            int index =
                dgv_chitietSP.Rows.Add();

            DataGridViewRow newRow =
                dgv_chitietSP.Rows[index];

            newRow.Cells[COL_MA_BT].Value =
                maBienThe;

            newRow.Cells[COL_TEN_SP].Value =
                tenSP;

            newRow.Cells[COL_SIZE].Value =
                tenSize;

            newRow.Cells[COL_MAU].Value =
                tenMau;

            // Mặc định số lượng = 1
            newRow.Cells[COL_SO_LUONG].Value =
                1;

            // Đơn giá để người dùng nhập
            newRow.Cells[COL_DON_GIA].Value =
                "";

            newRow.Cells[COL_THANH_TIEN].Value =
                "0";

            CapNhatTongTien();

            // Chuyển focus sang số lượng
            dgv_chitietSP.CurrentCell =
                newRow.Cells[COL_SO_LUONG];

            dgv_chitietSP.BeginEdit(true);

            dangCoSanPhamTrongPhieu = true;
            cmb_NhaCungCap.Enabled = false;
        }

        // =========================================================
        // XÓA DÒNG
        // =========================================================

        private void btn_xoadong_Click(
            object sender,
            EventArgs e)
        {
            if (dgv_chitietSP.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn dòng cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (dgv_chitietSP.CurrentRow.IsNewRow)
                return;

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa dòng sản phẩm này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dgv_chitietSP.Rows.Remove(
                    dgv_chitietSP.CurrentRow);

                CapNhatTongTien();

                dangCoSanPhamTrongPhieu =
                    dgv_chitietSP.Rows.Count > 0;

                cmb_NhaCungCap.Enabled =
                    !dangCoSanPhamTrongPhieu;
            }
        }

        // =========================================================
        // VALIDATE Ô NHẬP
        // =========================================================

        private void dgv_chitietSP_CellValidating(
            object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgv_chitietSP.Rows[e.RowIndex].IsNewRow)
                return;

            dgv_chitietSP.Rows[e.RowIndex].ErrorText = "";

            string columnName =
                dgv_chitietSP.Columns[e.ColumnIndex].Name;

            string value =
                Convert.ToString(e.FormattedValue).Trim();

            // SỐ LƯỢNG
            if (columnName == COL_SO_LUONG)
            {
                // Cho phép trống tạm thời khi đang nhập.
                // Khi Lưu Phiếu mới bắt buộc > 0.
                if (string.IsNullOrWhiteSpace(value))
                    return;

                int soLuong;

                if (!int.TryParse(value, out soLuong) ||
                    soLuong <= 0)
                {
                    e.Cancel = true;
                    dgv_chitietSP.Rows[e.RowIndex].ErrorText =
                        "Số lượng phải là số nguyên lớn hơn 0.";
                    return;
                }
            }

            // ĐƠN GIÁ
            if (columnName == COL_DON_GIA)
            {
                // Cho phép trống tạm thời khi đang nhập.
                // Khi Lưu Phiếu mới bắt buộc > 0.
                if (string.IsNullOrWhiteSpace(value))
                    return;

                decimal donGia;

                if (!TryParseTien(value, out donGia) ||
                    donGia < 0)
                {
                    e.Cancel = true;
                    dgv_chitietSP.Rows[e.RowIndex].ErrorText =
                        "Đơn giá phải là số không âm.";
                    return;
                }
            }
        }

        // =========================================================
        // CELL END EDIT
        // =========================================================

        private void dgv_chitietSP_CellEndEdit(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dgv_chitietSP.Rows.Count)
                return;

            DataGridViewRow row =
                dgv_chitietSP.Rows[e.RowIndex];

            row.ErrorText = "";

            // Nếu vừa nhập đơn giá thì định dạng lại cho dễ nhìn.
            if (e.ColumnIndex >= 0 &&
                dgv_chitietSP.Columns[e.ColumnIndex].Name == COL_DON_GIA)
            {
                decimal donGia;

                if (TryParseTien(
                    Convert.ToString(
                        row.Cells[COL_DON_GIA].Value),
                    out donGia) &&
                    donGia > 0)
                {
                    row.Cells[COL_DON_GIA].Value =
                        donGia.ToString("N0");
                }
            }

            TinhThanhTienDong(row);
            CapNhatTongTien();
        }

        // =========================================================
        // CELL VALUE CHANGED
        // =========================================================

        private void dgv_chitietSP_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >=
                dgv_chitietSP.Rows.Count)
                return;

            if (e.ColumnIndex < 0)
                return;

            string columnName =
                dgv_chitietSP.Columns[e.ColumnIndex]
                    .Name;

            if (columnName == COL_SO_LUONG ||
                columnName == COL_DON_GIA)
            {
                TinhThanhTienDong(
                    dgv_chitietSP.Rows[e.RowIndex]);

                CapNhatTongTien();
            }
        }

        // =========================================================
        // TÍNH THÀNH TIỀN 1 DÒNG
        // =========================================================

        private void TinhThanhTienDong(
            DataGridViewRow row)
        {
            if (row == null ||
                row.IsNewRow)
                return;

            int soLuong = 0;
            decimal donGia = 0;

            int.TryParse(
                Convert.ToString(
                    row.Cells[COL_SO_LUONG].Value),
                out soLuong);

            TryParseTien(
                Convert.ToString(
                    row.Cells[COL_DON_GIA].Value),
                out donGia);

            decimal thanhTien =
                soLuong * donGia;

            row.Cells[COL_THANH_TIEN].Value =
                thanhTien.ToString("N0");
        }

        // =========================================================
        // TÍNH TỔNG
        // =========================================================

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row
                in dgv_chitietSP.Rows)
            {
                if (row.IsNewRow)
                    continue;

                int soLuong = 0;
                decimal donGia = 0;

                int.TryParse(
                    Convert.ToString(
                        row.Cells[COL_SO_LUONG].Value),
                    out soLuong);

                TryParseTien(
                    Convert.ToString(
                        row.Cells[COL_DON_GIA].Value),
                    out donGia);

                tongTien +=
                    soLuong * donGia;
            }

            lblThanhTien2.Text =
                "Thành tiền: " +
                tongTien.ToString("N0") +
                " VNĐ";
        }

        // =========================================================
        // ĐỌC TIỀN
        // =========================================================

        private bool TryParseTien(
            string text,
            out decimal value)
        {
            value = 0;

            if (string.IsNullOrWhiteSpace(text))
                return false;

            text = text.Trim();

            // Cho phép:
            // 1500000
            // 1.500.000
            // 1,500,000
            text = text
                .Replace(".", "")
                .Replace(",", "")
                .Replace(" ", "");

            return decimal.TryParse(
                text,
                out value);
        }

        // =========================================================
        // VALIDATE HEADER
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

            if (dgv_chitietSP.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Phiếu nhập chưa có sản phẩm.",
                    "Thiếu dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        // =========================================================
        // VALIDATE TOÀN BỘ CHI TIẾT
        // =========================================================

        private bool ValidateChiTiet()
        {
            for (int i = 0;
                 i < dgv_chitietSP.Rows.Count;
                 i++)
            {
                DataGridViewRow row =
                    dgv_chitietSP.Rows[i];

                if (row.IsNewRow)
                    continue;

                int soLuong;

                if (!int.TryParse(
                    Convert.ToString(
                        row.Cells[COL_SO_LUONG].Value),
                    out soLuong) ||
                    soLuong <= 0)
                {
                    MessageBox.Show(
                        "Dòng " +
                        (i + 1) +
                        ": Số lượng không hợp lệ.",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    dgv_chitietSP.CurrentCell =
                        row.Cells[COL_SO_LUONG];

                    return false;
                }

                decimal donGia;

                if (!TryParseTien(
                    Convert.ToString(
                        row.Cells[COL_DON_GIA].Value),
                    out donGia) ||
                    donGia <= 0)
                {
                    MessageBox.Show(
                        "Dòng " +
                        (i + 1) +
                        ": Đơn giá không hợp lệ.",
                        "Lỗi dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    dgv_chitietSP.CurrentCell =
                        row.Cells[COL_DON_GIA];

                    return false;
                }
            }

            return true;
        }

        // =========================================================
        // LƯU PHIẾU
        // =========================================================

        private void btnLuu_Click(
            object sender,
            EventArgs e)
        {
            LuuPhieuNhap();
        }

        private void LuuPhieuNhap()
        {
            if (!ValidateHeader())
                return;

            // Kết thúc việc edit ô hiện tại
            if (!dgv_chitietSP.EndEdit())
                return;

            if (!ValidateChiTiet())
                return;

            foreach (DataGridViewRow row in dgv_chitietSP.Rows)
            {
                if (!row.IsNewRow)
                    TinhThanhTienDong(row);
            }

            CapNhatTongTien();

            DialogResult confirm =
                MessageBox.Show(
                    "Bạn có chắc muốn lưu phiếu nhập này?",
                    "Xác nhận lưu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

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

                            int maPN;

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
                                    SqlDbType.NVarChar,
                                    30)
                                    .Value =
                                    "Chờ duyệt";

                                cmd.Parameters.Add(
                                    "@MaKho",
                                    SqlDbType.Int)
                                    .Value =
                                    Convert.ToInt32(
                                        cmb_Kho.SelectedValue);

                                maPN =
                                    Convert.ToInt32(
                                        cmd.ExecuteScalar());
                            }

                            // =================================================
                            // 2. INSERT TOÀN BỘ CHI TIẾT
                            // =================================================

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

                            foreach (
                                DataGridViewRow row
                                in dgv_chitietSP.Rows)
                            {
                                if (row.IsNewRow)
                                    continue;

                                int maBienThe =
                                    Convert.ToInt32(
                                        row.Cells[
                                            COL_MA_BT]
                                        .Value);

                                int soLuong =
                                    Convert.ToInt32(
                                        row.Cells[
                                            COL_SO_LUONG]
                                        .Value);

                                decimal donGia;

                                if (!TryParseTien(
                                    Convert.ToString(
                                        row.Cells[
                                            COL_DON_GIA]
                                            .Value),
                                    out donGia))
                                {
                                    throw new Exception(
                                        "Đơn giá không hợp lệ.");
                                }

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
                                        .Value =
                                        maBienThe;

                                    cmdCT.Parameters.Add(
                                        "@SoLuong",
                                        SqlDbType.Int)
                                        .Value =
                                        soLuong;

                                    SqlParameter pDonGia =
                                        cmdCT.Parameters.Add(
                                            "@DonGia",
                                            SqlDbType.Decimal);

                                    pDonGia.Precision = 18;
                                    pDonGia.Scale = 2;
                                    pDonGia.Value = donGia;

                                    cmdCT.ExecuteNonQuery();
                                }
                            }

                            // =================================================
                            // 3. COMMIT
                            // =================================================

                            tran.Commit();

                            MessageBox.Show(
                                "Tạo phiếu nhập thành công!\n\n" +
                                "Mã phiếu: PN" +
                                maPN.ToString("D4") +
                                "\nSố dòng: " +
                                dgv_chitietSP.Rows.Count +
                                "\nTrạng thái: Chờ duyệt",
                                "Thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ClearForm();
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
                    "Có lỗi xảy ra.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XÓA / HỦY
        // =========================================================

        private void btnHuy_Click(
            object sender,
            EventArgs e)
        {
            if (dgv_chitietSP.Rows.Count == 0)
            {
                ClearForm();
                return;
            }

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

        private void ClearForm()
        {
            cmb_NhaCungCap.SelectedIndex = -1;
            cmb_Kho.SelectedIndex = -1;
            cmb_NhanVien.SelectedIndex = -1;

            dtp_NgayNhap.Value =
                DateTime.Now;

            dgv_chitietSP.Rows.Clear();

            dangCoSanPhamTrongPhieu = false;
            cmb_NhaCungCap.Enabled = true;

            btn_timSP.Text = "";

            GNc_ChoDuyet.Text =
                "Chờ duyệt";

            lblThanhTien2.Text =
                "Thành tiền: 0 VNĐ";

            try
            {
                LoadSanPhamBienThe();
            }
            catch
            {
            }
        }

        // =========================================================
        // XÓA DÒNG → CẬP NHẬT TỔNG
        // =========================================================

        private void dgv_chitietSP_RowsRemoved(
            object sender,
            DataGridViewRowsRemovedEventArgs e)
        {
            CapNhatTongTien();

            dangCoSanPhamTrongPhieu =
                dgv_chitietSP.Rows.Count > 0;

            cmb_NhaCungCap.Enabled =
                !dangCoSanPhamTrongPhieu;
        }

        // =========================================================
        // EVENT CŨ NẾU DESIGNER ĐANG THAM CHIẾU
        // =========================================================

        private void label9_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}