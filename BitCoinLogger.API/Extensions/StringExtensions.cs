using System;

namespace BitcoinLogger.Api.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string lhs, string rhs)
        {
            return lhs.Equals(rhs, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}