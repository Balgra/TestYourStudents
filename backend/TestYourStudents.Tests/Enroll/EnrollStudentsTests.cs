using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestYourStudents.API.Controllers;
using TestYourStudents.API.Requests;
using TestYourStudents.Core.Entities;
using TestYourStudents.EF.EFRepositories.Abstractions;
using TestYourStudents.Tests.MockRepositories;
using Xunit;

namespace TestYourStudents.Tests.Enroll
{
    public class EnrollStudentsTests
    {
        private IRepository<StudentEmail> studentEmailRepo;
        private IRepository<Course> courseRepo;
        private EnrollController controller;
        
        public EnrollStudentsTests()
        {
            //mock a list of necessary data
            courseRepo = new TestRepository<Course>(new List<Course>(){
                    new Course(){Id = 1, Name = "SEF", ProfessorId = "af8a67e2-b958-4595-bc9a-4bb388c082f1"},
                    new Course(){Id = 2, Name = "CN", ProfessorId = "af8a67e3-b958-4595-bc9a-4bb388c083g1"}
                    });

            studentEmailRepo = new TestRepository<StudentEmail>(new List<StudentEmail>()
            {
                new StudentEmail(){Id = 1, CourseId = 1, Email = "test1@test.com"},
                new StudentEmail(){Id = 2, CourseId = 1, Email = "test2@test.com"},
                new StudentEmail(){Id = 3, CourseId = 1, Email = "test3@test.com"},
                new StudentEmail(){Id = 4, CourseId = 2, Email = "test4@test.com"},
                new StudentEmail(){Id = 5, CourseId = 2, Email = "test5@test.com"},
                new StudentEmail(){Id = 6, CourseId = 2, Email = "test6@test.com"},
            });
            controller = new EnrollController(studentEmailRepo, courseRepo);
            
            //setup a mock user
            var mock = new Mock<HttpContext>();
            mock.Setup(x => x.User.Identity.IsAuthenticated).Returns(true);
            mock.Setup(x => x.User.IsInRole(It.IsAny<string>())).Returns(true);
            mock.Setup(x => x.User.Claims).Returns(new List<Claim>()
            {
                new Claim("userId","af8a67e2-b958-4595-bc9a-4bb388c082f1")
            });
            controller.ControllerContext = new ControllerContext() {HttpContext = mock.Object};

        }
        
        [Fact]
        public async Task Test_If_Enrolling_Students_Works()
        {
            //arrange
            var request = new EnrollStudentsRequest()
            {
                StudentEmails = new List<string>()
                {
                    "test1@test.com",
                    "test2@test.com",
                    "test6@test.com",
                    "test7@test.com"
                }
            };

            //act
            await controller.EnrollStudents(request, 1);

            //assert
            var result = await studentEmailRepo.GetAllAsync();
            Assert.Equal(8, result.Count);
            Assert.Single(result, student => student.Email == "test1@test.com" && student.CourseId == 1);
            Assert.Single(result, student => student.Email == "test2@test.com" && student.CourseId == 1);
            Assert.Single(result, student => student.Email == "test6@test.com" && student.CourseId == 1);
            Assert.Single(result, student => student.Email == "test6@test.com" && student.CourseId == 2);
            Assert.Contains(result, student => student.Email == "test7@test.com" &&  student.CourseId == 1);
        }

        [Fact]
        public async Task Test_If_Professor_Is_Trying_To_Add_To_Another_Course()
        {
            //arrange
            var request = new EnrollStudentsRequest()
            {
                StudentEmails = new List<string>()
                {
                    "test1@test.com",
                }
            };

            //act
            await controller.EnrollStudents(request, 2);
            
            // assert
            var result = await studentEmailRepo.GetAllAsync();
            Assert.Equal(6, result.Count);
        }
    }
    
}