using System.Collections.Generic;

namespace JWT.Api.Helpers
{
    public class Response<TResponse>
    {
        public TResponse Value { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
