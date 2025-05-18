using DreamDictionary.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        private readonly MigrationService _migrationService;

        public MigrationController(MigrationService migrationService)
        {
            _migrationService = migrationService;
        }

        [HttpPost("migrate")]
        public IActionResult MigrateDatabase()
        {
            try
            {
                _migrationService.MigrateDatabase();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

            return Ok("Everuthin fine");
        }
    }
}
