using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClasses
{
    public class Student
    {
        //Class Fields
        private string name;
        private int age;

        //Defined and Default Constructors
        public Student()
        {
            this.name = "";
            this.age = 0;
        }

        public Student(string n, int a)
        {
            this.name = n;
            this.age = a;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        //done student-specific methods/properties are not part of the system, they CANNOT be utilized in the ListClass generic template
        public override string ToString()
        {
            return this.name;
        }
    }
}
