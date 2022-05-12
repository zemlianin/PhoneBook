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
using Npgsql;
using System.Data.Common;
using System.IO;

namespace PhoneBook
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

       

       

      

        private void DownloadBook()
        {
            Person.contacts.Clear();
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1Q2w3e4r5t;Database=PhoneBook;";
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
                File.AppendAllText("log","Соединение с БД открыто\n");
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM people", npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                if (npgSqlDataReader.HasRows)
                {                   
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                        Person.contacts.Add( new Person(dbDataRecord["first_name"].ToString() , dbDataRecord["last_name"].ToString() , dbDataRecord["info"].ToString()));
                }
                else
                    MessageBox.Show("отсутствуют контакты");

            }
        }
        private void ShowContacts()
        {
            StackPanel.Children.Clear(); 
            for (int i = 0; i < Person.contacts.Count; i++)
            {

                Person.contacts[i].Show(ref StackPanel);
                
            }
            File.AppendAllText("log", "Данные выведены\n");
        }

      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("log", "");
            DownloadBook();
            ShowContacts();
            
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1Q2w3e4r5t;Database=PhoneBook;";
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
                File.AppendAllText("log", "Соединение с БД открыто\n");
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"INSERT INTO people VALUES ({Person.contacts.Count+1}, '{newName.Text}', '{newLastName.Text}', null)",npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                DownloadBook();
                ShowContacts();
            }
        }

        
    }
}
