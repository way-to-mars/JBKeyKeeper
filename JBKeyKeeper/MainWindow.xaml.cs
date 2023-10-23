﻿using JBKeyKeeper.View;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace JBKeyKeeper
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string boundText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set {
                boundText = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("BoundText"));
            }
        }

        public MainWindow()
        {
            DataContext = this;
            Application.Current.MainWindow = this;  // to access MainWindow from customs

            InitializeComponent();
            WindowBody.Child = UI.ReadOnlyCreator.WindowBody(App.getJBBK().Items);
        }


        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine("Mouse In");
            this.Opacity = 1;
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine("Mouse gone");
            this.Opacity = 0.5;
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            return;
        }
    }
}
