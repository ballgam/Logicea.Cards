using FastEndpoints;
using FluentValidation;
using Logicea.Cards.Data.Models;
using System.Text.RegularExpressions;

namespace Cards.Update
{
    internal sealed class Request : CardModel
    {
        [FromClaim]
        public string UserID { get; set; } = default!;
    }

    internal sealed class Validator : Validator<Request>
    {
        public Validator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Card Name is required!")
                .MaximumLength(10).WithMessage("Card Name too long!");

            RuleFor(x => x.Description)
                .MinimumLength(100).WithMessage("Card Description is too short!");

            RuleFor(x => x.Color)
                .Must(BeAValidColor).WithMessage("Invalid Color Code!");
        }

        private bool BeAValidColor(string color)
        {
            string pattern = @"^#[0-9A-Fa-f]{6}$";
            Regex regex = new Regex(pattern);

            bool isValid = regex.IsMatch(color);

            return isValid;
        }
    }

    internal sealed class Response
    {
        public string Message => "Card saved!";
        public string? CardID { get; set; }
    }
}
