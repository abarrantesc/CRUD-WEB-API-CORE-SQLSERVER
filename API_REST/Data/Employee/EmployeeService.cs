using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Data
{
    public class EmployeeService : IEmployees
    {

        SQLconnection conn = new SQLconnection();

            
        public List<EmplyeesModel> GetListEmployee()
        {
            conn.ConnOpen();

            SqlCommand cmd = new SqlCommand("stpGetEmployee", conn.conectarbd);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            List<EmplyeesModel> listEmployee = new List<EmplyeesModel>();
            EmplyeesModel emplyeesModel; new EmplyeesModel();

            while (dr.Read())
            {
                emplyeesModel = new EmplyeesModel();
                emplyeesModel.BusinessEntityID = Convert.ToInt32(dr[0]);
                emplyeesModel.NationalIDNumber = dr[1].ToString();

                var column = dr.GetOrdinal("OrganizationLevel");

                if (!dr.IsDBNull(column)) { 
                    emplyeesModel.OrganizationLevel = Convert.ToInt32(dr["OrganizationLevel"]);
            }

                emplyeesModel.JobTitle = dr[3].ToString();
                emplyeesModel.BirthDate =Convert.ToDateTime(dr[4]);
                emplyeesModel.Gender = Convert.ToChar(dr[5]);
                emplyeesModel.ModifiedDate = Convert.ToDateTime(dr[6]);

                listEmployee.Add(emplyeesModel);

            }

            conn.ConnClose();
            return listEmployee;



        }

        public List<EmplyeesModel> GetEmployeeID(int id)
        {
            conn.ConnOpen();

            SqlCommand cmd = new SqlCommand("stpGetEmployeeID", conn.conectarbd);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BusinessEntityID", id);


            SqlDataReader dr = cmd.ExecuteReader();
            List<EmplyeesModel> listEmployee = new List<EmplyeesModel>();
            EmplyeesModel emplyeesModel; new EmplyeesModel();

            while (dr.Read())
            {
                emplyeesModel = new EmplyeesModel();
                emplyeesModel.BusinessEntityID = Convert.ToInt32(dr[0]);
                emplyeesModel.NationalIDNumber = dr[1].ToString();

                var column = dr.GetOrdinal("OrganizationLevel");

                if (!dr.IsDBNull(column))
                {
                    emplyeesModel.OrganizationLevel = Convert.ToInt32(dr["OrganizationLevel"]);
                }

                emplyeesModel.JobTitle = dr[3].ToString();
                emplyeesModel.BirthDate = Convert.ToDateTime(dr[4]);
                emplyeesModel.Gender = Convert.ToChar(dr[5]);
                emplyeesModel.ModifiedDate = Convert.ToDateTime(dr[6]);

                listEmployee.Add(emplyeesModel);

            }

            conn.ConnClose();
            return listEmployee;
        }

        public string AddEmployee(EmplyeesModel employee)
        {

            conn.ConnOpen();

            SqlCommand cmd = new SqlCommand("stpAddEmployee", conn.conectarbd);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@LoginID", employee.LoginId);
            cmd.Parameters.AddWithValue("@OrganizationNode", employee.OrganizationNode);
            cmd.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
            cmd.Parameters.AddWithValue("@MaritalStatus", employee.MaritalStatus);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
            cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
            cmd.Parameters.AddWithValue("@SalariedFlag", employee.SalariedFlag);
            cmd.Parameters.AddWithValue("@VacationHours", employee.VacationHours);
            cmd.Parameters.AddWithValue("@SickLeaveHours", employee.SickLeaveHours);
            cmd.Parameters.AddWithValue("@CurrentFlag", employee.CurrentFlag);
           
            int i = cmd.ExecuteNonQuery();
            conn.ConnClose();
            if (i >= 1)
            {
                return "1";

            }
            else
            {
                return "0";

            }
        }

        public string UpdateEmployee(int id,EmplyeesModel employee)
        {
            conn.ConnOpen();

            SqlCommand cmd = new SqlCommand("stpUpdateEmployee", conn.conectarbd);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BusinessEntityID", id);
            cmd.Parameters.AddWithValue("@NationalIDNumber", employee.NationalIDNumber);
            cmd.Parameters.AddWithValue("@LoginID", employee.LoginId);
            cmd.Parameters.AddWithValue("@OrganizationNode", employee.OrganizationNode);
            cmd.Parameters.AddWithValue("@JobTitle", employee.JobTitle);
            cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
            cmd.Parameters.AddWithValue("@MaritalStatus", employee.MaritalStatus);
            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
            cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
            cmd.Parameters.AddWithValue("@SalariedFlag", employee.SalariedFlag);
            cmd.Parameters.AddWithValue("@VacationHours", employee.VacationHours);
            cmd.Parameters.AddWithValue("@SickLeaveHours", employee.SickLeaveHours);
            cmd.Parameters.AddWithValue("@CurrentFlag", employee.CurrentFlag);

            int i = cmd.ExecuteNonQuery();
            conn.ConnClose();
            if (i >= 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string DeleteEmployee(int id)
        {
            conn.ConnOpen();

            SqlCommand cmd = new SqlCommand("stpDeleteEmployee", conn.conectarbd);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BusinessEntityID", id);
    
            int i = cmd.ExecuteNonQuery();
            conn.ConnClose();
            if (i >= 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}
   
