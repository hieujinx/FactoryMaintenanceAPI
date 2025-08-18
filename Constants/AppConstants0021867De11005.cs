namespace DaoMinhHieu0021867.Constants
{
    public static class AppConstants0021867De11005
    {
        public static class Validation
        {
            public const int MaxPageSize = 50;
            public const int DefaultPageSize = 10;
            public const int DefaultPageIndex = 1;

            public const int MaxMaKyThuatVienLength = 50;
            public const int MaxTenKyThuatVienLength = 100;
            public const int CCCDLength = 12;

            public const int MaxMaThietBiLength = 50;
            public const int MaxTenThietBiLength = 100;
        }

        public static class ErrorMessages
        {
            public const string TechnicianNotFound = "Không tìm thấy kỹ thuật viên";
            public const string DuplicateMaKyThuatVien = "Mã kỹ thuật viên đã tồn tại";
            public const string DuplicateTenKyThuatVien = "Tên kỹ thuật viên đã tồn tại";
            public const string DuplicateCCCD = "CCCD đã tồn tại";
            public const string InvalidPageSize = "Kích thước trang không hợp lệ";
            public const string InvalidPageIndex = "Số trang không hợp lệ";
        }

        public static class SuccessMessages
        {
            public const string DeleteTechnicianSuccess = "Xóa kỹ thuật viên thành công";
        }
    }
} 