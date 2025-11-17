using System.Data;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FixingСlicks();
        }

        public void FixingСlicks()
        {
            foreach (UIElement element in MainRoot.Children)
            {
                if (element is Button button)
                    ((Button) element).Click += ButtonClick;
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string valueOfButton = (string)((Button)e.OriginalSource).Content;

            if (valueOfButton == "AC")
                textLabel.Text = "";
            else if (valueOfButton == "=")
                textLabel.Text = new DataTable().Compute(textLabel.Text, null).ToString();
            else
                textLabel.Text += valueOfButton;
        }
    }
}