using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace KnockKnockWCF
{
    /// <summary>
    /// Service contract
    /// </summary>
    [ServiceContract]
    public interface IKnockKnockService 
    {
        /// <summary>
        /// Potentially checks the passed token
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = @"/Token")]
        Guid Token();

        /// <summary>
        /// Gets the nth Fibonacci number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = @"/Fibonacci?n={n}")]
        [FaultContract(typeof(ArgumentOutOfRangeException))]
        long Fibonacci(long n);

        /// <summary>
        /// Reverses a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = @"/ReverseWords?s={s}")]
        string ReverseWords(string s);

        /// <summary>
        /// Finds the type of triangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = @"/TriangleType?a={a}&b={b}&c={c}")]
        TypeOfTriangle TriangleType(int a, int b, int c);
    }

    /// <summary>
    /// Data contracts
    /// </summary>
    [DataContract]
    public enum TypeOfTriangle
    {
        /// <summary>
        /// Type of triangle - scalene
        /// </summary>
        [EnumMember]
        Scalene = 1,      // no two sides are the same length
        /// <summary>
        /// Type of triangle - isosceles
        /// </summary>
        [EnumMember]
        Isosceles = 2,    // two sides are the same length and one differs
        /// <summary>
        /// Type of triangle - equilateral
        /// </summary>
        [EnumMember]
        Equilateral = 3,  // all sides are the same length
        /// <summary>
        /// Returns error
        /// </summary>
        [EnumMember]
        Error = 4         // inputs can't produce a triangle
    }
}
