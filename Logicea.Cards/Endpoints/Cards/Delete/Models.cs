using FastEndpoints;

namespace Cards.Delete
{
    internal sealed class Request
    {
        public int CardID { get; set; } = default!;

        [FromClaim]
        public int UserID { get; set; } = default!;
    }



    internal sealed class Response
    {
        public string Message { get; set; } = default!;
    }
}
