using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingapi.data;
using trackingapi.DTO;
using trackingapi.Models;
using trackingapi.Service;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")] //mapping action methods
    [ApiController] //used for validation,data binding
    public class IssueController : ControllerBase //helps to manage http methods
    {
        //private readonly IssueDbContext _context; //You're using dependency injection to inject an instance of IssueDbContext into the IssueController constructor. This allows you to use _context throughout your controller's methods to interact with the database. You can perform operations like querying for data, adding new records, updating records, and deleting records using the methods provided by the DbContext class.
        private readonly IIssueService _iIssueService;
        public IssueController(IssueDbContext context, IIssueService iIssueService)
        {
            //_context = context;
            _iIssueService = iIssueService;

        }


        [HttpGet]
        public async Task<IEnumerable<IssueDTO>> Get()
        {
          //  await _iIssueService.GetAll();
            return (IEnumerable<IssueDTO>)await _iIssueService.GetAll();
        }   //=> //await _context.Issues.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(IssueDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {

            var issue = await _iIssueService.GetIssue(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(IssueDTO issue)
        {



            //await _iIssueService.AddAsync(issue);
            // await _iIssueService.SaveChangesAsync();

            var test = await _iIssueService.PostIssue(issue);
            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> update(int id, IssueDTO issue)
        {
            if (id != issue.Id) return BadRequest(); //if mismatch between id in the url and id in the body then return bad req

            //_context.Entry(issue).State = EntityState.Modified;
            //await _iIssueService.SaveChangesAsync();
            await _iIssueService.PutIssue(id, issue);
            //await _iIssueService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            //var issuetodelete = await _context.Issues.FindAsync(id); //checking if the issue
            //if (issuetodelete == null) return NotFound();



            // var issues = await _iissueservice.findasync(id);
            //_iissueservice.remove(issues);
            //await _context.savechangesasync();

            await _iIssueService.DeleteIssue(id);

            return NoContent();




        }
        //pageination
        [HttpPost("filteredissues")] //page-which page to display; num-how many elements to display;type-the type of issue
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Issue>> Test(FilterDTO filterRequest)
        {


          return await _iIssueService.FilterReq(filterRequest);

          
            ////pageination
            //[HttpPost("{page}/{num}/{type}")] //page-which page to display; num-how many elements to display;type-the type of issue
            //[ProducesResponseType(StatusCodes.Status200OK)]
            //public async Task<IActionResult> Test(int page,int num, IssueType type)
            //{


            //    var tot_num = _context.Issues.Count(); 
            //  //  var pageSize = 10; // Define your desired page size
            //   // var pageCount = (int)Math.Ceiling((decimal) tot_num/ num);

            //    var issues = await _context.Issues
            //        .Where(a => a.IssueType == type)
            //        .Skip((page - 1) * num) 
            //        .Take(num)
            //        .ToListAsync();

            //    return Ok(issues); // Return 200 OK with the list of issues
        }
    }
        //testing
/*
        [HttpGet("{page}")]
        public async Task<ActionResult<List<Product>>> GetProducts(int page)
        {
            if (_context.Products == null)
                return NotFound();

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Products.Count() / pageResults);

            var products = await _context.Products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new ProductResponse
            {
                Products = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        //over
*/
    }
      





    

