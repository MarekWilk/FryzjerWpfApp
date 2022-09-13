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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FryzjerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uslugiBtn_Click(object sender, RoutedEventArgs e)
        {
            
            UslugiWindow uw = new UslugiWindow();
            uw.ShowDialog();
        }

        private void klienciBtn_Click(object sender, RoutedEventArgs e)
        {
            KlienciWindow kw = new KlienciWindow();
            kw.ShowDialog();
        }

        private void pracownicyBtn_Click(object sender, RoutedEventArgs e)
        {
            PracownicyWindow pw = new PracownicyWindow();
            pw.ShowDialog();
        }

        private void wizytyBtn_Click(object sender, RoutedEventArgs e)
        {
            WizytyWindow ww = new WizytyWindow();
            ww.ShowDialog();
        }
    }
}
