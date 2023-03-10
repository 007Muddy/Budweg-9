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

        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["Bud_Employee"].ConnectionString;

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

        
        public int Add (Employee employee)
        {
            try
            {
                using (SqlConnection _sqlConnection = new SqlConnection(connectionString))
                {
                    _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand("INSERT INTO TABLE Bud_Employee (Department)" + "VALUES(@Department)", _sqlConnection))
                    {
                        
                        _sqlCommand.Parameters.Add("Department", SqlDbType.NVarChar);



                        _sqlCommand.ExecuteNonQuery();

                        Employee employee1 = new Employee( employee.EmployeeID, employee.Department);
                        employeeRepo.Add(employee1);
                    }
                }
                
            }

            catch (SqlException ex)
            {
                throw ex;
            }

            int result = -1;
            return result;

        }

        public Employee GetEmployeeByID(int id) 
        { 
            Employee employee= null;

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

                            Employee

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

        public void Delete (Employee employee) { }
    }
}
