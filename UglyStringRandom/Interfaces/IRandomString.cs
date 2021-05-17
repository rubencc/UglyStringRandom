namespace UglyStringRandom
{
    using System;

    public interface IRandomString : IDisposable
    {
        string GetRandom(int length, string dataSet);
    }
}
