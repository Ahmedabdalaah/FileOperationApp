// See https://aka.ms/new-console-template for more information
using FileOperationApp;

FileStream file = null;
EmpOperations emp = new EmpOperations();
string fileName = "Employee.txt";
if (!File.Exists(fileName))
{
    file = File.Create(fileName);
}
Console.WriteLine("a : Add new Employee");
Console.WriteLine("b : Show All Employee");
Console.WriteLine("c : Search for Employee");
Console.WriteLine("d : Update existing Employee");
Console.WriteLine("e : remove existing Employee");



string choice = Console.ReadLine();
if (choice == "a")
{
    Console.WriteLine("please Enter Employee Id : ");
    string i = Console.ReadLine();
    int id = Convert.ToInt32(i);
    Console.WriteLine("Please Enter Employee First Name : ");
    string fname = Console.ReadLine();
    Console.WriteLine("Please Enter Employee Last Name : ");
    string lname = Console.ReadLine();
    Console.WriteLine("Please Enter Employee Address : ");
    string address = Console.ReadLine();
    Console.WriteLine("please Enter Employee Age : ");
    string a = Console.ReadLine();
    int age = Convert.ToInt32(a);
    Console.WriteLine("Please Enter Employee Email : ");
    string email = Console.ReadLine();
    Console.WriteLine("please Enter Employee Phone : ");
    string p = Console.ReadLine();
    int phone = Convert.ToInt32(p);
    emp.AddEmployee(id, fname, lname, age, email, address, phone);
}
if (choice == "b")
{
    Console.WriteLine("Employee Informations");
    emp.GetAll();
}
if (choice == "c")
{
    Console.WriteLine("Please Enter the employee id ");
    int id = Convert.ToInt32(Console.ReadLine());
    emp.GetEmployee(id);
}
if (choice == "d")
{
    Console.WriteLine("Please Enter the employee  id ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please Enter Employee old Email : ");
    string email = Console.ReadLine();
    Console.WriteLine("Please Enter Employee new Email : ");
    string email2 = Console.ReadLine();
    emp.update(id, email, email2);
}
if (choice == "e")
{
    Console.WriteLine("Please Enter the employee  id ");
    int id = Convert.ToInt32(Console.ReadLine());
    emp.DeleteEmployeeByID(id);
}



