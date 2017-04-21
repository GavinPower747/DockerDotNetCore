using System;

public class ExceptionController
{
    public void Index()
    {
        throw new Exception("This was meant to happen");
    }
}