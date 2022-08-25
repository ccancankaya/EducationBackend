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
    public class EducationControllerTest
    {
        private readonly EducationController _controller;
        private readonly IEducationService _service;

        public EducationControllerTest()
        {
            _service = new EducationServiceTest();
            _controller = new EducationController(_service);
        }

        [Fact]
        public void Get_ReturnOk()
        {
            var result = _controller.GetEducations();

            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public void Get_AllItems()
        {
            var result = _controller.GetEducations() as OkObjectResult;

            var items = Assert.IsType<List<Education>>(result.Value);
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
            var invalidItem = new Education()
            {
                Id = 4,
                Link = "www.google.com"

            };

            _controller.ModelState.AddModelError("EducationName", "Required");

            var response = _controller.AddEducation(invalidItem);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Add_True()
        {
            var item = new Education()
            {
                EducationName = "Deneme Eğitim",
                Id = 4,
                Link = "www.google.com",
                EducationProgramId = 1

            };

            var result = _controller.AddEducation(item);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Update_True()
        {
            var item = new Education()
            {
                Id = 4,
                EducationName = "Deneme Eğitim 2",
                Link = "www.google.com",
                EducationProgramId = 1

            };

            var result = _controller.UpdateEducation(item);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Update_False()
        {
            var item = new Education()
            {
                Id = 5,
                EducationName = "Deneme Eğitim 2",
                Link = "www.google.com",
                EducationProgramId = 1

            };

            var result = _controller.UpdateEducation(item);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Remove_True()
        {
            var item = new Education()
            {
                EducationName = "Deneme Eğitim",
                Id = 4,
                Link = "www.google.com",
                EducationProgramId = 1

            };

            var result = _controller.DeleteEducation(item);

            Assert.Equal(3, _service.GetAll().Count());
        }
    }
}
