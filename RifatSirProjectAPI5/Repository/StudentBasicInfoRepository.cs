using System.Collections.Generic;
using System.Linq;
using RifatSirProjectAPI5.Models;

namespace RifatSirProjectAPI5.Repository
{
    public class StudentBasicInfoRepository : DatabaseRepository
    {
        public StudentBasicInfo Add(StudentBasicInfo studentBasicInfo) 
        {
            databaseContext.StudentBasicInfoTable.Add(studentBasicInfo);
            databaseContext.SaveChanges();
            return studentBasicInfo;
        }

        public List<StudentBasicInfo> GetAll() 
        {
            return databaseContext.StudentBasicInfoTable.OrderBy(StudentBasicInfo => StudentBasicInfo.BSSEROLL).ToList();
        }

        public StudentBasicInfo GetByBSSEROLL(int BSSEROLL)
        {
            return databaseContext.StudentBasicInfoTable.SingleOrDefault(StudentBasicInfo=> StudentBasicInfo.BSSEROLL == BSSEROLL);
        }
        public StudentBasicInfo GetById(int id)
        {
            return databaseContext.StudentBasicInfoTable.SingleOrDefault(StudentBasicInfo => StudentBasicInfo.Id == id);
        }

        public StudentBasicInfo Update(StudentBasicInfo studentBasicInfo) 
        {
            databaseContext.StudentBasicInfoTable.Update(studentBasicInfo);
            databaseContext.SaveChanges();
            return studentBasicInfo;
        }

        public bool Delete(int BSSEROLL) 
        {
            databaseContext.StudentBasicInfoTable.Remove(GetByBSSEROLL(BSSEROLL));
            databaseContext.SaveChanges();
            return true;
        }
    }
}
