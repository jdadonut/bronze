using System;

namespace Bronze.Lib
{
    public static class Random
    {
        static System.Random random = new();

        public static T From<T>(List<T> list)
        {
            return list[random.Next(list.Count-1)];
        }
    }
}