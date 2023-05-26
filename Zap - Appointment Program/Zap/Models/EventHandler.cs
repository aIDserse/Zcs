using Dapper;
using MySql.Data.MySqlClient;

namespace Zap.Models
{
    public class EventHandler
    {
        private string s; //stringa di connessione

        public EventHandler(IConfiguration configuration)
        {
            s = configuration.GetConnectionString("dbConnection");
        }

        public IEnumerable<Happening> ListEvents()
        {
            using var con = new MySqlConnection(s);
            return con.Query<Happening>("SELECT * FROM events");
        }

        public bool NewEvent(Happening e)
        {
            using var con = new MySqlConnection(s);
            var query = @"INSERT INTO events(date,maxplaces,title,description,organizer) VALUES(@date, @maxplaces, @title, @description, @organizer)";
            var param = new
            {
                date = e.Date,
                maxplaces = e.MaxPlaces,
                title = e.Title,
                description = e.Description,
                organizer = e.Organizer
            };
            try
            {
                con.Execute(query, param);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public Happening getEvent(int id)
        {
            using var con = new MySqlConnection(s);
            return con.Query<Happening>("select * from events WHERE ID = " + id).FirstOrDefault();
        }

        public bool NewReservation(Reservation r)
        {
            using var con = new MySqlConnection(s);
            var query = @"INSERT INTO reservations(UserID,EventID) VALUES(@userID,@EventID)";
            var param = new
            {
                userID = r.UserID,
                eventID = r.EventID
            };
            try
            {
                con.Execute(query, param);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool DeleteReservation(Reservation r)
        {
            using var con = new MySqlConnection(s);
            var query = @"DELETE FROM reservations WHERE UserID=@Uid AND EventID=@Eid";
            var param = new
            {
                Uid = r.UserID,
                Eid = r.EventID
            };
            try
            {
                con.Execute(query, param);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool DeleteRegistration(User U)
        {
            using var con = new MySqlConnection(s);
            var query1 = @"DELETE FROM reservations WHERE UserID=@Uid";
            var query2 = @"DELETE FROM users WHERE ID=@Uid";

            var param = new
            {
                Uid = U.Id
            };
            try
            {
                con.Execute(query1, param);
                con.Execute(query2, param);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public IEnumerable<dynamic> ListAviables()
        {
            using var con = new MySqlConnection(s);
            return con.Query<dynamic>("SELECT events.ID, events.Title, " +
                "events.MaxPlaces, events.Description," +
                " events.Date, events.Organizer, " +
                "COUNT(reservations.EventID) AS NumPartecipants, " +
                "EVENTS.MaxPlaces - COUNT(reservations.EventID) AS Places " +
                "FROM events LEFT JOIN reservations " +
                "ON events.ID = reservations.EventID " +
                "GROUP BY events.ID, events.Title, events.MaxPlaces, events.Date, " +
                "events.Description, events.Organizer");
        }

        public int AviablePlacesEvent(Happening id)
        {
            using var con = new MySqlConnection(s);
            int i = con.Query<int>("SELECT EVENTS.MaxPlaces - COUNT(reservations.EventID) AS Places " +
                "FROM events LEFT JOIN reservations " +
                "ON events.ID = reservations.EventID " +
                "WHERE events.ID = " + id.ID).FirstOrDefault();
            return i;
        }



    }
}
