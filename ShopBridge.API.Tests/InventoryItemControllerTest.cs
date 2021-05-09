using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.Controllers;
using ShopBridge.API.Core.Models;
using ShopBridge.API.Core.Services;
using ShopBridge.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShopBridge.API.Tests
{
    public class InventoryItemControllerTest
    {
        InventoryItemController _controller;
        IInventoryItemService _service;
        public InventoryItemControllerTest()
        {
            _service = new InventoryItemServiceFake();
            _controller = new InventoryItemController(_service);
        }
        [Fact]
        public void Get_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<InventoryItemViewModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(10010);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void GetById_ReturnsOkResult()
        {
            // Arrange
            var testGuid = 2;
            // Act
            var okResult = _controller.Get(testGuid);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetById_ReturnsItem()
        {
            // Arrange
            var testGuid = 2;
            // Act
            var okResult = _controller.Get(testGuid).Result as OkObjectResult;
            // Assert
            Assert.IsType<InventoryItemViewModel>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as InventoryItemViewModel).Id);
        }


        [Fact]
        public void Add_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new InventoryItem()
            {
                Manufacturer = "Man",
                Price = 100
            };
            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = _controller.Post(nameMissingItem).Result;
            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }
        [Fact]
        public void Add_ReturnsCreatedItem()
        {
            // Arrange
            InventoryItem testItem = new InventoryItem()
            {
                Name = "Denim",
                Manufacturer = "Originl",
                Price = 500
            };
            // Act
            var createdResponse = _controller.Post(testItem).Result;
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new InventoryItem()
            {
                Name = "Kay",
                Manufacturer = "MArk",
                Price = 12.00M
            };
            // Act
            var createdResponse = _controller.Post(testItem).Result as OkObjectResult;
            var item = (InventoryItemViewModel)createdResponse.Value;
            // Assert
            Assert.IsType<InventoryItemViewModel>(item);
            Assert.Equal("Kay", item.Name);
        }
    }
}
