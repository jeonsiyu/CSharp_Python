using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager
{
    public partial class Form3 : Form, IRefresh
    {
        public Form3()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            // 무명델리게이트
            button2.Click += delegate (object o, EventArgs e)
            {
                try
                {
                    User u = DataManager.users.Single(item => item.id.Equals(textBox1.Text));
                    u.name = textBox2.Text; //u가 바뀌면 users 내용도 같이 바뀜
                    try //만약 빌린 책이 있다면 그 책에 대해서도 고객의 이름을 바꿔줘야 함
                    {
                        //해당 고객이 1권 혹은 여러 권 빌릴 수 있으므로 List 사용
                        List<Book> bookList = (from item in DataManager.books
                                               where item.userId.Equals(textBox1.Text)
                                               select item).ToList();
                        for (int i = 0; i < bookList.Count; i++)
                            bookList[i].userName = textBox2.Text;
                    }
                    catch (Exception)
                    {

                    }
                    RefreshScreen();
                    DataManager.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("해당 회원이 없어서 수정 작업 불가능");
                }
            };
            // 람다
            button3.Click += (o, e) =>
            {
                // 이미 책을 빌린 회원의 경우, 어떻게 처리 할 지는 스스로 추가적으로 더 고민해보기
                try
                {
                    User u = DataManager.users.Single(item => item.id.Equals(textBox1.Text));
                    DataManager.users.Remove(u);//얕은 복사이므로 Remove를 써도 그 위치가 지워짐
                    RefreshScreen();
                    DataManager.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("해당 ID인 회원이 없어 삭제 불가능");
                }
            };
            dataGridView1.CellClick += DataGridView1_CellClick;
            RefreshScreen();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            User selectUser = (sender as DataGridView).CurrentRow.DataBoundItem as User;
            textBox1.Text = selectUser.id;
            textBox2.Text = selectUser.name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Exists의 매개변수는 콜백함수
            //반환형 bool, item은 users에 있는 각 인스턴스들(=객체들)을 의미함
            if (DataManager.users.Exists(item => item.id.Equals(textBox1.Text)))
                MessageBox.Show("ID 중복! 생성 불가!");
            else
            {
                User newUser = new User();
                newUser.id = textBox1.Text;
                newUser.name = textBox2.Text;
                DataManager.users.Add(newUser);
                RefreshScreen();
                DataManager.Save();
            }
        }

        public void RefreshScreen()
        {
            dataGridView1.DataSource = null;
            if(DataManager.users.Count > 0)
            {
                dataGridView1.DataSource = DataManager.users;
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "이름"; ;

            }
        }

    }
}
