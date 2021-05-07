using System;
using System.Linq.Expressions;
using mop.BaseCalculator.Interfaces;

namespace mop.Calculator
{
    /// <summary>
    /// Simple calculator to perform operations on a given type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddCalculator<T> : ICalculator<T> where T : struct, IComparable
    {
        /// <summary>
        /// Adds two values of the same type. Does not check for overflows
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public T Calculate(T arg1, T arg2)
        {
            var arg1Operand = Expression.Parameter(typeof(T), "arg1");
            var arg2Operand = Expression.Parameter(typeof(T), "arg2");

            var body = Expression.Add(arg1Operand, arg2Operand);

            var addFunc = Expression.Lambda<Func<T, T, T>>(body, arg1Operand, arg2Operand);

            Func<T, T, T> addDelegate = addFunc.Compile();

            return addDelegate(arg1, arg2);
        }
    }
}
