using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ListStack : Stacks.Stack
    {
        public List<double?> stack;

        // Explained in Stack class
        public ListStack()
        {
            stack = new List<double?>();
        }

        // Explained in Stack class
        public override void Add(double? value)
        {
            stack.Add(value);
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
            stack.RemoveAt(stack.Count - 1);
        }

        // Explained in Stack class
        public override void Clear()
        {
            stack.Clear();
        }

        // Explained in Stack class
        public override int getLength(int i = 0)
        {
            return stack.Count;
        }
    }
}
