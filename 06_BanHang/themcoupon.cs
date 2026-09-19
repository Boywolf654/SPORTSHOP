using System;
using System.Data;
using System.Data.SqlClient;
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
            txt_loai.Items.Clear();
            txt_loai.Items.Add("PhanTram");
            txt_loai.Items.Add("TienMat");
            txt_loai.SelectedIndex = 0;
            dt_ngaybatdau.Value = DateTime.Today;
            dt_ketthuc.Value = DateTime.Today.AddDays(30);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string ma = txt_macoupon.Text.Trim().ToUpper();
            string ten = txt_ten.Text.Trim();

            if (!Regex.IsMatch(ma, @"^[A-Z0-9_-]{4,30}$"))
            {
                MessageBox.Show("Mã voucher phải 4-30 ký tự, chỉ gồm A-Z, 0-9, _ hoặc -.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_macoupon.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập tên chương trình.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ten.Focus();
                return;
            }

            if (!decimal.TryParse(txt_giatri.Text.Trim(), out decimal giaTri) || giaTri <= 0)
            {
                MessageBox.Show("Giá trị giảm không hợp lệ.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_giatri.Focus();
                return;
            }

            if (!decimal.TryParse(txt_dontoithieu.Text.Trim(), out decimal toiThieu) || toiThieu < 0)
            {
                MessageBox.Show("Đơn tối thiểu không hợp lệ.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_dontoithieu.Focus();
                return;
            }

            if (!int.TryParse(txt_soluong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượt sử dụng phải lớn hơn 0.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soluong.Focus();
                return;
            }

            if (txt_loai.SelectedItem.ToString() == "PhanTram" && giaTri > 100)
            {
                MessageBox.Show("Voucher phần trăm không được vượt quá 100%.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dt_ketthuc.Value.Date < dt_ngaybatdau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải >= ngày bắt đầu.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable check = kt.GetData(
                    "SELECT 1 FROM Voucher WHERE MaCode=@MaCode",
                    new SqlParameter[] { new SqlParameter("@MaCode", ma) });

                if (check.Rows.Count > 0)
                {
                    MessageBox.Show("Mã voucher đã tồn tại.", "Trùng mã",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                kt.Execute(@"
                    INSERT INTO Voucher
                    (MaCode, TenChuongTrinh, GiaTri, LoaiGiam,
                     GiaTriDonToiThieu, SoLuongToiDa, DaSuDung,
                     NgayBatDau, NgayHetHan, TrangThai)
                    VALUES
                    (@MaCode,@Ten,@GiaTri,@Loai,@ToiThieu,@SoLuong,0,
                     @BatDau,@KetThuc,1)",
                    new SqlParameter[]
                    {
                        new SqlParameter("@MaCode", ma),
                        new SqlParameter("@Ten", ten),
                        new SqlParameter("@GiaTri", giaTri),
                        new SqlParameter("@Loai", txt_loai.SelectedItem.ToString()),
                        new SqlParameter("@ToiThieu", toiThieu),
                        new SqlParameter("@SoLuong", soLuong),
                        new SqlParameter("@BatDau", dt_ngaybatdau.Value.Date),
                        new SqlParameter("@KetThuc", dt_ketthuc.Value.Date)
                    });

                MessageBox.Show("Đã tạo voucher " + ma + ".",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo voucher.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
