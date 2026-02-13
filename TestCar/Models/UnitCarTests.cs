using labaThirdUnitCarYuzikV3Rp10.Models;

namespace TestCar.Models;

public class UnitCarTests
{
    #region CheckSpeed_Tests
    
    [Fact]
    public void CheckSpeed_NegativeWhenFuelIsLow_ShouldLimitSpeed()
    {
        //Arrange
        var car = new Car();
        //Act
        double actualSpeed = car.CheckSpeed(150, 5);
        //Assert
        Assert.Equal(90, actualSpeed);
    }

    [Fact]
    public void CheckSpeed_PositiveWhenFuelIsOk_ShouldReturnInputSpeed()
    {
        //Arrange
        var car = new Car();
        //Act
        double actualSpeed = car.CheckSpeed(100, 10);
        //Assert
        Assert.Equal(100, actualSpeed);
    }

    [Fact]
    public void CheckSpeed_BoundaryWhenFuelIsHigh_ShouldLimitToMaxSpeed()
    {
        //Arrange
        var car = new Car();
        //Act
        double actualSpeed = car.CheckSpeed(200, 20);
        //Assert
        Assert.Equal(180, actualSpeed);
    }
    
    #endregion
    
    #region CheckFuel_Tests

    [Fact]
    public void CheckFuel_NegativeWhenEmptyTank_ShouldReturnEmptyMessage()
    {
        //Arrange
        var car = new Car();
        //Act
        string resultMessage =  car.CheckFuel(0, 70);
        //Assert
        Assert.Equal("Fuel tank is empty, so cannot drive", resultMessage);
    }

    [Fact]
    public void CheckFuel_PositiveWhenNormalLevel_ShouldReturnFullInfo()
    {
        //Arrange
        var car = new Car();
        //Act
        string resultMessage = car.CheckFuel(50, 100);
        //Assert
        Assert.Contains("Fuel: 50.0 | Range: 555.6km | Speed: 100km/h", resultMessage);
    }

    [Fact]
    public void CheckFuel_BoundaryWhenCriticalLevel_ShouldReturnWarningMessage()
    {
        //Arrange
        var car = new Car();
        //Act
        string resultMessage = car.CheckFuel(6.0, 90);
        //Assert
        Assert.Contains("Critical fuel level☠️.. Fuel: 6.0 & Range 66.7km", resultMessage);
    }

    [Fact]
    public void CheckFuel_LowFuelLevel_ShouldReturnLowFuelMessage()
    {
        //Arrange
        var car = new Car();
        //Act
        string resultMessage = car.CheckFuel(10.0, 100.0);
        //Assert
        Assert.Contains($"Low fuel level: 10.0 & Range: 111.1km",  resultMessage);
    }

    #endregion
}