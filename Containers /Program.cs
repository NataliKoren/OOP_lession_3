using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNetProgrammers.Containers;

namespace dotNetProgrammers
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FILE_NAME = @"D:\employees.xml";
            if (File.Exists(FILE_NAME))
            {
                var employeeContainer = new EmployeeContainer();
                try
                {
                    employeeContainer.LoadXmlFile(FILE_NAME);
                    Console.WriteLine("\na)\n");
                    employeeContainer.SortedEmployees();
                    Console.WriteLine("\nb)\n");
                    employeeContainer.GetFirstNEmployees(5);
                    Console.WriteLine("\nc)\n");
                    employeeContainer.GetLastNEmployees(3);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Can't found file");
            }
            Console.ReadLine();
        }
    }
}
