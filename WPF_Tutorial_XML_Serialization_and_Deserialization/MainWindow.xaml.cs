using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;

//Tutorial och kod hämtad från:
//https://www.daveoncsharp.com/2009/07/basic-xml-serialization-in-csharp/
//
//Del två:
//https://www.daveoncsharp.com/2009/07/xml-serialization-of-collections/

namespace WPF_Tutorial_XML_Serialization_and_Deserialization {
    
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            /*
            //https://stackoverflow.com/questions/27179373/xml-binding-to-datagrid-in-wpf
            //Visar dock bara en xml med en "employee" i sig
            string sampleXmlFile = @"C:\\Users\\Niklas\\Desktop\\.NET - Utvecklare\\FilesSavedFromVisualStudioApplications\\Tutorial_XML_Employee.xml";
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(sampleXmlFile);
            DataView dataView = new DataView(dataSet.Tables[0]);
            MyDataGrid.ItemsSource = dataView;
            */

            //https://stackoverflow.com/questions/27179373/xml-binding-to-datagrid-in-wpf
            //Modifierade Table[0] till Tables[1] vilket gör att flera "employee" i en "employeList" kan visas.
            //Varning: Kan nog inte användas för labben då ICollection måste användas? Kanske om kan göra om och lägga in i ICollection istället för DataSet/DataGrid?
            string sampleXmlFile = @"C:\\Users\\Niklas\\Desktop\\.NET - Utvecklare\\FilesSavedFromVisualStudioApplications\\Tutorial_XML_List_With_Employees.xml";
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(sampleXmlFile);
            DataView dataView = new DataView(dataSet.Tables[1]);
            MyDataGrid.ItemsSource = dataView;

        }

        private void Serialize() { //Saves as XML after finished!

            Employee employee = new Employee();
            employee.Name = "Logain";
            employee.Surname = "Ablar";
            employee.DateOfBirth = new DateTime(971, 3, 21);
            employee.Sex = Employee.EmployeeSex.Male;
            employee.PositionInCompany = "False Dragon reborn";

            XmlSerializer serializer = new XmlSerializer(employee.GetType());

            TextWriter textWriter = new StreamWriter("C:\\Users\\Niklas\\Desktop\\.NET - Utvecklare\\FilesSavedFromVisualStudioApplications\\Tutorial_XML_Employee.xml");

            serializer.Serialize(textWriter, employee);

            textWriter.Close();

        }

        private void Deserialize() {

            Employee employee = new Employee();

            XmlSerializer serializer = new XmlSerializer(employee.GetType());

            TextReader textReader = new StreamReader("C:\\Users\\Niklas\\Desktop\\.NET - Utvecklare\\FilesSavedFromVisualStudioApplications\\Tutorial_XML_Employee.xml");

            employee = (Employee) serializer.Deserialize(textReader);

            textReader.Close();

            MyTextBlock.Text = $"{employee.Name} {employee.Surname} is a {employee.Sex} previously known as {employee.PositionInCompany} and was born at {employee.DateOfBirth}";

        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e) {

            Serialize();

        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e) {

            Deserialize();

        }

        private void SerializeList() {

            EmployeeList employeeList = new EmployeeList();

            Employee employeeOne = new Employee();
            employeeOne.Name = "Matrim";
            employeeOne.Surname = "Cauthon";
            employeeOne.Sex = Employee.EmployeeSex.Male;
            employeeOne.DateOfBirth = new DateTime(978, 05, 27);
            employeeOne.PositionInCompany = "Rodholder of the Seanchan army";

            employeeList.AddEmployee(employeeOne);


            Employee employeeTwo = new Employee();
            employeeTwo.Name = "Alviarin";
            employeeTwo.Surname = "Freidhen";
            employeeTwo.Sex = Employee.EmployeeSex.Female;
            employeeTwo.DateOfBirth = new DateTime(943, 4, 13);
            employeeTwo.PositionInCompany = "Aes Sedai of the White Ajah (in truth a Black Ajah member)";

            employeeList.AddEmployee(employeeTwo);


            Employee employeeThree = new Employee();
            employeeThree.Name = "Talmanes";
            employeeThree.Surname = "Delovinde";
            employeeThree.Sex = Employee.EmployeeSex.Male;
            employeeThree.DateOfBirth = new DateTime(975, 01, 06);
            employeeThree.PositionInCompany = "Lieutenant-General in the Band of the Red Hand";

            employeeList.AddEmployee(employeeThree);


            Employee employeeFour = new Employee();
            employeeFour.Name = "Alliandre";
            employeeFour.Surname = "Maritha Kigarin";
            employeeFour.Sex = Employee.EmployeeSex.Female;
            employeeFour.DateOfBirth = new DateTime(972, 08, 18);
            employeeFour.PositionInCompany = "Queen of Ghealdan, Blessed of the Light, Defender of Garen's Wall";

            employeeList.AddEmployee(employeeFour);

            XmlSerializer serializer = new XmlSerializer(employeeList.GetType());

            TextWriter textWriter = new StreamWriter("C:\\Users\\Niklas\\Desktop\\.NET - Utvecklare\\FilesSavedFromVisualStudioApplications\\Tutorial_XML_List_With_Employees.xml");

            serializer.Serialize(textWriter, employeeList);

            textWriter.Close();

        }

        private void DeserializeList() {

            EmployeeList employeeList = new EmployeeList();

            XmlSerializer serializer = new XmlSerializer(employeeList.GetType());

            TextReader textReader = new StreamReader("C:\\Users\\Niklas\\Desktop\\.NET - Utvecklare\\FilesSavedFromVisualStudioApplications\\Tutorial_XML_List_With_Employees.xml");

            employeeList = (EmployeeList) serializer.Deserialize(textReader);

            textReader.Close();

            MyTextBlock.Text = "Hi";

        }

        private void ListSerializeButton_Click(object sender, RoutedEventArgs e) {

            SerializeList();

        }

        private void ListDeserializeButton_Click(object sender, RoutedEventArgs e) {

            DeserializeList();
            
        }

    }
}
