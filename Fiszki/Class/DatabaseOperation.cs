using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media;

namespace Fiszki.Class
{
    class DatabaseOperation
    {
        public static string connectionString = "Data Source=DBfiszki.db;Version=3";
        public static List<Word> WordsList = new List<Word>();
        public static int i = 0;
        public static Random rand = new Random();
        public static int goodAnswer = 0;
        public static int badAnswer = 0;
        public static void ViewWordsList(DataGrid wordsList)
        {
            try
            {
                SQLiteConnection Connection = new SQLiteConnection(connectionString);
                Connection.Open();
                string query = "SELECT slowo_pl as 'Słowo PL', slowo_ang as 'Słowo ANG', kategoria as 'Kategoria' FROM slowka";
                SQLiteCommand c = new SQLiteCommand(query, Connection);
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(c);
                da.Fill(dt);
                wordsList.ItemsSource = dt.DefaultView;
                Connection.Close();
            }
            catch
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
            }
        }
        public static void ViewCategoryInComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            try
            {
                SQLiteConnection Connection = new SQLiteConnection(connectionString);
                Connection.Open();
                string query = "SELECT kategoria FROM slowka GROUP BY kategoria";
                SQLiteCommand c = new SQLiteCommand(query, Connection);
                SQLiteDataReader r = c.ExecuteReader();
                while (r.Read())
                {
                    string category = r.GetString(0);
                    comboBox.Items.Add(category);
                }
                Connection.Close();
            }
            catch
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
            }
        }
        public static void FindWord(DataGrid wordsList, string word)
        {
            word = word.ToLower();
            try
            {
                SQLiteConnection Connection = new SQLiteConnection(connectionString);
                Connection.Open();
                string query = "";
                if (word == "")
                {
                    query = "SELECT slowo_pl as 'Słowo PL', slowo_ang as 'Słowo ANG', kategoria as 'Kategoria' FROM slowka";

                }
                else
                {
                    query = "SELECT slowo_pl as 'Słowo PL', slowo_ang as 'Słowo ANG', kategoria as 'Kategoria' FROM slowka WHERE slowo_pl LIKE '%" + word + "%' OR slowo_ang LIKE '%" + word + "%' OR kategoria LIKE '%" + word + "%'";

                }
                SQLiteCommand c = new SQLiteCommand(query, Connection);
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(c);
                da.Fill(dt);
                wordsList.ItemsSource = dt.DefaultView;
                Connection.Close();
            }
            catch
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
            }
        }
        public static bool IfThere(string wordPL, string wordANG)
        {
            int count = 0;
            try
            {
                SQLiteConnection Connection = new SQLiteConnection(connectionString);
                Connection.Open();
                string query = "SELECT COUNT(*) FROM slowka WHERE slowo_pl= '" + wordPL + "' AND slowo_ang = '" + wordANG + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, Connection);

                count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Connection.Close();
                    return true;
                }
                else
                {
                    Connection.Close();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
                return true;
            }
        }
        public static void AddWord(string wordPL, string wordANG, string category)
        {
            wordPL = wordPL.ToLower();
            wordANG = wordANG.ToLower();
            category = category.ToLower();
            wordPL = wordPL.Trim();
            wordANG = wordANG.Trim();
            category = category.Trim();
            if (!IfThere(wordPL, wordANG))
            {
                try
                {
                    SQLiteConnection Connection = new SQLiteConnection(connectionString);
                    SQLiteCommand cmd = new SQLiteCommand(Connection);
                    Connection.Open();
                    cmd.CommandText = "INSERT INTO slowka(slowo_pl, slowo_ang, kategoria) VALUES ('" + wordPL + "','" + wordANG + "','" + category + "')";
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                }
                catch
                {
                    MessageBox.Show("Błąd łączenia z bazą danych");
                }
            }
            else
            {
                MessageBox.Show("Takie słówko istnieje w bazie danych");
            }
        }
        public static void AddWordTxt()
        {
            Encoding enc = Encoding.GetEncoding("Windows-1250");
            OpenFileDialog wczytaj = new OpenFileDialog();
            wczytaj.Filter = "Text files (*.txt)|*.txt";
            int i = 0;
            var result = wczytaj.ShowDialog();
            try
            {
                FileStream fs = new FileStream(wczytaj.FileName,
                FileMode.Open, FileAccess.Read);
                string line = "";
                string[] words;
                string category = "";
                string wordPL = "";
                string wordANG = "";

                StreamReader sr = new StreamReader(fs, enc);
                while ((line = sr.ReadLine()) != null)
                {
                    words = line.Split(';');
                    if (words.GetLength(0) == 1)
                    {
                        category = words[0];
                    }
                    else if (words.GetLength(0) == 2)
                    {
                        wordPL = words[1];
                        wordANG = words[0];

                        wordPL = wordPL.ToLower();
                        wordANG = wordANG.ToLower();
                        category = category.ToLower();
                        wordPL = wordPL.Trim();
                        wordANG = wordANG.Trim();
                        category = category.Trim();
                        AddWord(wordPL, wordANG, category);
                        i++;
                    }
                    else
                    {
                        MessageBox.Show("Zły format pliku.");
                    }
                    wordPL = "";
                    wordANG = "";
                    Array.Clear(words, 0, words.GetLength(0));
                }
                if(i>0)
                {
                    MessageBox.Show("Słówka dodane");
                }
                else
                {
                    MessageBox.Show("Nie udało się wczytać słówek");
                }
            }
            catch
            {
                
            }
        }
        public static void LoadWordsToStudy(string category, Label LabelStatistics, TextBox TextBoxAnswer, Label labelAnswer)
        {
            i = 0;
            goodAnswer = 0;
            badAnswer = 0;
            ViewStatistic(LabelStatistics);
            TextBoxAnswer.Text = "";
            labelAnswer.Content = "";
            WordsList.Clear();
            int id;
            string wordPL;
            string wordANG;
            try
            {
                SQLiteConnection Connection = new SQLiteConnection(connectionString);
                Connection.Open();
                string query = "SELECT id, slowo_pl, slowo_ang FROM slowka Where kategoria = '" + category + "'";
                SQLiteCommand c = new SQLiteCommand(query, Connection);
                SQLiteDataReader r = c.ExecuteReader();
                while (r.Read())
                {
                    id = r.GetInt32(0);
                    wordPL = r.GetString(1);
                    wordANG = r.GetString(2);
                    WordsList.Add(new Word(id, wordPL, wordANG, category));
                    i++;
                }
                Connection.Close();
            }
            catch
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
            }
        }
        public static void StudyViewWord(Label fiszka, Button lockAnswer, TextBox textBoxAnswer)
        {
            if (WordsList.Count() != 0)
            {
                i = rand.Next(0, WordsList.Count());
                fiszka.Content = WordsList[i].wordPL;
            }
            else
            {
                MessageBox.Show("Koniec");
                lockAnswer.Visibility = Visibility.Hidden;
                textBoxAnswer.Visibility = Visibility.Hidden;
            }
        }
        public static void StudyCheckWord(Label fiszka, TextBox textBoxAnswer, Label labelAnswer, Label labelStatistics, Button lockAnswer)
        {
            textBoxAnswer.Text = textBoxAnswer.Text.Trim();
            if(textBoxAnswer.Text == "")
            {
                MessageBox.Show("najpierw wprowadź odpowiedź");
            }
            else
            {
                textBoxAnswer.Text = textBoxAnswer.Text.ToLower();
                textBoxAnswer.Text = textBoxAnswer.Text.Trim();
                if (String.Equals(WordsList[i].wordANG, textBoxAnswer.Text))
                {
                    labelAnswer.Foreground = Brushes.Green;
                    labelAnswer.Content = textBoxAnswer.Text + " - Dobrze";
                    goodAnswer++;
                    textBoxAnswer.Text = "";
                    AddPkt(WordsList[i].wordPL, WordsList[i].wordANG);
                }
                else
                {
                    labelAnswer.Foreground = Brushes.Red;
                    labelAnswer.Content = textBoxAnswer.Text + " - Źle. Dobra odpowiedź to: " + WordsList[i].wordANG;
                    badAnswer++;
                    textBoxAnswer.Text = "";
                    ResetPkt(WordsList[i].wordPL, WordsList[i].wordANG, WordsList[i].category);
                }
                ViewStatistic(labelStatistics);
                WordsList.RemoveAt(i);
                StudyViewWord(fiszka, lockAnswer, textBoxAnswer);
            }
        }
        public static void ViewStatistic(Label LabelStatistics)
        {
            LabelStatistics.Content = "Dobre odpowiedzi: " + goodAnswer + "   Złe odpowiedzi: " + badAnswer;
        }
        public static void DeleteWord(DataGrid DataGridWordsList)
        {
            DataRowView dataRow = (DataRowView)DataGridWordsList.SelectedItem;
            string wordPL = dataRow.Row.ItemArray[0].ToString();
            string wordANG = dataRow.Row.ItemArray[1].ToString();
            string category = dataRow.Row.ItemArray[2].ToString();

            try
            {
                SQLiteConnection Connection = new SQLiteConnection(connectionString);
                SQLiteCommand cmd = new SQLiteCommand(Connection);
                Connection.Open();
                cmd.CommandText = "Delete from slowka where slowo_pl = '" + wordPL + "' AND slowo_ang = '" + wordANG + "'AND kategoria = '" + category + "'";
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch
            {
                MessageBox.Show("Błąd łączenia z bazą danych");
            }
        }
        public static void AddPkt(string WordPL, string WordANG)
        {
            int pkt = 0;
            SQLiteConnection Connection = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand(Connection);
            Connection.Open();
            cmd.CommandText = "UPDATE slowka SET poziom_nauczenia = poziom_nauczenia + 1 WHERE slowo_pl = '" + WordPL + "' AND slowo_ang = '" + WordANG + "'";
            cmd.ExecuteNonQuery();

            string query = "SELECT poziom_nauczenia FROM slowka WHERE slowo_pl= '" + WordPL + "' AND slowo_ang = '" + WordANG + "'";
            cmd = new SQLiteCommand(query, Connection);

            pkt = Convert.ToInt32(cmd.ExecuteScalar());

            if (pkt >= 3)
            {
                cmd.CommandText = "UPDATE slowka SET kategoria = 'nauczone' WHERE slowo_pl = '" + WordPL + "' AND slowo_ang = '" + WordANG + "'";
                cmd.ExecuteNonQuery();
            }

            Connection.Close();
        }
        public static void ResetPkt(string WordPL, string WordANG, string Category)
        {
            SQLiteConnection Connection = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand(Connection);
            Connection.Open();
            if(Category == "nauczone")
            {
                cmd.CommandText = "UPDATE slowka SET poziom_nauczenia = 0, kategoria = 'do powtórki' WHERE slowo_pl = '" + WordPL + "' AND slowo_ang = '" + WordANG + "'";
            }
            else
            {
                cmd.CommandText = "UPDATE slowka SET poziom_nauczenia = 0 WHERE slowo_pl = '" + WordPL + "' AND slowo_ang = '" + WordANG + "'";

            }
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
