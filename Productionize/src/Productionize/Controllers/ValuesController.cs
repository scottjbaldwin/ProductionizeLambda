using Microsoft.AspNetCore.Mvc;

namespace Productionize.Controllers;

[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    IConfiguration _config;
    public ValuesController(IConfiguration config)
    {
        _config = config;
    }
    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        var env = Environment.GetEnvironmentVariables();
        var accessKey = env["AWS_ACCESS_KEY_ID"] as string;
        var secretKey = env["AWS_SECRET_ACCESS_KEY"] as string;
        secretKey = secretKey?.Substring(0, 5) + "****************";
        var sessionToken = env["AWS_SESSION_TOKEN"] as string;
        sessionToken = sessionToken?.Substring(0, 5) + "****************";

        var region = env["AWS_REGION"] as string;

        return new string[] { accessKey ?? "ACCESS KEY NOT FOUND", secretKey, sessionToken, region};
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        Console.WriteLine("I can log to a logstream!!!!");
        if (!string.IsNullOrEmpty(_config["MyValue"]))
        {
            return _config["MyValue"];
        }
        return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}