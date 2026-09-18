using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class Formdangnhap : Form
    {
        KetNoiDuLieu kt = new KetNoiDuLieu();

        public Formdangnhap()
        {
            InitializeComponent();

            // Ẩn mật khẩu mặc định
            txt_pass.PasswordChar = '*';

            // Thứ tự Tab
            txt_username.TabIndex = 0;
            txt_pass.TabIndex = 1;
            pass_check.TabIndex = 2;

            // Tự động focus vào ô tên đăng nhập
            this.Shown += Formdangnhap_Shown;

            // Checkbox hiện mật khẩu
            pass_check.CheckedChanged += pass_check_CheckedChanged;
        }

        private void Formdangnhap_Shown(object sender, EventArgs e)
        {
            txt_username.Focus();
            txt_username.SelectAll();
        }

        private void pass_check_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (pass_check.Checked)
            {
                // Hiện mật khẩu
                txt_pass.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mật khẩu
                txt_pass.PasswordChar = '*';
            }
        }

        private void Formdangnhap_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Gold, 2))
            {
                e.Graphics.DrawRectangle(
                    pen,
                    0,
                    0,
                    panel1.Width - 1,
                    panel1.Height - 1
                );
            }
        }

        public class RoundedTextBox : TextBox
        {
            public int BorderRadius { get; set; } = 12;
            public Color BorderColor { get; set; } = Color.Gold;

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
            }
        }

        // =========================================================
        // ĐĂNG NHẬP
        // =========================================================
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            // ==========================
            // LẤY DỮ LIỆU
            // ==========================

            string username = txt_username.Text.Trim();
            string password = txt_pass.Text;

            // ==========================
            // KIỂM TRA BỎ TRỐNG
            // ==========================

            if (username == "" || password == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                // ==========================
                // LẤY TÀI KHOẢN THEO USERNAME
                // ==========================

                string sql = @"
                    SELECT 
                        tk.MaTK,
                        tk.TenDangNhap,
                        tk.MatKhau,
                        tk.MaVaiTro,
                        tk.TrangThai,
                        tk.SoLanSaiMatKhau,
                        vt.TenVaiTro
                    FROM TaiKhoan tk
                    INNER JOIN VaiTro vt
                        ON tk.MaVaiTro = vt.MaVaiTro
                    WHERE tk.TenDangNhap = @username";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@username", username)
                };

                DataTable dt = kt.GetData(sql, parameters);

                // ==========================
                // KHÔNG TỒN TẠI TÀI KHOẢN
                // ==========================

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Tài khoản hoặc mật khẩu không chính xác!",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txt_pass.Clear();
                    txt_pass.Focus();

                    return;
                }

                DataRow row = dt.Rows[0];

                int maTK = Convert.ToInt32(row["MaTK"]);
                string tenDangNhap = row["TenDangNhap"].ToString();
                string matKhauDB = row["MatKhau"].ToString();
                int maVaiTro = Convert.ToInt32(row["MaVaiTro"]);
                bool trangThai = Convert.ToBoolean(row["TrangThai"]);
                int soLanSai = Convert.ToInt32(row["SoLanSaiMatKhau"]);
                string tenVaiTro = row["TenVaiTro"].ToString();

                // ==========================
                // KIỂM TRA TÀI KHOẢN ĐÃ KHÓA
                // ==========================

                if (!trangThai)
                {
                    MessageBox.Show(
                        "Tài khoản này đã bị khóa!\n\n" +
                        "Vui lòng liên hệ Admin hoặc Quản lý để được mở khóa.",
                        "Tài khoản bị khóa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txt_pass.Clear();
                    txt_pass.Focus();

                    return;
                }

                // ==========================
                // KIỂM TRA MẬT KHẨU
                // ==========================

                if (matKhauDB != password)
                {
                    soLanSai++;

                    // ==========================
                    // ADMIN / QUẢN LÝ
                    // KHÔNG BỊ KHÓA
                    // ==========================

                    if (maVaiTro == PhanQuyen.ADMIN ||
                        maVaiTro == PhanQuyen.QUAN_LY)
                    {
                        string sqlTangSai = @"
                            UPDATE TaiKhoan
                            SET SoLanSaiMatKhau = @SoLanSai
                            WHERE MaTK = @MaTK";

                        SqlParameter[] pTangSai =
                        {
                            new SqlParameter("@SoLanSai", soLanSai),
                            new SqlParameter("@MaTK", maTK)
                        };

                        kt.Execute(sqlTangSai, pTangSai);

                        MessageBox.Show(
                            "Tài khoản hoặc mật khẩu không chính xác!\n\n" +
                            "Admin / Quản lý không bị khóa tài khoản.",
                            "Đăng nhập thất bại",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }

                    // ==========================
                    // NHÂN VIÊN / KHÁCH HÀNG
                    // ==========================

                    else
                    {
                        if (soLanSai >= 3)
                        {
                            // ĐỦ 3 LẦN → KHÓA
                            string sqlKhoa = @"
                                UPDATE TaiKhoan
                                SET 
                                    SoLanSaiMatKhau = @SoLanSai,
                                    TrangThai = 0
                                WHERE MaTK = @MaTK";

                            SqlParameter[] pKhoa =
                            {
                                new SqlParameter("@SoLanSai", soLanSai),
                                new SqlParameter("@MaTK", maTK)
                            };

                            kt.Execute(sqlKhoa, pKhoa);

                            MessageBox.Show(
                                "Bạn đã nhập sai mật khẩu 3 lần!\n\n" +
                                "Tài khoản đã bị khóa.\n" +
                                "Vui lòng liên hệ Admin hoặc Quản lý để mở khóa.",
                                "Tài khoản bị khóa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                        else
                        {
                            int conLai = 3 - soLanSai;

                            string sqlTangSai = @"
                                UPDATE TaiKhoan
                                SET SoLanSaiMatKhau = @SoLanSai
                                WHERE MaTK = @MaTK";

                            SqlParameter[] pTangSai =
                            {
                                new SqlParameter("@SoLanSai", soLanSai),
                                new SqlParameter("@MaTK", maTK)
                            };

                            kt.Execute(sqlTangSai, pTangSai);

                            MessageBox.Show(
                                "Tài khoản hoặc mật khẩu không chính xác!\n\n" +
                                "Bạn còn " + conLai + " lần thử.",
                                "Đăng nhập thất bại",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }

                    txt_pass.Clear();
                    txt_pass.Focus();

                    return;
                }

                // =========================================================
                // ĐĂNG NHẬP ĐÚNG
                // RESET SỐ LẦN SAI
                // =========================================================

                string sqlDangNhapDung = @"
                    UPDATE TaiKhoan
                    SET 
                        SoLanSaiMatKhau = 0,
                        LanDangNhapCuoi = GETDATE()
                    WHERE MaTK = @MaTK";

                SqlParameter[] pDangNhapDung =
                {
                    new SqlParameter("@MaTK", maTK)
                };

                kt.Execute(sqlDangNhapDung, pDangNhapDung);

                // =========================================================
                // TẠO ĐỐI TƯỢNG TÀI KHOẢN
                // =========================================================

                TaiKhoan tk = new TaiKhoan();

                tk.MaTK = maTK;
                tk.TenDangNhap = tenDangNhap;
                tk.MatKhau = matKhauDB;
                tk.MaVaiTro = maVaiTro;
                tk.TrangThai = trangThai;

                // =========================================================
                // LƯU SESSION
                // =========================================================

                Session.MaTK = tk.MaTK;
                Session.TenDangNhap = tk.TenDangNhap;
                Session.MaVaiTro = tk.MaVaiTro;
                Session.TenVaiTro = tenVaiTro;

                // =========================================================
                // CHỈ NHÂN VIÊN MỚI CÓ MaNV
                // =========================================================

                if (Session.MaVaiTro == PhanQuyen.NV_BAN_HANG ||
                    Session.MaVaiTro == PhanQuyen.NV_KHO)
                {
                    // -----------------------------------------------------
                    // 1. Kiểm tra tài khoản đã có MaNV chưa
                    // -----------------------------------------------------

                    string sqlMaNV = @"
                        SELECT MaNV
                        FROM NhanVien
                        WHERE MaTK = @MaTK";

                    SqlParameter[] pMaNV =
                    {
                        new SqlParameter("@MaTK", Session.MaTK)
                    };

                    object resultMaNV =
                        kt.ExecuteScalar(sqlMaNV, pMaNV);

                    int maNV;

                    // -----------------------------------------------------
                    // 2. Chưa có MaNV → TỰ ĐỘNG TẠO
                    // -----------------------------------------------------

                    if (resultMaNV == null ||
                        resultMaNV == DBNull.Value)
                    {
                        string sqlTaoNhanVien = @"
                            INSERT INTO NhanVien
                            (
                                HoTen,
                                ChucVu,
                                TrangThai,
                                MaTK
                            )
                            VALUES
                            (
                                @HoTen,
                                @ChucVu,
                                1,
                                @MaTK
                            );

                            SELECT SCOPE_IDENTITY();";

                        SqlParameter[] pTaoNV =
                        {
                            new SqlParameter(
                                "@HoTen",
                                Session.TenDangNhap),

                            new SqlParameter(
                                "@ChucVu",
                                tenVaiTro),

                            new SqlParameter(
                                "@MaTK",
                                Session.MaTK)
                        };

                        object resultTaoNV =
                            kt.ExecuteScalar(
                                sqlTaoNhanVien,
                                pTaoNV);

                        if (resultTaoNV == null ||
                            resultTaoNV == DBNull.Value)
                        {
                            throw new Exception(
                                "Không thể tạo mã nhân viên cho tài khoản.");
                        }

                        maNV =
                            Convert.ToInt32(resultTaoNV);
                    }
                    else
                    {
                        // -------------------------------------------------
                        // 3. Đã có MaNV → DÙNG MaNV CŨ
                        // -------------------------------------------------

                        maNV =
                            Convert.ToInt32(resultMaNV);
                    }

                    // -----------------------------------------------------
                    // 4. Lưu MaNV vào Session
                    // -----------------------------------------------------

                    Session.MaNV = maNV;

                    
                }
                else
                {
                    // =====================================================
                    // ADMIN / QUẢN LÝ / KHÁCH HÀNG
                    // KHÔNG CÓ MaNV
                    // =====================================================

                    Session.MaNV = 0;
                }

                // =========================================================
                // GHI LỊCH SỬ ĐĂNG NHẬP CHO ADMIN / QUẢN LÝ
                // =========================================================

                if (Session.MaVaiTro == PhanQuyen.ADMIN ||
                    Session.MaVaiTro == PhanQuyen.QUAN_LY)
                {
                    string sqlLichSu = @"
                        INSERT INTO LichSuDangNhap
                        (
                            MaTK,
                            ThoiGianVao,
                            ThoiGianRa,
                            KetQua,
                            LyDo
                        )
                        VALUES
                        (
                            @MaTK,
                            GETDATE(),
                            NULL,
                            N'Thành công',
                            NULL
                        )";

                    SqlParameter[] pLichSu =
                    {
                        new SqlParameter(
                            "@MaTK",
                            Session.MaTK)
                    };

                    kt.Execute(
                        sqlLichSu,
                        pLichSu);
                }

                // =========================================================
                // THÔNG BÁO
                // =========================================================

                MessageBox.Show(
                    "Đăng nhập thành công!\n\n" +
                    "Tài khoản: " + Session.TenDangNhap + "\n" +
                    "Vai trò: " + Session.TenVaiTro,
                    "Đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // =========================================================
                // ĐIỀU HƯỚNG THEO VAI TRÒ
                // =========================================================

                Form frm = null;

                switch (Session.MaVaiTro)
                {
                    // =====================================================
                    // ADMIN
                    // =====================================================
                    case PhanQuyen.ADMIN:

                        frm = new FormAdmin(tk);
                        break;


                    // =====================================================
                    // QUẢN LÝ
                    // =====================================================
                    case PhanQuyen.QUAN_LY:

                        frm = new FormAdmin(tk);
                        break;


                    // =====================================================
                    // NHÂN VIÊN KHO
                    // =====================================================
                    case PhanQuyen.NV_KHO:

                        frm = new FromKho();
                        break;


                    // =====================================================
                    // NHÂN VIÊN BÁN HÀNG
                    // =====================================================
                    case PhanQuyen.NV_BAN_HANG:

                        frm = new form_hóa_đơn_bán_hàng();
                        break;


                    // =====================================================
                    // KHÁCH HÀNG
                    // =====================================================
                    case PhanQuyen.KHACH_HANG:

                        frm = new formgiaodienbanhang();
                        break;


                    // =====================================================
                    // KHÔNG CÓ QUYỀN
                    // =====================================================
                    default:

                        MessageBox.Show(
                            "Tài khoản chưa được phân quyền!",
                            "Lỗi phân quyền",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        Session.DangXuat();
                        return;
                }

                // =========================================================
                // MỞ FORM
                // =========================================================

                if (frm != null)
                {
                    frm.FormClosed += (s, args) =>
                    {
                        Application.Exit();
                    };

                    frm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra khi đăng nhập!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // QUÊN MẬT KHẨU
        // =========================================================

        private void linkLabel1_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            formquenmatkhau frm =
                new formquenmatkhau();

            frm.ShowDialog();
        }

        // =========================================================
        // ĐĂNG KÝ
        // =========================================================

        private void linkLabel2_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            FormDangKy frm =
                new FormDangKy();

            frm.ShowDialog();
        }
    }
}