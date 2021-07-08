using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RifatSirProjectAPI5.Repository;
using RifatSirProjectAPI5.Models;

namespace RifatSirProjectAPI5.Repository
{
    public class StudentAuthRepository: DatabaseRepository
    {
        public StudentAuth Add(StudentAuth studentAuth)
        {
            databaseContext.StudentAuthTable.Add(studentAuth);
            databaseContext.SaveChanges();
            return studentAuth;
        }

        /*public List<StudentAuth> GetAll()
        {
            return databaseContext.StudentAuthTable.ToList();
        }*/

        public StudentAuth GetByBSSEROLL(int BSSEROLL)
        {
            return databaseContext.StudentAuthTable.SingleOrDefault(StudentAuth => StudentAuth.BSSEROLL == BSSEROLL);
        }

        public StudentAuth GetByEmail(string Email)
        {
            return databaseContext.StudentAuthTable.SingleOrDefault(StudentAuth => StudentAuth.Email == Email);
        }

        public StudentAuth Update(StudentAuth studentAuth)
        {
            databaseContext.StudentAuthTable.Update(studentAuth);
            databaseContext.SaveChanges();
            return studentAuth;
        }

        public bool Delete(int BSSEROLL)
        {
            databaseContext.StudentAuthTable.Remove(GetByBSSEROLL(BSSEROLL));
            databaseContext.SaveChanges();
            return true;
        }
    }
}
