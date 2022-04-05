using System;

namespace FormClean.Domain.Validation
{
    public class DomainExceptionValidate : Exception
    {

        public DomainExceptionValidate(string error) : base(error) { }

        public static void When(bool hasError, string error) 
        {
            if(hasError) 
            {
                throw new DomainExceptionValidate(error);
            }
        
        }

    }
}
