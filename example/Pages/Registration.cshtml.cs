using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace example.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public string Register { get; set; }
        public void OnPost()
        {
            string name = Request.Form["name"];
            string email= Request.Form["email"];
            string password = Request.Form["pass"];
            string gender = Request.Form["gen"];
            string city = Request.Form["city"];
            string date = Request.Form["date"];
            string phno = Request.Form["phno"];

            using (MySqlConnection con = new MySqlConnection("server=localhost;username=root;database=vv;port=3306;password=sakshi01@5"))
            {
                //opening connection
                con.Open();

                //Inserting values
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = "INSERT INTO reg(name,gender,date,phoneno,email,password,city) VALUES(?name, ?gender, ?date, ?phno, ?email, ?password, ?city)";

                comm.Parameters.AddWithValue("?name", name);
                comm.Parameters.AddWithValue("?gender", gender);
                comm.Parameters.AddWithValue("?date", date);
                comm.Parameters.AddWithValue("?phno", phno);
                comm.Parameters.AddWithValue("?email", email);
                comm.Parameters.AddWithValue("?password", password);
                comm.Parameters.AddWithValue("?city", city);

                //passing the query and connection var to command
                //MySqlCommand cmd = new MySqlCommand(query, con);

                //Execute command
                comm.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
