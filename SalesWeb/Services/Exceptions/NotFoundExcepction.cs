using System;

namespace SalesWeb.Services.Exceptions
{
    public class NotFoundExcepction : ApplicationException
    {
        public NotFoundExcepction(string message) : base(message)
        {
        }
    }
}