using System;
//such class whose object cannot be created and declared using
//abstract keyword. It is used to hide complex detail of class
//it's object cannot be breated
//it can have instance variable, method and constructor
//it can have abstract method: such method which is declared only
//but not initialized (no body part)
//normal class should inherit abstract class and such normal class
//hvae to provide body part od all the abstract method

namespace CSIT
{
    abstract class Question
    {
        //it can have instance variable
        private int x;
        private int y;
        //it can have constructor
        public Question(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        //normal method 
        public void displaySum()
        {
            Console.WriteLine("Sum is " + (x + y));
        }
        //it can have abstract method
        public abstract void displayDiff(int x, int y);
        public abstract void displayMulti(int x, int y);
    }

    //abstract class should be used by normal class
    class Ans1 : Question
    {
        private int x1;
        private int y1;
        public Ans1(int x1, int y1): base(x1, y1)
        {
            this.x1 = x1;
            this.y1 = y1;
        }

        //normal method
        public void displayDiv()
        {
            Console.WriteLine("Div is " + (x1/y1));
        }

        //providing body of abstract method
        public override void displayDiff(int x, int y)
        {
            Console.WriteLine("Difference is " + (x1 - y1));
        }
        public override void displayMulti(int x, int y)
        {
            Console.WriteLine("Multiplication is " + (x1 * y1));
        }
    }
}
