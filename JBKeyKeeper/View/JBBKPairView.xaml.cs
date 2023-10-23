using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JBKeyKeeper.View
{
    /// <summary>
    /// Логика взаимодействия для JBBKPairView.xaml
    /// </summary>
    public partial class JBBKPairView : UserControl
    {
        public JBBKPairView()
        {
            InitializeComponent();
        }

        private void UserControl_DragLeave(object sender, DragEventArgs e)
        {
            Console.WriteLine("JBBKPairView Drag Leave");
        }

        private void UserControl_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, this.Value.Text.ToString());

                // Initiate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
