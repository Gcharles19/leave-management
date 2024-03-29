﻿using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            var isCReated = _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes =  _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
            //_db.LeaveTypes.FirstOrDefault();
            //throw new NotImplementedException();
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int Id)
        {
            throw new NotImplementedException();
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

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
