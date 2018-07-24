using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Handles all button clicks and calculates
    /// </summary>
    class CalculatorsMind
    {
        // Create stacks
        ArrayStack arrayStack = new ArrayStack(50);
        ListStack listStack = new ListStack();
        MyListStack myListStack = new MyListStack();

        // Input label to get value from
        public Label labelInput;

        // Current selected stack, starts with ArrayStack
        string array = "ArrayStack";

        // List to fill, and set in listBoxOutput with UpdateListBox
        public List<double?> listBoxValues = new List<double?>();
        public ListBox listBoxOutput;
        public double? lastResult;

        /// <summary>
        /// Handels every click on a value button 1-9, (-), etc
        /// </summary>
        /// <param name="value"></param>
        public void Value(string value)
        {
            string currentInput = labelInput.Text;
            
            // Max input length
            if (currentInput.Length == 20)
            {
                return;
            }

            // Add value to input
            if (value == "(-)")
            {
                // Check if already minus
                if (currentInput == "")
                {
                    labelInput.Text = "-";
                }
                else if (currentInput[0] != '-')
                {
                    labelInput.Text = "-" + currentInput;
                }
            }
            else if (value == ".")
            {
                // Check if already dot
                if (currentInput != "" && currentInput[currentInput.Length-1] != '.') {
                    labelInput.Text = currentInput + value;
                }
            } else { 
                labelInput.Text = currentInput + value;
            }
        }

        /// <summary>
        /// Adds value to the current stack
        /// </summary>
        public void AddToStack(bool getLastResult = false)
        {
            double input;
            if (getLastResult)
            {
                // Get last calculated value
                input = lastResult.GetValueOrDefault();
            } else
            {
                string currentInput = labelInput.Text;
                bool successfullyParsed = double.TryParse(currentInput, out input);

                // Check if set value is valid
                if (currentInput == "" || !successfullyParsed)
                {
                    return;
                }
            }

            // Add value to listbox and update it
            listBoxValues.Add(input);
            UpdateListBox();

            // Add to stack
            switch (array)
            {
                case "ArrayStack":
                    arrayStack.Add(input);
                    break;
                case "ListStack":
                    listStack.Add(input);
                    break;
                case "MyListStack":
                    myListStack.Add(input);
                    break;
                default:
                    break;
            }

            // Clear input field
            labelInput.Text = "";
        }

        /// <summary>
        /// Removes the last item from current stack
        /// </summary>
        public void RemoveFromStack()
        {
            switch (array)
            {
                case "ArrayStack":
                    arrayStack.Remove();
                    break;
                case "ListStack":
                    listStack.Remove();
                    break;
                case "MyListStack":
                    myListStack.Remove();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Clears current stack and adds everyitem to new stack
        /// </summary>
        /// <param name="radioButton"></param>
        public void SwitchStack(RadioButton radioButton)
        {
            switch (array)
            {
                case "ArrayStack":
                    arrayStack.Clear();
                    break;
                case "ListStack":
                    listStack.Clear();
                    break;
                case "MyListStack":
                    myListStack.Clear();
                    break;
                default:
                    break;
            }

            if (radioButton.Checked)
            {              
                // Set new value to array
                array = radioButton.Text;

                // Fill stack with list
                switch (array)
                {
                    case "ArrayStack":
                        foreach (double item in listBoxValues)
                        {
                            arrayStack.Add(item);
                        }
                        break;
                    case "ListStack":
                        foreach (double item in listBoxValues)
                        {
                            listStack.Add(item);
                        }
                        break;
                    case "MyListStack":
                        foreach (double item in listBoxValues)
                        {
                            myListStack.Add(item);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Calculates last 2 values from stack and adds result to stack
        /// </summary>
        /// <param name="value"></param>
        public void Operator(string value)
        {
            int listBoxCount = listBoxValues.Count;
            if (listBoxCount >= 2)
            {
                // doubles used in calculation
                double? a, b;
                switch (array)
                {
                    case "ArrayStack":
                        b = arrayStack.GetValue();
                        arrayStack.Remove();
                        a = arrayStack.GetValue();
                        arrayStack.Remove();
                        break;
                    case "ListStack":
                        b = listStack.GetValue();
                        listStack.Remove();
                        a = listStack.GetValue();
                        listStack.Remove();
                        break;
                    case "MyListStack":
                        b = myListStack.GetValue();
                        System.Windows.Forms.MessageBox.Show("b - " + b.ToString());
                        a = myListStack.GetValue();
                        System.Windows.Forms.MessageBox.Show("a - " + a.ToString());
                        myListStack.Remove();
                        myListStack.Remove();
                        break;
                    default:
                        a = 1;
                        b = 1;
                        break;
                }

                switch (value)
                {
                    case "/":
                        lastResult = a / b;
                        break;
                    case "*":
                        lastResult = a * b;
                        break;
                    case "-":
                        lastResult = a - b;
                        break;
                    case "+":
                        lastResult = a + b;
                        break;
                    default:
                        lastResult = 0;
                        break;
                }

                // Remove last to values from list
                listBoxValues.RemoveAt(listBoxCount - 1);
                listBoxValues.RemoveAt(listBoxCount - 2);
                AddToStack(true);
            }
        }

        /// <summary>
        /// Updates all list items in listbox
        /// </summary>
        /// <param name="items"></param>
        public void UpdateListBox()
        {
            listBoxOutput.Items.Clear();

            listBoxValues.Reverse();

            foreach (double? item in listBoxValues)
            {
                listBoxOutput.Items.Add(item);
            }

            listBoxValues.Reverse();
        }
    }
}
