using System;
using System.Collections.Generic;

namespace LabAssignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            UserProfile();
            Vehicle();
            Calculator();
            EmployeeSalary();
            StudentConstructors();
            ProductValidation();
            LibraryManagement();
        }

        // Experiment 1
        static void UserProfile()
        {
            Console.WriteLine("\n--- Experiment 1: User Profile ---");

            UserProfile user1 = new UserProfile();
            user1.SetUsername("Jai Sony");
            user1.SetPassword("secret123");
            user1.SetEmail("jai@example.com");

            UserProfile user2 = new UserProfile();
            user2.SetUsername("Deepak Katara");
            user2.SetPassword("pass456");
            user2.SetEmail("deepak@example.com");

            Console.WriteLine($"User1: {user1.GetUsername()}, {user1.GetEmail()}");
            Console.WriteLine($"User2: {user2.GetUsername()}, {user2.GetEmail()}");
        }

        // Experiment 2
        static void Vehicle()
        {
            Console.WriteLine("\n--- Experiment 2: Vehicle Details ---");

            Vehicle truck = new Truck("Tata", "HeavyDuty", 2020);
            Vehicle bus = new Bus("Volvo", "Luxury", 2022);

            truck.DisplayDetails();
            bus.DisplayDetails();
        }

        // Experiment 3
        static void Calculator()
        {
            Console.WriteLine("\n--- Experiment 3: Calculator ---");

            Calculator calc = new Calculator();
            Console.WriteLine("Add(int,int): " + calc.Add(5, 10));
            Console.WriteLine("Add(float,float): " + calc.Add(2.5f, 3.5f));
            Console.WriteLine("Add(double,double,double): " + calc.Add(1.2, 2.3, 3.4));
        }

        // Experiment 4
        static void EmployeeSalary()
        {
            Console.WriteLine("\n--- Experiment 4: Employee Salary ---");

            Employee fullTime = new FullTimeEmployee("Jai", 50000);
            Employee partTime = new PartTimeEmployee("Deepak", 200, 80);

            Console.WriteLine($"{fullTime.Name} Salary: {fullTime.CalculateSalary()}");
            Console.WriteLine($"{partTime.Name} Salary: {partTime.CalculateSalary()}");
        }

        // Experiment 5
        static void StudentConstructors()
        {
            Console.WriteLine("\n--- Experiment 5: Student Constructors ---");

            Student s1 = new Student();
            Student s2 = new Student("Vijay", 101);
            Student s3 = new Student("Pavan", 102, 95);

            s1.Display();
            s2.Display();
            s3.Display();
        }

        // Experiment 6
        static void ProductValidation()
        {
            Console.WriteLine("\n--- Experiment 6: Product Validation ---");

            Product p1 = new Product { ProductID = 1, ProductName = "Laptop", Price = 50000, Quantity = 5 };
            Product p2 = new Product { ProductID = 2, ProductName = "Mouse", Price = -100, Quantity = 10 };

            p1.PrintDetails();
            p2.PrintDetails();
        }

        // Experiment 7
        static void LibraryManagement()
        {
            Console.WriteLine("\n--- Experiment 7: Library Management ---");

            Library library = new Library();
            library.RegisterMember(new Member("Vijay"));
            library.RegisterMember(new Member("Pavan"));

            library.AddBook(new Book("C# Basics"));
            library.AddBook(new Book("Java Advanced"));

            library.LendBook("C# Basics", "Vijay");
            library.LendBook("Java Advanced", "Pavan");
            library.DisplayAvailableBooks();
        }
    }

    // Experiment 1 Classes
    class UserProfile
    {
        private string username;
        private string password;
        private string email;

        public void SetUsername(string name) => username = name;
        public string GetUsername() => username;

        public void SetPassword(string pass)
        {
            if (pass.Length >= 6)
                password = pass;
            else
                Console.WriteLine("Password must be at least 6 characters.");
        }
        public string GetPassword() => password;

        public void SetEmail(string mail)
        {
            if (mail.Contains("@"))
                email = mail;
            else
                Console.WriteLine("Invalid email format.");
        }
        public string GetEmail() => email;
    }

    // Experiment 2 Classes
    class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"{Year} {Make} {Model}");
        }
    }

    class Truck : Vehicle
    {
        public Truck(string make, string model, int year) : base(make, model, year) { }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Truck: {Year} {Make} {Model}");
        }
    }

    class Bus : Vehicle
    {
        public Bus(string make, string model, int year) : base(make, model, year) { }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Bus: {Year} {Make} {Model}");
        }
    }

    // Experiment 3 Classes
    class Calculator
    {
        public int Add(int a, int b) => a + b;
        public float Add(float a, float b) => a + b;
        public double Add(double a, double b, double c) => a + b + c;
    }

    // Experiment 4 Classes
    abstract class Employee
    {
        public string Name { get; set; }
        public Employee(string name) => Name = name;
        public abstract double CalculateSalary();
    }

    class FullTimeEmployee : Employee
    {
        public double MonthlySalary { get; set; }
        public FullTimeEmployee(string name, double salary) : base(name) => MonthlySalary = salary;
        public override double CalculateSalary() => MonthlySalary;
    }

    class PartTimeEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public PartTimeEmployee(string name, double rate, int hours) : base(name)
        {
            HourlyRate = rate;
            HoursWorked = hours;
        }
        public override double CalculateSalary() => HourlyRate * HoursWorked;
    }

    // Experiment 5 Classes
    class Student
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public int Marks { get; set; }

        public Student() => Console.WriteLine("Default Constructor Called");
        public Student(string name, int roll)
        {
            Name = name;
            RollNumber = roll;
        }
        public Student(string name, int roll, int marks)
        {
            Name = name;
            RollNumber = roll;
            Marks = marks;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Roll: {RollNumber}, Marks: {Marks}");
        }
    }

    // Experiment 6 Classes
    class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        private double price;
        public double Price
        {
            get => price;
            set
            {
                if (value >= 0)
                    price = value;
                else
                {
                    price = 0;
                    Console.WriteLine("Price cannot be negative. Setting to 0.");
                }
            }
        }
        public int Quantity { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"ID: {ProductID}, Name: {ProductName}, Price: {Price}, Qty: {Quantity}");
        }
    }

    // Experiment 7 Classes
    class Book
    {
        public string Title { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Book(string title) => Title = title;
    }

    class Member
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public Member(string name) => Name = name;
    }

    class Library
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();

        public void AddBook(Book book) => books.Add(book);
        public void RegisterMember(Member member) => members.Add(member);

        public void LendBook(string title, string memberName)
        {
            Book book = books.Find(b => b.Title == title && b.IsAvailable);
            Member member = members.Find(m => m.Name == memberName);

            if (book != null && member != null)
            {
                book.IsAvailable = false;
                member.BorrowedBooks.Add(book);
                Console.WriteLine($"{memberName} borrowed \"{title}\"");
            }
            else
            {
                Console.WriteLine("Book not available or member not found.");
            }
        }

        public void DisplayAvailableBooks()
        {
            Console.WriteLine("\nAvailable Books:");
            foreach (var b in books)
                if (b.IsAvailable)
                    Console.WriteLine(b.Title);
        }
    }
}
