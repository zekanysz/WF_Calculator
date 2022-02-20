namespace WinFormsCalculator
{
    public partial class calcForm : Form
    {
        private string numberInput;
        private char op;
        private string operand1;
        private string operand2;

        public calcForm()
        {
            InitializeComponent();
            numberInput = "0";
            UpdateDisplay();
            op = ' ';
        }

        private void UpdateDisplay()
        {
            lbl_Display.Text = numberInput;
        }

        private void NumberInput_Click(object sender, EventArgs e)
        {
            if (numberInput == "0")
                numberInput = "";

            numberInput += ((Button)sender).Tag;
            UpdateDisplay();
        }

        private void btn_backSpace_Click(object sender, EventArgs e)
        {
            if (numberInput.Length > 1)
                numberInput = numberInput.Remove(numberInput.Length - 1, 1);
            else
                numberInput = "0";

            UpdateDisplay();
        }

        private void btn_dot_Click(object sender, EventArgs e)
        {
            if (!numberInput.Contains(","))
                numberInput += ((Button)sender).Tag;

            UpdateDisplay();
        }

        private void btn_polarity_Click(object sender, EventArgs e)
        {
            char firstChar = numberInput[0];

            if (!char.IsDigit(firstChar))
                numberInput = numberInput.Remove(0, 1);
            else
                if(lbl_Display.Text != "0")
                    numberInput = "-" + numberInput;

            UpdateDisplay();
        }

        private void Operator_Click(object sender, EventArgs e)
        {

            if (op == ' ')
            {
                op = ((string)(((Button)sender).Tag))[0];
                operand1 = numberInput;
                numberInput = "0";
            }
            else
            {
                operand2 = numberInput;
                double result = Calculate();
                lbl_Display.Text = result.ToString();
                operand1 = result.ToString();
                numberInput = "0";
            }
        }

        private double Calculate()
        {
            double op1 = Double.Parse(operand1);
            double op2 = Double.Parse(operand2);

            switch (op)
            {
                case '+':
                    return op1 + op2;

                case '-':
                    return op1 - op2;
            }

            return 0;
        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {

            if (op != ' ')
            {
                if (string.IsNullOrEmpty(operand2))
                    operand2 = numberInput;
                double result = Calculate();

                operand1 = numberInput = lbl_Display.Text = result.ToString();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            numberInput = "0";
            op = ' ';
            operand1 = "";
            operand1 = "";
            UpdateDisplay();
        }
    }
}