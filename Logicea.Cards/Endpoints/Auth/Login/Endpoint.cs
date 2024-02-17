using FastEndpoints;
using FastEndpoints.Security;
using Logicea.Cards.Auth;
using Logicea.Cards.Services.Contracts;

namespace Auth.Login
{
    internal sealed class Endpoint : Endpoint<Request, Response>
    {
        private readonly IAuthService _authService;

        public Endpoint(IAuthService authService)
        {
            _authService = authService;
        }

        public override void Configure()
        {
            Post("/auth/login");
            AllowAnonymous();

            Summary(s =>
            {
                s.Summary = "Endpoint for signing in the API";
                s.Description = "Once a user signs in, they'll get a jwt token which will be used for subsequent api access";
                s.ExampleRequest = new Request { Email = "test@test.com", Password = "password123" };
            });
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var loginModel = await _authService.Login(r.Email);

            if (loginModel is null
                || (string.IsNullOrEmpty(loginModel.PasswordHash) || !BCrypt.Net.BCrypt.Verify(r.Password, loginModel.PasswordHash)))
            {
                ThrowError("Invalid login details!");
            }


            Response.UserName = r.Email;
            //Response.UserPermissions = Allow.NamesFor(Allow.Admin);
            Response.Token.ExpiryDate = DateTime.UtcNow.AddHours(4);

            Response.Token.Value = JWTBearer.CreateToken(
                signingKey: Config["JwtSigningKey"]!,
                expireAt: DateTime.UtcNow.AddHours(4),
                //permissions: Allow.Admin,//TODO::
                claims: (Claim.AdminID, loginModel.UserID.ToString()));
        }
    }
}