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

                    // -------------------------------------------------
                    // 1. KIỂM TRA CHẤM CÔNG HÔM NAY
                    // -------------------------------------------------
                    string sqlCheck = @"
                        SELECT MaChamCong, GioVao, GioRa
                        FROM ChamCong
                        WHERE MaNV = @MaNV
                          AND NgayLam = @NgayLam";

                    bool daVao = false;
                    bool daRa = false;

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
                                daVao =
                                    reader["GioVao"] != DBNull.Value;

                                daRa =
                                    reader["GioRa"] != DBNull.Value;
                            }
                        }
                    }

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

                    // -------------------------------------------------
                    // 2. GHI CHẤM CÔNG VÀO CA
                    // -------------------------------------------------
                    string sqlInsertChamCong = @"
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
                        new SqlCommand(sqlInsertChamCong, conn))
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
                    }

                    // -------------------------------------------------
                    // 3. TẠO CA LÀM VIỆC
                    //
                    // Nếu đã có một ca "Đang làm" thì không tạo thêm.
                    // Nếu ca cũ đã kết thúc thì tạo MaCa mới.
                    // -------------------------------------------------
                    string sqlCheckCa = @"
                        SELECT TOP 1 MaCa
                        FROM CaLamViec
                        WHERE MaNV = @MaNV
                          AND TrangThai = N'Đang làm'
                        ORDER BY MaCa DESC";

                    object maCaDangLam;

                    using (SqlCommand cmdCheckCa =
                        new SqlCommand(sqlCheckCa, conn))
                    {
                        cmdCheckCa.Parameters.Add(
                            "@MaNV",
                            SqlDbType.Int).Value = maNV;

                        maCaDangLam = cmdCheckCa.ExecuteScalar();
                    }

                    if (maCaDangLam == null ||
                        maCaDangLam == DBNull.Value)
                    {
                        string sqlInsertCa = @"
                            INSERT INTO CaLamViec
                            (
                                MaNV,
                                GioBatDau,
                                GioKetThuc,
                                DoanhThu,
                                SoHoaDon,
                                TrangThai
                            )
                            VALUES
                            (
                                @MaNV,
                                @GioBatDau,
                                NULL,
                                0,
                                0,
                                N'Đang làm'
                            )";

                        using (SqlCommand cmdInsertCa =
                            new SqlCommand(sqlInsertCa, conn))
                        {
                            cmdInsertCa.Parameters.Add(
                                "@MaNV",
                                SqlDbType.Int).Value = maNV;

                            cmdInsertCa.Parameters.Add(
                                "@GioBatDau",
                                SqlDbType.DateTime).Value = gioVao;

                            cmdInsertCa.ExecuteNonQuery();
                        }
                    }

                    dtp_GioVao.Value = gioVao;

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
                        return;
                    }

                    MessageBox.Show(
                        "Đã ghi nhận vào ca lúc "
                        + gioVao.ToString("HH:mm:ss")
                        + ".",
                        "Chấm công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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

                    // -------------------------------------------------
                    // 1. LẤY CHẤM CÔNG ĐANG MỞ
                    // -------------------------------------------------
                    int maChamCong = 0;
                    DateTime gioVao;

                    string sqlCheck = @"
                        SELECT TOP 1
                            MaChamCong,
                            GioVao,
                            GioRa
                        FROM ChamCong
                        WHERE MaNV = @MaNV
                          AND NgayLam = @NgayLam
                        ORDER BY MaChamCong DESC";

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

                    // -------------------------------------------------
                    // 2. CẬP NHẬT CHẤM CÔNG
                    // -------------------------------------------------
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

                    // -------------------------------------------------
                    // 3. ĐÓNG CA LÀM VIỆC + TỔNG KẾT CA
                    //
                    // Không phụ thuộc HoaDon.MaCa.
                    // Doanh thu được tính theo:
                    //   - đúng MaNV
                    //   - khoảng thời gian GioBatDau -> GioRa
                    //   - hóa đơn Hoàn thành
                    // -------------------------------------------------
                    string sqlDongCa = @"
                        UPDATE CaLamViec
                        SET
                            GioKetThuc = @GioKetThuc,

                            DoanhThu = ISNULL(
                                (
                                    SELECT SUM(ISNULL(hd.TongTien, 0))
                                    FROM HoaDon hd
                                    WHERE hd.MaNV = CaLamViec.MaNV
                                      AND hd.NgayLap >= CaLamViec.GioBatDau
                                      AND hd.NgayLap <= @GioKetThuc
                                      AND hd.TrangThaiDonHang = N'Hoàn thành'
                                ),
                                0
                            ),

                            SoHoaDon = ISNULL(
                                (
                                    SELECT COUNT(*)
                                    FROM HoaDon hd
                                    WHERE hd.MaNV = CaLamViec.MaNV
                                      AND hd.NgayLap >= CaLamViec.GioBatDau
                                      AND hd.NgayLap <= @GioKetThuc
                                      AND hd.TrangThaiDonHang = N'Hoàn thành'
                                ),
                                0
                            ),

                            TrangThai = N'Đã kết thúc'

                        WHERE MaCa = (
                            SELECT TOP 1 MaCa
                            FROM CaLamViec
                            WHERE MaNV = @MaNV
                              AND TrangThai = N'Đang làm'
                            ORDER BY MaCa DESC
                        );";

                    int soDongCa;

                    using (SqlCommand cmdDongCa =
                        new SqlCommand(sqlDongCa, conn))
                    {
                        cmdDongCa.Parameters.Add(
                            "@MaNV",
                            SqlDbType.Int).Value = maNV;

                        cmdDongCa.Parameters.Add(
                            "@GioKetThuc",
                            SqlDbType.DateTime).Value = gioRa;

                        soDongCa = cmdDongCa.ExecuteNonQuery();
                    }

                    if (soDongCa == 0)
                    {
                        MessageBox.Show(
                            "Đã ghi giờ ra nhưng không tìm thấy ca đang làm " +
                            "trong bảng CaLamViec.\n\n" +
                            "Hãy kiểm tra lại dữ liệu CaLamViec.",
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    Dtp_GioRa.Value = gioRa;

                    // -------------------------------------------------
                    // 4. LẤY KẾT QUẢ CA VỪA ĐÓNG
                    // -------------------------------------------------
                    decimal doanhThu = 0;
                    int soHoaDon = 0;

                    string sqlKetQua = @"
                        SELECT TOP 1
                            DoanhThu,
                            SoHoaDon
                        FROM CaLamViec
                        WHERE MaNV = @MaNV
                        ORDER BY MaCa DESC";

                    using (SqlCommand cmdKetQua =
                        new SqlCommand(sqlKetQua, conn))
                    {
                        cmdKetQua.Parameters.Add(
                            "@MaNV",
                            SqlDbType.Int).Value = maNV;

                        using (SqlDataReader reader =
                            cmdKetQua.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                doanhThu =
                                    reader["DoanhThu"] == DBNull.Value
                                    ? 0
                                    : Convert.ToDecimal(
                                        reader["DoanhThu"]);

                                soHoaDon =
                                    reader["SoHoaDon"] == DBNull.Value
                                    ? 0
                                    : Convert.ToInt32(
                                        reader["SoHoaDon"]);
                            }
                        }
                    }

                    TimeSpan thoiGianLam = gioRa - gioVao;

                    MessageBox.Show(
                        "ĐÃ KẾT THÚC CA\n\n" +
                        "Nhân viên: " + txt_TenNV.Text + "\n" +
                        "Giờ vào: " + gioVao.ToString("dd/MM/yyyy HH:mm:ss") + "\n" +
                        "Giờ ra:  " + gioRa.ToString("dd/MM/yyyy HH:mm:ss") + "\n" +
                        "Thời gian: " +
                        (int)thoiGianLam.TotalHours + " giờ " +
                        thoiGianLam.Minutes + " phút\n\n" +
                        "Số hóa đơn: " + soHoaDon + "\n" +
                        "Doanh thu: " + doanhThu.ToString("N0") + " đ",
                        "Chấm công - Kết thúc ca",
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