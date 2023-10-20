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
            InitializeComponent();
        }
    }
}
