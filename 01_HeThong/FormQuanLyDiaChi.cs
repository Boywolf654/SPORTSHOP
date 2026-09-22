using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._07_KhachHang
{
    public partial class FormQuanLyDiaChi : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private readonly int maKH;
        private int maDiaChiDangSua = 0;

        public FormQuanLyDiaChi(int maKH)
        {
            this.maKH = maKH;
            InitializeComponent();
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnMacDinh.Click += btnMacDinh_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvDiaChi.CellClick += dgvDiaChi_CellClick;
            Load += FormQuanLyDiaChi_Load;
        }

        private void FormQuanLyDiaChi_Load(object sender, EventArgs e)
        {
            ResetInput();
            LoadDiaChi();
        }

        private void LoadDiaChi()
        {
            DataTable dt = kt.GetData(@"
                SELECT MaDiaChi, NguoiNhan, SDT, DiaChiCuThe, TinhThanh, MacDinh
                FROM DiaChiKhachHang
                WHERE MaKH=@MaKH
                ORDER BY MacDinh DESC, MaDiaChi DESC",
                new SqlParameter[] { new SqlParameter("@MaKH", maKH) });

            dgvDiaChi.DataSource = dt;
            if (dgvDiaChi.Columns["MaDiaChi"] != null) dgvDiaChi.Columns["MaDiaChi"].HeaderText = "Mã";
            if (dgvDiaChi.Columns["NguoiNhan"] != null) dgvDiaChi.Columns["NguoiNhan"].HeaderText = "Người nhận";
            if (dgvDiaChi.Columns["SDT"] != null) dgvDiaChi.Columns["SDT"].HeaderText = "SĐT";
            if (dgvDiaChi.Columns["DiaChiCuThe"] != null) dgvDiaChi.Columns["DiaChiCuThe"].HeaderText = "Địa chỉ cụ thể";
            if (dgvDiaChi.Columns["TinhThanh"] != null) dgvDiaChi.Columns["TinhThanh"].HeaderText = "Tỉnh/Thành";
            if (dgvDiaChi.Columns["MacDinh"] != null) dgvDiaChi.Columns["MacDinh"].HeaderText = "Mặc định";

            foreach (DataGridViewRow row in dgvDiaChi.Rows)
            {
                if (row.Cells["MacDinh"].Value != null && row.Cells["MacDinh"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["MacDinh"].Value))
                    row.DefaultCellStyle.Font = new Font(dgvDiaChi.Font, FontStyle.Bold);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNguoiNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập người nhận.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiNhan.Focus();
                return false;
            }

            string sdt = txtSDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt) || sdt.Length < 9 || sdt.Length > 10)
            {
                MessageBox.Show("Số điện thoại phải có 9-10 chữ số.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            foreach (char c in sdt)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ cụ thể.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTinhThanh.Text))
            {
                MessageBox.Show("Vui lòng nhập tỉnh/thành.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTinhThanh.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection cn = kt.GetConnection())
                {
                    cn.Open();
                    using (SqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            if (chkMacDinh.Checked)
                            {
                                using (SqlCommand clear = new SqlCommand("UPDATE DiaChiKhachHang SET MacDinh=0 WHERE MaKH=@MaKH", cn, tr))
                                {
                                    clear.Parameters.AddWithValue("@MaKH", maKH);
                                    clear.ExecuteNonQuery();
                                }
                            }

                            using (SqlCommand cmd = new SqlCommand(@"
                                INSERT INTO DiaChiKhachHang(MaKH,NguoiNhan,SDT,DiaChiCuThe,TinhThanh,MacDinh)
                                VALUES(@MaKH,@NguoiNhan,@SDT,@DiaChi,@TinhThanh,@MacDinh)", cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@MaKH", maKH);
                                cmd.Parameters.AddWithValue("@NguoiNhan", txtNguoiNhan.Text.Trim());
                                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                                cmd.Parameters.AddWithValue("@TinhThanh", txtTinhThanh.Text.Trim());
                                cmd.Parameters.AddWithValue("@MacDinh", chkMacDinh.Checked);
                                cmd.ExecuteNonQuery();
                            }

                            tr.Commit();
                        }
                        catch { try { tr.Rollback(); } catch { } throw; }
                    }
                }

                MessageBox.Show("Đã thêm địa chỉ.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInput();
                LoadDiaChi();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm địa chỉ.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maDiaChiDangSua <= 0)
            {
                MessageBox.Show("Hãy chọn địa chỉ cần sửa.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection cn = kt.GetConnection())
                {
                    cn.Open();
                    using (SqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            if (chkMacDinh.Checked)
                            {
                                using (SqlCommand clear = new SqlCommand("UPDATE DiaChiKhachHang SET MacDinh=0 WHERE MaKH=@MaKH", cn, tr))
                                {
                                    clear.Parameters.AddWithValue("@MaKH", maKH);
                                    clear.ExecuteNonQuery();
                                }
                            }

                            using (SqlCommand cmd = new SqlCommand(@"
                                UPDATE DiaChiKhachHang
                                SET NguoiNhan=@NguoiNhan, SDT=@SDT, DiaChiCuThe=@DiaChi,
                                    TinhThanh=@TinhThanh, MacDinh=@MacDinh
                                WHERE MaDiaChi=@MaDiaChi AND MaKH=@MaKH", cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@NguoiNhan", txtNguoiNhan.Text.Trim());
                                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                                cmd.Parameters.AddWithValue("@TinhThanh", txtTinhThanh.Text.Trim());
                                cmd.Parameters.AddWithValue("@MacDinh", chkMacDinh.Checked);
                                cmd.Parameters.AddWithValue("@MaDiaChi", maDiaChiDangSua);
                                cmd.Parameters.AddWithValue("@MaKH", maKH);
                                if (cmd.ExecuteNonQuery() != 1) throw new Exception("Địa chỉ không tồn tại hoặc không thuộc khách hàng.");
                            }

                            tr.Commit();
                        }
                        catch { try { tr.Rollback(); } catch { } throw; }
                    }
                }

                MessageBox.Show("Đã cập nhật địa chỉ.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDiaChi();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật địa chỉ.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDiaChiDangSua <= 0)
            {
                MessageBox.Show("Hãy chọn địa chỉ cần xóa.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xóa địa chỉ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                kt.Execute("DELETE FROM DiaChiKhachHang WHERE MaDiaChi=@MaDiaChi AND MaKH=@MaKH",
                    new SqlParameter[] { new SqlParameter("@MaDiaChi", maDiaChiDangSua), new SqlParameter("@MaKH", maKH) });
                ResetInput();
                LoadDiaChi();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa địa chỉ.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            if (maDiaChiDangSua <= 0)
            {
                MessageBox.Show("Hãy chọn địa chỉ muốn đặt mặc định.", "Địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cn = kt.GetConnection())
                {
                    cn.Open();
                    using (SqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand clear = new SqlCommand("UPDATE DiaChiKhachHang SET MacDinh=0 WHERE MaKH=@MaKH", cn, tr))
                            {
                                clear.Parameters.AddWithValue("@MaKH", maKH);
                                clear.ExecuteNonQuery();
                            }
                            using (SqlCommand set = new SqlCommand("UPDATE DiaChiKhachHang SET MacDinh=1 WHERE MaDiaChi=@MaDiaChi AND MaKH=@MaKH", cn, tr))
                            {
                                set.Parameters.AddWithValue("@MaDiaChi", maDiaChiDangSua);
                                set.Parameters.AddWithValue("@MaKH", maKH);
                                if (set.ExecuteNonQuery() != 1) throw new Exception("Không tìm thấy địa chỉ.");
                            }
                            tr.Commit();
                        }
                        catch { try { tr.Rollback(); } catch { } throw; }
                    }
                }

                LoadDiaChi();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đặt địa chỉ mặc định.\n\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDiaChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDiaChi.Rows[e.RowIndex].DataBoundItem == null) return;
            DataGridViewRow row = dgvDiaChi.Rows[e.RowIndex];
            maDiaChiDangSua = Convert.ToInt32(row.Cells["MaDiaChi"].Value);
            txtNguoiNhan.Text = Convert.ToString(row.Cells["NguoiNhan"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["SDT"].Value);
            txtDiaChi.Text = Convert.ToString(row.Cells["DiaChiCuThe"].Value);
            txtTinhThanh.Text = Convert.ToString(row.Cells["TinhThanh"].Value);
            chkMacDinh.Checked = row.Cells["MacDinh"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["MacDinh"].Value);
            lblDangChon.Text = "Đang chọn mã địa chỉ: " + maDiaChiDangSua;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetInput();
            LoadDiaChi();
        }

        private void ResetInput()
        {
            maDiaChiDangSua = 0;
            txtNguoiNhan.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTinhThanh.Clear();
            chkMacDinh.Checked = false;
            lblDangChon.Text = "Chưa chọn địa chỉ";
        }
    }
}
