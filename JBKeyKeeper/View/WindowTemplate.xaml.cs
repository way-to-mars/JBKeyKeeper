using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace JBKeyKeeper.View
{
    public partial class WindowTemplate : Window
    {
        JBKKContainer2 _JBBKContainer;

        public WindowTemplate()
        {
            MouseLeave += Window_MouseLeave;
            MouseEnter += Window_MouseEnter;

            InitializeComponent();

            _JBBKContainer = App.GetJBKK();

            Inflate(_JBBKContainer);
        }

        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) => Opacity = 1;

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e) => Opacity = 0.75;

        private void Inflate(JBKKContainer2 data)
        {
            WindowBody.Children.Clear();

            foreach (var item in data.Items)
                WindowBody.Children.Add(new ItemView(item, OnExpanderExpander));
        }

        private void OnExpanderExpander(Expander obj) =>
            WindowBody.Children.Cast<ItemView>()
                    .Select(itemView => itemView.MainExpander)
                    .Where(expander => expander != obj)
                    .ToList()
                    .ForEach(expander =>
                    {
                        if (expander.IsExpanded)
                        {
                            Debug.WriteLine($"{obj.Header} is closing {expander.Header}");
                            expander.IsExpanded = false;
                        }
                    });
    }
}
