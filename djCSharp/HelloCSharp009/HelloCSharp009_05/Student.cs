using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp009_05
{
    //클래스를 dataGridView에 적용하려면
    //클래스 완성하고 나서 프로그램을 한 번 껐다켜거나
    //혹은 프로젝트 빌드를 다시 해야 함(정리->다시빌드->빌드)
    //이 작업을 안 하게 되면... dataGridView에 Student 클래스가 안 보일 것임...
    public class Student
    {
        public string name { get; set; }
        public string hakbeon { get; set; }
        public string major { get; set; }
        public string etc; //기타 특이사항, {get;set;}이 없어서 dataGridView에 적용이 안 될 것임...
    }
}
