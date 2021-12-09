using DLL.Model;
using DLL.Repository;
using System.Threading.Tasks;
using System.Linq;

namespace BLL.Service
{
    public class EmployeeService
    {
        private readonly EmployeeRepo _employeeRepo;

        public EmployeeService(EmployeeRepo repo)
        {
            _employeeRepo = repo;
        }

        public async Task ChangeLoginDataAsync(Employee emp, string newLogin, string newPassword)
        {
            var e = (await _employeeRepo.FindByConditionWithLoginAsync(x => x.Id == emp.Id).ConfigureAwait(false))?.First();
            if (e == null)
                return;
            e.UserInfo.Login = newLogin;
            e.UserInfo.Password = newPassword;
            await _employeeRepo.UpdateAsync(emp);
        }
    }
}
