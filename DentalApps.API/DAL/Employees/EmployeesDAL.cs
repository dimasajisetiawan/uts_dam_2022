using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalApps.API.DAL.Interface;
using DentalApps.API.Data;
using DentalApps.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalApps.API.DAL.Employees
{
    public class EmployeesDAL : IEmployees
    {
        private readonly ApplicationDbContext _db;

        public EmployeesDAL(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<Employee> Create(Employee objEntity)
        {
            try
            {
                await _db.Employees.AddAsync(objEntity);
                await _db.SaveChangesAsync();
                return objEntity;
            }
            catch (DbUpdateException dbEx)
            {
                
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var deleteEmployee = await GetById(id);
                if(deleteEmployee==null) throw new ArgumentNullException($"Data {id} tidak ditemukan");
                _db.Employees.Remove(deleteEmployee);
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var results = await _db.Employees.OrderBy(e => e.Username).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Employee> GetById(string id)
        {
            var result = await _db.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();
            if (result == null) throw new ArgumentNullException($"Error: Data tidak ditemukan");
            return result;
        }

        public async Task<Employee> Update(string id, Employee objEntity)
        {
            try
            {
                var editEmployee =  await GetById(id);
                editEmployee.FullName = objEntity.FullName;
                editEmployee.Email = objEntity.Email;
                await _db.SaveChangesAsync();
                return editEmployee;

            }
            catch (DbUpdateException dbEx)
            {
                
                throw new Exception(dbEx.InnerException.Message);
            }
        }
    }
}