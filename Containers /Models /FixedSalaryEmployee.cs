using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetProgrammers.Models
{
    class FixedSalaryEmployee:Employee
    {
        public FixedSalaryEmployee(int id, string name, double salary) : base(id, name, salary)
        {
            
        }
        public override double GetSalary()
        {
            return Salary;
        }
    }
}
