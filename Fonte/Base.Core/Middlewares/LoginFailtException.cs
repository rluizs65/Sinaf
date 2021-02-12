using System;

namespace Base.Core.Middlewares
{
    public class LoginFailtException : Exception
    {
        public LoginFailtException()
        {
        }

        public LoginFailtException(string message) : base(message)
        {
        }

        public LoginFailtException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
