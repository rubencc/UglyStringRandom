namespace UglyStringRandom
{
    using System;
    using System.Collections.Generic;

    public interface IRandomNumber : IDisposable
    {
        int GetInteger();
        List<int> GetIntegers(int number);
    }
}
