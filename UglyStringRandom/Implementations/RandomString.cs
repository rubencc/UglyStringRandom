namespace UglyStringRandom
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RandomString :IRandomString
    {
        private readonly IRandomNumber rn;

        public RandomString(IRandomNumber rn)
        {
            this.rn = rn ?? throw new ArgumentNullException(nameof(rn));
        }

        public string GetRandom(int length, string dataSet)
        {
            if(length <= 0)
                return String.Empty;

            StringBuilder sb = new StringBuilder();

            int dataSetLength = dataSet.Length;

            List<int> integers = this.rn.GetIntegers(length);

            integers.ForEach(x =>
            {
                int integer = Math.Abs(x);
                int index = integer % dataSetLength;
                sb.Append(dataSet[index]);
            });

            //for (int i = 0; i < length; i++)
            //{
            //    int integer = Math.Abs(this.rn.GetInteger());
            //    int index = integer % dataSetLength;
            //    sb.Append(dataSet[index]);
            //}

            return sb.ToString();
        }

        public void Dispose()
        {
            rn?.Dispose();
        }
    }
}
