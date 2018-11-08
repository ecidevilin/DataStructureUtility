

namespace Chaos
{
    public static class PowerOfTwo
    {
        public static int ToLarger(int n)
        {
            if ((n & (n - 1)) != 0)
            {
                n |= (n >> 1);
                n |= (n >> 2);
                n |= (n >> 4);
                n |= (n >> 8);
                n |= (n >> 16);
                n++;
                if (n < 0)
                {
                    n >>= 1;
                }
            }
            return n;
        }
    }
}
