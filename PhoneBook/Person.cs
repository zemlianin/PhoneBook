using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PhoneBook
{
    class Person
    {
        internal static List<Person> contacts = new List<Person>();
        internal Person(string FirstName, string LastName, string Info)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.info = Info;
        }
        internal string firstName;
        internal string lastName;
        internal string info;


        internal void Show(ref StackPanel stackPanel)
        {
            var OnePerson = new Grid();
            OnePerson.Height = 40;
            OnePerson.ColumnDefinitions.Add(new ColumnDefinition());
            OnePerson.ColumnDefinitions.Add(new ColumnDefinition());
            OnePerson.ColumnDefinitions.Add(new ColumnDefinition());
            var firstNameBox = new TextBox();
            var lastNameBox = new TextBox();
            var infoBox = new TextBox();
            firstNameBox.Text = firstName;
            lastNameBox.Text = lastName;
            infoBox.Text = info;        
            OnePerson.Children.Add(firstNameBox);          
            Grid.SetColumn(firstNameBox, 0);
            OnePerson.Children.Add(lastNameBox);
            Grid.SetColumn(lastNameBox, 1);
            OnePerson.Children.Add(infoBox);
            Grid.SetColumn(infoBox, 2);
            stackPanel.Children.Add(OnePerson);
            Grid.SetColumn(OnePerson,3);
        }
    }
}
