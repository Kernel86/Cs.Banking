/*************************
 * [dlgAbout.xaml.cs]
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
using System.Windows.Shapes;

namespace Cs.Banking.UI
{
    /// <summary>
    /// Interaction logic for dlgAbout.xaml
    /// </summary>
    public partial class dlgAbout : Window
    {
        public dlgAbout()
        {
            InitializeComponent();

            // Set assignment information
            lblAssignment.Text = "C# Intermediate - Project 4 - Banking";
            lblDate.Text = "2012-11-08";
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
