using Microsoft.AspNetCore.Mvc;

namespace assignment2BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class J1Controller : ControllerBase
{

    /// <summary>
    /// Source: https://cemc.uwaterloo.ca/sites/default/files/documents/2021/2021CCCJrProblemSet.html
    /// Problem J1: Deliv-e-droid
    /// 
    /// Receives a HTTP Post request with 2 form parameters that are non-negative (deliveries, collisions) and returns a HTTP response with the total amount of points as a int data type.
    /// </summary>
    /// <param name="deliveries">Amount of deliveries</param>
    /// <param name="collisions">Amount of collisions</param>
    /// <returns>calculated and return the total using the two input values as int data type value</returns>
    /// <example
    /// POST api/J1/delivedroid
    /// HEADER  Content-Type: application/x-www-form-urlencoded
    /// BODY "collisions=123&deliveries=5"
    /// -> -980
    /// </example>
    /// POST api/J1/delivedroid
    /// HEADER  Content-Type: application/x-www-form-urlencoded
    /// BODY "collisions=10&deliveries=35"
    /// -> 2150
    /// </example>
    /// POST api/J1/delivedroid
    /// HEADER  Content-Type: application/x-www-form-urlencoded
    /// BODY "collisions=3&deliveries=2"
    /// -> 70
    /// </example>
    [HttpPost(template: "Delivedroid")]
    public int DelivEDroid([FromForm] int deliveries, [FromForm] int collisions) // Declared a method that takes two parameter (deliveries and collisions) and returns an Int data type
    {

        int packagePoints = 50; // points per delivery
        int collisionPoints = 10; // points deducted per collision
        int extraPoints = 0; // declared extra points variable and initialized to 0

        // Check if deliveries are greater than collisions and if so, assign 500 extra points
        if (deliveries > collisions)
        {
            extraPoints = 500;
        }

        int totalPackageAmount = packagePoints * deliveries; // product of package per points and deliveries amounts
        int totalCollisionAmount = collisionPoints * collisions; // product of collision per points and collision amounts

        return totalPackageAmount - totalCollisionAmount + extraPoints; // total amounts of points after calculation return as an Int data type
    }

    [HttpPost(template: "BoilingWater")]
    /// <summary>
    /// Sources: https://cemc.uwaterloo.ca/sites/default/files/documents/2021/2021CCCJrProblemSet.html
    /// Problem J1: Boiling Water
    /// 
    /// Receives a HTTP Post request with a form parameter that is between 80 to 200(exclusively) as a int type (temperature) and using the parameter it
    /// will calculate the atmospheric pressure at sea level and return a HTTP response as a string.
    /// Use the formula provided to calculate the atmospheric pressure.
    /// </summary>
    /// <param name="temperature">temperature in celsius</param>
    /// <returns>return a string with the current atmospheric pressure and current sea level</returns>
    /// <example
    /// POST api/J1/BoilingWater
    /// HEADER Content-Type: application/x-www-form-urlencoded
    /// BODY "temperature=105"
    /// -> "100 -1"
    /// </example>
    /// <example
    /// POST api/J1/BoilingWater
    /// HEADER Content-Type: application/x-www-form-urlencoded
    /// BODY "temperature=95"
    /// -> "75 1"
    /// </example>
    /// </example>
    /// <example
    /// POST api/J1/BoilingWater
    /// HEADER Content-Type: application/x-www-form-urlencoded
    /// BODY "temperature=100"
    /// -> "100 0"
    /// </example>
    /// 
    public string BoilingWater([FromForm] int temperature)
    {
        int rateOfChangePressure = 5; // rate of change of pressure in kpa per degree celsius
        int constant = 400; // Constant used in the formula
        int seaLevel = 100; // Sea level equal to 100 kpa
        int currentSeaLevel = 0; // Declare variable and initialize to 0: used to determine what the sea level is after calculation.
        int atmosphericPressure = rateOfChangePressure * temperature - constant; // Calculate the atmospheric Pressure.

        // After Calculating the atmposheric pressure, we will check if the current atmospheric
        // pressure is above, below or equal to sea level.
        if (atmosphericPressure > seaLevel)
        {
            return $"{seaLevel} -1"; // return 100 only if it's below sea level regardless of the calculated atmospherePressure and -1 as a string.
        }
        else if (atmosphericPressure < seaLevel)
        {
            currentSeaLevel = 1;
        }
        else if (atmosphericPressure == seaLevel)
        {
            currentSeaLevel = 0;
        }

        return $"{atmosphericPressure} {currentSeaLevel}"; // Return the atmospheric pressure and current Sea level as a string.
    }
}
