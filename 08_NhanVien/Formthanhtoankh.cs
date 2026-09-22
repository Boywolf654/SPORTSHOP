using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPORTSHOP._06_BanHang
{
    public partial class FormThanhToanKH : Form
    {
        // =========================================================
        // MÀU CHỦ ĐẠO (đồng bộ với giao diện bán hàng)
        // =========================================================
        private readonly Color MauDo = Color.FromArgb(220, 30, 45);
        private readonly Color MauNut = Color.FromArgb(38, 38, 41);
        private readonly Color MauNutChon = Color.FromArgb(220, 30, 45);
        private readonly Color MauChuMo = Color.FromArgb(190, 192, 198);
        private readonly Color MauTrang = Color.White;

        // =========================================================
        // DỮ LIỆU RA / VÀO
        // =========================================================

        /// <summary>Tổng tiền của hóa đơn cần thanh toán.</summary>
        public decimal TongTien { get; private set; }

        /// <summary>Số tiền khách đưa (chỉ có ý nghĩa với tiền mặt).</summary>
        public decimal SoTienKhachDua { get; private set; }

        /// <summary>Tiền thối lại cho khách.</summary>
        public decimal TienThoiLai { get; private set; }

        /// <summary>"Tiền mặt" / "Chuyển khoản" / "Thẻ".</summary>
        public string PhuongThucThanhToan { get; private set; }

        /// <summary>Kênh cụ thể: MoMo, ZaloPay, Thẻ Visa vật lý...</summary>
        public string ChiTietPhuongThuc { get; private set; }

        /// <summary>True khi khách đã xác nhận thanh toán thành công.</summary>
        public bool DaThanhToan { get; private set; }

        // =========================================================
        // TRẠNG THÁI NỘI BỘ
        // =========================================================

        private enum LoaiThanhToan
        {
            TienMat,
            ChuyenKhoan,
            The
        }

        private LoaiThanhToan loaiDangChon = LoaiThanhToan.TienMat;

        private decimal tienKhachDua = 0;

        private string kenhChuyenKhoan = "";
        private string loaiThe = "";

        private string maHoaDon = "";

        // Nút "Nhận đủ tiền" được tạo động cùng bàn phím số
        private Guna.UI2.WinForms.Guna2Button btnNhanDuTien;

        // =========================================================
        // KHỞI TẠO
        // =========================================================

        public FormThanhToanKH(decimal tongTien)
            : this(tongTien, "")
        {
        }

        public FormThanhToanKH(decimal tongTien, string maHD)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            TongTien = tongTien < 0 ? 0 : tongTien;
            maHoaDon = maHD ?? "";

            PhuongThucThanhToan = "Tiền mặt";
            ChiTietPhuongThuc = "Tiền mặt";
            DaThanhToan = false;

            btnTienMat.Click += (s, e) => ChonLoai(LoaiThanhToan.TienMat);
            btnChuyenKhoan.Click += (s, e) => ChonLoai(LoaiThanhToan.ChuyenKhoan);
            btnThe.Click += (s, e) => ChonLoai(LoaiThanhToan.The);

            btnNganHang.Click += (s, e) => ChonKenhChuyenKhoan("Ngân hàng");
            btnMoMo.Click += (s, e) => ChonKenhChuyenKhoan("MoMo");
            btnZaloPay.Click += (s, e) => ChonKenhChuyenKhoan("ZaloPay");

            btnTheVisa.Click += (s, e) => ChonLoaiThe("Thẻ Visa vật lý");
            btnTheDienTu.Click += (s, e) => ChonLoaiThe("Thẻ điện tử");

            btnThanhToan.Click += btnThanhToan_Click;
            btnHuy.Click += btnHuy_Click;
        }

        private void FormThanhToanKH_Load(object sender, EventArgs e)
        {
            lbMaHoaDon.Text =
                string.IsNullOrWhiteSpace(maHoaDon)
                    ? "Hóa đơn mới"
                    : "Hóa đơn: " + maHoaDon;

            TaoNutMenhGia();
            TaoBanPhimSo();

            ChonLoai(LoaiThanhToan.TienMat);

            CapNhatTomTat();
        }

        // =========================================================
        // TẠO NÚT MỆNH GIÁ (CỘNG DỒN)
        // =========================================================

        private void TaoNutMenhGia()
        {
            int[] menhGia =
            {
                1000, 2000, 5000,
                10000, 20000, 50000,
                100000, 200000, 500000
            };

            int x0 = 20;
            int y0 = 114;
            int w = 193;
            int h = 50;
            int gapX = 10;
            int gapY = 10;

            for (int i = 0; i < menhGia.Length; i++)
            {
                int cot = i % 3;
                int dong = i / 3;

                Guna.UI2.WinForms.Guna2Button nut =
                    TaoNut(
                        DocMenhGiaNgan(menhGia[i]),
                        new Point(x0 + cot * (w + gapX),
                                  y0 + dong * (h + gapY)),
                        new Size(w, h),
                        12F);

                int giaTri = menhGia[i];

                nut.Click += (s, e) =>
                {
                    tienKhachDua += giaTri;
                    CapNhatTomTat();
                };

                pnlTienMat.Controls.Add(nut);
            }
        }

        private string DocMenhGiaNgan(int giaTri)
        {
            return (giaTri / 1000).ToString("N0") + "K";
        }

        // =========================================================
        // TẠO BÀN PHÍM SỐ
        // =========================================================

        private void TaoBanPhimSo()
        {
            int x0 = 20;
            int y0 = 316;
            int w = 142;
            int h = 46;
            int gapX = 10;
            int gapY = 8;

            // Ba hàng chữ số 1..9
            string[] phim =
            {
                "1", "2", "3",
                "4", "5", "6",
                "7", "8", "9"
            };

            for (int i = 0; i < phim.Length; i++)
            {
                int cot = i % 3;
                int dong = i / 3;

                Guna.UI2.WinForms.Guna2Button nut =
                    TaoNut(
                        phim[i],
                        new Point(x0 + cot * (w + gapX),
                                  y0 + dong * (h + gapY)),
                        new Size(w, h),
                        13F);

                string so = phim[i];

                nut.Click += (s, e) =>
                {
                    NhapChuSo(so);
                };

                pnlTienMat.Controls.Add(nut);
            }

            // Cột 4: Xóa lùi / Xóa hết / 000
            Guna.UI2.WinForms.Guna2Button nutXoaLui =
                TaoNut(
                    "⌫",
                    new Point(x0 + 3 * (w + gapX), y0),
                    new Size(w, h),
                    13F);

            nutXoaLui.Click += (s, e) =>
            {
                tienKhachDua = Math.Floor(tienKhachDua / 10);
                CapNhatTomTat();
            };

            pnlTienMat.Controls.Add(nutXoaLui);

            Guna.UI2.WinForms.Guna2Button nutXoaHet =
                TaoNut(
                    "C",
                    new Point(x0 + 3 * (w + gapX), y0 + (h + gapY)),
                    new Size(w, h),
                    13F);

            nutXoaHet.FillColor = Color.FromArgb(58, 38, 41);
            nutXoaHet.ForeColor = Color.FromArgb(255, 120, 130);

            nutXoaHet.Click += (s, e) =>
            {
                tienKhachDua = 0;
                CapNhatTomTat();
            };

            pnlTienMat.Controls.Add(nutXoaHet);

            Guna.UI2.WinForms.Guna2Button nutBaSo =
                TaoNut(
                    "000",
                    new Point(x0 + 3 * (w + gapX), y0 + 2 * (h + gapY)),
                    new Size(w, h),
                    13F);

            nutBaSo.Click += (s, e) => NhapChuSo("000");

            pnlTienMat.Controls.Add(nutBaSo);

            // Hàng cuối: 0 - 00 - NHẬN ĐỦ TIỀN
            int yCuoi = y0 + 3 * (h + gapY);

            Guna.UI2.WinForms.Guna2Button nutKhong =
                TaoNut(
                    "0",
                    new Point(x0, yCuoi),
                    new Size(w, h),
                    13F);

            nutKhong.Click += (s, e) => NhapChuSo("0");

            pnlTienMat.Controls.Add(nutKhong);

            Guna.UI2.WinForms.Guna2Button nutHaiSo =
                TaoNut(
                    "00",
                    new Point(x0 + (w + gapX), yCuoi),
                    new Size(w, h),
                    13F);

            nutHaiSo.Click += (s, e) => NhapChuSo("00");

            pnlTienMat.Controls.Add(nutHaiSo);

            btnNhanDuTien =
                TaoNut(
                    "NHẬN ĐỦ TIỀN",
                    new Point(x0 + 2 * (w + gapX), yCuoi),
                    new Size(w * 2 + gapX, h),
                    12F);

            btnNhanDuTien.FillColor = Color.FromArgb(16, 185, 129);
            btnNhanDuTien.ForeColor = MauTrang;
            btnNhanDuTien.HoverState.FillColor = Color.FromArgb(5, 150, 105);

            btnNhanDuTien.Click += (s, e) =>
            {
                tienKhachDua = TongTien;
                CapNhatTomTat();
            };

            pnlTienMat.Controls.Add(btnNhanDuTien);
        }

        // Nhập thêm chữ số vào số tiền đang có (giống bàn phím máy tính tiền)
        private void NhapChuSo(string chuSo)
        {
            decimal moi = tienKhachDua;

            for (int i = 0; i < chuSo.Length; i++)
            {
                int so = chuSo[i] - '0';

                moi = moi * 10 + so;

                // Chặn số quá lớn gây tràn hiển thị
                if (moi > 999999999)
                {
                    moi = 999999999;
                    break;
                }
            }

            tienKhachDua = moi;

            CapNhatTomTat();
        }

        // =========================================================
        // TẠO NÚT DÙNG CHUNG
        // =========================================================

        private Guna.UI2.WinForms.Guna2Button TaoNut(
            string chu,
            Point viTri,
            Size kichThuoc,
            float coChu)
        {
            Guna.UI2.WinForms.Guna2Button nut =
                new Guna.UI2.WinForms.Guna2Button();

            nut.Text = chu;
            nut.Location = viTri;
            nut.Size = kichThuoc;

            nut.BorderRadius = 10;
            nut.FillColor = MauNut;
            nut.ForeColor = MauTrang;

            nut.Font = new Font(
                "Segoe UI Semibold",
                coChu);

            nut.HoverState.FillColor =
                Color.FromArgb(56, 56, 60);

            nut.Cursor = Cursors.Hand;

            return nut;
        }

        // =========================================================
        // CHỌN PHƯƠNG THỨC
        // =========================================================

        private void ChonLoai(LoaiThanhToan loai)
        {
            loaiDangChon = loai;

            DatMauNutPhuongThuc(btnTienMat, loai == LoaiThanhToan.TienMat);
            DatMauNutPhuongThuc(btnChuyenKhoan, loai == LoaiThanhToan.ChuyenKhoan);
            DatMauNutPhuongThuc(btnThe, loai == LoaiThanhToan.The);

            pnlTienMat.Visible = loai == LoaiThanhToan.TienMat;
            pnlChuyenKhoan.Visible = loai == LoaiThanhToan.ChuyenKhoan;
            pnlThe.Visible = loai == LoaiThanhToan.The;

            if (pnlTienMat.Visible)
                pnlTienMat.BringToFront();

            if (pnlChuyenKhoan.Visible)
                pnlChuyenKhoan.BringToFront();

            if (pnlThe.Visible)
                pnlThe.BringToFront();

            CapNhatTomTat();
        }

        private void DatMauNutPhuongThuc(
            Guna.UI2.WinForms.Guna2Button nut,
            bool dangChon)
        {
            nut.FillColor = dangChon ? MauNutChon : MauNut;
            nut.ForeColor = dangChon ? MauTrang : MauChuMo;
        }

        private void ChonKenhChuyenKhoan(string kenh)
        {
            kenhChuyenKhoan = kenh;

            DatMauNutKenh(btnNganHang, kenh == "Ngân hàng");
            DatMauNutKenh(btnMoMo, kenh == "MoMo");
            DatMauNutKenh(btnZaloPay, kenh == "ZaloPay");

            CapNhatTomTat();
        }

        private void ChonLoaiThe(string the)
        {
            loaiThe = the;

            DatMauNutKenh(btnTheVisa, the == "Thẻ Visa vật lý");
            DatMauNutKenh(btnTheDienTu, the == "Thẻ điện tử");

            CapNhatTomTat();
        }

        private void DatMauNutKenh(
            Guna.UI2.WinForms.Guna2Button nut,
            bool dangChon)
        {
            nut.FillColor = dangChon ? MauDo : MauNut;
            nut.ForeColor = MauTrang;
        }

        // =========================================================
        // CẬP NHẬT KHUNG TÓM TẮT
        // =========================================================

        private void CapNhatTomTat()
        {
            lbTongTien.Text = DinhDangTien(TongTien);

            lbKhachDua.Text = DinhDangTien(tienKhachDua);

            if (loaiDangChon == LoaiThanhToan.TienMat)
            {
                lbPTValue.Text = "Tiền mặt";

                lbDuaValue.Text = DinhDangTien(tienKhachDua);

                decimal thoi = tienKhachDua - TongTien;

                lbThoiValue.Text =
                    thoi > 0
                        ? DinhDangTien(thoi)
                        : "0 đ";

                if (tienKhachDua < TongTien)
                {
                    decimal thieu = TongTien - tienKhachDua;

                    lbCanhBao.Text =
                        "Còn thiếu " + DinhDangTien(thieu);

                    btnThanhToan.Enabled = false;
                }
                else
                {
                    lbCanhBao.Text = "";
                    btnThanhToan.Enabled = true;
                }
            }
            else if (loaiDangChon == LoaiThanhToan.ChuyenKhoan)
            {
                lbPTValue.Text =
                    string.IsNullOrEmpty(kenhChuyenKhoan)
                        ? "Chuyển khoản"
                        : kenhChuyenKhoan;

                lbDuaValue.Text = DinhDangTien(TongTien);
                lbThoiValue.Text = "0 đ";

                if (string.IsNullOrEmpty(kenhChuyenKhoan))
                {
                    lbCanhBao.Text =
                        "Hãy chọn kênh chuyển khoản.";

                    btnThanhToan.Enabled = false;
                }
                else
                {
                    lbCanhBao.Text = "";
                    btnThanhToan.Enabled = true;
                }
            }
            else
            {
                lbPTValue.Text =
                    string.IsNullOrEmpty(loaiThe)
                        ? "Thẻ"
                        : loaiThe;

                lbDuaValue.Text = DinhDangTien(TongTien);
                lbThoiValue.Text = "0 đ";

                if (string.IsNullOrEmpty(loaiThe))
                {
                    lbCanhBao.Text =
                        "Hãy chọn loại thẻ khách sử dụng.";

                    btnThanhToan.Enabled = false;
                }
                else
                {
                    lbCanhBao.Text = "";
                    btnThanhToan.Enabled = true;
                }
            }
        }

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0") + " đ";
        }

        // =========================================================
        // XÁC NHẬN THANH TOÁN
        // =========================================================

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string moTaPhuongThuc;
            string noiDungXacNhan;

            if (loaiDangChon == LoaiThanhToan.TienMat)
            {
                if (tienKhachDua < TongTien)
                {
                    MessageBox.Show(
                        "Số tiền khách đưa chưa đủ để thanh toán hóa đơn.",
                        "SPORTSHOP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                decimal thoi = tienKhachDua - TongTien;

                moTaPhuongThuc = "Tiền mặt";

                noiDungXacNhan =
                    "Xác nhận thanh toán bằng TIỀN MẶT?\n\n"
                    + "Tổng tiền: " + DinhDangTien(TongTien) + "\n"
                    + "Khách đưa: " + DinhDangTien(tienKhachDua) + "\n"
                    + "Tiền thối lại: " + DinhDangTien(thoi);

                PhuongThucThanhToan = "Tiền mặt";
                ChiTietPhuongThuc = "Tiền mặt";
                SoTienKhachDua = tienKhachDua;
                TienThoiLai = thoi;
            }
            else if (loaiDangChon == LoaiThanhToan.ChuyenKhoan)
            {
                if (string.IsNullOrEmpty(kenhChuyenKhoan))
                    return;

                moTaPhuongThuc = kenhChuyenKhoan;

                noiDungXacNhan =
                    "Xác nhận thanh toán bằng CHUYỂN KHOẢN?\n\n"
                    + "Kênh: " + kenhChuyenKhoan + "\n"
                    + "Số tiền: " + DinhDangTien(TongTien);

                PhuongThucThanhToan = "Chuyển khoản";
                ChiTietPhuongThuc = kenhChuyenKhoan;
                SoTienKhachDua = TongTien;
                TienThoiLai = 0;
            }
            else
            {
                if (string.IsNullOrEmpty(loaiThe))
                    return;

                moTaPhuongThuc = loaiThe;

                noiDungXacNhan =
                    "Xác nhận thanh toán bằng THẺ?\n\n"
                    + "Loại thẻ: " + loaiThe + "\n"
                    + "Số tiền: " + DinhDangTien(TongTien);

                PhuongThucThanhToan = "Thẻ";
                ChiTietPhuongThuc = loaiThe;
                SoTienKhachDua = TongTien;
                TienThoiLai = 0;
            }

            DialogResult xacNhan =
                MessageBox.Show(
                    noiDungXacNhan,
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            DaThanhToan = true;

            MessageBox.Show(
                "Thanh toán thành công!\n\n"
                + "Phương thức: " + moTaPhuongThuc,
                "SPORTSHOP",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DaThanhToan = false;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}