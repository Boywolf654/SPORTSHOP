using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class Quản_lí_sản_phẩm_FormSanPham : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        // Lưu mã sản phẩm đang chọn
        private int? maSPDangChon = null;
        private int? maSPCanSua = null;

        public Quản_lí_sản_phẩm_FormSanPham()
        {
            InitializeComponent();

            btnThemSP.Click += btnThemSP_Click;
            btnSuaSP.Click += btnSuaSP_Click;
            btnXoaSP.Click += btnXoaSP_Click;
            btnLamMoiSP.Click += btnLamMoiSP_Click;

            btnThemBienThe.Click += btnThemBienThe_Click;
            btnSuaBienThe.Click += btnSuaBienThe_Click;
            btnXoaBienThe.Click += btnXoaBienThe_Click;
            btnLamMoiBienThe.Click += btnLamMoiBienThe_Click;

            cmbDanhMuc.SelectedIndexChanged += cmbDanhMuc_SelectedIndexChanged;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            dgvBienThe.CellClick += dgvBienThe_CellClick;


        }
        public Quản_lí_sản_phẩm_FormSanPham(int maSP)
    : this()
        {
            maSPCanSua = maSP;
        }
        // =========================================================
        // BO GÓC BUTTON
        // =========================================================
        private void BoGocButton(Button btn, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(
                btn.Width - radius,
                0,
                radius,
                radius,
                270,
                90);

            path.AddArc(
                btn.Width - radius,
                btn.Height - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                0,
                btn.Height - radius,
                radius,
                radius,
                90,
                90);

            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        // =========================================================
        // LOAD FORM
        // =========================================================
        private void Quản_lí_sản_phẩm_FormSanPham_Load(
            object sender,
            EventArgs e)
        {
            // Bo góc các button
            BoGocButton(btnThemSP, 10);
            BoGocButton(btnSuaSP, 10);
            BoGocButton(btnXoaSP, 10);
            BoGocButton(btnLamMoiSP, 10);

            BoGocButton(btnThemBienThe, 10);
            BoGocButton(btnSuaBienThe, 10);
            BoGocButton(btnXoaBienThe, 10);
            BoGocButton(btnLamMoiBienThe, 10);

            // Load dữ liệu
            LoadDanhMuc();
            LoadThuongHieu();
            LoadSanPham();

            
            LoadMau();
            ClearForm();

            if (maSPCanSua != null)
            {
                ChonSanPhamCanSua(maSPCanSua.Value);
            }
        }

        private void ChonSanPhamCanSua(int maSP)
        {
            for (int i = 0; i < dgvSanPham.Rows.Count; i++)
            {
                if (Convert.ToInt32(
                    dgvSanPham.Rows[i].Cells["MaSP"].Value) == maSP)
                {
                    dgvSanPham.CurrentCell =
                        dgvSanPham.Rows[i].Cells["MaSP"];

                    dgvSanPham.Rows[i].Selected = true;

                    dgvSanPham_CellClick(
                        dgvSanPham,
                        new DataGridViewCellEventArgs(0, i));

                    break;
                }
            }
        }

        private void LoadSize(int maDM)
        {
            string sql = @"
        SELECT MaSize, TenSize
        FROM Size
        WHERE TrangThai = 1
          AND MaDM = @MaDM
        ORDER BY TenSize";

            SqlParameter[] parameters =
            {
        new SqlParameter("@MaDM", maDM)
    };

            DataTable dt = kt.GetData(sql, parameters);

            cmbSize.DataSource = dt;
            cmbSize.DisplayMember = "TenSize";
            cmbSize.ValueMember = "MaSize";
        }

        private void cmbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDanhMuc.SelectedValue == null)
                return;

            if (cmbDanhMuc.SelectedValue is DataRowView)
                return;

            int maDM;

            if (!int.TryParse(cmbDanhMuc.SelectedValue.ToString(), out maDM))
                return;

            LoadSize(maDM);
        }

        private void LoadMau()
        {
            string sql = @"
        SELECT MaMau, TenMau
        FROM MauSac
        WHERE TrangThai = 1
        ORDER BY TenMau";

            DataTable dt = kt.GetData(sql);

            cmbMau.DataSource = null;
            cmbMau.DataSource = dt;
            cmbMau.DisplayMember = "TenMau";
            cmbMau.ValueMember = "MaMau";
            cmbMau.SelectedIndex = -1;
        }

        private void LoadBienThe(int maSP)
        {
            string sql = @"
        SELECT
            bt.MaBienThe,
            bt.MaSP,
            s.TenSize,
            m.TenMau,
            bt.SKU,
            bt.GiaNhap,
            bt.GiaBan,
            bt.SoLuong,
            bt.TrangThai
        FROM BienTheSanPham bt
        INNER JOIN Size s ON s.MaSize = bt.MaSize
        INNER JOIN MauSac m ON m.MaMau = bt.MaMau
        WHERE bt.MaSP = @MaSP
          AND bt.TrangThai = 1
        ORDER BY bt.MaBienThe";

            SqlParameter[] parameters =
            {
        new SqlParameter("@MaSP", maSP)
    };

            DataTable dt = kt.GetData(sql, parameters);

            dgvBienThe.DataSource = dt;

            if (dgvBienThe.Columns["MaBienThe"] != null)
                dgvBienThe.Columns["MaBienThe"].HeaderText = "Mã biến thể";

            if (dgvBienThe.Columns["MaSP"] != null)
                dgvBienThe.Columns["MaSP"].Visible = false;

            if (dgvBienThe.Columns["TenSize"] != null)
                dgvBienThe.Columns["TenSize"].HeaderText = "Size";

            if (dgvBienThe.Columns["TenMau"] != null)
                dgvBienThe.Columns["TenMau"].HeaderText = "Màu";

            if (dgvBienThe.Columns["SKU"] != null)
                dgvBienThe.Columns["SKU"].HeaderText = "SKU";

            if (dgvBienThe.Columns["GiaNhap"] != null)
            {
                dgvBienThe.Columns["GiaNhap"].HeaderText = "Giá nhập";
                dgvBienThe.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            }

            if (dgvBienThe.Columns["GiaBan"] != null)
            {
                dgvBienThe.Columns["GiaBan"].HeaderText = "Giá bán";
                dgvBienThe.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            }

            if (dgvBienThe.Columns["SoLuong"] != null)
                dgvBienThe.Columns["SoLuong"].HeaderText = "Số lượng";

            if (dgvBienThe.Columns["TrangThai"] != null)
                dgvBienThe.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvBienThe.ReadOnly = true;
            dgvBienThe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBienThe.MultiSelect = false;
        }
        // =========================================================
        // LOAD DANH MỤC
        // =========================================================
        private void LoadDanhMuc()
        {
            string sql = @"
                SELECT MaDM, TenDanhMuc
                FROM DanhMuc
                WHERE TrangThai = 1
                ORDER BY TenDanhMuc";

            DataTable dt = kt.GetData(sql);

            cmbDanhMuc.DataSource = null;
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDM";
            cmbDanhMuc.SelectedIndex = -1;
        }

        // =========================================================
        // LOAD THƯƠNG HIỆU
        // =========================================================
        private void LoadThuongHieu()
        {
            string sql = @"
                SELECT MaTH, TenThuongHieu
                FROM ThuongHieu
                WHERE TrangThai = 1
                ORDER BY TenThuongHieu";

            DataTable dt = kt.GetData(sql);

            cmbThuongHieu.DataSource = null;
            cmbThuongHieu.DataSource = dt;
            cmbThuongHieu.DisplayMember = "TenThuongHieu";
            cmbThuongHieu.ValueMember = "MaTH";
            cmbThuongHieu.SelectedIndex = -1;
        }

        // =========================================================
        // LOAD DANH SÁCH SẢN PHẨM
        // =========================================================
        private void LoadSanPham()
        {
            try
            {
                string sql = @"
                    SELECT
                        sp.MaSP,
                        sp.TenSP,
                        sp.MaDM,
                        dm.TenDanhMuc,
                        sp.MaTH,
                        th.TenThuongHieu,
                        sp.MoTa,
                        sp.TrangThai,
                        sp.NgayTao
                    FROM SanPham sp
                    INNER JOIN DanhMuc dm
                        ON dm.MaDM = sp.MaDM
                    INNER JOIN ThuongHieu th
                        ON th.MaTH = sp.MaTH
                    ORDER BY sp.MaSP DESC";

                DataTable dt = kt.GetData(sql);

                dgvSanPham.DataSource = dt;

                // Ẩn mã danh mục và mã thương hiệu
                if (dgvSanPham.Columns["MaDM"] != null)
                    dgvSanPham.Columns["MaDM"].Visible = false;

                if (dgvSanPham.Columns["MaTH"] != null)
                    dgvSanPham.Columns["MaTH"].Visible = false;

                // Tên cột
                if (dgvSanPham.Columns["MaSP"] != null)
                    dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";

                if (dgvSanPham.Columns["TenSP"] != null)
                    dgvSanPham.Columns["TenSP"].HeaderText =
                        "Tên sản phẩm";

                if (dgvSanPham.Columns["TenDanhMuc"] != null)
                    dgvSanPham.Columns["TenDanhMuc"].HeaderText =
                        "Danh mục";

                if (dgvSanPham.Columns["TenThuongHieu"] != null)
                    dgvSanPham.Columns["TenThuongHieu"].HeaderText =
                        "Thương hiệu";

                if (dgvSanPham.Columns["MoTa"] != null)
                    dgvSanPham.Columns["MoTa"].HeaderText = "Mô tả";

                if (dgvSanPham.Columns["TrangThai"] != null)
                    dgvSanPham.Columns["TrangThai"].HeaderText =
                        "Trạng thái";

                if (dgvSanPham.Columns["NgayTao"] != null)
                {
                    dgvSanPham.Columns["NgayTao"].HeaderText =
                        "Ngày tạo";

                    dgvSanPham.Columns["NgayTao"]
                        .DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                dgvSanPham.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvSanPham.MultiSelect = false;
                dgvSanPham.ReadOnly = true;
                dgvSanPham.AllowUserToAddRows = false;

                dgvSanPham.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CLICK CHỌN SẢN PHẨM
        // =========================================================
        private void dgvSanPham_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvSanPham.Rows[e.RowIndex];

                maSPDangChon =
                    Convert.ToInt32(
                        row.Cells["MaSP"].Value);
                LoadBienThe(maSPDangChon.Value);

                txtTenSP.Text =
                    row.Cells["TenSP"].Value?.ToString() ?? "";

                txtMoTa.Text =
                    row.Cells["MoTa"].Value?.ToString() ?? "";

                if (row.Cells["MaDM"].Value != DBNull.Value)
                {
                    cmbDanhMuc.SelectedValue =
                        Convert.ToInt32(
                            row.Cells["MaDM"].Value);
                }

                if (row.Cells["MaTH"].Value != DBNull.Value)
                {
                    cmbThuongHieu.SelectedValue =
                        Convert.ToInt32(
                            row.Cells["MaTH"].Value);
                }

                if (row.Cells["TrangThai"].Value != DBNull.Value)
                {
                    chkTrangThai.Checked =
                        Convert.ToBoolean(
                            row.Cells["TrangThai"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể chọn sản phẩm.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // THÊM SẢN PHẨM
        // =========================================================
        private void btnThemSP_Click(
            object sender,
            EventArgs e)
        {
            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenSP.Focus();
                return;
            }

            // Kiểm tra danh mục
            if (cmbDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbDanhMuc.Focus();
                return;
            }

            // Kiểm tra thương hiệu
            if (cmbThuongHieu.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn thương hiệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbThuongHieu.Focus();
                return;
            }

            try
            {
                string sql = @"
                    INSERT INTO SanPham
                    (
                        TenSP,
                        MaDM,
                        MaTH,
                        MoTa,
                        TrangThai,
                        NgayTao
                    )
                    VALUES
                    (
                        @TenSP,
                        @MaDM,
                        @MaTH,
                        @MoTa,
                        @TrangThai,
                        GETDATE()
                    )";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@TenSP",
                        txtTenSP.Text.Trim()),

                    new SqlParameter(
                        "@MaDM",
                        Convert.ToInt32(
                            cmbDanhMuc.SelectedValue)),

                    new SqlParameter(
                        "@MaTH",
                        Convert.ToInt32(
                            cmbThuongHieu.SelectedValue)),

                    new SqlParameter(
                        "@MoTa",
                        string.IsNullOrWhiteSpace(txtMoTa.Text)
                            ? (object)DBNull.Value
                            : txtMoTa.Text.Trim()),

                    new SqlParameter(
                        "@TrangThai",
                        chkTrangThai.Checked)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Thêm sản phẩm thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadSanPham();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm sản phẩm.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SỬA SẢN PHẨM
        // =========================================================
        private void btnSuaSP_Click(
            object sender,
            EventArgs e)
        {
            if (maSPDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show(
                    "Tên sản phẩm không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenSP.Focus();
                return;
            }

            if (cmbDanhMuc.SelectedIndex == -1 ||
                cmbThuongHieu.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn đầy đủ danh mục và thương hiệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string sql = @"
                    UPDATE SanPham
                    SET
                        TenSP = @TenSP,
                        MaDM = @MaDM,
                        MaTH = @MaTH,
                        MoTa = @MoTa,
                        TrangThai = @TrangThai
                    WHERE MaSP = @MaSP";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@TenSP",
                        txtTenSP.Text.Trim()),

                    new SqlParameter(
                        "@MaDM",
                        Convert.ToInt32(
                            cmbDanhMuc.SelectedValue)),

                    new SqlParameter(
                        "@MaTH",
                        Convert.ToInt32(
                            cmbThuongHieu.SelectedValue)),

                    new SqlParameter(
                        "@MoTa",
                        string.IsNullOrWhiteSpace(txtMoTa.Text)
                            ? (object)DBNull.Value
                            : txtMoTa.Text.Trim()),

                    new SqlParameter(
                        "@TrangThai",
                        chkTrangThai.Checked),

                    new SqlParameter(
                        "@MaSP",
                        maSPDangChon.Value)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Cập nhật sản phẩm thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadSanPham();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật sản phẩm.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XÓA MỀM
        // =========================================================
        private void btnXoaSP_Click(
            object sender,
            EventArgs e)
        {
            if (maSPDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần ngừng hoạt động.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn ngừng hoạt động sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
                    UPDATE SanPham
                    SET TrangThai = 0
                    WHERE MaSP = @MaSP";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@MaSP",
                        maSPDangChon.Value)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Đã ngừng hoạt động sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadSanPham();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể ngừng hoạt động sản phẩm.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LÀM MỚI
        // =========================================================
        private void btnLamMoiSP_Click(
            object sender,
            EventArgs e)
        {
            ClearForm();
            LoadSanPham();
        }

        // =========================================================
        // XÓA TRẮNG FORM
        // =========================================================
        private void ClearForm()
        {
            maSPDangChon = null;

            txtTenSP.Clear();
            txtMoTa.Clear();

            cmbDanhMuc.SelectedIndex = -1;
            cmbThuongHieu.SelectedIndex = -1;

            chkTrangThai.Checked = true;

            dgvSanPham.ClearSelection();
        }

        

        private void btnThemBienThe_Click(object sender, EventArgs e)
        {
            // Phải chọn sản phẩm trước
            if (maSPDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm trước.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra Size
            if (cmbSize.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn Size.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbSize.Focus();
                return;
            }

            // Kiểm tra Màu
            if (cmbMau.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn màu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbMau.Focus();
                return;
            }

            // Kiểm tra SKU
            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập SKU.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSKU.Focus();
                return;
            }

            // Kiểm tra giá nhập
            decimal giaNhap;

            if (!decimal.TryParse(txtGiaNhap.Text.Trim(), out giaNhap) ||
                giaNhap <= 0)
            {
                MessageBox.Show(
                    "Giá nhập không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaNhap.Focus();
                return;
            }

            // Kiểm tra giá bán
            decimal giaBan;

            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out giaBan) ||
                giaBan <= 0)
            {
                MessageBox.Show(
                    "Giá bán không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaBan.Focus();
                return;
            }

            // Giá bán không được thấp hơn giá nhập
            if (giaBan < giaNhap)
            {
                MessageBox.Show(
                    "Giá bán không được thấp hơn giá nhập.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaBan.Focus();
                return;
            }

            try
            {
                int maSize = Convert.ToInt32(cmbSize.SelectedValue);
                int maMau = Convert.ToInt32(cmbMau.SelectedValue);

                // Kiểm tra trùng Size + Màu
                string sqlCheck = @"
            SELECT COUNT(*)
            FROM BienTheSanPham
            WHERE MaSP = @MaSP
              AND MaSize = @MaSize
              AND MaMau = @MaMau";

                SqlParameter[] checkParams =
                {
            new SqlParameter("@MaSP", maSPDangChon.Value),
            new SqlParameter("@MaSize", maSize),
            new SqlParameter("@MaMau", maMau)
        };

                int tonTai = Convert.ToInt32(
                    kt.ExecuteScalar(sqlCheck, checkParams));

                if (tonTai > 0)
                {
                    MessageBox.Show(
                        "Sản phẩm này đã có biến thể với Size và Màu đã chọn.",
                        "Trùng biến thể",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Kiểm tra SKU trùng
                string sqlCheckSKU = @"
            SELECT COUNT(*)
            FROM BienTheSanPham
            WHERE SKU = @SKU";

                SqlParameter[] skuParams =
                {
            new SqlParameter("@SKU", txtSKU.Text.Trim())
        };

                int trungSKU = Convert.ToInt32(
                    kt.ExecuteScalar(sqlCheckSKU, skuParams));

                if (trungSKU > 0)
                {
                    MessageBox.Show(
                        "SKU này đã tồn tại.",
                        "Trùng SKU",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSKU.Focus();
                    return;
                }

                // Thêm biến thể
                string sql = @"
            INSERT INTO BienTheSanPham
            (
                MaSP,
                MaSize,
                MaMau,
                SKU,
                GiaNhap,
                GiaBan,
                SoLuong,
                TrangThai
            )
            VALUES
            (
                @MaSP,
                @MaSize,
                @MaMau,
                @SKU,
                @GiaNhap,
                @GiaBan,
                0,
                1
            )";

                SqlParameter[] parameters =
                {
            new SqlParameter("@MaSP", maSPDangChon.Value),
            new SqlParameter("@MaSize", maSize),
            new SqlParameter("@MaMau", maMau),
            new SqlParameter("@SKU", txtSKU.Text.Trim()),
            new SqlParameter("@GiaNhap", giaNhap),
            new SqlParameter("@GiaBan", giaBan)
        };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Thêm biến thể thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Load lại danh sách biến thể
                LoadBienThe(maSPDangChon.Value);

                // Xóa dữ liệu nhập
                ClearBienTheForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm biến thể.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearBienTheForm()
        {
            cmbSize.SelectedIndex = -1;
            cmbMau.SelectedIndex = -1;

            txtSKU.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();

            dgvBienThe.ClearSelection();
        }

        private int? maBienTheDangChon = null;

        private void btnSuaBienThe_Click(object sender, EventArgs e)
        {
            if (maBienTheDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn biến thể cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbSize.SelectedIndex == -1 ||
                cmbMau.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn Size và Màu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập SKU.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal giaNhap;
            decimal giaBan;

            if (!decimal.TryParse(txtGiaNhap.Text.Trim(), out giaNhap) ||
                giaNhap <= 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ.");
                txtGiaNhap.Focus();
                return;
            }

            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out giaBan) ||
                giaBan <= 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.");
                txtGiaBan.Focus();
                return;
            }

            if (giaBan < giaNhap)
            {
                MessageBox.Show(
                    "Giá bán không được thấp hơn giá nhập.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maSize = Convert.ToInt32(cmbSize.SelectedValue);
                int maMau = Convert.ToInt32(cmbMau.SelectedValue);

                // Kiểm tra trùng Size + Màu
                string sqlCheck = @"
            SELECT COUNT(*)
            FROM BienTheSanPham
            WHERE MaSP = @MaSP
              AND MaSize = @MaSize
              AND MaMau = @MaMau
              AND MaBienThe <> @MaBienThe";

                SqlParameter[] checkParams =
                {
            new SqlParameter("@MaSP", maSPDangChon.Value),
            new SqlParameter("@MaSize", maSize),
            new SqlParameter("@MaMau", maMau),
            new SqlParameter("@MaBienThe", maBienTheDangChon.Value)
        };

                int trung = Convert.ToInt32(
                    kt.ExecuteScalar(sqlCheck, checkParams));

                if (trung > 0)
                {
                    MessageBox.Show(
                        "Đã tồn tại biến thể có Size và Màu này.",
                        "Trùng biến thể",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra SKU
                string sqlCheckSKU = @"
            SELECT COUNT(*)
            FROM BienTheSanPham
            WHERE SKU = @SKU
              AND MaBienThe <> @MaBienThe";

                SqlParameter[] skuParams =
                {
            new SqlParameter("@SKU", txtSKU.Text.Trim()),
            new SqlParameter("@MaBienThe", maBienTheDangChon.Value)
        };

                int trungSKU = Convert.ToInt32(
                    kt.ExecuteScalar(sqlCheckSKU, skuParams));

                if (trungSKU > 0)
                {
                    MessageBox.Show(
                        "SKU này đã tồn tại.",
                        "Trùng SKU",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string sql = @"
            UPDATE BienTheSanPham
            SET
                MaSize = @MaSize,
                MaMau = @MaMau,
                SKU = @SKU,
                GiaNhap = @GiaNhap,
                GiaBan = @GiaBan
            WHERE MaBienThe = @MaBienThe";

                SqlParameter[] parameters =
                {
            new SqlParameter("@MaSize", maSize),
            new SqlParameter("@MaMau", maMau),
            new SqlParameter("@SKU", txtSKU.Text.Trim()),
            new SqlParameter("@GiaNhap", giaNhap),
            new SqlParameter("@GiaBan", giaBan),
            new SqlParameter("@MaBienThe", maBienTheDangChon.Value)
        };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Cập nhật biến thể thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadBienThe(maSPDangChon.Value);
                ClearBienTheForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật biến thể.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoaBienThe_Click(object sender, EventArgs e)
        {
            if (maBienTheDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn biến thể cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn ngừng hoạt động biến thể này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = @"
            UPDATE BienTheSanPham
            SET TrangThai = 0
            WHERE MaBienThe = @MaBienThe";

                SqlParameter[] parameters =
                {
            new SqlParameter(
                "@MaBienThe",
                maBienTheDangChon.Value)
        };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Đã ngừng hoạt động biến thể.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadBienThe(maSPDangChon.Value);
                ClearBienTheForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể ngừng hoạt động biến thể.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiBienThe_Click(object sender, EventArgs e)
        {
            ClearBienTheForm();

            if (maSPDangChon != null)
            {
                LoadBienThe(maSPDangChon.Value);
            }
        }

        private void dgvBienThe_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvBienThe.Rows[e.RowIndex];

                maBienTheDangChon =
                    Convert.ToInt32(
                        row.Cells["MaBienThe"].Value);

                // Size
                if (row.Cells["TenSize"].Value != null)
                {
                    string tenSize =
                        row.Cells["TenSize"].Value.ToString();

                    for (int i = 0; i < cmbSize.Items.Count; i++)
                    {
                        DataRowView item =
                            cmbSize.Items[i] as DataRowView;

                        if (item != null &&
                            item["TenSize"].ToString() == tenSize)
                        {
                            cmbSize.SelectedIndex = i;
                            break;
                        }
                    }
                }

                // Màu
                if (row.Cells["TenMau"].Value != null)
                {
                    string tenMau =
                        row.Cells["TenMau"].Value.ToString();

                    for (int i = 0; i < cmbMau.Items.Count; i++)
                    {
                        DataRowView item =
                            cmbMau.Items[i] as DataRowView;

                        if (item != null &&
                            item["TenMau"].ToString() == tenMau)
                        {
                            cmbMau.SelectedIndex = i;
                            break;
                        }
                    }
                }

                txtSKU.Text =
                    row.Cells["SKU"].Value?.ToString() ?? "";

                txtGiaNhap.Text =
                    row.Cells["GiaNhap"].Value?.ToString() ?? "";

                txtGiaBan.Text =
                    row.Cells["GiaBan"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể chọn biến thể.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}