using System.Text.RegularExpressions;
using System.Globalization;

namespace DaoMinhHieu0021867.Utils
{
    public static class Utils0021867De11005
    {
        /// <summary>
        /// Kiểm tra chuỗi có phải là số điện thoại hợp lệ
        /// </summary>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Định dạng số điện thoại Việt Nam
            string pattern = @"^(0|84|\+84)([0-9]{9})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        /// <summary>
        /// Kiểm tra chuỗi có phải là email hợp lệ
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CCCD có hợp lệ không
        /// </summary>
        public static bool IsValidCCCD(string cccd)
        {
            if (string.IsNullOrWhiteSpace(cccd))
                return false;

            // CCCD phải có 12 số
            if (cccd.Length != 12)
                return false;

            // CCCD chỉ được chứa số
            return cccd.All(char.IsDigit);
        }

        /// <summary>
        /// Chuẩn hóa chuỗi tìm kiếm
        /// </summary>
        public static string NormalizeSearchString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Loại bỏ dấu tiếng Việt
            input = RemoveVietnameseTone(input);
            
            // Chuyển về chữ thường và cắt khoảng trắng thừa
            return input.ToLower().Trim();
        }

        /// <summary>
        /// Loại bỏ dấu tiếng Việt
        /// </summary>
        public static string RemoveVietnameseTone(string text)
        {
            string[] vietnameseChars = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            string[] replacementChars = new string[]
            {
                "aAeEoOuUiIdDyY",
                "aaaaaaaaaaaaaaa",
                "AAAAAAAAAAAAAAA",
                "eeeeeeeeeeee",
                "EEEEEEEEEEEE",
                "ooooooooooooooooo",
                "OOOOOOOOOOOOOOOOO",
                "uuuuuuuuuuu",
                "UUUUUUUUUUU",
                "iiiii",
                "IIIII",
                "d",
                "D",
                "yyyyy",
                "YYYYY"
            };

            for (int i = 1; i < vietnameseChars.Length; i++)
            {
                for (int j = 0; j < vietnameseChars[i].Length; j++)
                {
                    text = text.Replace(vietnameseChars[i][j], replacementChars[i][j]);
                }
            }

            return text;
        }

        /// <summary>
        /// Tạo mã ngẫu nhiên với độ dài cho trước
        /// </summary>
        public static string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Format số tiền theo định dạng tiền Việt Nam
        /// </summary>
        public static string FormatCurrency(decimal amount)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            return string.Format(cultureInfo, "{0:C0}", amount);
        }

        /// <summary>
        /// Tính thời gian sửa chữa (từ lúc bắt đầu đến lúc kết thúc)
        /// </summary>
        public static string CalculateRepairDuration(DateTime startTime, DateTime? endTime)
        {
            if (!endTime.HasValue)
                return "Đang sửa chữa";

            TimeSpan duration = endTime.Value - startTime;
            
            if (duration.TotalDays >= 1)
            {
                return $"{Math.Floor(duration.TotalDays)} ngày {duration.Hours} giờ";
            }
            else if (duration.TotalHours >= 1)
            {
                return $"{duration.Hours} giờ {duration.Minutes} phút";
            }
            else
            {
                return $"{duration.Minutes} phút";
            }
        }

        /// <summary>
        /// Kiểm tra ngày hợp lệ (không trong tương lai và không quá xa quá khứ)
        /// </summary>
        public static bool IsValidDate(DateTime date)
        {
            var now = DateTime.Now;
            var minDate = new DateTime(2000, 1, 1);

            return date <= now && date >= minDate;
        }

        /// <summary>
        /// Tính tổng thời gian sửa chữa của một kỹ thuật viên (tính bằng giờ)
        /// </summary>
        public static double CalculateTotalRepairHours(IEnumerable<DateTime> startTimes, IEnumerable<DateTime?> endTimes)
        {
            double totalHours = 0;
            var repairs = startTimes.Zip(endTimes, (start, end) => new { Start = start, End = end });

            foreach (var repair in repairs)
            {
                if (repair.End.HasValue)
                {
                    totalHours += (repair.End.Value - repair.Start).TotalHours;
                }
            }

            return Math.Round(totalHours, 2);
        }
    }
} 