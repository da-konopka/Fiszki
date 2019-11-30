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
    /// Logika interakcji dla klasy UserControlStudy.xaml
    /// </summary>
    public partial class UserControlStudy : UserControl
    {
        public UserControlStudy()
        {
            InitializeComponent();

            DatabaseOperation.ViewCategoryInComboBox(ComboBoxCategory);
            LockAnswer.Visibility = Visibility.Hidden;
            TextBoxAnswer.Visibility = Visibility.Hidden;
        }

        private void LockAnswer_Click(object sender, RoutedEventArgs e)
        {
            DatabaseOperation.StudyCheckWord(LabelFiszka, TextBoxAnswer, LabelAnswer, LabelStatistics, LockAnswer);
            DatabaseOperation.ViewCategoryInComboBox(ComboBoxCategory);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxCategory.Text == "")
            {
                MessageBox.Show("Wybierz kategorie");
            }
            else
            {
                DatabaseOperation.LoadWordsToStudy(ComboBoxCategory.Text, LabelStatistics, TextBoxAnswer, LabelAnswer);
                DatabaseOperation.StudyViewWord(LabelFiszka, LockAnswer, TextBoxAnswer);
                LockAnswer.Visibility = Visibility.Visible;
                TextBoxAnswer.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DatabaseOperation.StudyCheckWord(LabelFiszka, TextBoxAnswer, LabelAnswer, LabelStatistics, LockAnswer);
            }
        }
    }
}
