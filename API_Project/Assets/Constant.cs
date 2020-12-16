using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Assets
{
    public class Constant
    {

        /*------------------------------------------- Regex mẫu ---------------------------------------*/

        #region Regex

        public const string REGEX_FORMAT_ONLYNUMBER = "[0-9]+";

        #endregion

        #region STATUS CODE SEND BROKER

        public const int SUCCESSCODE = 200;
        public const int FAILCODE = 404;

        #endregion

        /*---------------------------------------------------------------------------------------------------------------*/

        /*------------------------------------------- MÃ LỖI - FOLDER UPLOAD FILE ---------------------------------------*/

        #region MÃ LỖI

        public const string ERRORCODE = "101";                                              //lỗi token
        public const string ERRORDATA = "106";                                              //lỗi Data
        public const string ERRORCODETIME = "102";                                          //lỗi về time
        public const string ERRORCODE_SQL = "103";                                          //lỗi sql
        public const string ERRORCODE_FORM = "104";                                         //lỗi về dữ liệu khi post thiếu dl
        public const string ERRORCODE_ROLE = "105";                                         //lỗi về quyền truy cập chức năng
        public const string ERRORCODE_EXCEPTION = "0000";                                   //EXCEPTION

        #endregion

        #region MESSAGE LỖI
        public const string message_error_status_fail = "Trạng thái phiếu đã thay đổi, vui lòng tải lại";
        #endregion

        #region UPLOAD FILE FOLDER
        public const string ROOT_UPLOAD_FOLDER = "dulieu";
        public const string IMAGES_UPLOAD_FOLDER = "dulieu/images";
        public const string TEMPLATE_IMPORT_FOLDER = "dulieu/Template";
        public const string USER_DATA_UPLOAD_FOLDER = "dulieu/DataUser";
        public const string FileAttachmentChecklistNCC_UpLoad_Folder = "dulieu/Data/ChecklistNCC/";
        public const string FileAttachmentKhieuNaiKH_UpLoad_Folder = "dulieu/Data/KhieuNaiKH/";
        public const string FileImport_NCC = "dulieu/Template/FileImportNCC/";


        #endregion

        /*---------------------------------------------------------------------------------------------------------------*/


        /*--------------------------------------------- TRẠNG THÁI CÁC PHÂN HỆ ------------------------------------------*/

        #region TRẠNG THÁI FORM DANH MỤC

        #region TRẠNG THÁI CẤU HÌNH HẠN MỨC
        public const string CHHM_MacDinh = "CHHM_MacDinh";
        public const string CHHM_CongDon = "CHHM_CongDon";
        #endregion

        #region TRẠNG THÁI THIẾT BỊ VÀ TÀI SẢN PHÂN BỔ
        public const string TBTS_DANGSUDUNG = "TBTS_DANGSUDUNG";
        public const string TBTS_DAXOA = "TBTS_DAXOA";

        #endregion


        #region TRẠNG THÁI CHỈ TIÊU ĐÁNH GIÁ NCC
        public const string CATEGORY_CTDGNCC = "CTDGNCC";


        #endregion

        #region DM DỊCH VỤ
        public const long IDLoaiDV = 19;
        #endregion

        #endregion

        #region PHÂN HỆ MUA HÀNG

            #region HINH THUC THANH TOÁN
        public const string CATEGORY_HTTT = "HINHTHUCTHANHTOAN";
            public const string HD_HOANTAT_CODE = "HD_HOANTAT";
            #endregion  HINH THUC THANH TOÁN

            #region ĐỀ NGHỊ MUA HÀNG

                #region TRẠNG THÁI PHIẾU ĐỀ NGHỊ MUA HÀNG

                public const string Config_PBMacDinh = "Config_PBMacDinh";

                public const string CATEGORY_DENGHI = "PDNMH";
                public const string PDNMH_DUYETCT_CODE = "PDNMH_DUYETCT";
                public const string PDNMH_KHONGDUYETCT_CODE = "PDNMH_KHONGDUYETCT";

                public const string CATEGORY_DENGHIMUAHANG = "PDNMH";

                public const string PDNMH_PHIEUMOI = "PDNMH_PHIEUMOI";
                public const string PDNMH_DANGTHUCHIEN = "PDNMH_DANGTHUCHIEN";
                public const string PDNMH_CHODUYET = "PDNMH_CHODUYET";
                public const string PDNMH_KHONGDUYET = "PDNMH_KHONGDUYET";
                public const string PDNMH_HOANTAT = "PDNMH_HOANTAT";
                public const string PDNMH_DAHUY = "PDNMH_DAHUY";
                public const string PDNMH_DAXOA = "PDNMH_DAXOA";

                public const string PDNMH_PHIEUMOI_DESCRIPTION = "Đang soạn thảo";
                public const string PDNMH_DANGTHUCHIEN_DESCRIPTION = "Đang thực hiện";
                public const string PDNMH_CHODUYET_DESCRIPTION = "Chờ duyệt";
                public const string PDNMH_KHONGDUYET_DESCRIPTION = "Không duyệt";
                public const string PDNMH_HOANTAT_DESCRIPTION = "Hoàn tất";
                public const string PDNMH_DAHUY_DESCRIPTION = "Đã hủy";
                public const string PDNMH_DAXOA_DESCRIPTION = "Đã xóa";

                #endregion

                #region TRẠNG THÁI CHI TIẾT PHIẾU ĐỀ NGHỊ MUA HÀNG

                public const string CATEGORY_DENGHIMUAHANG_DETAIL = "PDNMH_DETAIL";
                public const string DENGHIMUAHANGSX = "DENGHIMUAHANGSX";

                public const string PDNMH_DETAIL_CHOTPDUYETMUA = "PDNMH_DETAIL_CHOTPDUYETMUA";
                public const string PDNMH_DETAIL_CHOGDKDUYETGIA = "PDNMH_DETAIL_CHOGDKDUYETGIA";
                public const string PDNMH_DETAIL_CHOGDDUYET = "PDNMH_DETAIL_CHOGDDUYET";
                public const string PDNMH_DETAIL_CHODONGDENGHI = "PDNMH_DETAIL_CHODONGDENGHI";
                public const string PDNMH_DETAIL_HOANTAT = "PDNMH_DETAIL_HOANTAT";
                public const string PDNMH_DETAIL_KHONGDUYET = "PDNMH_DETAIL_KHONGDUYET";

                public const string PDNMH_DETAIL_CHOTPDUYETMUA_DESCRIPTION = "Chờ TP duyệt mua";
                public const string PDNMH_DETAIL_CHOGDKDUYETGIA_DESCRIPTION = "Chờ GĐK duyệt giá";
                public const string PDNMH_DETAIL_CHOGDDUYET_DESCRIPTION = "Chờ GĐ duyệt";
                public const string PDNMH_DETAIL_CHODONGDENGHI_DESCRIPTION = "Chờ đóng đề nghị";
                public const string PDNMH_DETAIL_HOANTAT_DESCRIPTION = "Hoàn tất";
                public const string PDNMH_DETAIL_KHONGDUYET_DESCRIPTION = "Không duyệt";

                #endregion

                #region LOẠI PHIẾU ĐỀ NGHỊ MUA HÀNG

                    public const string NHUCAUPHATSINH = "NHUCAUPHATSINH";
                    public const string NHUCAUKEHOACH = "NHUCAUKEHOACH";

                    public const string NHUCAUPHATSINH_DES = "Nhu cầu phát sinh";
                    public const string NHUCAUKEHOACH_DES = "Nhu cầu kế hoạch";

                #endregion

            #endregion

            #region TRẠNG THÁI PHIẾU MUA HÀNG

            public const string CATEGORY_DDH = "TM_DHM";

            public const string DHM_DANGSOANTHAO = "DHM_DANGSOANTHAO";
            public const string DHM_CHOTPDUYET = "DHM_CHOTPDUYET";
            public const string DHM_CHOGDKDUYET = "DHM_CHOGDKDUYET";
            public const string DHM_CHOGDDUYET = "DHM_CHOGDDUYET";
            public const string DHM_CHODONGPO = "DHM_CHODONGPO";
            public const string DHM_HOANTAT = "DHM_HOANTAT";
            public const string DHM_KHONGDUYET = "DHM_KHONGDUYET";
            public const string DHM_DAHUY = "DHM_DAHUY";
            public const string DHM_DAXOA = "DHM_DAXOA";

            public const string DHM_DANGTHUCHIEN = "DHM_DANGTHUCHIEN";

            #endregion

            #region TRẠNG THÁI GIÁ MUA NHÀ CUNG CẤP
            public const string GMNCC_DaXoa = "GMNCC_DaXoa";
            public const string GMNCC_ConSuDung = "GMNCC_ConSuDung";
            public const string GMNCC_DaHuy = "GMNCC_DaHuy";
            public const string GMNCC_KhongSuDung = "GMNCC_KhongSuDung";
            #endregion

            #region TRẠNG THÁI ĐÁNH GIÁ CHỌN NCC
            public const string CATEGORY_DGCNCC = "DGCNCC";

            public const string DGCNCC_DangSoanThao = "DGCNCC_DangSoanThao";
            public const string DGCNCC_ChoDuyet = "DGCNCC_ChoDuyet";
            public const string DGCNCC_KhongDuyet = "DGCNCC_KhongDuyet";
            public const string DGCNCC_HoanTat = "DGCNCC_HoanTat";
            public const string DGCNCC_DaHuy = "DGCNCC_DaHuy";
            public const string DGCNCC_DaXoa = "DGCNCC_DaXoa";

            public const string DGCNCC_DangSoanThao_DESCRIPTION = "Đang soạn thảo";
            public const string DGCNCC_ChoDuyet_DESCRIPTION = "Chờ duyệt";
            public const string DGCNCC_KhongDuyet_DESCRIPTION = "Không duyệt";
            public const string DGCNCC_HoanTat_DESCRIPTION = "Hoàn tất";
            public const string DGCNCC_DaHuy_DESCRIPTION = "Đã hủy";
            public const string DGCNCC_DaXoa_DESCRIPTION = "Đã xóa";
            #endregion

            #region TRẠNG THÁI ĐÁNH GIÁ NCC
            public const string CATEGORY_DGNCC = "DGNCC";

            public const string DGNCC_DangSoanThao = "DGNCC_DangSoanThao";
            public const string DGNCC_ChoDuyet = "DGNCC_ChoDuyet";
            public const string DGNCC_KhongDuyet = "DGNCC_KhongDuyet";
            public const string DGNCC_HoanTat = "DGNCC_HoanTat";
            public const string DGNCC_DaHuy = "DGNCC_DaHuy";
            public const string DGNCC_DaXoa = "DGNCC_DaXoa";

            public const string DGNCC_DangSoanThao_DESCRIPTION = "Đang soạn thảo";
            public const string DGNCC_ChoDuyet_DESCRIPTION = "Chờ xác nhận";
            public const string DGNCC_KhongDuyet_DESCRIPTION = "Từ chối";
            public const string DGNCC_HoanTat_DESCRIPTION = "Hoàn tất";
            public const string DGNCC_DaHuy_DESCRIPTION = "Đã hủy";
            public const string DGNCC_DaXoa_DESCRIPTION = "Đã xóa";
            #endregion

            #region TRẠNG THÁI HẠN MỨC PHÒNG BAN
            public const int LOAITHAMCHIEU_DNMH = 0;
            public const int LOAITHAMCHIEU_DHM = 1;

            #endregion

            #region TRẠNG THÁI YÊU CẦU ĐÁNH GIÁ NCC
            public const string CATEGORY_YCDGNCC = "YCDGNCC";

            public const string YCDGNCC_DANGSOANTHAO = "YCDGNCC_DANGSOANTHAO";
            public const string YCDGNCC_CHODUYET = "YCDGNCC_CHODUYET";
            public const string YCDGNCC_KHONGDUYET = "YCDGNCC_KHONGDUYET";
            public const string YCDGNCC_DANGTHUCHIEN = "YCDGNCC_DANGTHUCHIEN";
            public const string YCDGNCC_DAHUY = "YCDGNCC_DAHUY";
            public const string YCDGNCC_HOANTAT = "YCDGNCC_HOANTAT";


            public const int YCDGNCC_LOAIPHIEU = 37;
            public const int YCDGNCC_QUYTRINH = 53;



            public const short LOAIDG_NCCCU = 0;
            public const short LOAIDG_NCCMOI = 1;

            public const string LOAIDG_NCCCU_DESCRIPTION = "Nhà cung cấp cũ";
            public const string LOAIDG_NCCMOI_DESCRIPTION = "Nhà cung cấp mới";


            public const short DOTDG_DK = 0;
            public const short DOTDG_DGCNCC = 1;

            public const string DOTDG_DK_DESCRIPTION = "Định kỳ";
            public const string DOTDG_DGCNCC_DESCRIPTION = "Đánh giá chọn nhà cung cấp";


            #region Nofify for yêu cầu đánh giá

            public const string Header_Description_YCDGNCC = "Yêu cầu đánh giá nhà cung cấp";
            public const string NofMessage_DangChoDuyet_YCDGNCC = "NofMessage_DangChoDuyet_YCDGNCC";
            public const string NofMessage_DangChoChecklist_YCDGNCC = "NofMessage_DangChoChecklist_YCDGNCC";
            public const string NofMessage_DangChoVisitSupllier_YCDGNCC = "NofMessage_DangChoVisitSupllier_YCDGNCC";
            public const string NofMessage_KhongDuyet_YCDGNCC = "NofMessage_KhongDuyet_YCDGNCC";
            #endregion

            #endregion

            #region TRẠNG THÁI VISIT SUPPLIER
            public const string CATEGORY_VISITSUPPLIER = "VISITSUPPLIER";
            public const string PREFIX_VISITSUPPLIER = "VS";

            public const string VISITSUPPLIER_DANGSOANTHAO = "VISITSUPPLIER_DANGSOANTHAO";
            public const string VISITSUPPLIER_DAHUY = "VISITSUPPLIER_DAHUY";
            public const string VISITSUPPLIER_HOANTAT = "VISITSUPPLIER_HOANTAT";




            #region Nofify for visit supplier


            public const int VisitSupplier_LOAIPHIEU = 45;
            public const int VisitSupplier_QUYTRINH = 79;

            public const string Header_Description_VisitSupplier = "Phiếu Visit Supplier";
            public const string NofMessage_HOANTAT_VISITSUPPLIER = "NofMessage_HOANTAT_VISITSUPPLIER";

            #endregion

            #endregion

            #region HẠN MỨC DUYỆT MUA HÀNG
            public const string DNHMDM_DangSoanThao = "DNHMDM_DangSoanThao";
            public const string DNHMDM_ChoDuyet = "DNHMDM_ChoDuyet";
            public const string DNHMDM_DaHuy = "DNHMDM_DaHuy";
            public const string DNHMDM_KhongDuyet = "DNHMDM_KhongDuyet";
            public const string DNHMDM_HoanTat = "DNHMDM_HoanTat";
            public const string DNHMDM_DaXoa = "DNHMDM_DaXoa";

            public const string DNHMDM_DangHieuLuc = "DNHMDM_DangHieuLuc";
            public const string DNHMDM_ChuaHieuLuc = "DNHMDM_ChuaHieuLuc";
            public const string DNHMDM_HetHieuLuc = "DNHMDM_HetHieuLuc";
            #endregion

            #region HẠN MỨC PHÒNG BAN 
            public const string CATEGORY_HMPB = "HMPB";

            public const string HMPB_DangSoanThao = "HMPB_DangSoanThao";
            public const string HMPB_ChoDuyet = "HMPB_ChoDuyet";
            public const string HMPB_DaHuy = "HMPB_DaHuy";
            public const string HMPB_KhongDuyet = "HMPB_KhongDuyet";
            public const string HMPB_HoanTat = "HMPB_HoanTat";
            public const string HMPB_DaXoa = "HMPB_DaXoa";

            public const string HMPB_DangHieuLuc = "HMPB_DangHieuLuc";
            public const string HMPB_ChuaHieuLuc = "HMPB_ChuaHieuLuc";
            public const string HMPB_HetHieuLuc = "HMPB_HetHieuLuc";
            #endregion

            #region TRẠNG THÁI CHECKLIST NCC
            public const string CATEGORY_CHECKLISTNCC = "CHECKLISTNCC";
            public const string PREFIX_CHECKLISTNCC = "CKL";

            public const string CHECKLISTNCC_DANGSOANTHAO = "CHECKLISTNCC_DANGSOANTHAO";
            public const string CHECKLISTNCC_DAHUY = "CHECKLISTNCC_DAHUY";
            public const string CHECKLISTNCC_HOANTAT = "CHECKLISTNCC_HOANTAT";




            #region Nofify for CHECKLIST NCC


            public const int CHECKLISTNCC_LOAIPHIEU = 49;
            public const int CHECKLISTNCC_QUYTRINH = 65;

            public const string Header_Description_CHECKLISTNCC = "Phiếu Checklist đánh giá nhà cung cấp";


            #endregion

            #endregion

        #endregion

        #region PHÂN HỆ KHO

        #region THÔNG TIN HÀNG VỀ

        #region TRẠNG THÁI LẬP PHIẾU THÔNG TIN HÀNG VỀ

        public const string CATEGORY_TTHANGVE = "PTTHV";

        public const string PTTHV_PHIEUMOI = "PTTHV_PHIEUMOI";
        public const string PTTHV_CHOKQKT = "PTTHV_CHOKQKT";
        public const string PTTHV_CHODUYET = "PTTHV_CHODUYET";
        public const string PTTHV_KHONGDUYET = "PTTHV_KHONGDUYET";
        public const string PTTHV_HOANTAT = "PTTHV_HOANTAT";
        public const string PTTHV_DAHUY = "PTTHV_DAHUY";
        public const string PTTHV_DAXOA = "PTTHV_DAXOA";
        public const string PTTHV_CHOKIEMTRA = "PTTHV_CHOKIEMTRA";
        public const string PTTHV_TRAHANG = "PTTHV_TRAHANG";

        public const string PTTHV_PHIEUMOI_DESCRIPTION = "Đang soạn thảo";
        public const string PTTHV_CHOKQKT_DESCRIPTION = "Đang thực hiện";
        public const string PTTHV_CHODUYET_DESCRIPTION = "Chờ duyệt";
        public const string PTTHV_KHONGDUYET_DESCRIPTION = "Không duyệt";
        public const string PTTHV_HOANTAT_DESCRIPTION = "Hoàn tất";
        public const string PTTHV_DAHUY_DESCRIPTION = "Đã hủy";
        public const string PTTHV_DAXOA_DESCRIPTION = "Đã xóa";
        public const string PTTHV_CHOKIEMTRA_DESCRIPTION = "Chờ kiểm tra";
        public const string PTTHV_TRAHANG_DESCRIPTION = "Trả hàng";

        #endregion

        #region TRẠNG THÁI CHI TIẾT PHIẾU THÔNG TIN HÀNG VỀ

        public const string CATEGORY_TTHANGVE_DETAIL = "PTTHV_DETAIL";

        public const string PTTHV_DETAIL_CHOXULY = "PTTHV_DETAIL_CHOXULY";
        public const string PTTHV_DETAIL_KODUYETKQ = "PTTHV_DETAIL_KODUYETKQ";
        public const string PTTHV_DETAIL_CHOTPDUYET = "PTTHV_DETAIL_CHOTPDUYET";
        public const string PTTHV_DETAIL_CHOGDDUYET = "PTTHV_DETAIL_CHOGDDUYET";
        public const string PTTHV_DETAIL_DADUYETKQ = "PTTHV_DETAIL_DADUYETKQ";
        public const string PTTHV_DETAIL_HUY = "PTTHV_DETAIL_HUY";
        public const string PTTHV_DETAIL_CHOXACNHAN = "PTTHV_DETAIL_CHOXACNHAN";

        public const string PTTHV_DETAIL_CHOXULY_DESCRIPTION = "Chờ kiểm tra";
        public const string PTTHV_DETAIL_KODUYETKQ_DESCRIPTION = "Không cần duyệt KQ";
        public const string PTTHV_DETAIL_CHOTPDUYET_DESCRIPTION = "Chờ TP duyệt KQ";
        public const string PTTHV_DETAIL_CHOGDDUYET_DESCRIPTION = "Chờ GĐCL duyệt KQ";
        public const string PTTHV_DETAIL_DADUYETKQ_DESCRIPTION = "Hoàn tất";
        public const string PTTHV_DETAIL_HUY_DESCRIPTION = "Đã hủy";
        public const string PTTHV_DETAIL_CHOXACNHAN_DESCRIPTION = "Chờ xác nhận";

        #endregion

        #region NGUỒN PHÁT SINH PHIẾU THÔNG TIN HÀNG VỀ
            public const string CATEGORY_NGUONPHATSINH = "NPSLPTTHV";

            public const string NPSLPTTHV_MUAHANG = "NPSLPTTHV_MUAHANG";
            public const string NPSLPTTHV_KETQUASANXUAT = "NPSLPTTHV_KETQUASANXUAT";
            public const string NPSLPTTHV_PBDENGHINHAPKHO = "NPSLPTTHV_PBDENGHINHAPKHO";
            public const string NPSLPTTHV_DIXULY = "NPSLPTTHV_DIXULY";
            public const string NPSLPTTHV_KHTRA = "NPSLPTTHV_KHTRA";

            public const string NPSLPTTHV_MUAHANG_DESCRIPTION = "Phát sinh - mua hàng";
            public const string NPSLPTTHV_KETQUASANXUAT_DESCRIPTION = "Phát sinh - kết quả sản xuất";
            public const string NPSLPTTHV_PBDENGHINHAPKHO_DESCRIPTION = "Phát sinh - phòng ban đề nghị nhập kho";
            public const string NPSLPTTHV_DIXULY_DESCRIPTION = "Phát sinh - đi xử lý";
            public const string NPSLPTTHV_KHTRA_DESCRIPTION = "Phát sinh - khách hàng trả";

        #endregion

        #endregion

        #region ĐỀ NGHỊ NHẬP KHO

        #region TRẠNG THÁI ĐỀ NGHỊ NHẬP KHO
        public const string CATEGORY_DENGHINHAPKHO = "DNNK";

        public const string DNNK_DANGSOANTHAO = "DNNK_DANGSOANTHAO";
        public const string DNNK_CHODUYET = "DNNK_CHODUYET";
        public const string DNNK_CHONHAPKHO = "DNNK_CHONHAPKHO";
        public const string DNNK_KHONGDUYET = "DNNK_KHONGDUYET";
        public const string DNNK_HOANTAT = "DNNK_HOANTAT";
        public const string DNNK_DAHUY = "DNNK_DAHUY";
        public const string DNNK_DAXOA = "DNNK_DAXOA";
        public const string DNNK_CHOXULY = "DNNK_CHOXULY";
        public const string DNNK_DANGSOANTHAO_CK = "DNNK_DANGSOANTHAO_CK";

        public const string DNNK_DANGSOANTHAO_DESCRIPTION = "Đang soạn thảo";
        public const string DNNK_CHODUYET_DESCRIPTION = "Chờ duyệt";
        public const string DNNK_CHONHAPKHO_DESCRIPTION = "Chờ nhập kho";
        public const string DNNK_KHONGDUYET_DESCRIPTION = "Không duyệt";
        public const string DNNK_HOANTAT_DESCRIPTION = "Hoàn tất";
        public const string DNNK_DAHUY_DESCRIPTION = "Đã hủy";
        public const string DGNCC_CHOXULY_DESCRIPTION = "Đang thực hiện";
        public const string DNNK_DANGSOANTHAO_CK_DESCRIPTION = "Đang soạn thảo";

        #endregion

        #region LOẠI PHIẾU ĐỀ NGHỊ NHẬP KHO

        public const string NHAPHANGSANXUAT = "NHAPHANGSANXUAT";
        public const string NHAPDUNPLBBBTP = "NHAPDUNPLBBBTP";
        public const string BAOCAOKIEMKE = "NHAPDUNCCGIAO";
        public const string NHAPHANGCHUYENKHO = "NHAPHANGCHUYENKHO";

        public const string NHAPHANGSANXUAT_DESCRIPTION = "Nhập hàng sản xuất";
        public const string NHAPDUNPLBBBTP_DESCRIPTION = "Nhập thừa từ SX";
        public const string BAOCAOKIEMKE_DESCRIPTION = "Nhập dư hàng NCC giao";
        public const string NHAPHANGCHUYENKHO_DESCRIPTION = "Nhập hàng chuyển kho";

        #endregion

        #endregion

        #region NHẬP KHO

            #region TRANG THÁI NHẬP KHO

            public const string CATEGORY_NHAPKHO = "NK";
            public const string Config_HanSuDungMacDinhDMHangHoa = "Config_HanSuDungMacDinhDMHangHoa";
            
            public const string NK_DAHUY = "NK_DAHUY";
            public const string NK_PHIEUMOI = "NK_PHIEUMOI";
            public const string NK_CHOXACNHAN = "NK_CHOXACNHAN";
            public const string NK_TUCHOI = "NK_TUCHOI";
            public const string NK_HOANTAT = "NK_HOANTAT";
            public const string NK_DAXOA = "NK_DAXOA";


            public const string NK_PHIEUMOI_DESCRIPTION = "Đang soạn thảo";
            public const string NK_HOANTAT_DESCRIPTION = "Hoàn tất";
            public const string NK_DAXOA_DESCRIPTION = "Đã xóa";
            public const string NK_CHOXACNHAN_DESCRIPTION = "Chờ xác nhận";
            public const string NK_TUCHOI_DESCRIPTION = "Từ chối";
            public const string NK_DAHUY_DESCRIPTION = "Đã hủy";

            #endregion

            #region LOẠI PHIẾU NHẬP KHO
            public const string NHAPTUHANGVE = "NHAPTUHANGVE";
            public const string NHAPTUDENGHI = "NHAPTUDENGHI";
            public const string NHAPTUCHUYENKHO = "NHAPTUCHUYENKHO";
            public const string NHAPXUATDUNGLUON = "NHAPXUATDUNGLUON";
            public const string BAOCAOKIEMKEDAPHEDUYET = "BAOCAOKIEMKEDAPHEDUYET";

            public const string NHAPTUHANGVE_DESCRIPTION = "Nhập từ hàng về";
            public const string NHAPTUDENGHI_DESCRIPTION = "Nhập từ đề nghị";
            public const string NHAPTUCHUYENKHO_DESCRIPTION = "Nhập từ chuyển kho";
            public const string NHAPXUATDUNGLUON_DESCRIPTION = "Nhập xuất dùng luôn";
            public const string BAOCAOKIEMKEDAPHEDUYET_DESCRIPTION = "Báo cáo kiểm kê đã duyệt";
            #endregion

        #endregion

        #region ĐỀ NGHỊ XUẤT KHO

        #region TRẠNG THÁI PHIẾU ĐỀ NGHỊ XUẤT KHO

        public const string CATEGORY_KHODNXK = "DNXK";

        public const string KHODNXK_PHIEUMOI_CODE = "KHOPDNXK_LUUNHAP";
        public const string KHODNXK_CHODUYET_CODE = "KHOPDNXK_CHODUYET";
        public const string KHODNXK_KHONGDUYET_CODE = "KHOPDNXK_BITRALAI";
        public const string KHODNXK_HOANTAT_CODE = "KHOPDNXK_HOANTAT";
        public const string KHODNXK_DAHUY_CODE = "KHOPDNXK_DAHUY";
        public const string KHODNXK_XOA_CODE = "KHOPDNXK_DAXOA";
        public const string KHODNXK_CHOXUATKHO_CODE = "KHOPDNXK_CHOXUATKHO";
        public const string KHODNXK_XACNHANNHANHANG_CODE = "KHODNXK_XACNHANNHANHANG";
        public const string KHODNXK_DUYETCT_CODE = "KHODNXK_DUYETCT";
        public const string KHODNXK_KHONGDUYETCT_CODE = "KHODNXK_KHONGDUYETCT";


        public const string KHODNXK_DAHUY_DESCRIPTION = "Đã hủy";
        public const string KHODNXK_KHONGDUYET_DESCRIPTION = "Không duyệt";
        public const string KHODNXK_HOANTAT_DESCRIPTION = "Hoàn tất";
        public const string KHODNXK_XOA_DESCRIPTION = "Đã xóa";
        public const string KHODNXK_DUYETCT_DESCRIPTION = "Duyệt";
        public const string KHODNXK_KHONGDUYETCT_DESCRIPTION = "Không duyệt";

        public const string NPSDNXK_KHSX = "NPSDNXK_KHSX";
        public const string NPSDNXK_LSXBS = "NPSDNXK_LSXBS";
        public const string NPSDNXK_LSX = "NPSDNXK_LSX";
        public const string NPSDNXK_KHGH = "NPSDNXK_KHGH";

        public const string LOAIPHIEU_KHBH = "4_KEHOACHBANHANG";

        #endregion TRẠNG THÁI PHIẾU ĐỀ NGHỊ XUẤT KHO

        #region TRẠNG THÁI PHIẾU XUẤT KHO

        public const string CATEGORY_KHOXK = "XK";
        public const string CATEGORY_KHOXKLP = "KHOXKLP";


        public const string KHOXK_PHIEUMOI_CODE = "KHOXK_LUUNHAP";
        public const string KHOXK_BITRALAI_CODE = "KHOXK_BITRALAI";
        public const string KHOXK_HOANTAT_CODE = "KHOXK_HOANTAT";
        public const string KHOXK_DAHUY_CODE = "KHOXK_DAHUY";
        public const string KHOXK_XOA_CODE = "KHOXK_DAXOA";
        public const string KHOXK_CHOXACNHAN_CODE = "KHOXK_CHOXACNHAN";

        public const string KHOXK_DAHUY_DESCRIPTION = "Đã hủy";
        public const string KHOXK_BITRALAI_DESCRIPTION = "Bị trả lại";
        public const string KHOXK_HOANTAT_DESCRIPTION = "Hoàn tất";
        public const string KHOXK_XOA_DESCRIPTION = "Đã xóa";

        public const string KHOXK_LOAI_GHKH_CODE = "KHOXK_LOAI_GHKH_CODE";
        public const string KHOXK_LOAI_TYC_CODE = "KHOXK_LOAI_TYC_CODE";

        public const string KHOXK_LOAI_1_XUATKHOIKHO = "1_XUATKHOIKHO";
        public const string KHOXK_LOAI_2_XUATCHUYENKHO = "2_XUATCHUYENKHO";
        public const string KHOXK_LOAI_3_BAOCAOKIEMKEDAPHEDUYET = "3_BAOCAOKIEMKEDAPHEDUYET";
        public const string KHOXK_LOAI_4_NHAPXUATDUNGLUON = "4_NHAPXUATDUNGLUON";
        public const string KHOXK_LOAI_6_XUATHANGDIXULY = "6_XUATHANGDIXULY";

       
        public const string LoaiPhieuXuat_ChuyenKho = "2_XUATCHUYENKHO";

        #endregion TRẠNG THÁI PHIẾU XUẤT KHO

        #endregion

        #region XUẤT KHO
        public const string CATEGORY_XUATKHO = "XK";

        #endregion

        #region ĐỀ NGHỊ CHUYỂN KHO

        #region TRẠNG THÁI PHIẾU ĐỀ NGHỊ CHUYỂN KHO

        public const string CATEGORY_DENGHICHUYENKHO = "DNCK";
        public const string DNCK_DANGSOANTHAO = "DNCK_DANGSOANTHAO";

        public const string DNCK_DAHUY = "DNCK_DAHUY";
        public const string DNCK_HOANTAT = "DNCK_HOANTAT";
        public const string DNCK_DAXOA = "DNCK_DAXOA";
        //---new
        public const string DNCK_CHODUYET = "DNCK_CHODUYET";
        public const string DNCK_KHONGDUYET = "DNCK_KHONGDUYET";
        public const string DNCK_DANGTHUCHIEN = "DNCK_DANGTHUCHIEN";
        //---end

        public const int DNCKCT_LOAIPHIEU = 29;
        public const int DNCKCT_QUYTRINH = 43;

        #region Nofify for đề nghị chuyển kho

        public const string Header_Description_DNCK = "Đề nghị chuyển kho";
        public const string Header_Description_DNCK_Bonus = "Đề nghị duyệt chuyển kho";
        public const string NofMessage_Duyet_DNCKCT = "NofMessage_ChoDuyet_DNCKCT";
        public const string NofMessage_KhongDuyet_DNCKCT = "NofMessage_KhongDuyet_DNCKCT";


        #endregion


        #endregion

        #region TRẠNG THÁI CHI TIẾT PHIẾU ĐỀ NGHỊ CHUYỂN KHO
        public const string DNCKCT_DUYET = "DNCKCT_DUYET";
        public const string DNCKCT_KHONGDUYET = "DNCKCT_KHONGDUYET";
        #endregion

        #region LOẠI PHIẾU VÀ QUY TRÌNH PHIẾU
        public const int DNCK_LoaiPhieu = 24;
        public const int DNCKCT_LoaiPhieu = 29;

        public const int DNCK_QUITRINH = 39;
        public const int DNCKCT_QUITRINH = 43;

        #endregion
        #endregion

        #region CHUYỂN KHO

        #region TRẠNG THÁI CHUYỂN KHO

        public const string DANGSOANTHAO_CK = "CK_PHIEUMOI";
        public const string CHOXACNHAN_XK_CK = "CK_CHOXACNHAN_XK";
        public const string CHOXACNHAN_NK_CK = "CK_CHOXACNHAN_NK";
        public const string BITRALAI_XK_CK = "CK_BITRALAI_XK";
        public const string BITRALAI_NK_CK = "CK_BITRALAI_NK";
        public const string DAHUY_CK = "CK_DAHUY";
        public const string HOANTAT_CK = "CK_HOANTAT";
        public const string DAXOA_CK = "CK_DAXOA";

        #endregion


        #region Nofify for chuyển kho


        public const int XK_LOAIPHIEU = 5;
        //public const int XK_QUYTRINH = 43;

        public const int NK_LOAIPHIEU = 2;
        public const int NK_QUYTRINH = 8;

        public const string Header_Description_CK = "Chuyển kho";
        public const string Header_Description_XuatCK = "Phiếu xuất chuyển kho";

        public const string NofMessage_Xuat_CK = "NofMessage_Xuat_CK";
        public const string NofMessage_Nhap_CK = "NofMessage_Nhap_CK";
        public const string NofMessage_HOANTAT_CHUYENKHO = "NofMessage_HOANTAT_CHUYENKHO";

        #endregion

        #endregion

        #region KIỂM KÊ KHO

        #region TRẠNG THÁI PHIẾU KIỂM KÊ

        public const string CATEGORY_KK = "KK";
        public const string KK_DANGSOANTHAO = "KK_DANGSOANTHAO";
        //đổi trạng thái thành chờ xác nhận
        public const string KK_CHOKETQUA = "KK_CHOKETQUA";
        //end
        public const string KK_CHOXEMXET = "KK_CHOXEMXET";
        public const string KK_CHOBGDDUAHUONGXL = "KK_CHOBGDDUAHUONGXL";
        public const string KK_CHOXULY = "KK_CHOXULY";
        public const string KK_HOANTAT = "KK_HOANTAT";
        public const string KK_DAXOA = "KK_DAXOA";
        public const string KK_DAHUY = "KK_DAHUY";
        #endregion

        #endregion

        #region TỔNG HỢP TỒN KHO

        #region SỐ NGÀY CÀNH BÁO SẮP HẾT HẠN FORM TỔNG HỢP TỒN KHO THEO HẠN SỬ DỤNG 
        public const string TKHanSuDung = "TKHanSuDung";
        #endregion

        #endregion

        #region MANG VT-TTB RA NGOÀI

        #region TRANG THÁI MANG VT-TTB RA NGOÀI
        public const string CATEGORY_VTTTBRN = "VTTTBRN";

        public const string VTTTBRN_DangSoanThao = "VTTTBRN_DangSoanThao";
        public const string VTTTBRN_ChoDuyet = "VTTTBRN_ChoDuyet";
        public const string VTTTBRN_KhongDuyet = "VTTTBRN_KhongDuyet";
        public const string VTTTBRN_HoanTat = "VTTTBRN_HoanTat";
        public const string VTTTBRN_DaHuy = "VTTTBRN_DaHuy";
        public const string VTTTBRN_DaXoa = "VTTTBRN_DaXoa";

        public const string VTTTBRN_DangSoanThao_DESCRIPTION = "Đang soạn thảo";
        public const string VTTTBRN_ChoDuyet_DESCRIPTION = "Chờ duyệt";
        public const string VTTTBRN_KhongDuyet_DESCRIPTION = "Không duyệt";
        public const string VTTTBRN_HoanTat_DESCRIPTION = "Hoàn tất";
        public const string VTTTBRN_DaHuy_DESCRIPTION = "Đã hủy";
        public const string VTTTBRN_DaXoa_DESCRIPTION = "Đã xóa";
        #endregion

        #endregion

        #endregion

        #region PHÂN HỆ KINH DOANH

            #region YÊU CẦU BÁO GIÁ

            #region TRẠNG THÁI YÊU CẦU BÁO GIÁ
            public const string CATEGORY_YCBG = "PBG";

            public const string PBG_PHIEUMOI = "PBG_PHIEUMOI";
            public const string PBG_DANGTHUCHIEN = "PBG_DANGTHUCHIEN";
            public const string PBG_CHODUYET = "PBG_CHODUYET";
            public const string PBG_KHONGDUYET = "PBG_KHONGDUYET";
            public const string PBG_HOANTAT = "PBG_HOANTAT";
            public const string PBG_DAHUY = "PBG_DAHUY";
            public const string PBG_DAXOA = "PBG_DAXOA";

            public const string PBG_PHIEUMOI_DESCRIPTION = "Đang soạn thảo";
            public const string PBG_DANGTHUCHIEN_DESCRIPTION = "Đang thực hiện";
            public const string PBG_CHODUYET_DESCRIPTION = "Chờ duyệt";
            public const string PBG_KHONGDUYET_DESCRIPTION = "Không duyệt";
            public const string PBG_HOANTAT_DESCRIPTION = "Hoàn tất";
            public const string PBG_DAHUY_DESCRIPTION = "Đã hủy";
            public const string PBG_DAXOA_DESCRIPTION = "Đã xóa";
            #endregion

            #region TRẠNG THÁI CHI TIẾT PHIẾU YÊU CẦU BÁO GIÁ

            public const string CATEGORY_YCBG_DETAIL = "PBG_DETAIL";

            public const string PBG_DETAIL_PHIEUMOI = "PBG_DETAIL_PHIEUMOI";
            public const string PBG_DETAIL_KODUYETBAOGIA = "PBG_DETAIL_KODUYETBAOGIA";
            public const string PBG_DETAIL_CHODUYETBAOGIA = "PBG_DETAIL_CHODUYETBAOGIA";
            public const string PBG_DETAIL_DADUYETBAOGIA = "PBG_DETAIL_DADUYETBAOGIA";

            public const string PBG_DETAIL_PHIEUMOI_DESCRIPTION = "Đang soạn thảo";
            public const string PBG_DETAIL_KODUYETBAOGIA_DESCRIPTION = "Không duyệt báo giá";
            public const string PBG_DETAIL_CHODUYETBAOGIA_DESCRIPTION = "Chờ duyệt báo giá";
            public const string PBG_DETAIL_DADUYETBAOGIA_DESCRIPTION = "Đã duyệt báo giá";

            #endregion

            #endregion

            #region YÊU CẦU DUYỆT GIÁ

            #region TRẠNG THÁI PHIẾU YÊU CẦU DUYỆT GIÁ

            public const string CATEGORY_KDYCDG = "KDYCDG";

            public const string KDYCDG_DANGSOANTHAO_CODE = "KDYCDG_DANGSOANTHAO";
            public const string KDYCDG_CHODUYET_CODE = "KDYCDG_CHODUYET";
            public const string KDYCDG_DANGTHUCHIEN_CODE = "KDYCDG_DANGTHUCHIEN";
            public const string KDYCDG_HOANTAT_CODE = "KDYCDG_HOANTAT";
            public const string KDYCDG_KHONGDUYET_CODE = "KDYCDG_KHONGDUYET";
            public const string KDYCDG_DAHUY_CODE = "KDYCDG_DAHUY";
            public const string KDYCDG_XOA_CODE = "KDYCDG_XOA";
            public const string KDYCDG_HETHAN_CODE = "KDYCDG_HETHAN";

            public const string KDYCDG_DANGSOANTHAO_DESCRIPTION = "Đang soạn thảo";
            public const string KDYCDG_CHODUYET_DESCRIPTION = "Chờ duyệt";
            public const string KDYCDG_DANGTHUCHIEN_DESCRIPTION = "Đang thực hiện";
            public const string KDYCDG_HOANTAT_DESCRIPTION = "Hoàn tất";
            public const string KDYCDG_KHONGDUYET_DESCRIPTION = "Không duyệt";
            public const string KDYCDG_DAHUY_DESCRIPTION = "Đã hủy";
            public const string KDYCDG_XOA_DESCRIPTION = "Đã xóa";
            public const string KDYCDG_HETHAN_DESCRIPTION = "Hết hạn";

        #endregion TRẠNG THÁI PHIẾU YÊU CẦU DUYỆT GIÁ

        #region TYPE KINH DOANH DUYỆT GIÁ
        public const short DAT_HANG_KHACH_HANG = 0;
            public const short FORECAST = 1;
            #endregion

            #endregion

            #region ĐƠN HÀNG BÁN
            public const string Config_TienTeMacDinh = "Config_TienTeMacDinh";
            public const int LOAI_DONDATHANG = 0;
            public const int LOAI_FORECAST = 1;

                    #region TRẠNG THÁI PHIẾU KINH DOANH ĐẶT HÀNG
                    public const string CATEGORY_KDDH = "KDDH";

                    public const string KDDH_PHIEUMOI_CODE = "KDDH_DANGSOANTHAO";
                    public const string KDDH_CHODUYET_CODE = "KDDH_CHODUYET";
                    public const string KDDH_KHONGDUYET_CODE = "KDDH_KHONGDUYET";
                    public const string KDDH_CHOKHXACNHAN_CODE = "KDDH_CHOKHHXACNHAN";
                    public const string KDDH_TUCHOI_CODE = "KDDH_TUCHOI";
                    public const string KDDH_CHOCHOTHANG_CODE = "KDDH_CHOCHOTHANG";
                    public const string KDDH_HOANTAT_CODE = "KDDH_HOANTAT";
                    public const string KDDH_HUYCHOTHANG_CODE = "KDDH_HUYCHOTHANG";
                    public const string KDDH_DAHUY_CODE = "KDDH_DAHUY";
                    public const string KDDH_XOA_CODE = "KDDH_XOA";
                    public const string KDDH_DANGTHUCHIEN_CODE = "KDDH_DANGTHUCHIEN";

                    // bổ sung
                    public const string KDDH_DASUA_CODE = "KDDH_DASUA";
                    public const string KDDH_DADUYET_CODE = "KDDH_DADUYET";
                    public const string KDDH_DAKHONGDUYET_CODE = "KDDH_DAKHONGDUYET";
                    public const string KDDH_DONGYYCGH_CODE = "KDDH_DONGYYCGH";
                    public const string KDDH_HOANTATKHGHMOI_CODE = "KDDH_HOANTATKHGHMOI";


                    public const string KDDHCT_CHOGIAOHANG_CODE = "KDDHCT_CHOGIAOHANG";
                    public const string KDDHCT_CHUAGIAODUHANG_CODE = "KDDHCT_CHUAGIAODUHANG";
                    public const string KDDHCT_DAGIAODUHANG_CODE = "KDDHCT_DAGIAODUHANG";
                    public const string KDDHCT_CHOSANXUAT_CODE = "KDDHCT_CHOSANXUAT";
                    public const string KDDHCT_DASANXUAT_CODE = "KDDHCT_DASANXUAT";
                    #endregion TRẠNG THÁI PHIẾU KINH DOANH ĐẶT HÀNG

        
                    #region TRẠNG THÁI XÁC NHẬN KẾ HOẠCH
                    public const string KDXNKH_CHUAXACNHAN_CODE = "KDXNKH_CHUAXACNHAN";
                    public const string KDXNKH_XACNHAN_CODE = "KDXNKH_XACNHAN";
                    #endregion

            #endregion

            #region TÍNH GIÁ

            #region CẤU HÌNH CÁC TAB NHÂN SỰ PHIẾU TÍNH GIÁ            
            public const decimal IdChucVu_Is_CONGNHAN = 37;
            public const decimal IdCoCau_Is_SX = 61;
            public static decimal[] CONDS_TAB_QLSX = {  47, // BAN GIÁM ĐỐC
                                                        80, // MUA HÀNG
                                                        83, // QC
                                                        75, // R&D
                                                        50, // CƠ ĐIỆN
            };
            public static decimal[] CONDS_TAB_NVQL = {  49, // KẾ TOÁN
                                                        52, // HÀNH CHÁNH
                                                        81, // AN TOÀN LAO ĐỘNG
                                                        87, // KINH DOANH
            };
        #endregion

        #region CẤU HÌNH TÍNH GIÁ
        public const string CauHinhTinhGia = "CauHinhTinhGia";
            #endregion

            #region NGUỒN PHÁT SINH KHOẢN MỤC TÍNH GIÁ
            public const string CHTG_NPSMAKHOANMUC_DMHH = "NPSMAKHOANMUC_DMHH";
            #endregion

            #region TRẠNG THÁI TÍNH GIÁ
            public const string TG_CATEGORY = "KD_TG";
            public const string TG_DANGSOANTHAO = "TG_DANGSOANTHAO";
            public const string TG_CHOCHOTGIA = "TG_CHOCHOTGIA";
            public const string TG_HOANTAT = "TG_HOANTAT";
            public const string TG_DAHUY = "TG_DAHUY";
            public const string TG_DAXOA = "TG_DAXOA";
            #endregion

            #region TRẠNG THÁI CHI TIẾT TÍNH GIÁ
            public const string CTTG_DangXoanThao = "CTTG_DangXoanThao";
            public const string CTTG_ChoXacNhan = "CTTG_ChoXacNhan";
            public const string CTTG_DaXacNhan = "CTTG_DaXacNhan";

            #endregion

            #endregion

            #region KHIẾU NẠI KHÁCH HÀNG

            #region TRẠNG THÁI KHIẾU NẠI KHÁCH HÀNG

            public const string CATEGORY_KNKH = "KNKH";

            public const string KNKH_DANGSOANTHAO = "KNKH_DANGSOANTHAO";
            public const string KNKH_CHOTIEPNHAN = "KNKH_CHOTIEPNHAN";
            public const string KNKH_CHOKIEMTRA = "KNKH_CHOKIEMTRA";
            public const string KNKH_CHOCAPNHATHUONGXL = "KNKH_CHOCAPNHATHUONGXL";
            public const string KNKH_HOANTAT = "KNKH_HOANTAT";
            public const string KNKH_DAXOA = "KNKH_DAXOA";
            #endregion

            #region TRẠNG THÁI HÀNG BỊ KHIẾU NẠI

            public const string KNKHCT_CHOTIEPNHAN = "KNKHCT_CHOTIEPNHAN";
            public const string KNKHCT_CHOKIEMTRA = "KNKHCT_CHOKIEMTRA";
            public const string KNKHCT_CHOCAPNHATHUONGXL = "KNKHCT_CHOCAPNHATHUONGXL";
            public const string KNKHCT_HOANTAT = "KNKHCT_HOANTAT";

            #endregion

            #endregion

            #region THU HỒI/ TRIỆU HỒI SẢN PHẨM

            #region TRẠNG THÁI PHIẾU THU HỒI
            public const string THUHOI_CATEGORY = "THUHOI";

            public const string THUHOI_CHUADUYET = "THUHOI_CHUADUYET";
            public const string THUHOI_DADUYET = "THUHOI_DADUYET";
            public const string THUHOI_DANGTHUHOI = "THUHOI_DANGTHUHOI";
            public const string THUHOI_HOANTAT = "THUHOI_HOANTAT";
            public const string THUHOI_DAXOA = "THUHOI_DAXOA";
            #endregion

            #endregion

        #endregion

        #region PHÂN HỆ R&D

        #region PHIẾU YÊU CẦU NGHIÊN CỨU

        #region TRẠNG THÁI PHIẾU YÊU CẦU NGHIÊN CỨU
        public const string CATEGORY_YEUCAUNGHIENCUU = "YCNC";

        public const string YCNC_PHIEUMOI = "YCNC_PHIEUMOI";
        public const string YCNC_CHODUYET = "YCNC_CHODUYET";
        public const string YCNC_CHO_TPRD_DUYET = "YCNC_CHO_TPRD_DUYET";
        public const string YCNC_CHO_GDNM_DUYET = "YCNC_CHO_GDNM_DUYET";
        public const string YCNC_DANG_THUC_HIEN = "YCNC_DANG_THUC_HIEN";
        public const string YCNC_DANG_CHO_PHAN_CONG = "YCNC_DANG_CHO_PHAN_CONG";
        public const string YCNC_DAHUY = "YCNC_DAHUY";
        public const string YCNC_TUCHOI = "YCNC_TUCHOI";
        public const string YCNC_HOANTAT = "YCNC_HOANTAT";


        public const string YCNC_PHIEUMOI_DESCRIPTION = "Đang soạn thảo";
        public const string YCNC_CHODUYET_DESCRIPTION = "Chờ duyệt";
        public const string YCNC_CHO_TPRD_DUYET_DESCRIPTION = "Chờ R&D duyệt";
        public const string YCNC_CHO_GDNM_DUYET_DESCRIPTION = "Chờ GĐNM duyệt";
        public const string YCNC_DANG_THUC_HIEN_DESCRIPTION = "Đang thực hiện";
        public const string YCNC_DANG_CHO_PHAN_CONG_DESCRIPTION = "Chờ phân công thực hiện";
        public const string YCNC_HOANTAT_DESCRIPTION = "Hoàn tất";
        public const string YCNC_TUCHOI_DESCRIPTION = "Từ chối";
        public const string YCNC_DAHUY_DESCRIPTION = "Đã hủy";

        public const string YCNC_ID_DVT = "YCNC_ID_DVT";
        public const string YCNC_ID_NHOMHH = "YCNC_ID_NHOMHH";
        #endregion

        #endregion

        #region BOM
        public const string CATEGORY_BOM = "BOM";
        public const string BOM_DANGSOANTHAO = "BOM_DANGSOANTHAO";
        public const string BOM_CHOXACNHAN = "BOM_CHOXACNHAN";
        public const string BOM_TUCHOIXACNHAN = "BOM_TUCHOIXACNHAN";
        public const string BOM_CHODUYET = "BOM_CHODUYET";
        public const string BOM_DANGAPDUNG = "BOM_DANGAPDUNG";
        public const string BOM_TUCHOIDUYET = "BOM_TUCHOIDUYET";
        public const string BOM_DATHAYTHE = "BOM_DATHAYTHE";
        public const string BOM_DAHUY = "BOM_DAHUY";
        public const string BOM_DAXOA = "BOM_DAXOA";
        public const string BOM_CHOGDKDUYET = "BOM_CHOGDKDUYET";
        public const string BOM_TUCHOIGDK = "BOM_TUCHOIGDK";

        public const int KHOILUONGCANTINH = 100;

        #endregion


        #region SPEC
        public const string CATEGORY_SPEC = "SPEC";
        public const string SPEC_DANGSOANTHAO = "SPEC_DANGSOANTHAO";
        public const string SPEC_CHOXEMXET = "SPEC_CHOXEMXET";
        public const string SPEC_KHONGTHONGQUA = "SPEC_KHONGTHONGQUA";
        public const string SPEC_CHODUYET = "SPEC_CHODUYET";
        public const string SPEC_DADUYET = "SPEC_DADUYET";
        public const string SPEC_KHONGDUYET = "SPEC_KHONGDUYET";
        public const string SPEC_DAHUY = "SPEC_DAHUY";
        public const string SPEC_DAXOA = "SPEC_DAXOA";
        public const string SPEC_NGUNGSUDUNG = "SPEC_NGUNGSUDUNG";
        #endregion

        #region QUY TRÌNH SẢN XUẤT
        public const string CATEGORY_QTSX = "RD-QTSX-";
        public const string QTSX_DANGSOANTHAO = "QTSX_DANGSOANTHAO";
        public const string QTSX_CHODUYET = "QTSX_CHODUYET";
        public const string QTSX_CHOGDDUYET = "QTSX_CHOGDDUYET";
        public const string QTSX_KHONGDUYET = "QTSX_KHONGDUYET";
        public const string QTSX_CHOBANGIAO = "QTSX_CHOBANGIAO";
        public const string QTSX_CHOXNBANGIAO = "QTSX_CHOXNBANGIAO";
        public const string QTSX_HOANTAT = "QTSX_HOANTAT";
        public const string QTSX_DAHUY = "QTSX_DAHUY";
        public const string QTSX_DAXOA = "QTSX_DAXOA";

        public const string Config_PBMacDinh_NVQC_QTSX = "Config_PBMacDinh_NVQC_QTSX";
        public const string Config_PBMacDinh_QLSX_QTSX = "Config_PBMacDinh_QLSX_QTSX";
        public const string Config_PBMacDinh_GDRD_GDNM_QTSX = "Config_PBMacDinh_GDRD_GDNM_QTSX";

        #endregion

        #region TRẠNG THÁI NHẬT KÝ GỬI MẪU

        public const string CATEGORY_NHATKYGUIMAU = "NKGM";
        public const string Config_PBMacDinhNhatKyGuiMau = "Config_PBMacDinhNhatKyGuiMau";

        public const string NKGM_CHOGUIMAU = "NKGM_CHOGUIMAU";
        public const string NKGM_CHOKETQUAPHANHOI = "NKGM_CHOKETQUAPHANHOI";
        public const string NKGM_HOANTAT = "NKGM_HOANTAT";
        public const string NKGM_DAHUY = "NKGM_DAHUY";

        public const string NKGM_CHOGUIMAU_DESCRIPTION = "Chờ gửi mẫu";
        public const string PNKGM_CHOKETQUAPHANHOI_DESCRIPTION = "Chờ kết quả phản hồi";
        public const string NKGM_HOANTAT_DESCRIPTION = "Hoàn tất";
        public const string NKGM_DAHUY_DESCRIPTION = "Đã hủy";

        #endregion

        #endregion

        #region PHÂN HỆ HỢP ĐỒNG

        #region HỢP ĐỒNG MUA HÀNG
        public const string CATEGORY_HDMH = "HDMH";
        public const string HDMH_DANGSOANTHAO = "HDMH_DANGSOANTHAO";
        public const string HDMH_CHOXACNHAN = "HDMH_CHOXACNHAN";
        public const string HDMH_TUCHOI = "HDMH_TUCHOI";
        public const string HDMH_DUOCSUDUNG = "HDMH_DUOCSUDUNG";
        public const string HDMH_HETHOPDONG = "HDMH_HETHOPDONG";
        public const string HDMH_DAHUY = "HDMH_DAHUY";
        public const string HDMH_DAXOA = "HDMH_DAXOA";
        #endregion


        #endregion

        #region PHÂN HỆ KẾ HOẠCH
        public const string CATEGORY_YEUCAUXUATKHAN = "YCXK";
        public const string YCXK_DANGSOANTHAO = "YCXK_DANGSOANTHAO";
        public const string YCXK_CHOTPDUYET = "YCXK_CHOTPDUYET";
        public const string YCXK_CHOQCPASSKHAN = "YCXK_CHOQCPASSKHAN";
        public const string YCXK_CHOTPQCDUYET = "YCXK_CHOTPQCDUYET";
        public const string YCXK_HOANTAT = "YCXK_HOANTAT";
        public const string YCXK_DAHUY = "YCXK_DAHUY";
        public const string YCXK_DAXOA = "YCXK_DAXOA";
        public const string YCXK_KHONGDUYET = "YCXK_KHONGDUYET";

        public const string YCXK_DUYET_CONFIRM = "YCXK_DUYET_CONFIRM";
        public const string YCXK_KHONGDUYET_CONFIRM = "YCXK_KHONGDUYET_CONFIRM";

        public const string Config_PBMacDinhYeuCauXuatKhan = "Config_PBMacDinhYeuCauXuatKhan";

        #endregion

        #region PHÂN HỆ KẾ TOÁN

        #region PHIẾU CHI

        #region TRẠNG THÁI PHIẾU CHI
        public const string CATEGORY_PHIEUCHI = "KTPC";

        public const string KTPC_PHIEUMOI = "KTPC_PHIEUMOI";
        public const string KTPC_CHODUYET = "KTPC_CHODUYET";
        public const string KTPC_DANGSOANTHAO = "KTPC_DANGSOANTHAO";
        public const string KTPC_DAGHISOQUY = "KTPC_DAGHISOQUY";
        public const string KTPC_CHOGIAMDOCDUYET = "KTPC_CHOGIAMDOCDUYET";
        public const string KTPC_TRALAI = "KTPC_TRALAI";
        public const string KTPC_DADUYET = "KTPC_DADUYET";
        public const string KTPC_DAHUY = "KTPC_DAHUY";
        public const string KTPC_TUCHOI = "KTPC_TUCHOI";
        public const string KTPC_DAGHISOKETOAN = "KTPC_DAGHISOKETOAN";


        public const string KTPC_DANG_SOAN_THAO_DESCRIPTION = "Đang soạn thảo";
        public const string KTPC_CHODUYET_DESCRIPTION = "Chờ duyệt";
        public const string KTPC_PHIEUMOI_DESCRIPTION = "Phiếu mới";
        public const string KTPC_DAGHISOQUY_DESCRIPTION = "Đã ghi sổ quỹ";
        public const string KTPC_DAGHISOKETOAN_DESCRIPTION = "Đã ghi sổ kế toán";
        public const string KTPC_CHOGIAMDOCDUYET_DESCRIPTION = "Chờ giám đốc duyệt";
        public const string KTPC_TRALAI_DESCRIPTION = "Trả lại";
        public const string KTPC_DADUYET_DESCRIPTION = "Đã duyệt";
        public const string KTPC_TUCHOI_DESCRIPTION = "Từ chối";
        public const string KTPC_DAHUY_DESCRIPTION = "Đã hủy";
        #endregion

        #region Nofify for Phiếu chi

        public const string Header_Description_KTPC = "Phiếu chi";
        public const string NofMessage_DangChoDuyet_KTPC = "NofMessage_DangChoDuyet_KTPC";
        public const string NofMessage_KhongDuyet_KTPC = "NofMessage_KhongDuyet_KTPC";
        #endregion
        #endregion

        #region UỶ NHIỆM CHI

        #region TRẠNG THÁI UỶ NHIỆM CHI
        public const string CATEGORY_UYNHIEMCHI = "KTUNC";

        public const string KTUNC_PHIEUMOI = "KTUNC_PHIEUMOI";
        public const string KTUNC_CHODUYET = "KTUNC_CHODUYET";
        public const string KTUNC_DANGSOANTHAO = "KTUNC_DANGSOANTHAO";
        public const string KTUNC_DAGHISOQUY = "KTUNC_DAGHISOQUY";
        public const string KTUNC_CHOGIAMDOCDUYET = "KTUNC_CHOGIAMDOCDUYET";
        public const string KTUNC_TRALAI = "KTUNC_TRALAI";
        public const string KTUNC_DADUYET = "KTUNC_DADUYET";
        public const string KTUNC_DAHUY = "KTUNC_DAHUY";
        public const string KTUNC_DAGHISOKETOAN = "KTUNC_DAGHISOKETOAN";
        public const string KTUNC_TUCHOI = "KTUNC_TUCHOI";


        public const string KTUNC_DANG_SOAN_THAO_DESCRIPTION = "Đang soạn thảo";
        public const string KTUNC_CHODUYET_DESCRIPTION = "Chờ duyệt";
        public const string KTUNC_PHIEUMOI_DESCRIPTION = "Phiếu mới";
        public const string KTUNC_DAGHISOQUY_DESCRIPTION = "Đã ghi sổ quỹ";
        public const string KTUNC_DAGHISOKETOAN_DESCRIPTION = "Đã ghi sổ kế toán";
        public const string KTUNC_CHOGIAMDOCDUYET_DESCRIPTION = "Chờ giám đốc duyệt";
        public const string KTUNC_TRALAI_DESCRIPTION = "Trả lại";
        public const string KTUNC_DADUYET_DESCRIPTION = "Đã duyệt";
        public const string KTUNC_TUCHOI_DESCRIPTION = "Từ chối";
        public const string KTUNC_DAHUY_DESCRIPTION = "Đã hủy";
        #endregion

        #endregion

        #region Chứng từ bán hàng
            public const string CATEGORY_CTBH = "BH";
            public const string CATEGORY_CTBHTL = "BTL";
            public const string CATEGORY_CTBHGG = "BGG";
            public const string CATEGORY_HDBH = "HoaDon";

        #endregion

        #region Chứng từ mua hàng   
        public const string CATEGORY_CTMHTL = "MTL";
        public const string CATEGORY_CTMHGG = "MGG";

        #endregion

        #region Tài sản cố định   
        public const string CATEGORY_GTTS = "GTTS";

        #endregion

        #region Đề nghị tạm ứng
        #region TRẠNG THÁI ĐỀ NGHỊ TẠM ỨNG
        public const string CATEGORY_DNTU = "DNTU";

        public const string DNTU_DANGSOANTHAO = "DNTU_DANGSOANTHAO";
        public const string DNTU_CHODUYET = "DNTU_CHODUYET";
        public const string DNTU_KHONGDUYET = "DNTU_KHONGDUYET";


        public const string DNTU_DADUYET = "DNTU_DADUYET";
        public const string DNTU_DAHUY = "DNTU_DAHUY";


        public const int DNTU_LOAIPHIEU = 59;
        public const int DNTU_QUYTRINH = 53;



        #region Nofify for Đề nghị tạm ứng

        public const string Header_Description_DNTU = "Đề nghị tạm ứng";
        public const string NofMessage_DangChoDuyet_DNTU = "NofMessage_DangChoDuyet_DNTU";
        public const string NofMessage_KhongDuyet_DNTU = "NofMessage_KhongDuyet_DNTU";
        #endregion

        #endregion

        #endregion

        #region Đề nghị quyết toán tạm ứng
        #region TRẠNG THÁI ĐỀ QUYẾT TOÁN NGHỊ TẠM ỨNG
        public const string CATEGORY_DNQTTU = "DNQTTU";

        public const string DNQTTU_DANGSOANTHAO = "DNQTTU_DANGSOANTHAO";
        public const string DNQTTU_CHODUYET = "DNQTTU_CHODUYET";
        public const string DNQTTU_KHONGDUYET = "DNQTTU_KHONGDUYET";


        public const string DNQTTU_DADUYET = "DNQTTU_DADUYET";
        public const string DNQTTU_DAHUY = "DNQTTU_DAHUY";


        public const int DNQTTU_LOAIPHIEU = 61;
        public const int DNQTTU_QUYTRINH = 53;



        #region Nofify for Đề nghị tạm ứng

        public const string Header_Description_DNQTTU = "Đề nghị quyết toán tạm ứng";

        #endregion

        #endregion

        #endregion

        #region Đề nghị thanh toán
        #region TRẠNG THÁI ĐỀ QUYẾT THANH TOÁN
        public const string CATEGORY_DNTT = "DNTT";

        public const string DNTT_DANGSOANTHAO = "DNTT_DANGSOANTHAO";
        public const string DNTT_CHODUYET = "DNTT_CHODUYET";
        public const string DNTT_KHONGDUYET = "DNTT_KHONGDUYET";


        public const string DNTT_DADUYET = "DNTT_DADUYET";
        public const string DNTT_DAHUY = "DNTT_DAHUY";


        public const int DNTT_LOAIPHIEU = 66;
        public const int DNTT_QUYTRINH = 81;



        #region Nofify for Đề nghị tạm ứng

        public const string Header_Description_DNTT = "Đề nghị thanh toán";

        #endregion

        #endregion

        #endregion

        #region Tiếp nhận đề nghị
        public const string TIEPNHAN_DACHI = "TIEPNHAN_DACHI";
        public const string TIEPNHAN_DATHU = "TIEPNHAN_DATHU";
        public const string TIEPNHAN_CHUACHI = "TIEPNHAN_CHUACHI";
        public const string TIEPNHAN_DALAPPHIEUCHI = "TIEPNHAN_DALAPPHIEUCHI";
        public const string TIEPNHAN_DAQUYETTOAN = "TIEPNHAN_DAQUYETTOAN";
        public const string TIEPNHAN_CHUAQUYETTOAN = "TIEPNHAN_CHUAQUYETTOAN";
       
        public const string TIEPNHAN_CHUATHU = "TIEPNHAN_CHUATHU";

        #endregion

        #region Kế toán - kho
        public const string KTK_CHUAGHISO = "KTK_CHUAGHISO";
        public const string KTK_DAGHISO = "KTK_DAGHISO";


        #endregion

        #region Phiếu thu/chi tiền mặt/tiền gửi chứng từ công nợ

        public const string DebitInWeek = "DebitInWeek";
        public const string DebitInMonth = "DebitInMonth";
        public const string BeforeDay0_30 = "BeforeDay0_30";
        public const string BeforeDay31_60 = "BeforeDay31_60";
        public const string BeforeDay61_90 = "BeforeDay61_90";
        public const string BeforeDay91_120 = "BeforeDay91_120";
        public const string BeforeAboveDay120 = "BeforeAboveDay120";
        public const string OutOfDay1_30 = "OutOfDay1_30";
        public const string OutOfDay31_60 = "OutOfDay31_60";
        public const string OutOfDay61_90 = "OutOfDay61_90";
        public const string OutOfDay91_120 = "OutOfDay91_120";
        public const string OutOfAboveDay120 = "OutOfAboveDay120";
        public const string NotDebit = "NotDebit";
        public const int ReceiptsCash = 0;
        public const int ReceiptsDeposits = 1;

        public const string ReceiptAccount = "131";

        public const string PayAccount = "331";
        public const string PuDiscountAccount = "515";

        public const string TypeVote_Puvoucher = "IsPuvoucher";
        public const string TypeVote_Capayment = "IsCapayment";
        public const string TypeVote_BawithDraw = "IsBawithDraw";
        public const string TypeVote_Puservice = "IsPuservice";
        public const int Ref_Puvoucher = 1;
        public const int Ref_Puservice = 2;


        public const int LoaiChungTu_MHTrongNuocCode = 0;
        public const int LoaiChungTu_MHNhapKhauCode = 1;

        public const string LoaiChungTu_MHTrongNuocText = "Chứng từ mua hàng trong nước nhập kho chưa thanh toán"; 
        public const string LoaiChungTu_MHNhapKhauText = "Chứng từ mua hàng nhập khẩu nhập kho chưa thanh toán"; 
        public const string LoaiChungTu_MDVText = "Chứng từ mua dịch vụ chưa thanh toán";

        #endregion

        #region Chứng từ nghiệp vụ khác
        public const int CT_NVKhac = 1;
       

        public const string CT_NVKhacText = "Chứng từ nghiệp vụ khác";
       

        public const string CATEGORY_NVK = "CTNVK";

        #endregion


        #region Chứng từ quyết toán tạm ứng
        
        public const int CT_QTTU = 2;

        
        public const string CT_QTTUText = "Chứng từ quyết toán tạm ứng";

        public const string CATEGORY_QTTU = "QTTU";
        public const string AdvanceAccount = "141";
        public const int VoucherReftType_CaPayment = 1;
        public const int VoucherReftType_BawithDraw = 2;
        #endregion

        #region Chứng từ xử lý chênh lệch tỷ giá
        public const string NvkType_Payment = "NvkType_Payment";
        public const string NvkType_Receipts = "NvkType_Receipts";






        #endregion

        #region khóa sổ/ bỏ khóa sổ kỳ kế toán
        public const int LockSolution_Bookkeeping = 1;
        public const int LockSolution_Delete = 2;
        public const int LockSolution_ChangedDayPostedDate = 3;

        //quỹ 
        public const string LockType_Capayment = "LockType_Capayment";
        public const string LockType_BawithDraw = "LockType_BawithDraw";
        public const string LockType_Careceipt = "LockType_Careceipt";
        public const string LockType_Badeposit = "LockType_Badeposit";
        public const string LockType_GlvoucherNVK = "LockType_GlvoucherNVK";
        public const string LockType_GlvoucherQTTU = "LockType_GlvoucherQTTU";
        public const string LockType_Puinvoice = "LockType_Puinvoice";
        public const string LockType_Puservice = "LockType_Puservice";
        public const string LockType_Pudiscount = "LockType_Pudiscount";
        public const string LockType_Pureturn = "LockType_Pureturn";
        public const string LockType_Savoucher = "LockType_Savoucher";
        public const string LockType_Sadiscount = "LockType_Sadiscount";
        public const string LockType_Sareturn = "LockType_Sareturn";
        public const string LockType_Fadepreciation = "LockType_Fadepreciation";
        public const string LockType_Faadjustment = "LockType_Faadjustment";
        public const string LockType_Fatransfer = "LockType_Fatransfer";
        public const string LockType_Fadecrement = "LockType_Fadecrement";
        public const string LockType_Suallocation = "LockType_Suallocation";

        //kho
        public const string LockType_Warehouse = "LockType_Warehouse";
        public const string LockType_OutofStock = "LockType_OutofStock";
        public const string LockType_TranferWareHouse = "LockType_TranferWareHouse";



        public const string LockStatusTitle_IsPostedFinance = "sổ kế toán";
        public const string LockStatusTitle_IsPostedManagement = "sổ kho";
        public const string LockStatusTitle_General = "Chưa ghi";


        public const string LockSolutionTitle_Bookkeeping = "Ghi sổ";
        public const string LockSolutionTitle_Delete = "Xóa";
        public const string LockSolutionTitle_ChangedDayPostedDate = "Chuyển ngày HT";

        #endregion

        #endregion

        #region PHÂN HỆ QA/QC

        #region PHIẾU KIỂM TRA

        #region TRẠNG THÁI PHIẾU KIỂM TRA
        public const string CATEGORY_PHIEUKIEMTRA = "PKT";
        public const string CATEGORY_PHIEUKIEMTRA_PASSKHAN = "PKTPK";

        public const string PKT_DANGSOANTHAO = "PKT_DANGSOANTHAO";
        public const string PKT_CHOXEMXET = "PKT_CHOXEMXET";
        public const string PKT_KHONGTHONGQUA = "PKT_KHONGTHONGQUA";
        public const string PKT_CHODUYET = "PKT_CHODUYET";
        public const string PKT_KHONGDUYET = "PKT_KHONGDUYET";
        public const string PKT_DADUYET = "PKT_DADUYET";
        public const string PKT_DAXOA = "PKT_DAXOA";

        public const string PKT_DANGSOANTHAO_DESCRIPTION = "Đang soạn thảo";
        public const string PKT_CHOXEMXET_DESCRIPTION = "Chờ xem xét";
        public const string PKT_KHONGTHONGQUA_DESCRIPTION = "Không thông qua";
        public const string PKT_CHODUYET_DESCRIPTION = "Chờ duyệt";
        public const string PKT_KHONGDUYET_DESCRIPTION = "Không duyệt";
        public const string PKT_DADUYET_DESCRIPTION = "Đã duyệt";

        #endregion

        #region LOẠI PHIẾU KIỂM TRA
        public const int PKT_NGUYENPHULIEU_HOACHAT = 1;
        public const int PKT_BAOBI = 2;
        public const int PKT_THANHPHAM = 3;
        public const int PKT_KHAC = 4;
        #endregion

        #endregion

        #endregion

        #region PHÂN HỆ SẢN XUẤT

            #region KẾ HOẠCH SẢN XUẤT

                #region TRẠNG THÁI PHIẾU KẾ HOẠCH SẢN XUẤT

                    public const string CATEGORY_KHSX = "KHSX";
                    public const string Config_PBMacDinhKeHoachSX = "Config_PBMacDinhKeHoachSX";
                    public const string Config_PBMacDinhKeHoachSX_BPSD = "Config_PBMacDinhKeHoachSX_BPSD";
                    public const string Config_SoNgayMuaHangNPLFromKH = "Config_SoNgayMuaHangNPLFromKH";

                    public const string KHSX_DANGSOANTHAO = "KHSX_DANGSOANTHAO";
                    public const string KHSX_CHOXEMXET = "KHSX_CHOXEMXET";
                    public const string KHSX_KHONGXEMXET = "KHSX_KHONGXEMXET";
                    public const string KHSX_CHODUYET = "KHSX_CHODUYET";
                    public const string KHSX_KHONGDUYET = "KHSX_KHONGDUYET";
                    public const string KHSX_CHOTHUCHIEN = "KHSX_CHOTHUCHIEN";
                    public const string KHSX_DATHUCHIEN = "KHSX_DATHUCHIEN";
                    public const string KHSX_DAHUY = "KHSX_DAHUY";
                    public const string KHSX_DAXOA = "KHSX_DAXOA";
                    public const string KHSX_CHOMHXACNHAN = "KHSX_CHOMHXACNHAN";
                    public const string KHSX_MHKHONGDAPUNG = "KHSX_MHKHONGDAPUNG";
                    public const string KHSX_MHDAPUNG = "KHSX_MHDAPUNG";

                    public const string KHSX_DANGSOANTHAO_DESCRIPTION = "Đang soạn thảo";
                    public const string KHSX_CHOXEMXET_DESCRIPTION = "Chờ xem xét";
                    public const string KHSX_KHONGXEMXET_DESCRIPTION = "Không xem xét";
                    public const string KHSX_CHODUYET_DESCRIPTION = "Chờ duyệt";
                    public const string KHSX_KHONGDUYET_DESCRIPTION = "Không duyệt";
                    public const string KHSX_CHOTHUCHIEN_DESCRIPTION = "Chờ thực hiện";
                    public const string KHSX_DATHUCHIEN_DESCRIPTION = "Đã thực hiện";
                    public const string KHSX_DAHUY_DESCRIPTION = "Đã hủy";
                    public const string KHSX_DAXOA_DESCRIPTION = "Đã xóa";
                    public const string KHSX_CHOMHXACNHAN_DESCRIPTION = "Chờ MH xác nhận";
                    public const string KHSX_MHKHONGDAPUNG_DESCRIPTION = "MH không đáp ứng";
                    public const string KHSX_MHDAPUNG_DESCRIPTION = "MH có thể đáp ứng";

                #endregion

            #endregion

            #region LỆNH SẢN XUẤT   
                public const string CATEGORY_LSX = "LSX";
            #endregion

        #endregion

        #region TRẠNG THÁI PHIẾU THỬ NGHIỆM MẪU

        public const string CATEGORY_PTNM = "PTNM";
        public const string PTNM_CHODUYET = "PTNM_CHODUYET";
        public const string PTNM_DADUYET = "PTNM_DADUYET";
        public const string PTNM_TUCHOI = "PTNM_TUCHOI";

        public const string PTNM_CHODUYET_DESCRIPTION = "Chờ duyệt";
        public const string PTNM_DADUYET_DESCRIPTION = "Đã duyệt";
        public const string PTNM_TUCHOI_DESCRIPTION = "Từ chối";


        #endregion

        #region TRẠNG THÁI PHIẾU YÊU CẦU SỬA CHỮA

        public const string Config_PBMacDinhCoDien = "Config_PBMacDinhCoDien";
        public const string CATEGORY_YCSC = "YCSC";
        public const string YCSC_CHOTIEPNHAN = "YCSC_CHOTIEPNHAN";
        public const string YCSC_DATIEPNHAN = "YCSC_DATIEPNHAN";
        public const string YCSC_CHOPHANCONG = "YCSC_CHOPHANCONG";
        public const string YCSC_DAPHANCONG = "YCSC_DAPHANCONG";


        public const string YCSC_CHOTIEPNHAN_DESCRIPTION = "Chờ tiếp nhận";
        public const string YCSC_DATIEPNHAN_DESCRIPTION = "Đã tiếp nhận";
        public const string YCSC_CHOPHANCONG_DESCRIPTION = "Chờ phân công";
        public const string YCSC_DAPHANCONG_DESCRIPTION = "Đã phân công";

        #endregion

        #region Yêu cầu sửa chữa
        public const string NofMessage_YCSC = "NofMessage_YCSC";
        public const string NofMessage_YCSCDUYET = "NofMessage_YCSCDUYET";
        #endregion
        /*---------------------------------------------------------------------------------------------------------------*/


        /*-----------------------------------------------------QUI TRÌNH ------------------------------------------------*/

        #region QUI TRÌNH

        #region ID LOẠI PHIẾU QUI TRÌNH ĐỘNG

                #region THÔNG TIN HÀNG VỀ
                public const int QTD_TTHANGVE = 11;
                public const int QTD_TTHANGVE_DETAIL = 20;
                #endregion

                #region ĐỀ NGHỊ MUA HÀNG
                    public const int QTD_DENGHIMUAHANG_CHUAGUIMH = 17;
                    public const int QTD_DENGHIMUAHANG_GUIMUAHANG_KOVUOTHANMUC = 18;
                    public const int QTD_DENGHIMUAHANG_GUIMUAHANG_VUOTHANMUC = 19;
                #endregion

                #region ĐỀ NGHỊ NHẬP KHO
                public const int QTD_DENGHINHAPKHO = 9;
                public const int QTD_DENGHINHAPKHOPTCHITIET = 26;
                public const int QTD_DENGHINHAPKHOCHITIET = 27;
                public const int QTD_DENGHINHAPKHOCHITIETCHUYENNHAPKHO = 35;
                #endregion

                #region ĐỀ NGHỊ XUẤT KHO
                public const int QTD_DENGHIXUATKHO = 4;
                public const int QTD_DENGHIXUATKHO_XUATKHO = 36;
                public const int QTD_DENGHIXUATKHOCHITIET = 28;
                public const int QTD_DENGHIXUATKHOTUDONGTAO = 71;
                #endregion

                #region NHẬP/XUẤT KHO
                public const int QTD_NHAPKHO = 2;
                public const int QTD_XUATKHO = 5;
                public const int QTD_CHUYENKHO = 6;
                #endregion

                #region KẾ HOẠCH NCC GIAO HÀNG
                public const int QuyTrinh_KeHoachXacNhanGiaoHang = 41;
                #endregion

                #region PHIẾU YÊU CẦU NGHIÊN CỨU
                public const int QTD_PHIEUYEUCAU = 30;
                #endregion

                #region YÊU CẦU BÁO GIÁ
                public const int QTD_YEUCAUBAOGIA_MASTER = 32;
                public const int QTD_YEUCAUBAOGIA_DETAIL = 33;
                #endregion

                #region YÊU CẦU DUYỆT GIÁ
                public const int QTD_YEUCAUDUYETGIA_MASTER = 34;
                #endregion

                #region KIỂM TRA HÀNG HÓA

                public const int QTD_KIEMTRAHANGHOA = 48;
                public const int QTD_XEMXETHANGHOA = 50;
                public const int QTD_PHEDUYETHANGHOA = 51;

                #endregion

                #region NHẬT KÝ GỬI MẪU

                    public const int QTD_NHATKYGUIMAU = 53;

                #endregion

                #region BOM
                public const int QTD_BOM_MASTER = 47;
                #endregion

                #region BOM
                public const int QTD_SPEC_MASTER = 54;
                #endregion

                #region Hợp đồng
                public const int QTD_HDMH_MASTER = 65;
                #endregion

                #region KẾ TOÁN
                public const int QTD_PHIEUCHI_MASTER = 46;
                public const int QTD_UyNhiemChi_MASTER = 60;
                #endregion

                #region QUY TRÌNH SẢN XUẤT
                public const int QTD_QTSX_MASTER = 52;
                public const int QTD_QTSX_NVQC_XACNHAN = 62;
                public const int QTD_QTSX_QLSX_XACNHAN = 63;
                public const int QTD_QTSX_GDCL_XACNHAN = 64;
                #endregion

                #region YÊU CẦU XUẤT KHẨN
                public const int QTD_YCXK_TPDUYET = 55;
                public const int QTD_YCXK_QCPASSHANG = 56;
                public const int QTD_YCXK_TPQCDUYET = 58;
                public const int QTD_YCXK_THONGBAOTP = 72;
                #endregion

                #region KẾ HOẠCH SẢN XUẤT

                    public const int QTD_KEHOACHSANXUAT = 67;
                    public const int QTD_BAOCAOKEHOACHSANXUATTHEOTUAN = 73;
                    public const int QTD_KEHOACHSANXUATTHEOTUAN = 74;

                #endregion
                
                #region LỆNH SẢN XUẤT BỔ SUNG
                    public const int QTD_LENHSANXUATBOSUNG = 70;
                #endregion

                #region HẠN MỨC PHÒNG BAN
                public const int QTD_HANMUCPHONGBAN = 39;
                #endregion

        #endregion

        #endregion

        #region MESSAGE THÔNG BÁO CHO NOTIFICE

        #region DÙNG CHUNG
        public const string Header_Description = "Mặt hàng";
        public const string StrongStart = "<strong>";
        public const string StrongEnd = "</strong>";

        public const string NofMessage_DaDuyet = "NofMessage_DaDuyet";
        public const string NofMessage_DaXacNhan = "NofMessage_DaXacNhan";
        public const string NofMessage_KhongDuyet = "NofMessage_KhongDuyet";

        public const string NofMessage_DeNghiDaDuyet = "NofMessage_DeNghiDaDuyet";
        public const string NofMessage_DeNghiKhongDuyet = "NofMessage_DeNghiKhongDuyet";
        #endregion

        #region PHÂN HỆ KHO

        #region THÔNG TIN HÀNG VỀ
        public const string NofMessage_TPDuyetPassHang = "NofMessage_TPDuyetPassHang";
        public const string NofMessage_GDCLDuyetPassHang = "NofMessage_GDCLDuyetPassHang";
        public const string NofMessage_GDCLDaDuyet = "NofMessage_GDCLDaDuyet";
        #endregion

        #region ĐỀ NGHỊ NHẬP KHO
        public const string NofMessage_DeNghiNhapKho = "NofMessage_DeNghiNhapKho";
        public const string NofMessage_DeNghiDuyetDNNhapKho = "NofMessage_DeNghiDuyetDNNhapKho";
        #endregion

        #region ĐỀ NGHỊ XUẤT KHO
        public const string NofMessage_DaDuyet_DNXK = "NofMessage_DaDuyet_DNXK";
        public const string NofMessage_KhongDuyet_DNXK = "NofMessage_KhongDuyet_DNXK";
        public const string NofMessage_DeNghiXuatKho = "NofMessage_DeNghiXuatKho";
        public const string NofMessage_DeNghiDuyetDNXuatKho = "NofMessage_DeNghiDuyetDNXuatKho";
        public const string NofMessage_DaXacNhan_DNXK = "NofMessage_DaXacNhan_DNXK";
        #endregion

        #region XUẤT KHO
        public const string NofMessage_XacNhanXuatKhoiVTK = "NofMessage_XacNhanXuatKhoiVTK";
        #endregion

        #endregion

        #region PHÂN HỆ MUA HÀNG

        #region ĐỀ NGHỊ MUA HÀNG
        public const string NofMessage_DNDuyetMH = "NofMessage_DNDuyetMH";
        public const string NofMessage_DNMH = "NofMessage_DNMH";
        #endregion

        #region KẾ HOẠCH NCC GIAO HÀNG
        public const string NofMessage_KHNCCGH = "NofMessage_KHNCCGH";
        public const string NofMessage_KHNCCGH_KDuyet = "NofMessage_KHNCCGH_KDuyet";
        public const string NofMessage_KHNCCGH_Duyet = "NofMessage_KHNCCGH_Duyet";
        #endregion

        #endregion

        #region PHÂN HỆ MUA HÀNG

        #region PHIẾU KIỂM TRA

        public const string NofMessage_ChoKiemTra = "NofMessage_ChoKiemTra";

        #endregion

        #endregion

        #endregion

        /*---------------------------------------------------------------------------------------------------------------*/


        /*-------------------------------------------------- ID Loại Hàng Hóa -------------------------------------------*/

        #region DÒNG SẢN PHẨM

            public const int DSP_ADFD = 1;
            public const int DSP_VIEN = 2;
            public const int DSP_HONHOP = 3;
            public const int DSP_BTP = 4;

        #endregion

        #region BÁN THÀNH PHẨM

        public const int ID_BANTHANHPHAM = 5;

        #endregion

        #region THÀNH PHẨM

            public const int ID_THANHPHAM = 4;

        #endregion

        #region NGUYÊN - PHỤ LIỆU

            public const int ID_NGUYENLIEU = 1;

            public const int ID_PHULIEU = 2;
            
            public const int ID_BAOBI = 6;

        #endregion

        /*---------------------------------------------------------------------------------------------------------------*/
    }
}
