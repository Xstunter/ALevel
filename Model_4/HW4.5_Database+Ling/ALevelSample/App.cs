using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ALevelSample.Models;
using ALevelSample.Services.Abstractions;
using Newtonsoft.Json;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public App(
        IUserService userService,
        IOrderService orderService,
        IProductService productService)
    {
        _userService = userService;
        _orderService = orderService;
        _productService = productService;
    }

    public async Task Start()
    {
        var firstName = "first name";
        var lastName = "last name";

        var userId = await _userService.AddUser(firstName, lastName);

        await _userService.GetUser(userId);

        var product1 = await _productService.AddProductAsync("product1", 4);
        var product2 = await _productService.AddProductAsync("product2", 7);

        var order1 = await _orderService.AddOrderAsync(userId, new List<OrderItem>()
        {
            new OrderItem()
            {
                Count = 3,
                ProductId = product1
            },

            new OrderItem()
            {
                Count = 6,
                ProductId = product2
            },
        });

        var order2 = await _orderService.AddOrderAsync(userId, new List<OrderItem>()
        {
            new OrderItem()
            {
                Count = 1,
                ProductId = product1
            },

            new OrderItem()
            {
                Count = 9,
                ProductId = product2
            },
        });

        var userOrder = await _orderService.GetOrderByUserIdAsync(userId);

        // Update User
        /*userId = await _userService.UpdateUser(userId, "Bogdan", "Datsenko");

        var user = await _userService.GetUser(userId);

        Console.WriteLine(JsonConvert.SerializeObject(user));*/

        // Delete User
        /*await _userService.DeleteUser("a4ea48c5-dc7f-4f3d-be62-bfd132101047");*/

        // Update Product
        /*var productId = await _productService.UpdateProductAsync(1, "New product", 10);*/

        // Update OrderItems
        /*var orderItemId = await _orderService.UpdateOrderAsync(4, new List<OrderItem>()
        {
            new OrderItem()
            {
                Count = 5,
                ProductId = product1
            }
        });*/

        // Paging with filtering and ordering
        var products = await _productService.GetPaginatedProductsAsync(0, 7, "product1");
    }
}