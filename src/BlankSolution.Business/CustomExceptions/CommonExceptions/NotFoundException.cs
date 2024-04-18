using System.Runtime.Serialization;

namespace BlankSolution.Business.CustomExceptions.CommonExceptions
{
    public class NotFoundException : Exception
    {
        public int StatusCode { get; set; }
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        protected NotFoundException(int statuscode, string message) : base(message)
        {
            StatusCode = statuscode;
        }
    }
}
