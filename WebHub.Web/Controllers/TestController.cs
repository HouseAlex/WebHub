using Microsoft.AspNetCore.Mvc;

namespace WebHub.Web.Controllers
{
    /// <summary>
    /// Controller for testing purposes.
    /// </summary>
    public class TestController : Controller
    {
        /// <summary>
        /// initializes a new instance of the <see cref="TestController"/> class.
        /// </summary>
        public TestController() { }

        /// <summary>
        /// Gets the test data.
        /// </summary>
        /// <returns>
        /// The test data.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTestData()
        {
            var data = "Lick my booty hole";
            return Ok(data);
        }
    }
}
