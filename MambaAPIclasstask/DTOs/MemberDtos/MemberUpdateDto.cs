using FluentValidation;

namespace MambaAPIclasstask.DTOs.MemberDtos
{
    public class MemberUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public List<int> ProfessionIds { get; set; } = new List<int>();
        public string RedirectUrl { get; set; }
    }
    public class MemberUpdateDtoValidator : AbstractValidator<MemberUpdateDto>
    {
        public MemberUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("bosh ola bilmez")
                                .MaximumLength(30).WithMessage("max 30 ola biler");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("bosh ola bilmez");

            RuleFor(x => x.RedirectUrl).NotNull().WithMessage("null olamaz");
        }
    }

}
