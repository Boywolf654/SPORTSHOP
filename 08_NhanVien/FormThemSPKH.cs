using Guna.UI2.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPORTSHOP
{
    public partial class FormThemSPKH : Form
    {
        // ==============================
        // THÔNG TIN SẢN PHẨM ĐƯỢC CHỌN
        // ==============================

        public int MaBienTheChon { get; private set; }
        public int MaSPChon { get; private set; }
        public string TenSPChon { get; private set; }
        public string SKUChon { get; private set; }
        public string SizeChon { get; private set; }
        public string MauChon { get; private set; }
        public decimal DonGiaChon { get; private set; }
        public int SoLuongChon { get; private set; }
        public int TonKhoChon { get; private set; }


        // ==============================
        // CONSTRUCTOR
        // ==============================

        public FormThemSPKH()
        {
            InitializeComponent();

            this.Load += FormThemSPKH_Load;

            btn_tim.Click += btn_tim_Click;
            btn_them.Click += btn_them_Click;
            btn_huy.Click += btn_huy_Click;
        }


        // ==============================
        // LOAD FORM
        // ==============================

        private void FormThemSPKH_Load(object sender, EventArgs e)
        {
            TaoCotDataGridView();

            LoadSanPham();
        }


        // ==============================
        // TẠO CỘT DATAGRIDVIEW
        // ==============================

        private void TaoCotDataGridView()
        {
            dgv_ThemSP.Columns.Clear();

            dgv_ThemSP.AutoGenerateColumns = false;

            dgv_ThemSP.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv_ThemSP.AllowUserToAddRows = false;

            dgv_ThemSP.ReadOnly = true;

            dgv_ThemSP.MultiSelect = false;

            dgv_ThemSP.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;


            // Mã biến thể
            dgv_ThemSP.Columns.Add(
                "MaBienThe",
                "Mã biến thể");


            // Mã sản phẩm
            dgv_ThemSP.Columns.Add(
                "MaSP",
                "Mã SP");


            // Tên sản phẩm
            dgv_ThemSP.Columns.Add(
                "TenSP",
                "Tên sản phẩm");


            // SKU
            dgv_ThemSP.Columns.Add(
                "SKU",
                "SKU");


            // Size
            dgv_ThemSP.Columns.Add(
                "Size",
                "Size");


            // Màu
            dgv_ThemSP.Columns.Add(
                "Mau",
                "Màu");


            // Giá bán
            dgv_ThemSP.Columns.Add(
                "GiaBan",
                "Giá bán");


            // Tồn kho
            dgv_ThemSP.Columns.Add(
                "TonKho",
                "Tồn kho");


            // Định dạng giá
            dgv_ThemSP.Columns["GiaBan"]
                .DefaultCellStyle.Format = "N0";
        }


        // ==============================
        // LOAD SẢN PHẨM TỪ DATABASE
        // ==============================
        KetNoiDuLieu ketNoi = new KetNoiDuLieu();
        private void LoadSanPham(string tuKhoa = "")
        {
            try
            {
                // DÙNG CLASS KẾT NỐI CÓ SẴN
                using (SqlConnection conn = ketNoi.GetConnection())
                {
                    string sql = @"
                    SELECT
                        bt.MaBienThe,
                        sp.MaSP,
                        sp.TenSP,
                        bt.SKU,
                        sz.TenSize AS Size,
                        ms.TenMau AS Mau,
                        bt.GiaBan,
                        bt.SoLuong AS TonKho
                    FROM BienTheSanPham bt

                    INNER JOIN SanPham sp
                        ON bt.MaSP = sp.MaSP

                    INNER JOIN Size sz
                        ON bt.MaSize = sz.MaSize

                    INNER JOIN MauSac ms
                        ON bt.MaMau = ms.MaMau

                    WHERE
                        bt.TrangThai = 1
                        AND sp.TrangThai = 1

                        AND
                        (
                            @TuKhoa = ''

                            OR CAST(sp.MaSP AS NVARCHAR) LIKE '%' + @TuKhoa + '%'

                            OR sp.TenSP LIKE N'%' + @TuKhoa + N'%'

                            OR bt.SKU LIKE '%' + @TuKhoa + '%'
                        )

                    ORDER BY
                        sp.MaSP,
                        bt.MaBienThe";


                    using (SqlCommand cmd =
                        new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TuKhoa",
                            tuKhoa);


                        conn.Open();


                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            dgv_ThemSP.Rows.Clear();


                            while (reader.Read())
                            {
                                dgv_ThemSP.Rows.Add(
                                    reader["MaBienThe"],
                                    reader["MaSP"],
                                    reader["TenSP"],
                                    reader["SKU"],
                                    reader["Size"],
                                    reader["Mau"],
                                    reader["GiaBan"],
                                    reader["TonKho"]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm!\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ==============================
        // NÚT TÌM KIẾM
        // ==============================

        private void btn_tim_Click(object sender, EventArgs e)
        {
            string tuKhoa =
                txt_TimKiem.Text.Trim();

            LoadSanPham(tuKhoa);
        }


        // ==============================
        // NÚT THÊM
        // ==============================

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Chưa chọn sản phẩm
            if (dgv_ThemSP.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // Kiểm tra số lượng
            if (!int.TryParse(
                    txt_Soluong.Text.Trim(),
                    out int soLuong))
            {
                MessageBox.Show(
                    "Số lượng phải là số nguyên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_Soluong.Focus();

                return;
            }


            // Số lượng <= 0
            if (soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng phải lớn hơn 0!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_Soluong.Focus();

                return;
            }


            // Lấy dòng đang chọn
            DataGridViewRow row =
                dgv_ThemSP.SelectedRows[0];


            // Lấy tồn kho
            int tonKho =
                Convert.ToInt32(
                    row.Cells["TonKho"].Value);


            // Không đủ hàng
            if (soLuong > tonKho)
            {
                MessageBox.Show(
                    "Số lượng tồn kho chỉ còn "
                    + tonKho
                    + " sản phẩm!",
                    "Không đủ hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txt_Soluong.Focus();

                return;
            }


            // ==============================
            // LẤY THÔNG TIN SẢN PHẨM
            // ==============================

            MaBienTheChon =
                Convert.ToInt32(
                    row.Cells["MaBienThe"].Value);


            MaSPChon =
                Convert.ToInt32(
                    row.Cells["MaSP"].Value);


            TenSPChon =
                row.Cells["TenSP"].Value
                ?.ToString();


            SKUChon =
                row.Cells["SKU"].Value
                ?.ToString();


            SizeChon =
                row.Cells["Size"].Value
                ?.ToString();


            MauChon =
                row.Cells["Mau"].Value
                ?.ToString();


            DonGiaChon =
                Convert.ToDecimal(
                    row.Cells["GiaBan"].Value);


            SoLuongChon =
                soLuong;


            TonKhoChon =
                tonKho;


            // ==============================
            // TRẢ KẾT QUẢ VỀ FORM HÓA ĐƠN
            // ==============================

            DialogResult =
                DialogResult.OK;

            Close();
        }


        // ==============================
        // NÚT HỦY
        // ==============================

        private void btn_huy_Click(object sender, EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }
    }
}