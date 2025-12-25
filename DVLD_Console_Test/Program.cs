using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;

namespace DVLD_Console_Test
{

    internal class Program
    {
        static void testGetPersonByID(int id)
        {
            clsPerson person = clsPerson.Find(id);

            if (person == null)
            {
                Console.WriteLine("error not found ");
            }
            else
            {
                Console.WriteLine($"Person ID: {person.PersonID}");
                Console.WriteLine($"National No: {person.NationalNo}");
                Console.WriteLine($"First Name: {person.FirstName}");
                Console.WriteLine($"Second Name: {person.SecondName}");
                Console.WriteLine($"Third Name: {person.ThirdName}");
                Console.WriteLine($"Last Name: {person.LastName}");
                Console.WriteLine($"Date of Birth: {person.DateOfBirth:yyyy-MM-dd}");
                Console.WriteLine($"Gender: {person.Gender}");
                Console.WriteLine($"Address: {person.Address}");
                Console.WriteLine($"Phone: {person.Phone}");
                Console.WriteLine($"Email: {person.Email}");
                Console.WriteLine($"Nationality Country ID: {person.NationalityCountryID}");
                Console.WriteLine($"Image Path: {person.ImagePath}");

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("hi");
            testGetPersonByID(1);
        }
    }
}
