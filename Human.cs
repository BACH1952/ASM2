using System;
using System.Collections.Generic;
using System.Text;

namespace ASM2
{
    public class Human
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        CheckInput checkInput = new CheckInput();
        public Human()
        { }
        public Human(string ID, string Name, string Address, DateTime DoB, string Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
            this.DateOfBirth = DoB;
            this.Email = Email;
        }
        public virtual void AddNew()
        {
            while (true)
            {
                Console.Write("Enter ID: ");
                string takeID = Console.ReadLine();
                if (checkInput.Only_Digit(takeID) == true)
                {
                    this.ID = takeID;
                    break;
                }
                else
                {
                    Console.WriteLine("wrong ID ");
                }
            }

            while (true)
            {
                Console.Write("Enter Name: ");
                string takeName = Console.ReadLine();
                if (checkInput.Check_specialCharacters(takeName) > -1)
                {
                    this.Name = takeName;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid name");
                }
            }

            while (true)
            {
                Console.Write("Enter Address: ");
                string takeAddress = Console.ReadLine();
                if (checkInput.NotNull(takeAddress) > -1)
                {
                    this.Address = takeAddress;
                    break;
                }
                else
                {
                    Console.WriteLine("Address can not be null");
                }
            }

            while (true)
            {
                Console.Write("Enter Date of birth: ");
                string takeDate = Console.ReadLine();
                if (checkInput.Date_Time(takeDate) == true)
                {
                    this.DateOfBirth = DateTime.ParseExact(takeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter Email: ");
                string takeEmail = Console.ReadLine();
                if ((checkInput.Is_Gmail(takeEmail)) > -1)
                {
                    this.Email = takeEmail;
                    break;
                }
                else
                {
                    Console.WriteLine("wrong email");
                }
            }
        }
        /* View All*/
        public virtual void ViewAll(List<Human> person)
        {
            if (person != null)
            {
                foreach (Human p in person)
                {
                    Console.WriteLine(p.ID + "| " + p.Name + "| " + p.Address + "| " + p.DateOfBirth + "| " + p.Email + "| ");
                }
            }
            else
            {
                Console.WriteLine("database is null");
                return;
            }
        }
        /*Search*/
        public virtual void Search(string keyword, List<Human> person)
        {
            int searchResult = 0;
            foreach (Human p in person)
            {
                if (p.ID == keyword)
                {
                    Student s = p as Student;
                    searchResult = person.IndexOf(p);
                    if (searchResult > -1)
                    {
                        Console.WriteLine(person[searchResult].ID + " " + person[searchResult].Name + " " + person[searchResult].Address + " " + person[searchResult].DateOfBirth
                            + " " + person[searchResult].Email);
                    }
                    else
                    {
                        Console.WriteLine("can't found !");
                        return;
                    }
                }
            }
        }
        /*Delete*/
        public virtual void Delete(string delName, List<Human> person)
        {
            foreach (Human p in person)
            {
                if (p.Name.Contains(delName))
                {
                    person.RemoveAt(person.IndexOf(p));
                    if (person.IndexOf(p) < 0)
                    {
                        Console.WriteLine("deleted succesfully!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("can't deleted");
                    }
                }
                else
                {
                    Console.WriteLine("ID not found");
                    return;
                }
            }
        }
        /*update*/
        public virtual void EditInformation()
        {
            while (true)
            {
                Console.Write("Enter Name: ");
                string editName = Console.ReadLine();
                if (checkInput.NotNull(editName) < 0)
                {
                    break;
                }
                else if (checkInput.Check_specialCharacters(editName) > -1)
                {
                    this.Name = editName;
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter address: ");
                string editAddress = Console.ReadLine();
                if (checkInput.NotNull(editAddress) < 0)
                {
                    break;
                }
                else
                {
                    this.Address = editAddress;
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter date of birth: ");
                string editDOB = Console.ReadLine();
                if (checkInput.NotNull(editDOB) < 0)
                {
                    break;
                }
                else if (checkInput.Date_Time(editDOB) == true)
                {
                    this.DateOfBirth = DateTime.ParseExact(editDOB, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter email:");
                string editEmail = Console.ReadLine();
                if (checkInput.NotNull(editEmail) < 0)
                {
                    break;
                }
                else if (checkInput.Is_Gmail(editEmail) > -1)
                {
                    this.Email = editEmail;
                    break;
                }
            }
        }
    }
}