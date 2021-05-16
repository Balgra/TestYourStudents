using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

namespace TestYourStudents.Tests.Quiz
{
    public class CrateDeleteQuizAndQuestionTests
    {
            private IRepository<Core.Entities.Quiz> _quizRepo;
            private IRepository<Course> _courseRepo;
            private QuizController _controller;

            public CrateDeleteQuizAndQuestionTests()
            {
                //mock a list of necessary data
                _courseRepo = new TestRepository<Course>(new List<Course>()
                {
                    new Course() {Id = 1, Name = "SEF", ProfessorId = "af8a67e2-b958-4595-bc9a-4bb388c082f1"},
                    new Course() {Id = 2, Name = "CN", ProfessorId = "af8a67e3-b958-4595-bc9a-4bb388c083g1"}
                });

                _quizRepo = new TestRepository<Core.Entities.Quiz>(new List<Core.Entities.Quiz>()
                {//2021-05-05 20:20:19.060000
                        new Core.Entities.Quiz(){Id=1, Name="Romana", 
                            StartTime=new DateTime(2021,05,16,11,55,30,DateTimeKind.Local),
                            EndTime= new DateTime(2021,05,16,12,40,40,DateTimeKind.Local),
                            CourseId=1},
                        
                        new Core.Entities.Quiz(){Id=2, Name="Franceza", 
                            StartTime=new DateTime(2021,06,16,11,55,30,DateTimeKind.Local),
                            EndTime= new DateTime(2021,07,16,12,40,40,DateTimeKind.Local),
                            CourseId=2},
                        
                        new Core.Entities.Quiz(){Id=3, Name="Muzica", 
                            StartTime=new DateTime(2021,05,16,11,55,30,DateTimeKind.Local),
                            EndTime= new DateTime(2021,05,16,10,40,40,DateTimeKind.Local),
                            CourseId=2},
                        
                        new Core.Entities.Quiz(){Id=4, Name="Geogra", 
                            StartTime=new DateTime(2021,05,16,11,55,30,DateTimeKind.Local),
                            EndTime= new DateTime(2021,05,16,9,40,40,DateTimeKind.Local),
                            CourseId=1},
                    
                        new Core.Entities.Quiz(){Id=5, Name="Romana2", 
                            StartTime=new DateTime(2020,05,16,11,55,30,DateTimeKind.Local),
                            EndTime= new DateTime(2021,05,16,12,40,40,DateTimeKind.Local),
                            CourseId=2},
                        
                        new Core.Entities.Quiz(){Id=6, Name="Romana3", 
                            StartTime=new DateTime(2021,05,16,11,55,45,DateTimeKind.Local),
                            EndTime= new DateTime(2021,05,16,11,55,40,DateTimeKind.Local),
                            CourseId=2},
                });
                
               _controller = new QuizController(_courseRepo, _quizRepo,null,null);

               var mock = new Mock<HttpContext>();
                mock.Setup(x => x.User.Identity.IsAuthenticated).Returns(true);
                mock.Setup(x => x.User.IsInRole(It.IsAny<string>())).Returns(true);
                mock.Setup(x => x.User.Claims).Returns(new List<Claim>()
                {
                    new Claim("userId","af8a67e2-b958-4595-bc9a-4bb388c082f1")
                });
                
                _controller.ControllerContext = new ControllerContext() {HttpContext = mock.Object};

            }

            [Fact]
            public async Task Test_If_Creating_Quizzes_Works()
            {
                var request = new CreateQuizRequest()
                {
                        Name="Romana4", 
                        StartTime=new DateTime(2022,05,16,11,55,35,DateTimeKind.Local),
                        EndTime= new DateTime(2022,05,16,11,55,40,DateTimeKind.Local),
                        NumberOfMinutes = 10,
                        VisibleForStudents = true,
                };

                await _controller.QuizCreation(request, 1);

                var result = await _quizRepo.GetAllAsync();
                
                Assert.Equal(7,result.Count);
                Assert.Single(result,q => q.Name == "Romana4");

            }

            [Fact]
            public async Task Test_If_StartTime_Smaller_Than_EndTime_Works()
            {
                var request = new CreateQuizRequest()
                {
                    Name = "Romana5",
                    StartTime = new DateTime(2022, 05, 16, 11, 55, 35, DateTimeKind.Local),
                    EndTime = new DateTime(2022, 05, 16, 12, 55, 40, DateTimeKind.Local),
                    NumberOfMinutes = 10,
                    VisibleForStudents = true,
                };

                await _controller.QuizCreation(request, 1);

                var result = await _quizRepo.GetAllAsync();

                Assert.Equal(7, result.Count);
                Assert.Single(result, q => q.StartTime == request.StartTime);
                Assert.Single(result, q => q.EndTime == request.EndTime);
            }
            
            [Fact]
            public async Task Test_Quiz_Visible_For_Students()
            {
                var request = new CreateQuizRequest()
                {
                    Name = "Romana6",
                    StartTime = new DateTime(2022, 05, 16, 11, 55, 35, DateTimeKind.Local),
                    EndTime = new DateTime(2022, 05, 16, 12, 55, 40, DateTimeKind.Local),
                    NumberOfMinutes = 10,
                    VisibleForStudents = true,
                };

                await _controller.QuizCreation(request, 1);

                var result = await _quizRepo.GetAllAsync();

                Assert.Equal(7, result.Count);
                Assert.Single(result, q => q.VisibleForStudents == request.VisibleForStudents);

            }


    }
}