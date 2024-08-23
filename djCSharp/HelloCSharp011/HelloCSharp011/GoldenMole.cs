using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp011
{
    public class GoldenMole : Animal
    {
        public string hairColor { get; set; }
        private GoldenMole() { }
        private static GoldenMole instance;
        public static GoldenMole getInstance()
        {
            if(instance==null)
                instance = new GoldenMole();
            return instance;
        }
        public override void speak()
        {
            System.Windows.Forms.MessageBox.Show("...저... 잡아 먹지 마세요...");
        }
    }
}
