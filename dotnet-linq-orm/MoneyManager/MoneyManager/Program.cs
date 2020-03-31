using MoneyManager.Models;
using System;
using System.Linq;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MoneyManagerContext db = new MoneyManagerContext())
            {
                User user1 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Bill",
                    Email = "bill@gmail.com",
                    Hash = "123",
                    Salt = "321"
                };
                User user2 = new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Sara",
                    Email = "sara@gmail.com",
                    Hash = "456",
                    Salt = "765"
                };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Saved successfully.");

                var users = db.Users.ToList();
                Console.WriteLine("User list:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }
            Console.Read();
        }
    }
}
