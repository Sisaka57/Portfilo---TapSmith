using System;

namespace UnityEngine.Math
{
    [Serializable]
    public class Range
    {
        public int Min = 0;
        public int Max = 0;

        public Range()
        {
            Min = 0;
            Max = 100;
        }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}