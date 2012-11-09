/*************************
 * [wpfMain.xaml.cs]
 * C# Intermediate
 * Shawn Novak
 * 2012-11-08
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
                oCustomers.Populate();

                lstCustomers.ItemsSource = oCustomers.Items;
                lstCustomers.DisplayMemberPath = "FullName";
                lstCustomers.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            txtFirstName.Text = oCustomers.Items[lstCustomers.SelectedIndex].FirstName;
            txtLastName.Text = oCustomers.Items[lstCustomers.SelectedIndex].LastName;
            txtSSN.Text = oCustomers.Items[lstCustomers.SelectedIndex].SSN;
            txtId.Text = oCustomers.Items[lstCustomers.SelectedIndex].Id.ToString();
            txtBirthDate.Text = oCustomers.Items[lstCustomers.SelectedIndex].BirthDate.ToShortDateString();

            dgDeposits.ItemsSource = oCustomers.Items[lstCustomers.SelectedIndex].DepositList;
            dgWithdrawals.ItemsSource = oCustomers.Items[lstCustomers.SelectedIndex].WithdrawalList;
        }
    }
}
