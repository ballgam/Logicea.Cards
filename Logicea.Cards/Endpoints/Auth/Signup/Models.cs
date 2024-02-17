using FastEndpoints;
using FluentValidation;
using Logicea.Cards.Data.Entities;

namespace Auth.Signup
{
    public class Request
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Address is required!")
                .EmailAddress().WithMessage("Invalid Email Address!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("a password is required!");
        }
    }

    public class Response
    {
        public string Message { get; set; }
    }
}
