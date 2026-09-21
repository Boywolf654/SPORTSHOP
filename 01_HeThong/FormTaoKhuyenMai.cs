using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        }

        public FormTaoKhuyenMai(int maCTKM)
        {
            InitializeComponent();
            this.maCTKM = maCTKM;
        }

        private void FormTaoKhuyenMai_Load(object sender, EventArgs e)
        {
            cboLoai.Items.Clear();
            cboLoai.Items.Add("PhanTram");
            cboLoai.Items.Add("TienMat");
            cboLoai.SelectedIndex = 0;

            dtpBatDau.Value = DateTime.Today;
            dtpKetThuc.Value = DateTime.Today.AddDays(7);
            nudGiaTri.Maximum = 100;
            nudSoLuong.Minimum = 1;
            nudSoLuong.Value = 1;

            TaiSanPham();

            if (maCTKM > 0)
            {
                lblTieuDe.Text = "✏  SỬA CHƯƠNG TRÌNH KHUYẾN MÃI";
                Text = "Sửa chương trình khuyến mãi";
                TaiDuLieu();
            }
        }

        private void TaiSanPham()
        {
            DataTable dt = kt.GetData(@"SELECT MaSP, TenSP
                                        FROM SanPham
                                        WHERE TrangThai = 1
                                        ORDER BY MaSP");

            clbSanPham.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                clbSanPham.Items.Add(new SanPhamItem
                {
                    MaSP = Convert.ToInt32(row["MaSP"]),
                    TenSP = Convert.ToString(row["TenSP"])
                }, false);
            }
        }

        private void TaiDuLieu()
        {
            DataTable dt = kt.GetData(@"
                SELECT TenChuongTrinh, MoTa, LoaiKhuyenMai, GiaTri,
                       SoLuongToiThieu, NgayBatDau, NgayKetThuc
                FROM ChuongTrinhKhuyenMai
                WHERE MaCTKM = @MaCTKM",
                new SqlParameter[] { new SqlParameter("@MaCTKM", maCTKM) });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chương trình.", "Khuyến mãi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            DataRow r = dt.Rows[0];

            txtTen.Text = Convert.ToString(r["TenChuongTrinh"]);
            txtMoTa.Text = r["MoTa"] == DBNull.Value ? "" : Convert.ToString(r["MoTa"]);
            cboLoai.SelectedItem = Convert.ToString(r["LoaiKhuyenMai"]);
            nudGiaTri.Value = Convert.ToDecimal(r["GiaTri"]);
            nudSoLuong.Value = Math.Max(1, Convert.ToDecimal(r["SoLuongToiThieu"]));
            dtpBatDau.Value = Convert.ToDateTime(r["NgayBatDau"]);
            dtpKetThuc.Value = Convert.ToDateTime(r["NgayKetThuc"]);

            DataTable sp = kt.GetData(
                "SELECT MaSP FROM ChiTietCTKM WHERE MaCTKM = @MaCTKM",
                new SqlParameter[] { new SqlParameter("@MaCTKM", maCTKM) });

            foreach (DataRow row in sp.Rows)
            {
                int maSP = Convert.ToInt32(row["MaSP"]);

                for (int i = 0; i < clbSanPham.Items.Count; i++)
                {
                    SanPhamItem item = clbSanPham.Items[i] as SanPhamItem;

                    if (item != null && item.MaSP == maSP)
                    {
                        clbSanPham.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudGiaTri.Maximum =
                cboLoai.SelectedItem != null &&
                cboLoai.SelectedItem.ToString() == "PhanTram"
                ? 100 : 1000000000;
        }

        private bool KiemTra(out string loi)
        {
            loi = "";

            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                loi = "Chưa nhập tên chương trình.";
                return false;
            }

            if (cboLoai.SelectedIndex < 0)
            {
                loi = "Chưa chọn loại khuyến mãi.";
                return false;
            }

            if (nudGiaTri.Value <= 0)
            {
                loi = "Giá trị khuyến mãi phải lớn hơn 0.";
                return false;
            }

            if (dtpKetThuc.Value.Date < dtpBatDau.Value.Date)
            {
                loi = "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.";
                return false;
            }

            if (clbSanPham.CheckedItems.Count == 0)
            {
                loi = "Hãy chọn ít nhất một sản phẩm áp dụng.";
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTra(out string loi))
            {
                MessageBox.Show(loi, "Khuyến mãi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection cn = kt.GetConnection())
            {
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        int ma;

                        if (maCTKM == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO ChuongTrinhKhuyenMai
                                (TenChuongTrinh, MoTa, LoaiKhuyenMai, GiaTri,
                                 SoLuongToiThieu, NgayBatDau, NgayKetThuc, TrangThai)
                                OUTPUT INSERTED.MaCTKM
                                VALUES
                                (@Ten,@MoTa,@Loai,@GiaTri,@SoLuong,@BatDau,@KetThuc,1)",
                                cn, tran))
                            {
                                GanParameter(cmd);
                                ma = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        else
                        {
                            ma = maCTKM;

                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE ChuongTrinhKhuyenMai
                                SET TenChuongTrinh=@Ten, MoTa=@MoTa,
                                    LoaiKhuyenMai=@Loai, GiaTri=@GiaTri,
                                    SoLuongToiThieu=@SoLuong,
                                    NgayBatDau=@BatDau, NgayKetThuc=@KetThuc
                                WHERE MaCTKM=@MaCTKM", cn, tran))
                            {
                                GanParameter(cmd);
                                cmd.Parameters.AddWithValue("@MaCTKM", ma);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand(
                                "DELETE FROM ChiTietCTKM WHERE MaCTKM=@MaCTKM", cn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaCTKM", ma);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        foreach (object obj in clbSanPham.CheckedItems)
                        {
                            SanPhamItem item = obj as SanPhamItem;
                            if (item == null) continue;

                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO ChiTietCTKM(MaCTKM, MaSP)
                                VALUES(@MaCTKM,@MaSP)", cn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaCTKM", ma);
                                cmd.Parameters.AddWithValue("@MaSP", item.MaSP);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();

                        MessageBox.Show("Đã lưu chương trình khuyến mãi.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }

                        MessageBox.Show("Không thể lưu chương trình.\n\n" + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GanParameter(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Ten", txtTen.Text.Trim());
            cmd.Parameters.AddWithValue("@MoTa",
                string.IsNullOrWhiteSpace(txtMoTa.Text)
                ? (object)DBNull.Value : txtMoTa.Text.Trim());
            cmd.Parameters.AddWithValue("@Loai", cboLoai.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@GiaTri", nudGiaTri.Value);
            cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(nudSoLuong.Value));
            cmd.Parameters.AddWithValue("@BatDau", dtpBatDau.Value.Date);
            cmd.Parameters.AddWithValue("@KetThuc", dtpKetThuc.Value.Date);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private sealed class SanPhamItem
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }

            public override string ToString()
            {
                return MaSP.ToString("D3") + "  •  " + TenSP;
            }
        }
    }
}
