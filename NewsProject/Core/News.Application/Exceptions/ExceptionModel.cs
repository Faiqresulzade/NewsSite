using Newtonsoft.Json;

namespace News.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }

        public ExceptionModel(IEnumerable<string> errors, int statusCode)
        {
            Errors = errors;
            StatusCode = statusCode;
        }

        public override string ToString() => JsonConvert.SerializeObject(Errors);
    }
}