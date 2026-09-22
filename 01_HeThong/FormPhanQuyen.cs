using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormPhanQuyen : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maTK;

        private int vaiTroHienTai;

        public FormPhanQuyen()
        {
            InitializeComponent();

            btn_huy.Click += btn_huy_Click;
            btn_capnhap.Click += btn_capnhap_Click;
        }

        public FormPhanQuyen(int maTK) : this()
        {
            this.maTK = maTK;
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void FormPhanQuyen_Load(
            object sender,
            EventArgs e)
        {
            if (Session.MaVaiTro != PhanQuyen.ADMIN &&
                Session.MaVaiTro != PhanQuyen.QUAN_LY)
            {
                MessageBox.Show(
                    "Bạn không có quyền phân quyền tài khoản!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            txt_vaitrohientai.ReadOnly = true;

            LoadThongTinTaiKhoan();

            if (vaiTroHienTai == PhanQuyen.ADMIN)
            {
                MessageBox.Show(
                    "Không thể thay đổi quyền của tài khoản Admin!",
                    "Không được phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btn_capnhap.Enabled = false;
                cmb_vaitromoi.Enabled = false;

                return;
            }

            LoadVaiTroDuocPhep();
        }

        // =========================================================
        // LOAD THÔNG TIN TÀI KHOẢN
        // =========================================================

        private void LoadThongTinTaiKhoan()
        {
            try
            {
                string sql = @"
                    SELECT
                        tk.TenDangNhap,
                        tk.MaVaiTro,
                        vt.TenVaiTro
                    FROM TaiKhoan tk
                    INNER JOIN VaiTro vt
                        ON tk.MaVaiTro = vt.MaVaiTro
                    WHERE tk.MaTK = @MaTK";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaTK", maTK)
                };

                DataTable dt =
                    kt.GetData(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy tài khoản!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Close();
                    return;
                }

                DataRow row = dt.Rows[0];

                lb_TaiKhoan.Text =
                    row["TenDangNhap"].ToString();

                vaiTroHienTai =
                    Convert.ToInt32(row["MaVaiTro"]);

                txt_vaitrohientai.Text =
                    row["TenVaiTro"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin tài khoản!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        // =========================================================
        // LOAD VAI TRÒ ĐƯỢC PHÉP
        // =========================================================

        private void LoadVaiTroDuocPhep()
        {
            try
            {
                string sql = @"
                    SELECT
                        MaVaiTro,
                        TenVaiTro
                    FROM VaiTro
                    WHERE MaVaiTro IN
                    (
                        @QuanLy,
                        @NvBanHang,
                        @NvKho,
                        @KhachHang
                    )
                    ORDER BY MaVaiTro";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@QuanLy",
                        PhanQuyen.QUAN_LY),

                    new SqlParameter(
                        "@NvBanHang",
                        PhanQuyen.NV_BAN_HANG),

                    new SqlParameter(
                        "@NvKho",
                        PhanQuyen.NV_KHO),

                    new SqlParameter(
                        "@KhachHang",
                        PhanQuyen.KHACH_HANG)
                };

                DataTable dt =
                    kt.GetData(sql, parameters);

                cmb_vaitromoi.DataSource = dt;
                cmb_vaitromoi.DisplayMember = "TenVaiTro";
                cmb_vaitromoi.ValueMember = "MaVaiTro";

                // Chọn vai trò hiện tại
                for (int i = 0;
                     i < cmb_vaitromoi.Items.Count;
                     i++)
                {
                    DataRowView item =
                        cmb_vaitromoi.Items[i] as DataRowView;

                    if (item == null)
                        continue;

                    int maVaiTro =
                        Convert.ToInt32(
                            item["MaVaiTro"]);

                    if (maVaiTro == vaiTroHienTai)
                    {
                        cmb_vaitromoi.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách vai trò!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // CẬP NHẬT QUYỀN
        // =========================================================


        // =========================================================
        // KIỂM TRA / TẠO HỒ SƠ NHÂN VIÊN
        // =========================================================

        private bool LaVaiTroNhanVien(int maVaiTro)
        {
            return maVaiTro == PhanQuyen.NV_BAN_HANG ||
                   maVaiTro == PhanQuyen.NV_KHO;
        }

        private bool DaCoHoSoNhanVien(int maTK)
        {
            string sql = @"
                SELECT COUNT(*)
                FROM NhanVien
                WHERE MaTK = @MaTK";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaTK", maTK)
            };

            object result = kt.ExecuteScalar(sql, parameters);
            return Convert.ToInt32(result) > 0;
        }

        private string LayTenDangNhap()
        {
            string sql = @"
                SELECT TenDangNhap
                FROM TaiKhoan
                WHERE MaTK = @MaTK";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaTK", maTK)
            };

            object result = kt.ExecuteScalar(sql, parameters);
            return result == null || result == DBNull.Value
                ? ""
                : result.ToString();
        }

        private bool MoFormThongTinNhanVien(int maVaiTroMoi)
        {
            string tenDangNhap = LayTenDangNhap();

            string chucVu =
                maVaiTroMoi == PhanQuyen.NV_KHO
                    ? "Nhân viên kho"
                    : "Nhân viên bán hàng";

            using (FormThongTinNV frm =
                new FormThongTinNV(maTK, tenDangNhap, chucVu))
            {
                return frm.ShowDialog(this) == DialogResult.OK;
            }
        }

        private void CapNhatChucVuNhanVienNeuCo(int maVaiTroMoi)
        {
            if (!LaVaiTroNhanVien(maVaiTroMoi))
                return;

            string chucVu =
                maVaiTroMoi == PhanQuyen.NV_KHO
                    ? "Nhân viên kho"
                    : "Nhân viên bán hàng";

            string sql = @"
                UPDATE NhanVien
                SET ChucVu = @ChucVu,
                    TrangThai = 1
                WHERE MaTK = @MaTK";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ChucVu", chucVu),
                new SqlParameter("@MaTK", maTK)
            };

            kt.Execute(sql, parameters);
        }

        private void btn_capnhap_Click(
            object sender,
            EventArgs e)
        {
            if (cmb_vaitromoi.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn vai trò mới!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int maVaiTroMoi;

            try
            {
                maVaiTroMoi =
                    Convert.ToInt32(
                        cmb_vaitromoi.SelectedValue);
            }
            catch
            {
                MessageBox.Show(
                    "Vai trò không hợp lệ!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Không thay đổi gì
            if (maVaiTroMoi == vaiTroHienTai)
            {
                MessageBox.Show(
                    "Vai trò mới giống vai trò hiện tại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // Không cho cấp Admin
            if (maVaiTroMoi == PhanQuyen.ADMIN)
            {
                MessageBox.Show(
                    "Không được cấp quyền Admin bằng chức năng này!",
                    "Không được phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Quản lý không được cấp Admin
            if (Session.MaVaiTro == PhanQuyen.QUAN_LY &&
                maVaiTroMoi == PhanQuyen.ADMIN)
            {
                MessageBox.Show(
                    "Quản lý không có quyền cấp tài khoản Admin!",
                    "Không được phép",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Tài khoản: " + lb_TaiKhoan.Text +
                "\n\nVai trò hiện tại: " +
                txt_vaitrohientai.Text +
                "\nVai trò mới: " +
                cmb_vaitromoi.Text +
                "\n\nBạn có chắc muốn cập nhật quyền?",
                "Xác nhận phân quyền",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            int maNVMoi = 0;
            bool vuaTaoHoSoNhanVien = false;

            try
            {
                // Nếu chuyển tài khoản sang Nhân viên mà chưa có hồ sơ,
                // bắt buộc nhập đầy đủ thông tin nhân viên trước.
                if (LaVaiTroNhanVien(maVaiTroMoi))
                {
                    bool daCoHoSo = DaCoHoSoNhanVien(maTK);

                    if (!daCoHoSo)
                    {
                        if (!MoFormThongTinNhanVien(maVaiTroMoi))
                            return;

                        vuaTaoHoSoNhanVien = true;
                    }
                }

                string sql = @"
                    UPDATE TaiKhoan
                    SET MaVaiTro = @MaVaiTro
                    WHERE MaTK = @MaTK";

                SqlParameter[] parameters =
                {
                    new SqlParameter(
                        "@MaVaiTro",
                        maVaiTroMoi),

                    new SqlParameter(
                        "@MaTK",
                        maTK)
                };

                kt.Execute(sql, parameters);

                // Nếu tài khoản đã có hồ sơ nhân viên thì đồng bộ chức vụ
                // theo vai trò mới.
                if (LaVaiTroNhanVien(maVaiTroMoi))
                    CapNhatChucVuNhanVienNeuCo(maVaiTroMoi);

                MessageBox.Show(
                    "Đã cập nhật quyền cho tài khoản:\n" +
                    lb_TaiKhoan.Text +
                    (vuaTaoHoSoNhanVien
                        ? "\n\nĐã tạo và liên kết hồ sơ nhân viên."
                        : ""),
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật quyền!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
          
        }

        // =========================================================
        // HỦY
        // =========================================================

        private void btn_huy_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}