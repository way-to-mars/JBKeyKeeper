﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace JBKeyKeeper.View
{
    public partial class ClearableTextBox : UserControl, INotifyPropertyChanged
    {

        private string placeholder;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Placeholder
        {
            get { return placeholder; }
            set {
                placeholder = value;
                tbPlaceholder.Text = placeholder;
             //   PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Placeholder"));
            }
        }

        public ClearableTextBox()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else
                tbPlaceholder.Visibility = Visibility.Hidden;
        }
    }
}
