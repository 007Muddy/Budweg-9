﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ProjektBudweg.Model;

namespace ProjektBudweg.ViewModel.Repositories
{
    public class AdminRepo
    {
        private Admin admin { get; set; }
        private int _id;
        private string connectionString { get; } = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;


        //Check for authentication and return a bool
        public bool AuthenticateUser(Admin admin)
        {
            /*
             In this example, I'm reading the value of the "Username" and "Password" columns
            in each row and comparing them to the inputted username and password. If they match, 
            the code returns true, indicating that the authentication was successful. 
             */
            bool accepted = false;
            try
            {

                //Query through Database to check Authentication
                using (SqlConnection sq = new SqlConnection(connectionString))
                {
                    sq.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT UserName, Password FROM Budweg_Admin", sq))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //iterate through DB
                            while (reader.Read())
                            {
                                //Check if username matches
                                if (admin.UserName == reader["UserName"].ToString())
                                {

                                    ////Decryption of password///
                                    //It then uses the Convert.FromBase64String method to convert the savedPasswordHash string
                                    //into a byte array called "hashBytes". This is because the hashed password is stored in a
                                    //Base64 encoded string format, and this method converts it back to its original binary format
                                    byte[] hashBytes = Convert.FromBase64String(reader["Password"].ToString());
                                    //Next, it creates a new byte array called "salt" with a length of 16 bytes,
                                    //which is the same length as the salt used in the encryption process
                                    byte[] salt = new byte[16];
                                    //It uses the Array.Copy method to copy the first 16 bytes of the
                                    //hashBytes array into the salt array. In this way we can separate the salt from the hash.
                                    Array.Copy(hashBytes, 0, salt, 0, 16);
                                    //It creates a new instance of the Rfc2898DeriveBytes class, passing in the user input password,
                                    //salt and number of rounds
                                    var pbkdf2 = new Rfc2898DeriveBytes(admin.Password, salt, 10000);
                                    //It then calls the GetBytes method to generate a byte array of the hashed password.
                                    byte[] hash = pbkdf2.GetBytes(20);

                                    accepted = true;
                                    //It then uses a for loop to iterate through the hashBytes array, starting at the 17th position (16th index),
                                    //which is where the actual hashed password begins, since the first 16 bytes are the salt
                                    for (int i = 0; i < 20; i++)
                                    {
                                        //It compares each byte of the hashBytes array to the corresponding byte in the hash array,
                                        //using an if statement. If any of the bytes do not match, accepted = false.
                                        if (hashBytes[i + 16] != hash[i])
                                        {
                                            accepted = false;
                                            break;
                                        }
                                        //If the for loop completes without throwing an exception,
                                        //it means that the user entered the correct password and it prints "password is correct!

                                    }


                                }


                            }
                        }
                    }


                    //if (accepted)
                    //{
                    //    //using (SqlConnection sq2 = new SqlConnection(ConnectionString))
                    //    //{
                    //    //    sq2.Open();
                    //    using (SqlCommand cmd2 = new SqlCommand("UPDATE Users SET Mood = @mood " +
                    //        "WHERE Username = @username", sq))
                    //    {

                    //        cmd2.Parameters.AddWithValue("@mood", mood);
                    //        cmd2.Parameters.Add("@mood", SqlDbType.NVarChar).Value = mood;
                    //        cmd2.Parameters.AddWithValue("@username", username);
                    //        cmd2.ExecuteNonQuery();
                    //    }

                    //}
                    //}
                }

                //Update Mood to the employee
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return accepted;
        }


        public void Add(string username, string password, string role)
        {

            try
            {
                //Encryption using hash and salt///
                //Salt Rounds
                int rounds = 10000;
                //creating a byte array called salt
                byte[] salt;
                //with a length of 16 bytes, which is filled with random bytes using
                //RNGCryptoServiceProvider.
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                //New instans of the Rfc2898DeriveBytes class
                //passing in the password, salt, and number of rounds as arguments.
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, rounds);
                //Calls GetBytes method to generate a byte array of the hashed password
                byte[] hash = pbkdf2.GetBytes(20);// length of 20 bytes
                byte[] hashBytes = new Byte[36]; //length of 36 bytes
                //It uses the Array.Copy method to copy the salt bytes into the first 16 positions
                //of the hashBytes array
                Array.Copy(salt, 0, hashBytes, 0, 16);
                //It uses the Array.Copy method to copy the hashed password bytes into
                //the next 20 positions of the hashBytes array.
                Array.Copy(hash, 0, hashBytes, 16, 20);
                //It uses the Convert.ToBase64String method to convert the hashBytes array
                //into a base64 encoded string, which can be safely stored in the database
                string hashedPassword = Convert.ToBase64String(hashBytes);


                //I can use this line of code to increment the id Count
                //To then later set the UserId to id, to get the proper UserId number
                _id = 1;
                using (SqlConnection sq = new SqlConnection(connectionString))
                {
                    sq.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Budweg_Admin", sq))
                    {
                        using (SqlDataReader sar = cmd.ExecuteReader())
                        {
                            while (sar.Read())
                            {
                                _id++;
                            }
                        }
                    }
                }

                //A New SqlConnection object is created
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    //We use SqlCommand class to create an SQL INSERT Statement
                    using (SqlCommand command = new SqlCommand("INSERT INTO Budweg_Admin (Username, Password, Role) " +
                        "VALUES(@username, @password, @role)", sqlConnection))
                    {

                        // command.Parameters.AddWithValue("@userId", _id);
                        command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                        command.Parameters.Add("@password", SqlDbType.NVarChar).Value = hashedPassword;
                        command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }

    }
}
