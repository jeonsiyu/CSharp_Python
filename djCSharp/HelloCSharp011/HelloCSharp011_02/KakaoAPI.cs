using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HelloCSharp011_02
{
    public class KakaoAPI
    {
        public static List<Locale> Search(string text)
        {
            List<Locale> list = new List<Locale>();
            string site = "https://dapi.kakao.com/v2/local/search/keyword.json";
            string query = $"{site}?query={text}";
            string restApiKey = "99c8dc6a66407eaf5b364cf322975a29";
            string header = $"KakaoAK {restApiKey}";
            //요청 생성
            WebRequest req = WebRequest.Create(query);
            req.Headers.Add("Authorization", header);
            //응답 받기
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            string json = sr.ReadToEnd();
            //using System.Web.Script.Serialization;
            //안 될 경우
            //https://stackoverflow.com/questions/19467109/how-to-fix-error-type-system-web-script-serialization-javascriptserializer-is
            //프로젝트 마우스 오른쪽 클릭 -> 추가 -> 참조 -> 프레임워크
            //여기서 System.Web.Extensions를 추가 
            JavaScriptSerializer js = new JavaScriptSerializer();
            //dynamic = javaScript의 let같은 것 
            //C#의 var는 한 번 타입이 정해지면 타입 변경 안 됨
            //dynamic은 타입 변경 됨

            dynamic dob = js.Deserialize<dynamic>(json);
            dynamic docs = dob["documents"];
            object[] buf = docs;
            for(int i = 0; i<buf.Length; i++)
            {
                string local = docs[i]["place_name"];
                double x = double.Parse(docs[i]["x"]);
                double y = double.Parse(docs[i]["y"]);
                list.Add(new Locale(local, y, x));
            }

            return list;
        }
    }
}
