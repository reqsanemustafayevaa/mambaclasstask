using FluentValidation;

namespace MambaAPIclasstask.DTOs.MemberDtos
{
    public class MemberCreateDto
    {
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public string RedirectUrl { get; set; }
        public List<int> ProfessionIds { get; set; }
    }
    public class MemberCreateDtoValidator : AbstractValidator<MemberCreateDto>
    {
        public MemberCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("bosh ola bilmez")
                                .MaximumLength(30).WithMessage("max 30 ola biler");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("bosh ola bilmez");

            RuleFor(x => x.RedirectUrl).NotNull().WithMessage("null olamaz");
        }
    }
}
