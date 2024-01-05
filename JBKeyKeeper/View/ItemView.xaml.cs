using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace JBKeyKeeper.View
{
    /// <summary>
    /// Логика взаимодействия для ItemView.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        private event Action<Expander> OnExpanded;

        public ItemView(JBKKItem2 item, Action<Expander> OnExpandedEventHandler)
        {
            InitializeComponent();            
            OnExpanded = OnExpandedEventHandler;
            Inflate(item);
        }

        private void Inflate(JBKKItem2 item)
        {
            MainExpander.Header = item.Name;
            foreach(JBKKSubItem2 subItem in item.SubItems)
            {
                SubItemsList.Children.Add(new SubItemView(subItem));
            }
        }

        private void ItemName_Expanded(object sender, RoutedEventArgs e) => OnExpanded(sender as Expander);

        private void ItemName_Collapsed(object sender, RoutedEventArgs e) => Debug.WriteLine($"{sender} is collapsed");
    }
}
