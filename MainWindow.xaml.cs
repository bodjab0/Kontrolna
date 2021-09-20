using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kontrolna
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            ViewModel viewModel= (ViewModel)DataContext;
            switch (e.Key)
            {
                case Key.Left: viewModel.MoveLeft.Execute(1); break;
                case Key.Up: viewModel.MoveUp.Execute(1); break;
                case Key.Right: viewModel.MoveRight.Execute(1); break;
                case Key.Down: viewModel.MoveDown.Execute(1); break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)e.OriginalSource;
            if (tb.Text == "") tb.Background = Brushes.Transparent;
            if (tb.Text == "2") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#eee4da"));
            if (tb.Text == "4") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ede0c8"));
            if (tb.Text == "8") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2b179"));
            if (tb.Text == "16") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f59563"));
            if (tb.Text == "32") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f67c5f"));
            if (tb.Text == "64") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f65e3b"));
            if (tb.Text == "128") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#edcf72"));
            if (tb.Text == "256") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#edcc61"));
            if (tb.Text == "512") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#edc53f"));
            if (tb.Text == "1024") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#edc53f"));
            if (tb.Text == "2048") tb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#edc22e"));
        }
    }
}
