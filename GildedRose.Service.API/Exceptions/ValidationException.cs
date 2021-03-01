using System;

namespace GildedRose.Service.API.Exceptions
{
    public abstract class ValidationException : Exception
    {
        public override string Message { get; }

        protected ValidationException(string message)
        {
            Message = message;
        }
    }
}
