using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using dotNetProgrammers.Models;

namespace dotNetProgrammers.Containers
{
    class EmployeeContainer:List<Employee>
    {
        private List<Employee> sortedEmployees => SortEmployees();

        public void LoadXmlFile(string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            var employeeType = xmlDocument.GetElementsByTagName("Employee");
            var employeeId = xmlDocument.GetElementsByTagName("id");
            var employeeNames = xmlDocument.GetElementsByTagName("name");
            var employeeSalary = xmlDocument.GetElementsByTagName("salary");
            PopulateList(employeeType, employeeId, employeeNames, employeeSalary);
        }

        private void PopulateList(XmlNodeList employeeType, XmlNodeList employeeId, XmlNodeList employeeNames,
            XmlNodeList employeeSalary)
        {
            for (var counter = 0; counter < employeeType.Count; counter++)
            {
                var xmlAttribureCollection = employeeType[counter].Attributes;
                Employee currentEmployee;
                if (xmlAttribureCollection != null && xmlAttribureCollection["type"].Value == "1")
                {
                    currentEmployee = new FixedSalaryEmployee(
                        int.Parse(employeeId[counter].InnerText),
                        employeeNames[counter].InnerText,
                        double.Parse(employeeSalary[counter].InnerText)
                    );
                }
                else
                {
                    currentEmployee = new HourlySalaryEmployee(
                        int.Parse(employeeId[counter].InnerText),
                        employeeNames[counter].InnerText,
                        double.Parse(employeeSalary[counter].InnerText)
                    );
                }
                Add(currentEmployee);
            }
        }

        private List<Employee> SortEmployees()
        {
            return this.OrderByDescending(employee => employee.GetSalary())
                .ThenBy(employee => employee.Name)
                .ToList();
        }

        private void WriteEmployeesInfo(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public void SortedEmployees()
        {
            Console.WriteLine("Sorted employees:");
            WriteEmployeesInfo(sortedEmployees);
        }

        public void GetFirstNEmployees(int N)
        {
            Console.WriteLine("The first five employees:");
            var firstFiveEmployees = sortedEmployees.Take(N);
            WriteEmployeesInfo(firstFiveEmployees);
        }

        public void GetLastNEmployees(int N)
        {
            Console.WriteLine("Last three employees");
            var lastThreeEmployees = sortedEmployees;
            lastThreeEmployees.Reverse();
            WriteEmployeesInfo(lastThreeEmployees.Take(N));
        }

    }
}
