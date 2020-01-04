using System;
using System.Collections.Generic;
using System.Text;

namespace ASM2
{
    public class Student : Human
    {
        public string Class_ { get; set; }
        public Student() : base()
        { }
        public Student(string ID, string Name, string Address, DateTime DateOfBirth, string Email, string stdclass) : base(ID, Name, Address, DateOfBirth, Email)
        {
            this.Class_ = stdclass;
        }

        CheckInput checkInput = new CheckInput();

        /*ADD */
        public void AddNew(List<Human> student)
        {
            base.AddNew();

            Console.WriteLine("Enter information of student :");
            this.Class_ = "";

            if (!student.Exists(s => s.ID == this.ID))
            {
                student.Add(new Student(this.ID, this.Name, this.Address, this.DateOfBirth.Date, this.Email, this.Class_));
            }
        }
        /* View All */
        public new void ViewAll(List<Human> student)
        {
            if (student != null)
            {
                Console.WriteLine("___________________________________________________________________________________");
                Console.WriteLine("|   ID   |   Name    |   Address |   Date of birth   |       Email     |   Class  |");
                Console.WriteLine();
                foreach (Human p in student)
                {
                    Student s = p as Student;
                    Console.WriteLine(s.ID + "  |   " + s.Name + "  |    " + s.Address + "  |    " + s.DateOfBirth.Date.ToShortDateString() + "  |    " + s.Email + "    |    " + s.Class_);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("database is null");
                return;
            }
        }

        /* Search */
        public override void Search(String searchName, List<Human> student)
        {
            foreach (Human p in student)
            {
                Student s = p as Student;
                if (s.Name.Contains(searchName))
                {

                    if (student.IndexOf(s) > -1)
                    {
                        Console.WriteLine("___________________________________________________________________________________");
                        Console.WriteLine("|    ID   |   Name    |   Address |   Date of birth   |       Email     |   Class |");
                        Console.WriteLine(s.ID + "|  "+s.Name+"  |" + s.Address + "  |   " + s.DateOfBirth
                            + "  |   " + s.Email + "    |   " + s.Class_);
                    }
                    else
                    {
                        Console.WriteLine("can't found this student");
                        return;
                    }
                }
            }
        }
        /* Delete */
        public new void Delete(string delID, List<Human> student)
        {
            foreach (Human p in student)
            {
                Student s = p as Student;
                if (s.ID == delID)
                {
                    student.Remove(s);
                    if (student.IndexOf(s) < 0)
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

        /* Edit */
        public void EditInformation(string editID, List<Human> student)
        {
            base.EditInformation();
            while (true)
            {
                Console.Write("Enter new batch: ");
                string editBatch = Console.ReadLine();
                if (checkInput.NotNull(editBatch) < 0)
                {
                    break;
                }
                else if (checkInput.NotNull(editBatch) > -1)
                {
                    this.Class_ = editBatch;
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
                        foreach (Human p in student)
                        {
                            Student s = p as Student;
                            if (student.Exists(s => s.ID == editID))
                            {
                                s.Name = this.Name;
                                s.Address = this.Address;
                                s.DateOfBirth = this.DateOfBirth;
                                s.Email = this.Email;
                                s.Class_ = this.Class_;
                                if (student.IndexOf(s) > -1)
                                {
                                    Console.WriteLine("success");
                                }
                                else
                                {
                                    Console.WriteLine("Something wrong ");
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
