using System;

namespace DomainServices.Expections;

public class GenericNotFoundException : Exception
{
    public GenericNotFoundException(string errorMessage) : base(errorMessage) { }
}
