using System;
using System.Security.Cryptography;
//constructor of superclass (parent) cannot be called from
//subclass's object. So to call superclass constructor "base"
//keyword is used
//uses of base keyword:
//1. to call superclasss constructor
//2. method overriding

namespace CSIT
{
    class Calculation
    {
        private int x1;
        private int y1;
        //default constructor of parent
        public Calculation()
        {
            Console.WriteLine("Default constructor of super class");
        }
        //parameterized constructor
        public Calculation(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        public void calcSum()
        {
            Console.WriteLine("Sum = " + (x1+ y1));
        }
    }

    class Solution : Calculation
    {
        private int x2;
        private int y2;
        //default constructo of child class
        public Solution()
        {
            Console.WriteLine("Default constructor of sub class");
        }
        public Solution(int x2, int y2, int x1, int y1):base(x1,y1)
        {
            this.x2 = x2;
            this.y2 = y2;
        }
        public void calcDiff()
        {
            Console.WriteLine("Diff = " + (x2-y2));
        }
    }
}
