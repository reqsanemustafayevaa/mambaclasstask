using FluentValidation;
using MambaAPIclasstask.DTOs.MemberDtos;

namespace MambaAPIclasstask.DTOs.ProfessionDto
{
    public class ProfessionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProfessionGetDtoValidator : AbstractValidator<ProfessionGetDto>
    {
        public ProfessionGetDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("bosh ola bilmez")
                                .MaximumLength(30).WithMessage("max 30 ola biler");

          
        }
    }
}
