using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Tutorial_XML_Serialization_and_Deserialization {
    public class Employee {

        public enum EmployeeSex {
            
            Male,
            Female,
            Unknown,
            Undisclosed

        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        private EmployeeSex _sex;

        public EmployeeSex Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private string _positionInCompany;

        public string PositionInCompany 
        {
            get { return _positionInCompany; }
            set { _positionInCompany = value; }
        }

        public Employee() {
            
        }

    }

}
