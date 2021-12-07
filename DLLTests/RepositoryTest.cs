using DLL.Context;
using DLL.Model;
using DLL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace DLLTests
{
    public class RepositoryTest
    {
        [Fact]
        public void AddTicket()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestForCinemaProjDB;Integrated Security=True;Connect Timeout=30;").Options;

            var db = new CinemaContext(options);
            try
            {
                var repo = new TicketRepo(db);

                var hall = new Hall() { MaxSeats = 100, Number = 15 };
                db.Halls.Add(hall);
                db.SaveChanges();

                var place = new Place() { Number = 14, Hall = hall, Price = 100, Row = 2 };
                db.Places.Add(place);
                db.SaveChanges();

                var film = new Film() { Description = "testDescription", Duration = 1, Genre = "testGenre", Price = 1000, Title = "titleTest" };
                db.Films.Add(film);
                db.SaveChanges();

                var sess = new Session()
                {
                    Film = film,
                    Hall = hall,
                    StartTime = new DateTime(10000),
                    EndTime = new DateTime(10500),
                    Header = "COOL FILM TEST HEADER"
                };
                db.Sessions.Add(sess);
                db.SaveChanges();

                var logData = new LoginData() { Login = "testLogin", Password = "testPass" };
                db.Logins.Add(logData);
                db.SaveChanges();

                var emp = new Employee()
                {
                    Birthday = new DateTime(1998, 11, 24, 6, 55, 10),
                    LoginDataID = 1,
                    Name = "testName",
                    Role = "Manager",
                    Salary = 1000,
                    StartWork = new DateTime(2020, 10, 10, 10, 10, 10),
                    Surname = "TestSurname",
                    UserInfo = logData
                };

                db.Employees.Add(emp);
                db.SaveChanges();

                var tick = new Ticket()
                {
                    Employee = emp,
                    Phone = "050202-3-212",
                    Place = place,
                    PlaceID = 1,
                    Session = sess,
                    SessionID = 1,
                    Status = "test status"
                };

                repo.CreateAsync(tick).Wait();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }
    }
}
