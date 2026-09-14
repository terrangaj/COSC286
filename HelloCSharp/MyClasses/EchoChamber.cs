using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class EchoChamber
    {
        private int repeat;
        public int Repeat
        {
            get { return repeat; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                repeat = value;
            }
        }
        public string Last { get; private set; } = "";

        public EchoChamber(int nRepeat)
        {
            if (nRepeat <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.repeat = nRepeat;
            }
        }
        public EchoChamber()
        {
            this.repeat = 3;
        }

        public string Echo(string text)
        {
            string newString = "";
            Last = text;
            for (int i = 0; i< Repeat; i++)
            {
                newString += text;
            }
            return newString;
        }
        public override string ToString() 
        {
           return Last;
        }
    }
}
