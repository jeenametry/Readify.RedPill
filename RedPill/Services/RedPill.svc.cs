using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RedPill.Services
{
    /// <summary>
    /// RedPill Knock Knock test
    /// </summary>
    [ServiceBehavior(Name = "RedPill", Namespace = "http://KnockKnock.readify.net")]
    public class RedPill : IRedPill
    {
        #region Constants

        //Token
        private readonly Guid READIFY_TOKEN = Guid.Empty;

        //Fibonacci
        private const int MAX_FIB_INDEX = 92;
        private const int MIN_FIB_INDEX = -92;

        #endregion

        #region Public Methods
        public Guid WhatIsYourToken()
        {
            return READIFY_TOKEN;
        }

        public long FibonacciNumber(long n)
        {
            if (n < MIN_FIB_INDEX || n > MAX_FIB_INDEX)
            {
                throw new ArgumentOutOfRangeException("n", "n is out of range");
            }

            if (n == 0) return 0;

            long a = 0;
            long b = 1;
            var index = Math.Abs(n);

            for (var i = 0; i < index; i++)
            {
                var tmp = a;
                a = b;
                b += tmp;
            }

            return n < 0 && index % 2 == 0 ? -a : a;
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                return TriangleType.Error;
            }

            if (a == b && a == c && b == c)
            {
                return TriangleType.Equilateral;
            }

            if (a == b || a == c || b == c)
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }

        public string ReverseWords(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s", "s Cannot be null");

            var input = s;
            // Holds the output string chars
            char[] output = new char[input.Length];
            // Number of charecters written in the output array
            int written = 0;
            int startIndex = 0;
            int endIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                // Current charecter
                char c = input[i];

                if (char.IsWhiteSpace(c) || i == input.Length - 1)
                {
                    endIndex = char.IsWhiteSpace(c) ? i - 1 : i;
                    //Reached end of the word or end of the string. Add the word chars to the output in a reversed order
                    for (int j = endIndex; j >= startIndex; j--)
                    {
                        output[written++] = input[j];
                    }
                    startIndex = i + 1;

                    //Add white space in the same position
                    if (char.IsWhiteSpace(c))
                        output[written++] = c;
                }
            }

            return new string(output);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets whether the specified length of the sides of the traingle can form a valid triangle.
        /// </summary>
        /// <returns></returns>
        private bool IsValidTriangle(int a, int b, int c)
        {
            // These sides can form a valid triangle.
            if (a <= 0 || b <= 0 || c <= 0)
                return false;

            if (a < b + c && b < a + c && c < a + b)
                return true;

            return false;
        }

        #endregion
    }
}
