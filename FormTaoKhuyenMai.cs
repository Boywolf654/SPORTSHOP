using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormTaoKhuyenMai : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maCTKM;

        public FormTaoKhuyenMai()
        {
            InitializeComponent();
            maCTKM = 0;
            CauHinhGiaoDien();
            LoadSanPham();
            CapNhatPreview();
            dgvSanPham.CellValueChanged += dgvSanPham_CellValueChanged;
            dgvSanPham.CurrentCellDirtyStateChanged += dgvSanPham_CurrentCellDirtyStateChanged;
        }

        public FormTaoKhuyenMai(int maCTKM)
        {
            InitializeComponent();
            this.maCTKM = maCTKM;
            CauHinhGiaoDien();
            LoadSanPham();

            if (maCTKM > 0)
                LoadKhuyenMai(maCTKM);

            CapNhatPreview();
        }
        private void dgvSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                CapNhatSoLuongDaChon();
        }

        private void dgvSanPham_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.IsCurrentCellDirty)
                dgvSanPham.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void CauHinhGiaoDien()
        {
            cmbLoai.Items.Clear();
            cmbLoai.Items.Add("PhanTram");
            cmbLoai.Items.Add("TienMat");
            if (cmbLoai.SelectedIndex < 0)
                cmbLoai.SelectedIndex = 0;

            txtGiaTri.TextChanged += (s, e) => CapNhatPreview();
            txtSoLuongToiThieu.TextChanged += (s, e) => CapNhatPreview();
            cmbLoai.SelectedIndexChanged += (s, e) =>
            {
                lblDonVi.Text = cmbLoai.Text == "PhanTram" ? "%" : "đ";
                CapNhatPreview();
            };
            dtpBatDau.ValueChanged += (s, e) => CapNhatPreview();
            dtpKetThuc.ValueChanged += (s, e) => CapNhatPreview();
            txtTimSanPham.TextChanged += (s, e) => LocSanPham();
            chkChonTatCa.CheckedChanged += (s, e) => ChonTatCaTheoLoc(chkChonTatCa.Checked);
            btnHuy.Click += btnHuy_Click;
            btnLuu.Click += btnLuu_Click;
        }

        private void LoadSanPham()
        {
            try
            {
                string sql = @"
                    SELECT
                        sp.MaSP,
                        sp.TenSP,
                        ISNULL(dm.TenDanhMuc, N'') AS TenDanhMuc,
                        ISNULL(th.TenThuongHieu, N'') AS TenThuongHieu
                    FROM SanPham sp
                    LEFT JOIN DanhMuc dm ON dm.MaDM = sp.MaDM
                    LEFT JOIN ThuongHieu th ON th.MaTH = sp.MaTH
                    WHERE sp.TrangThai = 1
                    ORDER BY sp.MaSP DESC";

                DataTable dt = kt.GetData(sql, new SqlParameter[] { });

                dgvSanPham.DataSource = dt;

                if (dgvSanPham.Columns.Contains("MaSP"))
                    dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                if (dgvSanPham.Columns.Contains("TenSP"))
                    dgvSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                if (dgvSanPham.Columns.Contains("TenDanhMuc"))
                    dgvSanPham.Columns["TenDanhMuc"].HeaderText = "Danh mục";
                if (dgvSanPham.Columns.Contains("TenThuongHieu"))
                    dgvSanPham.Columns["TenThuongHieu"].HeaderText = "Thương hiệu";

                if (dgvSanPham.Columns.Contains("MaSP"))
                    dgvSanPham.Columns["MaSP"].Visible = false;

                dgvSanPham.ClearSelection();
                CapNhatSoLuongDaChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sản phẩm:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKhuyenMai(int ma)
        {
            try
            {
                string sql = @"
                    SELECT MaCTKM, TenChuongTrinh, MoTa, LoaiKhuyenMai,
                           GiaTri, SoLuongToiThieu, NgayBatDau, NgayKetThuc
                    FROM ChuongTrinhKhuyenMai
                    WHERE MaCTKM = @MaCTKM";

                DataTable dt = kt.GetData(sql, new SqlParameter[]
                {
                    new SqlParameter("@MaCTKM", ma)
                });

                if (dt.Rows.Count == 0)
                    return;

                DataRow r = dt.Rows[0];
                txtTen.Text = Convert.ToString(r["TenChuongTrinh"]);
                txtMoTa.Text = Convert.ToString(r["MoTa"]);
                cmbLoai.Text = Convert.ToString(r["LoaiKhuyenMai"]);
                txtGiaTri.Text = Convert.ToDecimal(r["GiaTri"]).ToString("0.##");
                txtSoLuongToiThieu.Text = Convert.ToInt32(r["SoLuongToiThieu"]).ToString();
                dtpBatDau.Value = Convert.ToDateTime(r["NgayBatDau"]);
                dtpKetThuc.Value = Convert.ToDateTime(r["NgayKetThuc"]);

                string sqlCT = "SELECT MaSP FROM ChiTietCTKM WHERE MaCTKM = @MaCTKM";
                DataTable ds = kt.GetData(sqlCT, new SqlParameter[]
                {
                    new SqlParameter("@MaCTKM", ma)
                });

                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.IsNewRow) continue;
                    int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);
                    row.Cells["Chon"].Value = ds.AsEnumerable()
                        .Any(x => Convert.ToInt32(x["MaSP"]) == maSP);
                }

                CapNhatSoLuongDaChon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được chương trình khuyến mãi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocSanPham()
        {
            string keyword = txtTimSanPham.Text.Trim().Replace("'", "''");

            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (row.IsNewRow) continue;

                string ten = Convert.ToString(row.Cells["TenSP"].Value);
                string dm = Convert.ToString(row.Cells["TenDanhMuc"].Value);
                string th = Convert.ToString(row.Cells["TenThuongHieu"].Value);

                row.Visible = keyword.Length == 0 ||
                              ten.IndexOf(keyword.Replace("''", "'"), StringComparison.OrdinalIgnoreCase) >= 0 ||
                              dm.IndexOf(keyword.Replace("''", "'"), StringComparison.OrdinalIgnoreCase) >= 0 ||
                              th.IndexOf(keyword.Replace("''", "'"), StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        private void ChonTatCaTheoLoc(bool chon)
        {
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (!row.IsNewRow && row.Visible)
                    row.Cells["Chon"].Value = chon;
            }
            CapNhatSoLuongDaChon();
        }

        private int DemSanPhamDaChon()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (!row.IsNewRow && Convert.ToBoolean(row.Cells["Chon"].Value ?? false))
                    count++;
            }
            return count;
        }

        private void CapNhatSoLuongDaChon()
        {
            lblDaChon.Text = "Đã chọn: " + DemSanPhamDaChon() + " sản phẩm";
        }

        private void CapNhatPreview()
        {
            decimal giaTri;
            int soLuong;

            decimal.TryParse(txtGiaTri.Text, out giaTri);
            int.TryParse(txtSoLuongToiThieu.Text, out soLuong);

            if (soLuong < 1) soLuong = 1;

            string donVi = cmbLoai.Text == "TienMat" ? "đ" : "%";
            string giaTriText = cmbLoai.Text == "TienMat"
                ? giaTri.ToString("#,##0") + "đ"
                : giaTri.ToString("0.##") + "%";

            lblPreview.Text =
                "💡 Xem trước: Mua tối thiểu " + soLuong +
                " sản phẩm → giảm " + giaTriText;

            lblThoiGian.Text =
                "📅 " + dtpBatDau.Value.ToString("dd/MM/yyyy") +
                "  →  " + dtpKetThuc.Value.ToString("dd/MM/yyyy");
        }

        private bool KiemTraDuLieu(out decimal giaTri, out int soLuong)
        {
            giaTri = 0;
            soLuong = 0;

            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chương trình.");
                txtTen.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaTri.Text, out giaTri) || giaTri <= 0)
            {
                MessageBox.Show("Giá trị khuyến mãi phải lớn hơn 0.");
                txtGiaTri.Focus();
                return false;
            }

            if (cmbLoai.Text == "PhanTram" && giaTri > 100)
            {
                MessageBox.Show("Giảm theo phần trăm không được vượt quá 100%.");
                txtGiaTri.Focus();
                return false;
            }

            if (!int.TryParse(txtSoLuongToiThieu.Text, out soLuong) || soLuong < 1)
            {
                MessageBox.Show("Số lượng tối thiểu phải từ 1 trở lên.");
                txtSoLuongToiThieu.Focus();
                return false;
            }

            if (dtpKetThuc.Value.Date < dtpBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được trước ngày bắt đầu.");
                dtpKetThuc.Focus();
                return false;
            }

            if (DemSanPhamDaChon() == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm áp dụng.");
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal giaTri;
                int soLuong;
                if (!KiemTraDuLieu(out giaTri, out soLuong))
                    return;

                string sqlCT = "";
                int maMoi = maCTKM;

                if (maCTKM <= 0)
                {
                    string sql = @"
                        INSERT INTO ChuongTrinhKhuyenMai
                        (TenChuongTrinh, MoTa, LoaiKhuyenMai, GiaTri,
                         SoLuongToiThieu, NgayBatDau, NgayKetThuc, TrangThai)
                        VALUES
                        (@Ten, @MoTa, @Loai, @GiaTri,
                         @SoLuong, @BatDau, @KetThuc, 1);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    maMoi = Convert.ToInt32(kt.ExecuteScalar(sql, new SqlParameter[]
                    {
                        new SqlParameter("@Ten", txtTen.Text.Trim()),
                        new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                        new SqlParameter("@Loai", cmbLoai.Text),
                        new SqlParameter("@GiaTri", giaTri),
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@BatDau", dtpBatDau.Value),
                        new SqlParameter("@KetThuc", dtpKetThuc.Value)
                    }));
                }
                else
                {
                    string sql = @"
                        UPDATE ChuongTrinhKhuyenMai
                        SET TenChuongTrinh=@Ten,
                            MoTa=@MoTa,
                            LoaiKhuyenMai=@Loai,
                            GiaTri=@GiaTri,
                            SoLuongToiThieu=@SoLuong,
                            NgayBatDau=@BatDau,
                            NgayKetThuc=@KetThuc
                        WHERE MaCTKM=@MaCTKM";

                    kt.Execute(sql, new SqlParameter[]
                    {
                        new SqlParameter("@Ten", txtTen.Text.Trim()),
                        new SqlParameter("@MoTa", txtMoTa.Text.Trim()),
                        new SqlParameter("@Loai", cmbLoai.Text),
                        new SqlParameter("@GiaTri", giaTri),
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@BatDau", dtpBatDau.Value),
                        new SqlParameter("@KetThuc", dtpKetThuc.Value),
                        new SqlParameter("@MaCTKM", maCTKM)
                    });

                    kt.Execute("DELETE FROM ChiTietCTKM WHERE MaCTKM=@MaCTKM",
                        new SqlParameter[] { new SqlParameter("@MaCTKM", maCTKM) });
                }

                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.IsNewRow || !Convert.ToBoolean(row.Cells["Chon"].Value ?? false))
                        continue;

                    int maSP = Convert.ToInt32(row.Cells["MaSP"].Value);

                    kt.Execute(@"
                        INSERT INTO ChiTietCTKM(MaCTKM, MaSP)
                        VALUES(@MaCTKM, @MaSP)",
                        new SqlParameter[]
                        {
                            new SqlParameter("@MaCTKM", maMoi),
                            new SqlParameter("@MaSP", maSP)
                        });
                }

                MessageBox.Show(
                    maCTKM > 0 ? "Đã cập nhật chương trình khuyến mãi." : "Đã tạo chương trình khuyến mãi.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu chương trình khuyến mãi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
