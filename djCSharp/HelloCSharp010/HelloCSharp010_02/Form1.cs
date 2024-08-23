using Newtonsoft.Json.Linq; //Newtonsoft를 설치한 이유
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HelloCSharp010_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=2714055500";
            XElement xe = XElement.Load(url);
            List<Weather> weathers = (from item in xe.Descendants("data")
                                      where item.Element("day").Value.Equals("0") 
                                      select new Weather()
                                      {
                                          hour = item.Element("hour").Value,
                                          temp = item.Element("temp").Value,
                                          wfKor = item.Element("wfKor").Value,
                                          wfEn = item.Element("wfEn").Value,
                                      }).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = weathers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1000회차부터 지금까지의 정보를 dataGridView에 띄울 것
            string url = "https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo=";
            int count = 1000;
            List<Lotto> lottos = new List<Lotto>();
            while(true)
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url+count); //url에 있는 글자 가져오기
                    count++;
                    var jObj = JObject.Parse(json); //그 글자를 JSON 형태로 변환함
                    //if (jObj["returnValue"].ToString().Equals("success") == false)
                    if (jObj["returnValue"].ToString().Equals("fail"))
                        break;
                    lottos.Add(new Lotto()
                    {
                        drwNo = jObj["drwNo"].ToString(),
                        drwNoDate = jObj["drwNoDate"].ToString()
                    });

                }//wc는 이 중괄호 끝나면 소멸됨

            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = lottos;
        }
    }
}
