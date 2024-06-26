using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Salary_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.clear();
            txt_in1.Focus();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void clear()
        {
            txt_in1.Clear();
            txt_inp3.Clear();
            lv_Calc.Items.Clear();

        }

        private void txt_in1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_Error.Visible = false; lv_Calc.Items.Clear();
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txt_in1.Text == "")
                {
                    txt_Error.Visible = true;
                    txt_Error.Text = "Hours must be filled out";
                    txt_in1.Focus();
                }
                else
                {
                    txt_inp3.Focus(); txt_inp3.SelectAll();
                }



            }
        }

        private void txt_in1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_inp3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_inp3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            double othrs = 0; double rghrs = 0; lv_Calc.Items.Clear();
            txt_Error.Visible = false;
            if (e.KeyChar == (char)13)
            {
                //lbl_error.Text = string.Empty;

                if (txt_inp3.Text == "")
                {
                    txt_Error.Visible = true;
                    txt_Error.Text = "Rate must be filled out";
                }
                else
                {
                    rghrs = Math.Abs(Convert.ToDouble(txt_in1.Text));
                    ListViewItem lv1 = new ListViewItem(txt_in1.Text);

                    if (rghrs > 37.5)
                    {
                        othrs = Math.Abs(rghrs - 37.5);
                        rghrs = Math.Abs(rghrs - othrs);
                    }
                    Classes.cls_function.Calculations(othrs.ToString(), txt_inp3.Text, rghrs.ToString());
                    lv1.SubItems.Add(othrs.ToString());
                    lv1.SubItems.Add(txt_inp3.Text);
                    lv1.SubItems.Add("$" + " " + Classes.cls_function.stpay.ToString());
                    lv1.SubItems.Add("$" + " " + Classes.cls_function.otpay.ToString());
                    lv1.SubItems.Add("$" + " " + Classes.cls_function.totpay.ToString());
                    lv_Calc.Items.Add(lv1);
                    txt_in1.Focus(); txt_in1.SelectAll();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_Error.Visible = false;
        }
    }
}

