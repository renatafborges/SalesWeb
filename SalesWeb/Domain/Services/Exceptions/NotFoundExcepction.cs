using System;

namespace SalesWeb.Domain.Services.Exceptions
{
    public class NotFoundExcepction : ApplicationException
    {
        public NotFoundExcepction(string message) : base(message)
        {
        }
    }
}