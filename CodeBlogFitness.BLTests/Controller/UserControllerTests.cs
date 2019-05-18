using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDaraTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 180;
            var genger = "man";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserDara(genger, birthdate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(genger, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(userName);
            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}