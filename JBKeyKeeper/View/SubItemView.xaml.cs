using System.Windows.Controls;

namespace JBKeyKeeper.View
{
    /// <summary>
    /// Логика взаимодействия для SubItemView.xaml
    /// </summary>
    public partial class SubItemView : UserControl
    {
        public SubItemView(JBKKSubItem2 subItem)
        {
            InitializeComponent();
            Margin = new System.Windows.Thickness(5);

            Inflate(subItem);
        }

        private void Inflate(JBKKSubItem2 subItem)
        {
            NameHolder.Text = subItem.Name;
            NameEditor.Text = subItem.Name;

            if (subItem.Uri.Length > 0)
            {
                NameHolder.ToolTip = new ToolTip { Content = subItem.Uri };
                UrlEditor.Text = subItem.Uri;
            }
        }
    }
}
