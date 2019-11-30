using Fiszki.Class;
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

namespace Fiszki
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlListWords.xaml
    /// </summary>
    public partial class UserControlListWords : UserControl
    {
        public UserControlListWords()
        {
            InitializeComponent();
            DatabaseOperation.FindWord(DataGridWordsList, TextBoxFind.Text);
        }

        private void TextBoxFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            DatabaseOperation.FindWord(DataGridWordsList, TextBoxFind.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatabaseOperation.DeleteWord(DataGridWordsList);
            DatabaseOperation.ViewWordsList(DataGridWordsList);
        }
    }
}
