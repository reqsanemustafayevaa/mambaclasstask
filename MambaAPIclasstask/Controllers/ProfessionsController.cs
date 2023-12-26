using AutoMapper;
using MambaAPIclasstask.Data;
using MambaAPIclasstask.DTOs.ProfessionDto;
using MambaAPIclasstask.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MambaAPIclasstask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProfessionsController(AppDbContext Context,IMapper mapper)
        {
            _context = Context;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public  IActionResult Get(ProfessionGetDto dto)
        {
            var profession = _context.Professions.FirstOrDefault(x=>x.Id==dto.Id);
            if (profession == null)
            {
                return NotFound();
            }
          ProfessionGetDto prdto=_mapper.Map<ProfessionGetDto>(profession);
            return Ok(prdto);
        }
       
        [HttpGet("")]
        public IActionResult GetAll()
        {
          
            List<ProfessionGetDto> professionGetDtos = new List<ProfessionGetDto>();
            foreach (var item in professionGetDtos)
            {
                ProfessionGetDto professionGetDto = new ProfessionGetDto()
                {
                    Id = item.Id,
                    Name = item.Name,

                };
                professionGetDtos.Add(professionGetDto);
            }
            return Ok(professionGetDtos);
        }
        [HttpPost]
        public IActionResult Create([FromForm]ProfessionCreateDto dto)
        {
            var profession = _mapper.Map<Profession>(dto);
            profession.CreatedDate = DateTime.UtcNow.AddHours(4);
            profession.UpdatedDate = DateTime.UtcNow.AddHours(4);
            profession.Isdeleted = false;
            _context.Professions.Add(profession);
            _context.SaveChanges();
            return StatusCode(201, new { message = "object yaradildi" });
        }
        [HttpPut]
        public IActionResult Update(ProfssionUpdateDto dto)
        {

            var existprofession = _context.Professions.FirstOrDefault(x => x.Id == dto.Id);
            if (existprofession == null)
            {
                return NotFound();
            }
            existprofession = _mapper.Map(dto, existprofession);



            existprofession.UpdatedDate = DateTime.UtcNow.AddHours(4);
            existprofession.Isdeleted = false;
            _context.SaveChanges();
            return Content("update olundu");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existprofession = _context.Professions.FirstOrDefault(x => x.Id ==id);
            if(existprofession == null)
            {
                return NotFound();

            }
            _context.Professions.Remove(existprofession);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
