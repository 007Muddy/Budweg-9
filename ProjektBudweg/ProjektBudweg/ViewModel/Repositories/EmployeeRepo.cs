using ProjektBudweg.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Buffers;
using System.Data;

namespace ProjektBudweg.ViewModel
{
    public class EmployeeRepo
    {
       

        private List<Employee> employeeRepo = new List<Employee>();

        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;

        //Loading all employees from database(P1_DB_2023_09) and polulating into employeeRepo
        public EmployeeRepo()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Bud_Employee", sqlConnection))
                    {
                        SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                        while (sqlReader.Read())
                        {
                            
                            int EmployeeID = sqlReader.GetInt32(0);
                            string Department = sqlReader.GetString(1);
                          
                            Employee employee = new Employee(EmployeeID,Department);
                            employeeRepo.Add(employee); 
                        
                        }
                    }


                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // This method adds an employee to the database and the employee repository.
        // It takes an Employee object as input and returns an integer value to indicate
        // the result of the operation:
        //  * 1: The employee was added successfully to the database and repository.
        //  * 0: No rows were affected by the database query, indicating that the operation failed.
        public int Add(Employee employee)
        {
            // Initialize the result variable to 0 to indicate failure by default.
            int result = 0;
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(connectionString))
                {
                    _sqlConnection.Open();

                    // Create a new SqlCommand object with the INSERT statement.
                    using (SqlCommand _sqlCommand = new SqlCommand("INSERT INTO TABLE Bud_Employee (Department)"
                                                                 + "VALUES(@Department)", _sqlConnection))
                    {
                        // Add the EmployeeID and Department parameters to the command object.

                        _sqlCommand.Parameters.Add("@Department", SqlDbType.NVarChar).Value = employee.Department;

                        // Execute the command and get the number of rows affected.
                        int rowsAffected = _sqlCommand.ExecuteNonQuery();

                        // Check if any rows were affected by the command.
                        if (rowsAffected > 0)
                        {
                            // If the query succeeded, add the employee to the repository.
                            employeeRepo.Add(employee);

                            result = 1;
                        }
                        else
                        {
                            // If no rows were affected, the query failed and the result variable remains 0.
                            result = 0;
                        }


                    }
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            // Return the result of the operation.
            return result;

        }

        public Employee GetEmployeeByID(int id) 
        { 
            Employee employee1= null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SELECT FROM Bud_Employee WHERE Employee_ID = @EmployeeID", sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = id;
                        SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                        while (sqlReader.Read())
                        {

                          int EmployeeID = sqlReader.GetInt32(0);
                            string Department = sqlReader.GetString(1);

                            employee1 = new Employee(EmployeeID, Department);

                            employeeRepo.Add(employee1);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return employee1;
        }

        public List<Employee> GeAllEmployees()
        {
            return employeeRepo;
        }

        public void Update(Employee employee)
        {
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE TABLE Bud_Employee SET Department = @Department WHERE Employee_ID = @EmployeeID", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                        sqlCommand.Parameters.AddWithValue("EmpoyeeID", employee.EmployeeID);
                        sqlCommand.ExecuteNonQuery();
                    }
                }

            }
            catch (SqlException e)
            {

                throw new Exception("An error occured while updating the Employee record.", e);
            }
        }

        public void Delete(Employee employee)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM Bud_Employee WHERE Employee_ID = @EmployeeID", sqlConnection))
                    {
                        command.Parameters.Add("EmployeeID", SqlDbType.Int).Value = employee.EmployeeID;
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (SqlException ex)
            {

                throw new Exception("An error occured while deleting an employee from the database");
            }
        }
    }
}

