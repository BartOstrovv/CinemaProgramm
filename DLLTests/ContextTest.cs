using DLL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using Xunit;
using DLL.Model;
using System.Linq;

namespace DLLTests
{
    public class ContextTest
    {
        public CinemaContext db;
        public ContextTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestForCinemaProjDB;Integrated Security=True;Connect Timeout=30;").Options;

            db = new CinemaContext(options);
        }

        [Fact]
        public void CreateDb()
        {
           /* var optionsBuilder = new DbContextOptionsBuilder<CinemaContext>();
            var options = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestForCinemaProjDB;Integrated Security=True;Connect Timeout=30;").Options;

            try
            {
                var db = new CinemaContext(options);
                Assert.NotNull(db);
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }*/
        }

        [Fact]
        public void AddFilm()
        {
            try
            {
                var film = new Film() { Description = "New Test Film", Duration = 1.5, Genre = "Comedy", Price = 150, Title = "COMEDY CLUB" };
                db.Films.Add(film);
                db.SaveChanges();

                var f = db.Films.Where(x => x.Description == "New Test Film" && x.Duration == 1.5 && x.Genre == "Comedy" && x.Title == "COMEDY CLUB" && x.Price == 150);
                Assert.NotNull(f);
                db.Films.Remove(film);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void AddEmployee()
        {
            try
            {
                var logData = new LoginData() { Login = "testLogin", Password = "testPass" };
                db.Logins.Add(logData);
                db.SaveChanges();

                var l = db.Logins.First(x => x.Login == "testLogin" && x.Password == "testPass");
                Assert.NotNull(l);

                var emp = new Employee()
                {
                    Birthday = new DateTime(1998, 11, 24, 6, 55, 10),
                    LoginDataID = l.Id,
                    Name = "testName",
                    Role = "Manager",
                    Salary = 1000,
                    StartWork = new DateTime(2020, 10, 10, 10, 10, 10),
                    Surname = "TestSurname",
                    UserInfo = logData
                };

                db.Employees.Add(emp);
                db.SaveChanges();

                var e = db.Employees.Where
                    (x => x.Name== "testName" && x.Surname== "TestSurname" && x.Role== "Manager");
                Assert.NotNull(e);
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void AddHall()
        {
            try
            {
                var hall = new Hall() { MaxSeats = 100, Number = 15 };
                db.Halls.Add(hall);
                db.SaveChanges();

                var h = db.Halls.First(x => x.MaxSeats == 100 && x.Number == 15);
                Assert.NotNull(h);
                db.Halls.Remove(hall);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void AddLoginData()
        {
            try
            {
                var log = new LoginData() { Login = "testLog", Password = "1234TestPass" };
                db.Logins.Add(log);
                db.SaveChanges();

                var h = db.Logins.First(x => x.Login == "testLog" && x.Password == "1234TestPass");
                Assert.NotNull(h);
                db.Logins.Remove(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void AddPlace()
        {
            try
            {
                var hall = new Hall() { MaxSeats = 100, Number = 15 };
                db.Halls.Add(hall);
                db.SaveChanges();

                var h = db.Halls.First(x => x.Number == 15 && x.MaxSeats == 100);
                Assert.NotNull(h);

                var place = new Place() { Number = 14, Hall = hall, Price = 100, Row = 2 };
                db.Places.Add(place);
                db.SaveChanges();

                var p = db.Places.First(x => x.Number == 14 && x.Price == 100 && x.Row == 2);
                Assert.NotNull(p);
                db.Halls.Remove(h);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void AddSession()
        {
            try
            {
                db.Films.Add(new Film() { Description = "testDescription", Duration = 1, Genre = "testGenre", Price = 1000, Title = "titleTest" });
                db.SaveChanges();
                var film = db.Films.First(x => x.Description == "testDescription" && x.Duration == 1 && x.Genre == "testGenre" && x.Price == 1000);
                Assert.NotNull(film);

                db.Halls.Add(new Hall() { MaxSeats = 1000, Number = 1 });
                db.SaveChanges();
                var hall = db.Halls.First(x => x.MaxSeats == 1000 && x.Number == 1);
                Assert.NotNull(hall);

                db.Sessions.Add(new Session()
                {
                    Film = film,
                    Hall = hall,
                    StartTime = new DateTime(10000),
                    EndTime = new DateTime(10500),
                    Header = "COOL FILM TEST HEADER"
                });
                db.SaveChanges();
                var sess = db.Sessions.First(x => x.Header == "COOL FILM TEST HEADER" && x.Hall == hall && x.Film == film);
                Assert.NotNull(sess);
                db.Sessions.Remove(sess);
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Fact]
        public void AddTicket()
        {
            try
            {
                var hall = new Hall() { MaxSeats = 100, Number = 15 };
                db.Halls.Add(hall);
                db.SaveChanges();

                var h = db.Halls.First(x => x.Number == 15 && x.MaxSeats == 100);
                Assert.NotNull(h);

                var place = new Place() { Number = 14, Hall = hall, Price = 100, Row = 2 };
                db.Places.Add(place);
                db.SaveChanges();

                var p = db.Places.First(x => x.Number == 14 && x.Price == 100 && x.Row == 2);
                Assert.NotNull(p);

                db.Films.Add(new Film() { Description = "testDescription", Duration = 1, Genre = "testGenre", Price = 1000, Title = "titleTest" });
                db.SaveChanges();
                var film = db.Films.First(x => x.Description == "testDescription" && x.Duration == 1 && x.Genre == "testGenre" && x.Price == 1000);
                Assert.NotNull(film);

                db.Sessions.Add(new Session()
                {
                    Film = film,
                    Hall = hall,
                    StartTime = new DateTime(10000),
                    EndTime = new DateTime(10500),
                    Header = "COOL FILM TEST HEADER"
                });
                db.SaveChanges();
                var sess = db.Sessions.First(x => x.Header == "COOL FILM TEST HEADER" && x.Hall == hall && x.Film == film);
                Assert.NotNull(sess);

                var logData = new LoginData() { Login = "testLogin", Password = "testPass" };
                db.Logins.Add(logData);
                db.SaveChanges();

                var l = db.Logins.First(x => x.Login == "testLogin" && x.Password == "testPass");
                Assert.NotNull(l);

                var emp = new Employee()
                {
                    Birthday = new DateTime(1998, 11, 24, 6, 55, 10),
                    LoginDataID = l.Id,
                    Name = "testName",
                    Role = "Manager",
                    Salary = 1000,
                    StartWork = new DateTime(2020, 10, 10, 10, 10, 10),
                    Surname = "TestSurname",
                    UserInfo = logData
                };

                db.Employees.Add(emp);
                db.SaveChanges();

                var e = db.Employees.First
                    (x => x.Name == "testName" && x.Surname == "TestSurname" && x.Role == "Manager");
                Assert.NotNull(e);

                db.Tickets.Add(new Ticket()
                {
                    Employee = e,
                    Phone = "050202-3-212",
                    Place = p,
                    PlaceID = p.Id,
                    Session = sess,
                    SessionID = sess.Id,
                    Status ="test status"
                });
                db.SaveChanges();

                var tick = db.Tickets.First(x => x.Phone == "050202-3-212");
                Assert.NotNull(tick);
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

    }
}
