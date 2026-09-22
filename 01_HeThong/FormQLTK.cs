using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormQLTK : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormQLTK()
        {
            InitializeComponent();

            btn_Mo.Click += btn_Mo_Click;
            Btn_Khoa.Click += Btn_Khoa_Click;
            btn_thoat.Click += btn_thoat_Click;
            btn_phanquyen.Click += btn_phanquyen_Click;

            dgv_QLTK.CellClick += dgv_QLTK_CellClick;

            cmb_trangthai.SelectedIndexChanged += cmb_trangthai_SelectedIndexChanged;
            txt_timtk.TextChanged += txt_timtk_TextChanged;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void FormQLTK_Load(object sender, EventArgs e)
        {
            // Chỉ Admin / Quản lý được vào
            if (Session.MaVaiTro != PhanQuyen.ADMIN &&
                Session.MaVaiTro != PhanQuyen.QUAN_LY)
            {
                MessageBox.Show(
                    "Bạn không có quyền quản lý tài khoản!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            CauHinhDgv();
            LoadComboTrangThai();
            LoadDanhSachTaiKhoan();
        }

        // =========================================================
        // COMBOBOX TRẠNG THÁI
        // =========================================================

        private void LoadComboTrangThai()
        {
            cmb_trangthai.Items.Clear();

            cmb_trangthai.Items.Add("Tất cả");
            cmb_trangthai.Items.Add("Đang hoạt động");
            cmb_trangthai.Items.Add("Đã khóa");

            cmb_trangthai.SelectedIndex = 0;
        }

        private void cmb_trangthai_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadDanhSachTaiKhoan();
        }

        // =========================================================
        // TÌM KIẾM
        // =========================================================

        private void txt_timtk_TextChanged(
            object sender,
            EventArgs e)
        {
            LoadDanhSachTaiKhoan();
        }

        // =========================================================
        // CẤU HÌNH DATAGRIDVIEW
        // =========================================================

        private void CauHinhDgv()
        {
            dgv_QLTK.AutoGenerateColumns = true;

            dgv_QLTK.AllowUserToAddRows = false;
            dgv_QLTK.AllowUserToDeleteRows = false;

            dgv_QLTK.ReadOnly = true;

            dgv_QLTK.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_QLTK.MultiSelect = false;

            dgv_QLTK.RowHeadersVisible = false;

            dgv_QLTK.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv_QLTK.Cursor = Cursors.Hand;
        }

        // =========================================================
        // LOAD DANH SÁCH TÀI KHOẢN
        // =========================================================

        private void LoadDanhSachTaiKhoan()
        {
            try
            {
                string tuKhoa = txt_timtk.Text.Trim();

                string sql = @"
                    SELECT
                        tk.MaTK,
                        tk.TenDangNhap,
                        vt.TenVaiTro,
                        CASE
                            WHEN tk.TrangThai = 1
                                THEN N'Đang hoạt động'
                            ELSE N'Đã khóa'
                        END AS TrangThai,
                        tk.SoLanSaiMatKhau,
                        tk.LanDangNhapCuoi
                    FROM TaiKhoan tk
                    INNER JOIN VaiTro vt
                        ON tk.MaVaiTro = vt.MaVaiTro
                    WHERE
                        tk.TenDangNhap LIKE '%' + @TuKhoa + '%'
                        AND
                        (
                            @TrangThai = -1
                            OR tk.TrangThai = @TrangThai
                        )
                    ORDER BY tk.MaTK";

                int trangThai = -1;

                if (cmb_trangthai.SelectedIndex == 1)
                    trangThai = 1;
                else if (cmb_trangthai.SelectedIndex == 2)
                    trangThai = 0;

                SqlParameter[] parameters =
                {
                    new SqlParameter("@TuKhoa", tuKhoa),
                    new SqlParameter("@TrangThai", trangThai)
                };

                DataTable dt =
                    kt.GetData(sql, parameters);

                dgv_QLTK.DataSource = dt;

                // ==========================
                // ĐỔI TÊN CỘT
                // ==========================

                if (dgv_QLTK.Columns.Contains("MaTK"))
                    dgv_QLTK.Columns["MaTK"].HeaderText = "Mã TK";

                if (dgv_QLTK.Columns.Contains("TenDangNhap"))
                    dgv_QLTK.Columns["TenDangNhap"].HeaderText =
                        "Tên đăng nhập";

                if (dgv_QLTK.Columns.Contains("TenVaiTro"))
                    dgv_QLTK.Columns["TenVaiTro"].HeaderText =
                        "Vai trò";

                if (dgv_QLTK.Columns.Contains("TrangThai"))
                    dgv_QLTK.Columns["TrangThai"].HeaderText =
                        "Trạng thái";

                if (dgv_QLTK.Columns.Contains("SoLanSaiMatKhau"))
                    dgv_QLTK.Columns["SoLanSaiMatKhau"].HeaderText =
                        "Số lần sai";

                if (dgv_QLTK.Columns.Contains("LanDangNhapCuoi"))
                    dgv_QLTK.Columns["LanDangNhapCuoi"].HeaderText =
                        "Đăng nhập cuối";

                if (dgv_QLTK.Columns.Contains("LanDangNhapCuoi"))
                {
                    dgv_QLTK.Columns["LanDangNhapCuoi"]
                        .DefaultCellStyle.Format =
                        "dd/MM/yyyy HH:mm";
                }

                if (dgv_QLTK.Columns.Contains("MaTK"))
                {
                    dgv_QLTK.Columns["MaTK"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgv_QLTK.Columns.Contains("SoLanSaiMatKhau"))
                {
                    dgv_QLTK.Columns["SoLanSaiMatKhau"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách tài khoản!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CHỌN TÀI KHOẢN
        // =========================================================

        private void dgv_QLTK_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            dgv_QLTK.Rows[e.RowIndex].Selected = true;
        }

        // =========================================================
        // LẤY MÃ TÀI KHOẢN
        // =========================================================

        private int? GetMaTKDangChon()
        {
            if (dgv_QLTK.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một tài khoản!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return null;
            }

            DataGridViewRow row =
                dgv_QLTK.SelectedRows[0];

            if (row.Cells["MaTK"].Value == null)
                return null;

            return Convert.ToInt32(
                row.Cells["MaTK"].Value);
        }

        // =========================================================
        // PHÂN QUYỀN
        // =========================================================

        private void btn_phanquyen_Click(
            object sender,
            EventArgs e)
        {
            int? maTK = GetMaTKDangChon();

            if (maTK == null)
                return;

            // Không cho tự phân quyền chính mình
            if (maTK.Value == Session.MaTK)
            {
                MessageBox.Show(
                    "Bạn không thể thay đổi quyền của chính tài khoản đang đăng nhập!",
                    "Không được phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string sql = @"
                    SELECT MaVaiTro
                    FROM TaiKhoan
                    WHERE MaTK = @MaTK";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaTK", maTK.Value)
                };

                object result =
                    kt.ExecuteScalar(sql, parameters);

                if (result == null ||
                    result == DBNull.Value)
                {
                    MessageBox.Show(
                        "Không tìm thấy tài khoản!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                int maVaiTro =
                    Convert.ToInt32(result);

                // Không cho bất kỳ ai sửa Admin
                if (maVaiTro == PhanQuyen.ADMIN)
                {
                    MessageBox.Show(
                        "Không thể thay đổi quyền của tài khoản Admin!",
                        "Không được phép",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (FormPhanQuyen form =
                new FormPhanQuyen(maTK.Value))
                {
                    DialogResult resultForm =
                        form.ShowDialog();

                    if (resultForm == DialogResult.OK)
                    {
                        LoadDanhSachTaiKhoan();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở chức năng phân quyền!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // MỞ KHÓA
        // =========================================================

        private void btn_Mo_Click(
            object sender,
            EventArgs e)
        {
            int? maTK = GetMaTKDangChon();

            if (maTK == null)
                return;

            try
            {
                string sqlCheck = @"
                    SELECT
                        TenDangNhap,
                        MaVaiTro,
                        TrangThai
                    FROM TaiKhoan
                    WHERE MaTK = @MaTK";

                SqlParameter[] pCheck =
                {
                    new SqlParameter("@MaTK", maTK.Value)
                };

                DataTable dt =
                    kt.GetData(sqlCheck, pCheck);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy tài khoản!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DataRow row = dt.Rows[0];

                string tenDangNhap =
                    row["TenDangNhap"].ToString();

                int maVaiTro =
                    Convert.ToInt32(row["MaVaiTro"]);

                bool trangThai =
                    Convert.ToBoolean(row["TrangThai"]);

                if (maVaiTro == PhanQuyen.ADMIN ||
                    maVaiTro == PhanQuyen.QUAN_LY)
                {
                    MessageBox.Show(
                        "Admin / Quản lý không thuộc diện bị khóa tự động.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                if (trangThai)
                {
                    MessageBox.Show(
                        "Tài khoản \"" + tenDangNhap +
                        "\" hiện đang hoạt động.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn mở khóa tài khoản:\n\n" +
                    tenDangNhap + "?",
                    "Xác nhận mở khóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                string sqlMo = @"
                    UPDATE TaiKhoan
                    SET
                        TrangThai = 1,
                        SoLanSaiMatKhau = 0
                    WHERE MaTK = @MaTK";

                SqlParameter[] pMo =
                {
                    new SqlParameter("@MaTK", maTK.Value)
                };

                kt.Execute(sqlMo, pMo);

                MessageBox.Show(
                    "Đã mở khóa tài khoản:\n" +
                    tenDangNhap,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDanhSachTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở khóa tài khoản!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // KHÓA
        // =========================================================

        private void Btn_Khoa_Click(
            object sender,
            EventArgs e)
        {
            int? maTK = GetMaTKDangChon();

            if (maTK == null)
                return;

            try
            {
                string sqlCheck = @"
                    SELECT
                        TenDangNhap,
                        MaVaiTro,
                        TrangThai
                    FROM TaiKhoan
                    WHERE MaTK = @MaTK";

                SqlParameter[] pCheck =
                {
                    new SqlParameter("@MaTK", maTK.Value)
                };

                DataTable dt =
                    kt.GetData(sqlCheck, pCheck);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy tài khoản!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DataRow row = dt.Rows[0];

                string tenDangNhap =
                    row["TenDangNhap"].ToString();

                int maVaiTro =
                    Convert.ToInt32(row["MaVaiTro"]);

                bool trangThai =
                    Convert.ToBoolean(row["TrangThai"]);

                if (maVaiTro == PhanQuyen.ADMIN ||
                    maVaiTro == PhanQuyen.QUAN_LY)
                {
                    MessageBox.Show(
                        "Không thể khóa tài khoản Admin hoặc Quản lý!",
                        "Không được phép",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!trangThai)
                {
                    MessageBox.Show(
                        "Tài khoản \"" + tenDangNhap +
                        "\" đã bị khóa.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn khóa tài khoản:\n\n" +
                    tenDangNhap + "?\n\n" +
                    "Tài khoản sẽ không thể đăng nhập cho đến khi được mở khóa.",
                    "Xác nhận khóa tài khoản",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                string sqlKhoa = @"
                    UPDATE TaiKhoan
                    SET TrangThai = 0
                    WHERE MaTK = @MaTK";

                SqlParameter[] pKhoa =
                {
                    new SqlParameter("@MaTK", maTK.Value)
                };

                kt.Execute(sqlKhoa, pKhoa);

                MessageBox.Show(
                    "Đã khóa tài khoản:\n" +
                    tenDangNhap,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDanhSachTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể khóa tài khoản!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // THOÁT
        // =========================================================

        private void btn_thoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

    }
}
