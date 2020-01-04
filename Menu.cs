using System;
using System.Collections.Generic;
using System.Text;

namespace ASM2
{
    public class Menu
    {
        CheckInput checkInput = new CheckInput();
        Student student = new Student();
        Lecture lecture = new Lecture();
        List<Human> p = new List<Human>();
        public void PrintMainMenu()
        {
            Console.WriteLine("__________________________________________");
            Console.WriteLine("|  Welcome to school management system   |");
            Console.WriteLine("|________________________________________|");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|         CHOSE YOUR OPINION             |");
            Console.WriteLine("|         1. Manage Student              |");
            Console.WriteLine("|         2. Manage Lecture              |");
            Console.WriteLine("|         3. Exit system                 |");
            Console.WriteLine("|________________________________________|");
            Console.Write("Enter your option is: ");
        }
        void PrintExit()
        {
            Console.WriteLine("__________________________________________");
            Console.WriteLine("|    Are you sure you wanted to exit?    |");
            Console.WriteLine("|           Press 1 to exit!             |");
            Console.WriteLine("|Press 2 to continue to use this program!|");
            Console.WriteLine("|________________________________________|");
            Console.Write("Enter your option is: ");
        }
        public void Option()
        {
            Console.Clear();
            string input = "";
            while (true)
            {
                PrintMainMenu();
                input = Console.ReadLine();
                if (checkInput.Validation_Switch(input) == true)
                {
                    switch (int.Parse(input))
                    {
                        case 1:
                            StudentOption();
                            break;
                        case 2:
                            Console.Clear();
                            PrintSubmenu("Lecture");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            PrintExit();
                            try
                            {
                                Console.Write("Your option is: ");
                                int exitInput = 0;
                                exitInput = int.Parse(Console.ReadLine());
                                if (checkInput.Validation_Switch(exitInput.ToString()) == true)
                                    switch (exitInput)
                                    {
                                        case 1:
                                            Environment.Exit(0);
                                            break;
                                        case 2:
                                            Console.Clear();
                                            break;
                                    }
                                else { return; }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invailid option! " + e);
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else { return; }
            }
        }
        void PrintSubmenu(string type)
        {
            Console.WriteLine("___________________________________________");
            Console.WriteLine("| WELCOME TO MANAGE " + type + " FUNCTION |");
            Console.WriteLine("|_________________________________________|");
            Console.WriteLine("|   1. Add new " + type + " information   |");
            Console.WriteLine("|   2. View all " + type + " information  |");
            Console.WriteLine("|   3. Search " + type + " information    |");
            Console.WriteLine("|   4. Delete " + type + " information    |");
            Console.WriteLine("|   5. Update " + type + " information    |");
            Console.WriteLine("|   6. Back to main menu                  |");
            Console.WriteLine("|_________________________________________|");
            Console.Write("Your option is: ");
        }
        void StudentOption()
        {
            string input = "";

            while (true)
            {
                Console.Clear();
                PrintSubmenu("Student");
                input = Console.ReadLine();
                var temp = checkInput.Validation_Switch(input);
                if (checkInput.Validation_Switch(input) == true)
                {
                    switch (int.Parse(input))
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("___________________________________");
                            Console.WriteLine("|This is Add New Student Function!!|");
                            Console.WriteLine("|__________________________________|");
                            student.AddNew(p);
                            break;
                        case 2:
                            Console.Clear();
                            student.ViewAll(p);
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Enter search name:");
                            string searchName = Console.ReadLine();
                            Console.WriteLine("____________________________________");
                            Console.WriteLine("|         Search result:           |");
                            Console.WriteLine("|__________________________________|");
                            if (checkInput.NotNull(searchName) > -1)
                            {
                                student.Search(searchName, p);
                            }
                            else
                            {
                                Console.WriteLine("Invailid name");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Enter delete ID");
                            string delID = Console.ReadLine();
                            student.Delete(delID, p);
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("Enter edit ID: ");
                            string editID = Console.ReadLine();
                            if (checkInput.Isid(editID) > -1)
                            {
                                student.EditInformation(editID, p);
                            }
                            else
                            {
                                Console.WriteLine("That was not a valid ID");
                                Console.WriteLine("Do you want to continue?");
                                Console.ReadLine();
                            }
                            break;
                        case 6:
                            return;
                        default:
                            return;
                    }
                }
            }
        }
        void LecturetOption()
        {
            string input = "";

            while (true)
            {
                Console.Clear();
                PrintSubmenu("Lecture");
                input = Console.ReadLine();
                if (checkInput.Validation_Switch(input) == true)
                {
                    switch (int.Parse(input))
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("_________________________________________");
                            Console.WriteLine("|   This is Add New Lecture Function!!  |");
                            Console.WriteLine("|_______________________________________|");
                            lecture.AddNew(p);
                            break;
                        case 2:
                            Console.Clear();
                            student.ViewAll(p);
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Enter search name:");
                            string searchName = Console.ReadLine();
                            Console.WriteLine("Search result: ");
                            if (checkInput.NotNull(searchName) > -1)
                            {
                                lecture.Search(searchName, p);
                            }
                            else
                            {
                                Console.WriteLine("Invailid name");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Enter delete ID");
                            string delID = Console.ReadLine();
                            lecture.Delete(delID, p);
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("Enter edit ID: ");
                            string editID = Console.ReadLine();
                            if (checkInput.Isid(editID) > -1)
                            {
                                lecture.EditInformation(editID, p);
                            }
                            else
                            {
                                Console.WriteLine("That was not a valid ID");
                                Console.WriteLine("Do you want to continue?");
                                Console.ReadLine();
                            }
                            break;
                        case 6:
                            return;
                        default:
                            return;
                    }
                }
            }
        }
    }
}
