namespace Calculadora
{
    using System;
    using System.CodeDom;
    using System.Windows.Forms;

    public partial class FrmCalculadora : Form
    {
        private bool isPositive = true;
        private float nFirstNumber = 0;
        private float nSecondNumber = 0;
        private float nResponse = 0;
        private char cOperator = '\0';

        private enum OperatorType
        {
            Suma = '+',
            Resta = '-',
            Multiplicacion = '*',
            Division = '/',
        }

        public FrmCalculadora()
        {
            this.InitializeComponent();
        }

        // Operadores aritméticos
        private void btnMinus_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {

        }

        private void btnMulti_Click(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text) || this.nFirstNumber != 0)
            {
                setCursorTextboxEndline();
                return;
            }

            //float.TryParse(this.txtInput.Text, out this.nFirstNumber);
            this.nFirstNumber = float.Parse(this.txtInput.Text);
            this.cOperator = (char)OperatorType.Suma;

            this.lblInput.Text = this.nFirstNumber.ToString() + ' ' + this.cOperator + ' ';
            this.txtInput.Text = string.Empty;

            setCursorTextboxEndline();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {

        }

        private void btnSquare_Click(object sender, EventArgs e)
        {

        }

        // Operadores no aritméticos
        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text) || this.nFirstNumber == 0)
            {
                setCursorTextboxEndline();
                return;
            }

            //float.TryParse(this.txtInput.Text, out this.nSecondNumber);
            this.nSecondNumber = float.Parse(this.txtInput.Text);

            switch (this.cOperator)
            {
                case (char)OperatorType.Suma:
                    this.nResponse = this.nFirstNumber + this.nSecondNumber;
                    break;
            }

            this.lblInput.Text += this.nSecondNumber.ToString() + " = ";
            this.txtInput.Text = this.nResponse.ToString();
            this.nFirstNumber = 0;
            this.setCursorTextboxEndline();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtInput.Text = string.Empty;
            this.txtInput.Focus();
            this.isPositive = true;
            this.nFirstNumber = 0;
            this.nSecondNumber = 0;
            this.nResponse = 0;
            this.cOperator = '\0';
            this.lblInput.Text = '0'.ToString();
        }
        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text)) return;

            string sInput = this.txtInput.Text;
            this.txtInput.Text = this.isPositive == true ? '-' + sInput : sInput.Replace('-'.ToString(), string.Empty);
            this.isPositive = !this.isPositive;

            this.setCursorTextboxEndline();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            if (this.isInputFulledForDash() || this.isOneDash()) return;

            this.txtInput.Text += ".";
            this.setCursorTextboxEndline();
        }

        // Números
        private void btnNum0_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled() || this.txtInput.Text.IndexOf('0') > -1) return;

            this.txtInput.Text += "0";
            this.setCursorTextboxEndline();
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "1";
            this.setCursorTextboxEndline();
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "2";
            this.setCursorTextboxEndline();
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "3";
            this.setCursorTextboxEndline();
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "4";
            this.setCursorTextboxEndline();
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "5";
            this.setCursorTextboxEndline();
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "6";
            this.setCursorTextboxEndline();
        }
        private void btnNum7_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "7";
            this.setCursorTextboxEndline();
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "8";
            this.setCursorTextboxEndline();
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;

            this.txtInput.Text += "9";
            this.setCursorTextboxEndline();
        }

        // KeyPres events
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // acepta solo números y decimales
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            else if (e.KeyChar == '.' && (this.isOneDash(sender, e) || this.isInputFulledForDash())) e.Handled = true;
        }

        // Logic presentation methods
        private bool isNumber (KeyPressEventArgs e)
        {
            return (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private bool isOneDash (object sender, KeyPressEventArgs e)
        {
            return e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1);
        }

        private bool isOneDash ()
        {
            return this.txtInput.Text.IndexOf('.') > -1;
        }

        // Coloca el cursor del textbox al final del texto 
        private void setCursorTextboxEndline ()
        {
            this.txtInput.Select(this.txtInput.Text.Length, 0);
            this.txtInput.Focus();
        }

        // Comprueba si el input está lleno (para números)
        private bool isInputFulled ()
        {
            return this.txtInput.Text.Length > this.txtInput.MaxLength - 1;
        }

        // Comprueba si el input está a 1 carácter para llenar (para el punto)
        private bool isInputFulledForDash ()
        {
            Console.WriteLine(this.txtInput.MaxLength);
            return this.txtInput.Text.Length > this.txtInput.MaxLength - 2;
        }
    }
}
