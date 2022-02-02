using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Library_Mvc_Jashim.Models
{
    public class LibrariansDB
    {
        //Declaring connection string  
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //Return list of all Librarian 
        public List<Librarians> ListAll()
        {
            List<Librarians> lst = new List<Librarians>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectLibrarian", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Librarians
                    {
                        LibrarianID = Convert.ToInt32(rdr["LibrarianID"]),      // LibrarianId
                        Name = rdr["Name"].ToString(),
                        Age = Convert.ToInt32(rdr["Age"]),
                        Email = rdr["Email"].ToString(),
                        Address = rdr["Address"].ToString(),
                    });
                }
                return lst;
            }
        }

        //Method for Adding a Librarian  
        public int Add(Librarians lbn)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateLibrarian", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", lbn.LibrarianID);
                com.Parameters.AddWithValue("@Name", lbn.Name);
                com.Parameters.AddWithValue("@Age", lbn.Age);
                com.Parameters.AddWithValue("@Email", lbn.Email);
                com.Parameters.AddWithValue("@Address", lbn.Address);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Librarian record  
        public int Update(Librarians lbn)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateLibrarian", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", lbn.LibrarianID);
                com.Parameters.AddWithValue("@Name", lbn.Name);
                com.Parameters.AddWithValue("@Age", lbn.Age);
                com.Parameters.AddWithValue("@Email", lbn.Email);
                com.Parameters.AddWithValue("@Address", lbn.Address);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee  
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteLibrarian", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}