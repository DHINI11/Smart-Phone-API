using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Phone.Model;

namespace Smart_Phone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileDeatils : ControllerBase
    {
        public readonly DataContext _context;
        public MobileDeatils(DataContext context)
        {
            _context = context;
        }
  
        [HttpGet]
        public async Task<ActionResult<List<MobileModel>>> GetAllMobile()
        {
            return Ok(await _context.Mobiles.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<MobileModel>>> GetMobile(int id)
        {
            var Data = await _context.Mobiles.FindAsync(id);
            if (Data == null)
                return BadRequest();

            return Ok(Data);
        }
        [HttpPost]
        public async Task<ActionResult<List<MobileModel>>> AddMobile(MobileModel mobile) {
           
            var Data = new MobileModel();
            
            if (mobile != null)
            {
                Data.Id = mobile.Id;
                Data.mobileName = mobile.mobileName;
                Data.launchYear = mobile.launchYear;
                Data.price = mobile.price;
                await _context.Mobiles.AddAsync(Data);
                await _context.SaveChangesAsync();

                return Ok(await _context.Mobiles.ToListAsync());
            }
            else {
            return BadRequest("Not a valid type");
            }
        }
        [HttpPut]

        public async Task<ActionResult<List<MobileModel>>> UpdateMobile(MobileModel request)
        {

           var Data = await _context.Mobiles.FindAsync(request.Id);
            if(Data == null)
                return NotFound("Requested Data Not Found");

            Data.price = request.price;
            Data.launchYear = request.launchYear;
            Data.mobileName=request.mobileName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Mobiles.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteMobile(int Id)
        {
            var Data = await _context.Mobiles.FindAsync(Id);
            if (Data == null)
                return BadRequest("Data Not Exist");

            _context.Mobiles.Remove(Data);
            return Ok( await _context.Mobiles.ToListAsync());
        }



    }
}
