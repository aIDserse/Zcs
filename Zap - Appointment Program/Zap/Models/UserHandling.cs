using Dapper;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Zap.Models
{
    public class UserHandling
    {
        private string s;
        public UserHandling(IConfiguration configuration)
        {
            s = configuration.GetConnectionString("dbConnection");
        }
        public User FindUser(string n, string p)
        {
            string query = @"SELECT * FROM users WHERE Email = @mail AND password = @password";
            using var con = new MySqlConnection(s);
            var param = new
            {
                mail = n,
                password = ComputeSha256(p)
            };
            return con.Query<User>(query, param).SingleOrDefault();
        }

        public void SendMailRegistration(string Mail, int ID)
        {
            using (MailMessage mail = new MailMessage("Test1.test69420@gmail.com", Mail))
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                mail.Subject = "Email di conferma";
                mail.Body =
                    "<html>" +
                    "<head>" +
                    "<style>" +
                    "h1 { color: #333; }" +
                    "h3 { color: #666; }" +
                    ".btn { background-color: #4CAF50; border: none; color: white; padding: 10px 20px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px; margin: 4px 2px; cursor: pointer; }" +
                    "</style>" +
                    "</head>" +
                    "<body>" +
                    "<div style=\"text-align: center;\">" +
                    "<h1>You did it!</h1>" +
                    "<p><h3>Thank you for creating the account!.</h3></p>" +

                    "<form action='https://localhost:7100/Home/DeleteRegistration/" + ID + "'>" +
                    "<input type=\"hidden\" name=\"ID\" value='" + ID + "' />" +
                    "<p><h3>If it wasn't you, click here to delete the account.</h3></p>" +
                    "<button type=\"submit\" class=\"btn\">DELETE ACCOUNT</button>" +
                    "</form>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                mail.IsBodyHtml = true;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("Test1.test69420@gmail.com", "jsjaglsrscghkxhr");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
        public void SendMailReservation(string Mail, Happening e)
        {
            using (MailMessage mail = new MailMessage("Test1.test69420@gmail.com", Mail))
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                mail.Subject = "Conferma prenotazione";
                mail.Body =
                    "<html>" +
                    "<head>" +
                    "<style>" +
                    "h1 { color: #333; }" +
                    "h3 { color: #666; }" +
                    ".btn { background-color: #4CAF50; border: none; color: white; padding: 10px 20px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px; margin: 4px 2px; cursor: pointer; }" +
                    "</style>" +
                    "</head>" +
                    "<body>" +
                    "<div style=\"text-align: center;\">" +
                    "<h1>Thank you for enrolling for this event!!</h1>" +
                    "<p><h3>You subscribed to the event:</h3></p>" +
                    "<p><strong>" + e.Title + "</strong></p>" +
                    "<p>" + e.Description + "</p>" +
                    "<p>Data: " + e.Date + "</p>" +
                    "<form action='https://localhost:7100/Home/DeleteReservation/" + e.ID + "'>" +
                    "<input type=\"hidden\" name=\"ID\" value='" + e.ID + "' />" +
                    "<p><h3>If it wasn't you or you wish to delete the reservation, click here:</h3></p>" +
                    "<button type=\"submit\" class=\"btn\">DELETE RESERVATION</button>" +
                    "</form>" +
                    "</div>" +
                    "</body>" +
                    "</html>";
                mail.IsBodyHtml = true;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("Test1.test69420@gmail.com", "jsjaglsrscghkxhr");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }


        public bool InsertUser(HappeningHandler u)
        {
            using var con = new MySqlConnection(s);
            var query = @"INSERT INTO users(name, surname, Email, password, role, MuseumID) VALUES(@name, @surname, @mail, @password, @role, @MuseumID)";
            var param = new
            {
                name = u.Name,
                surname = u.Surname,
                mail = u.Email,
                password = ComputeSha256(u.Password),
                role = "Basic",
                MuseumID = 1//u.MuseumID
            };
            try
            {
                con.Execute(query, param);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public User GiveUser(int id)
        {
            string query = @"SELECT * FROM users WHERE ID=@Id";
            using var con = new MySqlConnection(s);
            var param = new
            {
                Id = id
            };
            return con.Query<User>(query, param).SingleOrDefault();
        }

        public Reservation ReturnReservation(int idP, int idR )
        {
            string query = @"SELECT * FROM reservations WHERE EventID=@Idp AND UserID=@Idr";
            using var con = new MySqlConnection(s);
            var param = new
            {
                Idp = idP,
                Idr = idR

            };
            return con.Query<Reservation>(query, param).SingleOrDefault();
        }

        public IEnumerable<Museum> MuseumsList()
        {
            using var con = new MySqlConnection(s);
            return con.Query<Museum>("select * from museums");
        }

        private string ComputeSha256(string s)
        {
            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public List<string> MailList()
        {
            using var con = new MySqlConnection(s);
            return con.Query<string>("select email from users").AsList();
        }
    }
}
