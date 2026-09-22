using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormQLHinhAnhSanPham : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maSP;
        private int? maAnhDangChon = null;
        private string fileDaChon = null;

        public FormQLHinhAnhSanPham()
        {
            InitializeComponent();
            maSP = 0;
        }

        public FormQLHinhAnhSanPham(int maSP)
            : this()
        {
            this.maSP = maSP;
        }

        private void FormQLHinhAnhSanPham_Load(object sender, EventArgs e)
        {
            CauHinhGiaoDien();
            LoadThongTinSanPham();
            LoadDanhSachAnh();
            ClearAnhForm();
        }

        private void CauHinhGiaoDien()
        {
            this.Text = "SPORTSHOP - Quản lý hình ảnh sản phẩm";
            this.BackColor = Color.FromArgb(18, 18, 18);

            CauHinhButton(btnChonFile);
            CauHinhButton(btnThemAnh);
            CauHinhButton(btnDatAnhChinh);
            CauHinhButton(btnXoaAnh);
            CauHinhButton(btnLamMoi);

            dgvAnh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnh.MultiSelect = false;
            dgvAnh.ReadOnly = true;
            dgvAnh.AllowUserToAddRows = false;
            dgvAnh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnh.RowTemplate.Height = 32;

            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.BackColor = Color.FromArgb(35, 35, 37);

            btnThemAnh.Enabled = false;
            btnDatAnhChinh.Enabled = false;
            btnXoaAnh.Enabled = false;
        }

        private void CauHinhButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(220, 30, 45);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private void LoadThongTinSanPham()
        {
            if (maSP <= 0)
            {
                lblSanPham.Text = "Chưa chọn sản phẩm";
                return;
            }

            string sql = @"
                SELECT MaSP, TenSP
                FROM SanPham
                WHERE MaSP = @MaSP";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSP", maSP)
            };

            DataTable dt = kt.GetData(sql, parameters);

            if (dt.Rows.Count == 0)
            {
                lblSanPham.Text = "Không tìm thấy sản phẩm";
                return;
            }

            lblSanPham.Text =
                "SP" + maSP.ToString("D4") + " - " +
                dt.Rows[0]["TenSP"].ToString();
        }

        private void LoadDanhSachAnh()
        {
            dgvAnh.Rows.Clear();
            maAnhDangChon = null;

            if (maSP <= 0)
                return;

            string sql = @"
                SELECT
                    MaAnh,
                    UrlAnh,
                    AnhChinh
                FROM HinhAnhSanPham
                WHERE MaSP = @MaSP
                ORDER BY AnhChinh DESC, MaAnh DESC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaSP", maSP)
            };

            DataTable dt = kt.GetData(sql, parameters);

            foreach (DataRow row in dt.Rows)
            {
                int index = dgvAnh.Rows.Add(
                    row["MaAnh"],
                    row["UrlAnh"],
                    Convert.ToBoolean(row["AnhChinh"]) ? "Ảnh chính" : ""
                );

                dgvAnh.Rows[index].Tag =
                    Convert.ToInt32(row["MaAnh"]);
            }

            if (dgvAnh.Columns.Count >= 3)
            {
                dgvAnh.Columns[0].HeaderText = "Mã ảnh";
                dgvAnh.Columns[1].HeaderText = "Đường dẫn ảnh";
                dgvAnh.Columns[2].HeaderText = "Trạng thái";
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn hình ảnh sản phẩm";
                dialog.Filter =
                    "Ảnh (*.jpg;*.jpeg;*.png;*.webp;*.bmp)|*.jpg;*.jpeg;*.png;*.webp;*.bmp|" +
                    "Tất cả tập tin (*.*)|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                fileDaChon = dialog.FileName;
                txtDuongDan.Text = fileDaChon;
                HienThiAnh(fileDaChon);
                btnThemAnh.Enabled = maSP > 0;
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            if (maSP <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm trước.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(fileDaChon) ||
                !File.Exists(fileDaChon))
            {
                MessageBox.Show(
                    "Vui lòng chọn một file hình ảnh.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string thuMuc = Path.Combine(
                    Application.StartupPath,
                    "Images",
                    "Products",
                    "SP_" + maSP.ToString());

                Directory.CreateDirectory(thuMuc);

                string tenFile = Path.GetFileName(fileDaChon);
                string duongDanDich = Path.Combine(thuMuc, tenFile);

                if (File.Exists(duongDanDich))
                {
                    string ten = Path.GetFileNameWithoutExtension(tenFile);
                    string ext = Path.GetExtension(tenFile);
                    tenFile = ten + "_" +
                              DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                              ext;
                    duongDanDich = Path.Combine(thuMuc, tenFile);
                }

                File.Copy(fileDaChon, duongDanDich, false);

                string duongDanLuu = Path.Combine(
                    "Images",
                    "Products",
                    "SP_" + maSP.ToString(),
                    tenFile).Replace("\\", "/");

                string sql = @"
                    INSERT INTO HinhAnhSanPham
                    (
                        MaSP,
                        UrlAnh,
                        AnhChinh
                    )
                    VALUES
                    (
                        @MaSP,
                        @UrlAnh,
                        CASE
                            WHEN EXISTS
                            (
                                SELECT 1
                                FROM HinhAnhSanPham
                                WHERE MaSP = @MaSP
                                  AND AnhChinh = 1
                            )
                            THEN 0
                            ELSE 1
                        END
                    )";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaSP", maSP),
                    new SqlParameter("@UrlAnh", duongDanLuu)
                };

                kt.Execute(sql, parameters);

                MessageBox.Show(
                    "Đã thêm hình ảnh.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDanhSachAnh();
                ClearAnhForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm hình ảnh.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDatAnhChinh_Click(object sender, EventArgs e)
        {
            if (maAnhDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn hình ảnh.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = kt.GetConnection())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        string sqlTatCa = @"
                            UPDATE HinhAnhSanPham
                            SET AnhChinh = 0
                            WHERE MaSP = @MaSP";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlTatCa, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlAnhChinh = @"
                            UPDATE HinhAnhSanPham
                            SET AnhChinh = 1
                            WHERE MaAnh = @MaAnh
                              AND MaSP = @MaSP";

                        using (SqlCommand cmd = new SqlCommand(
                            sqlAnhChinh, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@MaAnh", maAnhDangChon.Value);
                            cmd.Parameters.AddWithValue(
                                "@MaSP", maSP);

                            if (cmd.ExecuteNonQuery() != 1)
                                throw new Exception(
                                    "Không tìm thấy hình ảnh cần đặt làm ảnh chính.");
                        }

                        tran.Commit();
                    }
                }

                LoadDanhSachAnh();

                MessageBox.Show(
                    "Đã đặt ảnh chính.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể đặt ảnh chính.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            if (maAnhDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn hình ảnh cần xóa.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Xóa hình ảnh đang chọn khỏi sản phẩm?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sqlLayAnh = @"
                    SELECT UrlAnh, AnhChinh
                    FROM HinhAnhSanPham
                    WHERE MaAnh = @MaAnh
                      AND MaSP = @MaSP";

                SqlParameter[] p =
                {
                    new SqlParameter("@MaAnh", maAnhDangChon.Value),
                    new SqlParameter("@MaSP", maSP)
                };

                DataTable dt = kt.GetData(sqlLayAnh, p);

                if (dt.Rows.Count == 0)
                    return;

                string url = dt.Rows[0]["UrlAnh"].ToString();
                bool anhChinh = Convert.ToBoolean(dt.Rows[0]["AnhChinh"]);

                kt.Execute(
                    "DELETE FROM HinhAnhSanPham WHERE MaAnh=@MaAnh AND MaSP=@MaSP",
                    p);

                if (anhChinh)
                {
                    string sqlChonAnhMoi = @"
                        UPDATE HinhAnhSanPham
                        SET AnhChinh = 1
                        WHERE MaAnh =
                        (
                            SELECT TOP 1 MaAnh
                            FROM HinhAnhSanPham
                            WHERE MaSP = @MaSP
                            ORDER BY MaAnh DESC
                        )
                        AND MaSP = @MaSP";

                    kt.Execute(
                        sqlChonAnhMoi,
                        new SqlParameter[]
                        {
                            new SqlParameter("@MaSP", maSP)
                        });
                }

                // Chỉ xóa file local do FormQLHinhAnh tạo.
                try
                {
                    string duongDan = url.Replace(
                        "/", Path.DirectorySeparatorChar.ToString());

                    if (!Path.IsPathRooted(duongDan))
                        duongDan = Path.Combine(
                            Application.StartupPath,
                            duongDan);

                    if (File.Exists(duongDan))
                        File.Delete(duongDan);
                }
                catch
                {
                    // DB đã xóa thì không làm thất bại thao tác chỉ vì file không xóa được.
                }

                LoadDanhSachAnh();
                ClearAnhForm();

                MessageBox.Show(
                    "Đã xóa hình ảnh.",
                    "SPORTSHOP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa hình ảnh.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadThongTinSanPham();
            LoadDanhSachAnh();
            ClearAnhForm();
        }

        private void dgvAnh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvAnh.Rows[e.RowIndex];

            if (row.Tag == null)
                return;

            maAnhDangChon = Convert.ToInt32(row.Tag);

            string url = row.Cells[1].Value?.ToString() ?? "";
            string duongDan = url.Replace(
                "/", Path.DirectorySeparatorChar.ToString());

            if (!Path.IsPathRooted(duongDan))
                duongDan = Path.Combine(Application.StartupPath, duongDan);

            HienThiAnh(duongDan);

            btnDatAnhChinh.Enabled = true;
            btnXoaAnh.Enabled = true;
        }

        private void HienThiAnh(string duongDan)
        {
            try
            {
                if (!File.Exists(duongDan))
                {
                    picPreview.Image = null;
                    return;
                }

                using (Image temp = Image.FromFile(duongDan))
                {
                    picPreview.Image = new Bitmap(temp);
                }
            }
            catch
            {
                picPreview.Image = null;
            }
        }

        private void ClearAnhForm()
        {
            maAnhDangChon = null;
            fileDaChon = null;
            txtDuongDan.Clear();

            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }

            btnThemAnh.Enabled = false;
            btnDatAnhChinh.Enabled = false;
            btnXoaAnh.Enabled = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }

            base.OnFormClosed(e);
        }
    }
}
