using EF;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using WebService.Impl;

namespace Service.Tests
{
    // 移除构造函数注入，改为在测试中手动创建模拟对象
    public class TestUserService
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly IUserService _userService;

        public TestUserService()
        {
            // 1. 创建IUserService的模拟对象
            _mockUserService = new Mock<IUserService>();

            // 2. 配置模拟行为（示例：GetAllUsers返回测试数据）
            var testUsers = new List<User> // 替换为你的User实体类型
            {
                new User { Id = 1, Username = "Test User 1" ,Password="123",Email="Email",motto="Motto",CreatedAt=DateTime.Now},
                new User { Id = 2, Username = "Test User 2" ,Password="123",Email="Email",motto="Motto",CreatedAt=DateTime.Now}
            };
            _mockUserService.Setup(s => s.GetAllUsers()).ReturnsAsync(testUsers);
            _mockUserService.Setup(s => s.GetByUserName(It.IsAny<string>())).ReturnsAsync(testUsers[0]);    

            // 3. 获取模拟对象的实例
            _userService = _mockUserService.Object;
        }

        [Fact]
        public void TestGetAllUsers()
        {
            // 执行测试
            var users = _userService.GetAllUsers();

            // 断言验证（可选，根据需求添加）
            Assert.NotNull(users);
            _mockUserService.Verify(s => s.GetAllUsers(), Times.Once); // 验证方法被调用一次
        }

        [Fact]
        public void TestGetByUserName()
        {
            // 执行测试
            var users = _userService.GetByUserName("1");

            // 断言验证（可选，根据需求添加）
            Assert.NotNull(users);
            //_mockUserService.Verify(s => s.GetAllUsers(), Times.Once); // 验证方法被调用一次
        }

    }

}