using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class coupon : Form
    {
        private readonly KetNoiDuLieu kt = new KetNoiDuLieu();
        private decimal tongTienDonHang = 0m;

        public int MaVoucherDuocChon { get; private set; }
        public decimal SoTienGiam { get; private set; }
        public string MaCodeDuocChon { get; private set; }

        public coupon() : this(0m) { }

        public coupon(decimal tongTien)
        {
            tongTienDonHang = tongTien;
            InitializeComponent();
            CauHinhGiaoDien();
            LoadVoucher();
            button1.Click += button1_Click;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            Shown += (s, e) => comboBox1.Focus();
        }

        private void CauHinhGiaoDien()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Text = "Chọn mã giảm giá";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            txt_giam.ReadOnly = true;
            txt_dontoithieu.ReadOnly = true;
            button1.DialogResult = DialogResult.None;
        }

        private void LoadVoucher()
        {
            try
            {
                string sql = @"
                    SELECT MaVoucher, MaCode, GiaTri, LoaiGiam,
                           GiaTriDonToiThieu, SoLuongToiDa, DaSuDung,
                           NgayBatDau, NgayHetHan
                    FROM Voucher
                    WHERE TrangThai = 1
                      AND DaSuDung < SoLuongToiDa
                      AND NgayBatDau <= CAST(GETDATE() AS DATE)
                      AND (NgayHetHan IS NULL OR NgayHetHan >= CAST(GETDATE() AS DATE))
                    ORDER BY MaVoucher DESC";

                DataTable dt = kt.GetData(sql, null);
                comboBox1.Items.Clear();
                comboBox1.Items.Add(new VoucherItem { MaVoucher = 0, MaCode = "-- Không dùng voucher --" });

                foreach (DataRow r in dt.Rows)
                {
                    comboBox1.Items.Add(new VoucherItem
                    {
                        MaVoucher = Convert.ToInt32(r["MaVoucher"]),
                        MaCode = r["MaCode"].ToString(),
                        GiaTri = Convert.ToDecimal(r["GiaTri"]),
                        LoaiGiam = r["LoaiGiam"].ToString(),
                        ToiThieu = Convert.ToDecimal(r["GiaTriDonToiThieu"]),
                        ConLai = Convert.ToInt32(r["SoLuongToiDa"]) - Convert.ToInt32(r["DaSuDung"])
                    });
                }

                comboBox1.SelectedIndex = 0;
                if (dt.Rows.Count == 0)
                {
                    txt_giam.Text = "Không có voucher đang hoạt động";
                    txt_dontoithieu.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải mã giảm giá.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VoucherItem v = comboBox1.SelectedItem as VoucherItem;
            if (v == null || v.MaVoucher == 0)
            {
                txt_giam.Text = "Không áp dụng giảm giá";
                txt_dontoithieu.Text = tongTienDonHang > 0 ? "Tổng đơn: " + tongTienDonHang.ToString("N0") + " đ" : "";
                return;
            }

            txt_giam.Text = v.LoaiGiam.Equals("PhanTram", StringComparison.OrdinalIgnoreCase)
                ? "Giảm " + v.GiaTri.ToString("0.##") + "%"
                : "Giảm " + v.GiaTri.ToString("N0") + " đ";
            txt_dontoithieu.Text = "Đơn tối thiểu " + v.ToiThieu.ToString("N0") + " đ  •  Còn " + v.ConLai + " lượt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VoucherItem v = comboBox1.SelectedItem as VoucherItem;
            if (v == null || v.MaVoucher == 0)
            {
                MaVoucherDuocChon = 0;
                SoTienGiam = 0;
                MaCodeDuocChon = null;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (tongTienDonHang > 0 && tongTienDonHang < v.ToiThieu)
            {
                MessageBox.Show("Đơn hàng chưa đạt giá trị tối thiểu " + v.ToiThieu.ToString("N0") + " đ.",
                    "Voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính lại từ dữ liệu DB để tránh áp dụng sai nếu voucher vừa thay đổi.
            try
            {
                string sql = @"
                    SELECT MaVoucher, MaCode, GiaTri, LoaiGiam, GiaTriDonToiThieu,
                           SoLuongToiDa, DaSuDung
                    FROM Voucher
                    WHERE MaVoucher = @MaVoucher
                      AND TrangThai = 1
                      AND DaSuDung < SoLuongToiDa
                      AND NgayBatDau <= CAST(GETDATE() AS DATE)
                      AND (NgayHetHan IS NULL OR NgayHetHan >= CAST(GETDATE() AS DATE))";
                SqlParameter[] p = { new SqlParameter("@MaVoucher", v.MaVoucher) };
                DataTable dt = kt.GetData(sql, p);
                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Voucher không còn hợp lệ hoặc đã hết lượt sử dụng.", "Voucher",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadVoucher();
                    return;
                }

                DataRow r = dt.Rows[0];
                decimal giaTri = Convert.ToDecimal(r["GiaTri"]);
                decimal toiThieu = Convert.ToDecimal(r["GiaTriDonToiThieu"]);
                string loai = r["LoaiGiam"].ToString();
                if (tongTienDonHang > 0 && tongTienDonHang < toiThieu)
                {
                    MessageBox.Show("Đơn hàng chưa đạt tối thiểu " + toiThieu.ToString("N0") + " đ.", "Voucher",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal giam = loai.Equals("PhanTram", StringComparison.OrdinalIgnoreCase)
                    ? tongTienDonHang * giaTri / 100m
                    : giaTri;
                if (giam > tongTienDonHang && tongTienDonHang > 0) giam = tongTienDonHang;

                MaVoucherDuocChon = Convert.ToInt32(r["MaVoucher"]);
                MaCodeDuocChon = r["MaCode"].ToString();
                SoTienGiam = Math.Max(0m, giam);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể áp dụng voucher.\n\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private sealed class VoucherItem
        {
            public int MaVoucher;
            public string MaCode;
            public decimal GiaTri;
            public string LoaiGiam;
            public decimal ToiThieu;
            public int ConLai;
            public override string ToString() { return MaCode; }
        }
    }
}
