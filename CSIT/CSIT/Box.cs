using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIT
{
    //properties -> used to set and return the value of instance variable
    //it is like getter and setter method
    class Box
    {
        //instance variable
        private int length;
        private int breadth;
        private int height;

        //using properties to set and return value of length
        public int Length
        {
            set { length = value; }
            get { return length; }
        }
        public int Breadth
        {
            set { breadth = value; }
            get { return breadth; }
        }
        public int Height
        {
            set { height = value; }
            get { return height; }
        }
    }
}
