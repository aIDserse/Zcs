using MySql.Data.MySqlClient;
using System.Net.Mail;

namespace Zap.Models
{
    public class RegistrationHandling
    {
        private ISession session;
        public RegistrationHandling(ISession sessione)
        {
            session = sessione;
        }
        
        public string GiveUserRole()
        {
            string ruolo = "Guest";
            string s = session.GetString("roleUser");
            if (s != null)
            {
                ruolo = s;
            }
            return ruolo;
        }
        public int GiveUserID()
        {
            int ID = 0;
            int s = Convert.ToInt32(session.GetInt32("Persona"));
            if (s != 0)
            {
                ID = s;
            }
            return ID;
        }
        public void SetUser(User u)
        {
            session.SetString("roleUser", u.Role);
            session.SetString("Username", u.Email);
            session.SetInt32("Persona", u.Id);
        }
        public void Exit()
        {
            session.SetString("roleUser", "Guest");
            session.SetString("Username", "Guest");
            session.SetInt32("Persona", 0);
        }

    }
}
