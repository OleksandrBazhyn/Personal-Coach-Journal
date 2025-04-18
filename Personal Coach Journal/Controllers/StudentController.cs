using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Coach_Journal.Models;

namespace Personal_Coach_Journal.Controllers
{
    public class StudentController
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(string FirstName, string LastName, string? PhoneNumber, string? TelegramTag, string? Description)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FirstName))
                    throw new ArgumentException("FirstName is required.", nameof(FirstName));

                if (string.IsNullOrWhiteSpace(LastName))
                    throw new ArgumentException("LastName is required.", nameof(LastName));

                if (string.IsNullOrWhiteSpace(PhoneNumber) && string.IsNullOrWhiteSpace(TelegramTag))
                    throw new ArgumentException("Either PhoneNumber or TelegramTag must be provided.");

                var student = new Student
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    TelegramTag = TelegramTag,
                    Description = Description
                };
                students.Add(student);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
