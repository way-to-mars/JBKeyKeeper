using JBKeyKeeper.View;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace JBKeyKeeper.UI
{
    internal class ReadOnlyCreator
    {
        public static ScrollViewer WindowBody(IList<JBBKItem> sourceItems) {
            ScrollViewer scrollViewer = new ScrollViewer();
            scrollViewer.Content = StackPanel(sourceItems);
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            return scrollViewer;
        }

        private static StackPanel StackPanel(IList<JBBKItem> sourceItems)
        {
            StackPanel result = new StackPanel();

            foreach (JBBKItem sourceItem in sourceItems)
            {
                var itemView = ItemView(sourceItem);
                result.Children.Add(itemView);
            }

            return result;
        }

        private static JBBKItemView ItemView(JBBKItem sourceItem)
        {
            JBBKItemView result = new JBBKItemView();
            result.Expander.Header = sourceItem.Name;
            result.Expander.Content = PairsStackPanel(sourceItem.Fields);
            return result;
        }

        private static StackPanel PairsStackPanel(IList<JBBKPair> sourceList)
        {
            StackPanel result = new StackPanel();
            foreach (JBBKPair pairSource in sourceList)
            {
                JBBKPairView pairView = new JBBKPairView();
                pairView.ValueName.Text = pairSource.Name;
                pairView.Value.Text = pairSource.Value;
                pairView.Margin = new Thickness(10, 5, 10, 0);
                result.Children.Add(pairView);
            }
            return result;
        }
    }
}
