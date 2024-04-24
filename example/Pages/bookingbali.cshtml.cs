using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using example.models;

namespace example.Pages
{
    public class bookingbaliModel : PageModel
    {
        [BindProperty]
        public required Booking book { get; set; }

        public void OnPost()
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string tourpackage = Request.Form["tour"];
            string date = Request.Form["date"];
            string msg = Request.Form["message"];


            using (MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=vv;port=3306;password=sakshi01@5"))
            {
                //opening connection
                con.Open();

                //Inserting values
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "INSERT INTO abooking(name,email,tourpackage,date,msg) VALUES(?name, ?email, ?tourpackage, ?date, ?msg)";

                comm.Parameters.AddWithValue("?name", name);
                comm.Parameters.AddWithValue("?email", email);
                comm.Parameters.AddWithValue("?tourpackage", tourpackage);
                comm.Parameters.AddWithValue("?date", date);
                comm.Parameters.AddWithValue("?msg", msg);


                //passing the query and connection var to command
                //MySqlCommand cmd = new MySqlCommand(query, con);

                //Execute command
                comm.ExecuteNonQuery();

                con.Close();
            }
        }
    }

}