using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Book_Shop
{
    /// <summary>
    /// Interaction logic for ConDeleteLanguageWin.xaml
    /// </summary>
    public partial class ConDeleteLanguageWin : Window
    {
        public ConDeleteLanguageWin()
        {
            InitializeComponent();
        }

        private void Clic_Ok(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clic_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
