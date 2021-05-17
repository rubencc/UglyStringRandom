namespace UglyStringRandom
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public class RandomNumber : IRandomNumber
    {
        private readonly RandomNumberGenerator rd;
        private readonly int size;
        private readonly byte[] buffer;
        private int index;

        public RandomNumber()
        {
            this.rd = RandomNumberGenerator.Create();
            this.size = sizeof(int);
            this.buffer = new byte[this.size * 64];
            this.index = this.buffer.Length;
        }

        public int GetInteger()
        {

            if (this.index >= this.buffer.Length)
            {
                this.rd.GetBytes(this.buffer);
                this.index = 0;
            }

            var result = BitConverter.ToInt32(this.buffer, this.index);
            this.index += this.size;
            return result;
        }

        public List<int> GetIntegers(int number)
        {
            List<int> result = new List<int>(number);

            for (int i = 0; i < number; i++)
            {
                int integer = this.GetInteger();
                result.Add(integer);
            }

            return result;
        }

        public void Dispose()
        {
            this.rd?.Dispose();
        }
    }
}
