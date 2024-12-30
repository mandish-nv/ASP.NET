using System;
//custom exception means generating own error. To create own error:
//1. create error class by inheriting superclass exception
//2. create constructor that will call superclass constructor with 
//error message by using base keyword
//3. use throw clause to throw own error

namespace CSIT
{
    //when age is less than 16 throw error
    class AgeError : Exception //error class
    {
        public AgeError(string message) : base(message){ }
    }
    class CustomExceptionDemo
    {
        public void sendAge(int age)
        {
            if (age <= 16)
            {
                throw new AgeError("Age should be greater than 16");
            }
            else
            {
                Console.WriteLine("Welcome");
            }
        }
    }
}
