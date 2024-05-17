using Newtonsoft.Json;

namespace News.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public IEnumerable<string> Errors => _errors;
        private IEnumerable<string> _errors;

        public ExceptionModel(IEnumerable<string> errors, int statusCode)
        {
            _errors = errors;
            StatusCode = statusCode;
        }

        public override string ToString() => JsonConvert.SerializeObject(Errors);
    }
}