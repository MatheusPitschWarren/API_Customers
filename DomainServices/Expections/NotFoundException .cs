using System;

namespace DomainServices.Expections;

public class GenericNotFoundException : Exception
{
    public NotFoundException(string errorMessage) : base(errorMessage) { }
}
