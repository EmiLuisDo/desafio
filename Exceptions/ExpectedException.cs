using System;

public class ExpectedException : Exception
{
    private readonly bool critical;
    public ExpectedException()
    {
    }

    public ExpectedException(string message, bool critical)
        : base(message)
    {
        this.critical = critical;
    }

    public ExpectedException(string message, Exception inner, bool critical)
        : base(message, inner)
    {
        this.critical = critical;

    }

    public bool isCritical()
    {
        return this.critical;
    }
}