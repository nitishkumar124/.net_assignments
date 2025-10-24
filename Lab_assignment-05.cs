using System;

class Program
{
    static void ZeroDivisionDemo()
    {
        try
        {
            Console.WriteLine("Q1: Handling Division by Zero");
            Console.Write("Enter numerator: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter denominator: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int result = num1 / num2;
            Console.WriteLine("Result = " + result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Division by zero is not allowed.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter integers.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Entered number is too large or too small for Int32.");
        }
        finally
        {
            Console.WriteLine("Execution completed.\n");
        }
    }

    static void MultipleCatchDemo()
    {
        try
        {
            Console.WriteLine("Q2: Multiple Catch Blocks");
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You entered: " + number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter a valid integer.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Number too large or too small for an Int32.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Execution completed.\n");
        }
    }

    static void CheckSalary()
    {
        try
        {
            Console.WriteLine("Q3: Custom Exception — NegativeSalaryException");
            Console.Write("Enter salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            if (salary < 0)
                throw new NegativeSalaryException("Salary cannot be negative.");

            Console.WriteLine("Salary is valid: " + salary + "\n");
        }
        catch (NegativeSalaryException ex)
        {
            Console.WriteLine("Error: " + ex.Message + "\n");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid numeric value.\n");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The entered salary is too large or small.\n");
        }
    }

    static void WithdrawDemo()
    {
        double balance = 5000;
        try
        {
            Console.WriteLine("Q4: Banking Scenario — InsufficientBalanceException");
            Console.Write("Enter amount to withdraw: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount > balance)
                throw new InsufficientBalanceException("Insufficient balance for this withdrawal.");

            balance -= amount;
            Console.WriteLine("Withdrawal successful! Remaining balance is: " + balance + "\n");
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Error: " + ex.Message + "\n");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid numeric amount.\n");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The entered amount is too large or small.\n");
        }
    }

    static void ValidateMarks()
    {
        try
        {
            Console.WriteLine("Q5: Student Marks Validation");
            Console.Write("Enter student marks (0-100): ");
            int marks = Convert.ToInt32(Console.ReadLine());

            Student stu = new Student();
            stu.SetMarks(marks);

            Console.WriteLine("Marks set successfully: " + stu.Marks + "\n");
        }
        catch (InvalidMarksException ex)
        {
            Console.WriteLine("Error: " + ex.Message + "\n");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid integer for marks.\n");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The entered marks value is out of range for Int32.\n");
        }
    }

    static void Main(string[] args)
    {    
        ZeroDivisionDemo();
        MultipleCatchDemo();
        CheckSalary();
        WithdrawDemo();
        ValidateMarks();

        Console.WriteLine("All demos completed. Press any key to exit.");
        Console.ReadKey();
    }
}

public class NegativeSalaryException : Exception
{
    public NegativeSalaryException(string message) : base(message) { }
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public class InvalidMarksException : Exception
{
    public InvalidMarksException(string message) : base(message) { }
}
#endregion

public class Student
{
    public int Marks { get; private set; }

    public void SetMarks(int marks)
    {
        if (marks < 0 || marks > 100)
            throw new InvalidMarksException("Marks must be between 0 and 100.");
        Marks = marks;
    }
}
