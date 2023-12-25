using System;
using System.ComponentModel;
using System.Windows;

namespace JBKeyKeeper
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public enum StateEnum { SHOW, CREATE, EDIT, HISTORY }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            DataContext = this;
            Application.Current.MainWindow = this;  // to access MainWindow from customs

            InitializeComponent();
            WindowBody.Child = UI.ReadOnlyCreator.WindowBody(App.GetJBBK().Items);
        }


        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine("Mouse In");
            this.Opacity = 1;

            // this.Effect = null;
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine("Mouse gone");
            this.Opacity = 0.75;
            // this.Effect = new BlurEffect() { Radius = 2 };
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            return;
        }
    }
}
