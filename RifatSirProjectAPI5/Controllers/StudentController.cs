using Microsoft.AspNetCore.Mvc;
using RifatSirProjectAPI5.Models;
using RifatSirProjectAPI5.Repository;

namespace RifatSirProjectAPI5.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentBasicInfoRepository _studentBasicInfoRepository = new StudentBasicInfoRepository();
        private readonly StudentAuthRepository _studentAuthRepository = new StudentAuthRepository();

        [HttpPost("surji/student/signUp")]
        public IActionResult StudentSignUp([FromBody] StudentAuth studentAuth)
        {
            var checkAccount = _studentAuthRepository.GetByBSSEROLL(studentAuth.BSSEROLL);

            if (checkAccount == null)
            {
                var addedStudent = _studentAuthRepository.Add(studentAuth);

                return Ok(true);
            }
            else
            {
                return Ok("already exists");
            }
        }

        [HttpPost("surji/student/signUp2")]
        public IActionResult StudentSignUp2([FromBody] StudentBasicInfo student)
        {

            var addedStudent = _studentBasicInfoRepository.Add(student);

            return Ok(true);
        }


        [HttpPost("surji/student/signIn")]
        public IActionResult StudentSignIn([FromBody] StudentAuth studentAuth)
        {
            var checkAccount = _studentAuthRepository.GetByEmail(studentAuth.Email);
            if (checkAccount != null)
            {
                if (checkAccount.password == studentAuth.password)
                {
                    return Ok(_studentBasicInfoRepository.GetByBSSEROLL(checkAccount.BSSEROLL));
                }
            }

            return Ok(false);
        }


        [HttpGet("surji/student/getAll")]
        public IActionResult getAllStudentBasicInfo()
        {
            return Ok(_studentBasicInfoRepository.GetAll());
        }

        [HttpPost("surji/student/update")]
        public IActionResult updateStudentBasicInfo([FromBody] StudentBasicInfo student)
        {
            _studentBasicInfoRepository.Update(student);
            return Ok(true);   

        }

        [HttpPost("surji/student/updatePassword")]
        public IActionResult updateStudentAuth([FromBody] StudentAuth studentAuth)
        {
            _studentAuthRepository.Update(studentAuth);
            return Ok(true);

        }

        [HttpPost(("surji/student/delete"))]
        public IActionResult deleteAccount([FromBody] int BSSEROLL) 
        {
            _studentAuthRepository.Delete(BSSEROLL);
            _studentBasicInfoRepository.Delete(BSSEROLL);
            return Ok(true);
        }

    }
}
