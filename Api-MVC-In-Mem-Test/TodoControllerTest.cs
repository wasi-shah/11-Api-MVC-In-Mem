using System;
using Moq;
using TodoApi.Controllers;
using TodoApi.Models;

namespace Api_MVC_In_Mem_Test;

public class TodoControllerTest
{

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
