using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingapi.data;
using trackingapi.Models;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")] //mapping action methods
    [ApiController] //used for validation,data binding
    public class IssueController : ControllerBase //helps to manage http methods
    { 
        private readonly IssueDbContext _context; //You're using dependency injection to inject an instance of IssueDbContext into the IssueController constructor. This allows you to use _context throughout your controller's methods to interact with the database. You can perform operations like querying for data, adding new records, updating records, and deleting records using the methods provided by the DbContext class.
        public IssueController(IssueDbContext context)=>_context = context;

        [HttpGet]
        public async Task<IEnumerable<issue>> Get()
            =>  await _context.Issues.ToListAsync();
        
        [HttpGet("id")]
        [ProducesResponseType(typeof(issue),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue==null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task< IActionResult> Create(issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id=issue.Id},issue);
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(int id,issue issue)
        {
            if (id!=issue.Id) return BadRequest(); //if mismatch between id in the url and id in the body then return bad req

            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issuetodelete = await _context.Issues.FindAsync(id); //checking if the issue exisits
            if (issuetodelete == null) return NotFound();

            _context.Issues.Remove(issuetodelete);
            await _context.SaveChangesAsync();

            return NoContent();


        }
    }       



}

    

