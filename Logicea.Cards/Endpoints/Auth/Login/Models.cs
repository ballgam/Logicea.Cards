using FastEndpoints;
using FluentValidation;
using Logicea.Cards.Auth;

namespace Auth.Login
{

    public class Request
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email Address is required!")
                 .EmailAddress().WithMessage("Invalid Email Address!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!");
        }
    }

    public class Response
    {
        public string UserName { get; set; } = default!;
        public IEnumerable<string> UserPermissions { get; set; }
        public JwtToken Token { get; set; } = new();
    }

}
