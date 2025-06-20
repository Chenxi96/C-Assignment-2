using Microsoft.AspNetCore.Mvc;

namespace assignment2BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class J2Controller : ControllerBase
{
    /// <summary>
    /// Sources: https://cemc.uwaterloo.ca/sites/default/files/documents/2021/2021CCCJrProblemSet.html
    /// Problem J2: Chili Peppers
    /// 
    /// Receives a HTTP GET request with a query parameter and give a HTTP response with the total Scoville score.
    /// </summary>
    /// <param name="pepperNames">Names of all the pepper that will be added to the total of the scoville score</param>
    /// <returns>A HTTP Response of the total Scoville score</returns>
    /// <example>
    /// GET : api/J2/ChiliPeppers&Ingredients=Poblano,Mirasol,Serrano,Habanero -> 23000
    /// </example>
    /// <example>
    /// GET : api/J2/ChiliPeppers&Ingredients=Thai,Thai,Thai,Thai,Thai -> 375000
    /// </example>
    /// <example>
    /// GET : api/J2/ChiliPeppers&Ingredients=Cayenne,Thai -> 115000
    /// </example>
    [HttpGet(template: "ChiliPeppers&Ingredients={pepperNames}")]
    public int TotalScolville(string pepperNames)
    {
        int poblano = 1500;
        int mirasol = 6000;
        int serrano = 15500;
        int cayenne = 40000;
        int thai = 75000;
        int habanero = 125000;

        int totalScovile = 0;

        // Splits the route parameter starts splitting after "ChiliPeppers&Ingredients=" then after each comma. then will add each pepper name
        // to the new variable results as a array element
        string[] results = pepperNames.Split(new string[] { "ChiliPeppers&Ingredients=", "," }, StringSplitOptions.None);

        // loops through results array and check each string with conditional
        for (int i = 0; i < results.Length; i++)
        {
            // for each index element it checks if it matches the string value e.g. "poblano"
            if (results[i]?.ToLower() == "poblano")
            {
                totalScovile += poblano;
            }
            else if (results[i]?.ToLower() == "mirasol")
            {
                totalScovile += mirasol;
            }
            else if (results[i]?.ToLower() == "serrano")
            {
                totalScovile += serrano;
            }
            else if (results[i]?.ToLower() == "thai")
            {
                totalScovile += thai;
            }
            else if (results[i]?.ToLower() == "habanero")
            {
                totalScovile += habanero;
            }
            else if (results[i]?.ToLower() == "cayenne")
            {
                totalScovile += cayenne;
            }
        }
        return totalScovile; // return the total amount of Scoville rating.
    }

    /// <summary>
    /// Sources: https://cemc.uwaterloo.ca/sites/default/files/documents/2021/2021CCCJrProblemSet.html
    /// Problem J2: Silent Auction
    /// 
    /// Receives a HTTP request with a query parameter. Sends a response with the query parameter with the highest bidder name.
    /// </summary>
    /// <param name="biddersAmounts">name and amount of bid</param>
    /// <returns> A HTTP Response with the auction winner</returns>
    /// <example>
    /// GET : api/J2/SilentAuction?biddersAmounts=Chenxi,200,Tim,100,Chanel,500,Tim,240 -> Chanel
    /// </example>
    /// <example>
    /// GET : api/J2/SilentAuction?biddersAmounts=Chenxi,100,Chanel,100,Tim,100 -> Chenxi
    /// </example>
    /// <example>
    /// GET : api/J2/SilentAuction?biddersAmounts=Ron,150,Brian,150,James,200 -> James
    /// </example>

    [HttpGet(template: "SilentAuction")]
    public string SilentAuction(string biddersAmounts)
    {
        string[] arrayResult = biddersAmounts.Split(",", StringSplitOptions.None); // This splits the string into names and amounts as strings.
        List<string> nameArray = new List<string>(); // Declared an empty List that stores the names of the bidder.
        List<int> amountArray = new List<int>(); // Declared an empty List that stores the amount per bidder.
        int greaterAmount = 0; // Declared a variable that tracks the highest amount per bidder.
        int index = 0; // Tracks the index we are at when we loop through the foreach loop.
        int count = 0; // Declared a count variable
        
        // Loops through arrayResult
        for (int i = 0; i < arrayResult.Length; i++)
        {
            // Check if there's no remainder, if so append the string to nameArray
            if (i % 2 == 0)
            {
                nameArray.Add(arrayResult[i]); // this will store the names

            }
            // Check if there's a remainder, if so append to amountArray
            else if (i % 2 == 1)
            {
                amountArray.Add(Int32.Parse(arrayResult[i])); // this will store the amounts as a number

            }
        }

        // Loop through amountArray
        amountArray.ForEach(delegate (int amount) // created an anonymous function that takes int amount as a parameter
        {
            if (amount > greaterAmount) // if amount is greater than greaterAmount
            {
                greaterAmount = amount; // Change greaterAmount to the current amount
                index = count; // Change index to what the current count is
            }
            count++; // Add one to count
        });
        return nameArray[index]; // return the name of the person
    }
}
