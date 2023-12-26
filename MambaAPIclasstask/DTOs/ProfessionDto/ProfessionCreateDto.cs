using FluentValidation;

namespace MambaAPIclasstask.DTOs.ProfessionDto
{
    public class ProfessionCreateDto
    {
        public string Name { get; set; }
    }
    public class ProfessionCreateDtoValidator : AbstractValidator<ProfessionGetDto>
    {
        public ProfessionCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("bosh ola bilmez")
                                .MaximumLength(30).WithMessage("max 30 ola biler");

        }
    }
}
