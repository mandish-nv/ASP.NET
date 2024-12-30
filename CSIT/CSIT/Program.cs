using System;

namespace CSIT
{
    class Program
    {
        static void Main(string[] args)
        {
            Box b1 = new Box();
            //setting and gettinf value of length, breadth and height for b1
            b1.Length = 1; //calls set of length
            int len1 = b1.Length;

            b1.Breadth = 30;
            int bre1 = b1.Breadth ;

            b1.Height = 40;
            int hei1 = b1.Height;

            int vol = len1 * bre1 * hei1;
            Console.WriteLine("Volume =  " + vol);



            //Classwork1
            Rectangle r1 = new Rectangle();
            r1.Length = 5;
            r1.Breadth = 10;

            double l = r1.Length;
            double b = r1.Breadth;

            double perimeter = 2 * (l + b);
            double area = l * b;

            Console.WriteLine("Perimeter = " + perimeter);
            Console.WriteLine("Area = " + area);


            //example on inheritance
            Console.WriteLine("\n--example on inheritance--");
            //create object of child class
            Student st1 = new Student();
            //accessing parent (person) property
            st1.setPerson(13, "Ram", "KTM");
            st1.displayPerson();
            //accessing own property
            st1.setStd("Science", "A+");
            st1.displayStd();
            //multilevel
            PrimaryStudent ps1 = new PrimaryStudent();
            //accessing grand parent (Person) property
            ps1.setPerson(5, "ram", "PKR");
            ps1.displayPerson();
            //accessing parent (Student) property
            ps1.setStd("Kindergarden", "A+");
            ps1.displayStd();
            //accessing own property
            ps1.setPrimary(5);
            ps1.displayPrimary();


            //Classwork 2
            Car c1 = new Car();
            Car c2 = new Car();

            c1.setVehicle(1, "Merce", "Des");
            c1.setCar(100);
            c2.setVehicle(1, "Lambo", "Des");
            c2.setCar(90);

            if (c1.Mileage > c2.Mileage)
            {
                c1.displayVehicle();
                c1.displayCar();
            }
            else
            {
                c2.displayVehicle();
                c2.displayCar();
            }


            Console.WriteLine("\n--Example on base keyword--");
            Solution sol1 = new Solution();
            Solution sol2 = new Solution(10,5,20,30);
            sol2.calcSum();//parent method
            sol2.calcDiff();//solution method


            Console.WriteLine("\n--Example on overriding--");
            Answer a1 = new Answer();
            a1.calc1();
            a1.calc2(20, 30);

            Console.WriteLine("\n--Example on Abstract class--");
            Ans1 ans1 = new Ans1(40, 50);
            ans1.displaySum();//normal method of abstract class
            ans1.displayDiv();//own method
            ans1.displayDiff(50, 40);//abstract method 1
            ans1.displayMulti(10, 5);//abstract method 2


            Console.WriteLine("\n--Example on Exception Handling--");
            ExceptionHandlingDemo ex1 = new ExceptionHandlingDemo();
            ex1.setData();

            Console.WriteLine("\n--Example on Custom Exception Handling--");
            CustomExceptionDemo ce1 = new CustomExceptionDemo();
            try
            {
                ce1.sendAge(11);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\n--Example on Interface--");
            InterfaceDemo ids = new InterfaceDemo();
            ids.calcSum(20, 30);
            ids.calcMulti(10, 5);
            ids.calcDiv(10, 5);
            //dynamic method dispatch: when Subclass's object is assigned
            //to reference variable of superclass then suhc reference
            //will call the subclass version of overriden method

            //superclass obj = subclass obj;
            //calls method of sub class

            Calc1 c; //reference variable of interface (obj cannot be created)
            c = ids; //dynamic method dispatch
            c.calcSum(20, 30);
            c.calcMulti(10, 5);

            Console.WriteLine("\n--Example on file handling--");
            FileHandlingDemo fh = new FileHandlingDemo();
            fh.writeFile();
            fh.readFile();



            Console.ReadKey();//hold screen
        }
    }
}
