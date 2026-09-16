using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._07_KhachHang
{
    public partial class FormThongTinKhachHang : Form
    {
        private KetNoiDuLieu kt = new KetNoiDuLieu();

        private int maKH = 0;

        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtEmail;

        private bool dangChinhSua = false;

        public FormThongTinKhachHang()
        {
            InitializeComponent();

            btnChinhsua.Click += btnChinhsua_Click;
            btnNgunggiaodich.Click += btnNgunggiaodich_Click;

            btn_canhan.Click += btn_canhan_Click;
            btn_dntc.Click += btn_dntc_Click;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================

        private void FormThongTinKhachHang_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                if (Session.MaTK <= 0)
                {
                    MessageBox.Show(
                        "Không xác định được tài khoản đang đăng nhập.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                LoadThongTinKhachHang();
                LoadLichSuMuaHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thông tin khách hàng.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOAD THÔNG TIN KHÁCH HÀNG
        // =========================================================

        private void LoadThongTinKhachHang()
        {
            string sql = @"
                SELECT
                    MaKH,
                    HoTen,
                    SDT,
                    Email,
                    DiemTichLuy,
                    HangThanhVien,
                    TrangThai
                FROM KhachHang
                WHERE MaTK = @MaTK";

            DataTable dt = kt.GetData(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@MaTK", Session.MaTK)
                });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Tài khoản hiện tại chưa có thông tin khách hàng.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DataRow row = dt.Rows[0];

            maKH = Convert.ToInt32(row["MaKH"]);

            string hoTen =
                row["HoTen"] == DBNull.Value
                    ? ""
                    : row["HoTen"].ToString();

            string sdt =
                row["SDT"] == DBNull.Value
                    ? ""
                    : row["SDT"].ToString();

            string email =
                row["Email"] == DBNull.Value
                    ? ""
                    : row["Email"].ToString();

            int diem =
                row["DiemTichLuy"] == DBNull.Value
                    ? 0
                    : Convert.ToInt32(row["DiemTichLuy"]);

            string hang =
                row["HangThanhVien"] == DBNull.Value
                    ? "Thường"
                    : row["HangThanhVien"].ToString();

            bool trangThai =
                row["TrangThai"] == DBNull.Value ||
                Convert.ToBoolean(row["TrangThai"]);

            // ==============================
            // HEADER
            // ==============================

            lbthongtinkhachhang.Text = hoTen;

            lbMakh.Text =
                "KH-" + maKH.ToString("D5");

            if (trangThai)
            {
                lbTrangthai.Text = "• Đang giao dịch";
                lbTrangthai.ForeColor =
                    Color.FromArgb(16, 185, 129);

                btnNgunggiaodich.Text =
                    "Ngừng giao dịch";
            }
            else
            {
                lbTrangthai.Text = "• Ngừng giao dịch";
                lbTrangthai.ForeColor =
                    Color.FromArgb(220, 38, 38);

                btnNgunggiaodich.Text =
                    "Mở lại giao dịch";
            }

            // ==============================
            // THÔNG TIN CHUNG
            // ==============================

            label5.Text = hoTen;
            label11.Text =
                "KH-" + maKH.ToString("D5");

            label15.Text =
                string.IsNullOrWhiteSpace(sdt)
                    ? "Chưa cập nhật"
                    : sdt;

            // Email
            label21.Text =
                string.IsNullOrWhiteSpace(email)
                    ? "Chưa cập nhật"
                    : email;

            // Hạng thành viên
            label37.Text = hang;

            // Điểm tích lũy
            label41.Text =
                diem.ToString("N0") + " điểm";

            // Thông tin hiện tại chưa có cột tương ứng
            label7.Text = "Chưa cập nhật";
            label9.Text = "Chưa cập nhật";
            label13.Text = "Chưa cập nhật";
        }

        // =========================================================
        // CHỈNH SỬA
        // =========================================================

        private void btnChinhsua_Click(
            object sender,
            EventArgs e)
        {
            if (maKH <= 0)
                return;

            if (!dangChinhSua)
            {
                BatCheDoChinhSua();

                btnChinhsua.Text = "Lưu thay đổi";

                dangChinhSua = true;

                return;
            }

            LuuThongTinKhachHang();
        }

        // =========================================================
        // TẠO TEXTBOX CHỈ KHI CHỈNH SỬA
        // =========================================================

        private void BatCheDoChinhSua()
        {
            // Họ tên
            txtHoTen = TaoTextBox(
                label5,
                label5.Text);

            // Số điện thoại
            txtSDT = TaoTextBox(
                label15,
                label15.Text == "Chưa cập nhật"
                    ? ""
                    : label15.Text);

            // Email
            txtEmail = TaoTextBox(
                label21,
                label21.Text == "Chưa cập nhật"
                    ? ""
                    : label21.Text);
        }

        private TextBox TaoTextBox(
            Label label,
            string giaTri)
        {
            TextBox txt = new TextBox();

            txt.Text = giaTri;
            txt.Font = label.Font;
            txt.Location = label.Location;
            txt.Size = new Size(
                Math.Max(250, label.Width + 100),
                32);

            txt.BorderStyle =
                BorderStyle.FixedSingle;

            txt.BackColor = Color.White;

            label.Parent.Controls.Add(txt);

            label.Visible = false;

            txt.BringToFront();

            return txt;
        }

        // =========================================================
        // LƯU THÔNG TIN
        // =========================================================

        private void LuuThongTinKhachHang()
        {
            string hoTen =
                txtHoTen.Text.Trim();

            string sdt =
                txtSDT.Text.Trim();

            string email =
                txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show(
                    "Họ tên không được để trống.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHoTen.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(sdt))
            {
                if (sdt.Length != 10 ||
                    !long.TryParse(sdt, out _))
                {
                    MessageBox.Show(
                        "Số điện thoại phải gồm 10 chữ số.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtSDT.Focus();
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(email) &&
                !email.Contains("@"))
            {
                MessageBox.Show(
                    "Email không hợp lệ.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            try
            {
                string sql = @"
                    UPDATE KhachHang
                    SET
                        HoTen = @HoTen,
                        SDT = @SDT,
                        Email = @Email
                    WHERE MaKH = @MaKH";

                kt.Execute(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@HoTen", hoTen),

                    new SqlParameter(
                        "@SDT",
                        string.IsNullOrWhiteSpace(sdt)
                            ? (object)DBNull.Value
                            : sdt),

                    new SqlParameter(
                        "@Email",
                        string.IsNullOrWhiteSpace(email)
                            ? (object)DBNull.Value
                            : email),

                    new SqlParameter("@MaKH", maKH)
                });

                XoaTextBoxChinhSua();

                dangChinhSua = false;

                btnChinhsua.Text = "Chỉnh sửa";

                LoadThongTinKhachHang();

                MessageBox.Show(
                    "Cập nhật thông tin thành công!",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật thông tin.\n\n"
                    + ex.Message,
                    "Lỗi SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // XÓA TEXTBOX SAU KHI LƯU
        // =========================================================

        private void XoaTextBoxChinhSua()
        {
            if (txtHoTen != null)
            {
                txtHoTen.Dispose();
                txtHoTen = null;
            }

            if (txtSDT != null)
            {
                txtSDT.Dispose();
                txtSDT = null;
            }

            if (txtEmail != null)
            {
                txtEmail.Dispose();
                txtEmail = null;
            }

            label5.Visible = true;
            label15.Visible = true;
            label21.Visible = true;
        }

        // =========================================================
        // NGỪNG / MỞ GIAO DỊCH
        // =========================================================

        private void btnNgunggiaodich_Click(
            object sender,
            EventArgs e)
        {
            if (maKH <= 0)
                return;

            bool dangHoatDong =
                lbTrangthai.Text.Contains("Đang giao dịch");

            if (dangHoatDong)
            {
                DialogResult result =
                    MessageBox.Show(
                        "Bạn có chắc muốn ngừng giao dịch với khách hàng này?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                CapNhatTrangThai(false);
            }
            else
            {
                DialogResult result =
                    MessageBox.Show(
                        "Mở lại giao dịch cho khách hàng này?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                CapNhatTrangThai(true);
            }
        }

        private void CapNhatTrangThai(bool trangThai)
        {
            try
            {
                string sql = @"
                    UPDATE KhachHang
                    SET TrangThai = @TrangThai
                    WHERE MaKH = @MaKH";

                kt.Execute(
                sql,
                new SqlParameter[]
                {
                    new SqlParameter("@TrangThai", trangThai),
                    new SqlParameter("@MaKH", maKH)
                });

                LoadThongTinKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cập nhật trạng thái.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // LOẠI KHÁCH HÀNG
        // =========================================================

        private void btn_canhan_Click(
            object sender,
            EventArgs e)
        {
            btn_canhan.FillColor =
                Color.FromArgb(24, 119, 242);

            btn_canhan.ForeColor = Color.White;

            btn_dntc.FillColor =
                Color.FromArgb(245, 247, 250);

            btn_dntc.ForeColor =
                Color.FromArgb(110, 115, 125);
        }

        private void btn_dntc_Click(
            object sender,
            EventArgs e)
        {
            btn_dntc.FillColor =
                Color.FromArgb(24, 119, 242);

            btn_dntc.ForeColor = Color.White;

            btn_canhan.FillColor =
                Color.FromArgb(245, 247, 250);

            btn_canhan.ForeColor =
                Color.FromArgb(110, 115, 125);
        }

        // =========================================================
        // LỊCH SỬ MUA HÀNG
        // =========================================================

        private void LoadLichSuMuaHang()
        {
            /*
             * Chưa kết nối phần này ở giai đoạn hiện tại.
             *
             * Khi module đơn hàng/thanh toán hoàn thiện,
             * sẽ lấy lịch sử theo MaKH.
             */

            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(
                "MaDonHang",
                "Mã đơn hàng");

            dataGridView1.Columns.Add(
                "NgayMua",
                "Ngày mua");

            dataGridView1.Columns.Add(
                "TongTien",
                "Tổng tiền");

            dataGridView1.Columns.Add(
                "TrangThai",
                "Trạng thái");

            dataGridView1.Rows.Add(
                "Chưa có dữ liệu",
                "",
                "",
                "Chưa cập nhật");

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}