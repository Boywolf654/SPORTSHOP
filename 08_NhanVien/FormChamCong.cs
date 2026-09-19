using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class D : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();
        private bool cheDoNhanVien = false;
        public D() : this(false)
        {
        }

        public D(bool cheDoNhanVien)
        {
            InitializeComponent();

            this.cheDoNhanVien = cheDoNhanVien;

            btn_tim.Click += btn_tim_Click;
            btn_vao.Click += btn_vao_Click;
            btn_Ra.Click += btn_Ra_Click;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================
        private void D_Load(object sender, EventArgs e)
        {
            // Hiển thị cả ngày + giờ
            dtp_GioVao.Format = DateTimePickerFormat.Custom;
            dtp_GioVao.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtp_GioVao.ShowUpDown = true;

            Dtp_GioRa.Format = DateTimePickerFormat.Custom;
            Dtp_GioRa.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            Dtp_GioRa.ShowUpDown = true;

            dtp_GioVao.Value = DateTime.Now;
            Dtp_GioRa.Value = DateTime.Now;

            // Chỉ nhân viên bán hàng và nhân viên kho mới bắt buộc chấm công.
            if (cheDoNhanVien &&
                Session.MaVaiTro != PhanQuyen.NV_BAN_HANG &&
                Session.MaVaiTro != PhanQuyen.NV_KHO)
            {
                MessageBox.Show(
                    "Tài khoản hiện tại không thuộc nhóm nhân viên phải chấm công.",
                    "Không được chấm công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if (cheDoNhanVien)
            {
                // Tự điền mã NV nhưng vẫn bắt buộc bấm TÌM
                txt_NhapMaNV.Text = Session.MaNV.ToString();

                txt_NhapMaNV.ReadOnly = true;

                // Giữ nút TÌM
                btn_tim.Visible = true;

                // Chưa hiển thị thông tin nhân viên
                txt_MaNV.Clear();
                txt_TenNV.Clear();
            }
            // Hai ô này chỉ hiển thị thông tin
            txt_TenNV.ReadOnly = true;
            txt_MaNV.ReadOnly = true;
            btn_vao.Enabled = false;
            btn_Ra.Enabled = false;
        }
        private void TimNhanVienTheoMa(int maNV)
        {
            try
            {
                string sql = @"
            SELECT MaNV, HoTen
            FROM NhanVien
            WHERE MaNV = @MaNV";

                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNV;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_MaNV.Text = reader["MaNV"].ToString();
                                txt_TenNV.Text = reader["HoTen"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lấy thông tin nhân viên:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        // =========================================================
        // TÌM NHÂN VIÊN
        // =========================================================
        private void btn_tim_Click(object sender, EventArgs e)
        {
            string maNVText = txt_NhapMaNV.Text.Trim();

            // ==========================
            // KIỂM TRA BỎ TRỐNG
            // ==========================
            if (string.IsNullOrWhiteSpace(maNVText))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_MaNV.Clear();
                txt_TenNV.Clear();

                btn_vao.Enabled = false;
                btn_Ra.Enabled = false;

                txt_NhapMaNV.Focus();
                return;
            }

            // ==========================
            // KIỂM TRA MÃ NV
            // ==========================
            int maNV;

            if (!int.TryParse(maNVText, out maNV))
            {
                MessageBox.Show(
                    "Mã nhân viên phải là số.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_MaNV.Clear();
                txt_TenNV.Clear();

                btn_vao.Enabled = false;
                btn_Ra.Enabled = false;

                txt_NhapMaNV.Focus();
                return;
            }

            try
            {
                string sql = @"
            SELECT MaNV, HoTen
            FROM NhanVien
            WHERE MaNV = @MaNV";

                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNV;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ==========================
                                // TÌM THẤY NHÂN VIÊN
                                // ==========================
                                txt_MaNV.Text =
                                    reader["MaNV"].ToString();

                                txt_TenNV.Text =
                                    reader["HoTen"].ToString();

                                btn_vao.Enabled = true;
                                btn_Ra.Enabled = true;

                                MessageBox.Show(
                                    "Đã tìm thấy nhân viên.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                // ==========================
                                // KHÔNG TÌM THẤY
                                // ==========================
                                txt_MaNV.Clear();
                                txt_TenNV.Clear();

                                btn_vao.Enabled = false;
                                btn_Ra.Enabled = false;

                                MessageBox.Show(
                                    "Không tìm thấy nhân viên.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm nhân viên:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // VÀO CA
        // =========================================================
        private void btn_vao_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhanVien())
                return;

            int maNV = Convert.ToInt32(txt_MaNV.Text);

            DateTime gioVao = DateTime.Now;
            DateTime ngayLam = gioVao.Date;

            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra nhân viên đã vào ca hôm nay chưa
                    string sqlCheck = @"
                        SELECT MaChamCong, GioVao, GioRa
                        FROM ChamCong
                        WHERE MaNV = @MaNV
                          AND NgayLam = @NgayLam";

                    using (SqlCommand cmdCheck =
                        new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.Add(
                            "@MaNV",
                            SqlDbType.Int).Value = maNV;

                        cmdCheck.Parameters.Add(
                            "@NgayLam",
                            SqlDbType.Date).Value = ngayLam;

                        using (SqlDataReader reader =
                            cmdCheck.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool daVao =
                                    reader["GioVao"] != DBNull.Value;

                                bool daRa =
                                    reader["GioRa"] != DBNull.Value;

                                reader.Close();

                                if (daVao && !daRa)
                                {
                                    MessageBox.Show(
                                        "Nhân viên này đã vào ca hôm nay.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                                    return;
                                }

                                if (daVao && daRa)
                                {
                                    MessageBox.Show(
                                        "Nhân viên này đã hoàn thành ca hôm nay.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                                    return;
                                }
                            }
                            else
                            {
                                reader.Close();

                                string sqlInsert = @"
                                    INSERT INTO ChamCong
                                    (
                                        MaNV,
                                        NgayLam,
                                        GioVao,
                                        GioRa,
                                        TrangThai
                                    )
                                    VALUES
                                    (
                                        @MaNV,
                                        @NgayLam,
                                        @GioVao,
                                        NULL,
                                        N'Có mặt'
                                    )";

                                using (SqlCommand cmdInsert =
                                    new SqlCommand(sqlInsert, conn))
                                {
                                    cmdInsert.Parameters.Add(
                                        "@MaNV",
                                        SqlDbType.Int).Value = maNV;

                                    cmdInsert.Parameters.Add(
                                        "@NgayLam",
                                        SqlDbType.Date).Value = ngayLam;

                                    cmdInsert.Parameters.Add(
                                        "@GioVao",
                                        SqlDbType.DateTime).Value = gioVao;

                                    cmdInsert.ExecuteNonQuery();
                                    if (cheDoNhanVien)
                                    {
                                        MessageBox.Show(
                                            "Đã ghi nhận vào ca.\n\n" +
                                            "Nhân viên: " + txt_TenNV.Text + "\n" +
                                            "Thời gian: " + gioVao.ToString("HH:mm:ss"),
                                            "Chấm công",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }

                                dtp_GioVao.Value = gioVao;

                                MessageBox.Show(
                                    "Đã ghi nhận vào ca lúc "
                                    + gioVao.ToString("HH:mm:ss")
                                    + ".",
                                    "Chấm công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi chấm công vào ca:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // RA CA
        // =========================================================
        private void btn_Ra_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhanVien())
                return;

            int maNV = Convert.ToInt32(txt_MaNV.Text);

            DateTime gioRa = DateTime.Now;
            DateTime ngayLam = gioRa.Date;

            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    int maChamCong = 0;
                    DateTime gioVao;

                    string sqlCheck = @"
                        SELECT MaChamCong, GioVao, GioRa
                        FROM ChamCong
                        WHERE MaNV = @MaNV
                          AND NgayLam = @NgayLam";

                    using (SqlCommand cmdCheck =
                        new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.Add(
                            "@MaNV",
                            SqlDbType.Int).Value = maNV;

                        cmdCheck.Parameters.Add(
                            "@NgayLam",
                            SqlDbType.Date).Value = ngayLam;

                        using (SqlDataReader reader =
                            cmdCheck.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Nhân viên chưa vào ca hôm nay.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }

                            maChamCong =
                                Convert.ToInt32(
                                    reader["MaChamCong"]);

                            if (reader["GioVao"] == DBNull.Value)
                            {
                                MessageBox.Show(
                                    "Nhân viên chưa có giờ vào ca.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return;
                            }

                            gioVao =
                                Convert.ToDateTime(
                                    reader["GioVao"]);

                            if (reader["GioRa"] != DBNull.Value)
                            {
                                MessageBox.Show(
                                    "Nhân viên này đã ra ca hôm nay.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                return;
                            }
                        }
                    }

                    if (gioRa <= gioVao)
                    {
                        MessageBox.Show(
                            "Giờ ra phải lớn hơn giờ vào.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    string sqlUpdate = @"
                        UPDATE ChamCong
                        SET GioRa = @GioRa
                        WHERE MaChamCong = @MaChamCong";

                    using (SqlCommand cmdUpdate =
                        new SqlCommand(sqlUpdate, conn))
                    {
                        cmdUpdate.Parameters.Add(
                            "@GioRa",
                            SqlDbType.DateTime).Value = gioRa;

                        cmdUpdate.Parameters.Add(
                            "@MaChamCong",
                            SqlDbType.Int).Value = maChamCong;

                        cmdUpdate.ExecuteNonQuery();
                    }

                    Dtp_GioRa.Value = gioRa;

                    TimeSpan thoiGianLam = gioRa - gioVao;

                    MessageBox.Show(
                        "Đã ghi nhận ra ca lúc "
                        + gioRa.ToString("HH:mm:ss")
                        + "\n\nThời gian làm: "
                        + (int)thoiGianLam.TotalHours
                        + " giờ "
                        + thoiGianLam.Minutes
                        + " phút.",
                        "Chấm công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi chấm công ra ca:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // KIỂM TRA NHÂN VIÊN
        // =========================================================
        private bool KiemTraNhanVien()
        {
            if (string.IsNullOrWhiteSpace(txt_MaNV.Text))
            {
                MessageBox.Show(
                    "Vui lòng tìm nhân viên trước.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_NhapMaNV.Focus();
                return false;
            }

            int maNV;

            if (!int.TryParse(txt_MaNV.Text, out maNV))
            {
                MessageBox.Show(
                    "Mã nhân viên không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
    }
}