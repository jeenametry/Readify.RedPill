using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPill.Services;

namespace RedPill.Tests
{
    [TestClass]
    public class RedPillTests
    {
        #region Constants

        /// <summary>
        /// All possible values for fibonacci sequence
        /// </summary>
        private static readonly long[] fibAllValues =
	    {
		    0,
		    1,
		    1,
		    2,
		    3,
		    5,
		    8,
		    13,
		    21,
		    34,
		    55,
		    89,
		    144,
		    233,
		    377,
		    610,
		    987,
		    1597,
		    2584,
		    4181,
		    6765,
		    10946,
		    17711,
		    28657,
		    46368,
		    75025,
		    121393,
		    196418,
		    317811,
		    514229,
		    832040,
		    1346269,
		    2178309,
		    3524578,
		    5702887,
		    9227465,
		    14930352,
		    24157817,
		    39088169,
		    63245986,
		    102334155,
		    165580141,
		    267914296,
		    433494437,
		    701408733,
		    1134903170,
		    1836311903,
		    2971215073,
		    4807526976,
		    7778742049,
		    12586269025,
		    20365011074,
		    32951280099,
		    53316291173,
		    86267571272,
		    139583862445,
		    225851433717,
		    365435296162,
		    591286729879,
		    956722026041,
		    1548008755920,
		    2504730781961,
		    4052739537881,
		    6557470319842,
		    10610209857723,
		    17167680177565,
		    27777890035288,
		    44945570212853,
		    72723460248141,
		    117669030460994,
		    190392490709135,
		    308061521170129,
		    498454011879264,
		    806515533049393,
		    1304969544928657,
		    2111485077978050,
		    3416454622906707,
		    5527939700884757,
		    8944394323791464,
		    14472334024676221,
		    23416728348467685,
		    37889062373143906,
		    61305790721611591,
		    99194853094755497,
		    160500643816367088,
		    259695496911122585,
		    420196140727489673,
		    679891637638612258,
		    1100087778366101931,
		    1779979416004714189,
		    2880067194370816120,
		    4660046610375530309,
			7540113804746346429
	    };

        #endregion

        #region Members

        RedPill.Services.RedPill _redPillService;

        #endregion

        [TestInitialize]
        public void Init()
        {
            _redPillService = new RedPill.Services.RedPill();
        }

        #region Fibonacci

        [TestMethod]
        public void FibonacciNumber_ValidValues()
        {
            
            for (int i = 0; i < fibAllValues.Length; i++)
            {
                Assert.AreEqual(fibAllValues[i], _redPillService.FibonacciNumber(i));
            }
        }

        [TestMethod]
        public void FibonacciNumber_OutOfRange()
        {
            var exceptionThrown = false;
            try
            {
                _redPillService.FibonacciNumber(93);
            }
            catch (ArgumentOutOfRangeException)
            {
                exceptionThrown = true;
            }

            try
            {
                _redPillService.FibonacciNumber(-93);
            }
            catch (ArgumentOutOfRangeException)
            {
                exceptionThrown = true;
            }

            Assert.AreEqual(true, exceptionThrown, "FibonacciNumber_OutOfRange expected to throw ArgumentOutOfRangeException");
        }

        #endregion

        #region ReverseWords

        [TestMethod]
        public void ReverseWords_ValidResult()
        {
            string inputString = null;

            // Assert words are reversed correctly
            inputString = "cat and dog";
            Assert.AreEqual("tac dna god", _redPillService.ReverseWords(inputString));

            // Assert whitespace(s) are preserverd correctly
            inputString = "cat    and dog ";
            Assert.AreEqual("tac    dna god ", _redPillService.ReverseWords(inputString));

            // Assert a string containing one word is reversed correctly
            inputString = "catanddog";
            Assert.AreEqual("goddnatac", _redPillService.ReverseWords(inputString));

            // Assert a string starting with a whitespace is reversed correctly
            inputString = "  cat and dog";
            Assert.AreEqual("  tac dna god", _redPillService.ReverseWords(inputString));

            // Assert Empty String is handled correctly
            inputString = "";
            Assert.AreEqual("", _redPillService.ReverseWords(inputString));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReverseWords_NullArgument()
        {
            _redPillService.ReverseWords(null);

        }

        #endregion

        #region WhatShapeIsThis

        [TestMethod]
        public void WhatShapeIsThis_ValidResult()
        {
            //Assert Error is returned when passing in invalid values
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(0, 0, 0));
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(-1, 4, 4));
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(0, 2, 4));
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(1, 2, 4));
            Assert.AreEqual(TriangleType.Error, _redPillService.WhatShapeIsThis(2, 2, 4));

            //Assert Equilateral
            Assert.AreEqual(TriangleType.Equilateral, _redPillService.WhatShapeIsThis(5, 5, 5));

            //Assert Isosceles
            Assert.AreEqual(TriangleType.Isosceles, _redPillService.WhatShapeIsThis(5, 5, 4));
            Assert.AreEqual(TriangleType.Isosceles, _redPillService.WhatShapeIsThis(5, 4, 5));
            Assert.AreEqual(TriangleType.Isosceles, _redPillService.WhatShapeIsThis(4, 5, 5));

            //Assert Scalene
            Assert.AreEqual(TriangleType.Scalene, _redPillService.WhatShapeIsThis(4, 5, 6));
        }
        #endregion
    }
}
