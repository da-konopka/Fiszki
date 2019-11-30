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
    /// Logika interakcji dla klasy UserControlAddWord.xaml
    /// </summary>
    public partial class UserControlAddWord : UserControl
    {
        public UserControlAddWord()
        {
            InitializeComponent();
        }

        private void ButtonAddWord_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCategory.Text = TextBoxCategory.Text.Trim();
            TextBoxWordPL.Text = TextBoxWordPL.Text.Trim();
            TextBoxWordANG.Text = TextBoxWordANG.Text.Trim();
            if (TextBoxCategory.Text == "" || TextBoxWordPL.Text == "" || TextBoxWordANG.Text == "")
            {
                MessageBox.Show("Wpisz dane poprawnie");
            }
            else
            {
                DatabaseOperation.AddWord(TextBoxWordPL.Text, TextBoxWordANG.Text, TextBoxCategory.Text);
                TextBoxCategory.Text = "";
                TextBoxWordPL.Text = "";
                TextBoxWordANG.Text = "";
            }
        }
    }
}
