using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SinglePageApp
{

    [Produces("application/json")]
    [Route("api")]
    [EnableCors("ReactPolicy")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private UserSettings userSet;
        public UsersController(UserSettings us) 
        { 
            this.userSet = us;
        }
        // GET: api/<UsersController>
        [HttpGet("H")]
        public async Task<IActionResult> Delete2()
        {
            //userSet.Delete(id);
            return NoContent();
        }
        //public IEnumerable<User> Get()
        //{
        //    return "Hello";
        //    return userSet.GetAll();
        //}

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userSet.GetById(id);
        }

        // POST api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> CreateUser([FromBody] User value)
        {
            return CreatedAtAction("Get", new { id = value.Id }, userSet.Create(value));
            //return userSet.Create(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User value)
        {
            userSet.Update(id, value);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            userSet.Delete(id);
            return NoContent();
        }
    }
}
