using System;

namespace LabAssignment3
{    
    class Program
    {
        
        static void Main()
        {
            Console.WriteLine("Choose Demo (1-10): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: Demo1(); break;
                case 2: Demo2(); break;
                case 3: Demo3(); break;
                case 4: Demo4(); break;
                case 5: Demo5(); break;
                case 6: Demo6(); break;
                case 7: Demo7(); break;
                case 8: Demo8(); break;
                case 9: Demo9(); break;
                case 10: Demo10(); break;
                default: Console.WriteLine("Invalid Choice"); break;
            }
        }

        static void Demo1()
        {
            Employee emp = new Employee { Name = "Ritik", Age = 23, Salary = 50000 };
            emp.DisplayDetails();
        }

        static void Demo2()
        {
            BankAccount acc = new BankAccount { AccountNumber = 101, HolderName = "Ritik" };
            acc.Deposit(5000);
            acc.Withdraw(2000);
            acc.DisplayAccount();
        }

        static void Demo3()
        {
            int[] nums = { 10, 20, 30, 40, 50 };
            Console.WriteLine("Average: " + MathHelper.CalculateAverage(nums));
        }

        static void Demo4()
        {
            Logger.LogMessage("Application Started");
            Logger.LogMessage("Performing operations...");
            Logger.LogMessage("Application Ended");
        }

        static void Demo5()
        {
            Person p = new Person { FirstName = "Ritik", LastName = "Mittal" };
            p.PrintFullName();
        }

        static void Demo6()
        {
            EmployeePartial emp = new EmployeePartial { Name = "Ritik", BaseSalary = 40000, Bonus = 5000 };
            Console.WriteLine($"{emp.Name}'s Total Salary: {emp.CalculateTotalSalary()}");
        }

        static void Demo7()
        {
            Shape c = new Circle { Radius = 5 };
            Shape r = new Rectangle { Length = 4, Width = 6 };
            Console.WriteLine("Circle Area: " + c.CalculateArea());
            Console.WriteLine("Rectangle Area: " + r.CalculateArea());
        }

        static void Demo8()
        {
            Animal dog = new Dog { Name = "Bruno", Age = 3 };
            Animal cat = new Cat { Name = "Kitty", Age = 2 };
            dog.MakeSound();
            cat.MakeSound();
        }

        static void Demo9()
        {
            Car c = new Car();
            c.StartEngine();
            c.Drive();
            c.StopEngine();
        }

        static void Demo10()
        {
            SavingsAccount sa = new SavingsAccount { AccountNumber = 202, Balance = 10000, InterestRate = 5 };
            sa.CalculateInterest();
        }

    }
    // 1. Employee (Instance Class) ==================
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Salary: {Salary}");
        }
    }

    // ================== 2. BankAccount (Instance Class) ==================
    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; private set; }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount}. Current Balance: {Balance}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount}. Current Balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance!");
            }
        }

        public void DisplayAccount()
        {
            Console.WriteLine($"Account No: {AccountNumber}, Holder: {HolderName}, Balance: {Balance}");
        }
    }

    // ================== 3. Static MathHelper ==================
    static class MathHelper
    {
        public static double CalculateAverage(int[] numbers)
        {
            if (numbers.Length == 0) return 0;
            double sum = 0;
            foreach (int num in numbers)
                sum += num;
            return sum / numbers.Length;
        }
    }

    // ================== 4. Static Logger ==================
    static class Logger
    {
        public static void LogMessage(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }

    // ================== 5. Partial Person ==================
    public partial class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public partial class Person
    {
        public void PrintFullName()
        {
            Console.WriteLine($"Full Name: {FirstName} {LastName}");
        }
    }

    // ================== 6. Partial Employee ==================
    public partial class EmployeePartial
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public double Bonus { get; set; }
    }

    public partial class EmployeePartial
    {
        public double CalculateTotalSalary()
        {
            return BaseSalary + Bonus;
        }
    }

    // ================== 7. Abstract Shape ==================
    abstract class Shape
    {
        public abstract double CalculateArea();
    }

    class Circle : Shape
    {
        public double Radius { get; set; }
        public override double CalculateArea() => Math.PI * Radius * Radius;
    }

    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public override double CalculateArea() => Length * Width;
    }

    // ================== 8. Abstract Animal ==================
    abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public abstract void MakeSound();
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} (Dog) says: Woof!");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} (Cat) says: Meow!");
        }
    }

    // ================== 9. Sealed Car ==================
    class Vehicle
    {
        public void StartEngine() => Console.WriteLine("Engine Started!");
        public void StopEngine() => Console.WriteLine("Engine Stopped!");
    }

    sealed class Car : Vehicle
    {
        public void Drive() => Console.WriteLine("Car is driving...");
    }

    // ================== 10. Sealed SavingsAccount ==================
    class BankAccountBase
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
    }

    sealed class SavingsAccount : BankAccountBase
    {
        public double InterestRate { get; set; }

        public void CalculateInterest()
        {
            double interest = Balance * InterestRate / 100;
            Console.WriteLine($"Interest: {interest}, Total Balance after Interest: {Balance + interest}");
        }
    }

}
