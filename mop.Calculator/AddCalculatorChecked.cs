using System;
using mop.BaseCalculator.Interfaces;

namespace mop.Calculator
{
    /// <summary>
    /// Calculator to perform operations on a given type. 
    /// It throws an OverflowException, where applicable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddCalculatorChecked<T> : ICalculator<T> where T : struct, IComparable
    {
        /// <summary>
        /// Adds two values of the same type.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public T Calculate(T arg1, T arg2)
        {
            var dynArg1 = (dynamic)arg1;
            var dynArg2 = (dynamic)arg2;

            var result = checked(dynArg1 + dynArg2);

            return result;
        }
    }
}
