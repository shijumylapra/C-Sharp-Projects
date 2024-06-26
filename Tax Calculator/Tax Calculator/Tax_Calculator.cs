using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax_Calculator
{
    public partial class Tax_Calculator : Form
    {
        double BasicTax;
        double ExcessTax;
        double ExcessAmt;
        public Tax_Calculator()
        {
            InitializeComponent();
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            double[,] a = new double[5, 4] { { 0, 14999.99, 0, .15 }, { 15000.00, 29999.99, 2250, .18 }, { 30000.00, 49999.99, 4950, .22 }, { 50000.00, 79999.99, 9350, .27 }, { 80000.00, 5000000000.00, 17450, .33 } };
            try
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (cls_tax.IsWithin(Convert.ToDouble(txt_salary.Text), a[i, 0], a[i, 1]) == true)
                    {
                        BasicTax = a[i, 2];
                        txt_basictax.Text = BasicTax.ToString("N2");
                        txt_exper.Text = a[i, 3].ToString() + "%";
                        ExcessAmt = Convert.ToDouble(txt_salary.Text) - a[i, 0];
                        ExcessTax = (ExcessAmt * a[i, 3]);
                        txt_examt.Text = ExcessTax.ToString("N2");
                        txt_total.Text = (BasicTax + ExcessTax).ToString("N2");
                        txt_net.Text = (Convert.ToDouble(txt_salary.Text) - Convert.ToDouble(txt_total.Text)).ToString("N2");
                        goto LBreak;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message: " + ex.Message);
                txt_salary.SelectAll(); txt_salary.Focus();
            }

        LBreak:;
        }
        void clear()
        {
            txt_basictax.Clear();
            txt_examt.Clear();
            txt_exper.Clear();
            txt_net.Clear();
            txt_total.Clear();

        }
        private void Tax_Calculator_Load(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_salary_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            clear();
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_calc_Click(null, null);
            }
        }
    }
}
