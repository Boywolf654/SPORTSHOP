using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class themcoupon : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();

        public themcoupon()
        {
            InitializeComponent();
            CauHinhGiaoDien();
            btn_them.Click += btn_them_Click;
            btn_huy.Click += btn_huy_Click;
            txt_macoupon.KeyPress += ChiChoKyTuMa;
            txt_giatri.KeyPress += ChiSoVaDauCham;
            txt_dontoithieu.KeyPress += ChiSoVaDauCham;
            txt_soluong.KeyPress += ChiSoVaDauCham;
        }

        private void CauHinhGiaoDien()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Text = "Thêm mã giảm giá";
            txt_macoupon.CharacterCasing = CharacterCasing.Upper;
            txt_loai.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_loai.Items.Clear();
            txt_loai.Items.Add("PhanTram");
            txt_loai.Items.Add("TienMat");
            txt_loai.SelectedIndex = 0;
            dt_ngaybatdau.Format = DateTimePickerFormat.Custom;
            dt_ngaybatdau.CustomFormat = "dd/MM/yyyy";
            dt_ketthuc.Format = DateTimePickerFormat.Custom;
            dt_ketthuc.CustomFormat = "dd/MM/yyyy";
            dt_ngaybatdau.Value = DateTime.Today;
            dt_ketthuc.Value = DateTime.Today.AddDays(30);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string ma = txt_macoupon.Text.Trim().ToUpper();
            string ten = txt_ten.Text.Trim();
            string loai = txt_loai.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma) || ma.Length < 4 || ma.Length > 30)
            {
                BaoLoi("Mã coupon phải từ 4 đến 30 ký tự.", txt_macoupon); return;
            }
            if (!Regex.IsMatch(ma, "^[A-Z0-9_-]+$"))
            {
                BaoLoi("Mã coupon chỉ được chứa A-Z, 0-9, _ hoặc -.", txt_macoupon); return;
            }
            if (string.IsNullOrWhiteSpace(ten) || ten.Length > 100)
            {
                BaoLoi("Tên chương trình không được trống và tối đa 100 ký tự.", txt_ten); return;
            }
            if (!decimal.TryParse(txt_giatri.Text.Trim(), out decimal giaTri) || giaTri <= 0)
            {
                BaoLoi("Giá trị giảm phải là số lớn hơn 0.", txt_giatri); return;
            }
            if (loai == "PhanTram" && giaTri > 100)
            {
                BaoLoi("Giảm theo phần trăm phải từ 0 đến 100.", txt_giatri); return;
            }
            if (!decimal.TryParse(txt_dontoithieu.Text.Trim(), out decimal toiThieu) || toiThieu < 0)
            {
                BaoLoi("Đơn tối thiểu phải là số không âm.", txt_dontoithieu); return;
            }
            if (!int.TryParse(txt_soluong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                BaoLoi("Số lượng sử dụng tối đa phải là số nguyên lớn hơn 0.", txt_soluong); return;
            }
            if (dt_ketthuc.Value.Date < dt_ngaybatdau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sqlCheck = "SELECT COUNT(*) FROM Voucher WHERE UPPER(MaCode) = @MaCode";
                SqlParameter[] pCheck = { new SqlParameter("@MaCode", ma) };
                if (Convert.ToInt32(kt.ExecuteScalar(sqlCheck, pCheck)) > 0)
                {
                    BaoLoi("Mã coupon đã tồn tại.", txt_macoupon); return;
                }

                string sql = @"
                    INSERT INTO Voucher
                    (MaCode, TenChuongTrinh, GiaTri, LoaiGiam,
                     GiaTriDonToiThieu, SoLuongToiDa, DaSuDung,
                     NgayBatDau, NgayHetHan, TrangThai)
                    VALUES
                    (@MaCode, @Ten, @GiaTri, @Loai,
                     @ToiThieu, @SoLuong, 0,
                     @NgayBatDau, @NgayHetHan, 1)";

                SqlParameter[] p =
                {
                    new SqlParameter("@MaCode", ma),
                    new SqlParameter("@Ten", ten),
                    new SqlParameter("@GiaTri", giaTri),
                    new SqlParameter("@Loai", loai),
                    new SqlParameter("@ToiThieu", toiThieu),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@NgayBatDau", dt_ngaybatdau.Value.Date),
                    new SqlParameter("@NgayHetHan", dt_ketthuc.Value.Date)
                };

                int affected = kt.Execute(sql, p);
                if (affected != 1) throw new Exception("Không thêm được coupon.");

                MessageBox.Show("Thêm coupon thành công!\n\nMã: " + ma,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                MessageBox.Show("Mã coupon đã tồn tại trong cơ sở dữ liệu.", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm coupon.\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoLoi(string msg, Control c)
        {
            MessageBox.Show(msg, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.Focus();
        }
        private void btn_huy_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
        private void ChiChoKyTuMa(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '_' || e.KeyChar == '-') return;
            e.Handled = true;
        }
        private void ChiSoVaDauCham(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || (e.KeyChar == '.' && !tb.Text.Contains("."))) return;
            e.Handled = true;
        }
    }
}
