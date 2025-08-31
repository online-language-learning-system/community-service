using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("api/test")]
public class TestDbController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TestDbController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("db-connection")]
    public IActionResult TestDbConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        try
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var cmd = new SqlCommand("SELECT COUNT(*) FROM app.communities", connection);
            var count = (int)cmd.ExecuteScalar();
            return Ok(new { success = true, count });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, error = ex.Message });
        }
    }
}

