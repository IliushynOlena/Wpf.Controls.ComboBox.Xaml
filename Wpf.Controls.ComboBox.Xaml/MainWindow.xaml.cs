using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Wpf.Controls.ComboBox.Xaml
{
    internal sealed partial class MainWindow : Window
    {
        //INotifyCollectionChanged
        ObservableCollection<Person> people = null;
        //List<Person> people = null;
        public MainWindow()
        {
            InitializeComponent();

            //people = new List<Person>()
            //{
            //    new Person() { Name = "Bogdan", Surname = "Bogdan", Birth = new System.DateTime(1990, 1, 1)},
            //    new Person() { Name = "Vikrotia", Surname = "Leveg", Birth = new System.DateTime(1994, 5, 10)},
            //    new Person() { Name = "Sasha", Surname = "Kofae", Birth = new System.DateTime(1980, 12, 14)}
            //};

            people = new ObservableCollection<Person>()
            {
                new Person() { Name = "Bogdan", Surname = "Bogdan", Birth = new System.DateTime(1990, 1, 1)},
                new Person() { Name = "Vikrotia", Surname = "Leveg", Birth = new System.DateTime(1994, 5, 10)},
                new Person() { Name = "Sasha", Surname = "Kofae", Birth = new System.DateTime(1980, 12, 14)}
            };

            // clear collection
            comboBox.Items.Clear();

            //foreach (var p in people)
            //{
            //    comboBox.Items.Add(p);
            //}

            // binding collection to list items
            comboBox.ItemsSource = people;                      // show ToString() by default

            // nameof - get object name as string value 
            // comboBox.DisplayMemberPath = "Fullname";   // show specific property
            //comboBox.DisplayMemberPath = nameof(Person.Name);   // show specific property
            comboBox.DisplayMemberPath = nameof(Person.FullName);
            //comboBox.DisplayMemberPath = $"{nameof(Person.Birth)}.{nameof(Person.Birth.Year)}";
            //comboBox.DisplayMemberPath = null;
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
            if (comboBox.SelectedItem != null)
            {
                MessageBox.Show(comboBox.SelectedItem.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newPerson = new Person() { Name = "New Name", Surname = "New Surname", 
                Birth = new System.DateTime(1990, 1, 1) };

            people.Add(newPerson);
            //comboBox.Items.Add(newPerson);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex != -1)
                people.RemoveAt(comboBox.SelectedIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            people.Clear();
           
        }
    }
}