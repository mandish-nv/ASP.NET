using System;
//method overriding is a condition in which superclass and subclass have
//same method with same signature (same name, same return type, same parameter)
//two keyboard are used in method overriding
//1. virtual keyword: used to denote overriden method of superclass
//2. override keyword: used to denote overriden method of subclass
//when overriden method is caleed from subclass object then subclass version
//of overriden method is called so to call superclass version of overriden
//method base keyword should be used
//method overriding is used to achieve dynamic polymorphism (run-time)

namespace CSIT
{
    class Solve
    {
        public virtual void calc1()
        {
            Console.WriteLine("Default method of superclass");
        }
        public virtual void calc2(int x, int y)
        {
            Console.WriteLine("Sum is " + (x+y));
        }
    }

    class Answer: Solve
    {
        public override void calc1()
        {
            base.calc1 (); // calls superclass overriden method calc1()
            Console.WriteLine("Default method of subclass");
        }
        public override void calc2(int x, int y)
        {
            base.calc2(x, y);
            Console.WriteLine("Difference is " + (x - y));
        }
    }
}
