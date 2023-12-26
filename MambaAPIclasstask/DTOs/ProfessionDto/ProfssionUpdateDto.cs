using FluentValidation;

namespace MambaAPIclasstask.DTOs.ProfessionDto
{
    public class ProfssionUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProfessionUpdateDtoValidator : AbstractValidator<ProfssionUpdateDto>
    {
        public ProfessionUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("bosh ola bilmez")
                                .MaximumLength(30).WithMessage("max 30 ola biler");

        }
    }
}
