using System;

namespace mop.BaseCalculator.Interfaces
{
    /// <summary>
    /// Inteface to perform calculations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICalculator<T> where T : struct
    {
        /// <summary>
        /// This method caculates the sum of two arguments of the same type
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        T Calculate(T arg1, T arg2);
    }
}
