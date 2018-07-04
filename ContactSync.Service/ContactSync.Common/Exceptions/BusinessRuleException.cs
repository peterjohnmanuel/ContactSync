using System;

namespace ContactSync.Common
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException()
        {

        }

        public BusinessRuleException(string message) : base (message)
        {

        }
    }
}
