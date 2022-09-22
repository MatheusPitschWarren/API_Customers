using System;

namespace DomainServices.Expections;

public class NotFoundException : Exception
{
    public NotFoundException(string errorMessage) : base(errorMessage) { }
}
