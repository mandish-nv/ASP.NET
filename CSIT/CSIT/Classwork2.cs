using System;
//Create a class vehicle having instance variable 
//reg(int), name(string), brand(string) and two method to set and return
//value of instance variable. Create another class Car that inherits Vehicle having
//instance variable mileage and methods to set and return the value of instance
//variable. Now create any two object of car and display detail of car that have greater mileage.

namespace CSIT
{
    class Vehicle
    {
        private int reg;
        private string name;
        private string brand;

        public void setVehicle(int reg, string name, string brand)
        {
            this.reg = reg;
            this.name = name;
            this.brand = brand;
        }
        public void displayVehicle()
        {
            Console.WriteLine("Reg is " + reg + " Name is " + name + " Brand is " + brand);
        }
    }

    class Car: Vehicle
    {
        private int mileage;

        public void setCar(int mileage)
        {
            this.mileage = mileage;
        }
        public void displayCar()
        {
            Console.WriteLine("Mileage is " + mileage);
        }
        public int Mileage
        {
            get { return mileage; }
        }
    }
}
