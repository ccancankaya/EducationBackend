using DataAccess.Abstract;
using EducationAPI.Controllers;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.services;
using Xunit;

namespace UnitTest.controllers
{
    public class EducationProgramControllerTest
    {
        private readonly EducationProgramController _controller;
        private readonly IEducationProgramService _service;

        public EducationProgramControllerTest()
        {
            _service = new EducationProgramServiceTest();
            _controller = new EducationProgramController(_service);
        }

        [Fact]
        public void Get_ReturnOk()
        {
            var result = _controller.GetAll();

            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void Get_AllItems()
        {
            var result = _controller.GetAll() as OkObjectResult;

            var items = Assert.IsType<List<EducationProgram>>(result.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Get_ById_NotFound()
        {
            var result = _controller.GetById(5);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ById_True()
        {
            var result = _controller.GetById(1);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void Add_Invalid()
        {
            var invalidItem = new EducationProgram()
            {
                Id = 4,
                StartDateTime = new DateTime(),
                EndDateTime = new DateTime().AddMinutes(45),
                Status = "Yayınlandı"
            };

            _controller.ModelState.AddModelError("ProgramName", "Required");

            var response = _controller.AddEducationProgram(invalidItem);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Add_True()
        {
            var item = new EducationProgram()
            {
                Id = 4,
                ProgramName = "Test Education Program",
                StartDateTime = new DateTime(),
                EndDateTime = new DateTime().AddMinutes(45),
                Status = "Yayınlandı"

            };

            var result = _controller.AddEducationProgram(item);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Update_True()
        {
            var item = new EducationProgram()
            {
                Id = 4,
                ProgramName = "Test Education Program 2",
                StartDateTime = new DateTime(),
                EndDateTime = new DateTime().AddMinutes(50),
                Status = "Yayınlanmadı"

            };

            var result = _controller.UpdateEducationProgram(item);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Update_False()
        {
            var item = new EducationProgram()
            {
                Id = 5,
                ProgramName = "Test Education Program 2",
                StartDateTime = new DateTime(),
                EndDateTime = new DateTime().AddMinutes(50),
                Status = "Yayınlanmadı"

            };

            var result = _controller.UpdateEducationProgram(item);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Remove_True()
        {
            var item = new EducationProgram()
            {
                Id = 4,
                ProgramName = "Test Education Program",
                StartDateTime = new DateTime(),
                EndDateTime = new DateTime().AddMinutes(45),
                Status = "Yayınlandı"

            };

            var result = _controller.DeleteEducationProgram(item);

            Assert.Equal(3, _service.GetAll().Count());
        }
    }
}
