namespace labaThirdUnitCarYuzikV3Rp10.Models;

public class Car
{
    #region Constants
    
    private const double MaxSpeed = 180.0;
    private const double MinSpeed = 0.0;
    private const double MaxFuel = 60.0;
    private const double MinFuel = 0.0;
    private const double CriticalFuelLevel = 8.0;
    private const double SpeedLimitOnReserve = 90.0;
    
    #endregion
    
    #region Public Methods
    
    /// <summary>
    /// Checks speed based on fuel
    /// </summary>
    /// <param name="speed">requested speed in km/h</param>
    /// <param name="fuel">current fuel in l</param>
    /// <returns>adjusted speed within safe limits</returns>
    public double CheckSpeed(double speed, double fuel)
    {
        if (speed > MaxSpeed) speed = MaxSpeed;
        if (speed < MinSpeed) speed = MinSpeed;
        
        if (fuel <= CriticalFuelLevel && speed > SpeedLimitOnReserve)
            speed = SpeedLimitOnReserve;
        
        return Math.Round(speed, 1);
    }

    /// <summary>
    /// Checks fuel level and calculates remaining range
    /// </summary>
    /// <param name="fuel">current fuel</param>
    /// <param name="speed">current speed</param>
    /// <returns>fuel status info</returns>
    public string CheckFuel(double fuel, double speed)
    {
        if (fuel > MaxFuel) fuel = MaxFuel;
        if (fuel < MinFuel) fuel = MinFuel;
        
        double intakePerOneHundredKm;
        
        //It would be better to put it in a separate region private method, but
        //since there are two methods, that's how it is
        if (speed > 140) intakePerOneHundredKm = 14.0;
        else if (speed > 110) intakePerOneHundredKm = 11.0;
        else if (speed > 80) intakePerOneHundredKm = 9.0;
        else if (speed > 50) intakePerOneHundredKm = 7.5;
        else if (speed > 0) intakePerOneHundredKm = 6.5;
        else intakePerOneHundredKm = 1.5;

        double range = (fuel / intakePerOneHundredKm) * 100;

        if (fuel <= 0)
        {
            return "Fuel tank is empty, so cannot drive";
        }

        if (fuel <= CriticalFuelLevel)
        {
            return $"Critical fuel level☠️.. Fuel: {fuel:F1} & Range {range:F1}km";
        }
        
        if (fuel <= MaxFuel * 0.2)
        {
            return $"Low fuel level: {fuel:F1} & Range: {range:F1}km";
        }
        
        return $"Fuel: {fuel:F1} | Range: {range:F1}km | Speed: {speed}km/h";
    }
    #endregion
}
