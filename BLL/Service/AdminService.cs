using DLL.Repository;
using DLL.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BLL.Service
{
    public class AdminService
    {
        private readonly EmployeeRepo _employeeRepo;
        private readonly LoginRepo _loginRepo;

        private readonly HallRepo _hallRepo;

        public AdminService(EmployeeRepo empR, LoginRepo loginR, HallRepo hallR)
        {
            _employeeRepo = empR;
            _loginRepo = loginR;
            _hallRepo = hallR;
        }

        public async Task<IReadOnlyCollection<Employee>> GetEmployeesAsync() =>
            await _employeeRepo.GetEmployeesWithAllIncludedAsync().ConfigureAwait(false);

        public async Task<IReadOnlyCollection<Hall>> GetHallsAsync() =>
            await _hallRepo.GetAllWithPlacesAsync().ConfigureAwait(false);

        public async Task<bool> AddNewEmployeeAsync(Employee emp, string login, string pass)
        {
            var logData = new LoginData() { Login = login, Password = pass };
            await _loginRepo.CreateAsync(logData);
            var res = await _loginRepo.FindByConditionAsync(x => x.Login == login && x.Password == pass);
            if (res.First() == null)
                return false;
            logData.Id = res.First().Id;
            emp.LoginDataID = res.First().Id;
            emp.UserInfo = logData;
            await _employeeRepo.CreateAsync(emp);
            return true;
        }

        public async Task AddNewHallAsync(int number, int maxSeats) =>
           await _hallRepo.CreateAsync(new Hall() { MaxSeats = maxSeats, Number = number });

        public async Task ModifyEmployeeAsync(Employee emp)
        {
            var e = (await _employeeRepo.FindByConditionWithLoginAsync(x => x.Id == emp.Id))?.First();
            if (e == null)
                return;
            await _employeeRepo.UpdateAsync(emp);
        }

        public async Task ModifyHallAsync(Hall hall)
        {
            var h = (await _hallRepo.FindByConditionWithPlacesAsync(x => x.Id == hall.Id))?.First();
            if (h == null)
                return;
            await _hallRepo.UpdateAsync(hall);
        }
    }
}
