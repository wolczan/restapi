using RestApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Examples
{
    public class Program
    {
        public static void Main()
        {
            // Tworzenie instancji klasy Product
            Product newProduct = new Product
            {
                Id = 1,
                Name = "Klawiatura bezprzewodowa",
                Price = 149.99M
            };

            // Wydrukowanie wartości dla sprawdzenia
            System.Console.WriteLine($"ID: {newProduct.Id}, Nazwa: {newProduct.Name}, Cena: {newProduct.Price}");

            // Przykładowa lista pracowników
            List<Employee> employees = new List<Employee>
            {
                new Employee { Age = 28, Team = "IT", Salary = 50000, FullName = "John Doe" },
                new Employee { Age = 32, Team = "Marketing", Salary = 45000, FullName = "Jane Smith" },
                new Employee { Age = 25, Team = "IT", Salary = 55000, FullName = "Emily Johnson" },
                // Dodaj więcej pracowników według potrzeb
            };

            // LINQ Query
            var youngITEmployees = employees
                .Where(e => e.Age < 30 && e.Team == "IT")
                .OrderBy(e => e.Salary)
                .Select(e => e.FullName)
                .ToList();

            // Wydrukowanie listy młodych pracowników IT
            System.Console.WriteLine("Młodzi pracownicy IT:");
            foreach (var employee in youngITEmployees)
            {
                System.Console.WriteLine(employee);
            }
        }
    }
}