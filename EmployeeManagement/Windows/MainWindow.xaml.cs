using EmployeeManagement.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // отследить изменения ширины всего окна
            this.SizeChanged += OnWindowSizeChanged;
          
        }
        #region HederStyle
        // отследить изменения ширины всего окна
        void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    nameBorder.BorderThickness = new Thickness(7);
                    labelMaxmin.Content = "❐";
                }
                else
                {
                    nameBorder.BorderThickness = new Thickness(2, 1, 2, 2);
                    labelMaxmin.Content = "☐";
                }
            }
        }
        // обрабатывает наведение на кнопку
        private void header_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                border.Background = Brushes.Red;
            else
            {
                border.Background = Brushes.Gray;
                border.Opacity = 0.7;
            }
        }
        // обрабатывает: мыша покидает кнопку
        private void header_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Color.FromRgb(71, 74, 81));
        }
        // обрабатывает нажатие на кнопку
        private void header_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                border.Background = Brushes.LightPink;
            else
            {
                border.Background = Brushes.Gray;
                border.Opacity = 1;
            }
        }
        // управение действием кнопок: закрыть, на весь экран, маленькое окно, свернуть на панель задач
        private void header_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border.Name == "close")
                Application.Current.Shutdown();
            else if (border.Name == "maxmin")
            {
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Maximized;
            }
            else
                this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажата кнопка в хедере");
        }
        #endregion

        #region MENU

        private void borderClick_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            string nameBorder = border.Name;

            switch (nameBorder)
            {
                case "btnProfile":
                    groupBoxMainFrame.Header = "Profile";
                    MainFrame.NavigationService.Navigate(new ProfilePage());
                    break;

                case "btnListEmployees":
                    groupBoxMainFrame.Header = "Employees";
                    MainFrame.NavigationService.Navigate(new ListEmployeesPage());
                    break;

                case "btnSchedule":
                    groupBoxMainFrame.Header = "Schedule";
                    MainFrame.NavigationService.Navigate(new SchedulePage());
                    break;

                case "btnEvent":
                    groupBoxMainFrame.Header = "Event";
                    MainFrame.NavigationService.Navigate(new EventPage());
                    break;
            }
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Color.FromRgb(71, 74, 81));
        }

        #endregion
    }

}