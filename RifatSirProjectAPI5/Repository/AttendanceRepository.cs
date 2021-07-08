using RifatSirProjectAPI5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RifatSirProjectAPI5.Repository
{
    public class AttendanceRepository: DatabaseRepository
    {
        public Attendance Add(Attendance attendance)
        {
            databaseContext.AttendanceTable.Add(attendance);
            databaseContext.SaveChanges();
            return attendance;
        }

        public List<Attendance> GetAll()
        {
            return databaseContext.AttendanceTable.OrderByDescending(Attendance => Attendance.DateAndTime).ToList();
        }

        public List<Attendance> GetByDateTime(DateTime DateAndTime)
        {
            return databaseContext.AttendanceTable.Where(Attendance => Attendance.DateAndTime == DateAndTime).ToList();
        }

        public List<Attendance> GetByBSSEROLL(int BSSEROLL)
        {
            return databaseContext.AttendanceTable.Where(Attendance => Attendance.BSSEROLL == BSSEROLL).ToList();
        }

        public Attendance GetByBSSEROLLAndDateTime(int BSSEROLL, DateTime DateAndTime)
        {
            return databaseContext.AttendanceTable.SingleOrDefault(Attendance => Attendance.BSSEROLL == BSSEROLL && Attendance.DateAndTime == DateAndTime);
        }

        public Attendance GetById(int Id)
        {
            return databaseContext.AttendanceTable.SingleOrDefault(Attendance => Attendance.Id == Id);
        }

        public bool Delete(int Id)
        {
            databaseContext.AttendanceTable.Remove(GetById(Id));
            databaseContext.SaveChanges();
            return true;
        }
    }
}
