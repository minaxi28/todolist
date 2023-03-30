namespace SinglePageApp
{
    public class UserSettings
    {
        private static List<User> users = new List<User> ();
        private static int Count = 0;
        private static readonly string[] names = new string[] {"Kiran","Jignu","Ravi","Chetan" };
        private static readonly string[] surnames = new string[] { "Desai", "Joshi", "Tamankar", "Chanekar" };
        private static readonly string[] email = new string[] { "@gamil.com", "@yahoo.com", "@reddit.com"};

        static UserSettings()
        {
           
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                string currName = names[rnd.Next(names.Length)];
                User user = new User
                {
                    Id = Count++,
                    Name = currName + " " + surnames[rnd.Next(surnames.Length)],
                    Email = currName.ToLower() + email[rnd.Next(email.Length)],
                    Phone = "+1 888-452-1232"
                };
                users.Add(user);
            }
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public User Create(User user)
        {
            user.Id = Count++;
            users.Add(user);
            return user;
        }
         public User Update(int id,User user)
        {
            User found = users.Where(us => us.Id == id).FirstOrDefault();
            if (found != null) 
            { 
                found.Name = user.Name;
                found.Email = user.Email; 
                found.Phone = user.Phone;
            }
            return found;
        }
        public void Delete(int id)
        {
            users.RemoveAll(n => n.Id == id);
        }
    }
}
