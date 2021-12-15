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
        private readonly EmployeeRepo _employerRepos;
        public LoginService(EmployeeRepo empRepo)
        {
            _employerRepos = empRepo;
        }

        public async Task<Employee> AutorizationAsync(LoginData login)
        {
            try
            {
                return (await _employerRepos.FindByConditionWithLoginAsync(empl => empl.UserInfo.Login == login.Login && empl.UserInfo.Password == login.Password))?.First();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
           
        
    }
}
