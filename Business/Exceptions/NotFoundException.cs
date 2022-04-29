// NotFoundException.cs
//
// © 2021

namespace Business.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string? message)
        : base(message)
    {
    }
}