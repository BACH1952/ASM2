using System;
using System.Collections.Generic;
using System.Text;

namespace ASM2
{
    class Lecture : Human
    {
        public string Departerment { get; set; }

        CheckInput checkInput = new CheckInput();
        public Lecture()
        { }
        public Lecture(string ID, string Name, string Address, DateTime DateOfBirth, string Email, string Departerment) : base(ID, Name, Address, DateOfBirth, Email)
        {
            this.Departerment = Departerment;
        }
        /* add*/
        public void AddNew(List<Human> lecture)
        {
            base.AddNew();
            while (true)
            {
                Console.WriteLine("Enter Department");
                string takeDept = Console.ReadLine();
                if (checkInput.NotNull(takeDept) > 0)
                {
                    this.Departerment = takeDept;
                    break;
                }

            }

            if (!lecture.Exists(l => l.ID == this.ID))
            {
                lecture.Add(new Lecture(this.ID, this.Name, this.Address, this.DateOfBirth.Date, this.Email, this.Departerment));
            }
        }
        /* view all */
        public new void ViewAll(List<Human> lecture)
        {
            if (lecture != null)
            {
                Console.WriteLine("________________________________________________________________________________________");
                Console.WriteLine("|  ID   |   Name    |   Address |   Date of birth   |       Email     |   Departerment |");
                Console.WriteLine();
                foreach (Human p in lecture)
                {
                    //Initiate object Student as a Person but still a student
                    Lecture l = p as Lecture;

                    //Print out data
                    Console.WriteLine(l.ID + "  |   " + l.Name + "  |    " +
                        l.Address + "  |    " + l.DateOfBirth.Date.ToShortDateString() + "  |    " + l.Email + "    |    " + l.Departerment);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("database is null");
                return;
            }
        }
        /* search*/
        public new void Search(string searchName, List<Human> lecture)
        {
            foreach (Human p in lecture)
            {
                Lecture l = p as Lecture;
                if (l.Name.Contains(searchName))
                {

                    if (lecture.IndexOf(l) > -1)
                    {
                        Console.WriteLine("________________________________________________________________________________________");
                        Console.WriteLine("|    ID   |   Name    |   Address |   Date of birth   |       Email     |   Department |");
                        Console.WriteLine(l.ID + "  |   " + l.Name + "  |   " + l.Address + "  |   " + l.DateOfBirth
                            + "  |   " + l.Email + "    |   " + l.Departerment);
                    }
                    else
                    {
                        Console.WriteLine("There is no student with that information!");
                        return;
                    }
                }
            }
        }
        /*  delete */
        public new void Delete(string delID, List<Human> lecture)
        {
            foreach (Human p in lecture)
            {
                Lecture l = p as Lecture;
                if (l.ID == delID)
                {
                    lecture.Remove(l);
                    if (lecture.IndexOf(l) < 0)
                    {
                        Console.WriteLine("Delete success");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("can't delete!");
                    }
                }
                else
                {
                    Console.WriteLine("Invailid ID");
                    return;
                }
            }
        }
        /* Update*/
        public void EditInformation(string editID, List<Human> lecture)
        {
            base.EditInformation();
            base.EditInformation();
            while (true)
            {
                Console.Write("Enter new department: ");
                string editDept = Console.ReadLine();
                if (checkInput.NotNull(editDept) < 0)
                {
                    break;
                }
                else if (checkInput.NotNull(editDept) > -1)
                {
                    this.Departerment = editDept;
                    break;
                }
            }
            Console.WriteLine("Do you want to save it?");
            Console.WriteLine("Press 1 to save the information!");
            Console.WriteLine("Press any other key to cancel ");
            int n = int.Parse(Console.ReadLine());
            if (checkInput.Validation_Switch(n.ToString()) == true)
            {
                switch (n)
                {
                    case 1:
                        foreach (Human p in lecture)
                        {
                            Lecture l = p as Lecture;
                            if (lecture.Exists(l => l.ID == editID))
                            {
                                l.Name = this.Name;
                                l.Address = this.Address;
                                l.DateOfBirth = this.DateOfBirth;
                                l.Email = this.Email;
                                l.Departerment = this.Departerment;
                                if (lecture.IndexOf(l) > -1)
                                {
                                    Console.WriteLine("success");
                                }
                                else
                                {
                                    Console.WriteLine("Something wrong");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invailid ID!");
                                return;
                            }
                            break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}