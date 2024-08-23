using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpProject
{
    public class FilterInit
    {
        public static int comboIndex = 1;
        public static string min = "1";
        public static string max = "1";
        public static int minamount;
        public static int maxamount;
        public string[] label6help =
        {
        "Lot : 정수를 입력합니다.",
        "Time : 오전 또는 오후 입력 후 한칸 띄우고\n한 자리 또는 두 자리수로 시,분 입력,\n소수점 한자리를 포함한 초를 넣습니다.\n예시 : 오후 10:00:00 ",
        "pH : 소수 또는 정수를 입력합니다.",
        "Current : 소수 또는 정수를 입력합니다.",
        "Voltage : 소수 또는 정수를 입력합니다."
        };
        public string[] combolist = new string[] { "Lot", "Time", "pH", "Current", "Voltage" };
    }
}
