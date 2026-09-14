using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class MyString : IComparable
    {
        private string _stringField;

        public string StringField { get; set; }

        // Added: CompareTo relies on this, but it was never defined
        public int StringLength
        {
            get { return _stringField.Length; }
        }

        public MyString(string s)
        {
            if (s == "3")
            {
                s = "3 which is the best numbeR!!!";
            }
            _stringField = s;
        }

        public MyString()
        {
            _stringField = "3";
        }

        public override string ToString()
        {
            return "My string is " + _stringField;
        }

        /**
         * We need to implement CompareTo in order to implement
         * the ICompare interface
         * The return value is based off comparing the current object to one passed in:
         * Returns negative if this object precedes the passed in object
         * Returns a positive if this object comes after the passed in object
         * Returns zero if the objects are in the same position
         */
        public int CompareTo(object obj)
        {
            int result = 0;
            // let's compare based on length
            // in case of a tie, compare alphabetically
            MyString other = (MyString)obj;
            if (this.StringLength == other.StringLength)
            {
                return this.StringField.CompareTo(other.StringField);
            }
            else
            {
                result = this.StringLength - other.StringLength;
            }
            return result;
        }

        public static bool operator < (MyString left, MyString right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(MyString left, MyString right)
        {
            return left.CompareTo(right) > 0;
        }
    }
}