using FastEndpoints;

namespace Cards.Delete
{
    internal sealed class Request
    {
        public string CardID { get; set; } = default!;

        [FromClaim]
        public string UserID { get; set; } = default!;
    }



    internal sealed class Response
    {
        public string Message { get; set; } = default!;
    }
}
