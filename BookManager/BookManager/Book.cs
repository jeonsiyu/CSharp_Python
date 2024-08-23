using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    public class Book
    {
        public string isbn { get; set; }
        public string name { get; set; }
        public string userId { get; set; } //빌린 사람의 ID
        public string userName { get; set; }//빌린 사람의 이름
        public bool isBorrowed { get; set; }//대여 여부
        public DateTime borrowedAt { get; set; } //언제 빌렸는 지
    }
}
