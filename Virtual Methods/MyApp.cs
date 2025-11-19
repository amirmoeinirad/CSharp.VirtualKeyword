
// Amir moeini Rad
// September 2025

// Main Concepts: 'virtual', 'override' and 'new' keywords

// 'virtual' means that the method can be overridden in a derived class.
// 'override' means that the method is overriding a base class virtual method.
// 'new' means that the method is hiding a base class method with the same name.
// 'new' is not recommended because it can lead to confusion and errors. It is not polymorphic.


using System;


namespace VirtualKeywordDemo
{
    internal class Person
    {
        // 'protected' access modifier allows access to derived classes.
        protected string firstName;
        protected string lastName;

        // Default constructor
        public Person()
        {
        }

        // Parameterized custom constructor
        public Person(string fn, string ln)
        {
            firstName = fn;
            lastName = ln;
        }

        // 'virtual' keyword allows this method to be overridden in derived classes.
        public virtual void DisplayFullName()
        {
            Console.WriteLine("Person: {0} {1}", firstName, lastName);
        }
    }


    //////////////////////////////////////////////////////////////////


    // A new class derived from Person...
    internal class Employee : Person
    {
        public ushort hireYear;

        // Default constructor
        // 'base()' calls the base class default constructor.
        public Employee() : base()
        {
        }

        // Parameterized custom constructor
        // 'base()' calls the base class parameterized constructor.
        public Employee(string fn, string ln, ushort hy) : base(fn, ln)
        {
            hireYear = hy;
        }

        // 'override' keyword indicates that this method is overriding a base class virtual method.
        public override void DisplayFullName()
        {
            Console.WriteLine("Employee: {0} {1}", firstName, lastName);
        }
    }


    //////////////////////////////////////////////////////////////////


    // A new class derived from Person...
    class Contractor : Person
    {
        public string company;

        // Default constructor
        public Contractor() : base()
        {
        }

        // Parameterized custom constructor
        public Contractor(string fn, string ln, string c) : base(fn, ln)
        {
            company = c;
        }

        // 'override' keyword indicates that this method is overriding a base class virtual method.
        public new void DisplayFullName()
        {
            Console.WriteLine("Contractor: {0} {1}", firstName, lastName);
        }
    }


    //////////////////////////////////////////////////////////////////


    // Main class
    class MyApp
    {
        public static void Main()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("'virtual', 'override' and 'new' keywords in C#.NET.");
            Console.WriteLine("---------------------------------------------------\n");


            Person person = new Person("Amir", "Rad");

            // CASE 1: Directly using the derived class type

            // In this case, the compiler knows the exact type of the object at compile time.
            // The 'virtual' and 'new' keywords affect method resolution.
            // 'virtual' methods are resolved at runtime, while 'new' methods are resolved at compile time.
            // However, whether you use 'virtual' or 'new' or even no keyword at all,
            // the method called is determined by the type of the reference variable.
            Employee employee1 = new Employee("Bradley", "Jones", 1983);
            Contractor worker1 = new Contractor("Carolyn", "Curry", "Microsoft");

            // CASE 2: Using the base class type to reference derived class objects

            // In this case, the compiler does not know the exact type of the object at compile time.
            // For instance, the variable 'employee2' is of type 'Person', but it references an 'Employee' object.
            // Here, the 'virtual' keyword allows the method to be resolved at runtime based on the actual object type.
            // Thus, the overridden method in the 'Employee' class is called.
            // But, if 'new' or no keyword was used in the 'Employee' class, the base class method would be called instead.
            // Replace 'override' with 'new' in the 'Employee' or 'Contractor' class to see the difference.
            Person employee2 = new Employee("Bradley", "Jones", 1983);
            Person worker2 = new Contractor("Carolyn", "Curry", "Microsoft");

            person.DisplayFullName();

            Console.WriteLine();

            employee1.DisplayFullName();
            worker1.DisplayFullName();

            Console.WriteLine();

            employee2.DisplayFullName();
            worker2.DisplayFullName();


            Console.WriteLine("\nDone.");
        }
    }
}