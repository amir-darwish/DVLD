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
        static void testAddNewPerson()
        {
            clsPerson newPerson = new clsPerson();
            newPerson.NationalNo = "N11";
            newPerson.FirstName = "John";
            newPerson.SecondName = "Doe";
            newPerson.ThirdName = "M";
            newPerson.LastName = "Smith";
            newPerson.DateOfBirth = new DateTime(1990, 1, 1);
            newPerson.Gender = 1;
            newPerson.Address = "123 Main St";
            newPerson.Phone = "555-1234";
            newPerson.Email = "nwq!@mail.xom";
            newPerson.NationalityCountryID = 1;
            bool isAdded = newPerson.Save();
            if (isAdded)
            {
                Console.WriteLine("New person added with ID: " + newPerson.PersonID);
            }
            else
            {
                Console.WriteLine("Failed to add new person.");
            }
        }
        static void testUpdatePerson(int id)
        {
            clsPerson personToUpdate = clsPerson.Find(id);
            if (personToUpdate != null)
            {
                personToUpdate.Phone = "555-5678";
                personToUpdate.Address = "456 Elm St";
                bool isUpdated = personToUpdate.Save();
                if (isUpdated)
                {
                    Console.WriteLine("Person updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update person.");
                }
            }
            else
            {
                Console.WriteLine("Person not found.");
            }
        }
        static void testDeletePerson(int id)
        {

            if (clsPerson.DeletePerson(id))
                {
                    Console.WriteLine("Person deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete person.");
                }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("hi");
            //testGetPersonByID(1);
            //testAddNewPerson();
            //testUpdatePerson(1);
            testDeletePerson(1033);
        }
    }
}
