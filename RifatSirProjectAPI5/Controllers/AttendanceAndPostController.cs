using Microsoft.AspNetCore.Mvc;
using RifatSirProjectAPI5.Models;
using RifatSirProjectAPI5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RifatSirProjectAPI5.Controllers
{
    public class AttendanceAndPostController : Controller
    {
        public readonly CoursePostsRepository _coursePostsRepository = new CoursePostsRepository();
        public readonly AttendanceRepository _attendatnceRepository = new AttendanceRepository();

        [HttpPost("surji/course/post/create")]
        public IActionResult createNewPost([FromBody] CoursePosts coursePosts)
        {
            coursePosts.DateAndTime = DateTime.Now;
            _coursePostsRepository.Add(coursePosts);
            return Ok(true); 
        }


        [HttpGet("surji/course/post/getAll")]
        public IActionResult getAll()
        {
            return Ok(_coursePostsRepository.GetAll());
        }


        [HttpDelete("surji/course/post/delete")]
        public IActionResult deletePostFromCourse(int postId)
        {
            _coursePostsRepository.Delete(postId);
            return Ok(true);
        }

        [HttpPost("surji/course/post/update")]
        public IActionResult updatePost([FromBody] CoursePosts coursePosts)
        {
            _coursePostsRepository.Update(coursePosts);
            return Ok(true);
        }

        [HttpGet("surji/course/post/openAttendance")]
        public IActionResult openAttendancePost(int postId)
        {
            CoursePosts coursePosts = _coursePostsRepository.GetById(postId);
            coursePosts.Post = "on";
            _coursePostsRepository.Update(coursePosts);
            return Ok(true);
        }

        [HttpGet("surji/course/post/closeAttendance")]
        public IActionResult closeAttendancePost(int postId)
        {
            CoursePosts coursePosts = _coursePostsRepository.GetById(postId);
            coursePosts.Post = "off";
            _coursePostsRepository.Update(coursePosts);
            return Ok(true);
        }

        [HttpPost("surji/course/attendance/add")]
        public IActionResult addAttendanceByStudent([FromBody] Attendance attendance)
        {
            CoursePosts coursePosts = _coursePostsRepository.GetByDateTime(attendance.DateAndTime);

            if (coursePosts.Post == "on")
            {
                var checkAccount = _attendatnceRepository.GetByBSSEROLLAndDateTime(attendance.BSSEROLL, attendance.DateAndTime);
                if (checkAccount == null)
                {
                    _attendatnceRepository.Add(attendance);
                    return Ok(true);
                }
                else return Ok(false);
            }
            else {
                return Ok(false);
            }
        }

        [HttpPost("surji/course/attendance/addByTeacher")]
        public IActionResult addAttendanceByTeacher([FromBody] Attendance attendance)
        {
            _attendatnceRepository.Add(attendance);
            return Ok(true);
        }


        [HttpGet("surji/course/attendance/getAll")]
        public IActionResult getAllAttendanceOfCourse()
        {
            return Ok(_attendatnceRepository.GetAll());
        }

        [HttpGet("surji/course/attendance/getAllByDateTime")]
        public IActionResult getAllAttendanceByDateTime(DateTime dateTime)
        {
            return Ok(_attendatnceRepository.GetByDateTime(dateTime));
        }

        [HttpGet("surji/course/attendance/getAllByRoll")]
        public IActionResult getAllAttendanceByBSSEROLL(int bsseRoll)
        {
            return Ok(_attendatnceRepository.GetByBSSEROLL(bsseRoll));
        }


        [HttpDelete("surji/course/attendance/delete")]
        public IActionResult deleteAttendanceFromCourse(int attendanceId)
        {
            _attendatnceRepository.Delete(attendanceId);
            return Ok(true);
        }

    }
}
