using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace clsUtils
{
    public partial class NumericTextBox : UserControl
    {
        public NumericTextBox()
        {
            InitializeComponent();
            TextChanged += NumericTextBox_TextChanged;
        }

        void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
        }

        bool allowSpace = false;

        public string StringValue
        {
            get
            {
                return textBox1.Text;
            }
            set { this.textBox1.Text = value.ToString(); }
        }

        public int IntValue
        {
            get
            {
                return Int32.Parse(this.textBox1.Text == "" ? "0" : this.textBox1.Text);
            }
            set { this.textBox1.Text = value.ToString(); OnTextChanged(new EventArgs()); }
        }

        public decimal DecimalValue
        {
            get
            {
                return Decimal.Parse(this.textBox1.Text == "" ? "0" : this.textBox1.Text);
            }
            set { this.textBox1.Text = value.ToString(); OnTextChanged(new EventArgs()); }
        }

        public bool AllowSpace
        {
            set
            {
                this.allowSpace = value;
            }

            get
            {
                return this.allowSpace;
            }
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
         keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            else if (this.allowSpace && e.KeyChar == ' ')
            {

            }
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }
    }
}
