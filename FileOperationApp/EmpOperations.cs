using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationApp
{
    internal class EmpOperations
    {
        string status;
        string wordsToDelete = "";
        public void AddEmployee(int id, string firstName, string lastName, int age, string email, string address, int phone)
        {
            try
            {
                File.AppendAllText("Employee.txt", $"{id};{firstName};{lastName};{age};{email};{address};{phone};#\n");
                Console.WriteLine("Success , Employee is added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteEmployeeByID(int id)
        {
            String line;
            try
            {
                StreamReader str = new StreamReader("Employee.txt");
                var Lines = File.ReadAllLines("Employee.txt");
                line = str.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split("\n");
                    for (int i = 0; i < data.Length; i++)
                    {
                        string[] value = data[i].Split(";");
                        if (Convert.ToInt32(value[i]) == id)
                        {
                            var newLines = Lines.Where(line => !line.Contains(value[i + 1]));
                            File.WriteAllLines("Employee.txt", newLines);
                            str.Close();
                            Console.WriteLine($"{value[i + 1]} {value[i + 2]}is deleted");
                        }

                        line = str.ReadLine();
                        str.Close();
                    }
                }
                str.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetAll()
        {
            String s;
            try
            {
                StreamReader str = new StreamReader("Employee.txt");
                s = str.ReadLine();
                while (s != null)
                {
                    string[] data = s.Split("\n");
                    foreach (string item in data)
                    {
                        Console.WriteLine("Employee : " + item);
                        s = str.ReadLine();
                    }
                }
                str.Close();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEmployee(int id)
        {
            String line;
            try
            {
                StreamReader str = new StreamReader("Employee.txt");
                line = str.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split("\n");
                    for (int i = 0; i < data.Length; i++)
                    {
                        string[] value = data[i].Split(";");
                        if (Convert.ToInt32(value[i]) == id)
                        {
                            Console.WriteLine($"Employee number {id} information");
                            Console.WriteLine($"Employee FirstName : {value[i + 1]}");
                            Console.WriteLine($"Employee LastName : {value[i + 2]}");
                            Console.WriteLine($"Employee Age : {Convert.ToInt32(value[i + 3])}");
                            Console.WriteLine($"Employee Email : {value[i + 4]}");
                            Console.WriteLine($"Employee Address : {value[i + 5]}");
                            Console.WriteLine($"Employee Phone : {Convert.ToInt32(value[i + 6])}");
                        }

                        line = str.ReadLine();
                    }
                }
                str.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Replacing(string old_email, string new_email)
        {
            try
            {
                string replaceString = string.Join(";", File.ReadAllLines("Employee.txt")).Replace(old_email, new_email);
                File.WriteAllText("Employee.txt", replaceString);
                Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void update(int id, string old_email, string new_email)
        {
            String line;
            try
            {
                StreamReader str = new StreamReader("Employee.txt");
                line = str.ReadLine();
                string strFile = File.ReadAllText("Employee.txt");
                while (line != null)
                {
                    string[] data = line.Split("\n");
                    for (int i = 0; i < data.Length; i++)
                    {
                        string[] value = data[i].Split(";");
                        if (Convert.ToInt32(value[i]) == id)
                        {
                            status = "ok";
                        }
                        str.Close();

                    }
                    if (status == "ok")
                    {
                        Replacing(old_email, new_email);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ConfirmDelete()
        {
            String line;
            if (wordsToDelete == "")
            {
                Console.WriteLine("not found");
            }
            else
            {
                try
                {
                    var Lines = File.ReadAllLines("Employee.txt");
                    StreamReader str = new StreamReader("Employee.txt");
                    string linee = str.ReadLine();

                    Console.WriteLine(wordsToDelete);
                    if (linee.Contains(wordsToDelete))
                    {
                        var newLines = Lines.Where(line => !linee.Contains(wordsToDelete));
                        File.WriteAllLines("Employee.txt", newLines);
                        Console.WriteLine("deleted");
                        str.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

    }
}

