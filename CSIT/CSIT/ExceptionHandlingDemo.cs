using System;
//exception is any abnrmal condition that disturb normal flow of program
//when exception occur then program will directly stop so to handle such
//exception, exception handling is used
//keyword used in exception handling:
//1. try: used to surround a code from which exception can be generated
//2. catch: used to handle error generated from try block
//3. throw: used to throw own exception (custom exception) from any line of code
//4. finally: always executed block whether exception occur or not

namespace CSIT
{
    class ExceptionHandlingDemo
    {
        //taking input from user and dividing it by 0
        public void setData()
        {
            Console.WriteLine("Enter first number: ");
            int x1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int y1 = Int32.Parse(Console.ReadLine()); // by default only string input
            try
            {
                int res = x1 / y1; //if y = 0 then error occurs
                Console.WriteLine("Div is " + res);
            }
            catch (DivideByZeroException d)
            {
                Console.WriteLine("Denominator should not be 0" + d);
            }
            catch (Exception e) //for all
            {
                Console.WriteLine("ERROR OCCURS" + e);
            }
            finally
            {
                Console.WriteLine("Always executed");
            }
            Console.WriteLine("Out of try catch block");
        }
    }
}
