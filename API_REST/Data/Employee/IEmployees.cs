using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Data
{
    public interface IEmployees
    {
        List<EmplyeesModel> GetListEmployee();

        List<EmplyeesModel> GetEmployeeID(int id);

        string AddEmployee(EmplyeesModel employee);
        string UpdateEmployee(int id,EmplyeesModel employee);
        string DeleteEmployee(int id);

    }
}
