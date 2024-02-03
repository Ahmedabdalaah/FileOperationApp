using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperationApp
{
    internal interface IOperations
    { 
     void AddEmployee(int id, string firstName, string lastName, int age, string email, string address, int phone);
    void DeleteEmployeeByID(int id);
    void update(int id, string old_email, string new_email);
    void GetAll();
    void GetEmployee(int id);
    void Replacing(string old_email, string new_email);
    }
}