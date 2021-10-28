using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Serialization;

namespace WPF_Tutorial_XML_Serialization_and_Deserialization {

    [XmlRoot("CompanyEmployees")]

    public class EmployeeList {

        [XmlArray("EmployeeListing")]
        [XmlArrayItem("Employee", typeof(Employee))]

        public List<Employee> employeeList;

        public EmployeeList() {

            employeeList = new List<Employee>();

        }

        public void AddEmployee(Employee employee) {

            employeeList.Add(employee);
            
        }
        
    }
}
