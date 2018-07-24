using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Initializes all the buttons and setup for all the button triggers
    /// </summary>
    public partial class Calculator : Form
    {
        CalculatorsMind calculatorsMind = new CalculatorsMind();

        /// <summary>
        /// Call all needed functions needed 
        /// </summary>
        public Calculator()
        {
            InitializeComponent();

            int startLocationX = 50;
            int startLocationY = 40;

            // Setup all buttons, function to setup radio buttons gets call in setupOperatorButtons
            setupInputLabel(startLocationX, startLocationY);
            setupValueButtons(startLocationX, startLocationY + 10);
            setupOperatorButtons(startLocationX + 290, startLocationY + 60);
            setupOutputListBox(startLocationX + 400, startLocationY);
        }

        /// <summary>
        /// Create label, add to form and set lable 
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void setupInputLabel(int locationX, int locationY)
        {
            // Set input label and add to form
            Label inputLabel = new Label();
            inputLabel.Name = "labelInput";
            inputLabel.TextAlign = ContentAlignment.MiddleRight;
            inputLabel.Width = 275;
            inputLabel.Height = 30;
            inputLabel.Location = new Point(locationX, locationY);
            inputLabel.BackColor = Color.Black;
            inputLabel.ForeColor = Color.White;
            this.Controls.Add(inputLabel);

            // Set label calculatorsMind
            calculatorsMind.labelInput = inputLabel;

            // Create calculate button
            Button AddToStack = new Button();
            AddToStack.Name = "buttonAddToStack";
            AddToStack.Text = ">";
            AddToStack.Width = 25;
            AddToStack.Height = 25;
            AddToStack.Location = new Point(locationX + 280, locationY);
            AddToStack.BackColor = Color.White;
            AddToStack.Click += (s, e) => {
                calculatorsMind.AddToStack();
                //calculatorsMind.UpdateListBox();
            };
            this.Controls.Add(AddToStack);
        }

        /// <summary>
        /// Adds value buttons to calculator
        /// </summary>
        /// <param name="startingLocationX"></param>
        /// <param name="startingLocationY"></param>
        public void setupValueButtons(int startingLocationX, int startingLocationY)
        {
            // Set array with buttons values
            String[] valueButtons = new string[] { "7", "8", "9", "4", "5", "6", "1", "2", "3", "(-)", "0", "." };
            int i = 0;

            int locationX = startingLocationX;
            int locationY = startingLocationY;

            foreach (string valueButton in valueButtons)
            {
                // Determine location, max 3 buttons besides eachother
                if (i % 3 == 0)
                {
                    locationX = startingLocationX;
                    locationY += 50;
                }

                // Create new button and set properties
                Button newButton = new Button();
                newButton.Name = "buttonValue" + valueButton;
                newButton.Text = valueButton;
                newButton.Location = new Point(locationX, locationY);
                newButton.BackColor = Color.White;
                newButton.Click += (s, e) => { calculatorsMind.Value((s as Button).Text); };
                this.Controls.Add(newButton);

                i++;
                locationX += 100;
            }
        }

        /// <summary>
        /// Adds operator butons to calculator
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void setupOperatorButtons(int locationX, int locationY)
        {
            String[] operatorButtons = new string[] { "/", "*", "-", "+" };

            foreach (string button in operatorButtons)
            {
                Button operatorButton = new Button();
                operatorButton.Name = "buttonCalculate" + button;
                operatorButton.Text = button;
                operatorButton.Width = 50;
                operatorButton.Height = 25;
                operatorButton.BackColor = Color.DarkGray;
                operatorButton.Location = new Point(locationX, locationY);
                operatorButton.Click += (s, e) => { calculatorsMind.Operator((s as Button).Text); };
                this.Controls.Add(operatorButton);
                locationY += 50;
            }

            setupRadioButtons(locationX, locationY - 10);
        }

        /// <summary>
        /// Adds radio buttons to calculator for stack options
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void setupRadioButtons(int locationX, int locationY)
        {
            string[] radioButtons = new string[] { "ArrayStack", "ListStack", "MyListStack"};

            foreach (string radioButton in radioButtons)
            {
                RadioButton newRadioButton = new RadioButton();
                if (radioButton == "ArrayStack")
                {
                    newRadioButton.Checked = true;
                }
                newRadioButton.Name = "radio" + radioButton;
                newRadioButton.Text = radioButton;
                newRadioButton.Location = new Point(locationX, locationY);
                newRadioButton.CheckedChanged += (s, e) => { calculatorsMind.SwitchStack(s as RadioButton); };
                this.Controls.Add(newRadioButton);

                locationY += 25;
            }
        }

        /// <summary>
        /// Adds ListBox to calculator for stack display
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void setupOutputListBox(int locationX, int locationY)
        {
            ListBox listBox = new ListBox();
            listBox.Name = "listBoxOutput";
            listBox.Height = 350;
            listBox.Width = 200;
            listBox.Location = new Point(locationX, locationY);
            this.Controls.Add(listBox);
            calculatorsMind.listBoxOutput = listBox;
        }
    }
}

