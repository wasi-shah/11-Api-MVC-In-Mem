using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using TodoApi.Controllers;
using TodoApi.Data;
using TodoApi.Models;

namespace Api_MVC_In_Mem_Test;

public class TodoControllerTest
{

[Fact]
public async Task TestTodoApiAsync()
{
    // Arrange
     var option = new DbContextOptionsBuilder<TodoContext>()
        .UseInMemoryDatabase(databaseName: "testdatabase")
        .Options;
    // Insert seed data into the database using one instance of the context
    using (var context = new TodoContext(option))
    {
        context.TodoItems.Add(new TodoItem { Id = 1, Name = "Test1" });
        context.TodoItems.Add(new TodoItem { Id = 2, Name = "Test2" });
        context.SaveChanges();
    }
    // Use a clean instance of the context to run the test
    using (var context = new TodoContext(option))
    {
        var controller = new TodoController(context);
        var result = await controller.GetTodoItems();
        var items = result.Value.ToList();
        // Assert
        Assert.Equal(2, items.Count);
  
    }
}
[Fact]
public void DoSum()
{
    // Arange
    var x=2;
    var y=3;
    var expected = 5;

    // Act
    var result = x + y;

    // Assert
    Assert.Equal(expected, result);
}

}
