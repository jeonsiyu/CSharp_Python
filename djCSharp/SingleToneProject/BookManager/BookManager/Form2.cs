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
    public partial class Form2 : Form, IRefresh
    {
        public Form2()
        {
            InitializeComponent();
            RefreshScreen();
        }

        public void RefreshScreen()
        {
            //dataGridView1.DataSource = null;
            //if (DataManager.books.Count > 0)
            //    dataGridView1.DataSource = DataManager.books;

            //bookBindingSource = Book 바인딩됨
            //바인딩 = 묶였음 = 연결됨 혹은 연동됨 이렇게 이해하면 됨
            //즉 서로 밀접한 연관이 있다.
            bookBindingSource.DataSource = null;
            if(DataManager.Instance.books.Count>0)
                bookBindingSource.DataSource = DataManager.Instance.books;

        }

        private void button1_Click(object sender, EventArgs e) //추가
        {
            bool existBook = false; 
            foreach(var item in DataManager.Instance.books)
            {
                if(item.isbn.Equals(textBox1.Text))
                {
                    existBook = true;
                    break;
                }
            }
            if(existBook)
                MessageBox.Show("ISBN 중복! 해당 책 이미 있음!");
            else
            {
                Book newBook = new Book();
                newBook.isbn = textBox1.Text;
                newBook.name = textBox2.Text;
                DataManager.Instance.books.Add(newBook); //새로운 책을 추가
                RefreshScreen();// 화면을 다시 갱신
                DataManager.Instance.Save(); //xml 파일에 저장하기 위함
            }
        }

        private void button2_Click(object sender, EventArgs e)//수정
        {
            Book book = null;
            for(int i = 0; i<DataManager.Instance.books.Count; i++)
            {
                if (DataManager.Instance.books[i].isbn.Equals(textBox1.Text))
                {
                    book = DataManager.Instance.books[i];//얕은 복사 수행
                    book.name = textBox2.Text;
                    RefreshScreen();
                    DataManager.Instance.Save();
                    break;
                }
            }
            if(book==null)
                MessageBox.Show("해당 책 없으니 수정 불가능");

        }

        private void button3_Click(object sender, EventArgs e)//삭제
        {
            bool existBook = false;
            for(int i = 0; i<DataManager.Instance.books.Count; i++)
            {
                if (DataManager.Instance.books[i].isbn.Equals(textBox1.Text))
                {
                    DataManager.Instance.books.RemoveAt(i);
                    existBook = true;
                    break;
                }
            }
            if(existBook)
            {
                RefreshScreen();
                DataManager.Instance.Save();
            }
            else
                MessageBox.Show("해당 책이 없으므로 삭제 불가능");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
            textBox1.Text = book.isbn;
            textBox2.Text = book.name;
        }
    }
}
