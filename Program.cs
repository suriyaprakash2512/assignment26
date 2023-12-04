using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace Assignment26
{
    class Program
    {
        static void Main()
        {
            
            Employee emp = new Employee
            {
                Id = 1,
                FirstName = "Rohit",
                LastName = "Sharma",
                Salary = 75000.0
            };

          
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\SuriyaPrakash\source\repos\day-21\Assignment26\employeebin.txt",
            FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, emp);
            stream.Close();

            stream = new FileStream(@"C:\Users\SuriyaPrakash\source\repos\day-21\Assignment26\employeebin.txt",
            FileMode.Open, FileAccess.Read);
            Employee objnew = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("deserialized employee data: ");
            Console.WriteLine($"Id: {objnew.Id}, FirstName: {objnew.FirstName}," +
                $" LastName: {objnew.LastName}, Salary: {objnew.Salary} ");

            


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.xml"))
            {
                xmlSerializer.Serialize(writer, emp);
            }

         
            Employee xmlDeserializedEmp;
            using (TextReader reader = new StreamReader("employee.xml"))
            {
                xmlDeserializedEmp = (Employee)xmlSerializer.Deserialize(reader);
            }

            
            Console.WriteLine("DeserializedXml Employee Data:");
            Console.WriteLine($"id: {xmlDeserializedEmp.Id}, FirstName: {xmlDeserializedEmp.FirstName}," +
                $"LastName: {xmlDeserializedEmp.LastName}, Salary: {xmlDeserializedEmp.Salary}");

            DisplayEmployee(xmlDeserializedEmp);



        }

        static void DisplayEmployee(Employee employee)
        {
            Console.WriteLine($"ID: {employee.Id}");
            Console.WriteLine($"First Name: {employee.FirstName}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}