using System.Collections.Generic;
using System.Linq;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;
        
        public EmployeeManager(EmployeeContext context)
        {
            _employeeContext = context;
        }
        public IEnumerable<Employee> GetAll()
        {

            return _employeeContext.Employees.FromSqlRaw<Employee>(
                      "[dbo].[uspEmpDetails]").ToList();

        }
        public async Task<List<Employee>> Get(long id)
        {
            

            string storedProc = "exec uspEmpDetailbyId @EmployeeId";
            var EmployeeId = new SqlParameter("@EmployeeId", id);
            return await _employeeContext.Employees.FromSqlRaw<Employee>(storedProc, EmployeeId).ToListAsync();
        }
        public async Task Add(Employee entity)
        {
            string storedProc = "exec uspAddEmpDetail @FirstName, @LastName, @PhoneNumber";

            //var EmployeeId = new SqlParameter("@EmployeeId", 0);
            var FirstName = new SqlParameter("@FirstName", entity.FirstName);
            var LastName = new SqlParameter("@LastName", entity.LastName);
            var PhoneNumber = new SqlParameter("@PhoneNumber", entity.PhoneNumber);

            var result =  await _employeeContext.Employees.FromSqlRaw
                                                    (storedProc, FirstName, LastName, PhoneNumber).ToListAsync();
        }
        public async Task Update(Employee entity)
        {
            var EmployeeId = new SqlParameter("@EmployeeId", entity.EmployeeId);
            var FirstName = new SqlParameter("@FirstName", entity.FirstName);
            var LastName = new SqlParameter("@LastName", entity.LastName);
            var PhoneNumber = new SqlParameter("@PhoneNumber", entity.PhoneNumber);

            string storedProc = "exec uspUpdateEmpDetail @EmployeeId, @FirstName, @LastName, @PhoneNumber";

            var result = await _employeeContext.Employees.FromSqlRaw
                                        (storedProc, EmployeeId, FirstName, LastName, PhoneNumber).ToListAsync();
        }
        public async Task Delete(long id)
        {
            var EmployeeId = new SqlParameter("@EmployeeId", id);

            string storedProc = "exec uspDeleteEmpDetail @EmployeeId";

            var result = await _employeeContext.Employees.FromSqlRaw
                                        (storedProc, EmployeeId).ToListAsync();
        }
    }
}
