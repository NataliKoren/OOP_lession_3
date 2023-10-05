using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetProgrammers.Models
{
    class HourlySalaryEmployee:Employee
    {
        public HourlySalaryEmployee(int id, string name, double salary) : base(id, name, salary)
        {
            
        }
        public override double GetSalary()
        {
            return 20.8 * 8 * Salary;
        }
    }
}
