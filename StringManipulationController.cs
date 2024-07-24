using Microsoft.AspNetCore.Mvc;

namespace StringManipulationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringManipulationController : ControllerBase
    {
        [HttpGet("manipulate")]
        public IActionResult ManipulateString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("Input string cannot be null or empty.");
            }

            var reversedString = ReverseString(input);
            var isPalindrome = IsPalindrome(input);

            var response = new
            {
                ReversedString = reversedString,
                IsPalindrome = isPalindrome
            };

            return Ok(response);
        }

        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private bool IsPalindrome(string input)
        {
            var reversedString = ReverseString(input);
            return string.Equals(input, reversedString, StringComparison.OrdinalIgnoreCase);
        }
    }
}