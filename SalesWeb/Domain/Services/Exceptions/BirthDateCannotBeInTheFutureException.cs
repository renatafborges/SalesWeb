using System;

namespace SalesWeb.Domain.Services.Exceptions
{
    public class BirthDateCannotBeInTheFutureException : Exception
    {
        public BirthDateCannotBeInTheFutureException() : base("Birth Date cannot be in the future.")
        {
        } 
    }
}