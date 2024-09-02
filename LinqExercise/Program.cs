using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Xml.XPath;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE TODO: Print the Sum of numbers
            Console.WriteLine($"The sum of all the numbers is: {numbers.Sum()}");
            
            //DONE TODO: Print the Average of numbers
            Console.WriteLine($"The average of all the numbers is: {numbers.Average()}");

            //DONE TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ascending order:");
            var ascending = numbers.OrderBy(item => item);
            foreach (var number in ascending)
            {
                Console.WriteLine(number);
            }

            //DONE TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Descending order:");
            var descending = numbers.OrderBy(item => item);
            foreach (var number in descending)
            {
                Console.WriteLine(number);
            }

            //DONE TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);
            Console.WriteLine("The numbers that are greater than six:");
            foreach (var num in greaterThanSix)
            {
                Console.WriteLine(num);
            }

            //DONE TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Four numbers from the list:");
            var evenNumbers = numbers.Where(num => (num % 2 == 0) && (num != 0));
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            //DONE TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Changed index 4 to my age:");
            var descendingWith32  = numbers.OrderBy(item => item);
            numbers.SetValue(32, 4);
            foreach (var number in descendingWith32)
            {
                Console.WriteLine(number);
            }
            

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //DONE TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employees whose first name starts with C or S:");
            var startsWithCorS = employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's')
                .OrderBy(name => name.FirstName);
            
            foreach (var person in startsWithCorS)
            {
                Console.WriteLine(person.FullName);
            }
            
            
            //DONE TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over age 26:");
            var age26 = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);

            foreach (var employee in age26)
            {
                Console.WriteLine($"Employee name: {employee.FullName}");
                Console.WriteLine($"Employee age: {employee.Age}");
            }
            //DONE TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("Total years of experience, YOE <= 10 and Age > 35:");
            
            var YOEsum = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine($"{YOEsum.Sum(x => x.YearsOfExperience)} years");
            
            //DONE TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("Average years of experience, YOE <= 10 and Age > 35:");
            var YOEaverage = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine($"{YOEsum.Average(x => x.YearsOfExperience)} years");
            
            //DONE TODO: Add an employee to the end of the list without using employees.Add() (( use Append))

            Console.WriteLine("Here is an updated list with a new employee! Welcome Mariah!");
            
            var newEmployeeList = employees.Append(new Employee("Mariah", "McNicol", 32, 4)).ToList();

            foreach (var person in newEmployeeList)
            {
                Console.WriteLine(person.FullName);
            }
            

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
