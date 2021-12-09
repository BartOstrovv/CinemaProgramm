using DLL.Model;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class LoginService
    {
        private readonly LoginRepo _loginRepo;
        public LoginService(LoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public async Task<Employee> AutorizationAsync(string login, string pass) =>
            (await _loginRepo.FindByConditionAsync(x => x.Login == login && x.Password == pass)).First()?.Employee;
    }
}
