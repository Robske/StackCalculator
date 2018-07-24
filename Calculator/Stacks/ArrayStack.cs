using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ArrayStack : Stacks.Stack
    {
        public double?[] stack;

        /// <summary>
        /// Set array with specified size
        /// </summary>
        /// <param name="totalIndex">Array size</param>
        public ArrayStack(int totalIndex)
        {
            stack = new double?[totalIndex];
        }

        // Explained in Stack class
        public override void Add(double? value)
        {
            if (stack[0] == null)
            {
                stack[0] = value;
            }
            else
            {
                int index = getLength();
                stack[index] = value;
            }
        }

        // Explained in Stack class
        public override double? GetValue(int stackLength = -1)
        {
            if (stackLength == -1)
            {
                stackLength = getLength();
            }

            if (stackLength > 0)
            {

                return stack[stackLength - 1];
            }
            else
            {
                return null;
            }
        }

        // Explained in Stack class
        public override void Remove()
        {
            int index = getLength();
            stack[index - 1] = null;
        }

        // Explained in Stack class
        public override void Clear()
        {
            Array.Clear(stack, 0, stack.Length);
        }

        // Explained in Stack class
        public override int getLength(int i = 0)
        {
            int count = 0;

            foreach (double? value in stack)
            {
                if (stack[count] != null)
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }

            return count;
        }
    }
}
