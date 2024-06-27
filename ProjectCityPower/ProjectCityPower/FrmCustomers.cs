//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerDataLibrary;
using System.IO;
namespace ProjectCityPower
{
    public partial class FrmCustomers : Form
    {
        List<string> list = new List<string>();
        ClCustomer _cust= new ClCustomer(); 

        ClCustomer.Connection _con = new ClCustomer.Connection(Directory.GetCurrentDirectory(), @"\\customer_records.txt");
        
        ClCustomer.ResidentialCustomer _crc = new ClCustomer.ResidentialCustomer();
        ClCustomer.CommercialCustomer _ccc = new ClCustomer.CommercialCustomer();
        ClCustomer.IndustrialCustomer _cic = new ClCustomer.IndustrialCustomer();
        CICustomerType ObjCType = new CICustomerType();

        public FrmCustomers()
        {
            InitializeComponent();
        }
        DataRow dr;
        void ClearText()
        {
            txtAccountNo.Text = "";
            txtCustomerName.Text = "";
            txtCustomerType.Text = "Press F5";
            txtCharge.Text = "";

        }
        private bool CustomerTypeTrue(string Type)
        {
            if (ObjCType.Type1 == Type  || ObjCType.Type2 == Type || ObjCType.Type3 == Type)
            {
                return true;
            }
            return false;

        }
        private void btn_Calc_Click(object sender, EventArgs e)
          {
            if (txtAccountNo.Text.Length > 0 && txtCharge.Text.Length > 0 && txtCustomerName.Text.Length > 0 && (CustomerTypeTrue(txtCustomerType.Text) == true))
            {
                using (StreamWriter stream = new FileInfo(_con.fullpath).AppendText())//ur file location//.AppendText())
                {
                    stream.WriteLine(txtAccountNo.Text + ", " + ClCustomer.Capitalize(txtCustomerName.Text.Trim()) + "," + txtCustomerType.Text[0] + "," + txtCharge.Text);//display textbox data in notepad
                }
                DisTranswe();
                ClearText();
                txtAccountNo.Focus();
            }
          
          }

        void Connection()
        {
            if (!File.Exists(_con.fullpath))
            {
                File.Create(_con.fullpath).Dispose();
            }
        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
             
            foreach (String str in listBox1.Items)
            {
                list.Add(str);
            }

            Connection();
            this.ActiveControl = txtAccountNo;
            DisTranswe();
        }

        //public long CountLinesLINQ(FileInfo file)
        //        => File.ReadLines(file.FullName).Count();

     
        public void DisTranswe()
        {
            DataTable dataTable1 = new DataTable();
            dataTable1.Columns.Add("Account No:", typeof(string));
            dataTable1.Columns.Add("Name", typeof(string));
            dataTable1.Columns.Add("Type", typeof(string));
            dataTable1.Columns.Add("Amount", typeof(string));

            string line = null;
            FileStream fs = new FileStream(_con.fullpath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            ClCustomer _cust = new ClCustomer();

            try
            {

                while ((line = sr.ReadLine()) != null)
                {
                string[] data = line.Split(',');
                dr = dataTable1.NewRow();
                dr["Account No:"] = data[0];
                dr["Name"] = data[1];
                switch (data[2])
                {
                    case "R":
                        dr["Type"] = "Residential";
                         _crc.ResCustomer (double.Parse(data[3]));
                        break;
                    case "C":
                        dr["Type"] = "Commerical";
                        _ccc.ComCustomer(double.Parse(data[3]));
                        break;
                    case "I":
                        dr["Type"] = "Industrial";
                         _cic.IndCustomer(double.Parse(data[3]));
                        break;
                }
                dr["Amount"] = "$ " + data[3];
                dataTable1.Rows.Add(dr);
                    _cust.customercount(); 
                }
                dataTable1.Rows.Add(new Object[]{
                "","","",""});
                dataTable1.Rows.Add(new Object[]{
                "Total Customers",
                 _cust.cuscount,
                "Residential Total",
                "$ "+_crc.rsum.ToString("N2")
            });
            
                dataTable1.Rows.Add(new Object[]{"",
                "","Commercial Total",
              "$ "+_ccc.csum.ToString("N2")
           });
                dataTable1.Rows.Add(new Object[]{"",
                "","Industrial Total",
                "$ "+_cic.isum.ToString("N2")
           });
                dataTable1.Rows.Add(new Object[]{"",
                "","Total Amount",
                "$ "+ _cust.TotAmount(_crc.rsum, _ccc.csum, _cic.isum)
            });
              
               
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Error","Incorrect Number",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgv_1.DataSource = new BindingSource(dataTable1, null);
            dgv_1.CurrentCell = dgv_1.Rows[dgv_1.Rows.Count - 1].Cells[0];
            dgv_1.Rows[dgv_1.Rows.Count - 1].Selected = true;
            this.dgv_1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_1.Columns["Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            sr.Close();
            fs.Close();
        }

        private void txtAccountNo_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                txtCustomerName.Focus();
                txtCustomerName.SelectAll();
            }

        }

            private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 13)
                {
                    txtCustomerType.Focus();
                    txtCustomerType.SelectAll();
                }

            }

      

        private void txtCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_Calc_Click(sender, e);
            }
        }


       
        private bool IsNumeric(string strText)
        {
            try
            {
                int test = int.Parse(strText);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
      

        private void txtCustomerName_Validating(object sender, CancelEventArgs e)
        {
            //if (txtCustomerName.Text.Trim().Length == 0)
            //{
            //    e.Cancel = true;
            //    errorProvider1.SetError(txtCustomerName, "Please enter the customer name.");
            //}
            //else
            //    errorProvider1.SetError(txtCustomerName, "");
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
            
        }
    
        private void txtCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FrmCustomerType FCT = new FrmCustomerType();
                FCT.ShowDialog(); // Shows Form2
                txtCustomerType.Text = ObjCType.CType;
                txtCustomerType.Focus();
                txtCustomerType.SelectAll();
            }
            else if (e.KeyCode == Keys.Enter)
            {

                txtCharge.Focus();
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }




        private void dgv_1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgv_1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtAccountNo.Text = row.Cells[0].Value.ToString();
                txtCustomerName.Text = row.Cells[1].Value.ToString();
                txtCustomerType.Text = row.Cells[2].Value.ToString();
                txtCharge.Text = row.Cells[3].Value.ToString();

            }
        }
        private void FindAllOfMyString(string searchString)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    listBox1.SetSelected(i, true);
                    
                }
                else
                {
                    // Do this if you want to select in the ListBox only the results of the latest search.
                    listBox1.SetSelected(i, false);
                }
            }
        }
     

        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNumeric(txtAccountNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAccountNo, "Please enter the account number, as a whole number.");
            }
            else
                errorProvider1.SetError(txtAccountNo, "");
        }

        private void FrmCustomers_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCustomerType FCT = new FrmCustomerType();
            FCT.ShowDialog(); // Shows Form2
            txtCustomerType.Text = ObjCType.CType;
            txtCustomerType.Focus();
            txtCustomerType.SelectAll();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
  }
//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-
