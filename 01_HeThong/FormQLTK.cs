using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormQLTK : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        public FormQLTK()
        {
            InitializeComponent();

            // ==========================
            // EVENT
            // ==========================

            btn_Mo.Click += btn_Mo_Click;
            Btn_Khoa.Click += Btn_Khoa_Click;
            btn_thoat.Click += btn_thoat_Click;

            dgv_QLTK.CellClick += dgv_QLTK_CellClick;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void FormQLTK_Load(object sender, EventArgs e)
        {
            // Chỉ Admin / Quản lý được vào quản lý tài khoản
            if (Session.MaVaiTro != PhanQuyen.ADMIN &&
                Session.MaVaiTro != PhanQuyen.QUAN_LY)
            {
                MessageBox.Show(
                    "Bạn không có quyền quản lý tài khoản!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                this.Close();
                return;
            }

            CauHinhDgv();
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
                    ORDER BY tk.MaTK";

                DataTable dt = kt.GetData(sql);

                dgv_QLTK.DataSource = dt;

                // ==========================
                // ĐỔI TÊN CỘT HIỂN THỊ
                // ==========================

                if (dgv_QLTK.Columns.Contains("MaTK"))
                    dgv_QLTK.Columns["MaTK"].HeaderText = "Mã TK";

                if (dgv_QLTK.Columns.Contains("TenDangNhap"))
                    dgv_QLTK.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";

                if (dgv_QLTK.Columns.Contains("TenVaiTro"))
                    dgv_QLTK.Columns["TenVaiTro"].HeaderText = "Vai trò";

                if (dgv_QLTK.Columns.Contains("TrangThai"))
                    dgv_QLTK.Columns["TrangThai"].HeaderText = "Trạng thái";

                if (dgv_QLTK.Columns.Contains("SoLanSaiMatKhau"))
                    dgv_QLTK.Columns["SoLanSaiMatKhau"].HeaderText = "Số lần sai";

                if (dgv_QLTK.Columns.Contains("LanDangNhapCuoi"))
                    dgv_QLTK.Columns["LanDangNhapCuoi"].HeaderText =
                        "Đăng nhập cuối";

                // Định dạng ngày giờ
                if (dgv_QLTK.Columns.Contains("LanDangNhapCuoi"))
                {
                    dgv_QLTK.Columns["LanDangNhapCuoi"]
                        .DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                // Căn giữa một số cột
                if (dgv_QLTK.Columns.Contains("MaTK"))
                    dgv_QLTK.Columns["MaTK"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                if (dgv_QLTK.Columns.Contains("SoLanSaiMatKhau"))
                    dgv_QLTK.Columns["SoLanSaiMatKhau"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách tài khoản!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
        // LẤY MÃ TÀI KHOẢN ĐANG CHỌN
        // =========================================================

        private int? GetMaTKDangChon()
        {
            if (dgv_QLTK.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn một tài khoản!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            DataGridViewRow row =
                dgv_QLTK.SelectedRows[0];

            if (row.Cells["MaTK"].Value == null)
                return null;

            return Convert.ToInt32(
                row.Cells["MaTK"].Value
            );
        }

        // =========================================================
        // MỞ KHÓA TÀI KHOẢN
        // =========================================================

        private void btn_Mo_Click(object sender, EventArgs e)
        {
            int? maTK = GetMaTKDangChon();

            if (maTK == null)
                return;

            try
            {
                // Lấy thông tin tài khoản
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
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                DataRow row = dt.Rows[0];

                string tenDangNhap =
                    row["TenDangNhap"].ToString();

                int maVaiTro =
                    Convert.ToInt32(row["MaVaiTro"]);

                bool trangThai =
                    Convert.ToBoolean(row["TrangThai"]);

                // Admin / Quản lý không cần mở khóa
                if (maVaiTro == PhanQuyen.ADMIN ||
                    maVaiTro == PhanQuyen.QUAN_LY)
                {
                    MessageBox.Show(
                        "Admin / Quản lý không thuộc diện bị khóa tự động.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                if (trangThai)
                {
                    MessageBox.Show(
                        "Tài khoản \"" + tenDangNhap +
                        "\" hiện đang hoạt động.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn mở khóa tài khoản:\n\n" +
                    tenDangNhap + "?",
                    "Xác nhận mở khóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

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
                    MessageBoxIcon.Information
                );

                LoadDanhSachTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở khóa tài khoản!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // KHÓA TÀI KHOẢN THỦ CÔNG
        // =========================================================

        private void Btn_Khoa_Click(object sender, EventArgs e)
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
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                DataRow row = dt.Rows[0];

                string tenDangNhap =
                    row["TenDangNhap"].ToString();

                int maVaiTro =
                    Convert.ToInt32(row["MaVaiTro"]);

                bool trangThai =
                    Convert.ToBoolean(row["TrangThai"]);

                // ==========================
                // KHÔNG CHO KHÓA ADMIN / QL
                // ==========================

                if (maVaiTro == PhanQuyen.ADMIN ||
                    maVaiTro == PhanQuyen.QUAN_LY)
                {
                    MessageBox.Show(
                        "Không thể khóa tài khoản Admin hoặc Quản lý!",
                        "Không được phép",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (!trangThai)
                {
                    MessageBox.Show(
                        "Tài khoản \"" + tenDangNhap +
                        "\" đã bị khóa.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn khóa tài khoản:\n\n" +
                    tenDangNhap + "?\n\n" +
                    "Tài khoản sẽ không thể đăng nhập cho đến khi được mở khóa.",
                    "Xác nhận khóa tài khoản",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

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
                    MessageBoxIcon.Information
                );

                LoadDanhSachTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể khóa tài khoản!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // THOÁT
        // =========================================================

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}