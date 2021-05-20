using System;

public class MyException : Exception
{
    private readonly bool critical;
    public MyException()
    {
    }

    public MyException(string message, bool critical)
        : base(message)
    {
        this.critical = critical;
    }

    public MyException(string message, Exception inner, bool critical)
        : base(message, inner)
    {
        this.critical = critical;

    }

    public bool isCritical()
    {
        return this.critical;
    }
}