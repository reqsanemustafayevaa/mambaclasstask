using FluentValidation;
using System.Security.AccessControl;

namespace MambaAPIclasstask.DTOs.MemberDtos
{
    public class MemberGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public string RedirectUrl { get; set; }
    }
    public class MemberGetDtoValidator : AbstractValidator<MemberGetDto>
    {
        public MemberGetDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("bosh ola bilmez")
                                .MaximumLength(30).WithMessage("max 30 ola biler");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("bosh ola bilmez");

            RuleFor(x => x.RedirectUrl).NotNull().WithMessage("null olamaz");
        }
    }
}
