using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormQuanLyChamCong : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private int maChamCongDangChon = 0;
        private int maNVDangChon = 0;

        public FormQuanLyChamCong()
        {
            InitializeComponent();
            btnLamMoi.Click += btnLamMoi_Click;
            btnTim.Click += btnTim_Click;
            btnLuu.Click += btnLuu_Click;
            dgvChamCong.SelectionChanged += dgvChamCong_SelectionChanged;
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            cmbNhanVien.SelectedIndexChanged += cmbNhanVien_SelectedIndexChanged;
            cmbTrangThai.SelectedIndexChanged += cmbTrangThai_SelectedIndexChanged;
        }

        private void FormQuanLyChamCong_Load(object sender, EventArgs e)
        {
            if (Session.MaVaiTro != PhanQuyen.ADMIN &&
                Session.MaVaiTro != PhanQuyen.QUAN_LY)
            {
                MessageBox.Show(
                    "Chỉ Admin hoặc Quản lý được phép quản lý chấm công.",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                BeginInvoke(new Action(Close));
                return;
            }

            dtpNgay.Value = DateTime.Today;
            dtpGioVao.Value = DateTime.Now;
            dtpGioRa.Value = DateTime.Now;

            LoadNhanVien();
            LoadDanhSach();
        }

        private void LoadNhanVien()
        {
            string sql = $@"
                SELECT nv.MaNV, nv.HoTen
                FROM NhanVien nv
                INNER JOIN TaiKhoan tk ON tk.MaTK = nv.MaTK
                WHERE tk.MaVaiTro IN ({PhanQuyen.NV_BAN_HANG}, {PhanQuyen.NV_KHO})
                ORDER BY nv.HoTen, nv.MaNV;";

            DataTable dt = kt.GetData(sql);

            DataRow all = dt.NewRow();
            all["MaNV"] = 0;
            all["HoTen"] = "Tất cả nhân viên";
            dt.Rows.InsertAt(all, 0);

            cmbNhanVien.DataSource = dt;
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaNV";
            cmbNhanVien.SelectedIndex = 0;
        }

        private int MaNVFilter()
        {
            if (cmbNhanVien.SelectedValue == null) return 0;
            int ma;
            return int.TryParse(cmbNhanVien.SelectedValue.ToString(), out ma) ? ma : 0;
        }

        private void LoadDanhSach()
        {
            int maNV = MaNVFilter();
            string trangThai = cmbTrangThai.SelectedItem == null
                ? "Tất cả"
                : cmbTrangThai.SelectedItem.ToString();

            string ngaySql = dtpNgay.Value.Date.ToString("yyyyMMdd");
            string sql = $@"
                SELECT
                    nv.MaNV,
                    nv.HoTen,
                    cc.MaChamCong,
                    CONVERT(date, '{ngaySql}', 112) AS NgayLam,
                    cc.GioVao,
                    cc.GioRa,
                    CASE
                        WHEN cc.MaChamCong IS NULL THEN N'Chưa vào ca'
                        WHEN cc.GioVao IS NOT NULL AND cc.GioRa IS NULL THEN N'Đang làm'
                        WHEN cc.GioVao IS NOT NULL AND cc.GioRa IS NOT NULL THEN N'Đã hoàn thành'
                        ELSE N'Chưa vào ca'
                    END AS TrangThai,
                    CASE
                        WHEN cc.GioVao IS NOT NULL AND cc.GioRa IS NOT NULL
                        THEN DATEDIFF(MINUTE, cc.GioVao, cc.GioRa)
                        ELSE NULL
                    END AS SoPhutLam
                FROM NhanVien nv
                INNER JOIN TaiKhoan tk ON tk.MaTK = nv.MaTK
                LEFT JOIN ChamCong cc
                    ON cc.MaNV = nv.MaNV
                   AND cc.NgayLam = CONVERT(date, '{ngaySql}', 112)
                WHERE tk.MaVaiTro IN ({PhanQuyen.NV_BAN_HANG}, {PhanQuyen.NV_KHO})
                  AND ({maNV} = 0 OR nv.MaNV = {maNV})
                ORDER BY
                    CASE
                        WHEN cc.MaChamCong IS NULL THEN 0
                        WHEN cc.GioVao IS NOT NULL AND cc.GioRa IS NULL THEN 1
                        ELSE 2
                    END,
                    nv.HoTen;";

            DataTable dt = kt.GetData(sql);

            if (trangThai != "Tất cả")
            {
                DataView v = dt.DefaultView;
                string safe = trangThai.Replace("'", "''");
                v.RowFilter = "TrangThai = '" + safe + "'";
                dgvChamCong.DataSource = v;
            }
            else
            {
                dgvChamCong.DataSource = dt;
            }

            CauHinhGrid();
            CapNhatThongKe(dt);
            ClearEditor();
        }

        private void CauHinhGrid()
        {
            if (dgvChamCong.Columns.Count == 0) return;

            string[] hide = { "MaChamCong" };
            foreach (string c in hide)
                if (dgvChamCong.Columns.Contains(c))
                    dgvChamCong.Columns[c].Visible = false;

            dgvChamCong.Columns["MaNV"].HeaderText = "Mã NV";
            dgvChamCong.Columns["HoTen"].HeaderText = "Nhân viên";
            dgvChamCong.Columns["NgayLam"].HeaderText = "Ngày";
            dgvChamCong.Columns["GioVao"].HeaderText = "Giờ vào";
            dgvChamCong.Columns["GioRa"].HeaderText = "Giờ ra";
            dgvChamCong.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvChamCong.Columns["SoPhutLam"].HeaderText = "Thời gian làm";

            dgvChamCong.Columns["NgayLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvChamCong.Columns["GioVao"].DefaultCellStyle.Format = "HH:mm:ss";
            dgvChamCong.Columns["GioRa"].DefaultCellStyle.Format = "HH:mm:ss";

            dgvChamCong.Columns["MaNV"].Width = 75;
            dgvChamCong.Columns["HoTen"].Width = 190;
            dgvChamCong.Columns["NgayLam"].Width = 100;
            dgvChamCong.Columns["GioVao"].Width = 100;
            dgvChamCong.Columns["GioRa"].Width = 100;
            dgvChamCong.Columns["TrangThai"].Width = 125;
            dgvChamCong.Columns["SoPhutLam"].Width = 120;
        }

        private void CapNhatThongKe(DataTable dt)
        {
            int tong = dt.Rows.Count;
            int chua = 0, dang = 0, xong = 0;

            foreach (DataRow r in dt.Rows)
            {
                string tt = r["TrangThai"].ToString();
                if (tt == "Chưa vào ca") chua++;
                else if (tt == "Đang làm") dang++;
                else if (tt == "Đã hoàn thành") xong++;
            }

            lblTong.Text = "Tổng: " + tong.ToString("N0");
            lblChua.Text = "Chưa vào ca: " + chua.ToString("N0");
            lblDang.Text = "Đang làm: " + dang.ToString("N0");
            lblXong.Text = "Đã hoàn thành: " + xong.ToString("N0");
        }

        private void dgvChamCong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChamCong.CurrentRow == null) return;

            DataGridViewRow r = dgvChamCong.CurrentRow;
            if (r.Cells["MaNV"].Value == null) return;

            int.TryParse(r.Cells["MaNV"].Value.ToString(), out maNVDangChon);
            int.TryParse(Convert.ToString(r.Cells["MaChamCong"].Value), out maChamCongDangChon);

            lblNhanVien.Text = "Đang chọn: NV" + maNVDangChon + " - " +
                               Convert.ToString(r.Cells["HoTen"].Value);

            bool coVao = r.Cells["GioVao"].Value != null &&
                         r.Cells["GioVao"].Value != DBNull.Value;
            bool coRa = r.Cells["GioRa"].Value != null &&
                        r.Cells["GioRa"].Value != DBNull.Value;

            chkCoGioVao.Checked = coVao;
            chkCoGioRa.Checked = coRa;

            if (coVao) dtpGioVao.Value = Convert.ToDateTime(r.Cells["GioVao"].Value);
            else dtpGioVao.Value = DateTime.Today.AddHours(8);

            if (coRa) dtpGioRa.Value = Convert.ToDateTime(r.Cells["GioRa"].Value);
            else dtpGioRa.Value = DateTime.Today.AddHours(17);
        }

        private void ClearEditor()
        {
            maChamCongDangChon = 0;
            maNVDangChon = 0;
            lblNhanVien.Text = "Chưa chọn nhân viên";
            chkCoGioVao.Checked = false;
            chkCoGioRa.Checked = false;
            dtpGioVao.Value = DateTime.Today.AddHours(8);
            dtpGioRa.Value = DateTime.Today.AddHours(17);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (maNVDangChon <= 0)
            {
                MessageBox.Show("Hãy chọn nhân viên cần chỉnh chấm công.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkCoGioRa.Checked && !chkCoGioVao.Checked)
            {
                MessageBox.Show("Không thể có giờ ra nếu chưa có giờ vào.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngay = dtpNgay.Value.Date;
            DateTime? gioVao = chkCoGioVao.Checked
                ? (DateTime?)new DateTime(ngay.Year, ngay.Month, ngay.Day,
                    dtpGioVao.Value.Hour, dtpGioVao.Value.Minute, dtpGioVao.Value.Second)
                : null;
            DateTime? gioRa = chkCoGioRa.Checked
                ? (DateTime?)new DateTime(ngay.Year, ngay.Month, ngay.Day,
                    dtpGioRa.Value.Hour, dtpGioRa.Value.Minute, dtpGioRa.Value.Second)
                : null;

            if (gioVao.HasValue && gioRa.HasValue && gioRa.Value <= gioVao.Value)
            {
                MessageBox.Show("Giờ ra phải lớn hơn giờ vào.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            int maCC = 0;
                            string find = @"
                                SELECT TOP 1 MaChamCong
                                FROM ChamCong
                                WHERE MaNV=@MaNV AND NgayLam=@NgayLam
                                ORDER BY MaChamCong DESC;";
                            using (SqlCommand c = new SqlCommand(find, conn, tran))
                            {
                                c.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNVDangChon;
                                c.Parameters.Add("@NgayLam", SqlDbType.Date).Value = ngay;
                                object o = c.ExecuteScalar();
                                if (o != null && o != DBNull.Value) maCC = Convert.ToInt32(o);
                            }

                            string trangThai = !gioVao.HasValue
                                ? "Chưa vào ca"
                                : (!gioRa.HasValue ? "Đang làm" : "Có mặt");

                            if (maCC == 0)
                            {
                                string insert = @"
                                    INSERT INTO ChamCong
                                    (MaNV, NgayLam, GioVao, GioRa, TrangThai)
                                    VALUES (@MaNV,@NgayLam,@GioVao,@GioRa,@TrangThai);";
                                using (SqlCommand c = new SqlCommand(insert, conn, tran))
                                {
                                    c.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNVDangChon;
                                    c.Parameters.Add("@NgayLam", SqlDbType.Date).Value = ngay;
                                    c.Parameters.Add("@GioVao", SqlDbType.DateTime).Value =
                                        (object)gioVao ?? DBNull.Value;
                                    c.Parameters.Add("@GioRa", SqlDbType.DateTime).Value =
                                        (object)gioRa ?? DBNull.Value;
                                    c.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 30).Value = trangThai;
                                    c.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string update = @"
                                    UPDATE ChamCong
                                    SET GioVao=@GioVao, GioRa=@GioRa, TrangThai=@TrangThai
                                    WHERE MaChamCong=@MaChamCong;";
                                using (SqlCommand c = new SqlCommand(update, conn, tran))
                                {
                                    c.Parameters.Add("@GioVao", SqlDbType.DateTime).Value =
                                        (object)gioVao ?? DBNull.Value;
                                    c.Parameters.Add("@GioRa", SqlDbType.DateTime).Value =
                                        (object)gioRa ?? DBNull.Value;
                                    c.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 30).Value = trangThai;
                                    c.Parameters.Add("@MaChamCong", SqlDbType.Int).Value = maCC;
                                    c.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Đã lưu chấm công cho " + lblNhanVien.Text.Replace("Đang chọn: ", ""),
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu chấm công:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e) => LoadDanhSach();
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpNgay.Value = DateTime.Today;
            if (cmbNhanVien.Items.Count > 0) cmbNhanVien.SelectedIndex = 0;
            cmbTrangThai.SelectedIndex = 0;
            LoadDanhSach();
        }
        private void dtpNgay_ValueChanged(object sender, EventArgs e) => LoadDanhSach();
        private void cmbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadDanhSach();
        }
        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated) LoadDanhSach();
        }
    }
}