﻿using System;
using System.Threading.Tasks;
using LessPaper.APIGateway.Controllers.v1;
using LessPaper.APIGateway.Models;
using LessPaper.Shared.Interfaces.GuardApi;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LessPaper.APIGateway.UnitTest.Controller
{
    public class UserControllerTest : BaseController
    {
        private readonly UserController controller;
    
        public UserControllerTest()
        {
            var writeApiMock = new Mock<IGuardApi>();
            writeApiMock.Setup(mock =>
                    mock.RegisterNewUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                        .ReturnsAsync(true);
          
            controller = new UserController(AppSettings, writeApiMock.Object);
        }

        [Fact]
        public async Task Register()
        {
            //Invalid email
            var badEmailRequestObj = await controller.Register(new UserRegistrationRequest
            {
                Email = "a@",
                Password = "my_secure_password"
            });
            Assert.IsType<BadRequestResult>(badEmailRequestObj);


            //Invalid password
            var badPasswordRequestObj = await controller.Register(new UserRegistrationRequest
            {
                Email = "a@b.de",
                Password = "1"
            });
            Assert.IsType<BadRequestResult>(badPasswordRequestObj);


            //Valid request
            var validRequestObj = await controller.Register(new UserRegistrationRequest
            {
                Email = "a@b.de",
                Password = "my_secure_password"
            });
            Assert.IsType<OkResult>(validRequestObj);

        }
    }
}
