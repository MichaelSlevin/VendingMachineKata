using System;

namespace VendingMachineKata
{
    public class InsufficientCreditException : Exception
    {
        public InsufficientCreditException()
        {
        }

        public InsufficientCreditException(string message) : base(message)
        {
        }

        public InsufficientCreditException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}