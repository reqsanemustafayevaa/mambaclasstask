using AutoMapper;
using MambaAPIclasstask.Data;
using MambaAPIclasstask.DTOs.MemberDtos;
using MambaAPIclasstask.DTOs.ProfessionDto;
using MambaAPIclasstask.Entities;
using MambaAPIclasstask.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MambaAPIclasstask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public MembersController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;

        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            MemberGetDto memberGetDto = _mapper.Map<MemberGetDto>(member);

            return Ok(memberGetDto);


        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create([FromForm] MemberCreateDto dto)
        {
            var member = _mapper.Map<Member>(dto);


            bool check = true;

            if (dto.ProfessionIds != null)
            {
                foreach (int professionId in dto.ProfessionIds)
                {
                    if (!_context.memberprofessions.Any(profession => profession.Id == professionId))
                    {
                        check = false;
                        break;
                    }
                }
            }

            if (check)
            {
                if (dto.ProfessionIds != null)
                {
                    foreach (int professionId in dto.ProfessionIds)
                    {
                        Memberprofession memberProfession = new Memberprofession()
                        {
                            Member = member,
                            ProfessionId = professionId,
                        };

                        _context.memberprofessions.Add(memberProfession);
                    }
                }
            }
            else
            {
                return NotFound();
            }

            if (dto.ImageFile != null)
            {
                if (dto.ImageFile.ContentType != "image/png" && dto.ImageFile.ContentType != "image/jpeg")
                {
                    return BadRequest("file must be .jpg or .png");
                }

                if (dto.ImageFile.Length > 1048576)
                {
                    return BadRequest("file must be lower than 2 mb");
                }
            }
            else
            {
                return BadRequest("required!");
            }

            string ImgUrl = Helper.SaveFile(_env.WebRootPath, "uploads/members", dto.ImageFile);
            member.CreatedDate = DateTime.UtcNow.AddHours(4);
            member.UpdatedDate = DateTime.UtcNow.AddHours(4);
            member.Isdeleted = false;
            member.ImageUrl = ImgUrl;
            _context.Members.Add(member);
            _context.SaveChanges();
            return StatusCode(201, new { message = "object yaradildi" });
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public  IActionResult Update([FromForm] MemberUpdateDto dto)
        {

            var member =  _context.Members.Include(x => x.Memberprofessions).FirstOrDefault(x => x.Id == dto.Id);

            if (member == null)
            {
                return NotFound();
            }
               

            member.Memberprofessions.RemoveAll(y => !dto.ProfessionIds.Contains(y.Id));

            foreach (var professionId in dto.ProfessionIds)
            {
                Memberprofession memberprf = new Memberprofession
                {
                    Member = member,
                    ProfessionId = professionId,
                };


                _context.memberprofessions.Add(memberprf);
            }

            if (dto.ImageFile != null)
            {
                if (dto.ImageFile.ContentType != "image/png" && dto.ImageFile.ContentType != "image/jpeg")
                {
                    return BadRequest("file must be .jpg or png");
                }

                if (dto.ImageFile.Length > 1048576)
                {
                    return BadRequest("file size must be lower than 1 mb");
                }

                
                string ImgUrl =  Helper.SaveFile(_env.WebRootPath,"uploads/members" , dto.ImageFile);

                string path=Path.Combine(_env.WebRootPath, "uploads/members",member.ImageUrl);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                member.ImageUrl = ImgUrl;

            }

            member = _mapper.Map(dto, member);
            member.Isdeleted = !member.Isdeleted;
            member.UpdatedDate = DateTime.UtcNow.AddHours(4);

             _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existmembeber = _context.Members.FirstOrDefault(x => x.Id == id);
            if (existmembeber == null)
            {
                return NotFound();

            }
            //_context.Professions.Remove(id);
            _context.SaveChanges();
            return NoContent();
        }



    }




}

