using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Create a class rectangle having instance variable length and breadth both in double.
//Now, create properties for it and calculate perimeter and area in Main method.
namespace CSIT
{
    class Rectangle
    {
        double length;
        double breadth;

        public double Length
        {
            set { length = value; }
            get { return length; }
        }
        public double Breadth
        {
            set { breadth = value; }
            get { return breadth; }
        }
    }
}
