using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
namespace assignment2BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class J3Controller : ControllerBase
{
    /// <summary>
    /// Source: https://cemc.uwaterloo.ca/sites/default/files/documents/2021/2021CCCJrProblemSet.html
    /// Problem J3: Secret Instructions
    /// 
    /// Receive a HTTP GET request with a query parameter and return a string with the query parameter
    /// value changed. The query parameter should have 5 numbers as a string divided my commas.
    /// e.g. 12345,54321,13245 (first line will not begin with 00)
    /// The first two digits represent the direction to turn:
    /// Sum is odd, the direction is left
    /// Sum is even and the sum is not zero, the direction is right
    /// Sum is zero, the direction is the same as previous instruction
    /// 
    /// The remaining three digits will represent the number of steps to take which will always be at
    /// least 100.
    /// </summary>
    /// <param name="secretFormula">secret code instructions</param>
    /// <returns> a HTTP response with the query parameter string changed</returns>
    /// 
    /// <example>
    /// GET : api/J3/SecretInstruction?secretFormula=34999,12424,43899,99999 -> left 999 left 424 left 899
    /// </example>
    /// <example>
    /// GET : api/J3/SecretInstruction?secretFormula=10100,00400,00123,23300,99999 -> left 100 left 400 left 123 left 300
    /// </example>
    /// <example>
    /// GET : api/J3/SecretInstruction?secretFormula=99123,12399,22123,49300,99999 -> right 123 left 399 right 123 left 300
    /// </example>
    [HttpGet(template: "SecretInstruction")]
    public string SecretInstruction(string secretFormula)
    {
        string[] secretCode = secretFormula.Split(','); // Splits the query param string and divided by the comma
        string direction = "left "; // Declare variable to indicate direction
        List<string> decodedMessage = new List<string>(); // Declared an empty list to add the decoded messages after looping.

        // loop through secretCode array
        foreach (string number in secretCode)
        {
            // if the number is 9999 this will break out of the loop
            if (number == "99999")
            {
                break;
            }

            string newCode = ""; // Declared an empty string variable

            // Checks if adding the first char and second char and checking if it's odd
            // this will change direction to "left"
            // this will add direction to newCode
            if ((number[0] - '0' + number[1] - '0') % 2 == 1)
            {
                direction = "left ";
                newCode += direction;
            }
            // Checks if adding the first and second char is even and if it's not zero
            // this will change direction to "right"
            // this will add direction to newCode
            else if ((number[0] - '0' + number[1] - '0') % 2 == 0 && number[0] - '0' + number[1] - '0' != 0)
            {
                direction = "right ";
                newCode += direction;
            }
            // Checks if adding the first and second char will equal zero
            // this will take whatever the direction variable is set to and add direction to newCode
            else if (number[0] - '0' + number[1] - '0' == 0)
            {
                newCode += direction;
            }
            // nested a for loop and add each char number into newCode starting from the 2 index
            for (int i = 2; i < number.Length; i++)
            {
                newCode += number[i];
            }
            decodedMessage.Add(newCode); // Add newCode into decodedMessage
        }
        // Return decodedMessage as a string by joining the decodedMessage list elements together
        // divide each element with a space.
        return String.Join(" ", decodedMessage);
    }
}