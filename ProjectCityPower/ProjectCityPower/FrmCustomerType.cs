
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
namespace ProjectCityPower
{
    
    public partial class FrmCustomerType : Form
    {

        CustomerDataLibrary.CICustomerType CIC = new CICustomerType();

        public FrmCustomerType()

        {
            InitializeComponent();
        }
       
        private void FrmCustomerType_Load(object sender, EventArgs e)
        {
            //CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-
            //ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(252, 372));
            listView1.View = View.Details;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            // Create three customer types.
            ListViewItem item1 = new ListViewItem(CIC.Type1, 0);
            ListViewItem item2 = new ListViewItem(CIC.Type2, 0);
            ListViewItem item3 = new ListViewItem(CIC.Type3, 0);
            listView1.Columns.Add("Customer Type", -2, HorizontalAlignment.Left);
            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            this.Controls.Add(listView1);
            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
                listView1.Select();
            }

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectData();
            }
        }

        void selectData()
        {
           
            CIC.TypeCt(listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text);
            this.Close();
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //Call function for select Customer Type from Listview
            selectData();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-