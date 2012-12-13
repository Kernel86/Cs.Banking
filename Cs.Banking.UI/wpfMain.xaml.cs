/*************************
 * [wpfMain.xaml.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-11-29
 *************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Cs.Banking.Business;

namespace Cs.Banking.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CCustomers oCustomers;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Create a new Customers class, populate it and display it
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                oCustomers = new CCustomers();
                //oCustomers.Populate(); // CStatic
                //oCustomers.Load(); // CXml
                //oCustomers.CommitFlat();
                oCustomers.GetData(); // CSQLServer
                oCustomers.CustomersChanged += new EventHandler(oCustomers_CustomersChanged);

                lstCustomers.ItemsSource = oCustomers.Items;
                lstCustomers.DisplayMemberPath = "FullName";
                lstCustomers.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //oCustomers.Save();

            oCustomers = null;
        }

        // Quit application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            // Show Abut dialog
            dlgAbout wpfAbout = new dlgAbout();
            wpfAbout.ShowDialog();
            wpfAbout = null;
        }

        // Update DataGrids and TextBoxes on seleciton change
        private void lstCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCustomers.SelectedIndex >= 0)
            {
                btnAdd.Content = "Save";

                txtFirstName.Text = oCustomers.Items[lstCustomers.SelectedIndex].FirstName;
                txtLastName.Text = oCustomers.Items[lstCustomers.SelectedIndex].LastName;
                txtSSN.Text = oCustomers.Items[lstCustomers.SelectedIndex].SSN;
                txtId.Text = oCustomers.Items[lstCustomers.SelectedIndex].CustomerId.ToString();
                txtBirthDate.Text = oCustomers.Items[lstCustomers.SelectedIndex].BirthDate.ToShortDateString();

                dgDeposits.ItemsSource = oCustomers.Items[lstCustomers.SelectedIndex].DepositList;
                dgWithdrawals.ItemsSource = oCustomers.Items[lstCustomers.SelectedIndex].WithdrawalList;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtSSN.Clear();
            txtBirthDate.Clear();

            btnAdd.Content = "Add";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dtBirthdate;

                if (txtFirstName.Text.Length > 0 &&
                    txtLastName.Text.Length > 0 &&
                    DateTime.TryParse(txtBirthDate.Text, out dtBirthdate) &&
                    txtSSN.Text.Length > 0)
                {
                    if (btnAdd.Content.ToString() == "Add")
                    {
                        CCustomer oNewCustomer = new CCustomer(lstCustomers.Items.Count + 1, txtSSN.Text, txtFirstName.Text, txtLastName.Text, dtBirthdate, lstCustomers.Items.Count + 1);
                        oNewCustomer.Insert();
                        oCustomers.Add(oNewCustomer);
                    }
                    else
                    {
                        oCustomers.Items[lstCustomers.SelectedIndex].FirstName = txtFirstName.Text;
                        oCustomers.Items[lstCustomers.SelectedIndex].LastName = txtLastName.Text;
                        oCustomers.Items[lstCustomers.SelectedIndex].SSN = txtSSN.Text;
                        oCustomers.Items[lstCustomers.SelectedIndex].BirthDate = dtBirthdate;

                        oCustomers.Items[lstCustomers.SelectedIndex].Update();

                        oCustomers_CustomersChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            oCustomers.Items[lstCustomers.SelectedIndex].Delete();
            oCustomers.RemoveAt(lstCustomers.SelectedIndex);
            btnClear_Click(sender, e);
        }

        private void oCustomers_CustomersChanged(object sender, EventArgs e)
        {
            lstCustomers.ItemsSource = null;
            lstCustomers.ItemsSource = oCustomers.Items;
        }
    }
}
