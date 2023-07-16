using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private TextBox displayTextBox;
        private double total;
        private double currentNumber;
        private char lastOperator;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Create the display TextBox
            displayTextBox = new TextBox();
            displayTextBox.Location = new System.Drawing.Point(10, 10);
            displayTextBox.Size = new System.Drawing.Size(230, 30);
            displayTextBox.ReadOnly = true;
            displayTextBox.TextAlign = HorizontalAlignment.Right;
            this.Controls.Add(displayTextBox);

            // Create the digit buttons (0 to 9)
            for (int i = 0; i <= 9; i++)
            {
                int row = (9 - i) / 3;
                int column = (9 - i) % 3;
                Button digitButton = new Button();
                digitButton.Text = i.ToString();
                digitButton.Location = new System.Drawing.Point(10 + column * 60, 50 + row * 60);
                digitButton.Size = new System.Drawing.Size(50, 50);
                digitButton.Click += digitButton_Click;
                this.Controls.Add(digitButton);
            }

            // Create the operator buttons
            char[] operators = { '+', '-', '*', '/' };
            int operatorColumn = 3;
            for (int i = 0; i < operators.Length; i++)
            {
                Button operatorButton = new Button();
                operatorButton.Text = operators[i].ToString();
                operatorButton.Location = new System.Drawing.Point(190, 50 + i * 60);
                operatorButton.Size = new System.Drawing.Size(50, 50);
                operatorButton.Click += operatorButton_Click;
                this.Controls.Add(operatorButton);
            }

            // Create the equal button
            Button equalButton = new Button();
            equalButton.Text = "=";
            equalButton.Location = new System.Drawing.Point(130, 230);
            equalButton.Size = new System.Drawing.Size(50, 50);
            equalButton.Click += equalButton_Click;
            this.Controls.Add(equalButton);

            // Create the clear button
            Button clearButton = new Button();
            clearButton.Text = "C";
            clearButton.Location = new System.Drawing.Point(70, 230);
            clearButton.Size = new System.Drawing.Size(50, 50);
            clearButton.Click += clearButton_Click;
            this.Controls.Add(clearButton);
        }

        private void digitButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            displayTextBox.Text += button.Text;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (double.TryParse(displayTextBox.Text, out currentNumber))
            {
                if (lastOperator == '+')
                    total += currentNumber;
                else if (lastOperator == '-')
                    total -= currentNumber;
                else if (lastOperator == '*')
                    total *= currentNumber;
                else if (lastOperator == '/')
                    total /= currentNumber;
                else
                    total = currentNumber;
            }

            lastOperator = Convert.ToChar(button.Text);
            displayTextBox.Text = "";
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(displayTextBox.Text, out currentNumber))
            {
                if (lastOperator == '+')
                    total += currentNumber;
                else if (lastOperator == '-')
                    total -= currentNumber;
                else if (lastOperator == '*')
                    total *= currentNumber;
                else if (lastOperator == '/')
                    total /= currentNumber;
                else
                    total = currentNumber;
            }

            displayTextBox.Text = total.ToString();
            total = 0;
            lastOperator = '\0';
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            displayTextBox.Text = "";
            total = 0;
            lastOperator = '\0';
        }
    }
}
