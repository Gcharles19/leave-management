using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CheckAllocation(int leaveTypeId, string employeeID)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(p => p.EmployeeId == employeeID && p.LeaveTypeID == leaveTypeId && p.Period == period).Any();
        }
        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            return _db.LeaveAllocations.Include(q => q.LeaveType)
                .Include(x => x.Employee)
                .ToList();
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(x => x.Employee)
                .FirstOrDefault(q => q.Id == id);
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(p => p.EmployeeId == id && p.Period == period).ToList();
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveTypes.Any(p => p.Id == id);
            return exists;
        }

        public bool Save()
        {
            var saveChanges = _db.SaveChanges();
            return saveChanges > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
