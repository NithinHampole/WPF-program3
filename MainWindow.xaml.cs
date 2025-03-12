using System;
using System.Collections.Generic;
using System.Windows;

namespace DynamicUI
{
    public partial class MainWindow : Window
    {
        private Dictionary<int, string> studentData = new Dictionary<int, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(inputId1.Text.Trim());
                string name = inputName.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Student name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (studentData.ContainsKey(id))
                {
                    MessageBox.Show("Student ID already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    studentData.Add(id, name);

                    DisplayStudents();
                }


                inputId1.Clear();
                inputName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(inputId2.Text.Trim());

                if (studentData.ContainsKey(id))
                {
                    studentData.Remove(id);
                    DisplayStudents();
                }
                else
                {
                    MessageBox.Show("Student ID not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }


                inputId2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayStudents()
        {
            output.Clear();
            foreach (var student in studentData)
            {
                output.AppendText($"ID: {student.Key}, Name: {student.Value}\n");
            }
        }

       
}
}