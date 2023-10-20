using System;
using System.ComponentModel;
using System.Windows;

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
            this.AllowsTransparency = true;
            InitializeComponent();
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
    }
}
