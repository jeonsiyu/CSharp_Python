using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager
{
    public partial class Form1 : Form, IRefresh
    {   
        delegate void BtnEvent(object s, EventArgs e);
        public Form1()
        {
            InitializeComponent();
            RefreshScreen();
            dataGridView1.CellClick += delegate (object o, DataGridViewCellEventArgs e)
            {
                DataGridView thisView = o as DataGridView; //이벤트 발생시키는 주체
                Book selectBook = thisView.CurrentRow.DataBoundItem as Book;
                textBox1.Text = selectBook.isbn;
                textBox2.Text = selectBook.name;
            };
            dataGridView2.CellClick += (o, e) =>
            {
                User selectUser = (o as DataGridView).CurrentRow.DataBoundItem as User;
                textBox3.Text = selectUser.id;
            };

            BtnEvent borrowEvent = delegate (object s, EventArgs e) //대여
            {
                if (textBox1.Text.Trim().Equals(""))
                    MessageBox.Show("ISBN을 입력하셔야 도서 대출이 가능합니다.");
                else if (textBox3.Text.Trim().Equals(""))
                    MessageBox.Show("회원 ID를 알아야 도서 대출이 진행됩니다.");
                else
                {
                    try
                    {
                        //Single = 괄호 안에 있는 메서드가 true 반환하는 조건인 것 하나를 가져옴
                        //깊은 복사가 아니라 얕은 복사로 가져 옴
                        //즉 book이 값이 바뀌면 books에도 영향을 줌
                        //만약에 저 조건에 해당하는 게 없으면 예외를 던짐, 즉 Exception부분으로 이동해버림
                        Book book = DataManager.books.Single(item => item.isbn.Equals(textBox1.Text));
                        if (book.isBorrowed)
                            MessageBox.Show("이미 누군가가 빌려갔습니다.");
                        else
                        {
                            try
                            {
                                User u = DataManager.users.Single(item => item.id.Equals(textBox3.Text));
                                book.userId = u.id;
                                book.userName = u.name;
                                book.isBorrowed = true;
                                book.borrowedAt = DateTime.Now;
                                RefreshScreen();
                                DataManager.Save();
                                MessageBox.Show($"{book.isbn}책을 {u.id}님이 대출합니다.");

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("해당 ID를 가진 회원은 없으므로 도서 대출 불가능");
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("해당 ISBN은 존재하지 않으므로 대출 불가능합니다.");
                    }
                }
            };
            BtnEvent returnEvent = (s, e) => //반납
            {
                if (textBox1.Text.Trim().Equals(""))
                    MessageBox.Show("ISBN이 없어서 반납이 불가능합니다.");
                else
                {
                    try
                    {
                        Book book = DataManager.books.Single
                        (delegate (Book item) { return item.isbn.Equals(textBox1.Text); });
                        if (book.isBorrowed == false)
                            MessageBox.Show("아직 안 빌렸으므로 반납 불가능");
                        else
                        {
                            book.userId = ""; //book을 수정하면 books에 영향을 줌
                            book.userName = "";
                            book.isBorrowed = false;

                            //연체 여부 체크
                            DateTime oldDay = book.borrowedAt;
                            book.borrowedAt = new DateTime();//반납 했으므로 날짜 초기화

                            TimeSpan timeDiff = DateTime.Now - oldDay;
                            if (timeDiff.Days > 7)
                                MessageBox.Show("연체 반납");
                            else
                                MessageBox.Show("정상반납");
                            RefreshScreen();
                            DataManager.Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("해당 ISBN은 존재하지 않으므로 반납 불가능합니다.");
                    }
                }
            };

            button1.Click += new EventHandler(borrowEvent);
            button2.Click += new EventHandler(returnEvent);

        }
        bool checklsBorrowed(Book item)
        {
            return item.isBorrowed;
        }

        public void RefreshScreen()
        {
            label1.Text = "전체 도서 수 : " + DataManager.books.Count; //이 때 Load() 호출됨
            label2.Text = "전체 회원 수 : " + DataManager.users.Count;
            label3.Text = "대출 중인 도서의 수: ";
            //label3.Text += DataManager.books.Where(item => item.isBorrowed).Count(); 
            label3.Text += DataManager.books.Where(checklsBorrowed).Count();
            label4.Text = "연체 중인 도서의 수 : ";
            label4.Text += DataManager.books.Where(delegate (Book item)
            {
                return item.isBorrowed && item.borrowedAt.AddDays(7) < DateTime.Now;
            }).Count();
         

            dataGridView1.DataSource = null;
            if (DataManager.books.Count > 0)
                dataGridView1.DataSource = DataManager.books;

            dataGridView2.DataSource = null;
            if (DataManager.users.Count > 0)
                dataGridView2.DataSource = DataManager.users;

        }

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide(); //현재 창 숨김
            Form2 f = new Form2();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog(); //모달, 뒤에 꺼 선택 못 하고, 코드가 이 지점에 멈춤
            RefreshScreen(); //창 보여주기 전에 갱신 
            Show(); //현재 창 보이게 함

        }

        private void 사용자관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 f = new Form3();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            RefreshScreen();
            Show();
        }
    }
}
