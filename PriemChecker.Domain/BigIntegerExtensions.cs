using System;
using System.Numerics; // For BigInteger

public static class BigIntegerExtensions
{
    // Extension method to compute integer square root of a BigInteger
    public static BigInteger Sqrt(this BigInteger n)
    {
        if (n == 0) return 0;
        if (n > 0)
        {
            // Start with an initial guess for the square root
            BigInteger bitLength = n >> 1;
            BigInteger result = 1 << (int)(bitLength.GetBitLength() / 2);
            
            // Refine the estimate using Newton's method
            while (!IsSqrt(result, n))
            {
                result = (result + n / result) >> 1;
            }
            return result;
        }
        throw new ArithmeticException("Square root of a negative number is not supported.");
    }

    // Helper function to check if 'x' is the square root of 'n'
    private static bool IsSqrt(BigInteger x, BigInteger n)
    {
        BigInteger lowerBound = x * x;
        BigInteger upperBound = (x + 1) * (x + 1);
        return n >= lowerBound && n < upperBound;
    }

    // Extension method to get bit length of a BigInteger
    private static int GetBitLength(this BigInteger n)
    {
        return (int)Math.Ceiling(BigInteger.Log(n, 2));
    }
}