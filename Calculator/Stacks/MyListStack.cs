using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class MyListStack : Stacks.Stack
    {
        MyListStack next;
        double? item;

        // Explained in Stack class
        public override void Add(double? value)
        {
            if (item == null)
            {
                item = value;
            }
            else if (next == null)
            {
                // Create next and set item by calling Add
                next = new MyListStack();
                next.Add(value);
            }
            else
            {
                next.Add(value);
            }
        }

        // Explained in Stack class
        public override double? GetValue(int stackLength = -1)
        {
            // if no count given, set length as count
            if (stackLength == -1)
            {
                stackLength = getLength();
            }

            if (stackLength == 0)
            {
                return null;
            }
            else if (stackLength == 1)
            {
                return item;
            }
            else
            {
                return next.GetValue(stackLength - 1);
            }
        }

        // Explained in Stack class
        public override void Remove()
        {
            if (next == null || next.item == null)
            {
                item = null;
                return;
            }
            else
            {
                next.Remove();
            }
        }

        // Explained in Stack class
        public override void Clear()
        {
            if (next == null && item == null)
            {
                return;
            } else
            {
                item = null;
                if (next != null)
                {
                    next.Clear();
                }
            }
        }

        // Explained in Stack class
        public override int getLength(int count = 0)
        {
             if (item != null)
            {
                count++;

                if (next != null && next.item != null)
                {
                    return next.getLength(count);
                }
                else
                {
                    return count;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
