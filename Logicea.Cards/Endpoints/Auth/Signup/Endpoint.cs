using FastEndpoints;
using Logicea.Cards.Services.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Auth.Signup
{
    internal sealed class Endpoint : Endpoint<Request, Response, Mapper>
    {
        private readonly IAuthService _authService;

        public Endpoint(IAuthService authService)
        {
            _authService = authService;
        }

        public override void Configure()
        {
            Post("/auth/signup");
            AllowAnonymous();

            Summary(s =>
            {
                s.Summary = "Endpoint for signing up the API";
                s.Description = "Users signs up by providing their email and password. For simplicity, the registering user will also provide the role(Member or Admin) for which he's being registered for.";
                s.ExampleRequest = new Request { Email = "test@test.com", Password = "password123", Role="Member" };
            });
        }

        public override async Task HandleAsync(Request req, CancellationToken c)
        {
            var user = Map.ToEntity(req);

            var emailIsTaken = await _authService.EmailAddressIsTaken(user.Email);
            if (emailIsTaken)
                AddError(r => r.Email, "Email address is already in use!");

            ThrowIfAnyErrors();

            await _authService.CreateNewUser(user);

            await SendAsync(new() { Message = "User signup successfull!" });
        }
    }
}