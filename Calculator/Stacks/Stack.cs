using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Stacks
{
    abstract class Stack
    {
        /// <summary>
        /// Adds item to stack
        /// </summary>
        /// <param name="item">item to add to stack</param>
        public abstract void Add(double? item);

        /// <summary>
        /// Returns the last value from stack
        /// </summary>
        /// <returns></returns>
        public abstract double? GetValue(int i);

        /// <summary>
        /// Removes 1 item from stack
        /// </summary>
        public abstract void Remove();

        /// <summary>
        /// Clears stack
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Counts values in stack
        /// </summary>
        /// <returns></returns>
        public abstract int getLength(int i);
    }
}
