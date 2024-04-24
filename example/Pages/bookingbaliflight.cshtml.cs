using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using example.models;

namespace example.Pages
{
    public class bookingbaliflightModel : PageModel
    {
        [BindProperty]
        public required Flightbooking book { get; set; }

        public void OnPost()
        {
            string departure = Request.Form["departure"];
            string destination = Request.Form["destination"];
            string date = Request.Form["date"];
            string passengers = Request.Form["passengers"];



            using (MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=vv;port=3306;password=sakshi01@5"))
            {
                //opening connection
                con.Open();

                //Inserting values
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "INSERT INTO fbooking(departure,destination,date,passengers) VALUES(?departure, ?destination, ?date, ?passengers)";

                comm.Parameters.AddWithValue("?departure", departure);
                comm.Parameters.AddWithValue("?destination", destination);
                comm.Parameters.AddWithValue("?date", date);
                comm.Parameters.AddWithValue("?passengers", passengers);



                //passing the query and connection var to command
                //MySqlCommand cmd = new MySqlCommand(query, con);

                //Execute command
                comm.ExecuteNonQuery();

                con.Close();
            }
        }
    }

}