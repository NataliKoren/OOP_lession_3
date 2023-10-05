using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetProgrammers.Models
{
    abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        protected Employee()
        {
            
        }

        protected Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public abstract double GetSalary();

        public override string ToString()
        {
            return $"{Name} = {GetSalary()}";
        }
    }
}
