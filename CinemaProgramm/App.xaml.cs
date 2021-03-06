using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using DLL.Context;
using Microsoft.EntityFrameworkCore;
using BLL.Service;
using DLL.Repository;
using CinemaProgramm.ViewModel;
using DLL.Model;

namespace CinemaProgramm
{
    public partial class App : Application
    {
        public static IServiceProvider _servProvider;
        public App()
        {
            var services = new ServiceCollection();
            PrepareDataService(services);
            _servProvider = services.BuildServiceProvider();
        }

        public static void PrepareDataService(ServiceCollection servCollect)
        {
            //Main
            servCollect.AddSingleton<AuthorizationWindow>();
            //Context
            servCollect.AddDbContext<CinemaContext>(op => op.UseSqlServer(ConfigurationManager.ConnectionStrings["sConnect"].ConnectionString));
            servCollect.AddSingleton<CinemaContext>();
            //Repository
            servCollect.AddTransient<EmployeeRepo>();
            servCollect.AddTransient<LoginRepo>();
            servCollect.AddTransient<TicketRepo>();
            servCollect.AddTransient<HallRepo>();
            servCollect.AddTransient<SessionRepo>();
            servCollect.AddTransient<FilmRepo>();
            //Services
            servCollect.AddTransient<AdminService>();
            servCollect.AddTransient<EmployeeService>();
            servCollect.AddTransient<LoginService>();
            servCollect.AddTransient<SessionService>();
            servCollect.AddTransient<TicketService>();
            //ViewModel
            servCollect.AddTransient<LoginDataViewModel>();

            //Model
            servCollect.AddSingleton<Employee>();
            servCollect.AddSingleton<LoginData>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var wind = _servProvider.GetService<AuthorizationWindow>();
            wind.ShowDialog();
        }
    }
}
