using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CollectionCrudOperations.Models;

namespace CollectionCrudOperations
{
    public partial class frmCustomers : Form
    {
        List<Customer> customersCollection = new List<Customer>();
        int currentIndex = 0;
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            Navigation(currentIndex);
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            Navigation(currentIndex);
        }
        private void Navigation(int index)
        {
            if (customersCollection.Count>0)
            {
                txtCustomerId.Text = customersCollection[index].CustomerId.ToString();
                txtContactName.Text = customersCollection[index].ContactName;
                txtCity.Text = customersCollection[index].City;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCustomerId.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCustomerId.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer newCustomer = new Customer()
            {
                CustomerId=int.Parse(txtCustomerId.Text),
                ContactName=txtContactName.Text,
                City=txtCity.Text
            };
            customersCollection.Add(newCustomer);
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            currentIndex = customersCollection.Count-1;
            Navigation(currentIndex);
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex>0)
            {
                currentIndex--;
                Navigation(currentIndex);
            }
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            if (currentIndex<customersCollection.Count-1)
            {
                currentIndex++;
                Navigation(currentIndex);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            customersCollection[currentIndex].ContactName = txtContactName.Text;
            customersCollection[currentIndex].City = txtCity.Text;
        }
    }
}
