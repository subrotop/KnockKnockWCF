using System;
using System.ServiceModel;

namespace KnockKnockWCF
{
    /// <summary>
    /// The Knock knock service
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class KnockKnockService : IKnockKnockService
    {
        /// <summary>
        /// The Readify token associated with the subroto pant
        /// </summary>
        protected Guid token = new Guid("3b39f592-b55f-4451-b95d-74ead823a3fe");

        /// <summary>
        /// Returns token
        /// </summary>
        /// <returns></returns>
        public Guid Token()
        {
            //no guid with no checks
            return token;
        }

        #region Fibonacci
        /// <summary>
        /// using recursion
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long FindNthFibonacciNumber(long n)
        {
            //recursion should do it
            if (n == 1 || n == 2) return 1;
            long nthfibonacciNumber = FindNthFibonacciNumber(n - 1) + FindNthFibonacciNumber(n - 2);
            return nthfibonacciNumber;
        }

        /// <summary>
        /// This one uses Binet's Formula
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long GetBinetsFibonacciNumber(long n)
        {
            if (n > 92)
                throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");
            if (n < -92)
                throw new ArgumentOutOfRangeException("n", "Fib(<-92) will cause a 64-bit integer overflow.");

            var sqrt5 = Math.Sqrt(5);

            var bigPhi = (sqrt5 + 1) / 2;
            var miniPhi = bigPhi - 1;

            return Convert.ToInt64((Math.Pow(bigPhi, n) - Math.Pow(-miniPhi, n)) / sqrt5);
        }

        /// <summary>
        /// Gets nth Fibonacci number
        /// </summary>
        /// <param name="n" description="The index(n) of the fibonacci sequence "></param>
        /// <returns></returns>
        public long Fibonacci(long n)
        {
            long result = 0;
            result = GetFibonacci(n);
            return result;
        }

        private long GetFibonacci(long n)
        {
            long result;
            try
            {
                result = GetBinetsFibonacciNumber(n); // FindNthFibonacciNumber(n);
            }
            catch (Exception ex)
            {
                throw new Exception("GetBinetsFibonacciNumber failed", ex);
            }

            return result;
        }

        #endregion

        #region reversewords


        /// <summary>
        /// Reverses the word
        /// </summary>
        /// <param name="s" description="A sentence"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            string result = string.Empty;
            try
            {
                result = ReverseString(s);
            }
            catch (Exception ex)
            {
                throw new Exception("ReverseWords failed", ex);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseStringDirect(string s)
        {
            char[] array = new char[s.Length];
            int forward = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                array[forward++] = s[i];
            }
            return new string(array);
        }

        #endregion

        #region Triangle Calculations

        ///check triangle type
        /// <summary>
        /// Displays the triangle name
        /// </summary>
        /// <param name="a" description="The length of side a"></param>
        /// <param name="b" description="The length of side b"></param>
        /// <param name="c" description="The length of side c"></param>
        /// <returns></returns>
        public TypeOfTriangle TriangleType(int a, int b, int c)
        {
            TypeOfTriangle result = TypeOfTriangle.Error;

            try
            {
                result = GetTypeOfTriangle(a, b, c);
            }
            catch (Exception ex)
            {
                throw new Exception("TriangleType failed", ex);
            }
            return result;
        }

        /// <summary>
        /// Gets the type of the specified triangle.
        /// </summary>
        /// <param name="a">The length of side 'a'.</param>
        /// <param name="b">The length of side 'b'.</param>
        /// <param name="c">The length of side 'c'.</param>
        /// <returns>The <see cref="TypeOfTriangle"/> type.</returns>
        public TypeOfTriangle GetTypeOfTriangle(int a, int b, int c)
        {
            var key = string.Format("GetTypeOfTriangle{0},{1},{2}", a, b, c);

            var result = TypeOfTriangle.Error;

            if (!this.IsValidTriangle(a, b, c))
            {
                return TypeOfTriangle.Error;
            }
            else if (this.IsEquilateralType(a, b, c))
            {
                result = TypeOfTriangle.Equilateral;
            }
            else if (this.IsScaleneType(a, b, c))
            {
                result = TypeOfTriangle.Scalene;
            }
            else if (this.IsIsoscelesType(a, b, c))
            {
                result = TypeOfTriangle.Isosceles;
            }

            return result;
        }

        #endregion

        #region Protected Methods

        protected bool IsValidTriangle(int a, int b, int c)
        {
            bool triangleExist = true;

            // All sides must have positive length.
            if (a <= 0 || b <= 0 || c <= 0)
            {
                triangleExist = false;
            }
            // The sum of the lengths of any two sides of a triangle must be greater than the length of the third side for non-degenerate triangle.
            else if (((long)a + b) <= c)
            {
                triangleExist = false;
            }
            else if (((long)a + c) <= b)
            {
                triangleExist = false;
            }
            else if (((long)b + c) <= a)
            {
                triangleExist = false;
            }

            return triangleExist;
        }

        // An equilateral triangle has all sides the same length. 
        // An equilateral triangle is also a regular polygon with all angles measuring 60°.
        protected bool IsEquilateralType(int a, int b, int c)
        {
            return (a == b && a == c);
        }

        // An isosceles triangle has two sides of equal length.
        // An isosceles triangle also has two angles of the same measure.
        protected bool IsIsoscelesType(int a, int b, int c)
        {
            return (a == b || a == c || b == c);
        }

        // A scalene triangle has all sides different lengths, or equivalently all angles are unequal.
        protected bool IsScaleneType(int a, int b, int c)
        {
            return (a != b && a != c && b != c);
        }

        #endregion
    }

}
