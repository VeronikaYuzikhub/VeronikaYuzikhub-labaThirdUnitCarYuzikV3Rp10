// See https://aka.ms/new-console-template for more information
using labaThirdUnitCarYuzikV3Rp10.Models;

namespace labaThirdUnitCarYuzikV3Rp10;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Create car instance
        Car car = new Car();
        
        // speed limit with critical fuel
        double limitedSpeed = car.CheckSpeed(150, 5.0);
        Console.WriteLine($"1 - Speed 150km/h with 5l fuel: {limitedSpeed}km/h (expected: 90)");
        
        //how many km per 20l at a speed of 110km/h
        string fuelStatus = car.CheckFuel(20.0, 110);
        Console.WriteLine($"2 - Fuel 20l at 110km/h: {fuelStatus}");
        
        // сritical fuel warning
        string criticalStatus = car.CheckFuel(6.0, 90);
        Console.WriteLine($"3 - Fuel 6l at 90km/h: {criticalStatus}");
    }
}