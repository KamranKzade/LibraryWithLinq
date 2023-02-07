﻿using LibraryWithLinq.DataAccess.SqlServer;
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

namespace LibraryWithLinq
{


    public partial class MainWindow : Window
    {
        MyLibraryDataClassesDataContext ldc = new MyLibraryDataClassesDataContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minimize_Btn(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Close_Btn(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (teacher_radio.IsChecked == true)
            {
                MessageBox.Show("Teacher");
            }
            else if (student_radio.IsChecked == true)
            {
                MessageBox.Show("Student");
            }

            else if (libs_radio.IsChecked == true)
            {
                MessageBox.Show("Libs");
            }
            else
            {
                MessageBox.Show("Secimlerden Birini edin-> RadioButtonlardan");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}