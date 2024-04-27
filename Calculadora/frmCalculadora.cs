namespace Calculadora
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class FrmCalculadora : Form
    {
        private bool isPositive = true;
        private double nFirstNumber = 0;
        private double nSecondNumber = 0;
        private double nResponse = 0;
        private char cOperator = '\0';
        private char cDecimalSeparator = (char)CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        // TODO:
        // - manejar los eventos de copiar y pegar
        // - manejar los errores si se copia letras u otro tipo de caracteres
        // - manejar diviosn entre 0
        // - extraer logica en otra capa para hacer el test
        // - añadir test unitarios con entradas de textoP

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
            this.btnDecimalSeparator.Text = this.cDecimalSeparator.ToString();
        }

        // Operadores aritméticos
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text) || this.nFirstNumber != 0)
            {
                this.setCursorTextboxEndline();
                return;
            }

            //float.TryParse(this.txtInput.Text, out this.nFirstNumber);
            this.cOperator = (char)OperatorType.Resta;
            this.handleOperatorClick();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text) || this.nFirstNumber != 0)
            {
                this.setCursorTextboxEndline();
                return;
            }

            //float.TryParse(this.txtInput.Text, out this.nFirstNumber);
            this.cOperator = (char)OperatorType.Division;
            this.handleOperatorClick();
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text) || this.nFirstNumber != 0)
            {
                this.setCursorTextboxEndline();
                return;
            }

            //float.TryParse(this.txtInput.Text, out this.nFirstNumber);
            this.cOperator = (char)OperatorType.Multiplicacion;
            this.handleOperatorClick();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text) || this.nFirstNumber != 0)
            {
                this.setCursorTextboxEndline();
                return;
            }

            //float.TryParse(this.txtInput.Text, out this.nFirstNumber);
            this.cOperator = (char)OperatorType.Suma;
            this.handleOperatorClick();
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
                this.setCursorTextboxEndline();
                return;
            }

            //float.TryParse(this.txtInput.Text, out this.nSecondNumber);
            this.nSecondNumber = double.Parse(this.txtInput.Text);

            switch (this.cOperator)
            {
                case (char)OperatorType.Suma:
                    this.nResponse = this.nFirstNumber + this.nSecondNumber;
                    break;
                case (char)OperatorType.Resta:
                    this.nResponse = this.nFirstNumber - this.nSecondNumber;
                    break;
                case (char)OperatorType.Multiplicacion:
                    this.nResponse = this.nFirstNumber * this.nSecondNumber;
                    break;
                case (char)OperatorType.Division:
                    this.nResponse = this.nFirstNumber / this.nSecondNumber;
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

        private void btnDecimalSeparator_Click(object sender, EventArgs e)
        {
            if (this.isInputFulledForDecimalSeparator() || this.isOneDecimalSeparator()) return;

            this.txtInput.Text += this.cDecimalSeparator;
            this.setCursorTextboxEndline();
        }

        // Números
        private void btnNum0_Click(object sender, EventArgs e)
        {
            if (this.isInputFulled()) return;
            if (this.txtInput.Text.IndexOf('0') > -1 && this.txtInput.Text.Length < 2) return;

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
            // si no es un número, ni separador decimal, ni tecla de control, ni tecla de operación aritmética
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != this.cDecimalSeparator
                && !this.isOperatorKey(e))
            {
                e.Handled = true;
            }

            // validación del separador decimal
            else if (e.KeyChar == this.cDecimalSeparator
                    && (this.isOneDecimalSeparator(sender, e)
                    || this.isInputFulledForDecimalSeparator()))
            {
                e.Handled = true;
            }

            // si se presiona ENTER
            else if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnEqual_Click(sender, e);
                e.Handled = true;
            }

            // si se presiona NUM 0
            else if (e.KeyChar == '0')
            {
                this.btnNum0_Click(sender, e);
                e.Handled = true;
            }

            // si se presiona un operador aritmético (+,-,*,/)
            else if (this.isOperatorKey(e))
            {
                switch (e.KeyChar)
                {
                    case (char)OperatorType.Suma:
                        this.cOperator = (char)OperatorType.Suma;
                        this.lblInput.Text = this.nFirstNumber.ToString() + ' ' + this.cOperator + ' ';
                        this.btnPlus_Click(sender, e);
                        break;
                    case (char)OperatorType.Resta:
                        this.cOperator = (char)OperatorType.Resta;
                        this.lblInput.Text = this.nFirstNumber.ToString() + ' ' + this.cOperator + ' ';
                        this.btnMinus_Click(sender, e);
                        break;
                    case (char)OperatorType.Multiplicacion:
                        this.cOperator = (char)OperatorType.Multiplicacion;
                        this.lblInput.Text = this.nFirstNumber.ToString() + ' ' + this.cOperator + ' ';
                        this.btnMulti_Click(sender, e);
                        break;
                    case (char)OperatorType.Division:
                        this.cOperator = (char)OperatorType.Division;
                        this.lblInput.Text = this.nFirstNumber.ToString() + ' ' + this.cOperator + ' ';
                        this.btnDiv_Click(sender, e);
                        break;
                }

                e.Handled = true;
            }
        }

        // Logic presentation methods
        private bool isNumber (KeyPressEventArgs e)
        {
            return !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private bool isOneDecimalSeparator (object sender, KeyPressEventArgs e)
        {
            return e.KeyChar == this.cDecimalSeparator && ((sender as TextBox).Text.IndexOf(this.cDecimalSeparator) > -1);
        }

        private bool isOneDecimalSeparator()
        {
            return this.txtInput.Text.IndexOf(this.cDecimalSeparator) > -1;
        }

        // Coloca el cursor del textbox al final del texto 
        private void setCursorTextboxEndline ()
        {
            this.txtInput.Select(this.txtInput.Text.Length, 0);
            this.txtInput.Focus();
        }

        // Secuencia comun para los eventos click de los operadores
        private void handleOperatorClick ()
        {
            this.nFirstNumber = double.Parse(this.txtInput.Text);
            this.lblInput.Text = this.nFirstNumber.ToString() + ' ' + this.cOperator + ' ';
            this.txtInput.Text = string.Empty;
            this.setCursorTextboxEndline();
        }

        // Comprueba si el input está lleno (para números)
        private bool isInputFulled ()
        {
            return this.txtInput.Text.Length > this.txtInput.MaxLength - 1;
        }

        // Comprueba si el input está a 1 carácter para llenar (para el punto)
        private bool isInputFulledForDecimalSeparator ()
        {
            Console.WriteLine(this.txtInput.MaxLength);
            return this.txtInput.Text.Length > this.txtInput.MaxLength - 2;
        }

        // Verifica si la tecla presionada es un operador aritmético (+,-,*,/)
        private bool isOperatorKey (KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)OperatorType.Suma) return true;
            if (e.KeyChar == (char)OperatorType.Resta) return true;
            if (e.KeyChar == (char)OperatorType.Multiplicacion) return true;
            if (e.KeyChar == (char)OperatorType.Division) return true;
            return false;
        }
    }
}
