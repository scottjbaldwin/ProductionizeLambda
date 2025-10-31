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
        return new string[] { "something", "nothing", "anything", "more", "AWS VT Syncup" };
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